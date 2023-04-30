Imports System.IO
Imports System.Data.SqlServerCe
Public Class frmSupplier
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
    Private Sub frmSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSupplierName.Select()
        LoadSupplier()
    End Sub
    Private Sub LoadSupplier()
        FillDataGrid("SELECT supplier_id,supplier_name,address,phone,balance_date,status FROM tbl_supplier", dgvSupplier)
        ExecuteSQLQuery("SELECT * FROM tbl_supplier")
        If sqlDT.Rows.Count > 0 Then
            lblCount.Text = "Total " & sqlDT.Rows.Count & " suppliers found."
        Else
            lblCount.Text = "Total 0 supplier found."
        End If
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtSupplierName.Text = "" Then
            MsgBox("Required: Supplier Name", MsgBoxStyle.Information, "Information")
        ElseIf cmbStatus.Text = "" Then
            MsgBox("Required: Status", MsgBoxStyle.Information, "Information")
        Else
            If btnSave.Text = "SAVE" Then
                ExecuteSQLQuery(" INSERT INTO tbl_supplier (supplier_name,address,phone,balance_date,status) VALUES " & _
                                " ( '" + str_repl(txtSupplierName.Text) + "', '" + str_repl(txtAddress.Text) + "', '" + str_repl(txtPhone.Text) + "', '" & Format(dtpBalanceDate.Value, "MM/dd/yyyy") & "', '" + str_repl(cmbStatus.Text) + "' ) ")
                ExecuteSQLQuery("SELECT   supplier_id  FROM   tbl_supplier  ORDER BY supplier_id DESC")
                Dim SUPP_ID As Double = sqlDT.Rows(0)("supplier_id")
                uploadImage(SUPP_ID)
                txtSupplierId.Text = ""
                txtSupplierName.Text = ""
                txtAddress.Text = ""
                txtPhone.Text = ""
                dtpBalanceDate.Value = Now
                cmbStatus.SelectedIndex = -1
                PictureBox1.BackgroundImage = Esy_POS.My.Resources.no_image_2
                LoadSupplier()
                MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
            ElseIf btnSave.Text = "UPDATE" Then
                ExecuteSQLQuery(" UPDATE  tbl_supplier SET supplier_name='" + str_repl(txtSupplierName.Text) + "',address='" + str_repl(txtAddress.Text) + "',phone='" + str_repl(txtPhone.Text) + "',balance_date='" & Format(dtpBalanceDate.Value, "MM/dd/yyyy") & "',status='" + str_repl(cmbStatus.Text) + "' " & _
                                " WHERE supplier_id=" & txtSupplierId.Text & " ")
                uploadImage(txtSupplierId.Text)
                txtSupplierId.Text = ""
                txtSupplierName.Text = ""
                txtAddress.Text = ""
                txtPhone.Text = ""
                dtpBalanceDate.Value = Now
                cmbStatus.SelectedIndex = -1
                PictureBox1.BackgroundImage = Esy_POS.My.Resources.no_image_2
                btnSave.Text = "SAVE"
                LoadSupplier()
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadSupplier()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub uploadImage(ByVal SUPP_ID As Double)
        Dim con As New SqlCeConnection(CnString)
        con.Open()
        Dim sql As String = "UPDATE  tbl_supplier SET  photo=@photo  WHERE supplier_id=" & SUPP_ID & " "
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

    Private Sub dgvSupplier_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSupplier.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure to edit: " & dgvSupplier.CurrentRow.Cells(2).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                On Error Resume Next
                ExecuteSQLQuery("SELECT * FROM tbl_supplier WHERE supplier_id=" & dgvSupplier.CurrentRow.Cells(1).Value & " ")
                txtSupplierId.Text = sqlDT.Rows(0)("supplier_id")
                txtSupplierName.Text = sqlDT.Rows(0)("supplier_name")
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