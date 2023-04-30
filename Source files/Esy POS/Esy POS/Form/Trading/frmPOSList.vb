Public Class frmPOSList
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
    Private Sub LoadInvoice()
        FillDataGrid(" SELECT        tbl_sale.SALES_ID, tbl_sale.Sales_Date, tbl_customer.customer_name FROM            tbl_sale INNER JOIN  tbl_customer ON tbl_sale.customer_id = tbl_customer.customer_id " & _
                     " WHERE        (tbl_sale.POS = 'Y') AND (tbl_sale.Sales_Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_sale.Sales_Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ", dgvInvoice)
    End Sub

    Private Sub frmPOSList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadInvoice()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        LoadInvoice()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        LoadInvoice()
    End Sub

    Private Sub dgvInvoice_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInvoice.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure you want to edit this invocie no# " & dgvInvoice.CurrentRow.Cells(1).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                With frmPOS
                    .txtInvoiceID.Text = dgvInvoice.CurrentRow.Cells(1).Value
                    .Show()
                End With
            End If
        End If
    End Sub
End Class