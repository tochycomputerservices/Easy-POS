Public Class frmResetDB
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

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        If MsgBox(" Do you want Reset database ? Database Reset will delete all of the data on your database. ", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
            ExecuteSQLQuery(" DELETE FROM  Barcode")
            ExecuteSQLQuery(" DELETE FROM  Setting")
            ExecuteSQLQuery(" DELETE FROM  tbl_bad_stock")
            ExecuteSQLQuery(" DELETE FROM  tbl_business")
            ExecuteSQLQuery(" DELETE FROM  tbl_category")
            ExecuteSQLQuery(" DELETE FROM  tbl_customer")
            ExecuteSQLQuery(" DELETE FROM  tbl_employee")
            ExecuteSQLQuery(" DELETE FROM  tbl_item")
            ExecuteSQLQuery(" DELETE FROM  tbl_permission")
            ExecuteSQLQuery(" DELETE FROM  tbl_sale")
            ExecuteSQLQuery(" DELETE FROM  tbl_sale_details")
            ExecuteSQLQuery(" DELETE FROM  tbl_sale_return")
            ExecuteSQLQuery(" DELETE FROM  tbl_supplier")
            ExecuteSQLQuery(" DELETE FROM  tbl_users")
            ExecuteSQLQuery(" DELETE FROM  tbl_userlog")
            ExecuteSQLQuery(" DELETE FROM  tbl_usertrail")
            ExecuteSQLQuery(" DELETE FROM  HeadOfAccounts")
            ExecuteSQLQuery(" DELETE FROM  ChartOfAccounts")
            ExecuteSQLQuery(" DELETE FROM  Voucher")
            ExecuteSQLQuery(" DELETE FROM  tbl_Transaction")

            ExecuteSQLQuery(" ALTER TABLE tbl_bad_stock ALTER COLUMN stock_id IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_category ALTER COLUMN category_id IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_customer ALTER COLUMN customer_id IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_employee ALTER COLUMN emp_id IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_item ALTER COLUMN item_id IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_sale ALTER COLUMN SALES_ID IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_sale_details ALTER COLUMN auto_id IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_sale_return ALTER COLUMN RETURN_ID IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_supplier ALTER COLUMN supplier_id IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_userlog ALTER COLUMN Log_ID IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_users ALTER COLUMN User_ID IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE ChartOfAccounts ALTER COLUMN CH_ACC_ID IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE Voucher ALTER COLUMN BILL_NO IDENTITY (1,1) ")
            ExecuteSQLQuery(" ALTER TABLE tbl_Transaction ALTER COLUMN ID IDENTITY (1,1) ")

            MsgBox("Done.", MsgBoxStyle.Information, "Information")
            MsgBox("The software will be closed now.", MsgBoxStyle.Information, "Information")
            End
        End If
    End Sub
End Class