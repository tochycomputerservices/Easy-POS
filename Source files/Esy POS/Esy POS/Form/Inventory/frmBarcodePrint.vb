Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Data.SqlServerCe
Public Class frmBarcodePrint
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

    Private Sub btnClearPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearPage.Click
        ExecuteSQLQuery(" DELETE FROM Barcode ")
    End Sub

    Private Sub frmBarcodePrint_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        lstItem.Visible = False
    End Sub

    Private Sub frmBarcodePrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CountData()
        FillListBox(" SELECT item_id,item_name FROM tbl_item  WHERE status='Active' ", lstItem)
        lstItem.Visible = False
    End Sub
    Private Sub CountData()

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
            txtBarcode.Text = ""
            txtPrice.Text = ""
            lstItem.Visible = True
            FillListBox(" SELECT item_id,item_name FROM tbl_item  WHERE status='Active'", lstItem)
            PicBarCode.BackgroundImage = Code128("", "", "", "A")
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
            txtBarcode.Text = sqlDT.Rows(0)("barcode")
            txtPrice.Text = sqlDT.Rows(0)("sell_price")
            lstItem.Visible = False
            PicBarCode.BackgroundImage = Code128(txtBarcode.Text, txtItemName.Text, "PRICE: " & txtPrice.Text, "A")
            txtLabelPcs.Select()
        End If
    End Sub

    Private Sub lstItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lstItem.KeyPress
        On Error Resume Next
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If lstItem.Items.Count > 0 Then
                txtItemID.Text = Split(lstItem.SelectedItem, " # ")(0)
                txtItemName.Text = Split(lstItem.SelectedItem, " # ")(1)
                ExecuteSQLQuery(" SELECT    *     FROM            tbl_item  WHERE        (item_id = " & txtItemID.Text & ") ")
                txtBarcode.Text = sqlDT.Rows(0)("barcode")
                txtPrice.Text = sqlDT.Rows(0)("sell_price")
                PicBarCode.BackgroundImage = Code128(txtBarcode.Text, txtItemName.Text, "PRICE: " & txtPrice.Text, "A")
                lstItem.Visible = False
                txtLabelPcs.Select()
            End If
        End If
    End Sub

    Private Sub btnAddToPage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToPage.Click
        If txtItemID.Text = "" Then
            MsgBox("Required: Item Name", MsgBoxStyle.Information, "Information")
        ElseIf Val(txtLabelPcs.Text) <= 0 Then
            MsgBox("Required: Barcode Sticker Quantity ", MsgBoxStyle.Information, "Information")
        Else
            Dim x, i As Integer
            Dim cnt As Integer
            Dim XHOLD As Integer
            Dim holdI As Integer
            holdI = 0
            cnt = 1

            For i = 0 To Int(txtLabelPcs.Text) - 1
                If cnt = 1 Then
                    sqlSTR = "INSERT INTO Barcode (BARCODE_1, PRODUCT_DESC_1, MRP_1) VALUES ('" + txtBarcode.Text + "','" + txtItemName.Text + "', 'PRICE: " + txtPrice.Text + "')"
                    ExecuteSQLQuery(sqlSTR)
                    sqlSTR = "SELECT * FROM Barcode ORDER BY auto_id DESC"
                    ExecuteSQLQuery(sqlSTR)
                    XHOLD = sqlDT.Rows(0)("auto_id")
                ElseIf cnt = 2 Then
                    sqlSTR = "UPDATE Barcode SET BARCODE_2 ='" & txtBarcode.Text & "', PRODUCT_DESC_2='" + txtItemName.Text + "' , MRP_2='PRICE: " + txtPrice.Text + "' WHERE auto_id =" & XHOLD
                    ExecuteSQLQuery(sqlSTR)
                    holdI = holdI + 1
                Else
                    If ((cnt - 1) / (2)) = 1 Then
                        sqlSTR = "INSERT INTO Barcode (BARCODE_1, PRODUCT_DESC_1, MRP_1) VALUES ('" + txtBarcode.Text + "','" + txtItemName.Text + "', 'PRICE: " + txtPrice.Text + "')"
                        ExecuteSQLQuery(sqlSTR)
                        sqlSTR = "SELECT * FROM Barcode ORDER BY auto_id DESC"
                        ExecuteSQLQuery(sqlSTR)
                        XHOLD = sqlDT.Rows(0)("auto_id")
                        cnt = 1
                    End If
                End If
                cnt = cnt + 1
            Next

            Audit_Trail(xUser_ID, TimeOfDay, "Add barcode stiker into barcode table.")

            txtItemID.Text = ""
            txtItemName.Text = ""
            txtBarcode.Text = ""
            txtPrice.Text = ""
            txtLabelPcs.Text = ""
            lstItem.Visible = False
        End If
    End Sub


    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        If txtItemID.Text = "" Then
            MsgBox("Required: Item Name", MsgBoxStyle.Information, "Information")
        Else
            Dim dlg As New SaveFileDialog
            dlg.Filter = " " & txtItemName.Text & "|*.jpg"
            If dlg.ShowDialog = Windows.Forms.DialogResult.OK Then
                PicBarCode.BackgroundImage.Save(dlg.FileName)
            End If
        End If
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        ExecuteSQLQuery("SELECT *  FROM            Barcode")
        If sqlDT.Rows.Count > 0 Then
            '---------------------------------------------------------------
            Audit_Trail(xUser_ID, TimeOfDay, "Print preview barcode.")
            With frmCrvDefault
                Dim rpt_Document As New ReportDocument
                Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
                rpt_Document.Load(Application.StartupPath & "\Reports\Barcode.rpt")
                Dim My_Connection As SqlCeConnection
                Dim my_Command As New SqlCeCommand
                Dim my_DataAdapter As New SqlCeDataAdapter
                Dim my_DataSource As New EsyPosDataSet
                My_Connection = New SqlCeConnection(CnString)
                my_Command.CommandText = "SELECT *  FROM   Barcode"
                my_Command.Connection = My_Connection
                my_Command.CommandType = CommandType.Text
                my_DataAdapter.SelectCommand = my_Command
                my_DataAdapter.Fill(my_DataSource, "Barcode")
                rpt_Document.SetDataSource(my_DataSource)
                .CrystalReportViewer1.ReportSource = rpt_Document
                .Show()
            End With
            '---------------------------------------------------------------
        Else
            MsgBox("Barcode not found.", MsgBoxStyle.Information, "Information")
        End If
    End Sub
End Class