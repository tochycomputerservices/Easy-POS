Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlServerCe
Public Class frmChartOfAccountsReport
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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub LoadReport(ByVal sqlQry As String)
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\ChartOfAccounts.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = sqlQry
            my_Command.Connection = My_Connection
            my_Command.CommandType = CommandType.Text
            my_DataAdapter.SelectCommand = my_Command
            my_DataAdapter.Fill(my_DataSource, "ChartOfAccounts")
            rpt_Document.SetDataSource(my_DataSource)
            .CrystalReportViewer1.ReportSource = rpt_Document
            .Show()
        End With
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        If rbShowAll.Checked = True Then
            LoadReport(" SELECT        ChartOfAccounts.HACCID, HeadOfAccounts.HeadOfAccountsName, ChartOfAccounts.CH_ACC_ID, ChartOfAccounts.AccountnName, ChartOfAccounts.OpeningBalance, ChartOfAccounts.OpeningDate, ChartOfAccounts.AcStatus " & _
                       " FROM            HeadOfAccounts INNER JOIN ChartOfAccounts ON HeadOfAccounts.HACCID = ChartOfAccounts.HACCID ")
        ElseIf rbActive.Checked = True Then
            LoadReport(" SELECT        ChartOfAccounts.HACCID, HeadOfAccounts.HeadOfAccountsName, ChartOfAccounts.CH_ACC_ID, ChartOfAccounts.AccountnName, ChartOfAccounts.OpeningBalance, ChartOfAccounts.OpeningDate, ChartOfAccounts.AcStatus " & _
                       " FROM            HeadOfAccounts INNER JOIN ChartOfAccounts ON HeadOfAccounts.HACCID = ChartOfAccounts.HACCID WHERE (ChartOfAccounts.AcStatus = 'Active') ")
        ElseIf rbDeActive.Checked = True Then
            LoadReport(" SELECT        ChartOfAccounts.HACCID, HeadOfAccounts.HeadOfAccountsName, ChartOfAccounts.CH_ACC_ID, ChartOfAccounts.AccountnName, ChartOfAccounts.OpeningBalance, ChartOfAccounts.OpeningDate, ChartOfAccounts.AcStatus " & _
           " FROM            HeadOfAccounts INNER JOIN ChartOfAccounts ON HeadOfAccounts.HACCID = ChartOfAccounts.HACCID WHERE (ChartOfAccounts.AcStatus = 'Deactive') ")
        End If
    End Sub
End Class