Public Class frmBadStock
    Dim x, y As Integer
    Dim newpoint As New Point
    Dim ITEM_COST As Double
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

    Private Sub frmBadStock_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        lstItem.Visible = False
    End Sub

    Private Sub frmBadStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtItemName.Select()
        lstItem.Visible = False
        loadData()
        FillListBox(" SELECT item_id,item_name FROM tbl_item  WHERE status='Active' ", lstItem)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtItemName_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtItemName.Click
        lstItem.Visible = True
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
        lstItem.Visible = False
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
            ITEM_COST = sqlDT.Rows(0)("cost")
            lstItem.Visible = False
            txtBadUnit.Select()
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
                ITEM_COST = sqlDT.Rows(0)("cost")
                lstItem.Visible = False
                txtBadUnit.Select()
            End If
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtItemID.Text = "" Then
            MsgBox("Required: Item Name", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtBadUnit.Text) Then
            MsgBox("Required: Bad Unit", MsgBoxStyle.Information, "Information")
        ElseIf Val(txtBadUnit.Text) > Val(txtStockUnit.Text) Then
            MsgBox("Insufficient stock.", MsgBoxStyle.Critical, "Critical")
        Else
            'Insert bad stock information into database.
            ExecuteSQLQuery(" INSERT INTO tbl_bad_stock (item_id, User_ID, quantity, uom, entry_date, cost, reason) VALUES  " & _
                            " (" & txtItemID.Text & ", " & xUser_ID & ", " & str_repl(txtBadUnit.Text) & ", '" & txtUOM.Text & "', '" & Format(Now, "MM/dd/yyyy") & "', " & Val(txtBadUnit.Text) * ITEM_COST & ", '" + str_repl(txtReason.Text) + "') ")
            'Update from stock
            ExecuteSQLQuery(" UPDATE  tbl_item SET quantity=quantity-" & str_repl(txtBadUnit.Text) & "  WHERE        (item_id = " & txtItemID.Text & ") ")

            Audit_Trail(xUser_ID, TimeOfDay, "Change Password.")

            txtItemID.Text = ""
            txtItemName.Text = ""
            txtStockUnit.Text = ""
            txtUOM.Text = ""
            txtBadUnit.Text = ""
            txtReason.Text = ""
            lstItem.Visible = False
            txtItemName.Select()
            loadData()
            MsgBox("Bad stock has been added on database successfully.", MsgBoxStyle.Information, "Information")
        End If
    End Sub

    Private Sub loadData()
        FillDataGrid(" SELECT        tbl_bad_stock.stock_id, tbl_item.item_name, tbl_bad_stock.quantity, tbl_bad_stock.uom, tbl_bad_stock.cost, tbl_bad_stock.entry_date " & _
                     " FROM            tbl_bad_stock INNER JOIN   tbl_item ON tbl_bad_stock.item_id = tbl_item.item_id " & _
                     " WHERE        (tbl_bad_stock.entry_date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_bad_stock.entry_date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ", dgvRecord)
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        loadData()
    End Sub

    Private Sub dtpFrom_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFrom.ValueChanged
        loadData()
    End Sub

    Private Sub dtpTo_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTo.ValueChanged
        loadData()
    End Sub

    Private Sub dgvRecord_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvRecord.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure to delete: " & dgvRecord.CurrentRow.Cells(2).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                'Get item information from bad stock.
                ExecuteSQLQuery(" SELECT  * FROM tbl_bad_stock WHERE stock_id= " & dgvRecord.CurrentRow.Cells(1).Value & " ")
                Dim ITEM_ID As Double = sqlDT.Rows(0)("item_id")
                Dim QUANTIRY As Double = sqlDT.Rows(0)("quantity")
                'Quantity return into stock.
                ExecuteSQLQuery(" UPDATE tbl_item SET  quantity=quantity+" & QUANTIRY & " WHERE        (item_id = " & ITEM_ID & ") ")
                'Delete data from bad stock
                ExecuteSQLQuery(" DELETE  tbl_bad_stock WHERE stock_id= " & dgvRecord.CurrentRow.Cells(1).Value & " ")
                loadData()
                Audit_Trail(xUser_ID, TimeOfDay, "Delete data from bad stock.")
                MsgBox("Stock updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If
    End Sub
End Class