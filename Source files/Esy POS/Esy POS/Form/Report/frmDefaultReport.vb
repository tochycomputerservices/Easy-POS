Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Data.SqlServerCe
Public Class frmDefaultReport
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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub LoadCheckval()
        If rbCustomer.Checked Then
            gbCustomer.Enabled = True
            gbSupplier.Enabled = False
            gbEmployee.Enabled = False
        ElseIf rbSupplier.Checked Then
            gbCustomer.Enabled = False
            gbSupplier.Enabled = True
            gbEmployee.Enabled = False
        ElseIf rbEmployee.Checked Then
            gbCustomer.Enabled = False
            gbSupplier.Enabled = False
            gbEmployee.Enabled = True
        End If

        'Load Customer ID
        ExecuteSQLQuery("SELECT        customer_id  FROM            tbl_customer   ORDER BY customer_id")
        If sqlDT.Rows.Count > 0 Then
            txtCustIdFrom.Text = sqlDT.Rows(0)("customer_id")
        Else
            txtCustIdFrom.Text = "0"
        End If

        ExecuteSQLQuery("SELECT        customer_id  FROM            tbl_customer   ORDER BY customer_id DESC")
        If sqlDT.Rows.Count > 0 Then
            txtCustIdTo.Text = sqlDT.Rows(0)("customer_id")
        Else
            txtCustIdTo.Text = "0"
        End If

        'Load Supplier ID
        ExecuteSQLQuery("SELECT        supplier_id  FROM            tbl_supplier   ORDER BY supplier_id")
        If sqlDT.Rows.Count > 0 Then
            txtSuppIdFrom.Text = sqlDT.Rows(0)("supplier_id")
        Else
            txtSuppIdFrom.Text = "0"
        End If

        ExecuteSQLQuery("SELECT        supplier_id  FROM            tbl_supplier   ORDER BY supplier_id DESC")
        If sqlDT.Rows.Count > 0 Then
            txtSuppIdTo.Text = sqlDT.Rows(0)("supplier_id")
        Else
            txtSuppIdTo.Text = "0"
        End If

        'Load Employee ID
        ExecuteSQLQuery("SELECT        emp_id  FROM            tbl_employee   ORDER BY emp_id")
        If sqlDT.Rows.Count > 0 Then
            txtEmpIdFrom.Text = sqlDT.Rows(0)("emp_id")
        Else
            txtEmpIdFrom.Text = "0"
        End If

        ExecuteSQLQuery("SELECT        emp_id  FROM            tbl_employee   ORDER BY emp_id DESC")
        If sqlDT.Rows.Count > 0 Then
            txtEmpIdTo.Text = sqlDT.Rows(0)("emp_id")
        Else
            txtEmpIdTo.Text = "0"
        End If

    End Sub

    Private Sub frmDefaultReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadCheckval()
    End Sub

    Private Sub rbCustomer_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCustomer.CheckedChanged
        LoadCheckval()
    End Sub

    Private Sub rbSupplier_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSupplier.CheckedChanged
        LoadCheckval()
    End Sub

    Private Sub rbEmployee_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbEmployee.CheckedChanged
        LoadCheckval()
    End Sub

    Private Sub btnPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreview.Click
        LoadCompanyDetails()
        If rbCustomer.Checked Then
            If Val(txtCustIdFrom.Text) <= 0 Then
                MsgBox("Required: FROM ID NO.", MsgBoxStyle.Information, "Information")
            ElseIf Val(txtCustIdTo.Text) <= 0 Then
                MsgBox("Required: TO ID NO.", MsgBoxStyle.Information, "Information")
            Else
                'Report preview
                With frmCrvDefault
                    Dim rpt_Document As New ReportDocument
                    Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
                    rpt_Document.Load(Application.StartupPath & "\Reports\Customer.rpt")
                    Dim My_Connection As SqlCeConnection
                    Dim my_Command As New SqlCeCommand
                    Dim my_DataAdapter As New SqlCeDataAdapter
                    Dim my_DataSource As New EsyPosDataSet
                    My_Connection = New SqlCeConnection(CnString)
                    my_Command.CommandText = " SELECT        customer_id, customer_name, address, phone, balance_date, status, photo " & _
                                             " FROM            tbl_customer  WHERE        (customer_id >= " & txtCustIdFrom.Text & " AND customer_id <= " & txtCustIdTo.Text & ") "
                    my_Command.Connection = My_Connection
                    my_Command.CommandType = CommandType.Text
                    my_DataAdapter.SelectCommand = my_Command
                    my_DataAdapter.Fill(my_DataSource, "tbl_customer")
                    rpt_Document.SetDataSource(my_DataSource)

                    ParamCollection.Add(crpBusinessName)
                    rpt_Document.DataDefinition.ParameterFields("BusinessName").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpBusinessAddress)
                    rpt_Document.DataDefinition.ParameterFields("BusinessAddress").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpTelephone)
                    rpt_Document.DataDefinition.ParameterFields("Telephone").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpFax)
                    rpt_Document.DataDefinition.ParameterFields("Fax").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpEmail)
                    rpt_Document.DataDefinition.ParameterFields("Email").ApplyCurrentValues(ParamCollection)

                    .CrystalReportViewer1.ReportSource = rpt_Document
                    .Show()
                End With
                '----------------
            End If
        ElseIf rbSupplier.Checked Then
            If Val(txtSuppIdFrom.Text) <= 0 Then
                MsgBox("Required: FROM ID NO.", MsgBoxStyle.Information, "Information")
            ElseIf Val(txtSuppIdTo.Text) <= 0 Then
                MsgBox("Required: TO ID NO.", MsgBoxStyle.Information, "Information")
            Else
                'Report preview
                With frmCrvDefault
                    Dim rpt_Document As New ReportDocument
                    Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
                    rpt_Document.Load(Application.StartupPath & "\Reports\Supplier.rpt")
                    Dim My_Connection As SqlCeConnection
                    Dim my_Command As New SqlCeCommand
                    Dim my_DataAdapter As New SqlCeDataAdapter
                    Dim my_DataSource As New EsyPosDataSet
                    My_Connection = New SqlCeConnection(CnString)
                    my_Command.CommandText = " SELECT      *  FROM    tbl_supplier  WHERE        (supplier_id >= " & txtSuppIdFrom.Text & " AND supplier_id <= " & txtSuppIdTo.Text & ") "
                    my_Command.Connection = My_Connection
                    my_Command.CommandType = CommandType.Text
                    my_DataAdapter.SelectCommand = my_Command
                    my_DataAdapter.Fill(my_DataSource, "tbl_supplier")
                    rpt_Document.SetDataSource(my_DataSource)

                    ParamCollection.Add(crpBusinessName)
                    rpt_Document.DataDefinition.ParameterFields("BusinessName").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpBusinessAddress)
                    rpt_Document.DataDefinition.ParameterFields("BusinessAddress").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpTelephone)
                    rpt_Document.DataDefinition.ParameterFields("Telephone").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpFax)
                    rpt_Document.DataDefinition.ParameterFields("Fax").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpEmail)
                    rpt_Document.DataDefinition.ParameterFields("Email").ApplyCurrentValues(ParamCollection)

                    .CrystalReportViewer1.ReportSource = rpt_Document
                    .Show()
                End With
                '----------------
            End If
        ElseIf rbEmployee.Checked Then
            If Val(txtEmpIdFrom.Text) <= 0 Then
                MsgBox("Required: FROM ID NO.", MsgBoxStyle.Information, "Information")
            ElseIf Val(txtEmpIdTo.Text) <= 0 Then
                MsgBox("Required: TO ID NO.", MsgBoxStyle.Information, "Information")
            Else
                'Report preview
                With frmCrvDefault
                    Dim rpt_Document As New ReportDocument
                    Dim ParamCollection As New CrystalDecisions.Shared.ParameterValues
                    rpt_Document.Load(Application.StartupPath & "\Reports\Employee.rpt")
                    Dim My_Connection As SqlCeConnection
                    Dim my_Command As New SqlCeCommand
                    Dim my_DataAdapter As New SqlCeDataAdapter
                    Dim my_DataSource As New EsyPosDataSet
                    My_Connection = New SqlCeConnection(CnString)
                    my_Command.CommandText = " SELECT      *  FROM    tbl_employee  WHERE        (emp_id >= " & txtEmpIdFrom.Text & " AND emp_id <= " & txtEmpIdTo.Text & ") "
                    my_Command.Connection = My_Connection
                    my_Command.CommandType = CommandType.Text
                    my_DataAdapter.SelectCommand = my_Command
                    my_DataAdapter.Fill(my_DataSource, "tbl_employee")
                    rpt_Document.SetDataSource(my_DataSource)

                    ParamCollection.Add(crpBusinessName)
                    rpt_Document.DataDefinition.ParameterFields("BusinessName").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpBusinessAddress)
                    rpt_Document.DataDefinition.ParameterFields("BusinessAddress").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpTelephone)
                    rpt_Document.DataDefinition.ParameterFields("Telephone").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpFax)
                    rpt_Document.DataDefinition.ParameterFields("Fax").ApplyCurrentValues(ParamCollection)
                    ParamCollection.Add(crpEmail)
                    rpt_Document.DataDefinition.ParameterFields("Email").ApplyCurrentValues(ParamCollection)

                    .CrystalReportViewer1.ReportSource = rpt_Document
                    .Show()
                End With
                '----------------
            End If
        End If
    End Sub
End Class