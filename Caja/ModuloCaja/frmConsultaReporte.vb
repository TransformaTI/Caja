Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmConsultaReporte
    Inherits System.Windows.Forms.Form
    Private rptReporte As New ReportDocument()
    Private _TablaReporte As Table
    Private _LogonInfo As TableLogOnInfo

    Dim crConnectionInfo As New ConnectionInfo()

    Dim crTables As Tables
    Dim crTable As Table
    Dim crParameterValues As ParameterValues
    Dim crParameterDiscreteValue As ParameterDiscreteValue
    Dim crParameterFieldDefinitions As ParameterFieldDefinitions
    Dim crParameterFieldDefinition As ParameterFieldDefinition


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
    Friend WithEvents crvReporte As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaReporte))
        Me.crvReporte = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'crvReporte
        '
        Me.crvReporte.ActiveViewIndex = -1
        'Me.crvReporte.DisplayGroupTree = False
        Me.crvReporte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crvReporte.Name = "crvReporte"
        Me.crvReporte.ReportSource = Nothing
        Me.crvReporte.ShowGroupTreeButton = False
        Me.crvReporte.Size = New System.Drawing.Size(592, 413)
        Me.crvReporte.TabIndex = 0
        '
        'frmConsultaReporte
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(592, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.crvReporte})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaReporte"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de reporte"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal TipoReporte As enumTipoReporte, _
                   ByVal Celula As Short, _
                   ByVal Fecha As Date, _
                   ByVal FOperacion As Date, _
                   Optional ByVal Caja As Integer = 0, _
                   Optional ByVal Folio As Integer = 0, _
                   Optional ByVal Consecutivo As Integer = 0, _
                   Optional ByVal Clave As String = "")

        MyBase.New()
        InitializeComponent()
        Cursor = Cursors.WaitCursor

        Try
            Select Case TipoReporte
                Case enumTipoReporte.RepMovimientoCaja
                    crvReporte.SelectionFormula = "{vwMovimientoCaja1.FMovimiento} =" & FechaCrystal(Fecha) & " AND {vwMovimientoCaja1.RutaCelula} = " & Celula.ToString
                    rptReporte.Load(Main.GLOBAL_RutaReportes & "\MovimientosCaja.rpt")
                    AplicaInfoConexion()

                Case enumTipoReporte.RepEficiencias
                    crvReporte.SelectionFormula = "{vwReporteEficiencias.FOperacion} =" & FechaCrystal(Fecha) & " AND {vwReporteEficiencias.Celula} = " & Celula.ToString
                    rptReporte.Load(GLOBAL_RutaReportes & "\Eficiencias.rpt")
                    AplicaInfoConexion()

                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("TituloReporte")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = "Del día: " & Fecha.ToShortDateString & " Célula: " & Celula.ToString
                    crParameterValues.Add(crParameterDiscreteValue)

                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                Case enumTipoReporte.RepMovimientoCajaDetalle

                    rptReporte.Load(GLOBAL_RutaReportes & "\MovimientoCajaDetalle.rpt")
                    AplicaInfoConexion()
                    'Consecutivo
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Consecutivo")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Consecutivo
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Folio
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Folio
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Caja
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Caja
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'FOperacion
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = FOperacion
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                Case enumTipoReporte.RepFormatoNotaIngreso

                    rptReporte.Load(GLOBAL_RutaReportes & "\FormatoNotaIngreso.rpt")
                    AplicaInfoConexion()

                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Clave")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Clave
                    crParameterValues.Add(crParameterDiscreteValue)

                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                Case enumTipoReporte.RepComprobanteCaja                    
                    rptReporte.Load(GLOBAL_RutaReportes & "\ComprobanteCaja.rpt")
                    AplicaInfoConexion()
                    'Consecutivo
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Consecutivo")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Consecutivo
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Folio
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Folio
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Caja
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Caja
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'FOperacion
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = FOperacion
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Clave
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Clave")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Clave
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

                    'reporte de cobros eliminados por modificación del movimiento de caja
                Case enumTipoReporte.RepMovimientoCobrosEliminados

                    rptReporte.Load(GLOBAL_RutaReportes & "\ReporteCobrosEliminados.rpt")
                    AplicaInfoConexion()
                    'Consecutivo
                    crParameterFieldDefinitions = rptReporte.DataDefinition.ParameterFields
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Consecutivo")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Consecutivo
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Folio
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Folio")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Folio
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'Caja
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Caja")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = Caja
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    'FOperacion
                    crParameterFieldDefinition = crParameterFieldDefinitions.Item("@FOperacion")
                    crParameterValues = crParameterFieldDefinition.CurrentValues
                    crParameterDiscreteValue = New ParameterDiscreteValue()
                    crParameterDiscreteValue.Value = FOperacion
                    crParameterValues.Add(crParameterDiscreteValue)
                    crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)
                    ''Clave
                    'crParameterFieldDefinition = crParameterFieldDefinitions.Item("@Clave")
                    'crParameterValues = crParameterFieldDefinition.CurrentValues
                    'crParameterDiscreteValue = New ParameterDiscreteValue()
                    'crParameterDiscreteValue.Value = Clave
                    'crParameterValues.Add(crParameterDiscreteValue)
                    'crParameterFieldDefinition.ApplyCurrentValues(crParameterValues)

            End Select

            crvReporte.ReportSource = rptReporte

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Reportes", MessageBoxButtons.OK, MessageBoxIcon.Error)

        Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub AplicaInfoConexion()
        Dim _Usuario, _Password As String
        If Main.GLOBAL_SeguridadNT = True Then
            _Usuario = "sigametcls"
            _Password = "romanos122"
        Else
            _Usuario = Main.GLOBAL_IDUsuario
            _Password = Main.GLOBAL_Password
        End If
        For Each _TablaReporte In rptReporte.Database.Tables
            _LogonInfo = _TablaReporte.LogOnInfo
            With _LogonInfo.ConnectionInfo
                .ServerName = Main.GLOBAL_Servidor
                .DatabaseName = Main.GLOBAL_Database
                .UserID = _Usuario
                .Password = _Password
            End With
            _TablaReporte.ApplyLogOnInfo(_LogonInfo)
        Next
    End Sub

    Public Enum enumTipoReporte
        RepMovimientoCaja = 1
        RepEficiencias = 2
        RepMovimientoCajaDetalle = 3
        RepFormatoNotaIngreso = 4
        RepComprobanteCaja = 5
        RepMovimientoCobrosEliminados = 6
    End Enum

End Class
