<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFirstSale
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
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.lblCaption = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.txtCustomerID = New System.Windows.Forms.TextBox()
        Me.txtCustomer = New System.Windows.Forms.TextBox()
        Me.lstCustomer = New System.Windows.Forms.ListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtBuyerConsin1 = New System.Windows.Forms.TextBox()
        Me.txtBuyerConsin2 = New System.Windows.Forms.TextBox()
        Me.txtNarration = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.btnInvoiceList = New System.Windows.Forms.Button()
        Me.btnNewTrns = New System.Windows.Forms.Button()
        Me.txtInvoiceID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbDetails = New System.Windows.Forms.GroupBox()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.btnCollection = New System.Windows.Forms.Button()
        Me.lstItem = New System.Windows.Forms.ListBox()
        Me.btnPrintView = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnPayment = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.txtGlobalDisc = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnAddQuantity = New System.Windows.Forms.Button()
        Me.txtQuantity = New System.Windows.Forms.TextBox()
        Me.txtUOM = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtStockUnit = New System.Windows.Forms.TextBox()
        Me.txtItemID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtItemName = New System.Windows.Forms.TextBox()
        Me.dtgItem = New System.Windows.Forms.DataGridView()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gbMain.SuspendLayout()
        Me.gbDetails.SuspendLayout()
        CType(Me.dtgItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblCaption
        '
        Me.lblCaption.BackColor = System.Drawing.SystemColors.HotTrack
        Me.lblCaption.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaption.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.lblCaption.Location = New System.Drawing.Point(0, 0)
        Me.lblCaption.Name = "lblCaption"
        Me.lblCaption.Size = New System.Drawing.Size(606, 32)
        Me.lblCaption.TabIndex = 6
        Me.lblCaption.Text = "First Sale"
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
        Me.btnClose.Location = New System.Drawing.Point(576, 1)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(29, 28)
        Me.btnClose.TabIndex = 7
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'txtCustomerID
        '
        Me.txtCustomerID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomerID.Location = New System.Drawing.Point(18, 79)
        Me.txtCustomerID.Name = "txtCustomerID"
        Me.txtCustomerID.ReadOnly = True
        Me.txtCustomerID.Size = New System.Drawing.Size(42, 23)
        Me.txtCustomerID.TabIndex = 25
        '
        'txtCustomer
        '
        Me.txtCustomer.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCustomer.Location = New System.Drawing.Point(60, 79)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Size = New System.Drawing.Size(233, 23)
        Me.txtCustomer.TabIndex = 24
        '
        'lstCustomer
        '
        Me.lstCustomer.BackColor = System.Drawing.Color.White
        Me.lstCustomer.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.lstCustomer.FormattingEnabled = True
        Me.lstCustomer.ItemHeight = 16
        Me.lstCustomer.Location = New System.Drawing.Point(18, 101)
        Me.lstCustomer.Name = "lstCustomer"
        Me.lstCustomer.Size = New System.Drawing.Size(275, 68)
        Me.lstCustomer.TabIndex = 514
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label3.Location = New System.Drawing.Point(18, 60)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 515
        Me.Label3.Text = "Customer Name"
        '
        'txtBuyerConsin1
        '
        Me.txtBuyerConsin1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuyerConsin1.Location = New System.Drawing.Point(18, 124)
        Me.txtBuyerConsin1.Name = "txtBuyerConsin1"
        Me.txtBuyerConsin1.Size = New System.Drawing.Size(276, 23)
        Me.txtBuyerConsin1.TabIndex = 516
        '
        'txtBuyerConsin2
        '
        Me.txtBuyerConsin2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuyerConsin2.Location = New System.Drawing.Point(299, 34)
        Me.txtBuyerConsin2.Name = "txtBuyerConsin2"
        Me.txtBuyerConsin2.Size = New System.Drawing.Size(276, 23)
        Me.txtBuyerConsin2.TabIndex = 517
        '
        'txtNarration
        '
        Me.txtNarration.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNarration.Location = New System.Drawing.Point(299, 79)
        Me.txtNarration.Name = "txtNarration"
        Me.txtNarration.Size = New System.Drawing.Size(276, 23)
        Me.txtNarration.TabIndex = 518
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label2.Location = New System.Drawing.Point(18, 105)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(141, 16)
        Me.Label2.TabIndex = 519
        Me.Label2.Text = "Buyer Consignee Line 1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label4.Location = New System.Drawing.Point(299, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(141, 16)
        Me.Label4.TabIndex = 520
        Me.Label4.Text = "Buyer Consignee Line 2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label5.Location = New System.Drawing.Point(299, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 16)
        Me.Label5.TabIndex = 521
        Me.Label5.Text = "Narration"
        '
        'gbMain
        '
        Me.gbMain.Controls.Add(Me.btnInvoiceList)
        Me.gbMain.Controls.Add(Me.btnNewTrns)
        Me.gbMain.Controls.Add(Me.txtInvoiceID)
        Me.gbMain.Controls.Add(Me.lstCustomer)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.Label3)
        Me.gbMain.Controls.Add(Me.txtBuyerConsin2)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Controls.Add(Me.txtNarration)
        Me.gbMain.Controls.Add(Me.txtCustomerID)
        Me.gbMain.Controls.Add(Me.Label5)
        Me.gbMain.Controls.Add(Me.txtBuyerConsin1)
        Me.gbMain.Controls.Add(Me.Label4)
        Me.gbMain.Controls.Add(Me.txtCustomer)
        Me.gbMain.Location = New System.Drawing.Point(9, 29)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(587, 191)
        Me.gbMain.TabIndex = 522
        Me.gbMain.TabStop = False
        '
        'btnInvoiceList
        '
        Me.btnInvoiceList.BackColor = System.Drawing.Color.White
        Me.btnInvoiceList.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInvoiceList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvoiceList.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnInvoiceList.Image = Global.Esy_POS.My.Resources.Resources.To_Do_List_1_WF
        Me.btnInvoiceList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInvoiceList.Location = New System.Drawing.Point(447, 117)
        Me.btnInvoiceList.Name = "btnInvoiceList"
        Me.btnInvoiceList.Size = New System.Drawing.Size(128, 30)
        Me.btnInvoiceList.TabIndex = 524
        Me.btnInvoiceList.Text = "INVOICE LIST"
        Me.btnInvoiceList.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInvoiceList.UseVisualStyleBackColor = False
        '
        'btnNewTrns
        '
        Me.btnNewTrns.BackColor = System.Drawing.Color.White
        Me.btnNewTrns.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNewTrns.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNewTrns.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnNewTrns.Image = Global.Esy_POS.My.Resources.Resources.Save_01_WF_md
        Me.btnNewTrns.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnNewTrns.Location = New System.Drawing.Point(300, 117)
        Me.btnNewTrns.Name = "btnNewTrns"
        Me.btnNewTrns.Size = New System.Drawing.Size(141, 30)
        Me.btnNewTrns.TabIndex = 523
        Me.btnNewTrns.Text = "NEW SALES"
        Me.btnNewTrns.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNewTrns.UseVisualStyleBackColor = False
        '
        'txtInvoiceID
        '
        Me.txtInvoiceID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInvoiceID.Location = New System.Drawing.Point(18, 34)
        Me.txtInvoiceID.Name = "txtInvoiceID"
        Me.txtInvoiceID.ReadOnly = True
        Me.txtInvoiceID.Size = New System.Drawing.Size(141, 23)
        Me.txtInvoiceID.TabIndex = 523
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label1.Location = New System.Drawing.Point(18, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 16)
        Me.Label1.TabIndex = 524
        Me.Label1.Text = "INVOICE NO"
        '
        'gbDetails
        '
        Me.gbDetails.Controls.Add(Me.btnSave)
        Me.gbDetails.Controls.Add(Me.btnCollection)
        Me.gbDetails.Controls.Add(Me.lstItem)
        Me.gbDetails.Controls.Add(Me.btnPrintView)
        Me.gbDetails.Controls.Add(Me.btnPayment)
        Me.gbDetails.Controls.Add(Me.btnExit)
        Me.gbDetails.Controls.Add(Me.txtGlobalDisc)
        Me.gbDetails.Controls.Add(Me.Label8)
        Me.gbDetails.Controls.Add(Me.Label9)
        Me.gbDetails.Controls.Add(Me.btnAddQuantity)
        Me.gbDetails.Controls.Add(Me.txtQuantity)
        Me.gbDetails.Controls.Add(Me.txtUOM)
        Me.gbDetails.Controls.Add(Me.Label6)
        Me.gbDetails.Controls.Add(Me.txtStockUnit)
        Me.gbDetails.Controls.Add(Me.txtItemID)
        Me.gbDetails.Controls.Add(Me.Label7)
        Me.gbDetails.Controls.Add(Me.txtItemName)
        Me.gbDetails.Controls.Add(Me.dtgItem)
        Me.gbDetails.Controls.Add(Me.Label10)
        Me.gbDetails.Location = New System.Drawing.Point(9, 217)
        Me.gbDetails.Name = "gbDetails"
        Me.gbDetails.Size = New System.Drawing.Size(587, 244)
        Me.gbDetails.TabIndex = 523
        Me.gbDetails.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnSave.Image = Global.Esy_POS.My.Resources.Resources.Save_01_WF_md
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(18, 205)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(100, 30)
        Me.btnSave.TabIndex = 529
        Me.btnSave.Text = "SAVE"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'btnCollection
        '
        Me.btnCollection.BackColor = System.Drawing.Color.White
        Me.btnCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCollection.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCollection.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnCollection.Image = Global.Esy_POS.My.Resources.Resources.Pending_Invoice_WF
        Me.btnCollection.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCollection.Location = New System.Drawing.Point(242, 205)
        Me.btnCollection.Name = "btnCollection"
        Me.btnCollection.Size = New System.Drawing.Size(114, 30)
        Me.btnCollection.TabIndex = 528
        Me.btnCollection.Text = "DUE LIST"
        Me.btnCollection.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCollection.UseVisualStyleBackColor = False
        '
        'lstItem
        '
        Me.lstItem.BackColor = System.Drawing.Color.White
        Me.lstItem.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.lstItem.FormattingEnabled = True
        Me.lstItem.ItemHeight = 16
        Me.lstItem.Location = New System.Drawing.Point(93, 42)
        Me.lstItem.Name = "lstItem"
        Me.lstItem.Size = New System.Drawing.Size(275, 84)
        Me.lstItem.TabIndex = 520
        '
        'btnPrintView
        '
        Me.btnPrintView.BackColor = System.Drawing.Color.White
        Me.btnPrintView.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrintView.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintView.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnPrintView.Image = Global.Esy_POS.My.Resources.Resources.Printer_WF_fil
        Me.btnPrintView.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrintView.Location = New System.Drawing.Point(362, 205)
        Me.btnPrintView.Name = "btnPrintView"
        Me.btnPrintView.Size = New System.Drawing.Size(128, 30)
        Me.btnPrintView.TabIndex = 527
        Me.btnPrintView.Text = "PRINT PREVIEW"
        Me.btnPrintView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrintView.UseVisualStyleBackColor = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(402, 25)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 13)
        Me.Label10.TabIndex = 527
        Me.Label10.Text = "UNIT  DISC. (%)"
        '
        'btnPayment
        '
        Me.btnPayment.BackColor = System.Drawing.Color.White
        Me.btnPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPayment.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPayment.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnPayment.Image = Global.Esy_POS.My.Resources.Resources.Cheque_01
        Me.btnPayment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPayment.Location = New System.Drawing.Point(122, 205)
        Me.btnPayment.Name = "btnPayment"
        Me.btnPayment.Size = New System.Drawing.Size(114, 30)
        Me.btnPayment.TabIndex = 526
        Me.btnPayment.Text = "PAYMENT"
        Me.btnPayment.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPayment.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.BackColor = System.Drawing.Color.White
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.ForeColor = System.Drawing.SystemColors.HotTrack
        Me.btnExit.Image = Global.Esy_POS.My.Resources.Resources.Wrong_WF_md
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(496, 205)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(79, 30)
        Me.btnExit.TabIndex = 525
        Me.btnExit.Text = "CLOSE"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = False
        '
        'txtGlobalDisc
        '
        Me.txtGlobalDisc.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlobalDisc.Location = New System.Drawing.Point(489, 22)
        Me.txtGlobalDisc.Name = "txtGlobalDisc"
        Me.txtGlobalDisc.Size = New System.Drawing.Size(37, 21)
        Me.txtGlobalDisc.TabIndex = 526
        Me.txtGlobalDisc.Text = "0"
        Me.txtGlobalDisc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label8.Location = New System.Drawing.Point(246, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 16)
        Me.Label8.TabIndex = 525
        Me.Label8.Text = "UOM"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(383, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 524
        Me.Label9.Text = "QTY."
        '
        'btnAddQuantity
        '
        Me.btnAddQuantity.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddQuantity.Location = New System.Drawing.Point(532, 49)
        Me.btnAddQuantity.Name = "btnAddQuantity"
        Me.btnAddQuantity.Size = New System.Drawing.Size(43, 23)
        Me.btnAddQuantity.TabIndex = 523
        Me.btnAddQuantity.Text = "ADD"
        Me.btnAddQuantity.UseVisualStyleBackColor = True
        '
        'txtQuantity
        '
        Me.txtQuantity.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuantity.Location = New System.Drawing.Point(426, 50)
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 22)
        Me.txtQuantity.TabIndex = 522
        '
        'txtUOM
        '
        Me.txtUOM.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUOM.Location = New System.Drawing.Point(287, 49)
        Me.txtUOM.Name = "txtUOM"
        Me.txtUOM.ReadOnly = True
        Me.txtUOM.Size = New System.Drawing.Size(81, 23)
        Me.txtUOM.TabIndex = 519
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label6.Location = New System.Drawing.Point(6, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(94, 16)
        Me.Label6.TabIndex = 518
        Me.Label6.Text = "Stock Available"
        '
        'txtStockUnit
        '
        Me.txtStockUnit.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtStockUnit.Location = New System.Drawing.Point(135, 49)
        Me.txtStockUnit.Name = "txtStockUnit"
        Me.txtStockUnit.ReadOnly = True
        Me.txtStockUnit.Size = New System.Drawing.Size(105, 23)
        Me.txtStockUnit.TabIndex = 517
        '
        'txtItemID
        '
        Me.txtItemID.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemID.Location = New System.Drawing.Point(93, 20)
        Me.txtItemID.Name = "txtItemID"
        Me.txtItemID.ReadOnly = True
        Me.txtItemID.Size = New System.Drawing.Size(42, 23)
        Me.txtItemID.TabIndex = 516
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.75!)
        Me.Label7.Location = New System.Drawing.Point(6, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 16)
        Me.Label7.TabIndex = 515
        Me.Label7.Text = "Item Name"
        '
        'txtItemName
        '
        Me.txtItemName.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtItemName.Location = New System.Drawing.Point(135, 20)
        Me.txtItemName.Name = "txtItemName"
        Me.txtItemName.Size = New System.Drawing.Size(233, 23)
        Me.txtItemName.TabIndex = 514
        '
        'dtgItem
        '
        Me.dtgItem.AllowUserToAddRows = False
        Me.dtgItem.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.Color.White
        Me.dtgItem.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dtgItem.BackgroundColor = System.Drawing.Color.White
        Me.dtgItem.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        Me.dtgItem.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle12
        Me.dtgItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgItem.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column7, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6})
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle19.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle19.SelectionForeColor = System.Drawing.Color.White
        DataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgItem.DefaultCellStyle = DataGridViewCellStyle19
        Me.dtgItem.EnableHeadersVisualStyles = False
        Me.dtgItem.GridColor = System.Drawing.Color.Gray
        Me.dtgItem.Location = New System.Drawing.Point(18, 78)
        Me.dtgItem.Name = "dtgItem"
        Me.dtgItem.ReadOnly = True
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle20.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle20.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle20.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgItem.RowHeadersDefaultCellStyle = DataGridViewCellStyle20
        Me.dtgItem.RowHeadersVisible = False
        Me.dtgItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgItem.Size = New System.Drawing.Size(557, 121)
        Me.dtgItem.TabIndex = 499
        '
        'Column7
        '
        Me.Column7.DataPropertyName = "auto_id"
        DataGridViewCellStyle13.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column7.DefaultCellStyle = DataGridViewCellStyle13
        Me.Column7.HeaderText = "ID"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        Me.Column7.Visible = False
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "item_name"
        DataGridViewCellStyle14.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column1.DefaultCellStyle = DataGridViewCellStyle14
        Me.Column1.HeaderText = "ITEM "
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 240
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "quantity"
        DataGridViewCellStyle15.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column2.DefaultCellStyle = DataGridViewCellStyle15
        Me.Column2.HeaderText = "QTY"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 70
        '
        'Column3
        '
        Me.Column3.DataPropertyName = "price"
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.Format = "N2"
        DataGridViewCellStyle16.NullValue = Nothing
        Me.Column3.DefaultCellStyle = DataGridViewCellStyle16
        Me.Column3.HeaderText = "PRICE"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 80
        '
        'Column4
        '
        Me.Column4.DataPropertyName = "sub_total"
        DataGridViewCellStyle17.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle17.Format = "N2"
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle17
        Me.Column4.HeaderText = "TOTAL"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        '
        'Column6
        '
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle18.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle18
        Me.Column6.HeaderText = ""
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Text = "DEL"
        Me.Column6.UseColumnTextForButtonValue = True
        Me.Column6.Width = 40
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.HotTrack
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.Label11.Location = New System.Drawing.Point(-1, 464)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(606, 32)
        Me.Label11.TabIndex = 524
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'frmFirstSale
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(606, 467)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.lblCaption)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.gbDetails)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFirstSale"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "First Sale"
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.gbDetails.ResumeLayout(False)
        Me.gbDetails.PerformLayout()
        CType(Me.dtgItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lblCaption As System.Windows.Forms.Label
    Friend WithEvents txtCustomerID As System.Windows.Forms.TextBox
    Friend WithEvents txtCustomer As System.Windows.Forms.TextBox
    Friend WithEvents lstCustomer As System.Windows.Forms.ListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtBuyerConsin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtBuyerConsin2 As System.Windows.Forms.TextBox
    Friend WithEvents txtNarration As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents gbMain As System.Windows.Forms.GroupBox
    Friend WithEvents txtInvoiceID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInvoiceList As System.Windows.Forms.Button
    Friend WithEvents btnNewTrns As System.Windows.Forms.Button
    Friend WithEvents gbDetails As System.Windows.Forms.GroupBox
    Friend WithEvents dtgItem As System.Windows.Forms.DataGridView
    Friend WithEvents lstItem As System.Windows.Forms.ListBox
    Friend WithEvents txtUOM As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtStockUnit As System.Windows.Forms.TextBox
    Friend WithEvents txtItemID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtItemName As System.Windows.Forms.TextBox
    Friend WithEvents txtQuantity As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAddQuantity As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtGlobalDisc As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnCollection As System.Windows.Forms.Button
    Friend WithEvents btnPrintView As System.Windows.Forms.Button
    Friend WithEvents btnPayment As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewButtonColumn
End Class
