Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlServerCe

Public Class frmLedgerBook
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

    Private Sub LoadIncomeStatement()
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\LedgerBook.rpt")
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

    Private Sub frmLedgerBook_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDataComboBox("SELECT * FROM ChartOfAccounts WHERE (NOT (HACCID = 1001)) AND (AcStatus = 'Active') ", "CH_ACC_ID", "AccountnName", cmbAccounts)
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        ExecuteSQLQuery(" DELETE FROM tbl_Transaction ")
        If cmbAccounts.SelectedValue Is Nothing Or cmbAccounts.SelectedIndex = -1 Then
            MsgBox("Required: Cash – Bank", MsgBoxStyle.Information, "Information")
        Else
            'Income statement
            ExecuteSQLQuery("SELECT  * FROM  ChartOfAccounts  WHERE   (CH_ACC_ID = " & cmbAccounts.SelectedValue & ") AND (HACCID = 2001)")
            If sqlDT.Rows.Count > 0 Then
                If rbAllTransaction.Checked = True Then
                    ExecuteSQLQuery("SELECT  * FROM    ChartOfAccounts   WHERE  (CH_ACC_ID = " & cmbAccounts.SelectedValue & ")")
                    If sqlDT.Rows.Count > 0 Then
                        crpSharedBalance.Value = sqlDT.Rows(0)("OpeningBalance")
                    Else
                        crpSharedBalance.Value = 0
                    End If

                    ExecuteSQLQuery("SELECT *  FROM  Voucher  WHERE   (ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                    If sqlDT.Rows.Count > 0 Then

                        ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Income') AND (ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                        If sqlDT.Rows.Count > 0 Then
                            ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                            " SELECT        Voucher.EntryDate, ChartOfAccounts.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts_1.AccountnName " & _
                                            " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Income') AND (Voucher.ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                        End If


                    End If

                    crpSharedDate.Value = "Ledger Book of " & cmbAccounts.Text
                    LoadIncomeStatement()

                ElseIf rbDateWiseTrns.Checked = True Then
                    Dim OpeningBalance As Double
                    ExecuteSQLQuery("SELECT  * FROM    ChartOfAccounts   WHERE  (CH_ACC_ID = " & cmbAccounts.SelectedValue & ")")
                    If sqlDT.Rows.Count > 0 Then
                        OpeningBalance = sqlDT.Rows(0)("OpeningBalance")
                    Else
                        OpeningBalance = 0
                    End If


                    Dim Income As Double
                    ExecuteSQLQuery("SELECT * FROM            Voucher WHERE        (BillType = N'Income') AND (ReceivedAcID = " & cmbAccounts.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                    If sqlDT.Rows.Count > 0 Then
                        ExecuteSQLQuery("SELECT SUM(Amount) AS Expr1 FROM            Voucher WHERE        (BillType = N'Income') AND (ReceivedAcID = " & cmbAccounts.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                        Income = sqlDT.Rows(0)("Expr1")
                    Else
                        Income = 0
                    End If

                    crpSharedBalance.Value = OpeningBalance + Income


                    ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Income') AND (ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                    If sqlDT.Rows.Count > 0 Then
                        ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                        " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                        " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Income') AND (Voucher.ReceivedAcID =  " & cmbAccounts.SelectedValue & ") " & _
                                        "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                    End If


                    crpSharedDate.Value = "Ledger Book of " & cmbAccounts.Text & " From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")
                    LoadIncomeStatement()

                End If
            End If

        End If

        'Expenses statement
        ExecuteSQLQuery("SELECT  * FROM  ChartOfAccounts  WHERE   (CH_ACC_ID = " & cmbAccounts.SelectedValue & ") AND (HACCID = 3001)")
        If sqlDT.Rows.Count > 0 Then
            If rbAllTransaction.Checked = True Then


                ExecuteSQLQuery("SELECT  * FROM    ChartOfAccounts   WHERE  (CH_ACC_ID = " & cmbAccounts.SelectedValue & ")")
                If sqlDT.Rows.Count > 0 Then
                    crpSharedBalance.Value = sqlDT.Rows(0)("OpeningBalance")
                Else
                    crpSharedBalance.Value = 0
                End If

                ExecuteSQLQuery("SELECT *  FROM  Voucher  WHERE   (ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then

                    ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Expenses') AND (ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                    If sqlDT.Rows.Count > 0 Then
                        ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                        " SELECT        Voucher.EntryDate, ChartOfAccounts.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts_1.AccountnName " & _
                                        " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Expenses') AND (Voucher.ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                    End If


                End If

                crpSharedDate.Value = "Ledger Book of " & cmbAccounts.Text
                LoadIncomeStatement()

            ElseIf rbDateWiseTrns.Checked = True Then

                Dim OpeningBalance As Double
                ExecuteSQLQuery("SELECT  * FROM    ChartOfAccounts   WHERE  (CH_ACC_ID = " & cmbAccounts.SelectedValue & ")")
                If sqlDT.Rows.Count > 0 Then
                    OpeningBalance = sqlDT.Rows(0)("OpeningBalance")
                Else
                    OpeningBalance = 0
                End If


                Dim Income As Double
                ExecuteSQLQuery("SELECT * FROM            Voucher WHERE        (BillType = N'Expenses') AND (ReceivedAcID = " & cmbAccounts.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery("SELECT SUM(Amount) AS Expr1 FROM            Voucher WHERE        (BillType = N'Expenses') AND (ReceivedAcID = " & cmbAccounts.SelectedValue & ") AND (EntryDate <= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (EntryDate = '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "'))")
                    Income = sqlDT.Rows(0)("Expr1")
                Else
                    Income = 0
                End If

                crpSharedBalance.Value = OpeningBalance + Income


                ExecuteSQLQuery("SELECT  *  FROM            Voucher  WHERE        (BillType = N'Expenses') AND (ReceivedAcID =  " & cmbAccounts.SelectedValue & ") ")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" INSERT INTO tbl_Transaction (TRNS_DATE, Description, Bill_No, Receipt_No, Received, Paid, Account) " & _
                                    " SELECT        Voucher.EntryDate, ChartOfAccounts_1.AccountnName + '--' + Voucher.Description AS Expr1, Voucher.BILL_NO, Voucher.ReceiptNo, Voucher.Amount, 0 AS Expr2, ChartOfAccounts.AccountnName " & _
                                    " FROM            Voucher INNER JOIN ChartOfAccounts ON Voucher.CashBankID = ChartOfAccounts.CH_ACC_ID INNER JOIN ChartOfAccounts AS ChartOfAccounts_1 ON Voucher.ReceivedAcID = ChartOfAccounts_1.CH_ACC_ID  WHERE        (Voucher.BillType = N'Expenses') AND (Voucher.ReceivedAcID =  " & cmbAccounts.SelectedValue & ") " & _
                                    "  AND        (Voucher.EntryDate >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND Voucher.EntryDate <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                End If


                crpSharedDate.Value = "Ledger Book of " & cmbAccounts.Text & " From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")
                LoadIncomeStatement()



            End If
        End If

    End Sub
End Class