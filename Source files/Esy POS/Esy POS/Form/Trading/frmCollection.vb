Public Class frmCollection
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

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub LoadSalesData()
        FillDataGrid(" SELECT        tbl_sale.SALES_ID, tbl_sale.Sales_Date, tbl_customer.customer_name, SUM(tbl_sale_details.total_cost) AS total_cost, SUM(tbl_sale_details.total_price) AS total_price, SUM(tbl_sale_details.vat) AS vat,  " & _
                     " SUM(tbl_sale_details.disc) AS disc, SUM(tbl_sale_details.sub_total) - tbl_sale.grand_disc AS sub_total FROM            tbl_sale INNER JOIN " & _
                     " tbl_sale_details ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID INNER JOIN  tbl_customer ON tbl_sale.customer_id = tbl_customer.customer_id " & _
                     " WHERE        (tbl_sale.Sales_Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (NOT (tbl_sale.term_of_payment = 'DUE')) AND (tbl_sale.Sales_Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') " & _
                     " GROUP BY tbl_sale.SALES_ID, tbl_customer.customer_name, tbl_sale.Sales_Date, tbl_sale.grand_disc ", dgvCollected)
        FillDataGrid(" SELECT        tbl_sale.SALES_ID, tbl_sale.Sales_Date, tbl_customer.customer_name, SUM(tbl_sale_details.total_cost) AS total_cost, SUM(tbl_sale_details.total_price) AS total_price, SUM(tbl_sale_details.vat) AS vat,  " & _
                     " SUM(tbl_sale_details.disc) AS disc, SUM(tbl_sale_details.sub_total) - tbl_sale.grand_disc AS sub_total FROM            tbl_sale INNER JOIN " & _
                     " tbl_sale_details ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID INNER JOIN  tbl_customer ON tbl_sale.customer_id = tbl_customer.customer_id " & _
                     " WHERE        (tbl_sale.Sales_Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (tbl_sale.term_of_payment = 'DUE') AND (tbl_sale.Sales_Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') " & _
                     " GROUP BY tbl_sale.SALES_ID, tbl_customer.customer_name, tbl_sale.Sales_Date, tbl_sale.grand_disc ", dgvDue)
    End Sub

    Private Sub frmCollection_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSalesData()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        LoadSalesData()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        LoadSalesData()
    End Sub

    Private Sub dgvDue_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDue.CellContentClick
        If e.ColumnIndex = 0 Then
            LoadCompanyDetails()
            LoadReport(dgvDue.CurrentRow.Cells(2).Value)
        ElseIf e.ColumnIndex = 1 Then
            frmPayment.txtInvoiceID.Text = dgvDue.CurrentRow.Cells(2).Value
            frmPayment.ShowDialog()
        End If
    End Sub

    Private Sub dgvCollected_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCollected.CellContentClick
        If e.ColumnIndex = 0 Then
            LoadCompanyDetails()
            LoadReport(dgvCollected.CurrentRow.Cells(1).Value)
        End If
    End Sub
End Class