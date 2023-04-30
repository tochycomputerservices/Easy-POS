Imports System.Drawing
Imports System.Windows.Forms.DataVisualization.Charting
Public Class frmSalesChart
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

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Chart1.Series(0).Points.Clear()

        ExecuteSQLQuery(" SELECT   tbl_sale_details.sub_total, tbl_sale.Sales_Date  FROM   tbl_sale INNER JOIN  tbl_sale_details ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID " & _
                        " WHERE        (tbl_sale.Sales_Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "' AND tbl_sale.Sales_Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
        If sqlDT.Rows.Count > 0 Then

            ExecuteSQLQuery(" SELECT        SUM(tbl_sale_details.sub_total) AS Expr1, tbl_sale.Sales_Date  FROM            tbl_sale " & _
                            "  INNER JOIN  tbl_sale_details ON tbl_sale.SALES_ID = tbl_sale_details.SALES_ID  GROUP BY tbl_sale.Sales_Date " & _
                            " HAVING        (tbl_sale.Sales_Date >= '" & Format(dtpFrom.Value, "MM/dd/yyyy") & "') AND (tbl_sale.Sales_Date <= '" & Format(dtpTo.Value, "MM/dd/yyyy") & "') ")
            For i = 0 To sqlDT.Rows.Count - 1
                Chart1.Series("Date").Points.AddXY(sqlDT.Rows(i)("Sales_Date"), Math.Round(sqlDT.Rows(i)("Expr1"), 2))
            Next

        Else
            MsgBox("Sales not found.", MsgBoxStyle.Information, "Information")
        End If
    End Sub
    Private Sub LinkLabelExport_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabelExport.LinkClicked
        Dim saveFileDialog1 As New SaveFileDialog()
        saveFileDialog1.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg"
        saveFileDialog1.FilterIndex = 2
        saveFileDialog1.RestoreDirectory = True
        If saveFileDialog1.ShowDialog() = DialogResult.OK Then
            Dim format As ChartImageFormat = ChartImageFormat.Bmp
            If saveFileDialog1.FileName.EndsWith("bmp") Then
                format = ChartImageFormat.Bmp
            Else
                If saveFileDialog1.FileName.EndsWith("jpg") Then
                    format = ChartImageFormat.Jpeg
                End If
            End If
            Chart1.SaveImage(saveFileDialog1.FileName, format)
        End If
    End Sub
End Class