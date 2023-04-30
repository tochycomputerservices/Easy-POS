Imports System.IO
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlServerCe
Public Class frmPOS
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

    Private Sub TimerMenu_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerMenu.Tick
        lblDate.Text = Date.Now.ToString("MMMMMMMMMM dd, yyyy")
        lblTime.Text = TimeOfDay
    End Sub

    Private Sub frmPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtBarcode.Select()
        FillDataComboBox("SELECT * FROM    tbl_customer  WHERE  (status = N'Active')", "customer_id", "customer_name", cmbCustomer)
        gbQuantity.Visible = False
        FillDataComboBox("SELECT * FROM tbl_category", "category_id", "category_name", cmbCategory)
        cmbCategory.SelectedIndex = -1
        LoadItemWithImg()
    End Sub
    Private Sub LoadItemWithImg()
        FlowLayoutPanel1.Controls.Clear()
        ExecuteSQLQuery("SELECT * FROM tbl_item  WHERE status='Active'")
        If sqlDT.Rows.Count > 0 Then
            For i = 0 To sqlDT.Rows.Count - 1
                Dim picturebx As New Button
                picturebx.TextImageRelation = TextImageRelation.ImageBeforeText
                picturebx.TextAlign = ContentAlignment.MiddleLeft
                picturebx.ImageAlign = ContentAlignment.MiddleLeft
                picturebx.Name = sqlDT.Rows(i)("item_id")
                picturebx.Text = sqlDT.Rows(i)("item_name")
                picturebx.Text += Environment.NewLine + "Price: " & sqlDT.Rows(i)("sell_price")
                If sqlDT.Rows(i)("quantity") >= 1 Then
                    picturebx.BackColor = Color.White
                Else
                    picturebx.BackColor = Color.PeachPuff
                End If
                picturebx.Size = New System.Drawing.Size(150, 75)
                Dim bytBLOBData() As Byte = sqlDT.Rows(i)("photo")
                Dim stmBLOBData As New MemoryStream(bytBLOBData)
                picturebx.Image = ResizeImage(Image.FromStream(stmBLOBData), New System.Drawing.Size(60, 60), True)
                AddHandler picturebx.Click, AddressOf Item_Click
                FlowLayoutPanel1.Controls.Add(picturebx)
            Next
        End If
    End Sub

    Private Sub Item_Click(ByVal sender As Object, ByVal e As EventArgs)
        If txtInvoiceID.Text = "" Then
            MsgBox("Illegal Operation", MsgBoxStyle.Critical, "Critical")
        Else
            '--------------------
            Dim button As Button = TryCast(sender, Button)
            'MessageBox.Show(button.Name)
            If Not IsNumeric(txtGlobalDisc.Text) Then
                txtGlobalDisc.Text = "0"
            End If

            'check unit into stock
            ExecuteSQLQuery("SELECT    *  FROM            tbl_item   WHERE        (item_id = " & button.Name & ") AND (quantity >= 1)")
            If sqlDT.Rows.Count > 0 Then
                Dim TEMP_ITEM_ID As Double = sqlDT.Rows(0)("item_id")
                Dim ITEM_VAT As Double = sqlDT.Rows(0)("vat")
                Dim ITEM_COST As Double = sqlDT.Rows(0)("cost")
                Dim ITEM_PRICE As Double = sqlDT.Rows(0)("sell_price")


                'Sales gloal discount Calculation
                Dim SELL_DISC As Double = ITEM_PRICE * str_repl(txtGlobalDisc.Text) / 100

                'VAT calcualtion
                Dim SALES_VAT As Double = (ITEM_PRICE - SELL_DISC) * ITEM_VAT / 100

                'if already exitst this propduct
                ExecuteSQLQuery("SELECT * FROM tbl_sale_details WHERE SALES_ID=" & txtInvoiceID.Text & " AND item_id=" & TEMP_ITEM_ID & "")
                If sqlDT.Rows.Count > 0 Then
                    'if this item exist into the invoice

                    'Update frm stock
                    ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity - 1  WHERE        (item_id = " & TEMP_ITEM_ID & ")")

                    'Insert to sale deails table
                    ExecuteSQLQuery(" UPDATE  tbl_sale_details  SET   quantity=quantity+1, cost=" & ITEM_COST & ",   " & _
                                    "  price= " & ITEM_PRICE & ", vat=vat+ " & SALES_VAT & ",   " & _
                                    " disc=disc+ " & SELL_DISC & ", total_cost=total_cost+" & ITEM_COST & ",total_price=total_price+ " & ITEM_PRICE - SELL_DISC & " , sub_total=sub_total+ " & (ITEM_PRICE - SELL_DISC) + SALES_VAT & ", retrn='N'   WHERE  SALES_ID=" & txtInvoiceID.Text & " AND  item_id=" & TEMP_ITEM_ID & "  ")
                    loadSalesItem()
                Else
                    'if this item not exist into the invoice

                    'Update frm stock
                    ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity - 1  WHERE        (item_id = " & TEMP_ITEM_ID & ")")

                    'Insert to sale deails table
                    ExecuteSQLQuery(" INSERT INTO tbl_sale_details (SALES_ID, item_id, quantity, cost, price, vat, disc, total_cost, total_price, sub_total, retrn) VALUES  " & _
                                    " ( " & txtInvoiceID.Text & ", " & TEMP_ITEM_ID & ", 1, " & ITEM_COST & ", " & ITEM_PRICE & ", " & SALES_VAT & ",   " & _
                                    " " & SELL_DISC & ", " & ITEM_COST & ", " & ITEM_PRICE - SELL_DISC & " , " & (ITEM_PRICE - SELL_DISC) + SALES_VAT & ", 'N'  )")

                    loadSalesItem()
                End If


            Else
                MsgBox("Stock unavailable", MsgBoxStyle.Critical, "Critical")
            End If

            txtBarcode.Select()
            '--------------------
        End If
    End Sub


    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        If txtInvoiceID.Text = "" Then
            txtBarcode.Text = ""
            MsgBox("Illegal Operation", MsgBoxStyle.Information, "Information")
        Else
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                If txtBarcode.Text = "" Then
                    MsgBox("Please enter item barcode.", MsgBoxStyle.Information, "Information")
                Else
                    ExecuteSQLQuery(" SELECT  *  FROM            tbl_item  WHERE        (barcode = N'" & str_repl(txtBarcode.Text) & "') ")
                    If sqlDT.Rows.Count > 0 Then
                        '--------------------------------------

                        If Not IsNumeric(txtGlobalDisc.Text) Then
                            txtGlobalDisc.Text = "0"
                        End If

                        'check unit into stock
                        ExecuteSQLQuery("SELECT    *  FROM            tbl_item   WHERE        (barcode = N'" & str_repl(txtBarcode.Text) & "') AND (quantity >= 1)")
                        If sqlDT.Rows.Count > 0 Then
                            Dim TEMP_ITEM_ID As Double = sqlDT.Rows(0)("item_id")
                            Dim ITEM_VAT As Double = sqlDT.Rows(0)("vat")
                            Dim ITEM_COST As Double = sqlDT.Rows(0)("cost")
                            Dim ITEM_PRICE As Double = sqlDT.Rows(0)("sell_price")




                            'Sales gloal discount Calculation
                            Dim SELL_DISC As Double = ITEM_PRICE * str_repl(txtGlobalDisc.Text) / 100

                            'VAT calcualtion
                            Dim SALES_VAT As Double = (ITEM_PRICE - SELL_DISC) * ITEM_VAT / 100

                            'if already exitst this propduct
                            ExecuteSQLQuery("SELECT * FROM tbl_sale_details WHERE SALES_ID=" & txtInvoiceID.Text & " AND item_id=" & TEMP_ITEM_ID & "")
                            If sqlDT.Rows.Count > 0 Then
                                'if this item exist into the invoice

                                'Update frm stock
                                ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity - 1  WHERE        (item_id = " & TEMP_ITEM_ID & ")")

                                'Insert to sale deails table
                                ExecuteSQLQuery(" UPDATE  tbl_sale_details  SET   quantity=quantity+1, cost=" & ITEM_COST & ",   " & _
                                                "  price= " & ITEM_PRICE & ", vat=vat+ " & SALES_VAT & ",   " & _
                                                " disc=disc+ " & SELL_DISC & ", total_cost=total_cost+" & ITEM_COST & ",total_price=total_price+ " & ITEM_PRICE - SELL_DISC & " , sub_total=sub_total+ " & (ITEM_PRICE - SELL_DISC) + SALES_VAT & ", retrn='N'   WHERE  SALES_ID=" & txtInvoiceID.Text & " AND  item_id=" & TEMP_ITEM_ID & "  ")

                            Else
                                'if this item not exist into the invoice

                                'Update frm stock
                                ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity - 1  WHERE        (item_id = " & TEMP_ITEM_ID & ")")

                                'Insert to sale deails table
                                ExecuteSQLQuery(" INSERT INTO tbl_sale_details (SALES_ID, item_id, quantity, cost, price, vat, disc, total_cost, total_price, sub_total, retrn) VALUES  " & _
                                                " ( " & txtInvoiceID.Text & ", " & TEMP_ITEM_ID & ", 1, " & ITEM_COST & ", " & ITEM_PRICE & ", " & SALES_VAT & ",   " & _
                                                " " & SELL_DISC & ", " & ITEM_COST & ", " & ITEM_PRICE - SELL_DISC & " , " & (ITEM_PRICE - SELL_DISC) + SALES_VAT & ", 'N'  )")


                            End If


                        Else
                            MsgBox("Stock unavailable", MsgBoxStyle.Critical, "Critical")
                        End If
                        txtBarcode.Text = ""
                        loadSalesItem()
                        '--------------------------------------
                    Else
                        txtBarcode.Text = ""
                        MsgBox("Sorry!  Barcode not found.", MsgBoxStyle.Information, "Information")
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub loadSalesItem()
        FillDataGrid(" SELECT        tbl_sale_details.auto_id, tbl_item.item_name, tbl_sale_details.quantity, tbl_sale_details.price, tbl_sale_details.sub_total " & _
                     " FROM            tbl_sale_details INNER JOIN  tbl_item ON tbl_sale_details.item_id = tbl_item.item_id  WHERE        (tbl_sale_details.SALES_ID = " & txtInvoiceID.Text & ") ", dtgItem)
        ExecuteSQLQuery("SELECT        SALES_ID  FROM            tbl_sale_details  WHERE        (SALES_ID = " & txtInvoiceID.Text & ")")
        If sqlDT.Rows.Count > 0 Then
            ExecuteSQLQuery("SELECT    SUM(sub_total) AS Expr1  FROM            tbl_sale_details  WHERE        (SALES_ID = " & txtInvoiceID.Text & ")")
            lblTotal.Text = Math.Round(sqlDT.Rows(0)("Expr1"), 2)
        Else
            lblTotal.Text = "00.00"
        End If

    End Sub

    Private Sub dtgItem_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgItem.CellContentClick
        If e.ColumnIndex = 0 Then
            COL_ID = dtgItem.CurrentRow.Cells(2).Value
            gbQuantity.Visible = True
            txtQuantity.Select()
        ElseIf e.ColumnIndex = 1 Then
            ExecuteSQLQuery("SELECT * FROM tbl_sale_details WHERE auto_id= " & dtgItem.CurrentRow.Cells(2).Value & " ")
            Dim ITEM_ID As Double = sqlDT.Rows(0)("item_id")
            Dim SOLD_QTY As Double = sqlDT.Rows(0)("quantity")
            ExecuteSQLQuery(" UPDATE tbl_item SET  quantity=quantity + " & SOLD_QTY & " WHERE  item_id=" & ITEM_ID & " ")
            ExecuteSQLQuery(" DELETE  tbl_sale_details  WHERE auto_id= " & dtgItem.CurrentRow.Cells(2).Value & " ")
            loadSalesItem()
            txtBarcode.Select()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        clr_count = clr_count + 3
        If (clr_count Mod 2) = 0 Then
            lblTotal.ForeColor = Color.BlueViolet
        Else
            lblTotal.ForeColor = Color.Black
        End If
    End Sub

    Private Sub btnAddQuantity_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddQuantity.Click
        '  gbQuantity.Visible = False
        If Val(txtQuantity.Text) <= 0 Then
            MsgBox("Please enter positive value.", MsgBoxStyle.Critical, "Error.")
        Else
            ExecuteSQLQuery("SELECT   *  FROM            tbl_sale_details  WHERE        (auto_id = " & COL_ID & ")")
            Dim TEMP_ITEM_ID As Double = sqlDT.Rows(0)("item_id")
            ExecuteSQLQuery("SELECT    *  FROM            tbl_item   WHERE        (item_id = '" & TEMP_ITEM_ID & "') AND (quantity >= " & Val(txtQuantity.Text) & ")")
            If sqlDT.Rows.Count > 0 Then

                Dim UNIT_COST As Double = sqlDT.Rows(0)("cost")
                Dim UNIT_SELL_PRICE As Double = sqlDT.Rows(0)("sell_price")

                Dim ITEM_VAT As Double = sqlDT.Rows(0)("vat")
                Dim ITEM_COST As Double = Val(txtQuantity.Text) * sqlDT.Rows(0)("cost")
                Dim ITEM_PRICE As Double = Val(txtQuantity.Text) * sqlDT.Rows(0)("sell_price")

                'Sales gloal discount Calculation
                Dim SELL_DISC As Double = ITEM_PRICE * str_repl(txtGlobalDisc.Text) / 100

                'VAT calcualtion
                Dim SALES_VAT As Double = (ITEM_PRICE - SELL_DISC) * ITEM_VAT / 100


                'Update frm stock
                ExecuteSQLQuery(" UPDATE  tbl_item  SET  quantity=quantity - " & Val(txtQuantity.Text) & "  WHERE        (item_id = " & TEMP_ITEM_ID & ")")

                'Insert to sale deails table
                ExecuteSQLQuery(" UPDATE  tbl_sale_details  SET   quantity=quantity+" & Val(txtQuantity.Text) & ", cost=" & UNIT_COST & ",   " & _
                                "  price= " & UNIT_SELL_PRICE & ", vat=vat+ " & SALES_VAT & ",   " & _
                                " disc=disc+ " & SELL_DISC & ", total_cost=total_cost+" & ITEM_COST & ",total_price=total_price+ " & ITEM_PRICE - SELL_DISC & " , sub_total=sub_total+ " & (ITEM_PRICE - SELL_DISC) + SALES_VAT & ", retrn='N'   WHERE  SALES_ID=" & txtInvoiceID.Text & " AND  item_id=" & TEMP_ITEM_ID & "  ")


                loadSalesItem()
                txtQuantity.Text = ""
                gbQuantity.Visible = False
                txtBarcode.Select()
            Else
                loadSalesItem()
                txtQuantity.Text = ""
                gbQuantity.Visible = False
                MsgBox("Stock unavailable", MsgBoxStyle.Critical, "Critical")
                txtBarcode.Select()
            End If
        End If

    End Sub

    Private Sub btnNewTrns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewTrns.Click
        If cmbCustomer.SelectedValue Is Nothing Or cmbCustomer.SelectedIndex = -1 Then
            MsgBox("Required: Customer name", MsgBoxStyle.Information, "Information")
        Else
            ExecuteSQLQuery(" INSERT INTO tbl_sale (Sales_Date, Sales_Time, User_ID, customer_id, grand_disc, collection_full, POS, term_of_payment, consin1, consin2, narration, Payment, Change) VALUES  " & _
                             " ('" & Format(Now, "MM/dd/yyyy") & "', '" + TimeOfDay + "', '" & xUser_ID & "', " & cmbCustomer.SelectedValue & ", 0, 'N', 'Y', 'DUE', '-', '-', '-',0 , 0) ")
            ExecuteSQLQuery("SELECT        SALES_ID  FROM            tbl_sale  ORDER BY SALES_ID DESC")
            txtInvoiceID.Text = sqlDT.Rows(0)("SALES_ID")
            loadSalesItem()
            txtBarcode.Select()
        End If
    End Sub
    Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
        Select Case keyData
            Case Keys.F2
                btnNewTrns.PerformClick()
            Case Keys.F5
                btnPayment.PerformClick()
            Case Keys.Escape
                Me.Close()
            Case Else
                Return MyBase.ProcessCmdKey(msg, keyData)
        End Select

        Return True
    End Function

    Private Sub btnPayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPayment.Click
        If txtInvoiceID.Text = "" Then
            MsgBox("Illegal Operation", MsgBoxStyle.Critical, "Critical")
        Else
            frmPayment.txtInvoiceID.Text = Me.txtInvoiceID.Text
            frmPayment.ShowDialog()
        End If

    End Sub

    Private Sub btnCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollection.Click
        frmCollection.MdiParent = frmMDIParent
        frmCollection.Show()
    End Sub

    Private Sub btnInvoiceList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoiceList.Click
        frmPOSList.ShowDialog()
    End Sub

    Private Sub txtInvoiceID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtInvoiceID.TextChanged
        If IsNumeric(txtInvoiceID.Text) Then
            loadSalesItem()
        End If
    End Sub

    Private Sub btnPrintPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintPrev.Click
        If txtInvoiceID.Text = "" Then
            MsgBox("Illegal Operation", MsgBoxStyle.Critical, "Critical")
        Else
            LoadCompanyDetails()
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
                                         " tbl_sale_details.disc, tbl_sale_details.total_cost, tbl_sale_details.total_price, tbl_sale_details.sub_total, tbl_customer.address, tbl_customer.phone, tbl_sale.Payment, tbl_sale.Change " & _
                                         " FROM            tbl_customer INNER JOIN  tbl_sale ON tbl_customer.customer_id = tbl_sale.customer_id INNER JOIN tbl_users ON tbl_sale.User_ID = tbl_users.User_ID LEFT OUTER JOIN  tbl_item INNER JOIN " & _
                                         " tbl_sale_details ON tbl_item.item_id = tbl_sale_details.item_id ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID  WHERE        (tbl_sale.SALES_ID = " & txtInvoiceID.Text & ") "
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

                .CrystalReportViewer1.ReportSource = rpt_Document
                .Show()

            End With
        End If
    End Sub
    Private Sub cmbCategory_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCategory.SelectedValueChanged
        If cmbCategory.SelectedValue Is Nothing Or cmbCategory.SelectedIndex = -1 Then

        Else
            FlowLayoutPanel1.Controls.Clear()
            ExecuteSQLQuery("SELECT * FROM tbl_item  WHERE status='Active'  AND  category_id = " & num_fltr(cmbCategory.SelectedValue.ToString) & "  ")
            If sqlDT.Rows.Count > 0 Then
                For i = 0 To sqlDT.Rows.Count - 1
                    Dim picturebx As New Button
                    picturebx.TextImageRelation = TextImageRelation.ImageBeforeText
                    picturebx.TextAlign = ContentAlignment.MiddleLeft
                    picturebx.ImageAlign = ContentAlignment.MiddleLeft
                    picturebx.Name = sqlDT.Rows(i)("item_id")
                    picturebx.Text = sqlDT.Rows(i)("item_name")
                    picturebx.Text += Environment.NewLine + "Price: " & sqlDT.Rows(i)("sell_price")
                    If sqlDT.Rows(i)("quantity") >= 1 Then
                        picturebx.BackColor = Color.White
                    Else
                        picturebx.BackColor = Color.PeachPuff
                    End If
                    picturebx.Size = New System.Drawing.Size(150, 75)
                    Dim bytBLOBData() As Byte = sqlDT.Rows(i)("photo")
                    Dim stmBLOBData As New MemoryStream(bytBLOBData)
                    picturebx.Image = ResizeImage(Image.FromStream(stmBLOBData), New System.Drawing.Size(60, 60), True)
                    AddHandler picturebx.Click, AddressOf Item_Click
                    FlowLayoutPanel1.Controls.Add(picturebx)
                Next
            End If
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadItemWithImg()
    End Sub
End Class