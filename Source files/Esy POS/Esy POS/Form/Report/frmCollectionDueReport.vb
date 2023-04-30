Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlServerCe
Public Class frmCollectionDueReport
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

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        LoadCompanyDetails()
        If cmbType.Text = "" Then
            MsgBox("Required: TERM OF PAYMENT", MsgBoxStyle.Information, "Information")
        Else

            crpSharedDate.Value = cmbType.Text & " STATEMENT , From " & Format(dtpFrom.Value, "dd/MM/yyyy") & " To " & Format(dtpTo.Value, "dd/MM/yyyy")
            LoadReport(" SELECT        tbl_sale.SALES_ID, tbl_sale.Sales_Date, tbl_sale.Sales_Time, tbl_users.user_name, tbl_sale.customer_id, tbl_customer.customer_name, tbl_sale.grand_disc, tbl_sale.collection_full, tbl_sale.term_of_payment,  " & _
                        "  tbl_sale.consin1, tbl_sale.consin2, tbl_sale.narration, tbl_sale_details.item_id, tbl_item.item_name, tbl_sale_details.quantity, tbl_sale_details.cost, tbl_sale_details.price, tbl_sale_details.vat,  " & _
                        " tbl_sale_details.disc, tbl_sale_details.total_cost, tbl_sale_details.total_price, tbl_sale_details.sub_total  FROM            tbl_customer INNER JOIN " & _
                        " tbl_sale ON tbl_customer.customer_id = tbl_sale.customer_id INNER JOIN tbl_users ON tbl_sale.User_ID = tbl_users.User_ID LEFT OUTER JOIN tbl_item INNER JOIN " & _
                        "  tbl_sale_details ON tbl_item.item_id = tbl_sale_details.item_id ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID " & _
                        " WHERE       (tbl_sale.term_of_payment = '" + cmbType.Text + "') AND    (tbl_sale.Sales_Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_sale.Sales_Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")

        End If
    End Sub
    Private Sub LoadReport(ByVal sqlQry As String)
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\SalesList.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = sqlQry
            my_Command.Connection = My_Connection
            my_Command.CommandType = CommandType.Text
            my_DataAdapter.SelectCommand = my_Command
            my_DataAdapter.Fill(my_DataSource, "Sale")
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