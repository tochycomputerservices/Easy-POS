<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListOfItem
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCount = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCriteria = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbAccording = New System.Windows.Forms.ComboBox()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.clm_item_id = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clm_category_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clm_item_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clm_barcode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clm_vat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clm_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.clm_btn = New System.Windows.Forms.DataGridViewButtonColumn()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(714, 32)
        Me.lblCaption.TabIndex = 8
        Me.lblCaption.Text = "List of item"
        Me.lblCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.SystemColors.HotTrack
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Navy
        Me.btnClose.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Image = Global.Esy_POS.My.Resources.Resources.Circle_Close___01
        Me.btnClose.Location = New System.Drawing.Point(683, 2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(29, 28)
        Me.btnClose.TabIndex = 9
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.Location = New System.Drawing.Point(0, 387)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(714, 32)
        Me.Label1.TabIndex = 10
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblCount
        '
        Me.lblCount.AutoSize = True
        Me.lblCount.Location = New System.Drawing.Point(8, 370)
        Me.lblCount.Name = "lblCount"
        Me.lblCount.Size = New System.Drawing.Size(43, 13)
        Me.lblCount.TabIndex = 502
        Me.lblCount.Text = "........."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(98, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 504
        Me.Label2.Text = "Criteria"
        '
        'txtCriteria
        '
        Me.txtCriteria.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCriteria.Location = New System.Drawing.Point(154, 41)
        Me.txtCriteria.Name = "txtCriteria"
        Me.txtCriteria.Size = New System.Drawing.Size(202, 23)
        Me.txtCriteria.TabIndex = 503
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(358, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 16)
        Me.Label3.TabIndex = 505
        Me.Label3.Text = "According to "
        '
        'cmbAccording
        '
        Me.cmbAccording.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccording.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbAccording.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.cmbAccording.FormattingEnabled = True
        Me.cmbAccording.Items.AddRange(New Object() {"Supplier Name", "Item ID", "Item Name", "Barcode"})
        Me.cmbAccording.Location = New System.Drawing.Point(438, 40)
        Me.cmbAccording.Name = "cmbAccording"
        Me.cmbAccording.Size = New System.Drawing.Size(215, 24)
        Me.cmbAccording.TabIndex = 506
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White
        Me.dgvItem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvItem.BackgroundColor = System.Drawing.Color.White
        Me.dgvItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dgvItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clm_item_id, Me.clm_category_name, Me.clm_item_name, Me.clm_barcode, Me.clm_vat, Me.clm_status, Me.clm_btn})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvItem.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvItem.EnableHeadersVisualStyles = False
        Me.dgvItem.GridColor = System.Drawing.Color.Gray
        Me.dgvItem.Location = New System.Drawing.Point(4, 70)
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvItem.RowHeadersVisible = False
        Me.dgvItem.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItem.Size = New System.Drawing.Size(705, 297)
        Me.dgvItem.TabIndex = 507
        '
        'clm_item_id
        '
        Me.clm_item_id.DataPropertyName = "item_id"
        Me.clm_item_id.HeaderText = "ID"
        Me.clm_item_id.Name = "clm_item_id"
        Me.clm_item_id.ReadOnly = True
        Me.clm_item_id.Visible = False
        '
        'clm_category_name
        '
        Me.clm_category_name.DataPropertyName = "category_name"
        Me.clm_category_name.HeaderText = "CATEGORY"
        Me.clm_category_name.Name = "clm_category_name"
        Me.clm_category_name.ReadOnly = True
        Me.clm_category_name.Width = 150
        '
        'clm_item_name
        '
        Me.clm_item_name.DataPropertyName = "item_name"
        Me.clm_item_name.HeaderText = "ITEM  NAME"
        Me.clm_item_name.Name = "clm_item_name"
        Me.clm_item_name.ReadOnly = True
        Me.clm_item_name.Width = 200
        '
        'clm_barcode
        '
        Me.clm_barcode.DataPropertyName = "barcode"
        Me.clm_barcode.HeaderText = "BARCODE"
        Me.clm_barcode.Name = "clm_barcode"
        Me.clm_barcode.ReadOnly = True
        Me.clm_barcode.Width = 130
        '
        'clm_vat
        '
        Me.clm_vat.DataPropertyName = "vat"
        Me.clm_vat.HeaderText = "VAT"
        Me.clm_vat.Name = "clm_vat"
        Me.clm_vat.ReadOnly = True
        Me.clm_vat.Width = 50
        '
        'clm_status
        '
        Me.clm_status.DataPropertyName = "status"
        Me.clm_status.HeaderText = "STATUS"
        Me.clm_status.Name = "clm_status"
        Me.clm_status.ReadOnly = True
        '
        'clm_btn
        '
        Me.clm_btn.HeaderText = ""
        Me.clm_btn.Name = "clm_btn"
        Me.clm_btn.ReadOnly = True
        Me.clm_btn.Text = "EDIT"
        Me.clm_btn.UseColumnTextForButtonValue = True
        Me.clm_btn.Width = 50
        '
        'frmListOfItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(714, 389)
        Me.Controls.Add(Me.cmbAccording)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCriteria)
        Me.Controls.Add(Me.lblCount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.dgvItem)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmListOfItem"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "List of item"
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCount As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCriteria As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbAccording As System.Windows.Forms.ComboBox
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvItem As System.Windows.Forms.DataGridView
    Friend WithEvents clm_item_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clm_category_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clm_item_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clm_barcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clm_vat As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clm_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clm_btn As System.Windows.Forms.DataGridViewButtonColumn
End Class
