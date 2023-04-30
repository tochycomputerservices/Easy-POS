<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDefaultReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.rbCustomer = New System.Windows.Forms.RadioButton()
        Me.rbSupplier = New System.Windows.Forms.RadioButton()
        Me.rbEmployee = New System.Windows.Forms.RadioButton()
        Me.gbCustomer = New System.Windows.Forms.GroupBox()
        Me.txtCustIdFrom = New System.Windows.Forms.TextBox()
        Me.txtCustIdTo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbSupplier = New System.Windows.Forms.GroupBox()
        Me.txtSuppIdTo = New System.Windows.Forms.TextBox()
        Me.txtSuppIdFrom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbEmployee = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtEmpIdTo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtEmpIdFrom = New System.Windows.Forms.TextBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.gbCustomer.SuspendLayout()
        Me.gbSupplier.SuspendLayout()
        Me.gbEmployee.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(431, 32)
        Me.Label1.TabIndex = 18
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(431, 32)
        Me.lblCaption.TabIndex = 16
        Me.lblCaption.Text = "DEFAULT REPORT"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'rbCustomer
        '
        Me.rbCustomer.AutoSize = True
        Me.rbCustomer.Checked = True
        Me.rbCustomer.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCustomer.Location = New System.Drawing.Point(37, 43)
        Me.rbCustomer.Name = "rbCustomer"
        Me.rbCustomer.Size = New System.Drawing.Size(92, 18)
        Me.rbCustomer.TabIndex = 20
        Me.rbCustomer.TabStop = True
        Me.rbCustomer.Text = "CUSTOMER"
        Me.rbCustomer.UseVisualStyleBackColor = True
        '
        'rbSupplier
        '
        Me.rbSupplier.AutoSize = True
        Me.rbSupplier.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSupplier.Location = New System.Drawing.Point(37, 103)
        Me.rbSupplier.Name = "rbSupplier"
        Me.rbSupplier.Size = New System.Drawing.Size(85, 18)
        Me.rbSupplier.TabIndex = 21
        Me.rbSupplier.Text = "SUPPLIER"
        Me.rbSupplier.UseVisualStyleBackColor = True
        '
        'rbEmployee
        '
        Me.rbEmployee.AutoSize = True
        Me.rbEmployee.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbEmployee.Location = New System.Drawing.Point(37, 165)
        Me.rbEmployee.Name = "rbEmployee"
        Me.rbEmployee.Size = New System.Drawing.Size(88, 18)
        Me.rbEmployee.TabIndex = 22
        Me.rbEmployee.Text = "EMPLOYEE"
        Me.rbEmployee.UseVisualStyleBackColor = True
        '
        'gbCustomer
        '
        Me.gbCustomer.Controls.Add(Me.txtCustIdFrom)
        Me.gbCustomer.Controls.Add(Me.txtCustIdTo)
        Me.gbCustomer.Controls.Add(Me.Label2)
        Me.gbCustomer.Controls.Add(Me.Label3)
        Me.gbCustomer.Location = New System.Drawing.Point(34, 49)
        Me.gbCustomer.Name = "gbCustomer"
        Me.gbCustomer.Size = New System.Drawing.Size(249, 48)
        Me.gbCustomer.TabIndex = 23
        Me.gbCustomer.TabStop = False
        '
        'txtCustIdFrom
        '
        Me.txtCustIdFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustIdFrom.Location = New System.Drawing.Point(96, 18)
        Me.txtCustIdFrom.Name = "txtCustIdFrom"
        Me.txtCustIdFrom.Size = New System.Drawing.Size(55, 21)
        Me.txtCustIdFrom.TabIndex = 41
        Me.txtCustIdFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtCustIdTo
        '
        Me.txtCustIdTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustIdTo.Location = New System.Drawing.Point(185, 18)
        Me.txtCustIdTo.Name = "txtCustIdTo"
        Me.txtCustIdTo.Size = New System.Drawing.Size(55, 21)
        Me.txtCustIdTo.TabIndex = 42
        Me.txtCustIdTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "FROM ID NO."
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(157, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 13)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "TO"
        '
        'gbSupplier
        '
        Me.gbSupplier.Controls.Add(Me.txtSuppIdTo)
        Me.gbSupplier.Controls.Add(Me.txtSuppIdFrom)
        Me.gbSupplier.Controls.Add(Me.Label4)
        Me.gbSupplier.Controls.Add(Me.Label5)
        Me.gbSupplier.Location = New System.Drawing.Point(34, 110)
        Me.gbSupplier.Name = "gbSupplier"
        Me.gbSupplier.Size = New System.Drawing.Size(249, 48)
        Me.gbSupplier.TabIndex = 24
        Me.gbSupplier.TabStop = False
        '
        'txtSuppIdTo
        '
        Me.txtSuppIdTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuppIdTo.Location = New System.Drawing.Point(185, 18)
        Me.txtSuppIdTo.Name = "txtSuppIdTo"
        Me.txtSuppIdTo.Size = New System.Drawing.Size(55, 21)
        Me.txtSuppIdTo.TabIndex = 46
        Me.txtSuppIdTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSuppIdFrom
        '
        Me.txtSuppIdFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSuppIdFrom.Location = New System.Drawing.Point(96, 18)
        Me.txtSuppIdFrom.Name = "txtSuppIdFrom"
        Me.txtSuppIdFrom.Size = New System.Drawing.Size(55, 21)
        Me.txtSuppIdFrom.TabIndex = 45
        Me.txtSuppIdFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(157, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "TO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 22)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "FROM ID NO."
        '
        'gbEmployee
        '
        Me.gbEmployee.Controls.Add(Me.Label6)
        Me.gbEmployee.Controls.Add(Me.txtEmpIdTo)
        Me.gbEmployee.Controls.Add(Me.Label7)
        Me.gbEmployee.Controls.Add(Me.txtEmpIdFrom)
        Me.gbEmployee.Location = New System.Drawing.Point(34, 174)
        Me.gbEmployee.Name = "gbEmployee"
        Me.gbEmployee.Size = New System.Drawing.Size(249, 48)
        Me.gbEmployee.TabIndex = 25
        Me.gbEmployee.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(157, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 13)
        Me.Label6.TabIndex = 52
        Me.Label6.Text = "TO"
        '
        'txtEmpIdTo
        '
        Me.txtEmpIdTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpIdTo.Location = New System.Drawing.Point(185, 20)
        Me.txtEmpIdTo.Name = "txtEmpIdTo"
        Me.txtEmpIdTo.Size = New System.Drawing.Size(55, 21)
        Me.txtEmpIdTo.TabIndex = 48
        Me.txtEmpIdTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(14, 24)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "FROM ID NO."
        '
        'txtEmpIdFrom
        '
        Me.txtEmpIdFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpIdFrom.Location = New System.Drawing.Point(96, 20)
        Me.txtEmpIdFrom.Name = "txtEmpIdFrom"
        Me.txtEmpIdFrom.Size = New System.Drawing.Size(55, 21)
        Me.txtEmpIdFrom.TabIndex = 47
        Me.txtEmpIdFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.White
        Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreview.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnPreview.Image = Global.Esy_POS.My.Resources.Resources.Print_WF
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(35, 237)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(130, 29)
        Me.btnPreview.TabIndex = 40
        Me.btnPreview.Text = "PRINT PREVIEW"
        Me.btnPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPreview.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnExit.Image = Global.Esy_POS.My.Resources.Resources.Cross_Close
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(171, 237)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(112, 29)
        Me.btnExit.TabIndex = 39
        Me.btnExit.Text = "CLOSE"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.GrayText
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Image = Global.Esy_POS.My.Resources.Resources.Circle_Close___01
        Me.btnClose.Location = New System.Drawing.Point(400, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(29, 28)
        Me.btnClose.TabIndex = 17
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Esy_POS.My.Resources.Resources.Form_06_WF_smoke
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(320, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 107)
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'frmDefaultReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 289)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.rbEmployee)
        Me.Controls.Add(Me.rbSupplier)
        Me.Controls.Add(Me.rbCustomer)
        Me.Controls.Add(Me.gbEmployee)
        Me.Controls.Add(Me.gbSupplier)
        Me.Controls.Add(Me.gbCustomer)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.PictureBox1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDefaultReport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DEFAULT REPORT"
        Me.gbCustomer.ResumeLayout(False)
        Me.gbCustomer.PerformLayout()
        Me.gbSupplier.ResumeLayout(False)
        Me.gbSupplier.PerformLayout()
        Me.gbEmployee.ResumeLayout(False)
        Me.gbEmployee.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents rbCustomer As System.Windows.Forms.RadioButton
    Friend WithEvents rbSupplier As System.Windows.Forms.RadioButton
    Friend WithEvents rbEmployee As System.Windows.Forms.RadioButton
    Friend WithEvents gbCustomer As System.Windows.Forms.GroupBox
    Friend WithEvents gbSupplier As System.Windows.Forms.GroupBox
    Friend WithEvents gbEmployee As System.Windows.Forms.GroupBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents txtCustIdFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtCustIdTo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSuppIdTo As System.Windows.Forms.TextBox
    Friend WithEvents txtSuppIdFrom As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpIdTo As System.Windows.Forms.TextBox
    Friend WithEvents txtEmpIdFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
