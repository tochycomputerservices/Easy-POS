Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Data.SqlServerCe
Module modSalesRecipt
    Public Sub LoadReport(ByVal INV_NO As Double)
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\Invoice.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = " SELECT        tbl_sale.SALES_ID, tbl_sale.Sales_Date, tbl_sale.Sales_Time, tbl_users.user_name, tbl_sale.customer_id, tbl_customer.customer_name, tbl_sale.grand_disc, tbl_sale.collection_full, tbl_sale.term_of_payment,  " & _
                                     "  tbl_sale.consin1, tbl_sale.consin2, tbl_sale.narration, tbl_sale_details.item_id, tbl_item.item_name, tbl_sale_details.quantity, tbl_sale_details.cost, tbl_sale_details.price, tbl_sale_details.vat,  " & _
                                     " tbl_sale_details.disc, tbl_sale_details.total_cost, tbl_sale_details.total_price, tbl_sale_details.sub_total, tbl_customer.address, tbl_customer.phone , tbl_sale.Payment, tbl_sale.Change " & _
                                     " FROM            tbl_customer INNER JOIN  tbl_sale ON tbl_customer.customer_id = tbl_sale.customer_id INNER JOIN tbl_users ON tbl_sale.User_ID = tbl_users.User_ID LEFT OUTER JOIN  tbl_item INNER JOIN " & _
                                     " tbl_sale_details ON tbl_item.item_id = tbl_sale_details.item_id ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID  WHERE        (tbl_sale.SALES_ID = " & INV_NO & ") "
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
            .CrystalReportViewer1.ReportSource = rpt_Document
            .Show()
        End With
    End Sub
    Public Sub LoadPOSRecipt(ByVal INV_NO As Double)
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\POSRecipt.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = " SELECT        tbl_sale.SALES_ID, tbl_sale.Sales_Date, tbl_sale.Sales_Time, tbl_users.user_name, tbl_sale.customer_id, tbl_customer.customer_name, tbl_sale.grand_disc, tbl_sale.collection_full, tbl_sale.term_of_payment,  " & _
                                     "  tbl_sale.consin1, tbl_sale.consin2, tbl_sale.narration, tbl_sale_details.item_id, tbl_item.item_name, tbl_sale_details.quantity, tbl_sale_details.cost, tbl_sale_details.price, tbl_sale_details.vat,  " & _
                                     " tbl_sale_details.disc, tbl_sale_details.total_cost, tbl_sale_details.total_price, tbl_sale_details.sub_total, tbl_customer.address, tbl_customer.phone , tbl_sale.Payment, tbl_sale.Change " & _
                                     " FROM            tbl_customer INNER JOIN  tbl_sale ON tbl_customer.customer_id = tbl_sale.customer_id INNER JOIN tbl_users ON tbl_sale.User_ID = tbl_users.User_ID LEFT OUTER JOIN  tbl_item INNER JOIN " & _
                                     " tbl_sale_details ON tbl_item.item_id = tbl_sale_details.item_id ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID  WHERE        (tbl_sale.SALES_ID = " & INV_NO & ") "
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
            ParamCollection.Add(crpTINN)
            rpt_Document.DataDefinition.ParameterFields("TINN").ApplyCurrentValues(ParamCollection)
            ParamCollection.Add(crpSlogan)
            rpt_Document.DataDefinition.ParameterFields("Slogan").ApplyCurrentValues(ParamCollection)
            'Reprot directly sent to default printer
            rpt_Document.PrintToPrinter(1, False, 1, 1)
        End With
    End Sub
End Module
