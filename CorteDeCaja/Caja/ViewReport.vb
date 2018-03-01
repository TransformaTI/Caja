Option Strict On

Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class ViewReport

    Inherits System.Windows.Forms.Form
    Private AñoCP As Integer
    Private FolioCP As Integer
    Dim tablaActual As CrystalDecisions.CrystalReports.Engine.Table
    Dim loginActual As CrystalDecisions.Shared.TableLogOnInfo

    Dim reporte As New ReportDocument()

    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition

    Public strFiltro As String

    Public Sub Conexion()
        For Each tablaActual In reporte.Database.Tables
            loginActual = tablaActual.LogOnInfo
            With loginActual.ConnectionInfo
                .ServerName = dmModulo._Servidor
                .UserID = dmModulo._Usuario
                .Password = dmModulo._PassWord
                .DatabaseName = dmModulo._DB
            End With
            tablaActual.ApplyLogOnInfo(loginActual)
        Next
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents crvReportes As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ViewReport))
        Me.crvReportes = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvReportes
        '
        Me.crvReportes.ActiveViewIndex = -1
        Me.crvReportes.DisplayGroupTree = False
        Me.crvReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReportes.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.crvReportes.Name = "crvReportes"
        Me.crvReportes.ReportSource = Nothing
        Me.crvReportes.ShowGroupTreeButton = False
        Me.crvReportes.Size = New System.Drawing.Size(822, 519)
        Me.crvReportes.TabIndex = 0
        '
        'ViewReport
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(822, 519)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReportes})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ViewReport"
        Me.Text = "Impresión de reportes"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    'Impresión de la ficha seleccionada
    Public Sub Entrar(ByVal Papeleta As Integer, ByVal Caja As String, ByVal Fecha As String)
        Try

            reporte.Load(Application.StartupPath + "\Reportes\rptImprimeFicha.rpt")
            Conexion()

            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            'Se agregan los parámetros del reporte (Procedimiento almacenado)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Papeleta")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Papeleta
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Caja
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Fecha")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Fecha
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReportes.ReportSource = reporte

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

        Me.ShowDialog()
    End Sub

    Public Sub EntrarComprobante(ByVal NombreEmpresaContable As String, ByVal Proveedor As Integer, ByVal Comprobante As Integer, ByVal Cajera As String, ByVal Cajas As Integer)

        Try
            If Proveedor = 380 Then
                reporte.Load(Application.StartupPath + "\Reportes\rptImprimeComprobanteServicioPan.rpt")
            Else
                reporte.Load(Application.StartupPath + "\Reportes\rptImprimeComprobanteServicioCometra.rpt")
            End If
            Conexion()

            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@ComprobanteServicio") 'nombre del parametro del PROCEDIMIENTO ALMACENADO
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Comprobante
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Cajera") 'nombre del parametro del PROCEDIMIENTO ALMACENADO
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Cajera.Trim
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja") 'nombre del parametro del PROCEDIMIENTO ALMACENADO
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Cajas
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresa") 'nombre del parametro del PROCEDIMIENTO ALMACENADO
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = dmModulo._NombreEmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReportes.ReportSource = reporte

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

        Me.ShowDialog()
    End Sub

    Public Sub CorteCaja(ByVal NombreEmpresaContable As String, ByVal FOperacion As String, ByVal Caja As Integer, ByVal Consecutivo As Integer, ByVal TipoCorte As Integer)
        Try

            reporte.Load(Application.StartupPath + "\Reportes\rptReporteCorteCaja.rpt")

            Conexion()

            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            '2007-016-EIM-01	
            'REQ 139
            'Autor: Fernando Correa
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresaContable")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = NombreEmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@EmpresaContable")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = dmModulo._EmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = CType(FOperacion, String)

            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Caja

            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Consecutivo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Consecutivo

            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TipoCorte")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = TipoCorte
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crvReportes.ReportSource = reporte

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
        Me.ShowDialog()

    End Sub

    '2012-01-31	
    'Autor: Claudia García
    Public Sub CorteCajaPrestamos(ByVal NombreEmpresaContable As String, ByVal FOperacion As String, ByVal Caja As Integer, ByVal Consecutivo As Integer, ByVal TipoCorte As Integer)
        Try

            reporte.Load(Application.StartupPath + "\Reportes\rptReporteCorteCajaF.rpt")

            Conexion()

            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresaContable")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = NombreEmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@EmpresaContable")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = dmModulo._EmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = CType(FOperacion, String)

            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Caja

            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Consecutivo")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Consecutivo

            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TipoCorte")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = TipoCorte
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crvReportes.ReportSource = reporte

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
        Me.ShowDialog()

    End Sub

    Public Sub RelacionCheques(ByVal NombreEmpresaContable As String, ByVal Caja As Integer, ByVal Fecha As String, ByVal Reportes As String, ByVal DiasAnteriores As Boolean)
        Dim cheques As Integer
        Try
            If Reportes = "Relacion de Cheques Bancos" Then
                reporte.Load(Application.StartupPath + "\Reportes\rptReporteRelacionCheques.rpt")
            ElseIf Reportes = "Relacion Cheques Corte" Then
                reporte.Load(Application.StartupPath + "\Reportes\rptReporteRelacionChequesBancos2.rpt")
                cheques = 1
            ElseIf Reportes = "Relacion Cheques Corte x Banco" Then
                reporte.Load(Application.StartupPath + "\Reportes\rptReporteRelacionChequesBancos.rpt")
                cheques = 0
            Else
                reporte.Load(Application.StartupPath + "\Reportes\rptReporteRelacionChequesMovimientoCaja.rpt")

            End If

            Conexion()

            '2007-016-EIM-01	
            'REQ 139
            'Autor: Fernando Correa

            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Caja
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Fecha
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            If Reportes = "Relacion Cheques Corte x Banco" Or Reportes = "Relacion Cheques Corte" Then
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TipoCheques")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = cheques
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            Else
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@TipoCheques")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = Reportes
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If
            If Reportes <> "Relacion Cheques Corte" And Reportes <> "Relacion Cheques Corte x Banco" Then
                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@DiasAnteriores")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = DiasAnteriores
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresaContable")
                crParameterValues = crParameterFieldDefinition.CurrentValues
                crParameterDiscreteValue = New ParameterDiscreteValue()
                crParameterDiscreteValue.Value = NombreEmpresaContable
                crParameterValues.Add(crParameterDiscreteValue)
                crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            End If
            crvReportes.ReportSource = reporte

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

        Me.ShowDialog()
    End Sub

    Public Sub DesgloceFichas(ByVal NombreEmpresaContable As String, ByVal EmpresaContable As Integer, ByVal FOperacion As String)
        Try

            reporte.Load(Application.StartupPath + "\Reportes\rptReporteDesgloceFichasDepositoContraVentaContado.rpt")

            Conexion()
            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            '2007-016-EIM-01	
            'REQ 139
            'Autor: Fernando Correa
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresaContable")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = NombreEmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@EmpresaContable")
            crParameterFieldDefinition.CurrentValues.Clear()
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = EmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = FOperacion
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReportes.ReportSource = reporte

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

        Me.ShowDialog()
    End Sub

    Public Sub ChequesPosfechados(ByVal NombreEmpresaContable As String, ByVal FDeposito As String, ByVal Caja As Integer, ByVal Acumulado As Boolean)
        Try

            reporte.Load(Application.StartupPath + "\Reportes\rptReporteChequesPosfechados.rpt")

            Conexion()
            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            '2007-016-EIM-01	
            'REQ 139
            'Autor: Fernando Correa
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresaContable")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = NombreEmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FDeposito")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = FDeposito
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Caja
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Acumulado")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Acumulado
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crvReportes.ReportSource = reporte

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
        Me.ShowDialog()
    End Sub

    Public Sub ChequesPosfechadosVencidos(ByVal NombreEmpresaContable As String, ByVal FDeposito As String, ByVal Caja As Integer, ByVal Acumulado As Boolean)
        Try

            reporte.Load(Application.StartupPath + "\Reportes\rptReporteChequesPosfechadosVencidos.rpt")

            Conexion()
            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            '2007-016-EIM-01	
            'REQ 139
            'Autor: Fernando Correa
            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresaContable")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = NombreEmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FDeposito")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = FDeposito
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Caja
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crvReportes.ReportSource = reporte

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Acumulado")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Acumulado
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try
        Me.ShowDialog()
    End Sub

    Public Sub RelacionChequesDeposito(ByVal NombreEmpresaContable As String, ByVal FDeposito As String, ByVal Banco As Int16)
        Try

            reporte.Load(Application.StartupPath + "\Reportes\rptRelacionChequesDepositos.rpt")

            Conexion()
            crParameterFieldDefinitions = reporte.DataDefinition.ParameterFields

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@NombreEmpresa")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = dmModulo._NombreEmpresaContable
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FInicio")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = FDeposito
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Ffin")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = FDeposito
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Banco")
            crParameterValues = crParameterFieldDefinition.CurrentValues
            crParameterDiscreteValue = New ParameterDiscreteValue()
            crParameterDiscreteValue.Value = Banco
            crParameterValues.Add(crParameterDiscreteValue)
            crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
            crvReportes.ReportSource = reporte


        Catch ExReport As LoadSaveReportException
            MessageBox.Show("No se pudo cargar el reporte.", "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch Ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error: " & Chr(13) & _
                           Ex.Message, "Error general", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

        Me.ShowDialog()
    End Sub
End Class