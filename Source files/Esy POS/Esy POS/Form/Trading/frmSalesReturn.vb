Public Class frmSalesReturn
    Dim x, y As Integer
    Dim newpoint As New Point
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

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Not IsNumeric(txtInvoiceSearch.Text) Then
            MsgBox("Please enter a valid invoice id.", MsgBoxStyle.Information, "Information")
        Else
            sqlSTR = " SELECT        tbl_sale_details.auto_id, tbl_sale_details.SALES_ID, tbl_item.item_name, tbl_sale_details.quantity, tbl_item.uom, tbl_sale_details.cost, tbl_sale_details.price, tbl_sale_details.sub_total " & _
                      " FROM            tbl_sale_details INNER JOIN  tbl_item ON tbl_sale_details.item_id = tbl_item.item_id  WHERE        (tbl_sale_details.SALES_ID = " & txtInvoiceSearch.Text & ") "
            ExecuteSQLQuery(sqlSTR)
            If sqlDT.Rows.Count > 0 Then
                FillDataGrid(" SELECT        tbl_sale_details.auto_id, tbl_sale_details.SALES_ID, tbl_item.item_name, tbl_sale_details.quantity, tbl_item.uom, tbl_sale_details.cost, tbl_sale_details.price, tbl_sale_details.sub_total " & _
                             " FROM            tbl_sale_details INNER JOIN  tbl_item ON tbl_sale_details.item_id = tbl_item.item_id  WHERE        (tbl_sale_details.SALES_ID = " & txtInvoiceSearch.Text & ") ", dgvSale)
            Else
                MsgBox("Your criteria finished searching the database. Invoice not found.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub

    Private Sub frmSalesReturn_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSaleReturnData()
        gbReturnQuantity.Visible = False
        txtInvoiceSearch.Select()
    End Sub

    Private Sub dgvSale_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvSale.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure to return from INV. No# : " & dgvSale.CurrentRow.Cells(2).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                COL_ID = dgvSale.CurrentRow.Cells(1).Value
                txtQuantity.Text = dgvSale.CurrentRow.Cells(4).Value
                gbReturnQuantity.Visible = True
                txtQuantity.Select()
            End If
        End If
    End Sub

    Private Sub btnReturnQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReturnQuantity.Click
        If Val(txtQuantity.Text) <= 0 Then
            MsgBox("Please enter positive value.", MsgBoxStyle.Critical, "Error.")
        Else
            ExecuteSQLQuery("SELECT    *  FROM            tbl_sale_details   WHERE        (auto_id = '" & COL_ID & "') AND (quantity >= " & Val(txtQuantity.Text) & ")")
            Dim ITEM_COST As Double = sqlDT.Rows(0)("cost")
            Dim ITEM_PRICE As Double = sqlDT.Rows(0)("price")
            Dim ITEM_ID As Double = sqlDT.Rows(0)("item_id")
            Dim SALES_ID As Double = sqlDT.Rows(0)("SALES_ID")
            Dim SALES_QTY As Double = sqlDT.Rows(0)("quantity")
            'Customer id from sales table
            ExecuteSQLQuery(" SELECT  *   FROM   tbl_sale  WHERE   (SALES_ID = " & SALES_ID & ") ")
            Dim CUST_ID As Double = sqlDT.Rows(0)("customer_id")
            If sqlDT.Rows.Count > 0 Then
                '----------------------------
                ExecuteSQLQuery("SELECT    *  FROM            tbl_sale_details   WHERE        (auto_id = '" & COL_ID & "') AND (quantity = " & Val(txtQuantity.Text) & ")")
                If sqlDT.Rows.Count > 0 Then
                    ExecuteSQLQuery(" UPDATE  tbl_sale_details  SET quantity=quantity - " & str_repl(txtQuantity.Text) & ", cost = cost - " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", total_cost = total_cost - " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", price = price - " & (ITEM_PRICE / SALES_QTY) * Val(txtQuantity.Text) & ", total_price = total_price - " & (ITEM_PRICE / SALES_QTY) * Val(txtQuantity.Text) & ", sub_total = sub_total - " & (ITEM_PRICE / SALES_QTY) * Val(txtQuantity.Text) & ",  retrn='Y'  WHERE        (auto_id = '" & COL_ID & "')")
                    ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity + " & Val(txtQuantity.Text) & "  WHERE        (item_id = " & ITEM_ID & ")")
                    ExecuteSQLQuery(" INSERT INTO tbl_sale_return (return_date, item_id, quantity,  cost, cost_total, User_ID, customer_id, SALES_ID) VALUES  " & _
                                    " ('" & Format(Now, "MM/dd/yyyy") & "', '" & ITEM_ID & "', " & Val(txtQuantity.Text) & ", " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", " & xUser_ID & ", " & CUST_ID & ", " & SALES_ID & " ) ")
                Else
                    ExecuteSQLQuery(" UPDATE  tbl_sale_details  SET quantity=quantity - " & str_repl(txtQuantity.Text) & ", cost = cost - " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", total_cost = total_cost - " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", price = price - " & (ITEM_PRICE / SALES_QTY) * Val(txtQuantity.Text) & ", total_price = total_price - " & (ITEM_PRICE / SALES_QTY) * Val(txtQuantity.Text) & ", sub_total = sub_total - " & (ITEM_PRICE / SALES_QTY) * Val(txtQuantity.Text) & ",  retrn='Y'  WHERE        (auto_id = '" & COL_ID & "')")
                    ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity + " & Val(txtQuantity.Text) & "  WHERE        (item_id = " & ITEM_ID & ")")
                    ExecuteSQLQuery(" INSERT INTO tbl_sale_return (return_date, item_id, quantity,  cost, cost_total, User_ID, customer_id, SALES_ID) VALUES  " & _
                                    " ('" & Format(Now, "MM/dd/yyyy") & "', '" & ITEM_ID & "', " & Val(txtQuantity.Text) & ", " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", " & (ITEM_COST / SALES_QTY) * Val(txtQuantity.Text) & ", " & xUser_ID & ", " & CUST_ID & ", " & SALES_ID & " ) ")
                End If
                Audit_Trail(xUser_ID, TimeOfDay, "Sales Return. Inv # " & SALES_ID)
                '----------------------------
            Else
                MsgBox("Illegal Operation.", MsgBoxStyle.Critical, "Critical")
            End If
            btnSearch.PerformClick()
            LoadSaleReturnData()
            txtQuantity.Text = ""
            gbReturnQuantity.Visible = False
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        gbReturnQuantity.Visible = False
        txtInvoiceSearch.Select()
    End Sub

    Private Sub LoadSaleReturnData()
        FillDataGrid(" SELECT        tbl_sale_return.RETURN_ID, tbl_sale_return.SALES_ID, tbl_item.item_name, tbl_sale_return.quantity, tbl_item.uom, tbl_sale_return.cost, tbl_sale_return.cost_total " & _
                     " FROM            tbl_sale_return INNER JOIN  tbl_item ON tbl_sale_return.item_id = tbl_item.item_id  WHERE        (tbl_sale_return.return_date = '" & Format(Now, "MM/dd/yyyy") & "') ", dgvSaleReturn)
    End Sub
End Class