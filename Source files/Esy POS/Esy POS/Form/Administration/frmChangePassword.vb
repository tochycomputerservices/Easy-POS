Public Class frmChangePassword
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
    Private Sub frmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCurrentPassword.Select()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtCurrentPassword.Text = "" Then
            MsgBox("Required: Old Password", MsgBoxStyle.Information, "Information")
        ElseIf txtNewPassword.Text = "" Then
            MsgBox("Required: New Password", MsgBoxStyle.Information, "Information")
        ElseIf txtRePassword.Text = "" Then
            MsgBox("Required: Re-password", MsgBoxStyle.Information, "Information")
        ElseIf Not (txtNewPassword.Text = txtRePassword.Text) Then
            MsgBox("New password and re-password does not match.", MsgBoxStyle.Information, "Information")
        Else
            ExecuteSQLQuery("SELECT  *  FROM            tbl_users  WHERE        (User_ID = " & xUser_ID & ") AND (password = '" & str_repl(txtCurrentPassword.Text) & "')")
            If sqlDT.Rows.Count > 0 Then
                Dim msg As String
                msg = "Would you like to change this password?"
                If MsgBox(msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Question...") = MsgBoxResult.Yes Then
                    ExecuteSQLQuery(" UPDATE  tbl_users SET password = '" & str_repl(txtRePassword.Text) & "' WHERE        User_ID = " & xUser_ID & "")
                    Audit_Trail(xUser_ID, TimeOfDay, "Change Password.")
                    MsgBox("Password successfully changed.", MsgBoxStyle.Information, "Information")
                    Me.Close()
                End If
            Else
                MsgBox("Sorry! Current password does not match.", MsgBoxStyle.Critical, "Critical")
            End If
        End If
    End Sub
End Class