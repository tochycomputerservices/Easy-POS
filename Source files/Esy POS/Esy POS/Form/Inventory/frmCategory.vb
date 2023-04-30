Public Class frmCategory
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

    Private Sub loadCategory()
        FillDataGrid("SELECT        category_id, category_name   FROM            tbl_category", dgvCategory)
    End Sub

    Private Sub frmCategory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadCategory()
        txtCatName.Select()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtCatName.Text = "" Then
            MsgBox("Required: Category Name", MsgBoxStyle.Information, "Information")
        Else
            If btnSave.Text = "SAVE" Then
                'Insert a new item category
                ExecuteSQLQuery(" INSERT INTO  tbl_category (category_name) VALUES ('" + str_repl(txtCatName.Text) + "')")
                loadCategory()
                txtCatName.Text = ""
                Audit_Trail(xUser_ID, TimeOfDay, "Add a new item category.")
                MsgBox("New record has been added on database successfully.", MsgBoxStyle.Information, "Information")
            ElseIf btnSave.Text = "UPDATE" Then
                'Update category unique id wise
                ExecuteSQLQuery(" UPDATE   tbl_category SET   category_name='" + str_repl(txtCatName.Text) + "'  WHERE category_id=" & txtCatID.Text & " ")
                loadCategory()
                txtCatID.Text = ""
                txtCatName.Text = ""
                btnSave.Text = "SAVE"
                Audit_Trail(xUser_ID, TimeOfDay, "Update category.")
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            End If
        End If

    End Sub

    Private Sub dgvCategory_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvCategory.CellContentClick
        If e.ColumnIndex = 0 Then
            If MsgBox("Are you sure to edit: " & dgvCategory.CurrentRow.Cells(2).Value, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                txtCatID.Text = dgvCategory.CurrentRow.Cells(1).Value
                txtCatName.Text = dgvCategory.CurrentRow.Cells(2).Value
                btnSave.Text = "UPDATE"
            End If
        End If
    End Sub
End Class