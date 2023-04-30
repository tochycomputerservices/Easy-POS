Imports System.IO
Imports System.Data.SqlServerCe
Public Class frmCustomer
    Dim x, y As Integer
    Dim newpoint As New Point
    Private Sub lblCaption_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCaption.MouseDown
        x = Control.MousePosition.X - Me.Location.X
        y = Control.MousePosition.Y - Me.Location.Y
    End Sub

    Private Sub lblCaption_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblCaption.MouseMove
        If e.Button = Windows.Forms.MouseButtons.Left Then
            newpoint = Control.MousePosition
            newpoint.X -= x
            newpoint.Y -= y
            Me.Location = newpoint
            Application.DoEvents()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmCusomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCustomerName.Select()
        LoadCustomer()
    End Sub

    Private Sub LoadCustomer()
        FillDataGrid("SELECT customer_id,customer_name,address,phone,balance_date,status FROM tbl_customer", dgvCustomer)
        ExecuteSQLQuery("SELECT * FROM tbl_customer")
        If sqlDT.Rows.Count > 0 Then
            lblCount.Text = "Total " & sqlDT.Rows.Count & " customers found."
        Else
            lblCount.Text = "Total 0 customer found."
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadCustomer()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtCustomerName.Text = "" Then
            MsgBox("Required: Customer Name", MsgBoxStyle.Information, "Information")
        ElseIf cmbStatus.Text = "" Then
            MsgBox("Required: Status", MsgBoxStyle.Information, "Information")
        Else
            If btnSave.Text = "SAVE" Then
                'new customer add statement 
                ExecuteSQLQuery(" INSERT INTO tbl_customer (customer_name,address,phone,balance_date,status) VALUES " & _
                                " ( '" + str_repl(txtCustomerName.Text) + "', '" + str_repl(txtAddress.Text) + "', '" + str_repl(txtPhone.Text) + "', '" & Format(dtpBalanceDate.Value, "MM/dd/yyyy") & "', '" + str_repl(cmbStatus.Text) + "' ) ")
                'get inserted customer id
                ExecuteSQLQuery("SELECT   customer_id  FROM   tbl_customer  ORDER BY customer_id DESC")
                Dim CUST_ID As Double = sqlDT.Rows(0)("customer_id")
                'Update image using the customer id
                uploadImage(CUST_ID)
                txtCustomerID.Text = ""
                txtCustomerName.Text = ""
                txtAddress.Text = ""
                txtPhone.Text = ""
                dtpBalanceDate.Value = Now
                cmbStatus.SelectedIndex = -1
                PictureBox1.BackgroundImage = Esy_POS.My.Resources.no_image_2
                LoadCustomer()
                Audit_Trail(xUser_ID, TimeOfDay, "Add a new customer")
                MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
            ElseIf btnSave.Text = "UPDATE" Then
                'Update customer information
                ExecuteSQLQuery(" UPDATE  tbl_customer SET  customer_name='" + str_repl(txtCustomerName.Text) + "', address='" + str_repl(txtAddress.Text) + "', phone='" + str_repl(txtPhone.Text) + "', balance_date='" & Format(dtpBalanceDate.Value, "MM/dd/yyyy") & "', status='" + str_repl(cmbStatus.Text) + "'  " & _
                                " WHERE customer_id=" & txtCustomerID.Text & " ")
                'Update image using customer id
                uploadImage(txtCustomerID.Text)
                txtCustomerID.Text = ""
                txtCustomerName.Text = ""
                txtAddress.Text = ""
                txtPhone.Text = ""
                dtpBalanceDate.Value = Now
                cmbStatus.SelectedIndex = -1
                PictureBox1.BackgroundImage = Esy_POS.My.Resources.no_image_2
                btnSave.Text = "SAVE"
                LoadCustomer()
                Audit_Trail(xUser_ID, TimeOfDay, "Update customer profile")
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub

    Private Sub uploadImage(ByVal CUST_ID As Double)
        Dim con As New SqlCeConnection(CnString)
        con.Open()
        Dim sql As String = "UPDATE  tbl_customer SET  photo=@photo WHERE customer_id=" & CUST_ID & " "
        Dim cmd As New SqlCeCommand(sql, con)
        Dim ms As New MemoryStream()
        PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
        Dim data As Byte() = ms.GetBuffer()
        Dim p As New SqlCeParameter("@photo", SqlDbType.Image)
        p.Value = data
        cmd.Parameters.Add(p)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()
    End Sub

    Private Sub dgvCustomer_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCustomer.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure to edit: " & dgvCustomer.CurrentRow.Cells(2).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                On Error Resume Next
                ExecuteSQLQuery("SELECT * FROM tbl_customer WHERE customer_id=" & dgvCustomer.CurrentRow.Cells(1).Value & " ")
                txtCustomerID.Text = sqlDT.Rows(0)("customer_id")
                txtCustomerName.Text = sqlDT.Rows(0)("customer_name")
                txtAddress.Text = sqlDT.Rows(0)("address")
                txtPhone.Text = sqlDT.Rows(0)("phone")
                dtpBalanceDate.Value = sqlDT.Rows(0)("balance_date")
                cmbStatus.Text = sqlDT.Rows(0)("status")
                Dim bytBLOBData() As Byte = sqlDT.Rows(0)("photo")
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                PictureBox1.BackgroundImage = Image.FromStream(stmBLOBData)
                btnSave.Text = "UPDATE"
            End If
        End If
    End Sub

End Class