Public Class frmFirstSale
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

    Private Sub frmFirstSale_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstCustomer.Visible = False
        lstItem.Visible = False
        FillListBox("SELECT        customer_id, customer_name  FROM            tbl_customer  WHERE        (status = N'Active')", lstCustomer)
        gbDetails.Enabled = False
    End Sub

    Private Sub txtCustomer_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCustomer.Click
        lstCustomer.Visible = True
        FillListBox("SELECT        customer_id, customer_name  FROM            tbl_customer  WHERE        (status = N'Active')", lstCustomer)
    End Sub

    Private Sub txtCustomer_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyDown
        Dim keydata As System.Windows.Forms.Keys = e.KeyData
        If keydata = Keys.Down Then
            If lstCustomer.Items.Count > 0 Then
                lstCustomer.Visible = True
                lstCustomer.SelectedIndex = 0
                lstCustomer.Select()
            End If
        End If
    End Sub

    Private Sub txtCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCustomer.TextChanged
        If txtCustomer.Text = "" Then
            txtCustomerID.Text = ""
            lstCustomer.Visible = True
            FillListBox("SELECT        customer_id, customer_name  FROM            tbl_customer  WHERE        (status = N'Active')", lstCustomer)
        Else
            lstCustomer.Visible = True
            FillListBox("SELECT        customer_id, customer_name  FROM            tbl_customer  WHERE        (status = N'Active') AND  (customer_name LIKE N'%" & str_repl(txtCustomer.Text) & "%')", lstCustomer)
        End If
    End Sub

    Private Sub lstCustomer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstCustomer.DoubleClick
        On Error Resume Next
        If lstCustomer.Items.Count > 0 Then
            txtCustomerID.Text = Split(lstCustomer.SelectedItem, " # ")(0)
            txtCustomer.Text = Split(lstCustomer.SelectedItem, " # ")(1)
            lstCustomer.Visible = False
            txtBuyerConsin1.Select()
        End If
    End Sub

    Private Sub lstCustomer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstCustomer.KeyPress
        On Error Resume Next
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If lstCustomer.Items.Count > 0 Then
                txtCustomerID.Text = Split(lstCustomer.SelectedItem, " # ")(0)
                txtCustomer.Text = Split(lstCustomer.SelectedItem, " # ")(1)
                lstCustomer.Visible = False
                txtBuyerConsin1.Select()
            End If
        End If
    End Sub

    Private Sub gbMain_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles gbMain.Click
        lstCustomer.Visible = False
    End Sub
    Private Sub loadSalesItem()
        FillDataGrid(" SELECT        tbl_sale_details.auto_id, tbl_item.item_name, tbl_sale_details.quantity, tbl_sale_details.price, tbl_sale_details.sub_total " & _
                     " FROM            tbl_sale_details INNER JOIN  tbl_item ON tbl_sale_details.item_id = tbl_item.item_id  WHERE        (tbl_sale_details.SALES_ID = " & txtInvoiceID.Text & ") ", dtgItem)
    End Sub
    Private Sub txtItemName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemName.Click
        lstItem.Visible = True
        FillListBox(" SELECT item_id,item_name FROM tbl_item  WHERE status='Active'", lstItem)
    End Sub
    Private Sub txtItemName_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtItemName.KeyDown
        Dim keydata As System.Windows.Forms.Keys = e.KeyData
        If keydata = Keys.Down Then
            If lstItem.Items.Count > 0 Then
                lstItem.Visible = True
                lstItem.SelectedIndex = 0
                lstItem.Select()
            End If
        End If
    End Sub

    Private Sub txtItemName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemName.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            lstItem.Visible = False
        End If
    End Sub
    Private Sub txtItemName_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtItemName.TextChanged
        If txtItemName.Text = "" Then
            txtItemID.Text = ""
            txtUOM.Text = ""
            txtStockUnit.Text = ""
            lstItem.Visible = True
            FillListBox(" SELECT item_id,item_name FROM tbl_item  WHERE status='Active'", lstItem)
        Else
            lstItem.Visible = True
            FillListBox("SELECT        item_id,item_name  FROM            tbl_item WHERE  (item_name LIKE N'%" & str_repl(txtItemName.Text) & "%') AND status='Active'", lstItem)
        End If
    End Sub

    Private Sub lstItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstItem.DoubleClick
        On Error Resume Next
        If lstItem.Items.Count > 0 Then
            txtItemID.Text = Split(lstItem.SelectedItem, " # ")(0)
            txtItemName.Text = Split(lstItem.SelectedItem, " # ")(1)
            ExecuteSQLQuery(" SELECT    *     FROM            tbl_item  WHERE        (item_id = " & txtItemID.Text & ") ")
            txtStockUnit.Text = sqlDT.Rows(0)("quantity")
            txtUOM.Text = sqlDT.Rows(0)("uom")
            lstItem.Visible = False
            txtQuantity.Select()
        End If
    End Sub

    Private Sub lstItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstItem.KeyPress
        On Error Resume Next
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If lstItem.Items.Count > 0 Then
                txtItemID.Text = Split(lstItem.SelectedItem, " # ")(0)
                txtItemName.Text = Split(lstItem.SelectedItem, " # ")(1)
                ExecuteSQLQuery(" SELECT    *     FROM            tbl_item  WHERE        (item_id = " & txtItemID.Text & ") ")
                txtStockUnit.Text = sqlDT.Rows(0)("quantity")
                txtUOM.Text = sqlDT.Rows(0)("uom")
                lstItem.Visible = False
                txtQuantity.Select()
            End If
        End If
    End Sub

    Private Sub btnNewTrns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTrns.Click
        If txtCustomerID.Text = "" Then
            MsgBox("Required: Customer name", MsgBoxStyle.Information, "Information")
        Else
            If btnNewTrns.Text = "NEW SALES" Then
                ExecuteSQLQuery(" INSERT INTO tbl_sale (Sales_Date, Sales_Time, User_ID, customer_id, grand_disc, collection_full, POS, term_of_payment, consin1, consin2, narration, Payment, Change) VALUES  " & _
                                " ('" & Format(Now, "MM/dd/yyyy") & "', '" + TimeOfDay + "', '" & xUser_ID & "', " & txtCustomerID.Text & ", 0, 'N', 'N', 'DUE', '" + str_repl(txtBuyerConsin1.Text) + "', '" + str_repl(txtBuyerConsin2.Text) + "', '" + str_repl(txtNarration.Text) + "',0 , 0 ) ")
                ExecuteSQLQuery("SELECT        SALES_ID  FROM            tbl_sale  ORDER BY SALES_ID DESC")
                txtInvoiceID.Text = sqlDT.Rows(0)("SALES_ID")
                loadSalesItem()
                gbMain.Enabled = False
                gbDetails.Enabled = True
                txtItemName.Select()
            ElseIf btnNewTrns.Text = "UPDATE" Then
                ExecuteSQLQuery(" UPDATE  tbl_sale SET  customer_id=" & txtCustomerID.Text & ", collection_full='N', term_of_payment='DUE', consin1='" + str_repl(txtBuyerConsin1.Text) + "', consin2='" + str_repl(txtBuyerConsin2.Text) + "', narration='" + str_repl(txtNarration.Text) + "'   " & _
                                "  WHERE        (SALES_ID = " & txtInvoiceID.Text & ") ")
                btnNewTrns.Text = "NEW SALES"
                loadSalesItem()
                gbMain.Enabled = False
                gbDetails.Enabled = True
                txtItemName.Select()
            End If
        End If
    End Sub

    Private Sub btnAddQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddQuantity.Click
        If Val(txtQuantity.Text) <= 0 Then
            MsgBox("Please enter positive value.", MsgBoxStyle.Critical, "Error.")
        Else
            If Not IsNumeric(txtGlobalDisc.Text) Then
                txtGlobalDisc.Text = "0"
            End If
            ExecuteSQLQuery("SELECT    *  FROM            tbl_item   WHERE        (item_id = '" & str_repl(txtItemID.Text) & "') AND (quantity >= " & txtQuantity.Text & ")")
            If sqlDT.Rows.Count > 0 Then
                Dim TEMP_ITEM_ID As Double = sqlDT.Rows(0)("item_id")
                Dim ITEM_VAT As Double = sqlDT.Rows(0)("vat")
                Dim ITEM_COST As Double = sqlDT.Rows(0)("cost") * Val(txtQuantity.Text)
                Dim ITEM_PRICE As Double = sqlDT.Rows(0)("sell_price") * Val(txtQuantity.Text)

                Dim UNIT_COST As Double = sqlDT.Rows(0)("cost")
                Dim UNIT_SELL_PRICE As Double = sqlDT.Rows(0)("sell_price")

                'Sales gloal discount Calculation
                Dim SELL_DISC As Double = ITEM_PRICE * str_repl(txtGlobalDisc.Text) / 100

                'VAT calcualtion
                Dim SALES_VAT As Double = (ITEM_PRICE - SELL_DISC) * ITEM_VAT / 100

                'if already exitst this propduct
                ExecuteSQLQuery("SELECT * FROM tbl_sale_details WHERE SALES_ID=" & txtInvoiceID.Text & " AND item_id=" & TEMP_ITEM_ID & "")
                If sqlDT.Rows.Count > 0 Then
                    'if this item exist into the invoice

                    'Update frm stock
                    ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity - " & txtQuantity.Text & "  WHERE        (item_id = " & TEMP_ITEM_ID & ")")

                    'Insert to sale deails table
                    ExecuteSQLQuery(" UPDATE  tbl_sale_details  SET   quantity=quantity+" & txtQuantity.Text & ", cost=" & UNIT_COST & ",   " & _
                                    "  price= " & UNIT_SELL_PRICE & ", vat=vat+ " & SALES_VAT & ",   " & _
                                    " disc=disc+ " & SELL_DISC & ", total_cost=total_cost+" & ITEM_COST & ",total_price=total_price+ " & ITEM_PRICE - SELL_DISC & " , sub_total=sub_total+ " & (ITEM_PRICE - SELL_DISC) + SALES_VAT & ", retrn='N'   WHERE  SALES_ID=" & txtInvoiceID.Text & " AND  item_id=" & TEMP_ITEM_ID & "  ")

                Else
                    'if this item not exist into the invoice

                    'Update frm stock
                    ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity - " & txtQuantity.Text & "  WHERE        (item_id = " & TEMP_ITEM_ID & ")")

                    'Insert to sale deails table
                    ExecuteSQLQuery(" INSERT INTO tbl_sale_details (SALES_ID, item_id, quantity, cost, price, vat, disc, total_cost, total_price, sub_total, retrn) VALUES  " & _
                                    " ( " & txtInvoiceID.Text & ", " & TEMP_ITEM_ID & ", " & txtQuantity.Text & ", " & UNIT_COST & ", " & UNIT_SELL_PRICE & ", " & SALES_VAT & ",   " & _
                                    " " & SELL_DISC & ", " & ITEM_COST & ", " & ITEM_PRICE - SELL_DISC & " , " & (ITEM_PRICE - SELL_DISC) + SALES_VAT & ", 'N'  )")


                End If


            Else
                MsgBox("Stock unavailable", MsgBoxStyle.Critical, "Critical")
            End If

            txtItemID.Text = ""
            txtItemName.Text = ""
            txtUOM.Text = ""
            txtStockUnit.Text = ""
            txtQuantity.Text = ""
            lstItem.Visible = False
            loadSalesItem()
            txtItemName.Select()

        End If
    End Sub

    Private Sub dtgItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgItem.CellContentClick
        If e.ColumnIndex = 0 Then
            ExecuteSQLQuery("SELECT * FROM tbl_sale_details WHERE auto_id= " & dtgItem.CurrentRow.Cells(1).Value & " ")
            Dim ITEM_ID As Double = sqlDT.Rows(0)("item_id")
            Dim SOLD_QTY As Double = sqlDT.Rows(0)("quantity")
            ExecuteSQLQuery(" UPDATE tbl_item SET  quantity=quantity + " & SOLD_QTY & " WHERE  item_id=" & ITEM_ID & " ")
            ExecuteSQLQuery(" DELETE  tbl_sale_details  WHERE auto_id= " & dtgItem.CurrentRow.Cells(1).Value & " ")
            loadSalesItem()
            txtItemName.Select()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        frmPayment.txtInvoiceID.Text = Me.txtInvoiceID.Text
        frmPayment.ShowDialog()
    End Sub

    Private Sub btnCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollection.Click
        frmCollection.MdiParent = frmMDIParent
        frmCollection.Show()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        FillDataGrid(" SELECT        tbl_sale_details.auto_id, tbl_item.item_name, tbl_sale_details.quantity, tbl_sale_details.price, tbl_sale_details.sub_total " & _
                   " FROM            tbl_sale_details INNER JOIN  tbl_item ON tbl_sale_details.item_id = tbl_item.item_id  WHERE        (tbl_sale_details.SALES_ID = 0) ", dtgItem)
        gbDetails.Enabled = False
        gbMain.Enabled = True
        txtBuyerConsin1.Text = ""
        txtBuyerConsin2.Text = ""
        txtNarration.Text = ""
        txtInvoiceID.Text = ""
        txtCustomerID.Text = ""
        txtCustomer.Text = ""
        lstCustomer.Visible = False
        MsgBox("You’re good to go!", MsgBoxStyle.Information, "Information")
        txtCustomer.Select()
    End Sub

    Private Sub btnInvoiceList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoiceList.Click
        frmFirstInvoiceList.MdiParent = frmMDIParent
        frmFirstInvoiceList.Show()
    End Sub

    Private Sub btnPrintView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintView.Click
        LoadCompanyDetails()
        LoadReport(txtInvoiceID.Text)
    End Sub
End Class