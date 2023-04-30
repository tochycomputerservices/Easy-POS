Imports System.IO
Imports System.Data.SqlServerCe
Public Class frmItemInformation
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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub frmItemInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbCategory.Select()
        LoadData()
    End Sub

    Private Sub btnListView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnListView.Click
        frmListOfItem.MdiParent = frmMDIParent
        frmListOfItem.Show()
    End Sub

    Private Sub LoadData()
        FillDataComboBox("SELECT *  FROM   tbl_supplier  WHERE  (status = 'Active') ", "supplier_id", "supplier_name", cmbSupplier)
        FillDataComboBox("SELECT  category_id, category_name  FROM   tbl_category", "category_id", "category_name", cmbCategory)

        ExecuteSQLQuery("SELECT   *   FROM  tbl_item")
        If sqlDT.Rows.Count > 0 Then
            lblCount.Text = "Total " & sqlDT.Rows.Count & " item found."
        Else
            lblCount.Text = "Total 0 item found."
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        LoadData()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbCategory.SelectedValue Is Nothing Or cmbCategory.SelectedIndex = -1 Then
            MsgBox("Required: Category", MsgBoxStyle.Information, "Information")
        ElseIf cmbSupplier.SelectedValue Is Nothing Or cmbSupplier.SelectedIndex = -1 Then
            MsgBox("Required: Supplier", MsgBoxStyle.Information, "Information")
        ElseIf txtItemName.Text = "" Then
            MsgBox("Required: Item Name", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtQuantity.Text) Then
            MsgBox("Required: Quantity or Zero", MsgBoxStyle.Information, "Information")
        ElseIf txtUOM.Text = "" Then
            MsgBox("Required: Unit of Mesure", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtCost.Text) Then
            MsgBox("Required: Cost or Zero", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtPrice.Text) Then
            MsgBox("Required: Price or Zero", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtVAT.Text) Then
            MsgBox("Required: VAT or Zero", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtROL.Text) Then
            MsgBox("Required: Re Order Level  or Zero", MsgBoxStyle.Information, "Information")
        ElseIf cmbStatus.Text = "" Then
            MsgBox("Required: Status", MsgBoxStyle.Information, "Information")
        Else
            If btnSave.Text = "SAVE" Then
                If cbAutoBarcode.Checked Then

                    'Get barcode form database (Setting table )
                    CreateBarcode()

                    'Insert a new item
                    ExecuteSQLQuery(" INSERT INTO  tbl_item (category_id ,supplier_id, item_name, barcode, quantity, uom, cost, sell_price, vat, re_order_level, status) VALUES " & _
                                    " (  " & cmbCategory.SelectedValue & ", " & cmbSupplier.SelectedValue & ", '" + str_repl(txtItemName.Text) + "', '" & AUTO_BARCODE & "', '" & str_repl(txtQuantity.Text) & "', '" + str_repl(txtUOM.Text) + "', '" + str_repl(txtCost.Text) + "', '" & str_repl(txtPrice.Text) & "', '" & str_repl(txtVAT.Text) & "', '" & str_repl(txtROL.Text) & "', '" + str_repl(cmbStatus.Text) + "' ) ")
                    ExecuteSQLQuery("SELECT   item_id  FROM   tbl_item  ORDER BY item_id DESC")
                    Dim ITEM_ID As Double = sqlDT.Rows(0)("item_id")
                    uploadImage(ITEM_ID)
                    Audit_Trail(xUser_ID, TimeOfDay, "Add item: " & str_repl(txtItemName.Text))
                    ClearAllControl()
                    LoadData()
                    MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
                Else
                    'manual barcode with product entry
                    If txtBarcode.Text = "" Then
                        MsgBox("Required: Barcode", MsgBoxStyle.Information, "Information")
                    Else
                        'check the barcode existance
                        ExecuteSQLQuery("SELECT        barcode  FROM            tbl_item  WHERE        (barcode = '" + str_repl(txtBarcode.Text) + "')")
                        If sqlDT.Rows.Count > 0 Then
                            MsgBox("Sorry! Barcode already exist.", MsgBoxStyle.Critical, "Error.")
                        Else
                            ExecuteSQLQuery(" INSERT INTO  tbl_item (category_id ,supplier_id, item_name, barcode, quantity, uom, cost, sell_price, vat, re_order_level, status) VALUES " & _
                                            " (  " & cmbCategory.SelectedValue & ", " & cmbSupplier.SelectedValue & ", '" + str_repl(txtItemName.Text) + "', '" + str_repl(txtBarcode.Text) + "', '" & str_repl(txtQuantity.Text) & "', '" + str_repl(txtUOM.Text) + "', '" + str_repl(txtCost.Text) + "', '" & str_repl(txtPrice.Text) & "', '" & str_repl(txtVAT.Text) & "', '" & str_repl(txtROL.Text) & "', '" + str_repl(cmbStatus.Text) + "' ) ")
                            ExecuteSQLQuery("SELECT   item_id  FROM   tbl_item  ORDER BY item_id DESC")
                            Dim ITEM_ID As Double = sqlDT.Rows(0)("item_id")
                            uploadImage(ITEM_ID)
                            Audit_Trail(xUser_ID, TimeOfDay, "Add Item : " & str_repl(txtItemName.Text))
                            ClearAllControl()
                            LoadData()
                            MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
                        End If
                    End If
                End If
            ElseIf btnSave.Text = "UPDATE" Then
                'Update statement
                ExecuteSQLQuery(" UPDATE   tbl_item  SET category_id=" & cmbCategory.SelectedValue & " ,supplier_id=" & cmbSupplier.SelectedValue & ", item_name='" + str_repl(txtItemName.Text) + "',  " & _
                                " barcode='" + str_repl(txtBarcode.Text) + "', quantity='" & str_repl(txtQuantity.Text) & "', uom='" + str_repl(txtUOM.Text) + "', cost='" + str_repl(txtCost.Text) + "', sell_price='" & str_repl(txtPrice.Text) & "', vat='" & str_repl(txtVAT.Text) & "', re_order_level='" & str_repl(txtROL.Text) & "', status='" + str_repl(cmbStatus.Text) + "'  " & _
                                " WHERE item_id=" & txtItemID.Text & " ")
                uploadImage(txtItemID.Text)
                Audit_Trail(xUser_ID, TimeOfDay, "Update Item: " & str_repl(txtItemName.Text))
                ClearAllControl()
                LoadData()
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If

    End Sub
    Private Sub uploadImage(ByVal ITEM_ID As Double)
        Dim con As New SqlCeConnection(CnString)
        con.Open()
        Dim sql As String = "UPDATE  tbl_item SET  photo=@photo  WHERE item_id=" & ITEM_ID & " "
        Dim cmd As New SqlCeCommand(sql, con)
        Dim ms As New MemoryStream()
        PictureBox1.BackgroundImage.Save(ms, PictureBox1.BackgroundImage.RawFormat)
        Dim data As Byte() = ms.GetBuffer()
        Dim p As New SqlCeParameter("@photo", SqlDbType.Image)
        p.Value = data
        cmd.Parameters.Add(p)
        cmd.ExecuteNonQuery()
        cmd.Dispose()
        con.Close()
    End Sub
    Private Sub ClearAllControl()
        txtItemID.Text = ""
        txtItemName.Text = ""
        txtBarcode.Text = ""
        txtQuantity.Text = ""
        txtUOM.Text = ""
        txtCost.Text = ""
        txtPrice.Text = ""
        txtVAT.Text = ""
        txtROL.Text = ""
        cmbStatus.SelectedIndex = -1
        PictureBox1.BackgroundImage = Esy_POS.My.Resources.no_item_image_sm
        btnSave.Text = "SAVE"
    End Sub
    Private Sub btnAddCategory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCategory.Click
        frmCategory.MdiParent = frmMDIParent
        frmCategory.Show()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OpenFileDialog1.Filter = "Image Files (JPEG,GIF,BMP,PNG)|*.jpg;*.jpeg;*.gif;*.bmp;*.png;"
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            PictureBox1.BackgroundImage = Image.FromFile(OpenFileDialog1.FileName)
        End If
    End Sub
End Class