Public Class frmChartOfAccounts
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
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmChartOfAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnRefresh.PerformClick()
    End Sub

    Private Sub LoadData()
        FillDataComboBox("SELECT * FROM HeadOfAccounts", "HACCID", "HeadOfAccountsName", cmbHeadOfAc)
        FillDataGrid(" SELECT CH_ACC_ID, HeadOfAccountsName, AccountnName, OpeningBalance, OpeningDate FROM ChartOfAccounts  " & _
                     " INNER JOIN HeadOfAccounts ON ChartOfAccounts.HACCID = HeadOfAccounts.HACCID ORDER BY ChartOfAccounts.HACCID, ChartOfAccounts.CH_ACC_ID ", dgvChartOfAccounts)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnEditHeadAc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditHeadAc.Click
        If cmbHeadOfAc.SelectedValue Is Nothing Or cmbHeadOfAc.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Head Of Account from combo box.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Dim message, title, defaultValue, myValue As String
            title = "Head Of Accounts"
            message = "Head of account name"
            ExecuteSQLQuery(" SELECT * FROM HeadOfAccounts  WHERE HACCID=" & cmbHeadOfAc.SelectedValue & " ")
            defaultValue = sqlDT.Rows(0)("HeadOfAccountsName").ToString()
            myValue = Interaction.InputBox(message, title, defaultValue, 220, 200)
            If myValue = "" Then
                MessageBox.Show("No data input.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                ExecuteSQLQuery(" UPDATE HeadOfAccounts SET HeadOfAccountsName='" & myValue & "' WHERE HACCID=" & cmbHeadOfAc.SelectedValue & " ")
                LoadData()
                MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbHeadOfAc.SelectedValue Is Nothing Or cmbHeadOfAc.SelectedIndex = -1 Then
            MsgBox("Required: Head Of Accounts", MsgBoxStyle.Information, "Information")
        ElseIf txtAccountName.Text = "" Then
            MsgBox("Required: Account’s Name", MsgBoxStyle.Information, "Information")
        ElseIf txtOpeningBalance.Text = "" Then
            MsgBox("Required: Opening Balance", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtOpeningBalance.Text) Then
            MessageBox.Show("Required: Opening Balance [Numeric Value].", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf cmbStatus.Text = "" Then
            MsgBox("Required: Status", MsgBoxStyle.Information, "Information")
        Else
            If btnSave.Text = "SAVE" Then
                ExecuteSQLQuery(" INSERT INTO ChartOfAccounts (HACCID, AccountnName, OpeningBalance ,OpeningDate, AcStatus) VALUES (" & cmbHeadOfAc.SelectedValue & ", '" + str_repl(txtAccountName.Text) + "', " & txtOpeningBalance.Text & " ,'" & Format(Now, "MM/dd/yyyy") & "', '" + str_repl(cmbStatus.Text) + "') ")
                LoadData()
                txtAcID.Text = ""
                txtAccountName.Text = ""
                cmbStatus.Text = ""
                txtOpeningBalance.Text = ""
                Audit_Trail(xUser_ID, TimeOfDay, "Add a Chart Of Accounts")
                MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
            ElseIf btnSave.Text = "UPDATE" Then
                ExecuteSQLQuery(" UPDATE  ChartOfAccounts SET  HACCID=" & cmbHeadOfAc.SelectedValue & ", AccountnName='" + str_repl(txtAccountName.Text) + "', OpeningBalance=" & txtOpeningBalance.Text & " ,OpeningDate='" & Format(Now, "MM/dd/yyyy") & "', AcStatus= '" + str_repl(cmbStatus.Text) + "' WHERE CH_ACC_ID=" & txtAcID.Text & " ")
                LoadData()
                txtAcID.Text = ""
                txtAccountName.Text = ""
                txtOpeningBalance.Text = ""
                cmbStatus.Text = ""
                Audit_Trail(xUser_ID, TimeOfDay, "Update Chart Of Accounts")
                btnSave.Text = "SAVE"
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub dgvChartOfAccounts_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvChartOfAccounts.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure you want to edit this account?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                ExecuteSQLQuery("SELECT * FROM ChartOfAccounts WHERE CH_ACC_ID= " & dgvChartOfAccounts.CurrentRow.Cells(2).Value & " ")
                txtAcID.Text = sqlDT.Rows(0)("CH_ACC_ID")
                txtAccountName.Text = sqlDT.Rows(0)("AccountnName")
                txtOpeningBalance.Text = sqlDT.Rows(0)("OpeningBalance")
                cmbStatus.Text = sqlDT.Rows(0)("AcStatus")
                cmbHeadOfAc.SelectedValue = sqlDT.Rows(0)("HACCID")
                btnSave.Text = "UPDATE"
            End If
        ElseIf e.ColumnIndex = 1 Then
            If MsgBox("Are you sure you want to delete this account?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM ChartOfAccounts WHERE CH_ACC_ID= " & dgvChartOfAccounts.CurrentRow.Cells(2).Value & " ")
                MsgBox("Record deleted successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub
End Class