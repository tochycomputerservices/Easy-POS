Public Class frmFirstInvoiceList
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


    Private Sub LoadAllInvoice()
        FillDataGrid(" SELECT        tbl_sale.SALES_ID, tbl_sale.Sales_Date, tbl_users.user_name, tbl_customer.customer_name, tbl_sale.term_of_payment  " & _
                     " FROM            tbl_sale INNER JOIN tbl_customer ON tbl_sale.customer_id = tbl_customer.customer_id INNER JOIN tbl_users ON tbl_sale.User_ID = tbl_users.User_ID  " & _
                     " WHERE        (tbl_sale.Sales_Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (tbl_sale.Sales_Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "')  ", dgvInvoice)
    End Sub

    Private Sub frmFirstInvoiceList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAllInvoice()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        LoadAllInvoice()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        LoadAllInvoice()
    End Sub

    Private Sub dgvInvoice_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure you want to edit this invocie no# " & dgvInvoice.CurrentRow.Cells(1).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                ExecuteSQLQuery(" SELECT        tbl_sale.SALES_ID, tbl_customer.customer_id, tbl_customer.customer_name, tbl_sale.consin1, tbl_sale.consin2, tbl_sale.narration " & _
                                " FROM            tbl_sale INNER JOIN  tbl_customer ON tbl_sale.customer_id = tbl_customer.customer_id   WHERE        (tbl_sale.SALES_ID = " & dgvInvoice.CurrentRow.Cells(2).Value & ") ")
                With frmFirstSale
                    .txtInvoiceID.Text = sqlDT.Rows(0)("SALES_ID")
                    .txtBuyerConsin1.Text = sqlDT.Rows(0)("consin1")
                    .txtBuyerConsin2.Text = sqlDT.Rows(0)("consin2")
                    .txtNarration.Text = sqlDT.Rows(0)("narration")
                    .txtCustomerID.Text = sqlDT.Rows(0)("customer_id")
                    Dim customer_name As String = sqlDT.Rows(0)("customer_name")
                    .MdiParent = frmMDIParent
                    .btnNewTrns.Text = "UPDATE"
                    .Show()
                    .txtCustomer.Text = customer_name
                    .lstCustomer.Visible = False
                End With
                Me.Close()
            End If
        ElseIf e.ColumnIndex = 1 Then
            LoadCompanyDetails()
            LoadReport(dgvInvoice.CurrentRow.Cells(2).Value)
        End If
    End Sub
End Class