Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlServerCe
Public Class frmCashBankStatementReport
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim clr_count As Integer = 3
    Dim COL_ID As Double
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

    Private Sub LoadReport()
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\CashStatement.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = " SELECT   ID, TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account  FROM  tbl_Transaction ORDER BY Bill_No"
            my_Command.Connection = My_Connection
            my_Command.CommandType = CommandType.Text
            my_DataAdapter.SelectCommand = my_Command
            my_DataAdapter.Fill(my_DataSource, "tbl_Transaction")
            rpt_Document.SetDataSource(my_DataSource)

            ParamCollection.Add(crpSharedDate)
            rpt_Document.DataDefinition.ParameterFields("SharedDate").ApplyCurrentValues(ParamCollection)

            ParamCollection.Add(crpSharedBalance)
            rpt_Document.DataDefinition.ParameterFields("OpeningBalance").ApplyCurrentValues(ParamCollection)

            .CrystalReportViewer1.ReportSource = rpt_Document
            .Show()
        End With
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmCashBankStatementReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDataComboBox("SELECT * FROM ChartOfAccounts WHERE HACCID=1001 AND AcStatus='Active'", "CH_ACC_ID", "AccountnName", cmbCashBank)
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        ExecuteSQLQuery(" DELETE FROM tbl_Transaction ")
        If cmbCashBank.SelectedValue Is Nothing Or cmbCashBank.SelectedIndex = -1 Then
            MsgBox("Required: Cash – Bank", MsgBoxStyle.Information, "Information")
        Else

            If rbAllTransaction.Checked = True Then

                ExecuteSQLQuery("SELECT  * FROM    ChartOfAccounts   WHERE  (CH_ACC_ID = " & cmbCashBank.SelectedValue & ")")
                If sqlDT.Rows.Count > 0 Then
                    crpSharedBalance.Value = sqlDT.Rows(0)("OpeningBalance")
                Else
                    crpSharedBalance.Value = 0
                End If


                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Income') AND (CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Income') AND (Voucher.CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                End If


                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Expenses') AND (CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Expenses') AND (Voucher.CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer') AND (CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') AND (Voucher.CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer') AND (ReceivedAcID =  " & cmbCashBank.SelectedValue & ")  ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts_1.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') AND (Voucher.ReceivedAcID =  " & cmbCashBank.SelectedValue & ") ")
                End If

                crpSharedDate.Value = "Statement of " & cmbCashBank.Text
                LoadReport()



            ElseIf rbDateWiseTrns.Checked = True Then
                '---------------------------------
                Dim OpeningBalance As Double
                ExecuteSQLQuery("SELECT  * FROM    ChartOfAccounts   WHERE  (CH_ACC_ID = " & cmbCashBank.SelectedValue & ")")
                If sqlDT.Rows.Count > 0 Then
                    OpeningBalance = sqlDT.Rows(0)("OpeningBalance")
                Else
                    OpeningBalance = 0
                End If

                Dim Income As Double
                ExecuteSQLQuery("SELECT * FROM            Voucher WHERE        (BillType = N'Income') AND (CashBankID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery("SELECT SUM(Amount) AS Expr1 FROM            Voucher WHERE        (BillType = N'Income') AND (CashBankID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                    Income = sqlDT.Rows(0)("Expr1")
                Else
                    Income = 0
                End If

                Dim Expenses As Double
                ExecuteSQLQuery("SELECT * FROM            Voucher WHERE        (BillType = N'Expenses') AND (CashBankID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery("SELECT SUM(Amount) AS Expr1 FROM            Voucher WHERE        (BillType = N'Expenses') AND (CashBankID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                    Expenses = sqlDT.Rows(0)("Expr1")
                Else
                    Expenses = 0
                End If

                Dim Transfer As Double
                ExecuteSQLQuery("SELECT * FROM            Voucher WHERE        (BillType = N'Transfer') AND (CashBankID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery("SELECT SUM(Amount) AS Expr1 FROM            Voucher WHERE        (BillType = N'Transfer') AND (CashBankID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                    Transfer = sqlDT.Rows(0)("Expr1")
                Else
                    Transfer = 0
                End If


                Dim Transfer2 As Double
                ExecuteSQLQuery("SELECT * FROM            Voucher WHERE        (BillType = N'Transfer') AND (ReceivedAcID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery("SELECT SUM(Amount) AS Expr1 FROM            Voucher WHERE        (BillType = N'Transfer') AND (ReceivedAcID = " & cmbCashBank.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                    Transfer2 = sqlDT.Rows(0)("Expr1")
                Else
                    Transfer2 = 0
                End If


                crpSharedBalance.Value = OpeningBalance + (Income - Transfer) - (Expenses - Transfer2)

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Income') AND (CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Income') AND (Voucher.CashBankID =  " & cmbCashBank.SelectedValue & ") " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If


                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Expenses') AND (CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Expenses') AND (Voucher.CashBankID =  " & cmbCashBank.SelectedValue & ") " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer') AND (CashBankID =  " & cmbCashBank.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') AND (Voucher.CashBankID =  " & cmbCashBank.SelectedValue & ") " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer') AND (ReceivedAcID =  " & cmbCashBank.SelectedValue & ")  ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts_1.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') AND (Voucher.ReceivedAcID =  " & cmbCashBank.SelectedValue & ") " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If



                crpSharedDate.Value = "Statement of " & cmbCashBank.Text & " From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")
                LoadReport()
                '---------------------------------
            End If

        End If
    End Sub
End Class