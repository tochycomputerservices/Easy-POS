Public Class frmScreenLock

    Private Sub frmScreenLock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPassword.Select()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If txtPassword.Text = "" Then
        Else
            If xUserPassword = txtPassword.Text Then
                Audit_Trail(xUser_ID, TimeOfDay, "Dispose lock screen.")
                txtPassword.Text = ""
                Me.Close()
            Else
                MsgBox("Wrong password.", MsgBoxStyle.Critical, "Critical")
            End If
        End If
    End Sub
End Class