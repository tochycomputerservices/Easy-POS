Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlServerCe
Public Class frmDateWiseSalesReturnReport
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

    Private Sub rbCategoryWiseReturn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCategoryWiseReturn.CheckedChanged
        If rbCategoryWiseReturn.Checked Then
            cmbCategory.Enabled = True
        Else
            cmbCategory.Enabled = False
        End If
    End Sub

    Private Sub frmDateWiseSalesReturnReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FillDataComboBox("SELECT  *  FROM  tbl_category", "category_id", "category_name", cmbCategory)
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        LoadCompanyDetails()
        If rbCategoryWiseReturn.Checked Then
            If cmbCategory.SelectedValue Is Nothing Or cmbCategory.SelectedIndex = -1 Then
                MsgBox("Required: Category", MsgBoxStyle.Information, "Information")
            Else
                '--------------------------------
                crpSharedDate.Value = "Category # " & cmbCategory.Text & ", From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")
                LoadReport(" SELECT        tbl_sale_return.RETURN_ID, tbl_sale_return.return_date, tbl_item.item_name, tbl_sale_return.quantity, tbl_sale_return.cost_total, tbl_sale_return.SALES_ID, tbl_item.category_id, tbl_sale_return.cost " & _
                           " FROM            tbl_sale_return INNER JOIN  tbl_item ON tbl_sale_return.item_id = tbl_item.item_id " & _
                           " WHERE   (tbl_item.category_id = " & cmbCategory.SelectedValue & ")   AND   (tbl_sale_return.return_date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_sale_return.return_date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
                '--------------------------------
            End If
        Else
            '--------------------------------
            crpSharedDate.Value = "From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")
            LoadReport(" SELECT        tbl_sale_return.RETURN_ID, tbl_sale_return.return_date, tbl_item.item_name, tbl_sale_return.quantity, tbl_sale_return.cost_total, tbl_sale_return.SALES_ID, tbl_item.category_id, tbl_sale_return.cost " & _
                       " FROM            tbl_sale_return INNER JOIN  tbl_item ON tbl_sale_return.item_id = tbl_item.item_id " & _
                       " WHERE        (tbl_sale_return.return_date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_sale_return.return_date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
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
            rpt_Document.Load(Application.StartupPath & "\Reports\SalesReturn.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = sqlQry
            my_Command.Connection = My_Connection
            my_Command.CommandType = CommandType.Text
            my_DataAdapter.SelectCommand = my_Command
            my_DataAdapter.Fill(my_DataSource, "SalesReturn")
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


            ParamCollection.Add(crpSharedDate)
            rpt_Document.DataDefinition.ParameterFields("SharedDate").ApplyCurrentValues(ParamCollection)

            .CrystalReportViewer1.ReportSource = rpt_Document
            .Show()
        End With
    End Sub
End Class