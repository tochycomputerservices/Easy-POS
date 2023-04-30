Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Data.SqlServerCe
Public Class frmItemListReport
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
    Private Sub LoadRb()
        FillDataComboBox("SELECT  *  FROM  tbl_category", "category_id", "category_name", cmbCategory)

        'Load Category ID
        ExecuteSQLQuery("SELECT        item_id  FROM            tbl_item   ORDER BY item_id")
        If sqlDT.Rows.Count > 0 Then
            txtItemIdFrom.Text = sqlDT.Rows(0)("item_id")
        Else
            txtItemIdFrom.Text = "0"
        End If

        ExecuteSQLQuery("SELECT        item_id  FROM            tbl_item   ORDER BY item_id DESC")
        If sqlDT.Rows.Count > 0 Then
            txtItemIdTo.Text = sqlDT.Rows(0)("item_id")
        Else
            txtItemIdTo.Text = "0"
        End If

        If rbCategoryWise.Checked Then
            cmbCategory.Enabled = True
            gbSupplier.Enabled = False
        ElseIf rbAllItem.Checked Then
            cmbCategory.Enabled = False
            gbSupplier.Enabled = True
        ElseIf rbAllActive.Checked Then
            cmbCategory.Enabled = False
            gbSupplier.Enabled = False
        ElseIf rbAllDeactive.Checked Then
            cmbCategory.Enabled = False
            gbSupplier.Enabled = False
        End If
    End Sub
    Private Sub frmItemListReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadRb()
    End Sub
    Private Sub rbCategoryWise_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCategoryWise.CheckedChanged
        LoadRb()
    End Sub

    Private Sub rbAllItem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllItem.CheckedChanged
        LoadRb()
    End Sub

    Private Sub rbAllActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllActive.CheckedChanged
        LoadRb()
    End Sub

    Private Sub rbAllDeactive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAllDeactive.CheckedChanged
        LoadRb()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        LoadCompanyDetails()
        If rbCategoryWise.Checked Then
            If cmbCategory.SelectedValue Is Nothing Or cmbCategory.SelectedIndex = -1 Then
                MsgBox("Require: Category", MsgBoxStyle.Information, "Information")
            Else
                LoadReport(" SELECT        tbl_category.category_id, tbl_category.category_name, tbl_item.item_id, tbl_item.supplier_id, tbl_item.item_name, tbl_item.barcode, tbl_item.quantity, tbl_item.uom, tbl_item.cost, tbl_item.sell_price, tbl_item.vat,  " & _
                           "  tbl_item.re_order_level, tbl_item.status, tbl_item.photo  FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_category.category_id = " & cmbCategory.SelectedValue & ") ")
            End If
        ElseIf rbAllItem.Checked Then
            If Val(txtItemIdFrom.Text) <= 0 Then
                MsgBox("Required: Item ID NO.", MsgBoxStyle.Information, "Information")
            ElseIf Val(txtItemIdTo.Text) <= 0 Then
                MsgBox("Required: TO ID NO.", MsgBoxStyle.Information, "Information")
            Else
                LoadReport(" SELECT        tbl_category.category_id, tbl_category.category_name, tbl_item.item_id, tbl_item.supplier_id, tbl_item.item_name, tbl_item.barcode, tbl_item.quantity, tbl_item.uom, tbl_item.cost, tbl_item.sell_price, tbl_item.vat,  " & _
                            "  tbl_item.re_order_level, tbl_item.status, tbl_item.photo  FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_item.item_id >= " & str_repl(txtItemIdFrom.Text) & " AND tbl_item.item_id <=  " & str_repl(txtItemIdTo.Text) & ")")
            End If
        ElseIf rbAllActive.Checked Then
            LoadReport(" SELECT        tbl_category.category_id, tbl_category.category_name, tbl_item.item_id, tbl_item.supplier_id, tbl_item.item_name, tbl_item.barcode, tbl_item.quantity, tbl_item.uom, tbl_item.cost, tbl_item.sell_price, tbl_item.vat,  " & _
                     "  tbl_item.re_order_level, tbl_item.status, tbl_item.photo  FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_item.status = 'Active')")
        ElseIf rbAllDeactive.Checked Then
            LoadReport(" SELECT        tbl_category.category_id, tbl_category.category_name, tbl_item.item_id, tbl_item.supplier_id, tbl_item.item_name, tbl_item.barcode, tbl_item.quantity, tbl_item.uom, tbl_item.cost, tbl_item.sell_price, tbl_item.vat,  " & _
                        "  tbl_item.re_order_level, tbl_item.status, tbl_item.photo  FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_item.status = 'Deactive')")
            End If
    End Sub

    Private Sub LoadReport(ByVal sqlQuy As String)
        With frmCrvDefault
            Dim rpt_Document As New ReportDocument
            Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
            rpt_Document.Load(Application.StartupPath & "\Reports\ItemList.rpt")
            Dim My_Connection As SqlCeConnection
            Dim my_Command As New SqlCeCommand
            Dim my_DataAdapter As New SqlCeDataAdapter
            Dim my_DataSource As New EsyPosDataSet
            My_Connection = New SqlCeConnection(CnString)
            my_Command.CommandText = sqlQuy
            my_Command.Connection = My_Connection
            my_Command.CommandType = CommandType.Text
            my_DataAdapter.SelectCommand = my_Command
            my_DataAdapter.Fill(my_DataSource, "tbl_item_list")
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
End Class