Imports System.IO
Public Class frmReOrder
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

    Private Sub frmReOrder_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbAccording.SelectedIndex = 2
        txtCriteria.Select()
        loadStock()
    End Sub
    Private Sub loadStock()
        sqlSTR = " SELECT  item_id, category_name, item_name, barcode, quantity, uom " & _
                     " FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_item.quantity <= tbl_item.re_order_level) AND (tbl_item.status = N'Active') "
        FillDataGrid(sqlSTR, dgvStock)
        ExecuteSQLQuery(sqlSTR)
        If sqlDT.Rows.Count > 0 Then
            lblCount.Text = "Total " & sqlDT.Rows.Count & " item found."
        Else
            lblCount.Text = "Total 0 item found."
        End If

    End Sub

    Private Sub txtCriteria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCriteria.TextChanged
        If txtCriteria.Text = "" Then
            loadStock()
        Else
            If cmbAccording.Text = "Supplier Name" Then
                sqlSTR = " SELECT        tbl_item.item_id, tbl_category.category_name, tbl_item.item_name, tbl_item.barcode, tbl_item.quantity, tbl_item.uom " & _
                              " FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id INNER JOIN     tbl_supplier ON tbl_item.supplier_id = tbl_supplier.supplier_id " & _
                              " WHERE        (tbl_item.quantity <= tbl_item.re_order_level) AND (tbl_item.status = N'Active') AND (tbl_supplier.supplier_name LIKE N'" & str_repl(txtCriteria.Text) & "%') "
                FillDataGrid(sqlSTR, dgvStock)
                ExecuteSQLQuery(sqlSTR)
                If sqlDT.Rows.Count > 0 Then
                    lblCount.Text = "Total " & sqlDT.Rows.Count & " item found."
                Else
                    lblCount.Text = "Total 0 item found."
                End If
            ElseIf cmbAccording.Text = "Item ID" Then
                If IsNumeric(txtCriteria.Text) Then
                    sqlSTR = " SELECT  item_id, category_name, item_name, barcode, quantity, uom " & _
                             " FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_item.quantity <= tbl_item.re_order_level) AND (tbl_item.status = N'Active') " & _
                             " AND        (tbl_item.item_id = " & str_repl(txtCriteria.Text) & ") "
                    FillDataGrid(sqlSTR, dgvStock)
                    ExecuteSQLQuery(sqlSTR)
                    If sqlDT.Rows.Count > 0 Then
                        lblCount.Text = "Total " & sqlDT.Rows.Count & " item found."
                    Else
                        lblCount.Text = "Total 0 item found."
                    End If
                Else
                    loadStock()
                End If
            ElseIf cmbAccording.Text = "Item Name" Then
                sqlSTR = " SELECT  item_id, category_name, item_name, barcode, quantity, uom " & _
                         " FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_item.quantity <= tbl_item.re_order_level) AND (tbl_item.status = N'Active') " & _
                         " AND (tbl_item.item_name LIKE N'" & str_repl(txtCriteria.Text) & "%') "
                FillDataGrid(sqlSTR, dgvStock)
                ExecuteSQLQuery(sqlSTR)
                If sqlDT.Rows.Count > 0 Then
                    lblCount.Text = "Total " & sqlDT.Rows.Count & " item found."
                Else
                    lblCount.Text = "Total 0 item found."
                End If
            ElseIf cmbAccording.Text = "Barcode" Then
                sqlSTR = " SELECT  item_id, category_name, item_name, barcode, quantity, uom " & _
                         " FROM            tbl_item INNER JOIN  tbl_category ON tbl_item.category_id = tbl_category.category_id  WHERE        (tbl_item.quantity <= tbl_item.re_order_level) AND (tbl_item.status = N'Active') " & _
                         " AND (tbl_item.barcode LIKE N'" & str_repl(txtCriteria.Text) & "%') "
                FillDataGrid(sqlSTR, dgvStock)
                ExecuteSQLQuery(sqlSTR)
                If sqlDT.Rows.Count > 0 Then
                    lblCount.Text = "Total " & sqlDT.Rows.Count & " item found."
                Else
                    lblCount.Text = "Total 0 item found."
                End If
            End If
        End If
    End Sub

    Private Sub dgvStock_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvStock.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure you want to edit this product?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                ExecuteSQLQuery(" SELECT        tbl_item.item_id, tbl_category.category_name, tbl_item.item_name, tbl_item.barcode, tbl_item.vat, tbl_item.status, tbl_item.supplier_id, tbl_supplier.supplier_name, tbl_item.quantity, tbl_item.uom, tbl_item.cost,  " & _
                                " tbl_item.sell_price, tbl_item.re_order_level, tbl_item.category_id, tbl_item.photo  FROM            tbl_item INNER JOIN " & _
                                "  tbl_category ON tbl_item.category_id = tbl_category.category_id INNER JOIN    tbl_supplier ON tbl_item.supplier_id = tbl_supplier.supplier_id  WHERE        (tbl_item.item_id = " & dgvStock.CurrentRow.Cells(1).Value & ") ")
                If sqlDT.Rows.Count > 0 Then
                    With frmItemInformation
                        .txtItemID.Text = sqlDT.Rows(0)("item_id")
                        .txtItemName.Text = sqlDT.Rows(0)("item_name")
                        .txtBarcode.Text = sqlDT.Rows(0)("barcode")
                        .txtQuantity.Text = sqlDT.Rows(0)("quantity")
                        .txtUOM.Text = sqlDT.Rows(0)("uom")
                        .txtCost.Text = sqlDT.Rows(0)("cost")
                        .txtPrice.Text = sqlDT.Rows(0)("sell_price")
                        .txtVAT.Text = sqlDT.Rows(0)("vat")
                        .txtROL.Text = sqlDT.Rows(0)("re_order_level")
                        .cmbStatus.Text = sqlDT.Rows(0)("status")
                        .cmbCategory.SelectedValue = sqlDT.Rows(0)("category_id")
                        .cmbSupplier.SelectedValue = sqlDT.Rows(0)("supplier_id")
                        Dim bytBLOBData() As Byte = sqlDT.Rows(0)("photo")
                        Dim stmBLOBData As New MemoryStream(bytBLOBData)
                        .PictureBox1.BackgroundImage = Image.FromStream(stmBLOBData)
                        .btnSave.Text = "UPDATE"
                        .MdiParent = frmMDIParent
                        .Show()
                    End With
                End If

            End If
        End If
    End Sub
End Class