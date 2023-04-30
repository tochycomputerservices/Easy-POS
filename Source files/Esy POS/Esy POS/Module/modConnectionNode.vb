Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports CrystalDecisions.ReportSource
Imports CrystalDecisions.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Drawing.Drawing2D
Module modConnectionNode
    'Crystal Report Parameter
    Public crpSharedDate As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpSharedBalance As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpBusinessName As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpBusinessAddress As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpTelephone As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpFax As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpEmail As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpTINN As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public crpSlogan As New CrystalDecisions.Shared.ParameterDiscreteValue
    Public sqlDT As New DataTable
    Public sqlDTx As New DataTable
    Public CnString As String
    Public LOGID As Integer
    Public sqlSTR As String
    Public username As String
    Public EMP_ID As Double
    Public EMP_NAME As String
    Public xUserPassword As String
    Public xUser_ID As Integer
    Public AUTO_BARCODE As Double
    Public Function checkServer() As Boolean
        CnString = "Data Source=|DataDirectory|\dbEsyPOS.sdf;Persist Security Info=True; Password=CQ25dbEsyPOS"
        Try
            Dim sqlCon As New SqlCeConnection
            sqlCon.ConnectionString = CnString
            sqlCon.Open()
            checkServer = True
            sqlCon.Close()
        Catch ex As Exception
            checkServer = False
            MsgBox("Error : " & ex.Message)
            End
        End Try
    End Function
    Public Sub LoadCompanyDetails()
        ExecuteSQLQuery("SELECT * FROM tbl_business")
        If sqlDT.Rows.Count > 0 Then
            crpBusinessName.Value = sqlDT.Rows(0)("business_name")
            crpBusinessAddress.Value = "Address: " & sqlDT.Rows(0)("address")
            crpTelephone.Value = "Telephone: " & sqlDT.Rows(0)("telephone")
            crpFax.Value = "FAX: " & sqlDT.Rows(0)("fax")
            crpEmail.Value = "Email: " & sqlDT.Rows(0)("email")
            crpTINN.Value = "VAT REG.: " & sqlDT.Rows(0)("vat_reg_no")
            crpSlogan.Value = sqlDT.Rows(0)("business_slogan")
        Else
            crpBusinessName.Value = "Business Name"
            crpBusinessAddress.Value = "Address: "
            crpTelephone.Value = "Telephone: "
            crpFax.Value = "FAX: "
            crpEmail.Value = "Email: "
            crpTINN.Value = " "
            crpSlogan.Value = " "
        End If
    End Sub
    Public Sub LoadAdvisory(ByVal lbl As Label)
        ExecuteSQLQuery("SELECT * FROM tbl_business")
        If sqlDT.Rows.Count > 0 Then
            lbl.Text = sqlDT.Rows(0)("business_name")
            crpBusinessName.Value = sqlDT.Rows(0)("business_name")
        Else
            lbl.Text = ""
            crpBusinessName.Value = "Business Name"
        End If
    End Sub
    Public Function str_repl(ByVal str As String)
        Return Replace(Replace(Replace(str, "'", ""), ",", ","), "`", "")
    End Function
    Public Function ExecuteSQLQuery(ByVal SQLQuery As String) As DataTable
        Try
            Dim sqlCon As New SqlCeConnection(CnString)
            Dim sqlDA As New SqlCeDataAdapter(SQLQuery, sqlCon)
            Dim sqlCB As New SqlCeCommandBuilder(sqlDA)
            sqlDT.Reset() ' refresh 
            sqlDA.Fill(sqlDT)
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        End Try
        Return sqlDT
    End Function
    Public Sub FillDataGrid(ByVal sql As String, ByVal dgv As DataGridView)
        Dim conn As SqlCeConnection = New SqlCeConnection(CnString)
        Try
            conn.Open()
            Dim cmd As SqlCeCommand = New SqlCeCommand(sql, conn)
            Dim adp As New SqlCeDataAdapter
            Dim dt As New DataTable
            adp.SelectCommand = cmd
            adp.Fill(dt)
            dgv.DataSource = dt
            adp.Dispose()
            cmd.Dispose()
        Catch ex As Exception
            MsgBox("Error:" & ex.ToString)
        Finally
            conn.Close()
        End Try
    End Sub

    Public Sub FillDataComboBox(ByVal sql As String, ByVal Value_Member As String, ByVal Display_Member As String, ByVal combo As ComboBox)
        Dim dt As DataTable = New DataTable()
        Using connection = New SqlCeConnection(CnString)
            Using cmd = New SqlCeCommand(sql, connection)
                connection.Open()
                Try
                    dt.Load(cmd.ExecuteReader())
                Catch e As SqlCeException
                    MessageBox.Show(" Error : " & e.ToString())
                End Try
            End Using
        End Using
        combo.DataSource = dt
        combo.ValueMember = Value_Member
        combo.DisplayMember = Display_Member
    End Sub

    Public Sub FillListBox(ByVal sql As String, ByVal lstbox As ListBox)
        Dim conn As New SqlCeConnection(CnString)
        lstbox.Items.Clear()
        Try
            conn.Open()
            Dim DT As New DataTable
            Dim DS As New DataSet
            DS.Tables.Add(DT)
            Dim DA As New SqlCeDataAdapter(sql, conn)
            DA.Fill(DT)
            Dim r As DataRow
            For Each r In DT.Rows
                lstbox.Items.Add(r.Item(0).ToString & " # " & r.Item(1).ToString)
            Next
        Catch ex As Exception
            MsgBox("Error : " & ex.Message)
        Finally
            conn.Close()
        End Try
    End Sub
    Public Sub Audit_Trail(ByVal user_ID As Integer, ByVal xtime As String, ByVal xAction As String)
        sqlSTR = "INSERT INTO tbl_usertrail (User_ID, Action, Date, Timex, log_ID) " & _
                 "VALUES (" & user_ID & ", " _
                            & "'" & xAction & "', " _
                            & "'" & Format(Now, "MM/dd/yyyy") & "', " _
                            & "'" & xtime & "', " _
                            & LOGID & ")"
        ExecuteSQLQuery(sqlSTR)
    End Sub
    Public Sub CreateBarcode()
        ExecuteSQLQuery("SELECT barcode FROM Setting")
        If Not sqlDT.Rows.Count > 0 Then
            ExecuteSQLQuery(" INSERT INTO  Setting (barcode) VALUES (10000000)")
        End If
        'get barcode 
        ExecuteSQLQuery("SELECT barcode FROM Setting")
        If sqlDT.Rows.Count > 0 Then
            AUTO_BARCODE = sqlDT.Rows(0)("barcode") + 1
            ExecuteSQLQuery(" UPDATE Setting SET  barcode='" & AUTO_BARCODE & "'  ")
        End If
    End Sub
    Public Function ResizeImage(ByVal image As Image, ByVal size As Size, Optional ByVal preserveAspectRatio As Boolean = True) As Image
        Try
            Dim Drawing2DWidth As Integer
            Dim Drawing2DHeight As Integer
            If preserveAspectRatio Then
                Dim Original_Dimension As Integer = image.Width
                Dim originalHeight As Integer = image.Height
                Dim percentWidth As Single = CSng(size.Width) / CSng(Original_Dimension)
                Dim percentHeight As Single = CSng(size.Height) / CSng(originalHeight)
                Dim percent As Single = IIf(percentHeight < percentWidth, percentHeight, percentWidth)
                Drawing2DWidth = CInt(Original_Dimension * percent)
                Drawing2DHeight = CInt(originalHeight * percent)
            Else
                Drawing2DWidth = size.Width
                Drawing2DHeight = size.Height
            End If
            Dim newImage As Image = New Bitmap(Drawing2DWidth, Drawing2DHeight)
            Using graphicsHandle As Graphics = Graphics.FromImage(newImage)
                graphicsHandle.InterpolationMode = InterpolationMode.HighQualityBicubic
                graphicsHandle.DrawImage(image, 0, 0, Drawing2DWidth, Drawing2DHeight)
            End Using
            Return newImage
        Catch ex As Exception
            Return image
        End Try
    End Function
    Public Function num_fltr(ByVal value As String)
        If Not IsNumeric(value) Then
            Return 0
        Else
            Return value
        End If
    End Function
    Public Sub InsertDefaultData()
        '*********CAUTION:  PLEASE DO NOT CHANGE ANY DATA FROM THIS MODULE.*********'
        ExecuteSQLQuery("SELECT *  FROM    tbl_employee")
        If Not sqlDT.Rows.Count > 0 Then
            ExecuteSQLQuery("INSERT INTO tbl_employee  (emp_name, address, phone, join_date, special_note, status) VALUES        ('Demo', '-', '-', CONVERT(DATETIME, '2020-01-01 00:00:00', 102), '-', 'Active')")
            ExecuteSQLQuery("SELECT        emp_id  FROM            tbl_employee  ORDER BY emp_id DESC")
            Dim TEMP_EMP_ID As Double = sqlDT.Rows(0)("emp_id")
            ExecuteSQLQuery("INSERT INTO tbl_users  (user_name, password, emp_id, reg_date)  VALUES        ('superadmin', '12345', " & TEMP_EMP_ID & ", CONVERT(DATETIME, '2020-01-01 00:00:00', 102))")
            ExecuteSQLQuery("SELECT        User_ID  FROM            tbl_users  ORDER BY User_ID DESC")
            Dim TEMP_USER_ID As Double = sqlDT.Rows(0)("User_ID")
            ExecuteSQLQuery("INSERT INTO tbl_permission (User_ID, AccessKey)  VALUES        (" & TEMP_USER_ID & ", 404)")
        End If
        ExecuteSQLQuery(" SELECT * FROM HeadOfAccounts ")
        If Not sqlDT.Rows.Count > 0 Then
            ExecuteSQLQuery("INSERT INTO HeadOfAccounts (HeadOfAccountsName, HACCID) VALUES ('CASH & BANK ACCOUNTS', 1001)")
            ExecuteSQLQuery("INSERT INTO HeadOfAccounts (HeadOfAccountsName, HACCID) VALUES ('INCOME ACCOUNTS', 2001)")
            ExecuteSQLQuery("INSERT INTO HeadOfAccounts (HeadOfAccountsName, HACCID) VALUES ('EXPENSE ACCOUNTS', 3001)")
        End If
    End Sub
End Module
