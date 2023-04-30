Public Class frmAuthentication
    Dim xuserid As Integer
    Dim xcountx As Integer
    Dim ix As Double
    Private Sub frmAuthentication_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
        checkServer()
        xcountx = 0
        username = ""
        xuserid = xUser_ID
        xUser_ID = 0
        txtUserName.Select()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        End
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        InsertDefaultData()
        Dim timex As String
        ExecuteSQLQuery(" SELECT     tbl_users.User_ID, tbl_users.user_name, tbl_users.password, tbl_users.emp_id, tbl_employee.emp_name  FROM            tbl_users INNER JOIN " & _
                        "  tbl_employee ON tbl_users.emp_id = tbl_employee.emp_id " & _
                        " WHERE        (tbl_employee.status = 'Active') AND (tbl_users.user_name = '" & str_repl(txtUserName.Text) & "') AND (tbl_users.password = '" & str_repl(txtPassword.Text) & "') ")
        If sqlDT.Rows.Count > 0 Then
            'if match user name & password
            timex = TimeOfDay
            username = sqlDT.Rows(0)("user_name")
            xUserPassword = sqlDT.Rows(0)("password")
            xUser_ID = sqlDT.Rows(0)("User_ID")
            EMP_NAME = sqlDT.Rows(0)("emp_name")
            ExecuteSQLQuery("INSERT INTO  tbl_userlog (User_ID, Log_In) VALUES (" & xUser_ID & ", '" & timex & "')")
            ExecuteSQLQuery("SELECT * FROM  tbl_userlog ORDER BY Log_ID DESC")
            LOGID = sqlDT.Rows(0)("Log_ID")
            Audit_Trail(xUser_ID, TimeOfDay, "Login to system. ")

            txtPassword.Text = ""
            txtUserName.Text = ""

            LoadUserPermission(ProgressBar1)

            With frmMDIParent
                .lblEmployeeName.Text = "Welcome, " & EMP_NAME
                .Show()
            End With
            Me.Visible = False
        Else

            MsgBox("You have no permission to use this system, for further details please contact to your top managment system.", MsgBoxStyle.Information, "Warning.")
            xcountx = xcountx + 1
            If xcountx >= 3 Then
                MsgBox("You have reach the maximum time of login !!", MsgBoxStyle.Critical, "Error.")
                End
            End If
            Exit Sub

        End If
    End Sub
End Class