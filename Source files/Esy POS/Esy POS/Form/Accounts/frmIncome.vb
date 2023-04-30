Public Class frmIncome
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

    Private Sub LoadData()
        FillDataComboBox("SELECT * FROM ChartOfAccounts WHERE HACCID=1001 AND AcStatus='Active'", "CH_ACC_ID", "AccountnName", cmbCashBank)
        FillDataComboBox("SELECT * FROM ChartOfAccounts WHERE HACCID=2001 AND AcStatus='Active'", "CH_ACC_ID", "AccountnName", cmbReceivedFrom)
        LoadVoucher()
    End Sub

    Private Sub frmIncome_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnRefresh.PerformClick()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbCashBank.SelectedValue Is Nothing Or cmbCashBank.SelectedIndex = -1 Then
            MsgBox("Required: Cash – Bank", MsgBoxStyle.Information, "Information")
        ElseIf cmbReceivedFrom.SelectedValue Is Nothing Or cmbReceivedFrom.SelectedIndex = -1 Then
            MsgBox("Required: Received From", MsgBoxStyle.Information, "Information")
        ElseIf txtAmount.Text = "" Then
            MsgBox("Required: Amount", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtAmount.Text) Then
            MessageBox.Show("Required: Amount [Numeric Value].", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If btnSave.Text = "SAVE" Then
                ExecuteSQLQuery(" INSERT INTO Voucher (EntryDate ,CashBankID ,ReceivedAcID ,BillCarrier  ,Description ,ReceiptNo ,Amount, BillType) VALUES  " & _
                                " ('" & Format(dtpEntryDate.Value, "MM/dd/yyyy") & "' , " & cmbCashBank.SelectedValue & " ," & cmbReceivedFrom.SelectedValue & " ,'" + str_repl(txtCarrier.Text) + "' ,'" + str_repl(txtDescription.Text) + "' ,'" + str_repl(txtReceiptNo.Text) + "' ," & txtAmount.Text & " , 'Income') ")
                LoadData()
                dtpEntryDate.Value = Now
                txtCarrier.Text = ""
                txtDescription.Text = ""
                txtReceiptNo.Text = ""
                txtAmount.Text = ""
                Audit_Trail(xUser_ID, TimeOfDay, "Add a Chart Of Accounts")
                MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
            ElseIf btnSave.Text = "UPDATE" Then
                ExecuteSQLQuery(" UPDATE Voucher SET EntryDate= '" & Format(dtpEntryDate.Value, "MM/dd/yyyy") & "' ,CashBankID= " & cmbCashBank.SelectedValue & ",ReceivedAcID =" & cmbReceivedFrom.SelectedValue & ",BillCarrier= '" + str_repl(txtCarrier.Text) + "' ,Description='" + str_repl(txtDescription.Text) + "' ,ReceiptNo='" + str_repl(txtReceiptNo.Text) + "' ,Amount= " & txtAmount.Text & " " & _
                                 " WHERE BILL_NO= " & txtBillNo.Text & " ")
                LoadData()
                txtBillNo.Text = ""
                dtpEntryDate.Value = Now
                txtCarrier.Text = ""
                txtDescription.Text = ""
                txtReceiptNo.Text = ""
                txtAmount.Text = ""
                Audit_Trail(xUser_ID, TimeOfDay, "Update Chart Of Accounts")
                btnSave.Text = "SAVE"
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub LoadVoucher()
        FillDataGrid(" SELECT   Voucher.BILL_NO, Voucher.EntryDate, ChartOfAccounts.AccountnName AS CashBank, ChartOfAccounts_1.AccountnName AS ReceivedFrom, Voucher.BillCarrier, Voucher.Description, Voucher.ReceiptNo, Voucher.Amount " & _
                     " FROM  Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID " & _
                     " WHERE Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "'  AND Voucher.BillType='Income' ", dgvVoucherList)
    End Sub
    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        LoadVoucher()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        LoadVoucher()
    End Sub

    Private Sub dgvVoucherList_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVoucherList.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure you want to edit this account?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                ExecuteSQLQuery("SELECT * FROM Voucher WHERE BILL_NO= " & dgvVoucherList.CurrentRow.Cells(2).Value & " ")
                txtBillNo.Text = dgvVoucherList.CurrentRow.Cells(2).Value
                dtpEntryDate.Value = sqlDT.Rows(0)("EntryDate")
                txtCarrier.Text = sqlDT.Rows(0)("BillCarrier")
                txtDescription.Text = sqlDT.Rows(0)("Description")
                txtReceiptNo.Text = sqlDT.Rows(0)("ReceiptNo")
                txtAmount.Text = sqlDT.Rows(0)("Amount")
                cmbCashBank.SelectedValue = sqlDT.Rows(0)("CashBankID")
                cmbReceivedFrom.SelectedValue = sqlDT.Rows(0)("ReceivedAcID")
                btnSave.Text = "UPDATE"
            End If
        ElseIf e.ColumnIndex = 1 Then
            If MsgBox("Are you sure you want to delete this account?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                ExecuteSQLQuery("DELETE FROM Voucher WHERE BILL_NO= " & dgvVoucherList.CurrentRow.Cells(2).Value & " ")
                LoadData()
                MsgBox("Record deleted successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub cmbCashBank_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCashBank.SelectedValueChanged
        If cmbCashBank.SelectedValue Is Nothing Or cmbCashBank.SelectedIndex = -1 Then
        Else
            ExecuteSQLQuery(" SELECT * FROM   ChartOfAccounts  WHERE  (CH_ACC_ID =  " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") ")
            Dim OpeningBalance As Double
            If sqlDT.Rows.Count > 0 Then
                OpeningBalance = sqlDT.Rows(0)("OpeningBalance")
            Else
                OpeningBalance = "0"
            End If

            'Debit Amount
            Dim DR_1, DR_2 As Double
            ExecuteSQLQuery("SELECT  * FROM            Voucher  WHERE   (CashBankID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Income' ")
            If sqlDT.Rows.Count > 0 Then
                ExecuteSQLQuery("SELECT   SUM(Amount) AS Expr1  FROM   Voucher   WHERE        (CashBankID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Income'")
                DR_1 = sqlDT.Rows(0)("Expr1")
            Else
                DR_1 = 0
            End If

            ExecuteSQLQuery("SELECT  * FROM            Voucher  WHERE   (CashBankID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Transfer' ")
            If sqlDT.Rows.Count > 0 Then
                ExecuteSQLQuery("SELECT   SUM(Amount) AS Expr1  FROM   Voucher   WHERE        (CashBankID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Transfer'")
                DR_2 = sqlDT.Rows(0)("Expr1")
            Else
                DR_2 = 0
            End If


            'Credit Amount
            Dim CR_1, CR_2 As Double
            ExecuteSQLQuery("SELECT  * FROM            Voucher  WHERE   (CashBankID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Expenses'")
            If sqlDT.Rows.Count > 0 Then
                ExecuteSQLQuery("SELECT   SUM(Amount) AS Expr1  FROM   Voucher   WHERE        (CashBankID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Expenses'")
                CR_1 = sqlDT.Rows(0)("Expr1")
            Else
                CR_1 = 0
            End If

            ExecuteSQLQuery("SELECT  * FROM            Voucher  WHERE   (ReceivedAcID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Transfer'")
            If sqlDT.Rows.Count > 0 Then
                ExecuteSQLQuery("SELECT   SUM(Amount) AS Expr1  FROM   Voucher   WHERE        (ReceivedAcID = " & num_fltr(cmbCashBank.SelectedValue.ToString) & ") AND BillType='Transfer'")
                CR_2 = sqlDT.Rows(0)("Expr1")
            Else
                CR_2 = 0
            End If


            txtDebitBalance.Text = OpeningBalance + (DR_1 - DR_2) - (CR_1 - CR_2)
        End If
    End Sub

End Class