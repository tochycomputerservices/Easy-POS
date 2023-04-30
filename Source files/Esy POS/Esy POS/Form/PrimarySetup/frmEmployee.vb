Imports System.IO
Imports System.Data.SqlServerCe
Public Class frmEmployee
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

    Private Sub frmEmployee_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEmployeeName.Select()
        loadEmployee()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtEmployeeName.Text = "" Then
            MsgBox("Required: Employee Name", MsgBoxStyle.Information, "Information")
        ElseIf cmbStatus.Text = "" Then
            MsgBox("Required: Status", MsgBoxStyle.Information, "Information")
        Else
            If btnSave.Text = "SAVE" Then
                'insert  a new employee 
                ExecuteSQLQuery(" INSERT INTO tbl_employee (emp_name,address,phone,join_date,special_note,status) VALUES " & _
                                " ('" + str_repl(txtEmployeeName.Text) + "', '" + str_repl(txtAddress.Text) + "', '" + str_repl(txtPhone.Text) + "', '" & Format(dtpJoinDate.Value, "MM/dd/yyyy") & "', '" + str_repl(txtNote.Text) + "', '" + str_repl(cmbStatus.Text) + "') ")
                'get employee inserted id no
                ExecuteSQLQuery("SELECT   emp_id  FROM   tbl_employee  ORDER BY emp_id DESC")
                Dim EMPL_ID As Double = sqlDT.Rows(0)("emp_id")
                'Upload image into database
                uploadImage(EMPL_ID)
                txtEmployeeID.Text = ""
                txtEmployeeName.Text = ""
                txtAddress.Text = ""
                txtPhone.Text = ""
                txtNote.Text = ""
                dtpJoinDate.Value = Now
                cmbStatus.SelectedIndex = -1
                PictureBox1.BackgroundImage = Esy_POS.My.Resources.no_image_2
                loadEmployee()
                Audit_Trail(xUser_ID, TimeOfDay, "Add a new employee")
                MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
            ElseIf btnSave.Text = "UPDATE" Then
                'Update employee 
                ExecuteSQLQuery(" UPDATE tbl_employee SET emp_name='" + str_repl(txtEmployeeName.Text) + "',address='" + str_repl(txtAddress.Text) + "',phone='" + str_repl(txtPhone.Text) + "',join_date='" & Format(dtpJoinDate.Value, "MM/dd/yyyy") & "',special_note='" + str_repl(txtNote.Text) + "',status='" + str_repl(cmbStatus.Text) + "'  " & _
                                " WHERE emp_id=" & txtEmployeeID.Text & " ")
                'Image update using employee id
                uploadImage(txtEmployeeID.Text)
                txtEmployeeID.Text = ""
                txtEmployeeName.Text = ""
                txtAddress.Text = ""
                txtPhone.Text = ""
                txtNote.Text = ""
                dtpJoinDate.Value = Now
                cmbStatus.SelectedIndex = -1
                PictureBox1.BackgroundImage = Esy_POS.My.Resources.no_image_2
                loadEmployee()
                btnSave.Text = "SAVE"
                Audit_Trail(xUser_ID, TimeOfDay, "Update employee information.")
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If


    End Sub
    Private Sub loadEmployee()
        FillDataGrid(" SELECT emp_id,emp_name,address,phone,join_date,status FROM   tbl_employee", dgvEmployee)
        ExecuteSQLQuery("SELECT * FROM tbl_employee")
        If sqlDT.Rows.Count > 0 Then
            lblCount.Text = "Total " & sqlDT.Rows.Count & " employee found."
        Else
            lblCount.Text = "Total 0 employee found."
        End If
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
    Private Sub uploadImage(ByVal EMPL_ID As Double)
        Dim con As New SqlCeConnection(CnString)
        con.Open()
        Dim sql As String = "UPDATE  tbl_employee SET  photo=@photo  WHERE emp_id=" & EMPL_ID & " "
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

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        loadEmployee()
    End Sub

    Private Sub dgvEmployee_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvEmployee.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure to edit: " & dgvEmployee.CurrentRow.Cells(2).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                On Error Resume Next
                ExecuteSQLQuery("SELECT * FROM tbl_employee WHERE emp_id=" & dgvEmployee.CurrentRow.Cells(1).Value & " ")
                txtEmployeeID.Text = sqlDT.Rows(0)("emp_id")
                txtEmployeeName.Text = sqlDT.Rows(0)("emp_name")
                txtAddress.Text = sqlDT.Rows(0)("address")
                txtPhone.Text = sqlDT.Rows(0)("phone")
                dtpJoinDate.Value = sqlDT.Rows(0)("join_date")
                cmbStatus.Text = sqlDT.Rows(0)("status")
                txtNote.Text = sqlDT.Rows(0)("special_note")
                Dim bytBLOBData() As Byte = sqlDT.Rows(0)("photo")
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                PictureBox1.BackgroundImage = Image.FromStream(stmBLOBData)
                btnSave.Text = "UPDATE"
            End If
        End If
    End Sub
End Class