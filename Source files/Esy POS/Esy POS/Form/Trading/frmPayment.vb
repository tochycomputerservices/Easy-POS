Public Class frmPayment
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

    Private Sub frmPayment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ExecuteSQLQuery("SELECT    *  FROM            tbl_sale_details  WHERE        (SALES_ID = " & txtInvoiceID.Text & ")")
        If sqlDT.Rows.Count > 0 Then
            ExecuteSQLQuery("SELECT        SUM(sub_total) AS Expr1  FROM            tbl_sale_details  WHERE        (SALES_ID = " & txtInvoiceID.Text & ")")
            txtTotal.Text = Math.Round(sqlDT.Rows(0)("Expr1"), 2)
        Else
            txtTotal.Text = "0"
        End If

        ExecuteSQLQuery("SELECT  *   FROM   tbl_sale  WHERE        (SALES_ID = " & txtInvoiceID.Text & ") AND (NOT (term_of_payment = 'DUE'))")
        If sqlDT.Rows.Count > 0 Then
            cmbType.Text = sqlDT.Rows(0)("term_of_payment")
            txtDiscount.Text = Math.Round(sqlDT.Rows(0)("grand_disc"), 2)
        Else
            txtDiscount.Text = ""
        End If
        txtPayment.Text = "0"
        txtDiscountPercent.Text = "0"
        cmbType.Select()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cmbType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbType.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            txtDiscount.Select()
        End If
    End Sub

    Private Sub txtDiscount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDiscount.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If Not IsNumeric(txtDiscount.Text) Then
                txtDiscount.Text = "0"
                txtPayment.Select()
            Else
                txtGtotal.Text = Val(txtTotal.Text) - Val(txtDiscount.Text)
                txtPayment.Select()
            End If
        End If
    End Sub

    Private Sub txtPayment_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPayment.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
            If Not IsNumeric(txtPayment.Text) Then
                txtPayment.Text = "0"
                btnSave.Select()
            ElseIf Val(txtPayment.Text) <= 0 Then
                txtChange.Text = "0"
                btnSave.Select()
            Else
                txtChange.Text = Val(txtPayment.Text) - Val(txtGtotal.Text)
                btnSave.Select()
            End If
        End If
    End Sub


    Private Sub loadCalculation()

    End Sub

    Private Sub txtDiscount_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscount.TextChanged
        If Not IsNumeric(txtDiscount.Text) Then
            txtDiscount.Text = "0"
        Else
            txtGtotal.Text = Val(txtTotal.Text) - Val(txtDiscount.Text)
        End If
    End Sub

    Private Sub txtPayment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPayment.TextChanged
        If IsNumeric(txtPayment.Text) Then
            txtChange.Text = Val(txtPayment.Text) - Val(txtGtotal.Text)
        ElseIf Val(txtPayment.Text) <= 0 Then
            txtChange.Text = Val(txtPayment.Text) - Val(txtGtotal.Text)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbType.Text = "" Then
            MsgBox("Required: TERM OF PAYMENT", MsgBoxStyle.Information, "Information")
        ElseIf Not IsNumeric(txtPayment.Text) Then
            MsgBox("Required: Payment", MsgBoxStyle.Information, "Information")
        ElseIf Val(txtPayment.Text) <= 0 Then
            MsgBox("Required: Payment", MsgBoxStyle.Information, "Information")
        Else
            If Val(txtGtotal.Text) <= Val(txtPayment.Text) Then
                ExecuteSQLQuery(" UPDATE  tbl_sale SET  grand_disc=" & str_repl(txtDiscount.Text) & ", collection_full='Y', term_of_payment='" + cmbType.Text + "', Change='" & txtChange.Text & "', Payment='" & txtPayment.Text & "'  WHERE        (SALES_ID = " & txtInvoiceID.Text & ")")
                MsgBox("Payment Completed.", MsgBoxStyle.Information, "Information")
                If MsgBox("Are you sure to print preview INV. NO#  " & txtInvoiceID.Text, MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
                    LoadCompanyDetails()
                    LoadPOSRecipt(txtInvoiceID.Text)
                End If
                Me.Close()
            Else
                MsgBox("Sorry! Payment not acceptable.", MsgBoxStyle.Critical, "Sorry!")
            End If
        End If
    End Sub

    Private Sub txtDiscountPercent_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscountPercent.TextChanged
        If txtDiscountPercent.Text = "" Then
            txtDiscount.Text = "0"
        ElseIf txtDiscountPercent.Text = "0" Then
            txtDiscount.Text = "0"
        ElseIf IsNumeric(txtDiscountPercent.Text) Then
            txtDiscount.Text = Math.Round(Val(txtTotal.Text) * Val(num_fltr(txtDiscountPercent.Text)) / 100, 2)
        Else
            txtDiscount.Text = "0"
        End If
    End Sub
End Class