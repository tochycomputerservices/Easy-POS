Public Class frmBusinessInfo
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

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub frmBusinessInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ExecuteSQLQuery("SELECT * FROM tbl_business")
        If sqlDT.Rows.Count > 0 Then
            txtBusinessName.Text = sqlDT.Rows(0)("business_name")
            txtAddress.Text = sqlDT.Rows(0)("address")
            txtContactPerson.Text = sqlDT.Rows(0)("contact_person")
            txtTelephone.Text = sqlDT.Rows(0)("telephone")
            txtFAX.Text = sqlDT.Rows(0)("fax")
            txtEmail.Text = sqlDT.Rows(0)("email")
            txtSlogan.Text = sqlDT.Rows(0)("business_slogan")
            txtVatRegNo.Text = sqlDT.Rows(0)("vat_reg_no")
        End If
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If txtBusinessName.Text = "" Then
            MsgBox("Required: Business Name", MsgBoxStyle.Information, "Information")
        ElseIf txtAddress.Text = "" Then
            MsgBox("Required: Address", MsgBoxStyle.Information, "Information")
        ElseIf txtTelephone.Text = "" Then
            MsgBox("Required: Telephone", MsgBoxStyle.Information, "Information")
        Else
            ExecuteSQLQuery("SELECT * FROM tbl_business")
            If sqlDT.Rows.Count > 0 Then
                ExecuteSQLQuery(" UPDATE tbl_business SET business_name='" + str_repl(txtBusinessName.Text) + "' ,address='" + str_repl(txtAddress.Text) + "',contact_person='" + str_repl(txtContactPerson.Text) + "',telephone='" + str_repl(txtTelephone.Text) + "',fax='" + str_repl(txtFAX.Text) + "',email='" + str_repl(txtEmail.Text) + "',business_slogan='" + str_repl(txtSlogan.Text) + "', vat_reg_no='" + str_repl(txtVatRegNo.Text) + "'  ")
                MsgBox("Record updated successful.", MsgBoxStyle.Information, "Information")
            Else
                ExecuteSQLQuery(" INSERT INTO tbl_business (business_name ,address,contact_person,telephone,fax,email,business_slogan, vat_reg_no)VALUES " & _
                                " ('" + str_repl(txtBusinessName.Text) + "', '" + str_repl(txtAddress.Text) + "', '" + str_repl(txtContactPerson.Text) + "', '" + str_repl(txtTelephone.Text) + "', '" + str_repl(txtFAX.Text) + "', '" + str_repl(txtEmail.Text) + "', '" + str_repl(txtSlogan.Text) + "', '" + str_repl(txtVatRegNo.Text) + "') ")
                MsgBox("New record has been added on database successfully. You’re good to go!", MsgBoxStyle.Information, "Information")
            End If
        End If

    End Sub
End Class

