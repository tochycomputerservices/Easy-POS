Imports System.IO
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Windows.Forms
Imports System.Data.SqlServerCe

Public Class frmImportItems
    Dim x, y As Integer
    Dim newpoint As New Point
    Private Excel07ConString As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties='Excel 12.0;HDR={1}'"
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

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Using OpenFileDialog As OpenFileDialog = New OpenFileDialog()
            OpenFileDialog.Title = "Microsoft Excel File..."
            OpenFileDialog.Filter = "Excel Files (xlsx)|*.xlsx;"

            If OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                txtFilePath.Text = OpenFileDialog.FileName
                '''''''''''
                Try
                    ''''''''''''''''''''''''''
                    Dim conStr, sheetName As String
                    conStr = String.Format(Excel07ConString, txtFilePath.Text, "YES")
                    'Get the name of the First Sheet.
                    Using con As OleDbConnection = New OleDbConnection(conStr)
                        Using cmd As OleDbCommand = New OleDbCommand()
                            cmd.Connection = con
                            con.Open()
                            Dim dtExcelSchema As DataTable = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
                            sheetName = dtExcelSchema.Rows(0)("TABLE_NAME").ToString()
                            con.Close()
                        End Using
                    End Using
                    'Read Data from the First Sheet.
                    Using con As OleDbConnection = New OleDbConnection(conStr)

                        Using cmd As OleDbCommand = New OleDbCommand()

                            Using oda As OleDbDataAdapter = New OleDbDataAdapter()
                                Dim dt As DataTable = New DataTable()
                                cmd.CommandText = "SELECT * From [" & sheetName & "]"
                                cmd.Connection = con
                                con.Open()
                                oda.SelectCommand = cmd
                                oda.Fill(dt)
                                con.Close()
                                'Populate DataGridView.
                                dgv1.DataSource = dt
                            End Using
                        End Using
                        ''''''''''''''''''''''''''
                    End Using
                Catch ex As Exception
                    MessageBox.Show(ex.ToString())
                End Try
                '''''''''''
            End If
        End Using
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If dgv1.RowCount > 0 Then
                Dim msg As New DialogResult()
                msg = MessageBox.Show("Total " + dgv1.RowCount.ToString() + " student(s) found. Click Yes to save this data.", "Import Data?", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If msg = DialogResult.Yes Then
                    Dim i As Integer = 0
                    For i = 0 To dgv1.RowCount - 1
                        Dim ItemName As String = dgv1.Rows(i).Cells("ITEM_NAME").Value.ToString()
                        Dim Barcode As String = dgv1.Rows(i).Cells("BARCODE").Value.ToString()
                        Dim Quantity As String = dgv1.Rows(i).Cells("QUANTITY").Value.ToString()
                        Dim UnitOfMeasure As String = dgv1.Rows(i).Cells("UOM").Value.ToString()
                        Dim Cost As String = dgv1.Rows(i).Cells("COST").Value.ToString()
                        Dim SellPrice As String = dgv1.Rows(i).Cells("SELL_PRICE").Value.ToString()
                        Dim Vat As String = dgv1.Rows(i).Cells("VAT").Value.ToString()
                        Dim ReOrderLevel As String = dgv1.Rows(i).Cells("RE_ORDER_LEVEL").Value.ToString()
                        Dim ItemStatus As String = dgv1.Rows(i).Cells("STATUS").Value.ToString()
                        Dim SuppID As String = dgv1.Rows(i).Cells("SUPPLIER_ID").Value.ToString()
                        Dim CatId As String = dgv1.Rows(i).Cells("CATEGORY_ID").Value.ToString()
                        ExecuteSQLQuery(" INSERT INTO  tbl_item (category_id ,supplier_id, item_name, barcode, quantity, uom, cost, sell_price, vat, re_order_level, status) VALUES " &
                                        " (  " & num_fltr(CatId) & ", " & num_fltr(SuppID) & ", '" + str_repl(ItemName) + "', '" + str_repl(Barcode) + "', '" & num_fltr(Quantity) & "', '" + str_repl(UnitOfMeasure) + "', '" + num_fltr(Cost) + "', '" & num_fltr(SellPrice) & "', '" & num_fltr(Vat) & "', '" & num_fltr(ReOrderLevel) & "', '" + str_repl(ItemStatus) + "' ) ")
                        ExecuteSQLQuery("SELECT   item_id  FROM   tbl_item  ORDER BY item_id DESC")
                        Dim ITEM_ID As Double = sqlDT.Rows(0)("item_id")
                        uploadImage(ITEM_ID)
                    Next
                    MessageBox.Show("Import sucessfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("No product(s) were found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            End If
        Catch ex As Exception
            MessageBox.Show(ex.ToString())
        End Try
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
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
End Class