Imports System.Windows.Forms
Public Class frmMDIParent
    Private m_ChildFormNumber As Integer
    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        Dim ChildForm As New System.Windows.Forms.Form
        ChildForm.MdiParent = Me
        m_ChildFormNumber += 1
        ChildForm.Text = "Window " & m_ChildFormNumber
        ChildForm.Show()
    End Sub
    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub
    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CloseAllToolStripMenuItem.Click
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub
    Private Sub btnBusinessinfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBusinessinfo.Click
        frmBusinessInfo.MdiParent = Me
        frmBusinessInfo.Show()
    End Sub

    Private Sub BUSINESSINFORMATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BUSINESSINFORMATIONToolStripMenuItem.Click
        frmBusinessInfo.MdiParent = Me
        frmBusinessInfo.Show()
    End Sub

    Private Sub btnCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustomer.Click
        frmCustomer.MdiParent = Me
        frmCustomer.Show()
    End Sub

    Private Sub CUSTOMERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CUSTOMERToolStripMenuItem.Click
        frmCustomer.MdiParent = Me
        frmCustomer.Show()
    End Sub

    Private Sub btnSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplier.Click
        frmSupplier.MdiParent = Me
        frmSupplier.Show()
    End Sub

    Private Sub SUPPLIERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SUPPLIERToolStripMenuItem.Click
        frmSupplier.MdiParent = Me
        frmSupplier.Show()
    End Sub

    Private Sub EMPLOYEEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EMPLOYEEToolStripMenuItem.Click
        frmEmployee.MdiParent = Me
        frmEmployee.Show()
    End Sub

    Private Sub btnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployee.Click
        frmEmployee.MdiParent = Me
        frmEmployee.Show()
    End Sub

    Private Sub PRODUCTINFORMATIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PRODUCTINFORMATIONToolStripMenuItem.Click
        frmItemInformation.MdiParent = Me
        frmItemInformation.Show()
    End Sub

    Private Sub btnItemInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItemInfo.Click
        frmItemInformation.MdiParent = Me
        frmItemInformation.Show()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        frmAbout.MdiParent = Me
        frmAbout.Show()
    End Sub

    Private Sub btnAbout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAbout.Click
        frmAbout.MdiParent = Me
        frmAbout.Show()
    End Sub

    Private Sub USERMANAGEMENTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERMANAGEMENTToolStripMenuItem.Click
        frmUserManagement.MdiParent = Me
        frmUserManagement.Show()
    End Sub

    Private Sub btnUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUser.Click
        frmUserManagement.MdiParent = Me
        frmUserManagement.Show()
    End Sub

    Private Sub btnChangePassword_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePassword.Click
        frmChangePassword.MdiParent = Me
        frmChangePassword.Show()
    End Sub

    Private Sub CHANGEPASSWORDToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANGEPASSWORDToolStripMenuItem.Click
        frmChangePassword.MdiParent = Me
        frmChangePassword.Show()
    End Sub

    Private Sub PERMISSIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PERMISSIONToolStripMenuItem.Click
        frmUserPermission.MdiParent = Me
        frmUserPermission.Show()
    End Sub

    Private Sub USERTRAILToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERTRAILToolStripMenuItem.Click
        frmUserTrail.MdiParent = Me
        frmUserTrail.Show()
    End Sub

    Private Sub USERLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles USERLISTToolStripMenuItem.Click
        frmUserList.MdiParent = Me
        frmUserList.Show()
    End Sub

    Private Sub POSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles POSToolStripMenuItem.Click
        frmPOS.MdiParent = Me
        frmPOS.Show()
    End Sub

    Private Sub btnPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOS.Click
        frmPOS.MdiParent = Me
        frmPOS.Show()
    End Sub

    Private Sub LISTOFITEMToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LISTOFITEMToolStripMenuItem.Click
        frmListOfItem.MdiParent = Me
        frmListOfItem.Show()
    End Sub

    Private Sub REORDERLEVELToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REORDERLEVELToolStripMenuItem.Click
        frmReOrder.MdiParent = Me
        frmReOrder.Show()
    End Sub

    Private Sub BADSTOCKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BADSTOCKToolStripMenuItem.Click
        frmBadStock.MdiParent = Me
        frmBadStock.Show()
    End Sub

    Private Sub btnBadStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBadStock.Click
        frmBadStock.MdiParent = Me
        frmBadStock.Show()
    End Sub

    Private Sub btnBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcode.Click
        frmBarcodePrint.MdiParent = Me
        frmBarcodePrint.Show()
    End Sub

    Private Sub BARCODEPRINTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BARCODEPRINTToolStripMenuItem.Click
        frmBarcodePrint.MdiParent = Me
        frmBarcodePrint.Show()
    End Sub

    Private Sub SCREENLOCKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SCREENLOCKToolStripMenuItem.Click
        Audit_Trail(xUser_ID, TimeOfDay, "Screen lock.")
        frmScreenLock.ShowDialog()
    End Sub

    Private Sub STOCKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles STOCKToolStripMenuItem.Click
        frmStock.MdiParent = Me
        frmStock.Show()
    End Sub

    Private Sub btnStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStock.Click
        frmStock.MdiParent = Me
        frmStock.Show()
    End Sub

    Private Sub OUTOFSTOCKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OUTOFSTOCKToolStripMenuItem.Click
        frmOutOfStock.MdiParent = Me
        frmOutOfStock.Show()
    End Sub

    Private Sub SalesReturnToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReturnToolStripMenuItem.Click
        frmSalesReturn.MdiParent = Me
        frmSalesReturn.Show()
    End Sub

    Private Sub btnSalesReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalesReturn.Click
        frmSalesReturn.MdiParent = Me
        frmSalesReturn.Show()
    End Sub

    Private Sub btnCollection_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCollection.Click
        frmCollection.MdiParent = Me
        frmCollection.Show()
    End Sub

    Private Sub COLLECTIONToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLLECTIONToolStripMenuItem.Click
        frmCollection.MdiParent = Me
        frmCollection.Show()
    End Sub

    Private Sub FIRSTSALEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FIRSTSALEToolStripMenuItem.Click
        frmFirstSale.MdiParent = Me
        frmFirstSale.Show()
    End Sub

    Private Sub frmMDIParent_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        Dim msg As String
        msg = "Log Out:  " & username & "  ?"
        msg = msg & Chr(10) & " "
        msg = msg & Chr(10) & "Are you sure want to quit?"
        If MsgBox(msg, MsgBoxStyle.Exclamation + MsgBoxStyle.YesNo, "Quit") = MsgBoxResult.No Then
            e.Cancel = 1
        Else
            sqlSTR = "UPDATE tbl_userlog SET Log_Out ='" & TimeOfDay & "' WHERE User_ID =" & xUser_ID & " AND Log_ID=" & LOGID
            ExecuteSQLQuery(sqlSTR)
            End
        End If
    End Sub

    Private Sub frmMDIParent_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadAdvisory(advCompany)
        lblVersion.Text = "Assembly version: " & My.Application.Info.Version.ToString
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub CHANGEUSERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHANGEUSERToolStripMenuItem.Click
        btnLogOut.PerformClick()
    End Sub

    Private Sub btnLogOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogOut.Click
        If MsgBox("Are you sure to log off .... ", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Confirm..") = MsgBoxResult.Yes Then
            Audit_Trail(xUser_ID, TimeOfDay, "log off ....")
            frmAuthentication.Visible = True
            Me.Hide()
        End If
    End Sub

    Private Sub DEFAULTREPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEFAULTREPORTToolStripMenuItem.Click
        frmDefaultReport.MdiParent = Me
        frmDefaultReport.Show()
    End Sub

    Private Sub ITEMLISTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMLISTToolStripMenuItem.Click
        frmItemListReport.MdiParent = Me
        frmItemListReport.Show()
    End Sub

    Private Sub BADSTOCKToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BADSTOCKToolStripMenuItem1.Click
        frmBadStockReport.MdiParent = Me
        frmBadStockReport.Show()
    End Sub

    Private Sub DATEWISESALESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DATEWISESALESToolStripMenuItem.Click
        frmDateWiseSalesReport.MdiParent = Me
        frmDateWiseSalesReport.Show()
    End Sub

    Private Sub DATEWISESALESRETURNToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DATEWISESALESRETURNToolStripMenuItem.Click
        frmDateWiseSalesReturnReport.MdiParent = Me
        frmDateWiseSalesReturnReport.Show()
    End Sub

    Private Sub COLLECTIONDUEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles COLLECTIONDUEToolStripMenuItem.Click
        frmCollectionDueReport.MdiParent = Me
        frmCollectionDueReport.Show()
    End Sub

    Private Sub EXITToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXITToolStripMenuItem.Click
        btnExit.PerformClick()
    End Sub

    Private Sub SALESCHARTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SALESCHARTToolStripMenuItem.Click
        frmSalesChart.MdiParent = Me
        frmSalesChart.Show()
    End Sub

    Private Sub ITEMWISESALESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITEMWISESALESToolStripMenuItem.Click
        frmItemWiseSales.MdiParent = Me
        frmItemWiseSales.Show()
    End Sub

    Private Sub DATABACKUPToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DATABACKUPToolStripMenuItem.Click
        frmDataBackup.MdiParent = Me
        frmDataBackup.Show()
    End Sub

    Private Sub RESETDATABASEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RESETDATABASEToolStripMenuItem.Click
        frmResetDB.MdiParent = Me
        frmResetDB.Show()
    End Sub

    Private Sub btnIncome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncome.Click
        frmIncome.MdiParent = Me
        frmIncome.Show()
    End Sub

    Private Sub INCOMEToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INCOMEToolStripMenuItem.Click
        frmIncome.MdiParent = Me
        frmIncome.Show()
    End Sub

    Private Sub CASHTRANSFERToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHTRANSFERToolStripMenuItem.Click
        frmCashTransfer.MdiParent = Me
        frmCashTransfer.Show()
    End Sub

    Private Sub CHARTOFACCOUNTSToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHARTOFACCOUNTSToolStripMenuItem.Click
        frmChartOfAccounts.MdiParent = Me
        frmChartOfAccounts.Show()
    End Sub

    Private Sub btnExpenses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExpenses.Click
        frmExpenses.MdiParent = Me
        frmExpenses.Show()
    End Sub

    Private Sub EXPENSESToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EXPENSESToolStripMenuItem.Click
        frmExpenses.MdiParent = Me
        frmExpenses.Show()
    End Sub

    Private Sub CHARTOFACCOUNTSToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CHARTOFACCOUNTSToolStripMenuItem1.Click
        frmChartOfAccountsReport.MdiParent = Me
        frmChartOfAccountsReport.Show()
    End Sub

    Private Sub TRANSACTIONREPORTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TRANSACTIONREPORTToolStripMenuItem.Click
        frmTransactionReport.MdiParent = Me
        frmTransactionReport.Show()
    End Sub

    Private Sub CASHBANKSTATEMENTToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CASHBANKSTATEMENTToolStripMenuItem.Click
        frmCashBankStatementReport.MdiParent = Me
        frmCashBankStatementReport.Show()
    End Sub

    Private Sub LEDGERBOOKToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LEDGERBOOKToolStripMenuItem.Click
        frmLedgerBook.MdiParent = Me
        frmLedgerBook.Show()
    End Sub

    Private Sub IMPORTITEMToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IMPORTITEMToolStripMenuItem.Click
        frmImportItems.MdiParent = Me
        frmImportItems.Show()
    End Sub
End Class
