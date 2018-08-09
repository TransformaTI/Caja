Option Strict On
Option Explicit On 
Public Class frmPrincipal
    Inherits System.Windows.Forms.Form


#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        If Not (GLOBAL_SigametPortatil) Then
            tbBarra.Buttons.Remove(tbbLiqPortatil)
        End If

        'TODO: Activación de los botones para control de folios
        'JAGD 17/11/2004
        If Not oSeguridad.TieneAcceso("CONTROL_FOLIOS") Then
            tbBarra.Buttons.Remove(tbbAsignacionFolios)
            tbBarra.Buttons.Remove(tbbCancelacionFolios)
        Else
            'GENERAR LA INSTANCIA PARA ESTE CONTROL 11/06/2009
            ControlFolios.Globals.GetInstance.ConfiguraModulo(GLOBAL_Servidor, GLOBAL_Database, _
                GLOBAL_IDUsuario, GLOBAL_Password, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario, _
                GLOBAL_RutaReportes, ConString)
        End If

        'TODO: Acceso al cambio de FMovimiento de liquidaciones
        'JAGD 17/11/2004
        If Not oSeguridad.TieneAcceso("CAMBIO_FMOVIMIENTO") Then
            mnuCambioFMovimiento.Visible = False
        End If

        mniModificacion.Visible = oSeguridad.TieneAcceso("CAMBIO_FMOVIMIENTOCOB")
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
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents mnuPrincipal As System.Windows.Forms.MainMenu
    Friend WithEvents mnuReportes As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAcercade As System.Windows.Forms.MenuItem
    Friend WithEvents mnuSalir As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatBanco As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLiquidaciones As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCheques As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatRazonDevCheque As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVentana As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVenCascada As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVenVertical As System.Windows.Forms.MenuItem
    Friend WithEvents mnuVenHorizontal As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatTipoMovCaja As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLiquidacionCelulaConsulta As System.Windows.Forms.MenuItem
    Friend WithEvents mnuArchivo As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatalogos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuAyuda As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents sbpUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpNombreUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuCatCaja As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCatDenom As System.Windows.Forms.MenuItem
    Friend WithEvents mnuTarjetaCredito As System.Windows.Forms.MenuItem
    Friend WithEvents mnuMovimientos As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuDocumentos As System.Windows.Forms.MenuItem
    Friend WithEvents mnuLiquidacion As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaCobranza As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultas As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents sbpCaja As System.Windows.Forms.StatusBarPanel
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCambioClave As System.Windows.Forms.MenuItem
    Friend WithEvents tbBarra As System.Windows.Forms.ToolBar
    Friend WithEvents tbbLiqOperadores As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents tbbConsultaCobLiq As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuRepMovCaja As System.Windows.Forms.MenuItem
    Friend WithEvents mnuRepEficiencias As System.Windows.Forms.MenuItem
    Friend WithEvents mnuConsultaOperador As System.Windows.Forms.MenuItem
    Friend WithEvents tbbConsultaOperador As System.Windows.Forms.ToolBarButton
    Friend WithEvents sbpVersion As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuReportesDinamicos As System.Windows.Forms.MenuItem
    Friend WithEvents tbbReportes As System.Windows.Forms.ToolBarButton
    Friend WithEvents sbpDiaAjuste As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpServidor As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpBaseDeDatos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents mnuCorteCaja As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents tbbCorteCaja As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuParametros As System.Windows.Forms.MenuItem
    Friend WithEvents tbbLiqPortatil As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCancelacionFolios As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbAsignacionFolios As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuCambioFMovimiento As System.Windows.Forms.MenuItem
    Friend WithEvents mniModificacion As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As MenuItem
    Friend WithEvents mnuCostoGas As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrincipal))
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.sbpUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.sbpNombreUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.sbpCaja = New System.Windows.Forms.StatusBarPanel()
        Me.sbpServidor = New System.Windows.Forms.StatusBarPanel()
        Me.sbpBaseDeDatos = New System.Windows.Forms.StatusBarPanel()
        Me.sbpVersion = New System.Windows.Forms.StatusBarPanel()
        Me.sbpDiaAjuste = New System.Windows.Forms.StatusBarPanel()
        Me.mnuPrincipal = New System.Windows.Forms.MainMenu(Me.components)
        Me.mnuArchivo = New System.Windows.Forms.MenuItem()
        Me.mnuLiquidaciones = New System.Windows.Forms.MenuItem()
        Me.mnuLiquidacionCelulaConsulta = New System.Windows.Forms.MenuItem()
        Me.mnuLiquidacion = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.mnuCheques = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.mnuMovimientos = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.mnuDocumentos = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuCorteCaja = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.mnuCambioFMovimiento = New System.Windows.Forms.MenuItem()
        Me.mniModificacion = New System.Windows.Forms.MenuItem()
        Me.mnuSalir = New System.Windows.Forms.MenuItem()
        Me.mnuConsultas = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaCobranza = New System.Windows.Forms.MenuItem()
        Me.mnuConsultaOperador = New System.Windows.Forms.MenuItem()
        Me.mnuCatalogos = New System.Windows.Forms.MenuItem()
        Me.mnuCatBanco = New System.Windows.Forms.MenuItem()
        Me.mnuCatRazonDevCheque = New System.Windows.Forms.MenuItem()
        Me.mnuCatTipoMovCaja = New System.Windows.Forms.MenuItem()
        Me.mnuCatCaja = New System.Windows.Forms.MenuItem()
        Me.mnuCatDenom = New System.Windows.Forms.MenuItem()
        Me.mnuTarjetaCredito = New System.Windows.Forms.MenuItem()
        Me.mnuReportes = New System.Windows.Forms.MenuItem()
        Me.mnuRepMovCaja = New System.Windows.Forms.MenuItem()
        Me.mnuRepEficiencias = New System.Windows.Forms.MenuItem()
        Me.mnuReportesDinamicos = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.mnuCambioClave = New System.Windows.Forms.MenuItem()
        Me.mnuCostoGas = New System.Windows.Forms.MenuItem()
        Me.mnuParametros = New System.Windows.Forms.MenuItem()
        Me.mnuVentana = New System.Windows.Forms.MenuItem()
        Me.mnuVenCascada = New System.Windows.Forms.MenuItem()
        Me.mnuVenHorizontal = New System.Windows.Forms.MenuItem()
        Me.mnuVenVertical = New System.Windows.Forms.MenuItem()
        Me.mnuAyuda = New System.Windows.Forms.MenuItem()
        Me.mnuAcercade = New System.Windows.Forms.MenuItem()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.tbBarra = New System.Windows.Forms.ToolBar()
        Me.tbbLiqOperadores = New System.Windows.Forms.ToolBarButton()
        Me.tbbLiqPortatil = New System.Windows.Forms.ToolBarButton()
        Me.tbbConsultaCobLiq = New System.Windows.Forms.ToolBarButton()
        Me.tbbConsultaOperador = New System.Windows.Forms.ToolBarButton()
        Me.tbbReportes = New System.Windows.Forms.ToolBarButton()
        Me.tbbCorteCaja = New System.Windows.Forms.ToolBarButton()
        Me.tbbAsignacionFolios = New System.Windows.Forms.ToolBarButton()
        Me.tbbCancelacionFolios = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpNombreUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpBaseDeDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpDiaAjuste, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'stbEstatus
        '
        Me.stbEstatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.stbEstatus.Location = New System.Drawing.Point(0, 395)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpUsuario, Me.sbpNombreUsuario, Me.sbpCaja, Me.sbpServidor, Me.sbpBaseDeDatos, Me.sbpVersion, Me.sbpDiaAjuste})
        Me.stbEstatus.ShowPanels = True
        Me.stbEstatus.Size = New System.Drawing.Size(808, 22)
        Me.stbEstatus.TabIndex = 1
        Me.stbEstatus.Text = "Módulo de caja (Prototipo)"
        '
        'sbpUsuario
        '
        Me.sbpUsuario.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpUsuario.Name = "sbpUsuario"
        '
        'sbpNombreUsuario
        '
        Me.sbpNombreUsuario.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpNombreUsuario.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpNombreUsuario.Name = "sbpNombreUsuario"
        Me.sbpNombreUsuario.Width = 103
        '
        'sbpCaja
        '
        Me.sbpCaja.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpCaja.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpCaja.Name = "sbpCaja"
        Me.sbpCaja.Width = 103
        '
        'sbpServidor
        '
        Me.sbpServidor.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpServidor.Icon = CType(resources.GetObject("sbpServidor.Icon"), System.Drawing.Icon)
        Me.sbpServidor.Name = "sbpServidor"
        Me.sbpServidor.ToolTipText = "Nombre del servidor"
        Me.sbpServidor.Width = 150
        '
        'sbpBaseDeDatos
        '
        Me.sbpBaseDeDatos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpBaseDeDatos.Name = "sbpBaseDeDatos"
        Me.sbpBaseDeDatos.ToolTipText = "Nombre de la base de datos"
        Me.sbpBaseDeDatos.Width = 150
        '
        'sbpVersion
        '
        Me.sbpVersion.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.sbpVersion.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpVersion.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.None
        Me.sbpVersion.Name = "sbpVersion"
        Me.sbpVersion.Width = 103
        '
        'sbpDiaAjuste
        '
        Me.sbpDiaAjuste.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.sbpDiaAjuste.MinWidth = 50
        Me.sbpDiaAjuste.Name = "sbpDiaAjuste"
        Me.sbpDiaAjuste.ToolTipText = "Día de ajuste"
        Me.sbpDiaAjuste.Width = 80
        '
        'mnuPrincipal
        '
        Me.mnuPrincipal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuArchivo, Me.mnuConsultas, Me.mnuCatalogos, Me.mnuReportes, Me.MenuItem5, Me.mnuVentana, Me.mnuAyuda})
        '
        'mnuArchivo
        '
        Me.mnuArchivo.Index = 0
        Me.mnuArchivo.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuLiquidaciones, Me.MenuItem3, Me.mnuCheques, Me.MenuItem1, Me.mnuMovimientos, Me.MenuItem6, Me.mnuDocumentos, Me.MenuItem4, Me.mnuCorteCaja, Me.MenuItem9, Me.mnuCambioFMovimiento, Me.mniModificacion, Me.mnuSalir})
        Me.mnuArchivo.Text = "&Archivo"
        '
        'mnuLiquidaciones
        '
        Me.mnuLiquidaciones.Index = 0
        Me.mnuLiquidaciones.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuLiquidacionCelulaConsulta, Me.mnuLiquidacion})
        Me.mnuLiquidaciones.Text = "&Liquidaciones"
        '
        'mnuLiquidacionCelulaConsulta
        '
        Me.mnuLiquidacionCelulaConsulta.Index = 0
        Me.mnuLiquidacionCelulaConsulta.Text = "Consulta de pre-liquidaciones de las células"
        '
        'mnuLiquidacion
        '
        Me.mnuLiquidacion.Index = 1
        Me.mnuLiquidacion.Text = "Liquidación de operadores"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "-"
        '
        'mnuCheques
        '
        Me.mnuCheques.Index = 2
        Me.mnuCheques.Shortcut = System.Windows.Forms.Shortcut.F3
        Me.mnuCheques.Text = "C&heques"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 3
        Me.MenuItem1.Text = "-"
        '
        'mnuMovimientos
        '
        Me.mnuMovimientos.Index = 4
        Me.mnuMovimientos.Text = "&Movimientos"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 5
        Me.MenuItem6.Text = "-"
        '
        'mnuDocumentos
        '
        Me.mnuDocumentos.Index = 6
        Me.mnuDocumentos.Text = "&Documentos"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 7
        Me.MenuItem4.Text = "-"
        '
        'mnuCorteCaja
        '
        Me.mnuCorteCaja.Index = 8
        Me.mnuCorteCaja.Text = "&Corte de caja"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 9
        Me.MenuItem9.Text = "-"
        '
        'mnuCambioFMovimiento
        '
        Me.mnuCambioFMovimiento.Index = 10
        Me.mnuCambioFMovimiento.Text = "Cambio de &FMovimiento"
        '
        'mniModificacion
        '
        Me.mniModificacion.Index = 11
        Me.mniModificacion.Text = "Modificación de cobranza"
        '
        'mnuSalir
        '
        Me.mnuSalir.Index = 12
        Me.mnuSalir.Text = "&Salir"
        '
        'mnuConsultas
        '
        Me.mnuConsultas.Index = 1
        Me.mnuConsultas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuConsultaCobranza, Me.mnuConsultaOperador})
        Me.mnuConsultas.Text = "Consultas"
        '
        'mnuConsultaCobranza
        '
        Me.mnuConsultaCobranza.Index = 0
        Me.mnuConsultaCobranza.Text = "Consulta de cobranzas y &liquidaciones"
        '
        'mnuConsultaOperador
        '
        Me.mnuConsultaOperador.Index = 1
        Me.mnuConsultaOperador.Text = "Consulta de &operadores y documentos"
        '
        'mnuCatalogos
        '
        Me.mnuCatalogos.Index = 2
        Me.mnuCatalogos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCatBanco, Me.mnuCatRazonDevCheque, Me.mnuCatTipoMovCaja, Me.mnuCatCaja, Me.mnuCatDenom, Me.mnuTarjetaCredito, Me.MenuItem8})
        Me.mnuCatalogos.Text = "&Catálogos"
        '
        'mnuCatBanco
        '
        Me.mnuCatBanco.Index = 0
        Me.mnuCatBanco.Text = "&Bancos"
        '
        'mnuCatRazonDevCheque
        '
        Me.mnuCatRazonDevCheque.Index = 1
        Me.mnuCatRazonDevCheque.Text = "&Razones de cheques devueltos"
        '
        'mnuCatTipoMovCaja
        '
        Me.mnuCatTipoMovCaja.Index = 2
        Me.mnuCatTipoMovCaja.Text = "&Tipo de movimientos de caja"
        '
        'mnuCatCaja
        '
        Me.mnuCatCaja.Index = 3
        Me.mnuCatCaja.Text = "&Cajas"
        '
        'mnuCatDenom
        '
        Me.mnuCatDenom.Index = 4
        Me.mnuCatDenom.Text = "&Denominaciones"
        '
        'mnuTarjetaCredito
        '
        Me.mnuTarjetaCredito.Index = 5
        Me.mnuTarjetaCredito.Text = "Tarjetas de crédito"
        '
        'mnuReportes
        '
        Me.mnuReportes.Index = 3
        Me.mnuReportes.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuRepMovCaja, Me.mnuRepEficiencias, Me.mnuReportesDinamicos})
        Me.mnuReportes.Text = "&Reportes"
        '
        'mnuRepMovCaja
        '
        Me.mnuRepMovCaja.Index = 0
        Me.mnuRepMovCaja.Text = "Movimientos de caja"
        '
        'mnuRepEficiencias
        '
        Me.mnuRepEficiencias.Index = 1
        Me.mnuRepEficiencias.Text = "Eficiencias negativas"
        '
        'mnuReportesDinamicos
        '
        Me.mnuReportesDinamicos.Index = 2
        Me.mnuReportesDinamicos.Text = "&Reportes..."
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem7, Me.mnuCambioClave, Me.mnuCostoGas, Me.mnuParametros})
        Me.MenuItem5.Text = "&Herramientas"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 0
        Me.MenuItem7.Text = "&Información del usuario"
        '
        'mnuCambioClave
        '
        Me.mnuCambioClave.Index = 1
        Me.mnuCambioClave.Text = "&Cambio de contraseña"
        '
        'mnuCostoGas
        '
        Me.mnuCostoGas.Index = 2
        Me.mnuCostoGas.Text = "C&osto del Gas"
        '
        'mnuParametros
        '
        Me.mnuParametros.Enabled = False
        Me.mnuParametros.Index = 3
        Me.mnuParametros.Text = "&Parámetros del sistema"
        '
        'mnuVentana
        '
        Me.mnuVentana.Index = 5
        Me.mnuVentana.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuVenCascada, Me.mnuVenHorizontal, Me.mnuVenVertical})
        Me.mnuVentana.Text = "&Ventana"
        '
        'mnuVenCascada
        '
        Me.mnuVenCascada.Index = 0
        Me.mnuVenCascada.Text = "Cascada"
        '
        'mnuVenHorizontal
        '
        Me.mnuVenHorizontal.Index = 1
        Me.mnuVenHorizontal.Text = "Mosaico horizontal"
        '
        'mnuVenVertical
        '
        Me.mnuVenVertical.Index = 2
        Me.mnuVenVertical.Text = "Mosaico vertical"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Index = 6
        Me.mnuAyuda.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuAcercade})
        Me.mnuAyuda.Text = "&?44e"
        '
        'mnuAcercade
        '
        Me.mnuAcercade.Index = 0
        Me.mnuAcercade.Text = "&Acerca de..."
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = -1
        Me.MenuItem2.Text = ""
        '
        'tbBarra
        '
        Me.tbBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbLiqOperadores, Me.tbbLiqPortatil, Me.tbbConsultaCobLiq, Me.tbbConsultaOperador, Me.tbbReportes, Me.tbbCorteCaja, Me.tbbAsignacionFolios, Me.tbbCancelacionFolios})
        Me.tbBarra.ButtonSize = New System.Drawing.Size(140, 36)
        Me.tbBarra.DropDownArrows = True
        Me.tbBarra.ImageList = Me.imgLista
        Me.tbBarra.Location = New System.Drawing.Point(0, 0)
        Me.tbBarra.Name = "tbBarra"
        Me.tbBarra.ShowToolTips = True
        Me.tbBarra.Size = New System.Drawing.Size(808, 78)
        Me.tbBarra.TabIndex = 5
        '
        'tbbLiqOperadores
        '
        Me.tbbLiqOperadores.ImageIndex = 1
        Me.tbbLiqOperadores.Name = "tbbLiqOperadores"
        Me.tbbLiqOperadores.Tag = "LiqOperadores"
        Me.tbbLiqOperadores.Text = "Liquidación a operadores"
        Me.tbbLiqOperadores.ToolTipText = "Liquidación en caja de operadores"
        '
        'tbbLiqPortatil
        '
        Me.tbbLiqPortatil.ImageIndex = 7
        Me.tbbLiqPortatil.Name = "tbbLiqPortatil"
        Me.tbbLiqPortatil.Tag = "LiqPortatil"
        Me.tbbLiqPortatil.Text = "Liquidación a operadores"
        Me.tbbLiqPortatil.ToolTipText = "Liquidacion en caja a operadores (tanque portátil)"
        '
        'tbbConsultaCobLiq
        '
        Me.tbbConsultaCobLiq.ImageIndex = 0
        Me.tbbConsultaCobLiq.Name = "tbbConsultaCobLiq"
        Me.tbbConsultaCobLiq.Tag = "ConsultaCobLiq"
        Me.tbbConsultaCobLiq.Text = "Cobranzas y liquidaciones"
        Me.tbbConsultaCobLiq.ToolTipText = "Consulta la lista de cobranzas capturadas y las liquidaciones recibidas en la caj" &
    "a"
        '
        'tbbConsultaOperador
        '
        Me.tbbConsultaOperador.ImageIndex = 3
        Me.tbbConsultaOperador.Name = "tbbConsultaOperador"
        Me.tbbConsultaOperador.Tag = "ConsultaOperador"
        Me.tbbConsultaOperador.Text = "Operadores y documentos"
        Me.tbbConsultaOperador.ToolTipText = "Consulta de operadores y cargos de eficiencias negativas"
        '
        'tbbReportes
        '
        Me.tbbReportes.ImageIndex = 4
        Me.tbbReportes.Name = "tbbReportes"
        Me.tbbReportes.Tag = "Reportes"
        Me.tbbReportes.Text = "Reportes"
        Me.tbbReportes.ToolTipText = "Reportes del sistema"
        '
        'tbbCorteCaja
        '
        Me.tbbCorteCaja.ImageIndex = 6
        Me.tbbCorteCaja.Name = "tbbCorteCaja"
        Me.tbbCorteCaja.Tag = "CorteCaja"
        Me.tbbCorteCaja.Text = "Corte de caja"
        Me.tbbCorteCaja.ToolTipText = "Corte de caja"
        Me.tbbCorteCaja.Visible = False
        '
        'tbbAsignacionFolios
        '
        Me.tbbAsignacionFolios.ImageIndex = 8
        Me.tbbAsignacionFolios.Name = "tbbAsignacionFolios"
        Me.tbbAsignacionFolios.Tag = "AsingFolios"
        Me.tbbAsignacionFolios.Text = "Asignacion de folios"
        Me.tbbAsignacionFolios.ToolTipText = "Control de Folios"
        '
        'tbbCancelacionFolios
        '
        Me.tbbCancelacionFolios.ImageIndex = 9
        Me.tbbCancelacionFolios.Name = "tbbCancelacionFolios"
        Me.tbbCancelacionFolios.Tag = "CancelFolios"
        Me.tbbCancelacionFolios.Text = "Cancelacion de folios"
        Me.tbbCancelacionFolios.ToolTipText = "Cancelacion de folios"
        '
        'imgLista
        '
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        Me.imgLista.Images.SetKeyName(0, "")
        Me.imgLista.Images.SetKeyName(1, "")
        Me.imgLista.Images.SetKeyName(2, "")
        Me.imgLista.Images.SetKeyName(3, "")
        Me.imgLista.Images.SetKeyName(4, "")
        Me.imgLista.Images.SetKeyName(5, "")
        Me.imgLista.Images.SetKeyName(6, "")
        Me.imgLista.Images.SetKeyName(7, "")
        Me.imgLista.Images.SetKeyName(8, "")
        Me.imgLista.Images.SetKeyName(9, "")
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 6
        Me.MenuItem8.Text = "Tipo Concepto"
        '
        'frmPrincipal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.PaleGoldenrod
        Me.ClientSize = New System.Drawing.Size(808, 417)
        Me.Controls.Add(Me.tbBarra)
        Me.Controls.Add(Me.stbEstatus)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mnuPrincipal
        Me.Name = "frmPrincipal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Módulo de caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.sbpUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpNombreUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpServidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpBaseDeDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpVersion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpDiaAjuste, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub Salir()
        Salir()
    End Sub

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuSalir.Click
        Me.Close()
    End Sub

    Private Sub mnuCatBanco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatBanco.Click
        Dim frmCatBanco As frmCatBanco = New frmCatBanco()
        With frmCatBanco
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub mnuCatCuenta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmCatCuentas As frmCatCuentaBan = New frmCatCuentaBan()
        With frmCatCuentas
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub mnuCatTipoMov_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatTipoMovCaja.Click
        Dim frmCatTipoMov As frmCatTipoMov = New frmCatTipoMov()
        With frmCatTipoMov
            .MdiParent = Me
            .Show()
        End With
    End Sub

    Private Sub mnuCatRazonDevCheque_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatRazonDevCheque.Click
        Dim frmRazonDevCheque As frmCatRazonDevCheque = New frmCatRazonDevCheque()
        frmRazonDevCheque.MdiParent = Me
        frmRazonDevCheque.Show()
    End Sub

    Private Sub mnuVenCascada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVenCascada.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub mnuVenHorizontal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuVenHorizontal.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub mnuVenVertical_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuVenVertical.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub mnuConsultaLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLiquidacionCelulaConsulta.Click
        Dim frmPreLiq As New frmPreLiquidacionConsulta()
        frmPreLiq.MdiParent = Me
        frmPreLiq.Show()
    End Sub


    Private Sub mnuMovimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim frmCapMov As frmCapMovimiento = New frmCapMovimiento()
        frmCapMov.MdiParent = Me
        frmCapMov.Show()
    End Sub


    Private Sub mnuCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCheques.Click
        Cheques()
    End Sub

    Private Sub frmPrincipal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "Caja" & Chr(178) & " - " & GLOBAL_NombreEmpresa
        sbpUsuario.Text = Main.GLOBAL_IDUsuario
        sbpNombreUsuario.Text = Main.GLOBAL_UsuarioNombre
        sbpCaja.Text = "Caja " & Main.GLOBAL_CajaUsuario.ToString
        sbpServidor.Text = Main.GLOBAL_Servidor
        sbpBaseDeDatos.Text = Main.GLOBAL_Database
        sbpVersion.Text = "Caja Versión: " & Application.ProductVersion
        If Now.Date.Day <= Main.GLOBAL_DiasAjuste Then
            sbpDiaAjuste.Text = "AJUSTE"
        End If
        If Main.GLOBAL_IDUsuario = GLOBAL_SysAdmin Then
            mnuParametros.Enabled = True
        End If
    End Sub


    Private Sub mnuCatCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatCaja.Click
        Dim frmCatCajas As New frmCatCaja()
        frmCatCajas.MdiParent = Me
        frmCatCajas.Show()
    End Sub

    Private Sub mnuCatDenom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCatDenom.Click
        Dim frmCatDenom As New frmCatDenominaciones()
        frmCatDenom.MdiParent = Me
        frmCatDenom.Show()
    End Sub

    Private Sub mnuTarjetaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuTarjetaCredito.Click
        Dim lParametro As New SigaMetClasses.cConfig(3, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
        lParametro.Dispose()

        Dim frmTarCred As SigaMetClasses.frmConTarjetaCredito
        If String.IsNullOrEmpty(lURLGateway) Then
            frmTarCred = New SigaMetClasses.frmConTarjetaCredito(GLOBAL_IDUsuario)
        Else
            'frmTarCred = New SigaMetClasses.frmConTarjetaCredito(lURLGateway, GLOBAL_IDUsuario)
        End If
        frmTarCred.MdiParent = Me
        frmTarCred.Show()
    End Sub

    Private Sub mnuMovimientos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuMovimientos.Click
        ConsultaMovimientos()
    End Sub

    Private Sub mnuDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuDocumentos.Click
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "ConsultaCargo" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim oConsultaDocumento As New SigaMetClasses.ConsultaCargo()
        oConsultaDocumento.MdiParent = Me
        oConsultaDocumento.Show()
    End Sub

    Private Sub mnuLiquidacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuLiquidacion.Click
        LiquidacionCaja()
    End Sub

    Private Sub mnuConsultaCobranza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaCobranza.Click
        CapturaCobranza()
    End Sub

    Private Sub Cheques()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaCheques" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim frmConCheques As New SigaMetClasses.ConsultaCheques(3, Main.GLOBAL_IDUsuario, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        With frmConCheques
            .WindowState = FormWindowState.Maximized
            .MdiParent = Me
            .CargaListaCheques()
            .URLGateway = Main.GLOBAL_URLGATEWAY
            .CadenaConexion = Main.ConString
            .Corporativo = CType(GLOBAL_CorporativoUsuario, Byte)
            .Sucursal = CType(GLOBAL_SucursalUsuario, Byte)
            .Show()
        End With
        Cursor = Cursors.Default
    End Sub

    Private Sub CapturaCobranza()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaCapCobranza" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim frmConCapCob As New frmConsultaCapCobranza()
        frmConCapCob.MdiParent = Me
        frmConCapCob.Show()
    End Sub

    Private Sub ConsultaOperador()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaOperador" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Dim frmConOperador As New frmConsultaOperador()
        frmConOperador.MdiParent = Me
        frmConOperador.Show()
    End Sub

    Private Sub LiquidacionCaja()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaPreLiquidacion" Then
                f.Focus()
                Exit Sub
            End If
        Next
        Cursor = Cursors.WaitCursor
        Dim frmConPreLiq As New frmConsultaPreLiquidacion()
        frmConPreLiq.MdiParent = Me
        frmConPreLiq.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub ConsultaMovimientos()
        Dim forma As Form
        For Each forma In Me.MdiChildren
            If forma.Name = "ConsultaMovimiento" Then
                forma.Focus()
                Exit Sub
            End If
        Next
        Dim frmConMov As New frmMovimientos()
        frmConMov.MdiParent = Me
        frmConMov.Show()
    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Dim frmInforUsuario As New frmInfoUsuario()
        frmInforUsuario.MdiParent = Me
        frmInforUsuario.Show()
    End Sub

    Private Sub mnuCambioClave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambioClave.Click
        Dim frmCambioClave As New SigaMetClasses.CambioClave(Main.GLOBAL_IDUsuario, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        frmCambioClave.ShowDialog()
    End Sub

    Private Sub tbBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "LiqOperadores"
                LiquidacionCaja()
            Case Is = "ConsultaCobLiq"
                CapturaCobranza()
            Case Is = "ConsultaOperador"
                ConsultaOperador()
            Case Is = "Reportes"
                Reportes()
            Case Is = "CorteCaja"
                CorteCaja()
            Case Is = "LiqPortatil"
                liquidacionPortatil()
                'TODO: Control de folios JAG 17/11/2004
            Case Is = "AsingFolios"
                asignacionDeFolios()
            Case Is = "CancelFolios"
                cancelacionDeFolios()

        End Select

    End Sub

    Private Sub mnuRepMovCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepMovCaja.Click
        Dim frmRepMovCaja As New frmFiltroReporteMovCaja()
        frmRepMovCaja.MdiParent = Me
        frmRepMovCaja.Show()
    End Sub

    Private Sub mnuRepEficiencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuRepEficiencias.Click
        Dim frmRepEficiencia As New frmFiltroReporteEficiencia()
        frmRepEficiencia.MdiParent = Me
        frmRepEficiencia.Show()
    End Sub

    Private Sub mnuConsultaOperador_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaOperador.Click
        ConsultaOperador()
    End Sub

    Private Sub mnuAcercade_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuAcercade.Click
        Dim frmAbout As New SigaMetClasses.AcercaDe("Caja", Application.ProductVersion, Application.CompanyName)
        frmAbout.ShowDialog()
    End Sub

    Private Sub mnuReportesDinamicos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuReportesDinamicos.Click
        Reportes()
    End Sub

    Private Sub Reportes()
        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmListaReporte" Then
                f.Focus()
                Exit Sub
            End If
        Next

        Cursor = Cursors.WaitCursor
        Dim _Servidor, _BaseDatos, _UserID, _Password As String

        _Servidor = Main.GLOBAL_Servidor
        _BaseDatos = Main.GLOBAL_Database

        If Main.GLOBAL_SeguridadNT = True Then
            _UserID = "sigametcls"
            _Password = "romanos122"
        Else
            _UserID = Main.GLOBAL_IDUsuario
            _Password = Main.GLOBAL_Password
        End If

        'Ruta alterna de reportes 20/03/2008                
        Dim frmConRep As New ReporteDinamico.frmListaReporte(3, Main.GLOBAL_RutaReportes, _Servidor, _BaseDatos, Main.GLOBAL_IDUsuario,
                GLOBAL_Connection, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario, GLOBAL_SeguridadReportes)
        '*****

        frmConRep.MdiParent = Me
        frmConRep.WindowState = FormWindowState.Maximized
        frmConRep.Show()
        Cursor = Cursors.Default
    End Sub

    Private Sub liquidacionPortatil()

        Dim f As Form
        For Each f In Me.MdiChildren
            If f.Name = "frmLiquidacionConsulta" Then
                f.Focus()
                Exit Sub
            End If
        Next
        'Dim frmLiquidacionPortatil As New frmLiquidacionConsulta()
        'frmLiquidacionPortatil.MdiParent = Me
        'frmLiquidacionPortatil.WindowState = FormWindowState.Maximized
        'frmLiquidacionPortatil.Show()
        'SE CAMBIÓ LA LLAMADA A LA FRMLIQUIDACIONPORTATIL POR LA LLAMADA A LA
        'DLL LIQUIDACION PORTATIL
        'Dim frmLiquidacionPortatil As New _
        'LiquidacionPortatil.frmLiquidacionConsulta(GLOBAL_IDUsuario, GLOBAL_IDEmpleado, _
        'CType(GLOBAL_CajaUsuario, Byte), GLOBAL_FactorDensidad, GLOBAL_Servidor, _
        'GLOBAL_Database, GLOBAL_Password)
        'frmLiquidacionPortatil.MdiParent = Me
        'frmLiquidacionPortatil.WindowState = FormWindowState.Maximized
        'frmLiquidacionPortatil.Show()

        'Cambió la forma de llamar a la liquidación de portátil
        '09-06-2005
        Dim frmLiquidacionPortatil As New LiquidacionPortatil.frmLiquidacionConsulta(GLOBAL_IDUsuario, GLOBAL_IDEmpleado, CType(GLOBAL_CajaUsuario, Byte), GLOBAL_FactorDensidad, GLOBAL_Servidor, GLOBAL_Database, GLOBAL_Password, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        frmLiquidacionPortatil.MdiParent = Me
        frmLiquidacionPortatil.WindowState = FormWindowState.Maximized
        If frmLiquidacionPortatil.Validated Then
            frmLiquidacionPortatil.Show()
        End If

    End Sub

#Region "Control de folios"

    Private Sub asignacionDeFolios()
        Dim f As Form
        Dim parametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim rutaReporte As String = CType(parametro.Parametros.Item("RutaReportesW7"), String)
        parametro.Dispose()
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaFoliosAsignados" Then
                f.Focus()
                Exit Sub
            End If
        Next

        Dim frmControlFolios As New ControlFolios.frmConsultaFoliosAsignados()

        'Dim frmControlFolios As New _
        'ControlFolios.frmConsultaFoliosAsignados(GLOBAL_Servidor, GLOBAL_Database, _
        '    GLOBAL_IDUsuario, GLOBAL_Password, rutaReporte)
        frmControlFolios.MdiParent = Me
        frmControlFolios.WindowState = FormWindowState.Maximized
        frmControlFolios.Show()
    End Sub


    Private Sub cancelacionDeFolios()
        Dim f As Form
        Dim parametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim rutaReporte As String = CType(parametro.Parametros.Item("RutaReportesW7"), String)
        parametro.Dispose()
        For Each f In Me.MdiChildren
            If f.Name = "frmConsultaFoliosCancelados" Then
                f.Focus()
                Exit Sub
            End If
        Next
        'Dim frmControlFolios As New _
        'ControlFolios.frmConsultaFoliosCancelados(GLOBAL_Servidor, GLOBAL_Database, _
        '    GLOBAL_IDUsuario, GLOBAL_Password, rutaReporte)

        Dim frmControlFolios As New ControlFolios.frmConsultaFoliosCancelados()

        frmControlFolios.MdiParent = Me
        frmControlFolios.WindowState = FormWindowState.Maximized
        frmControlFolios.Show()
    End Sub

#End Region

    Private Sub frmPrincipal_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If MessageBox.Show("¿Desea salir de la aplicación?", "Módulo de Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            e.Cancel = True
        End If
    End Sub

    Private Sub mnuCorteCaja_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCorteCaja.Click
        CorteCaja()
    End Sub

    Private Sub CorteCaja()
        Cursor = Cursors.WaitCursor
        If Not ExisteCorteCaja(Main.GLOBAL_CajaUsuario, Main.FechaOperacion) Then
            Dim frmCorteCaja As New frmCorteCajaAlta(Main.GLOBAL_CajaUsuario, Main.FechaOperacion, Main.ConsecutivoInicioDeSesion)
            frmCorteCaja.ShowDialog()
        Else
            If MessageBox.Show("El corte de caja de este día ya fue capturado." & Chr(13) &
                               "¿Desea modificarlo?", "Corte de caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim oCorte As New SigaMetClasses.CorteCaja()
                Dim frmCorteCaja As New frmCorteCajaAlta(Main.GLOBAL_CajaUsuario, Main.FechaOperacion, Main.ConsecutivoInicioDeSesion, oCorte.ConsultaAplicacion(Main.GLOBAL_CajaUsuario, Main.FechaOperacion))
                frmCorteCaja.ShowDialog()
            End If

        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub mnuParametros_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuParametros.Click
        Cursor = Cursors.WaitCursor
        Dim oParametros As New SigaMetClasses.ConsultaParametros(3)
        oParametros.ShowDialog()
        Cursor = Cursors.Default
    End Sub


    Private Sub mnuCambioFMovimiento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCambioFMovimiento.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmLiquidacionCambio As New CambioDeFechaLiquidacion.FrmLiquidacionesPendientes(Main.GLOBAL_IDUsuario, ConString)
        frmLiquidacionCambio.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mniModificacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mniModificacion.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmModificacionCobranza As New ActualizacionCobranza.ActualizacionCobranza(Main.GLOBAL_IDUsuario, SigaMetClasses.DataLayer.Conexion)
        frmModificacionCobranza.WindowState = FormWindowState.Maximized
        frmModificacionCobranza.MdiParent = Me
        frmModificacionCobranza.Show()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub mnuCostoGas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCostoGas.Click
        If oSeguridad.TieneAcceso("CAPTURACOSTOGLP") Then
            Me.Cursor = Cursors.WaitCursor
            Dim frmCapturaGLP As CapturaCostoGLP.frmCosto
            Try
                frmCapturaGLP = New CapturaCostoGLP.frmCosto(SigaMetClasses.DataLayer.Conexion, Main.GLOBAL_IDUsuario)
            Catch ex As Exception
                MessageBox.Show("Ha ocurrido un error:" & vbCrLf & ex.Message,
                    Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            Finally
                Me.Cursor = Cursors.Default
            End Try
            frmCapturaGLP.ShowDialog()
        End If
    End Sub

    Private Sub MenuItem8_Click(sender As Object, e As EventArgs) Handles MenuItem8.Click
        Dim frmCatTipoConcepto As frmCatTipoConcepto = New frmCatTipoConcepto()
        With frmCatTipoConcepto
            .MdiParent = Me
            .Show()
        End With
    End Sub
End Class