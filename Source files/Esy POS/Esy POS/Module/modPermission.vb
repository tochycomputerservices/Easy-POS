Module modPermission
    Public Sub LoadUserPermission(ByVal ProgressBar1 As ProgressBar)
        ProgressBar1.Visible = True
        ProgressBar1.Value = 20
        '-------ACTION-CODE- 101
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 101)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.BUSINESSINFORMATIONToolStripMenuItem.Enabled = True
            frmMDIParent.btnBusinessinfo.Enabled = True
        Else
            frmMDIParent.BUSINESSINFORMATIONToolStripMenuItem.Enabled = False
            frmMDIParent.btnBusinessinfo.Enabled = False
        End If
        '-------ACTION-CODE- 102
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 102)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.CUSTOMERToolStripMenuItem.Enabled = True
            frmMDIParent.btnCustomer.Enabled = True
        Else
            frmMDIParent.CUSTOMERToolStripMenuItem.Enabled = False
            frmMDIParent.btnCustomer.Enabled = False
        End If
        '-------ACTION-CODE- 103
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 103)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.SUPPLIERToolStripMenuItem.Enabled = True
            frmMDIParent.btnSupplier.Enabled = True
        Else
            frmMDIParent.SUPPLIERToolStripMenuItem.Enabled = False
            frmMDIParent.btnSupplier.Enabled = False
        End If
        '-------ACTION-CODE- 104
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 104)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.EMPLOYEEToolStripMenuItem.Enabled = True
            frmMDIParent.btnEmployee.Enabled = True
        Else
            frmMDIParent.EMPLOYEEToolStripMenuItem.Enabled = False
            frmMDIParent.btnEmployee.Enabled = False
        End If
        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 201
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 201)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.PRODUCTINFORMATIONToolStripMenuItem.Enabled = True
            frmMDIParent.btnItemInfo.Enabled = True
        Else
            frmMDIParent.PRODUCTINFORMATIONToolStripMenuItem.Enabled = False
            frmMDIParent.btnItemInfo.Enabled = False
        End If
        '-------ACTION-CODE- 202
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 202)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.LISTOFITEMToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.LISTOFITEMToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 203
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 203)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.STOCKToolStripMenuItem.Enabled = True
            frmMDIParent.btnStock.Enabled = True
        Else
            frmMDIParent.STOCKToolStripMenuItem.Enabled = False
            frmMDIParent.btnStock.Enabled = False
        End If
        '-------ACTION-CODE- 204
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 204)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.OUTOFSTOCKToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.OUTOFSTOCKToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 205
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 205)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.REORDERLEVELToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.REORDERLEVELToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 206
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 206)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.BADSTOCKToolStripMenuItem.Enabled = True
            frmMDIParent.btnBadStock.Enabled = True
        Else
            frmMDIParent.BADSTOCKToolStripMenuItem.Enabled = False
            frmMDIParent.btnBadStock.Enabled = False
        End If
        '-------ACTION-CODE- 207
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 207)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.btnBarcode.Enabled = True
            frmMDIParent.BARCODEPRINTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.btnBarcode.Enabled = False
            frmMDIParent.BARCODEPRINTToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 208
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 208)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.IMPORTITEMToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.IMPORTITEMToolStripMenuItem.Enabled = False
        End If
        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 301
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 301)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.FIRSTSALEToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.FIRSTSALEToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 302
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 302)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.POSToolStripMenuItem.Enabled = True
            frmMDIParent.btnPOS.Enabled = True
        Else
            frmMDIParent.POSToolStripMenuItem.Enabled = False
            frmMDIParent.btnPOS.Enabled = False
        End If
        '-------ACTION-CODE- 303
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 303)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.SalesReturnToolStripMenuItem.Enabled = True
            frmMDIParent.btnSalesReturn.Enabled = True
        Else
            frmMDIParent.btnSalesReturn.Enabled = False
            frmMDIParent.SalesReturnToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 304
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 304)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.btnCollection.Enabled = True
            frmMDIParent.COLLECTIONToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.btnCollection.Enabled = False
            frmMDIParent.COLLECTIONToolStripMenuItem.Enabled = False
        End If

        '-------ACTION-CODE- 305
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 305)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.SALESCHARTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.SALESCHARTToolStripMenuItem.Enabled = False
        End If


        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 401
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 401)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.btnUser.Enabled = True
            frmMDIParent.USERMANAGEMENTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.btnUser.Enabled = False
            frmMDIParent.USERMANAGEMENTToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 402
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 402)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.USERLISTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.USERLISTToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 403
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 403)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.USERTRAILToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.USERTRAILToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 404
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 404)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.PERMISSIONToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.PERMISSIONToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 405
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 405)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.btnChangePassword.Enabled = True
            frmMDIParent.CHANGEPASSWORDToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.btnChangePassword.Enabled = False
            frmMDIParent.CHANGEPASSWORDToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 406
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 406)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.DATABACKUPToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.DATABACKUPToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 407
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 407)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.RESETDATABASEToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.RESETDATABASEToolStripMenuItem.Enabled = False
        End If
        ProgressBar1.Value = ProgressBar1.Value + 20
        '-------ACTION-CODE- 501
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 501)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.DEFAULTREPORTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.DEFAULTREPORTToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 502
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 502)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.ITEMLISTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.ITEMLISTToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 503
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 503)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.BADSTOCKToolStripMenuItem1.Enabled = True
        Else
            frmMDIParent.BADSTOCKToolStripMenuItem1.Enabled = False
        End If
        '-------ACTION-CODE- 504
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 504)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.DATEWISESALESToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.DATEWISESALESToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 505
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 505)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.DATEWISESALESRETURNToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.DATEWISESALESRETURNToolStripMenuItem.Enabled = False
        End If
        '-------ACTION-CODE- 506
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 506)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.COLLECTIONDUEToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.COLLECTIONDUEToolStripMenuItem.Enabled = False
        End If

        '-------ACTION-CODE- 507
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 507)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.ITEMWISESALESToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.ITEMWISESALESToolStripMenuItem.Enabled = False
        End If

        '-------ACTION-CODE- 508
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 508)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.CHARTOFACCOUNTSToolStripMenuItem1.Enabled = True
        Else
            frmMDIParent.CHARTOFACCOUNTSToolStripMenuItem1.Enabled = False
        End If

        '-------ACTION-CODE- 509
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 509)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.TRANSACTIONREPORTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.TRANSACTIONREPORTToolStripMenuItem.Enabled = False
        End If

        '-------ACTION-CODE- 510
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 510)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.CASHBANKSTATEMENTToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.CASHBANKSTATEMENTToolStripMenuItem.Enabled = False
        End If

        '-------ACTION-CODE- 511
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 511)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.LEDGERBOOKToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.LEDGERBOOKToolStripMenuItem.Enabled = False
        End If

        '-------ACTION-CODE- 601
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 601)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.CHARTOFACCOUNTSToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.CHARTOFACCOUNTSToolStripMenuItem.Enabled = False
        End If

        '-------ACTION-CODE- 602
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 602)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.INCOMEToolStripMenuItem.Enabled = True
            frmMDIParent.btnIncome.Enabled = True
        Else
            frmMDIParent.INCOMEToolStripMenuItem.Enabled = False
            frmMDIParent.btnIncome.Enabled = False
        End If

        '-------ACTION-CODE- 603
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 603)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.EXPENSESToolStripMenuItem.Enabled = True
            frmMDIParent.btnExpenses.Enabled = True
        Else
            frmMDIParent.EXPENSESToolStripMenuItem.Enabled = False
            frmMDIParent.btnExpenses.Enabled = False
        End If

        '-------ACTION-CODE- 604
        ExecuteSQLQuery("SELECT  User_ID, AccessKey FROM    tbl_permission  WHERE (User_ID = " & xUser_ID & ") AND (AccessKey = 604)")
        If sqlDT.Rows.Count > 0 Then
            frmMDIParent.CASHTRANSFERToolStripMenuItem.Enabled = True
        Else
            frmMDIParent.CASHTRANSFERToolStripMenuItem.Enabled = False
        End If

        ProgressBar1.Visible = False
    End Sub
End Module
