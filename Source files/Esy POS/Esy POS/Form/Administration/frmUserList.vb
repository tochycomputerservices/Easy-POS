Public Class frmUserList
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

    Private Sub frmUserList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch.Select()
        LoadUsers()
    End Sub

    Private Sub LoadUsers()

        sqlSTR = " SELECT        User_ID, emp_name, user_name, reg_date  " & _
                 " FROM            tbl_employee INNER JOIN  tbl_users ON tbl_employee.emp_id = tbl_users.emp_id  "
        FillDataGrid(sqlSTR, dgvUsers)
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count > 0 Then
            lblCount.Text = "Total " & sqlDT.Rows.Count & " users found."
        Else
            lblCount.Text = "Total 0 user found."
        End If
    End Sub

    Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
        If txtSearch.Text = "" Then
            LoadUsers()
        Else
            sqlSTR = " SELECT        User_ID, emp_name, user_name, reg_date  " & _
                     " FROM            tbl_employee INNER JOIN  tbl_users ON tbl_employee.emp_id = tbl_users.emp_id  " & _
                     "  WHERE      (tbl_users.user_name LIKE '" & str_repl(txtSearch.Text) & "%') "
            FillDataGrid(sqlSTR, dgvUsers)
            ExecuteSQLQuery(sqlSTR)
            If sqlDT.Rows.Count > 0 Then
                lblCount.Text = "Total " & sqlDT.Rows.Count & " users found."
            Else
                lblCount.Text = "Total 0 user found."
            End If
        End If
    End Sub

    Private Sub dgvUsers_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvUsers.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure to edit: " & dgvUsers.CurrentRow.Cells(3).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                ExecuteSQLQuery(" SELECT        tbl_users.User_ID, tbl_users.user_name, tbl_users.password, tbl_users.emp_id, tbl_employee.emp_name " & _
                                " FROM            tbl_users INNER JOIN  tbl_employee ON tbl_users.emp_id = tbl_employee.emp_id  WHERE        (tbl_users.User_ID = " & dgvUsers.CurrentRow.Cells(1).Value & ") ")
                If sqlDT.Rows.Count > 0 Then
                    With frmUserManagement
                        .txtPassword.Text = sqlDT.Rows(0)("password")
                        .txtRePassword.Text = sqlDT.Rows(0)("password")
                        .txtUserName.Text = sqlDT.Rows(0)("user_name")
                        .txtUserName.Enabled = False
                        .txtUserID.Text = sqlDT.Rows(0)("User_ID")
                        .cmbEmployee.SelectedValue = sqlDT.Rows(0)("emp_id")
                        .MdiParent = frmMDIParent
                        .Show()
                        .btnSave.Text = "UPDATE"
                    End With
                End If
            End If
        End If
    End Sub
End Class