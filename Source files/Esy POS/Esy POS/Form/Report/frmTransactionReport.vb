Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlServerCe

Public Class frmTransactionReport
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadReport()
        crpSharedBalance.Value = 0
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\TransactionReport.rpt")
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
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        ExecuteSQLQuery(" DELETE FROM tbl_Transaction ")
        If rbAllTransaction.Checked = True Then
            ExecuteSQLQuery("SELECT *  FROM  Voucher")
            If sqlDT.Rows.Count > 0 Then
                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Income')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Income') ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Expenses')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Expenses') ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') ")
                End If


                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts_1.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') ")
                End If

                crpSharedDate.Value = ""
                LoadReport()
            Else
                MsgBox("No data found.", MsgBoxStyle.Information, "Information")
            End If
        ElseIf rbDateWiseTrns.Checked = True Then
            ExecuteSQLQuery("SELECT *  FROM  Voucher WHERE        (EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "')")
            If sqlDT.Rows.Count > 0 Then

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Income')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Income') " & _
                                    "  AND (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Expenses')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Expenses') " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If

                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Paid, Received, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If


                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Transfer')")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts_1.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Transfer') " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If

                crpSharedDate.Value = " From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")
                LoadReport()

            Else
                MsgBox("No data found.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub
End Class