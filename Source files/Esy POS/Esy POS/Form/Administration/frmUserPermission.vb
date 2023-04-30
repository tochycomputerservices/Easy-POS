Public Class frmUserPermission
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

    Private Sub LoadAccessKey()
        ProgressBar1.Visible = True
        ProgressBar1.Value = 20
        '-------ACTION-CODE- 101
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 101)")
        If sqlDT.Rows.Count > 0 Then
            chk101.Checked = True
        Else
            chk101.Checked = False
        End If
        '-------ACTION-CODE- 102
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 102)")
        If sqlDT.Rows.Count > 0 Then
            chk102.Checked = True
        Else
            chk102.Checked = False
        End If
        '-------ACTION-CODE- 103
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 103)")
        If sqlDT.Rows.Count > 0 Then
            chk103.Checked = True
        Else
            chk103.Checked = False
        End If
        '-------ACTION-CODE- 104
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 104)")
        If sqlDT.Rows.Count > 0 Then
            chk104.Checked = True
        Else
            chk104.Checked = False
        End If
        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 201
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 201)")
        If sqlDT.Rows.Count > 0 Then
            chk201.Checked = True
        Else
            chk201.Checked = False
        End If
        '-------ACTION-CODE- 202
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 202)")
        If sqlDT.Rows.Count > 0 Then
            chk202.Checked = True
        Else
            chk202.Checked = False
        End If
        '-------ACTION-CODE- 203
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 203)")
        If sqlDT.Rows.Count > 0 Then
            chk203.Checked = True
        Else
            chk203.Checked = False
        End If
        '-------ACTION-CODE- 204
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 204)")
        If sqlDT.Rows.Count > 0 Then
            chk204.Checked = True
        Else
            chk204.Checked = False
        End If
        '-------ACTION-CODE- 205
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 205)")
        If sqlDT.Rows.Count > 0 Then
            chk205.Checked = True
        Else
            chk205.Checked = False
        End If
        '-------ACTION-CODE- 206
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 206)")
        If sqlDT.Rows.Count > 0 Then
            chk206.Checked = True
        Else
            chk206.Checked = False
        End If
        '-------ACTION-CODE- 207
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 207)")
        If sqlDT.Rows.Count > 0 Then
            chk207.Checked = True
        Else
            chk207.Checked = False
        End If
        '-------ACTION-CODE- 208
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 208)")
        If sqlDT.Rows.Count > 0 Then
            chk208.Checked = True
        Else
            chk208.Checked = False
        End If
        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 301
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 301)")
        If sqlDT.Rows.Count > 0 Then
            chk301.Checked = True
        Else
            chk301.Checked = False
        End If
        '-------ACTION-CODE- 302
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 302)")
        If sqlDT.Rows.Count > 0 Then
            chk302.Checked = True
        Else
            chk302.Checked = False
        End If
        '-------ACTION-CODE- 303
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 303)")
        If sqlDT.Rows.Count > 0 Then
            chk303.Checked = True
        Else
            chk303.Checked = False
        End If
        '-------ACTION-CODE- 304
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 304)")
        If sqlDT.Rows.Count > 0 Then
            chk304.Checked = True
        Else
            chk304.Checked = False
        End If

        '-------ACTION-CODE- 305
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 305)")
        If sqlDT.Rows.Count > 0 Then
            chk305.Checked = True
        Else
            chk305.Checked = False
        End If

        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 401
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 401)")
        If sqlDT.Rows.Count > 0 Then
            chk401.Checked = True
        Else
            chk401.Checked = False
        End If
        '-------ACTION-CODE- 402
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 402)")
        If sqlDT.Rows.Count > 0 Then
            chk402.Checked = True
        Else
            chk402.Checked = False
        End If
        '-------ACTION-CODE- 403
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 403)")
        If sqlDT.Rows.Count > 0 Then
            chk403.Checked = True
        Else
            chk403.Checked = False
        End If
        '-------ACTION-CODE- 404
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 404)")
        If sqlDT.Rows.Count > 0 Then
            chk404.Checked = True
        Else
            chk404.Checked = False
        End If
        '-------ACTION-CODE- 405
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 405)")
        If sqlDT.Rows.Count > 0 Then
            chk405.Checked = True
        Else
            chk405.Checked = False
        End If
        '-------ACTION-CODE- 406
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 406)")
        If sqlDT.Rows.Count > 0 Then
            chk406.Checked = True
        Else
            chk406.Checked = False
        End If
        '-------ACTION-CODE- 407
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 407)")
        If sqlDT.Rows.Count > 0 Then
            chk407.Checked = True
        Else
            chk407.Checked = False
        End If
        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 501
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 501)")
        If sqlDT.Rows.Count > 0 Then
            chk501.Checked = True
        Else
            chk501.Checked = False
        End If
        '-------ACTION-CODE- 502
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 502)")
        If sqlDT.Rows.Count > 0 Then
            chk502.Checked = True
        Else
            chk502.Checked = False
        End If
        '-------ACTION-CODE- 503
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 503)")
        If sqlDT.Rows.Count > 0 Then
            chk503.Checked = True
        Else
            chk503.Checked = False
        End If
        '-------ACTION-CODE- 504
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 504)")
        If sqlDT.Rows.Count > 0 Then
            chk504.Checked = True
        Else
            chk504.Checked = False
        End If
        '-------ACTION-CODE- 505
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 505)")
        If sqlDT.Rows.Count > 0 Then
            chk505.Checked = True
        Else
            chk505.Checked = False
        End If
        '-------ACTION-CODE- 506
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 506)")
        If sqlDT.Rows.Count > 0 Then
            chk506.Checked = True
        Else
            chk506.Checked = False
        End If

        '-------ACTION-CODE- 507
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 507)")
        If sqlDT.Rows.Count > 0 Then
            chk507.Checked = True
        Else
            chk507.Checked = False
        End If

        '-------ACTION-CODE- 508
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 508)")
        If sqlDT.Rows.Count > 0 Then
            chk508.Checked = True
        Else
            chk508.Checked = False
        End If

        '-------ACTION-CODE- 509
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 509)")
        If sqlDT.Rows.Count > 0 Then
            chk509.Checked = True
        Else
            chk509.Checked = False
        End If

        '-------ACTION-CODE- 510
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 510)")
        If sqlDT.Rows.Count > 0 Then
            chk510.Checked = True
        Else
            chk510.Checked = False
        End If

        '-------ACTION-CODE- 511
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 511)")
        If sqlDT.Rows.Count > 0 Then
            chk511.Checked = True
        Else
            chk511.Checked = False
        End If

        '-------ACTION-CODE- 601
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 601)")
        If sqlDT.Rows.Count > 0 Then
            chk601.Checked = True
        Else
            chk601.Checked = False
        End If


        '-------ACTION-CODE- 602
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 602)")
        If sqlDT.Rows.Count > 0 Then
            chk602.Checked = True
        Else
            chk602.Checked = False
        End If


        '-------ACTION-CODE- 603
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 603)")
        If sqlDT.Rows.Count > 0 Then
            chk603.Checked = True
        Else
            chk603.Checked = False
        End If

        '-------ACTION-CODE- 604
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 604)")
        If sqlDT.Rows.Count > 0 Then
            chk604.Checked = True
        Else
            chk604.Checked = False
        End If

        ProgressBar1.Visible = False
    End Sub

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If cmbUser.SelectedValue Is Nothing Or cmbUser.SelectedIndex = -1 Then
            MsgBox("Required: User name", MsgBoxStyle.Information, "Information")
        Else
            ProgressBar1.Visible = True
            ProgressBar1.Value = 20
            '-------ACTION-CODE- 101
            If chk101.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 101)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 101) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 101)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 101) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 102
            If chk102.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 102)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 102) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 102)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 102) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 103
            If chk103.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 103)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 103) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 103)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 103) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 104
            If chk103.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 104)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 104) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 104)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 104) ")
                Else
                End If
            End If
            ProgressBar1.Value = ProgressBar1.Value + 20
            '-------ACTION-CODE- 201
            If chk201.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 201)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 201) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 201)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 201) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 202
            If chk202.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 202)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 202) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 202)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 202) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 203
            If chk203.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 203)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 203) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 203)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 203) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 204
            If chk204.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 204)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 204) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 204)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 204) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 205
            If chk205.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 205)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 205) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 205)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 205) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 206
            If chk206.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 206)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 206) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 206)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 206) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 207
            If chk207.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 207)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 207) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 207)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 207) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 208
            If chk208.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 208)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 208) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 208)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 208) ")
                Else
                End If
            End If

            ProgressBar1.Value = ProgressBar1.Value + 20
            '-------ACTION-CODE- 301
            If chk301.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 301)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 301) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 301)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 301) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 302
            If chk302.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 302)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 302) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 302)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 302) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 303
            If chk303.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 303)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 303) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 303)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 303) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 304
            If chk304.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 304)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 304) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 304)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 304) ")
                Else
                End If
            End If


            '-------ACTION-CODE- 305
            If chk305.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 305)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 305) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 305)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 305) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 401
            If chk401.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 401)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 401) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 401)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 401) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 402
            If chk402.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 402)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 402) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 402)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 402) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 403
            If chk403.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 403)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 403) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 403)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 403) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 404
            If chk404.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 404)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 404) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 404)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 404) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 405
            If chk405.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 405)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 405) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 405)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 405) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 406
            If chk406.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 406)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 406) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 406)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 406) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 407
            If chk407.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 407)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 407) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 407)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 407) ")
                Else
                End If
            End If
            ProgressBar1.Value = ProgressBar1.Value + 20
            '-------ACTION-CODE- 501
            If chk501.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 501)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 501) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 501)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 501) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 502
            If chk502.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 502)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 502) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 502)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 502) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 503
            If chk503.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 503)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 503) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 503)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 503) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 504
            If chk504.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 504)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 504) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 504)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 504) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 505
            If chk505.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 505)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 505) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 505)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 505) ")
                Else
                End If
            End If
            '-------ACTION-CODE- 506
            If chk506.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 506)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 506) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 506)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 506) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 507
            If chk507.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 507)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 507) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 507)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 507) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 508
            If chk508.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 508)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 508) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 508)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 508) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 509
            If chk509.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 509)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 509) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 509)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 509) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 510
            If chk510.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 510)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 510) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 510)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 510) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 511
            If chk511.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 511)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 511) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 511)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 511) ")
                Else
                End If
            End If


            '-------ACTION-CODE- 601
            If chk601.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 601)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 601) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 601)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 601) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 602
            If chk602.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 602)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 602) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 602)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 602) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 603
            If chk603.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 603)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 603) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 603)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 603) ")
                Else
                End If
            End If

            '-------ACTION-CODE- 604
            If chk604.Checked Then
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 604)")
                If sqlDT.Rows.Count > 0 Then
                Else
                    ExecuteSQLQuery(" INSERT INTO tbl_permission ( User_ID, AccessKey) VALUES (" & cmbUser.SelectedValue & ", 604) ")
                End If
            Else
                ExecuteSQLQuery("SELECT        User_ID, AccessKey FROM            tbl_permission   WHERE        (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 604)")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" DELETE FROM tbl_permission WHERE (User_ID = " & cmbUser.SelectedValue & ") AND (AccessKey = 604) ")
                Else
                End If
            End If

            ProgressBar1.Visible = False
            Audit_Trail(xUser_ID, TimeOfDay, "Set user permission.")
            MsgBox("Setting saved.", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub frmUserPermission_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDataComboBox(" SELECT * FROM    tbl_users ", "User_ID", "user_name", cmbUser)
        cmbUser.Select()
        ProgressBar1.Visible = False
    End Sub

    Private Sub btnPermission_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPermission.Click
        If cmbUser.SelectedValue Is Nothing Or cmbUser.SelectedIndex = -1 Then
            MsgBox("Required: User name", MsgBoxStyle.Information, "Information")
        Else
            LoadAccessKey()
        End If
    End Sub
End Class