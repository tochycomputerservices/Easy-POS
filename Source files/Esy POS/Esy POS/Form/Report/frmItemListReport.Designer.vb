<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmItemListReport
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
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnPreview = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.rbCategoryWise = New System.Windows.Forms.RadioButton()
        Me.rbAllItem = New System.Windows.Forms.RadioButton()
        Me.rbAllDeactive = New System.Windows.Forms.RadioButton()
        Me.rbAllActive = New System.Windows.Forms.RadioButton()
        Me.cmbCategory = New System.Windows.Forms.ComboBox()
        Me.gbSupplier = New System.Windows.Forms.GroupBox()
        Me.txtItemIdTo = New System.Windows.Forms.TextBox()
        Me.txtItemIdFrom = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbSupplier.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.SystemColors.GrayText
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(431, 32)
        Me.lblCaption.TabIndex = 14
        Me.lblCaption.Text = "LIST OF ITEM"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
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
        Me.btnClose.TabIndex = 15
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.GrayText
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 287)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(431, 32)
        Me.Label1.TabIndex = 16
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = Global.Esy_POS.My.Resources.Resources.Form_06_WF_smoke
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.PictureBox1.Location = New System.Drawing.Point(320, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(111, 107)
        Me.PictureBox1.TabIndex = 17
        Me.PictureBox1.TabStop = False
        '
        'btnPreview
        '
        Me.btnPreview.BackColor = System.Drawing.Color.White
        Me.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPreview.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPreview.ForeColor = System.Drawing.SystemColors.GrayText
        Me.btnPreview.Image = Global.Esy_POS.My.Resources.Resources.Print_WF
        Me.btnPreview.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPreview.Location = New System.Drawing.Point(41, 232)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(130, 29)
        Me.btnPreview.TabIndex = 42
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
        Me.btnExit.Location = New System.Drawing.Point(177, 232)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(112, 29)
        Me.btnExit.TabIndex = 41
        Me.btnExit.Text = "CLOSE"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'rbCategoryWise
        '
        Me.rbCategoryWise.AutoSize = True
        Me.rbCategoryWise.Checked = True
        Me.rbCategoryWise.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbCategoryWise.Location = New System.Drawing.Point(41, 49)
        Me.rbCategoryWise.Name = "rbCategoryWise"
        Me.rbCategoryWise.Size = New System.Drawing.Size(159, 18)
        Me.rbCategoryWise.TabIndex = 43
        Me.rbCategoryWise.TabStop = True
        Me.rbCategoryWise.Text = "CATEGORY WISE ITEM"
        Me.rbCategoryWise.UseVisualStyleBackColor = True
        '
        'rbAllItem
        '
        Me.rbAllItem.AutoSize = True
        Me.rbAllItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbAllItem.Location = New System.Drawing.Point(41, 103)
        Me.rbAllItem.Name = "rbAllItem"
        Me.rbAllItem.Size = New System.Drawing.Size(86, 18)
        Me.rbAllItem.TabIndex = 44
        Me.rbAllItem.Text = "ALL ITEM "
        Me.rbAllItem.UseVisualStyleBackColor = True
        '
        'rbAllDeactive
        '
        Me.rbAllDeactive.AutoSize = True
        Me.rbAllDeactive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbAllDeactive.Location = New System.Drawing.Point(41, 197)
        Me.rbAllDeactive.Name = "rbAllDeactive"
        Me.rbAllDeactive.Size = New System.Drawing.Size(146, 18)
        Me.rbAllDeactive.TabIndex = 46
        Me.rbAllDeactive.Text = "ALL DEACTIVE ITEM"
        Me.rbAllDeactive.UseVisualStyleBackColor = True
        '
        'rbAllActive
        '
        Me.rbAllActive.AutoSize = True
        Me.rbAllActive.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold)
        Me.rbAllActive.Location = New System.Drawing.Point(41, 170)
        Me.rbAllActive.Name = "rbAllActive"
        Me.rbAllActive.Size = New System.Drawing.Size(130, 18)
        Me.rbAllActive.TabIndex = 45
        Me.rbAllActive.Text = "ALL ACTIVE ITEM"
        Me.rbAllActive.UseVisualStyleBackColor = True
        '
        'cmbCategory
        '
        Me.cmbCategory.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.cmbCategory.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.cmbCategory.FormattingEnabled = True
        Me.cmbCategory.Location = New System.Drawing.Point(60, 70)
        Me.cmbCategory.Name = "cmbCategory"
        Me.cmbCategory.Size = New System.Drawing.Size(249, 24)
        Me.cmbCategory.TabIndex = 47
        '
        'gbSupplier
        '
        Me.gbSupplier.Controls.Add(Me.txtItemIdTo)
        Me.gbSupplier.Controls.Add(Me.txtItemIdFrom)
        Me.gbSupplier.Controls.Add(Me.Label4)
        Me.gbSupplier.Controls.Add(Me.Label5)
        Me.gbSupplier.Location = New System.Drawing.Point(60, 117)
        Me.gbSupplier.Name = "gbSupplier"
        Me.gbSupplier.Size = New System.Drawing.Size(249, 43)
        Me.gbSupplier.TabIndex = 48
        Me.gbSupplier.TabStop = False
        '
        'txtItemIdTo
        '
        Me.txtItemIdTo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemIdTo.Location = New System.Drawing.Point(185, 15)
        Me.txtItemIdTo.Name = "txtItemIdTo"
        Me.txtItemIdTo.Size = New System.Drawing.Size(55, 21)
        Me.txtItemIdTo.TabIndex = 46
        Me.txtItemIdTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtItemIdFrom
        '
        Me.txtItemIdFrom.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemIdFrom.Location = New System.Drawing.Point(101, 15)
        Me.txtItemIdFrom.Name = "txtItemIdFrom"
        Me.txtItemIdFrom.Size = New System.Drawing.Size(55, 21)
        Me.txtItemIdFrom.TabIndex = 45
        Me.txtItemIdFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(162, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 13)
        Me.Label4.TabIndex = 50
        Me.Label4.Text = "TO"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(99, 13)
        Me.Label5.TabIndex = 49
        Me.Label5.Text = "FROM ITEM ID NO."
        '
        'frmItemListReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(431, 289)
        Me.Controls.Add(Me.cmbCategory)
        Me.Controls.Add(Me.rbAllDeactive)
        Me.Controls.Add(Me.rbAllActive)
        Me.Controls.Add(Me.rbAllItem)
        Me.Controls.Add(Me.rbCategoryWise)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.gbSupplier)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmItemListReport"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "LIST OF ITEM"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbSupplier.ResumeLayout(False)
        Me.gbSupplier.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents rbCategoryWise As System.Windows.Forms.RadioButton
    Friend WithEvents rbAllItem As System.Windows.Forms.RadioButton
    Friend WithEvents rbAllDeactive As System.Windows.Forms.RadioButton
    Friend WithEvents rbAllActive As System.Windows.Forms.RadioButton
    Friend WithEvents cmbCategory As System.Windows.Forms.ComboBox
    Friend WithEvents gbSupplier As System.Windows.Forms.GroupBox
    Friend WithEvents txtItemIdTo As System.Windows.Forms.TextBox
    Friend WithEvents txtItemIdFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
