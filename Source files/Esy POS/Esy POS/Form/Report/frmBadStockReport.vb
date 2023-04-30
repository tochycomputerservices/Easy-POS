Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlServerCe
Public Class frmBadStockReport
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

    Private Sub rbCategoryWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCategoryWise.CheckedChanged
        If rbCategoryWise.Checked Then
            cmbCategory.Enabled = True
        Else
            cmbCategory.Enabled = False
        End If
    End Sub

    Private Sub frmBadStockReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDataComboBox("SELECT  *  FROM  tbl_category", "category_id", "category_name", cmbCategory)
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        LoadCompanyDetails()
        If rbCategoryWise.Checked Then
            If cmbCategory.SelectedValue Is Nothing Or cmbCategory.SelectedIndex = -1 Then
                MsgBox("Required: Category", MsgBoxStyle.Information, "Information")
            Else
                '--------------------------------
                LoadReport(" SELECT        tbl_bad_stock.stock_id, tbl_item.item_name, tbl_bad_stock.quantity, tbl_bad_stock.uom, tbl_bad_stock.entry_date, tbl_bad_stock.cost, tbl_bad_stock.reason, tbl_item.category_id " & _
                           " FROM            tbl_bad_stock INNER JOIN tbl_item ON tbl_bad_stock.item_id = tbl_item.item_id " & _
                           " WHERE        (tbl_item.category_id = " & cmbCategory.SelectedValue & ") AND (tbl_bad_stock.entry_date >=  '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_bad_stock.entry_date <=  '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                '--------------------------------
            End If
        Else
            '--------------------------------
            LoadReport(" SELECT        tbl_bad_stock.stock_id, tbl_item.item_name, tbl_bad_stock.quantity, tbl_bad_stock.uom, tbl_bad_stock.entry_date, tbl_bad_stock.cost, tbl_bad_stock.reason, tbl_item.category_id " & _
                       " FROM            tbl_bad_stock INNER JOIN tbl_item ON tbl_bad_stock.item_id = tbl_item.item_id " & _
                       " WHERE    (tbl_bad_stock.entry_date >=  '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_bad_stock.entry_date <=  '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
            '--------------------------------
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub LoadReport(ByVal sqlQry As String)
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\BadStock.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = sqlQry
            my_Command.Connection = My_Connection
            my_Command.CommandType = CommandType.Text
            my_DataAdapter.SelectCommand = my_Command

            my_DataAdapter.Fill(my_DataSource, "Bad_Stock")
            rpt_Document.SetDataSource(my_DataSource)

            ParamCollection.Add(crpBusinessName)
            rpt_Document.DataDefinition.ParameterFields("BusinessName").ApplyCurrentValues(ParamCollection)
            ParamCollection.Add(crpBusinessAddress)
            rpt_Document.DataDefinition.ParameterFields("BusinessAddress").ApplyCurrentValues(ParamCollection)
            ParamCollection.Add(crpTelephone)
            rpt_Document.DataDefinition.ParameterFields("Telephone").ApplyCurrentValues(ParamCollection)
            ParamCollection.Add(crpFax)
            rpt_Document.DataDefinition.ParameterFields("Fax").ApplyCurrentValues(ParamCollection)
            ParamCollection.Add(crpEmail)
            rpt_Document.DataDefinition.ParameterFields("Email").ApplyCurrentValues(ParamCollection)

            crpSharedDate.Value = "From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")

            ParamCollection.Add(crpSharedDate)
            rpt_Document.DataDefinition.ParameterFields("SharedDate").ApplyCurrentValues(ParamCollection)

            .CrystalReportViewer1.ReportSource = rpt_Document
            .Show()
        End With
    End Sub
End Class