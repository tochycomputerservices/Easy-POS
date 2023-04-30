Public Class frmUserTrail
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

    Private Sub frmUserTrail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDataComboBox("SELECT *  FROM    tbl_users", "User_ID", "user_name", cmbUser)
        cmbUser.Select()
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If cmbUser.SelectedValue Is Nothing Or cmbUser.SelectedIndex = -1 Then
            MsgBox("Required: User name", MsgBoxStyle.Information, "Information")
        Else
            sqlSTR = " SELECT   tbl_usertrail.Action, tbl_usertrail.Date, tbl_usertrail.Timex, tbl_userlog.Log_In, tbl_userlog.Log_Out  FROM            tbl_usertrail INNER JOIN " & _
                     " tbl_userlog ON tbl_usertrail.log_ID = tbl_userlog.Log_ID " & _
                     " WHERE        (tbl_usertrail.User_ID = " & cmbUser.SelectedValue & ") AND (tbl_usertrail.Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_usertrail.Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') "
            FillDataGrid(sqlSTR, dtgRecord)
            ExecuteSQLQuery(sqlSTR)
            If sqlDT.Rows.Count > 0 Then
                lblCount.Text = "Total " & sqlDT.Rows.Count & " threads found."
            Else
                lblCount.Text = "Total 0 thread found."
            End If
        End If
    End Sub
End Class