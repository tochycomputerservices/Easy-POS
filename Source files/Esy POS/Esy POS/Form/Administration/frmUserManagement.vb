Public Class frmUserManagement
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
    Private Sub frmUserManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbEmployee.Select()
        FillDataComboBox("SELECT * FROM   tbl_employee", "emp_id", "emp_name", cmbEmployee)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        FillDataComboBox("SELECT * FROM   tbl_employee", "emp_id", "emp_name", cmbEmployee)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbEmployee.SelectedValue Is Nothing Or cmbEmployee.SelectedIndex = -1 Then
            MsgBox("Required: Employee Name", MsgBoxStyle.Information, "Information")
        ElseIf txtUserName.Text = "" Then
            MsgBox("Required: User name", MsgBoxStyle.Information, "Information")
        ElseIf txtPassword.Text = "" Then
            MsgBox("Required: Password", MsgBoxStyle.Information, "Information")
        ElseIf txtRePassword.Text = "" Then
            MsgBox("Required: Re-Password", MsgBoxStyle.Information, "Information")
        ElseIf Not txtPassword.Text = txtRePassword.Text Then
            MsgBox("Required: Password Does not match", MsgBoxStyle.Critical, "Critical")
        Else
            If btnSave.Text = "SAVE" Then

                'Check into database if the username exist.
                ExecuteSQLQuery(" SELECT * FROM tbl_users WHERE  user_name='" + str_repl(txtUserName.Text) + "' ")
                If sqlDT.Rows.Count > 0 Then
                    MsgBox("User name already exist.", MsgBoxStyle.Critical, "Critical")
                Else
                    'Insert a new user
                    ExecuteSQLQuery(" INSERT INTO tbl_users (user_name,password,emp_id,reg_date) VALUES " & _
                                   " ( '" + str_repl(txtUserName.Text) + "', '" + str_repl(txtPassword.Text) + "', " & cmbEmployee.SelectedValue & " , '" & Format(Now, "MM/dd/yyyy") & "' )  ")

                    Audit_Trail(xUser_ID, TimeOfDay, "Add a new user.")
                    txtPassword.Text = ""
                    txtRePassword.Text = ""
                    txtUserName.Text = ""
                    txtUserID.Text = ""
                    cmbEmployee.SelectedIndex = -1
                    MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")

                End If

            ElseIf btnSave.Text = "UPDATE" Then

                'Update user password only
                ExecuteSQLQuery(" UPDATE tbl_users  SET  password='" + str_repl(txtPassword.Text) + "', emp_id =" & cmbEmployee.SelectedValue & "   " & _
                                " WHERE        (User_ID = " & txtUserID.Text & ")  ")

                Audit_Trail(xUser_ID, TimeOfDay, "Update user password.")

                txtPassword.Text = ""
                txtRePassword.Text = ""
                txtUserName.Text = ""
                txtUserID.Text = ""
                txtUserID.Enabled = True
                cmbEmployee.SelectedIndex = -1
                btnSave.Text = "SAVE"
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub btnListView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListView.Click
        frmUserList.MdiParent = frmMDIParent
        frmUserList.Show()
    End Sub
End Class