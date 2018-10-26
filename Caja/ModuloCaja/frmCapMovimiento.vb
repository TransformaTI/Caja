Option Strict On
Option Explicit On 

Public Class frmCapMovimiento
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        lblTipoOperacion.Text = "Captura de movimiento"
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
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents lblFecha As ControlesBase.LabelBase
    Friend WithEvents grpCabecera As System.Windows.Forms.GroupBox
    Friend WithEvents grpLiquidacionConsulta As System.Windows.Forms.GroupBox
    Friend WithEvents grpCobroVale As System.Windows.Forms.GroupBox
    Friend WithEvents Vales As CapturaEfectivo.Vales
    Friend WithEvents grpCobroCheque As System.Windows.Forms.GroupBox
    Friend WithEvents grpCobroEfectivo As System.Windows.Forms.GroupBox
    Friend WithEvents grpCobroDocumentos As System.Windows.Forms.GroupBox
    Friend WithEvents lblPorCobrarEfectivo As System.Windows.Forms.Label
    Friend WithEvents lblPorCobrarVales As System.Windows.Forms.Label
	Friend WithEvents lblTotalCheques As System.Windows.Forms.Label
	Friend WithEvents lblTipoOperacion As System.Windows.Forms.Label
	Friend WithEvents lblImporteCobranza2 As ControlesBase.LabelBase
	Friend WithEvents Panel1 As System.Windows.Forms.Panel
	Friend WithEvents btnConsultaDocumentos As ControlesBase.BotonBase
	Friend WithEvents btnCambio As ControlesBase.BotonBase
	Friend WithEvents grdCheque As System.Windows.Forms.DataGrid
	Friend WithEvents lnkConsultaCheques As System.Windows.Forms.LinkLabel
	Friend WithEvents lblNoTieneCheques As System.Windows.Forms.Label
	Friend WithEvents lblEmpleado2 As ControlesBase.LabelBase
	Friend WithEvents lblFechaAlta2 As ControlesBase.LabelBase
	Friend WithEvents lblFechaAlta As System.Windows.Forms.Label
	Friend WithEvents lblNoTieneVales As System.Windows.Forms.Label
	Friend WithEvents lblTotalEfectivo As System.Windows.Forms.Label
	Friend WithEvents LabelBase1 As ControlesBase.LabelBase
	Friend WithEvents LabelBase3 As ControlesBase.LabelBase
	Friend WithEvents LabelBase4 As ControlesBase.LabelBase
	Friend WithEvents LabelBase5 As ControlesBase.LabelBase
	Friend WithEvents grpCobroTC As System.Windows.Forms.GroupBox
	Friend WithEvents Label2 As System.Windows.Forms.Label
	Friend WithEvents lnkConsultaTarjetaCredito As System.Windows.Forms.LinkLabel
	Friend WithEvents grdTarjetaCredito As System.Windows.Forms.DataGrid
	Friend WithEvents EstiloCheques As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents colChNumeroCheque As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colChBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents lblTotalTarjetaCredito As System.Windows.Forms.Label
	Friend WithEvents LabelBase6 As ControlesBase.LabelBase
	Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
	Friend WithEvents Label30 As ControlesBase.LabelBase
	Friend WithEvents lblRuta As System.Windows.Forms.Label
	Friend WithEvents lblTipoMovimientoCaja As System.Windows.Forms.Label
	Friend WithEvents lblFOperacion As System.Windows.Forms.Label
	Friend WithEvents grdFichaDeposito As System.Windows.Forms.DataGrid
	Friend WithEvents lnkConsultaFichaDeposito As System.Windows.Forms.LinkLabel
	Friend WithEvents grpCobroFicha As System.Windows.Forms.GroupBox
	Friend WithEvents lblCambio2 As ControlesBase.LabelBase
	Friend WithEvents lblImporteTotalCobro As System.Windows.Forms.Label
	Friend WithEvents lblImporteTotalCobros As ControlesBase.LabelBase
	Friend WithEvents Label3 As System.Windows.Forms.Label
	Friend WithEvents EstiloFicha As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents lblTotalTarjetaDebito As System.Windows.Forms.Label
	Friend WithEvents LabelBase7 As ControlesBase.LabelBase
	Friend WithEvents LabelBase8 As ControlesBase.LabelBase
	Friend WithEvents lblImporteMovimiento As System.Windows.Forms.Label
	Friend WithEvents grdInfoPreLiq As System.Windows.Forms.DataGrid
	Friend WithEvents InfoPreLiq As System.Windows.Forms.DataGridTableStyle
	Friend WithEvents colPLRutaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colPLCelula As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colPLImporteContado As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colPLImporteCredito As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colPLFolio As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents grpDatosMovimiento As System.Windows.Forms.GroupBox
	Friend WithEvents ComboTipoMovimientoCaja As SigaMetClasses.Combos.ComboTipoMovimientoCaja
	Friend WithEvents colChTotal As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents LabelBase2 As ControlesBase.LabelBase
	Friend WithEvents colPLEficiencia As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colPLImporteEficiencia As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colPLTipoPagoEficienciaDesc As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colPLTipoPagoEficiencia As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents LabelBase9 As ControlesBase.LabelBase
	Friend WithEvents lblImporteEficiencia As System.Windows.Forms.Label
	Friend WithEvents chkIncluirEficiencia As System.Windows.Forms.CheckBox
	Friend WithEvents grpCobroEficiencia As System.Windows.Forms.GroupBox
	Friend WithEvents lblCambio As System.Windows.Forms.Label
	Friend WithEvents lblCambioEntregado As System.Windows.Forms.Label
	Friend WithEvents LabelBase10 As ControlesBase.LabelBase
	Friend WithEvents lblFaltante As System.Windows.Forms.Label
	Friend WithEvents LabelBase11 As ControlesBase.LabelBase
	Friend WithEvents dtpFMovimiento As System.Windows.Forms.DateTimePicker
	Friend WithEvents LabelBase12 As ControlesBase.LabelBase
	Friend WithEvents lblTotalVarios As System.Windows.Forms.Label
	Friend WithEvents LabelBase13 As ControlesBase.LabelBase
	Friend WithEvents lblStatus As System.Windows.Forms.Label
	Friend WithEvents lblAFavorOperadorCheques As System.Windows.Forms.Label
	Friend WithEvents colChSaldo As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents lblNoTieneEfectivo As System.Windows.Forms.Label
	Friend WithEvents colChTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents colDocumento As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents lblMovimientoCajaClave As System.Windows.Forms.Label
	Friend WithEvents Panel2 As System.Windows.Forms.Panel
	Friend WithEvents LabelBase15 As ControlesBase.LabelBase
	Friend WithEvents lblRealEfectivoVales As System.Windows.Forms.Label
	Friend WithEvents lblFMovimiento As System.Windows.Forms.Label
	Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents picAviso As System.Windows.Forms.PictureBox
	Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
	Friend WithEvents PanelMensaje As System.Windows.Forms.Panel
	Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
	Friend WithEvents lblPanelMensaje As System.Windows.Forms.Label
	Friend WithEvents colPLFInicioRuta As System.Windows.Forms.DataGridTextBoxColumn
	Friend WithEvents lblObservaciones As System.Windows.Forms.Label
	Friend WithEvents LabelBase16 As ControlesBase.LabelBase
	Friend WithEvents lblMotivoCancelacion2 As System.Windows.Forms.Label
	Friend WithEvents lblMotivoCancelacion1 As ControlesBase.LabelBase
	Friend WithEvents CobroEfectivo As CapturaEfectivo.Efectivo
	Friend WithEvents lblCaptAFAvor As System.Windows.Forms.Label
	Friend WithEvents lnkConsultaIVA As System.Windows.Forms.LinkLabel
	Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
	Friend WithEvents LabelBase14 As ControlesBase.LabelBase
	Friend WithEvents lblTotalVale As System.Windows.Forms.Label
	Friend WithEvents LabelNombreEmpresa1 As NombreEmpresa.LabelNombreEmpresa
	Friend WithEvents RegistroValeCredito1 As ControlDeValesPromocionales.RegistroValeCredito
	<System.Diagnostics.DebuggerStepThrough()>
	Private Sub InitializeComponent()
		Me.components = New System.ComponentModel.Container()
		Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapMovimiento))
		Me.btnCancelar = New ControlesBase.BotonBase()
		Me.btnAceptar = New ControlesBase.BotonBase()
		Me.btnConsultaDocumentos = New ControlesBase.BotonBase()
		Me.grpLiquidacionConsulta = New System.Windows.Forms.GroupBox()
		Me.grdInfoPreLiq = New System.Windows.Forms.DataGrid()
		Me.InfoPreLiq = New System.Windows.Forms.DataGridTableStyle()
		Me.colPLFolio = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLRutaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLCelula = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLImporteContado = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLImporteCredito = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLEficiencia = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLImporteEficiencia = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLTipoPagoEficiencia = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLTipoPagoEficienciaDesc = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colPLFInicioRuta = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.LabelBase9 = New ControlesBase.LabelBase()
		Me.lblImporteEficiencia = New System.Windows.Forms.Label()
		Me.grpCabecera = New System.Windows.Forms.GroupBox()
		Me.lblMotivoCancelacion1 = New ControlesBase.LabelBase()
		Me.lblMotivoCancelacion2 = New System.Windows.Forms.Label()
		Me.LabelBase16 = New ControlesBase.LabelBase()
		Me.lblObservaciones = New System.Windows.Forms.Label()
		Me.picAviso = New System.Windows.Forms.PictureBox()
		Me.lblFMovimiento = New System.Windows.Forms.Label()
		Me.lblStatus = New System.Windows.Forms.Label()
		Me.ComboTipoMovimientoCaja = New SigaMetClasses.Combos.ComboTipoMovimientoCaja()
		Me.lblFOperacion = New System.Windows.Forms.Label()
		Me.lblTipoMovimientoCaja = New System.Windows.Forms.Label()
		Me.lblRuta = New System.Windows.Forms.Label()
		Me.lblFechaAlta = New System.Windows.Forms.Label()
		Me.lblNombreEmpleado = New System.Windows.Forms.Label()
		Me.dtpFMovimiento = New System.Windows.Forms.DateTimePicker()
		Me.LabelBase13 = New ControlesBase.LabelBase()
		Me.LabelBase2 = New ControlesBase.LabelBase()
		Me.LabelBase8 = New ControlesBase.LabelBase()
		Me.lblEmpleado2 = New ControlesBase.LabelBase()
		Me.Label30 = New ControlesBase.LabelBase()
		Me.lblFecha = New ControlesBase.LabelBase()
		Me.lblFechaAlta2 = New ControlesBase.LabelBase()
		Me.grpDatosMovimiento = New System.Windows.Forms.GroupBox()
		Me.lnkConsultaIVA = New System.Windows.Forms.LinkLabel()
		Me.grpCobroEficiencia = New System.Windows.Forms.GroupBox()
		Me.chkIncluirEficiencia = New System.Windows.Forms.CheckBox()
		Me.lblImporteMovimiento = New System.Windows.Forms.Label()
		Me.lblImporteCobranza2 = New ControlesBase.LabelBase()
		Me.grpCobroVale = New System.Windows.Forms.GroupBox()
		Me.RegistroValeCredito1 = New ControlDeValesPromocionales.RegistroValeCredito()
		Me.Vales = New CapturaEfectivo.Vales()
		Me.lblNoTieneVales = New System.Windows.Forms.Label()
		Me.grpCobroCheque = New System.Windows.Forms.GroupBox()
		Me.lnkConsultaCheques = New System.Windows.Forms.LinkLabel()
		Me.grdCheque = New System.Windows.Forms.DataGrid()
		Me.EstiloCheques = New System.Windows.Forms.DataGridTableStyle()
		Me.colChTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colChNumeroCheque = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colChBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colChTotal = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colChSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.lblNoTieneCheques = New System.Windows.Forms.Label()
		Me.grpCobroEfectivo = New System.Windows.Forms.GroupBox()
		Me.CobroEfectivo = New CapturaEfectivo.Efectivo()
		Me.lblPorCobrarVales = New System.Windows.Forms.Label()
		Me.lblPorCobrarEfectivo = New System.Windows.Forms.Label()
		Me.LabelBase3 = New ControlesBase.LabelBase()
		Me.LabelBase1 = New ControlesBase.LabelBase()
		Me.lblNoTieneEfectivo = New System.Windows.Forms.Label()
		Me.grpCobroDocumentos = New System.Windows.Forms.GroupBox()
		Me.LabelBase14 = New ControlesBase.LabelBase()
		Me.lblTotalVale = New System.Windows.Forms.Label()
		Me.lblCaptAFAvor = New System.Windows.Forms.Label()
		Me.LabelBase15 = New ControlesBase.LabelBase()
		Me.lblRealEfectivoVales = New System.Windows.Forms.Label()
		Me.lblAFavorOperadorCheques = New System.Windows.Forms.Label()
		Me.lblTotalVarios = New System.Windows.Forms.Label()
		Me.LabelBase12 = New ControlesBase.LabelBase()
		Me.lblTotalTarjetaDebito = New System.Windows.Forms.Label()
		Me.LabelBase7 = New ControlesBase.LabelBase()
		Me.grpCobroFicha = New System.Windows.Forms.GroupBox()
		Me.grdFichaDeposito = New System.Windows.Forms.DataGrid()
		Me.EstiloFicha = New System.Windows.Forms.DataGridTableStyle()
		Me.colTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
		Me.lnkConsultaFichaDeposito = New System.Windows.Forms.LinkLabel()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.lblTotalTarjetaCredito = New System.Windows.Forms.Label()
		Me.LabelBase6 = New ControlesBase.LabelBase()
		Me.grpCobroTC = New System.Windows.Forms.GroupBox()
		Me.grdTarjetaCredito = New System.Windows.Forms.DataGrid()
		Me.lnkConsultaTarjetaCredito = New System.Windows.Forms.LinkLabel()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.btnCambio = New ControlesBase.BotonBase()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.LabelBase11 = New ControlesBase.LabelBase()
		Me.lblFaltante = New System.Windows.Forms.Label()
		Me.lblCambioEntregado = New System.Windows.Forms.Label()
		Me.LabelBase10 = New ControlesBase.LabelBase()
		Me.lblCambio = New System.Windows.Forms.Label()
		Me.lblCambio2 = New ControlesBase.LabelBase()
		Me.lblImporteTotalCobro = New System.Windows.Forms.Label()
		Me.lblImporteTotalCobros = New ControlesBase.LabelBase()
		Me.lblTotalEfectivo = New System.Windows.Forms.Label()
		Me.lblTotalCheques = New System.Windows.Forms.Label()
		Me.LabelBase5 = New ControlesBase.LabelBase()
		Me.LabelBase4 = New ControlesBase.LabelBase()
		Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
		Me.lblTipoOperacion = New System.Windows.Forms.Label()
		Me.lblMovimientoCajaClave = New System.Windows.Forms.Label()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.LabelNombreEmpresa1 = New NombreEmpresa.LabelNombreEmpresa()
		Me.PanelMensaje = New System.Windows.Forms.Panel()
		Me.lblPanelMensaje = New System.Windows.Forms.Label()
		Me.PictureBox1 = New System.Windows.Forms.PictureBox()
		Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
		Me.grpLiquidacionConsulta.SuspendLayout()
		CType(Me.grdInfoPreLiq, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpCabecera.SuspendLayout()
		CType(Me.picAviso, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpDatosMovimiento.SuspendLayout()
		Me.grpCobroEficiencia.SuspendLayout()
		Me.grpCobroVale.SuspendLayout()
		Me.grpCobroCheque.SuspendLayout()
		CType(Me.grdCheque, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpCobroEfectivo.SuspendLayout()
		Me.grpCobroDocumentos.SuspendLayout()
		Me.grpCobroFicha.SuspendLayout()
		CType(Me.grdFichaDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.grpCobroTC.SuspendLayout()
		CType(Me.grdTarjetaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		Me.PanelMensaje.SuspendLayout()
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'btnCancelar
		'
		Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
		Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
		Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnCancelar.Location = New System.Drawing.Point(912, 40)
		Me.btnCancelar.Name = "btnCancelar"
		Me.btnCancelar.Size = New System.Drawing.Size(104, 24)
		Me.btnCancelar.TabIndex = 5
		Me.btnCancelar.Text = "&Cancelar (Esc)"
		Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnCancelar.UseVisualStyleBackColor = False
		'
		'btnAceptar
		'
		Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
		Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
		Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnAceptar.Location = New System.Drawing.Point(912, 8)
		Me.btnAceptar.Name = "btnAceptar"
		Me.btnAceptar.Size = New System.Drawing.Size(104, 24)
		Me.btnAceptar.TabIndex = 4
		Me.btnAceptar.Text = "&Aceptar (F10)"
		Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnAceptar.UseVisualStyleBackColor = False
		'
		'btnConsultaDocumentos
		'
		Me.btnConsultaDocumentos.BackColor = System.Drawing.SystemColors.Control
		Me.btnConsultaDocumentos.Image = CType(resources.GetObject("btnConsultaDocumentos.Image"), System.Drawing.Image)
		Me.btnConsultaDocumentos.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.btnConsultaDocumentos.Location = New System.Drawing.Point(128, 88)
		Me.btnConsultaDocumentos.Name = "btnConsultaDocumentos"
		Me.btnConsultaDocumentos.Size = New System.Drawing.Size(240, 40)
		Me.btnConsultaDocumentos.TabIndex = 26
		Me.btnConsultaDocumentos.Text = "Consulta documentos relacionados"
		Me.btnConsultaDocumentos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.btnConsultaDocumentos.UseVisualStyleBackColor = False
		Me.btnConsultaDocumentos.Visible = False
		'
		'grpLiquidacionConsulta
		'
		Me.grpLiquidacionConsulta.Controls.Add(Me.grdInfoPreLiq)
		Me.grpLiquidacionConsulta.Controls.Add(Me.LabelBase9)
		Me.grpLiquidacionConsulta.Controls.Add(Me.lblImporteEficiencia)
		Me.grpLiquidacionConsulta.Location = New System.Drawing.Point(8, 528)
		Me.grpLiquidacionConsulta.Name = "grpLiquidacionConsulta"
		Me.grpLiquidacionConsulta.Size = New System.Drawing.Size(392, 168)
		Me.grpLiquidacionConsulta.TabIndex = 35
		Me.grpLiquidacionConsulta.TabStop = False
		Me.grpLiquidacionConsulta.Text = "Consulta de la pre-liquidación de la ruta"
		'
		'grdInfoPreLiq
		'
		Me.grdInfoPreLiq.BackgroundColor = System.Drawing.Color.LemonChiffon
		Me.grdInfoPreLiq.CaptionBackColor = System.Drawing.Color.WhiteSmoke
		Me.grdInfoPreLiq.CaptionForeColor = System.Drawing.Color.Red
		Me.grdInfoPreLiq.CaptionText = "Información de la pre-liquidación"
		Me.grdInfoPreLiq.DataMember = ""
		Me.grdInfoPreLiq.ForeColor = System.Drawing.Color.Black
		Me.grdInfoPreLiq.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.grdInfoPreLiq.Location = New System.Drawing.Point(8, 24)
		Me.grdInfoPreLiq.Name = "grdInfoPreLiq"
		Me.grdInfoPreLiq.ReadOnly = True
		Me.grdInfoPreLiq.RowHeadersVisible = False
		Me.grdInfoPreLiq.SelectionBackColor = System.Drawing.Color.Red
		Me.grdInfoPreLiq.Size = New System.Drawing.Size(360, 96)
		Me.grdInfoPreLiq.TabIndex = 36
		Me.grdInfoPreLiq.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.InfoPreLiq})
		'
		'InfoPreLiq
		'
		Me.InfoPreLiq.DataGrid = Me.grdInfoPreLiq
		Me.InfoPreLiq.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colPLFolio, Me.colPLRutaDescripcion, Me.colPLCelula, Me.colPLImporteContado, Me.colPLImporteCredito, Me.colPLEficiencia, Me.colPLImporteEficiencia, Me.colPLTipoPagoEficiencia, Me.colPLTipoPagoEficienciaDesc, Me.colPLFInicioRuta})
		Me.InfoPreLiq.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.InfoPreLiq.MappingName = "InfoPreLiq"
		Me.InfoPreLiq.RowHeadersVisible = False
		'
		'colPLFolio
		'
		Me.colPLFolio.Format = ""
		Me.colPLFolio.FormatInfo = Nothing
		Me.colPLFolio.HeaderText = "Folio"
		Me.colPLFolio.MappingName = "Folio"
		Me.colPLFolio.Width = 50
		'
		'colPLRutaDescripcion
		'
		Me.colPLRutaDescripcion.Format = ""
		Me.colPLRutaDescripcion.FormatInfo = Nothing
		Me.colPLRutaDescripcion.HeaderText = "Ruta"
		Me.colPLRutaDescripcion.MappingName = "RutaDescripcion"
		Me.colPLRutaDescripcion.Width = 70
		'
		'colPLCelula
		'
		Me.colPLCelula.Format = ""
		Me.colPLCelula.FormatInfo = Nothing
		Me.colPLCelula.HeaderText = "Célula"
		Me.colPLCelula.MappingName = "Celula"
		Me.colPLCelula.Width = 40
		'
		'colPLImporteContado
		'
		Me.colPLImporteContado.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colPLImporteContado.Format = "#,##.00"
		Me.colPLImporteContado.FormatInfo = Nothing
		Me.colPLImporteContado.HeaderText = "Contado"
		Me.colPLImporteContado.MappingName = "ImporteContado"
		Me.colPLImporteContado.Width = 70
		'
		'colPLImporteCredito
		'
		Me.colPLImporteCredito.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colPLImporteCredito.Format = "#,##.00"
		Me.colPLImporteCredito.FormatInfo = Nothing
		Me.colPLImporteCredito.HeaderText = "Crédito"
		Me.colPLImporteCredito.MappingName = "ImporteCredito"
		Me.colPLImporteCredito.Width = 70
		'
		'colPLEficiencia
		'
		Me.colPLEficiencia.Format = ""
		Me.colPLEficiencia.FormatInfo = Nothing
		Me.colPLEficiencia.HeaderText = "Eficiencia"
		Me.colPLEficiencia.MappingName = "Eficiencia"
		Me.colPLEficiencia.Width = 75
		'
		'colPLImporteEficiencia
		'
		Me.colPLImporteEficiencia.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colPLImporteEficiencia.Format = "#,##.00"
		Me.colPLImporteEficiencia.FormatInfo = Nothing
		Me.colPLImporteEficiencia.HeaderText = "Importe eficiencia"
		Me.colPLImporteEficiencia.MappingName = "ImporteEficiencia"
		Me.colPLImporteEficiencia.Width = 120
		'
		'colPLTipoPagoEficiencia
		'
		Me.colPLTipoPagoEficiencia.Format = ""
		Me.colPLTipoPagoEficiencia.FormatInfo = Nothing
		Me.colPLTipoPagoEficiencia.MappingName = "TipoPagoEficiencia"
		Me.colPLTipoPagoEficiencia.Width = 0
		'
		'colPLTipoPagoEficienciaDesc
		'
		Me.colPLTipoPagoEficienciaDesc.Format = ""
		Me.colPLTipoPagoEficienciaDesc.FormatInfo = Nothing
		Me.colPLTipoPagoEficienciaDesc.HeaderText = "Tipo pago ef."
		Me.colPLTipoPagoEficienciaDesc.MappingName = "TipoPagoEficienciaDesc"
		Me.colPLTipoPagoEficienciaDesc.Width = 75
		'
		'colPLFInicioRuta
		'
		Me.colPLFInicioRuta.Format = ""
		Me.colPLFInicioRuta.FormatInfo = Nothing
		Me.colPLFInicioRuta.HeaderText = "F.Inicio Ruta"
		Me.colPLFInicioRuta.MappingName = "FInicioRuta"
		Me.colPLFInicioRuta.Width = 75
		'
		'LabelBase9
		'
		Me.LabelBase9.AutoSize = True
		Me.LabelBase9.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase9.ForeColor = System.Drawing.Color.Blue
		Me.LabelBase9.Location = New System.Drawing.Point(24, 128)
		Me.LabelBase9.Name = "LabelBase9"
		Me.LabelBase9.Size = New System.Drawing.Size(190, 18)
		Me.LabelBase9.TabIndex = 60
		Me.LabelBase9.Text = "Importe de la eficiencia:"
		Me.LabelBase9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblImporteEficiencia
		'
		Me.lblImporteEficiencia.BackColor = System.Drawing.Color.Khaki
		Me.lblImporteEficiencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblImporteEficiencia.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblImporteEficiencia.ForeColor = System.Drawing.Color.Blue
		Me.lblImporteEficiencia.Location = New System.Drawing.Point(240, 128)
		Me.lblImporteEficiencia.Name = "lblImporteEficiencia"
		Me.lblImporteEficiencia.Size = New System.Drawing.Size(128, 24)
		Me.lblImporteEficiencia.TabIndex = 59
		Me.lblImporteEficiencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'grpCabecera
		'
		Me.grpCabecera.BackColor = System.Drawing.Color.Gainsboro
		Me.grpCabecera.Controls.Add(Me.lblMotivoCancelacion1)
		Me.grpCabecera.Controls.Add(Me.lblMotivoCancelacion2)
		Me.grpCabecera.Controls.Add(Me.LabelBase16)
		Me.grpCabecera.Controls.Add(Me.lblObservaciones)
		Me.grpCabecera.Controls.Add(Me.picAviso)
		Me.grpCabecera.Controls.Add(Me.lblFMovimiento)
		Me.grpCabecera.Controls.Add(Me.lblStatus)
		Me.grpCabecera.Controls.Add(Me.ComboTipoMovimientoCaja)
		Me.grpCabecera.Controls.Add(Me.lblFOperacion)
		Me.grpCabecera.Controls.Add(Me.lblTipoMovimientoCaja)
		Me.grpCabecera.Controls.Add(Me.lblRuta)
		Me.grpCabecera.Controls.Add(Me.lblFechaAlta)
		Me.grpCabecera.Controls.Add(Me.lblNombreEmpleado)
		Me.grpCabecera.Controls.Add(Me.dtpFMovimiento)
		Me.grpCabecera.Controls.Add(Me.LabelBase13)
		Me.grpCabecera.Controls.Add(Me.LabelBase2)
		Me.grpCabecera.Controls.Add(Me.LabelBase8)
		Me.grpCabecera.Controls.Add(Me.lblEmpleado2)
		Me.grpCabecera.Controls.Add(Me.Label30)
		Me.grpCabecera.Controls.Add(Me.lblFecha)
		Me.grpCabecera.Controls.Add(Me.lblFechaAlta2)
		Me.grpCabecera.Location = New System.Drawing.Point(8, 72)
		Me.grpCabecera.Name = "grpCabecera"
		Me.grpCabecera.Size = New System.Drawing.Size(392, 296)
		Me.grpCabecera.TabIndex = 36
		Me.grpCabecera.TabStop = False
		Me.grpCabecera.Text = "Datos del movimiento"
		'
		'lblMotivoCancelacion1
		'
		Me.lblMotivoCancelacion1.AutoSize = True
		Me.lblMotivoCancelacion1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMotivoCancelacion1.Location = New System.Drawing.Point(16, 259)
		Me.lblMotivoCancelacion1.Name = "lblMotivoCancelacion1"
		Me.lblMotivoCancelacion1.Size = New System.Drawing.Size(116, 13)
		Me.lblMotivoCancelacion1.TabIndex = 47
		Me.lblMotivoCancelacion1.Text = "Motivo de cancelación:"
		Me.lblMotivoCancelacion1.Visible = False
		'
		'lblMotivoCancelacion2
		'
		Me.lblMotivoCancelacion2.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblMotivoCancelacion2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblMotivoCancelacion2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMotivoCancelacion2.ForeColor = System.Drawing.Color.Firebrick
		Me.lblMotivoCancelacion2.Location = New System.Drawing.Point(136, 256)
		Me.lblMotivoCancelacion2.Name = "lblMotivoCancelacion2"
		Me.lblMotivoCancelacion2.Size = New System.Drawing.Size(248, 21)
		Me.lblMotivoCancelacion2.TabIndex = 46
		Me.lblMotivoCancelacion2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.lblMotivoCancelacion2.Visible = False
		'
		'LabelBase16
		'
		Me.LabelBase16.AutoSize = True
		Me.LabelBase16.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase16.Location = New System.Drawing.Point(16, 192)
		Me.LabelBase16.Name = "LabelBase16"
		Me.LabelBase16.Size = New System.Drawing.Size(82, 13)
		Me.LabelBase16.TabIndex = 45
		Me.LabelBase16.Text = "Observaciones:"
		'
		'lblObservaciones
		'
		Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblObservaciones.ForeColor = System.Drawing.Color.Black
		Me.lblObservaciones.Location = New System.Drawing.Point(136, 192)
		Me.lblObservaciones.Name = "lblObservaciones"
		Me.lblObservaciones.Size = New System.Drawing.Size(248, 56)
		Me.lblObservaciones.TabIndex = 44
		'
		'picAviso
		'
		Me.picAviso.BackColor = System.Drawing.Color.Red
		Me.picAviso.Image = CType(resources.GetObject("picAviso.Image"), System.Drawing.Image)
		Me.picAviso.Location = New System.Drawing.Point(360, 121)
		Me.picAviso.Name = "picAviso"
		Me.picAviso.Size = New System.Drawing.Size(18, 18)
		Me.picAviso.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.picAviso.TabIndex = 0
		Me.picAviso.TabStop = False
		Me.picAviso.Visible = False
		'
		'lblFMovimiento
		'
		Me.lblFMovimiento.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblFMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFMovimiento.ForeColor = System.Drawing.Color.Blue
		Me.lblFMovimiento.Location = New System.Drawing.Point(136, 120)
		Me.lblFMovimiento.Name = "lblFMovimiento"
		Me.lblFMovimiento.Size = New System.Drawing.Size(248, 21)
		Me.lblFMovimiento.TabIndex = 43
		Me.lblFMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ttMensaje.SetToolTip(Me.lblFMovimiento, "Se está validando una liquidación de otro día")
		'
		'lblStatus
		'
		Me.lblStatus.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblStatus.ForeColor = System.Drawing.Color.Firebrick
		Me.lblStatus.Location = New System.Drawing.Point(136, 24)
		Me.lblStatus.Name = "lblStatus"
		Me.lblStatus.Size = New System.Drawing.Size(248, 21)
		Me.lblStatus.TabIndex = 41
		Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'ComboTipoMovimientoCaja
		'
		Me.ComboTipoMovimientoCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.ComboTipoMovimientoCaja.Location = New System.Drawing.Point(136, 48)
		Me.ComboTipoMovimientoCaja.Name = "ComboTipoMovimientoCaja"
		Me.ComboTipoMovimientoCaja.Size = New System.Drawing.Size(248, 21)
		Me.ComboTipoMovimientoCaja.TabIndex = 39
		Me.ComboTipoMovimientoCaja.Visible = False
		'
		'lblFOperacion
		'
		Me.lblFOperacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFOperacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFOperacion.ForeColor = System.Drawing.Color.Black
		Me.lblFOperacion.Location = New System.Drawing.Point(136, 96)
		Me.lblFOperacion.Name = "lblFOperacion"
		Me.lblFOperacion.Size = New System.Drawing.Size(248, 21)
		Me.lblFOperacion.TabIndex = 37
		Me.lblFOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblTipoMovimientoCaja
		'
		Me.lblTipoMovimientoCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTipoMovimientoCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTipoMovimientoCaja.ForeColor = System.Drawing.Color.Black
		Me.lblTipoMovimientoCaja.Location = New System.Drawing.Point(136, 48)
		Me.lblTipoMovimientoCaja.Name = "lblTipoMovimientoCaja"
		Me.lblTipoMovimientoCaja.Size = New System.Drawing.Size(248, 21)
		Me.lblTipoMovimientoCaja.TabIndex = 36
		Me.lblTipoMovimientoCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblRuta
		'
		Me.lblRuta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblRuta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRuta.ForeColor = System.Drawing.Color.Black
		Me.lblRuta.Location = New System.Drawing.Point(136, 144)
		Me.lblRuta.Name = "lblRuta"
		Me.lblRuta.Size = New System.Drawing.Size(248, 21)
		Me.lblRuta.TabIndex = 35
		Me.lblRuta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblFechaAlta
		'
		Me.lblFechaAlta.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFechaAlta.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFechaAlta.ForeColor = System.Drawing.Color.Black
		Me.lblFechaAlta.Location = New System.Drawing.Point(136, 72)
		Me.lblFechaAlta.Name = "lblFechaAlta"
		Me.lblFechaAlta.Size = New System.Drawing.Size(248, 21)
		Me.lblFechaAlta.TabIndex = 34
		Me.lblFechaAlta.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'lblNombreEmpleado
		'
		Me.lblNombreEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblNombreEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblNombreEmpleado.ForeColor = System.Drawing.Color.Black
		Me.lblNombreEmpleado.Location = New System.Drawing.Point(136, 168)
		Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
		Me.lblNombreEmpleado.Size = New System.Drawing.Size(248, 21)
		Me.lblNombreEmpleado.TabIndex = 33
		Me.lblNombreEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'dtpFMovimiento
		'
		Me.dtpFMovimiento.Enabled = False
		Me.dtpFMovimiento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.dtpFMovimiento.Location = New System.Drawing.Point(136, 120)
		Me.dtpFMovimiento.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
		Me.dtpFMovimiento.MinDate = New Date(2002, 1, 1, 0, 0, 0, 0)
		Me.dtpFMovimiento.Name = "dtpFMovimiento"
		Me.dtpFMovimiento.Size = New System.Drawing.Size(248, 21)
		Me.dtpFMovimiento.TabIndex = 40
		Me.dtpFMovimiento.Value = New Date(2002, 11, 29, 0, 0, 0, 0)
		'
		'LabelBase13
		'
		Me.LabelBase13.AutoSize = True
		Me.LabelBase13.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase13.Location = New System.Drawing.Point(16, 27)
		Me.LabelBase13.Name = "LabelBase13"
		Me.LabelBase13.Size = New System.Drawing.Size(121, 13)
		Me.LabelBase13.TabIndex = 42
		Me.LabelBase13.Text = "Estatus del movimiento:"
		'
		'LabelBase2
		'
		Me.LabelBase2.AutoSize = True
		Me.LabelBase2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase2.Location = New System.Drawing.Point(16, 123)
		Me.LabelBase2.Name = "LabelBase2"
		Me.LabelBase2.Size = New System.Drawing.Size(112, 13)
		Me.LabelBase2.TabIndex = 40
		Me.LabelBase2.Text = "Fecha de movimiento:"
		'
		'LabelBase8
		'
		Me.LabelBase8.AutoSize = True
		Me.LabelBase8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase8.Location = New System.Drawing.Point(16, 51)
		Me.LabelBase8.Name = "LabelBase8"
		Me.LabelBase8.Size = New System.Drawing.Size(103, 13)
		Me.LabelBase8.TabIndex = 38
		Me.LabelBase8.Text = "Tipo de movimiento:"
		'
		'lblEmpleado2
		'
		Me.lblEmpleado2.AutoSize = True
		Me.lblEmpleado2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblEmpleado2.Location = New System.Drawing.Point(16, 171)
		Me.lblEmpleado2.Name = "lblEmpleado2"
		Me.lblEmpleado2.Size = New System.Drawing.Size(57, 13)
		Me.lblEmpleado2.TabIndex = 32
		Me.lblEmpleado2.Text = "Empleado:"
		'
		'Label30
		'
		Me.Label30.AutoSize = True
		Me.Label30.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label30.Location = New System.Drawing.Point(16, 147)
		Me.Label30.Name = "Label30"
		Me.Label30.Size = New System.Drawing.Size(99, 13)
		Me.Label30.TabIndex = 24
		Me.Label30.Text = "Ruta pre-liquidada:"
		'
		'lblFecha
		'
		Me.lblFecha.AutoSize = True
		Me.lblFecha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFecha.Location = New System.Drawing.Point(16, 99)
		Me.lblFecha.Name = "lblFecha"
		Me.lblFecha.Size = New System.Drawing.Size(105, 13)
		Me.lblFecha.TabIndex = 23
		Me.lblFecha.Text = "Fecha de operación:"
		'
		'lblFechaAlta2
		'
		Me.lblFechaAlta2.AutoSize = True
		Me.lblFechaAlta2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFechaAlta2.Location = New System.Drawing.Point(16, 75)
		Me.lblFechaAlta2.Name = "lblFechaAlta2"
		Me.lblFechaAlta2.Size = New System.Drawing.Size(95, 13)
		Me.lblFechaAlta2.TabIndex = 28
		Me.lblFechaAlta2.Text = "Fecha de registro:"
		'
		'grpDatosMovimiento
		'
		Me.grpDatosMovimiento.Controls.Add(Me.lnkConsultaIVA)
		Me.grpDatosMovimiento.Controls.Add(Me.grpCobroEficiencia)
		Me.grpDatosMovimiento.Controls.Add(Me.lblImporteMovimiento)
		Me.grpDatosMovimiento.Controls.Add(Me.lblImporteCobranza2)
		Me.grpDatosMovimiento.Controls.Add(Me.btnConsultaDocumentos)
		Me.grpDatosMovimiento.Location = New System.Drawing.Point(8, 368)
		Me.grpDatosMovimiento.Name = "grpDatosMovimiento"
		Me.grpDatosMovimiento.Size = New System.Drawing.Size(392, 160)
		Me.grpDatosMovimiento.TabIndex = 38
		Me.grpDatosMovimiento.TabStop = False
		Me.grpDatosMovimiento.Text = "Datos del movimiento"
		'
		'lnkConsultaIVA
		'
		Me.lnkConsultaIVA.AutoSize = True
		Me.lnkConsultaIVA.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lnkConsultaIVA.Location = New System.Drawing.Point(140, 136)
		Me.lnkConsultaIVA.Name = "lnkConsultaIVA"
		Me.lnkConsultaIVA.Size = New System.Drawing.Size(220, 13)
		Me.lnkConsultaIVA.TabIndex = 30
		Me.lnkConsultaIVA.TabStop = True
		Me.lnkConsultaIVA.Text = "Consulta de importes por precio e IVA"
		Me.lnkConsultaIVA.Visible = False
		'
		'grpCobroEficiencia
		'
		Me.grpCobroEficiencia.Controls.Add(Me.chkIncluirEficiencia)
		Me.grpCobroEficiencia.Location = New System.Drawing.Point(272, 192)
		Me.grpCobroEficiencia.Name = "grpCobroEficiencia"
		Me.grpCobroEficiencia.Size = New System.Drawing.Size(40, 16)
		Me.grpCobroEficiencia.TabIndex = 29
		Me.grpCobroEficiencia.TabStop = False
		Me.grpCobroEficiencia.Text = "Cobro de la eficiencia"
		Me.grpCobroEficiencia.Visible = False
		'
		'chkIncluirEficiencia
		'
		Me.chkIncluirEficiencia.Enabled = False
		Me.chkIncluirEficiencia.Location = New System.Drawing.Point(24, 16)
		Me.chkIncluirEficiencia.Name = "chkIncluirEficiencia"
		Me.chkIncluirEficiencia.Size = New System.Drawing.Size(264, 24)
		Me.chkIncluirEficiencia.TabIndex = 28
		Me.chkIncluirEficiencia.Text = "Incluir el importe de la eficiencia en el total"
		'
		'lblImporteMovimiento
		'
		Me.lblImporteMovimiento.BackColor = System.Drawing.Color.Khaki
		Me.lblImporteMovimiento.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblImporteMovimiento.Font = New System.Drawing.Font("Tahoma", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblImporteMovimiento.ForeColor = System.Drawing.Color.Blue
		Me.lblImporteMovimiento.Location = New System.Drawing.Point(128, 32)
		Me.lblImporteMovimiento.Name = "lblImporteMovimiento"
		Me.lblImporteMovimiento.Size = New System.Drawing.Size(240, 48)
		Me.lblImporteMovimiento.TabIndex = 27
		Me.lblImporteMovimiento.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblImporteCobranza2
		'
		Me.lblImporteCobranza2.AutoSize = True
		Me.lblImporteCobranza2.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblImporteCobranza2.ForeColor = System.Drawing.Color.Blue
		Me.lblImporteCobranza2.Location = New System.Drawing.Point(16, 40)
		Me.lblImporteCobranza2.Name = "lblImporteCobranza2"
		Me.lblImporteCobranza2.Size = New System.Drawing.Size(106, 25)
		Me.lblImporteCobranza2.TabIndex = 25
		Me.lblImporteCobranza2.Text = "Importe:"
		'
		'grpCobroVale
		'
		Me.grpCobroVale.BackColor = System.Drawing.Color.Gainsboro
		Me.grpCobroVale.Controls.Add(Me.RegistroValeCredito1)
		Me.grpCobroVale.Controls.Add(Me.Vales)
		Me.grpCobroVale.Controls.Add(Me.lblNoTieneVales)
		Me.grpCobroVale.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grpCobroVale.Location = New System.Drawing.Point(160, 24)
		Me.grpCobroVale.Name = "grpCobroVale"
		Me.grpCobroVale.Size = New System.Drawing.Size(152, 464)
		Me.grpCobroVale.TabIndex = 35
		Me.grpCobroVale.TabStop = False
		Me.grpCobroVale.Text = "Vales de despensa (F4)"
		'
		'RegistroValeCredito1
		'
		Me.RegistroValeCredito1.Location = New System.Drawing.Point(8, 388)
		Me.RegistroValeCredito1.Name = "RegistroValeCredito1"
		Me.RegistroValeCredito1.Size = New System.Drawing.Size(136, 68)
		Me.RegistroValeCredito1.TabIndex = 4
		'
		'Vales
		'
		Me.Vales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Vales.Location = New System.Drawing.Point(8, 32)
		Me.Vales.Name = "Vales"
		Me.Vales.Size = New System.Drawing.Size(132, 376)
		Me.Vales.TabIndex = 0
		Me.Vales.V1 = CType(0, Short)
		Me.Vales.V10 = CType(0, Short)
		Me.Vales.V100 = CType(0, Short)
		Me.Vales.V15 = CType(0, Short)
		Me.Vales.V2 = CType(0, Short)
		Me.Vales.V20 = CType(0, Short)
		Me.Vales.V25 = CType(0, Short)
		Me.Vales.V3 = CType(0, Short)
		Me.Vales.V30 = CType(0, Short)
		Me.Vales.V35 = CType(0, Short)
		Me.Vales.V4 = CType(0, Short)
		Me.Vales.V5 = CType(0, Short)
		Me.Vales.V50 = CType(0, Short)
		'
		'lblNoTieneVales
		'
		Me.lblNoTieneVales.Location = New System.Drawing.Point(16, 184)
		Me.lblNoTieneVales.Name = "lblNoTieneVales"
		Me.lblNoTieneVales.Size = New System.Drawing.Size(128, 56)
		Me.lblNoTieneVales.TabIndex = 3
		Me.lblNoTieneVales.Text = "El movimiento no tiene vales relacionados"
		Me.lblNoTieneVales.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lblNoTieneVales.Visible = False
		'
		'grpCobroCheque
		'
		Me.grpCobroCheque.Controls.Add(Me.lnkConsultaCheques)
		Me.grpCobroCheque.Controls.Add(Me.grdCheque)
		Me.grpCobroCheque.Controls.Add(Me.lblNoTieneCheques)
		Me.grpCobroCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grpCobroCheque.Location = New System.Drawing.Point(320, 24)
		Me.grpCobroCheque.Name = "grpCobroCheque"
		Me.grpCobroCheque.Size = New System.Drawing.Size(288, 152)
		Me.grpCobroCheque.TabIndex = 36
		Me.grpCobroCheque.TabStop = False
		Me.grpCobroCheque.Text = "Cheque"
		'
		'lnkConsultaCheques
		'
		Me.lnkConsultaCheques.AutoSize = True
		Me.lnkConsultaCheques.Location = New System.Drawing.Point(160, 16)
		Me.lnkConsultaCheques.Name = "lnkConsultaCheques"
		Me.lnkConsultaCheques.Size = New System.Drawing.Size(123, 13)
		Me.lnkConsultaCheques.TabIndex = 1
		Me.lnkConsultaCheques.TabStop = True
		Me.lnkConsultaCheques.Text = "Ver datos completos"
		'
		'grdCheque
		'
		Me.grdCheque.BackgroundColor = System.Drawing.Color.Gainsboro
		Me.grdCheque.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
		Me.grdCheque.CaptionText = "Cheques en este movimiento"
		Me.grdCheque.DataMember = ""
		Me.grdCheque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grdCheque.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.grdCheque.Location = New System.Drawing.Point(8, 32)
		Me.grdCheque.Name = "grdCheque"
		Me.grdCheque.ReadOnly = True
		Me.grdCheque.Size = New System.Drawing.Size(272, 112)
		Me.grdCheque.TabIndex = 0
		Me.grdCheque.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloCheques})
		'
		'EstiloCheques
		'
		Me.EstiloCheques.DataGrid = Me.grdCheque
		Me.EstiloCheques.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colChTipoCobro, Me.colChNumeroCheque, Me.colChBancoNombre, Me.colChTotal, Me.colChSaldo})
		Me.EstiloCheques.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.EstiloCheques.MappingName = "Cheques"
		'
		'colChTipoCobro
		'
		Me.colChTipoCobro.Format = ""
		Me.colChTipoCobro.FormatInfo = Nothing
		Me.colChTipoCobro.HeaderText = "Tipo"
		Me.colChTipoCobro.MappingName = "TipoCobro"
		Me.colChTipoCobro.Width = 0
		'
		'colChNumeroCheque
		'
		Me.colChNumeroCheque.Format = ""
		Me.colChNumeroCheque.FormatInfo = Nothing
		Me.colChNumeroCheque.HeaderText = "No. Cheque"
		Me.colChNumeroCheque.MappingName = "NumeroCheque"
		Me.colChNumeroCheque.Width = 0
		'
		'colChBancoNombre
		'
		Me.colChBancoNombre.Format = ""
		Me.colChBancoNombre.FormatInfo = Nothing
		Me.colChBancoNombre.HeaderText = "Banco"
		Me.colChBancoNombre.MappingName = "BancoNombre"
		Me.colChBancoNombre.Width = 60
		'
		'colChTotal
		'
		Me.colChTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colChTotal.Format = "#,##.00"
		Me.colChTotal.FormatInfo = Nothing
		Me.colChTotal.HeaderText = "Total"
		Me.colChTotal.MappingName = "Total"
		Me.colChTotal.Width = 75
		'
		'colChSaldo
		'
		Me.colChSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colChSaldo.Format = "#,##.00"
		Me.colChSaldo.FormatInfo = Nothing
		Me.colChSaldo.HeaderText = "Saldo"
		Me.colChSaldo.MappingName = "Saldo"
		Me.colChSaldo.Width = 75
		'
		'lblNoTieneCheques
		'
		Me.lblNoTieneCheques.Location = New System.Drawing.Point(80, 56)
		Me.lblNoTieneCheques.Name = "lblNoTieneCheques"
		Me.lblNoTieneCheques.Size = New System.Drawing.Size(144, 56)
		Me.lblNoTieneCheques.TabIndex = 2
		Me.lblNoTieneCheques.Text = "El movimiento no tiene cheques relacionados"
		Me.lblNoTieneCheques.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'grpCobroEfectivo
		'
		Me.grpCobroEfectivo.BackColor = System.Drawing.Color.Gainsboro
		Me.grpCobroEfectivo.Controls.Add(Me.CobroEfectivo)
		Me.grpCobroEfectivo.Controls.Add(Me.lblPorCobrarVales)
		Me.grpCobroEfectivo.Controls.Add(Me.lblPorCobrarEfectivo)
		Me.grpCobroEfectivo.Controls.Add(Me.LabelBase3)
		Me.grpCobroEfectivo.Controls.Add(Me.LabelBase1)
		Me.grpCobroEfectivo.Controls.Add(Me.lblNoTieneEfectivo)
		Me.grpCobroEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grpCobroEfectivo.Location = New System.Drawing.Point(8, 24)
		Me.grpCobroEfectivo.Name = "grpCobroEfectivo"
		Me.grpCobroEfectivo.Size = New System.Drawing.Size(152, 464)
		Me.grpCobroEfectivo.TabIndex = 34
		Me.grpCobroEfectivo.TabStop = False
		Me.grpCobroEfectivo.Text = "Efectivo (F3)"
		'
		'CobroEfectivo
		'
		Me.CobroEfectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.CobroEfectivo.Location = New System.Drawing.Point(8, 32)
		Me.CobroEfectivo.M1 = CType(0, Short)
		Me.CobroEfectivo.M10 = CType(0, Short)
		Me.CobroEfectivo.M100 = CType(0, Short)
		Me.CobroEfectivo.M1000 = CType(0, Short)
		Me.CobroEfectivo.M10c = CType(0, Short)
		Me.CobroEfectivo.M2 = CType(0, Short)
		Me.CobroEfectivo.M20 = CType(0, Short)
		Me.CobroEfectivo.M200 = CType(0, Short)
		Me.CobroEfectivo.M20c = CType(0, Short)
		Me.CobroEfectivo.M5 = CType(0, Short)
		Me.CobroEfectivo.M50 = CType(0, Short)
		Me.CobroEfectivo.M500 = CType(0, Short)
		Me.CobroEfectivo.M50c = CType(0, Short)
		Me.CobroEfectivo.M5c = CType(0, Short)
		Me.CobroEfectivo.Morralla = 0R
		Me.CobroEfectivo.Name = "CobroEfectivo"
		Me.CobroEfectivo.Size = New System.Drawing.Size(136, 404)
		Me.CobroEfectivo.TabIndex = 50
		'
		'lblPorCobrarVales
		'
		Me.lblPorCobrarVales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPorCobrarVales.ForeColor = System.Drawing.Color.MediumBlue
		Me.lblPorCobrarVales.Location = New System.Drawing.Point(56, 432)
		Me.lblPorCobrarVales.Name = "lblPorCobrarVales"
		Me.lblPorCobrarVales.Size = New System.Drawing.Size(88, 16)
		Me.lblPorCobrarVales.TabIndex = 41
		Me.lblPorCobrarVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.lblPorCobrarVales.Visible = False
		'
		'lblPorCobrarEfectivo
		'
		Me.lblPorCobrarEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblPorCobrarEfectivo.ForeColor = System.Drawing.Color.MediumBlue
		Me.lblPorCobrarEfectivo.Location = New System.Drawing.Point(56, 432)
		Me.lblPorCobrarEfectivo.Name = "lblPorCobrarEfectivo"
		Me.lblPorCobrarEfectivo.Size = New System.Drawing.Size(88, 16)
		Me.lblPorCobrarEfectivo.TabIndex = 40
		Me.lblPorCobrarEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		Me.lblPorCobrarEfectivo.Visible = False
		'
		'LabelBase3
		'
		Me.LabelBase3.AutoSize = True
		Me.LabelBase3.Location = New System.Drawing.Point(64, 432)
		Me.LabelBase3.Name = "LabelBase3"
		Me.LabelBase3.Size = New System.Drawing.Size(40, 13)
		Me.LabelBase3.TabIndex = 49
		Me.LabelBase3.Text = "Vales:"
		Me.LabelBase3.Visible = False
		'
		'LabelBase1
		'
		Me.LabelBase1.AutoSize = True
		Me.LabelBase1.Location = New System.Drawing.Point(64, 432)
		Me.LabelBase1.Name = "LabelBase1"
		Me.LabelBase1.Size = New System.Drawing.Size(55, 13)
		Me.LabelBase1.TabIndex = 48
		Me.LabelBase1.Text = "Efectivo:"
		Me.LabelBase1.Visible = False
		'
		'lblNoTieneEfectivo
		'
		Me.lblNoTieneEfectivo.Location = New System.Drawing.Point(16, 184)
		Me.lblNoTieneEfectivo.Name = "lblNoTieneEfectivo"
		Me.lblNoTieneEfectivo.Size = New System.Drawing.Size(120, 56)
		Me.lblNoTieneEfectivo.TabIndex = 34
		Me.lblNoTieneEfectivo.Text = "El movimiento no tiene efectivo relacionado"
		Me.lblNoTieneEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		Me.lblNoTieneEfectivo.Visible = False
		'
		'grpCobroDocumentos
		'
		Me.grpCobroDocumentos.Controls.Add(Me.LabelBase14)
		Me.grpCobroDocumentos.Controls.Add(Me.lblTotalVale)
		Me.grpCobroDocumentos.Controls.Add(Me.lblCaptAFAvor)
		Me.grpCobroDocumentos.Controls.Add(Me.LabelBase15)
		Me.grpCobroDocumentos.Controls.Add(Me.lblRealEfectivoVales)
		Me.grpCobroDocumentos.Controls.Add(Me.lblAFavorOperadorCheques)
		Me.grpCobroDocumentos.Controls.Add(Me.lblTotalVarios)
		Me.grpCobroDocumentos.Controls.Add(Me.LabelBase12)
		Me.grpCobroDocumentos.Controls.Add(Me.lblTotalTarjetaDebito)
		Me.grpCobroDocumentos.Controls.Add(Me.LabelBase7)
		Me.grpCobroDocumentos.Controls.Add(Me.grpCobroFicha)
		Me.grpCobroDocumentos.Controls.Add(Me.lblTotalTarjetaCredito)
		Me.grpCobroDocumentos.Controls.Add(Me.LabelBase6)
		Me.grpCobroDocumentos.Controls.Add(Me.grpCobroTC)
		Me.grpCobroDocumentos.Controls.Add(Me.btnCambio)
		Me.grpCobroDocumentos.Controls.Add(Me.grpCobroVale)
		Me.grpCobroDocumentos.Controls.Add(Me.grpCobroCheque)
		Me.grpCobroDocumentos.Controls.Add(Me.grpCobroEfectivo)
		Me.grpCobroDocumentos.Controls.Add(Me.Panel1)
		Me.grpCobroDocumentos.Controls.Add(Me.lblTotalEfectivo)
		Me.grpCobroDocumentos.Controls.Add(Me.lblTotalCheques)
		Me.grpCobroDocumentos.Controls.Add(Me.LabelBase5)
		Me.grpCobroDocumentos.Controls.Add(Me.LabelBase4)
		Me.grpCobroDocumentos.Controls.Add(Me.LinkLabel1)
		Me.grpCobroDocumentos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grpCobroDocumentos.Location = New System.Drawing.Point(400, 72)
		Me.grpCobroDocumentos.Name = "grpCobroDocumentos"
		Me.grpCobroDocumentos.Size = New System.Drawing.Size(616, 624)
		Me.grpCobroDocumentos.TabIndex = 34
		Me.grpCobroDocumentos.TabStop = False
		Me.grpCobroDocumentos.Text = "Cobro de documentos"
		'
		'LabelBase14
		'
		Me.LabelBase14.AutoSize = True
		Me.LabelBase14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase14.Location = New System.Drawing.Point(26, 601)
		Me.LabelBase14.Name = "LabelBase14"
		Me.LabelBase14.Size = New System.Drawing.Size(31, 13)
		Me.LabelBase14.TabIndex = 67
		Me.LabelBase14.Text = "Vale:"
		'
		'lblTotalVale
		'
		Me.lblTotalVale.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalVale.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalVale.Location = New System.Drawing.Point(64, 601)
		Me.lblTotalVale.Name = "lblTotalVale"
		Me.lblTotalVale.Size = New System.Drawing.Size(80, 16)
		Me.lblTotalVale.TabIndex = 66
		Me.lblTotalVale.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblCaptAFAvor
		'
		Me.lblCaptAFAvor.Location = New System.Drawing.Point(148, 492)
		Me.lblCaptAFAvor.Name = "lblCaptAFAvor"
		Me.lblCaptAFAvor.Size = New System.Drawing.Size(96, 40)
		Me.lblCaptAFAvor.TabIndex = 65
		Me.lblCaptAFAvor.Text = "A favor operador:"
		Me.lblCaptAFAvor.TextAlign = System.Drawing.ContentAlignment.BottomCenter
		'
		'LabelBase15
		'
		Me.LabelBase15.AutoSize = True
		Me.LabelBase15.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase15.Location = New System.Drawing.Point(186, 568)
		Me.LabelBase15.Name = "LabelBase15"
		Me.LabelBase15.Size = New System.Drawing.Size(54, 13)
		Me.LabelBase15.TabIndex = 64
		Me.LabelBase15.Text = "Real E.V."
		'
		'lblRealEfectivoVales
		'
		Me.lblRealEfectivoVales.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblRealEfectivoVales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblRealEfectivoVales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblRealEfectivoVales.ForeColor = System.Drawing.Color.Blue
		Me.lblRealEfectivoVales.Location = New System.Drawing.Point(152, 584)
		Me.lblRealEfectivoVales.Name = "lblRealEfectivoVales"
		Me.lblRealEfectivoVales.Size = New System.Drawing.Size(88, 16)
		Me.lblRealEfectivoVales.TabIndex = 63
		Me.lblRealEfectivoVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblAFavorOperadorCheques
		'
		Me.lblAFavorOperadorCheques.BackColor = System.Drawing.Color.Gainsboro
		Me.lblAFavorOperadorCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblAFavorOperadorCheques.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblAFavorOperadorCheques.Location = New System.Drawing.Point(152, 536)
		Me.lblAFavorOperadorCheques.Name = "lblAFavorOperadorCheques"
		Me.lblAFavorOperadorCheques.Size = New System.Drawing.Size(88, 16)
		Me.lblAFavorOperadorCheques.TabIndex = 61
		Me.lblAFavorOperadorCheques.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblTotalVarios
		'
		Me.lblTotalVarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalVarios.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalVarios.Location = New System.Drawing.Point(64, 584)
		Me.lblTotalVarios.Name = "lblTotalVarios"
		Me.lblTotalVarios.Size = New System.Drawing.Size(80, 16)
		Me.lblTotalVarios.TabIndex = 59
		Me.lblTotalVarios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'LabelBase12
		'
		Me.LabelBase12.AutoSize = True
		Me.LabelBase12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase12.Location = New System.Drawing.Point(18, 584)
		Me.LabelBase12.Name = "LabelBase12"
		Me.LabelBase12.Size = New System.Drawing.Size(39, 13)
		Me.LabelBase12.TabIndex = 60
		Me.LabelBase12.Text = "Varios:"
		'
		'lblTotalTarjetaDebito
		'
		Me.lblTotalTarjetaDebito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalTarjetaDebito.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalTarjetaDebito.Location = New System.Drawing.Point(64, 568)
		Me.lblTotalTarjetaDebito.Name = "lblTotalTarjetaDebito"
		Me.lblTotalTarjetaDebito.Size = New System.Drawing.Size(80, 16)
		Me.lblTotalTarjetaDebito.TabIndex = 57
		Me.lblTotalTarjetaDebito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'LabelBase7
		'
		Me.LabelBase7.AutoSize = True
		Me.LabelBase7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase7.Location = New System.Drawing.Point(3, 568)
		Me.LabelBase7.Name = "LabelBase7"
		Me.LabelBase7.Size = New System.Drawing.Size(54, 13)
		Me.LabelBase7.TabIndex = 58
		Me.LabelBase7.Text = "T. Débito:"
		'
		'grpCobroFicha
		'
		Me.grpCobroFicha.Controls.Add(Me.grdFichaDeposito)
		Me.grpCobroFicha.Controls.Add(Me.lnkConsultaFichaDeposito)
		Me.grpCobroFicha.Controls.Add(Me.Label3)
		Me.grpCobroFicha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grpCobroFicha.Location = New System.Drawing.Point(320, 176)
		Me.grpCobroFicha.Name = "grpCobroFicha"
		Me.grpCobroFicha.Size = New System.Drawing.Size(288, 160)
		Me.grpCobroFicha.TabIndex = 56
		Me.grpCobroFicha.TabStop = False
		Me.grpCobroFicha.Text = "Varios(Transferencias, Aplicación de anticipos, Dación)"
		'
		'grdFichaDeposito
		'
		Me.grdFichaDeposito.BackgroundColor = System.Drawing.Color.Gainsboro
		Me.grdFichaDeposito.CaptionBackColor = System.Drawing.Color.SteelBlue
		Me.grdFichaDeposito.CaptionText = "Lista de documentos"
		Me.grdFichaDeposito.DataMember = ""
		Me.grdFichaDeposito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grdFichaDeposito.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.grdFichaDeposito.Location = New System.Drawing.Point(8, 32)
		Me.grdFichaDeposito.Name = "grdFichaDeposito"
		Me.grdFichaDeposito.ReadOnly = True
		Me.grdFichaDeposito.Size = New System.Drawing.Size(272, 120)
		Me.grdFichaDeposito.TabIndex = 0
		Me.grdFichaDeposito.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloFicha})
		'
		'EstiloFicha
		'
		Me.EstiloFicha.DataGrid = Me.grdFichaDeposito
		Me.EstiloFicha.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colTipoCobro, Me.colDocumento, Me.colTotal, Me.colSaldo})
		Me.EstiloFicha.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.EstiloFicha.MappingName = "FichaDeposito"
		Me.EstiloFicha.RowHeadersVisible = False
		'
		'colTipoCobro
		'
		Me.colTipoCobro.Format = ""
		Me.colTipoCobro.FormatInfo = Nothing
		Me.colTipoCobro.HeaderText = "Tipo"
		Me.colTipoCobro.MappingName = "TipoCobroDescripcion"
		Me.colTipoCobro.Width = 110
		'
		'colDocumento
		'
		Me.colDocumento.Format = ""
		Me.colDocumento.FormatInfo = Nothing
		Me.colDocumento.HeaderText = "Documento"
		Me.colDocumento.MappingName = "Documento"
		Me.colDocumento.NullText = ""
		Me.colDocumento.Width = 0
		'
		'colTotal
		'
		Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colTotal.Format = "#,##.00"
		Me.colTotal.FormatInfo = Nothing
		Me.colTotal.HeaderText = "Total"
		Me.colTotal.MappingName = "Total"
		Me.colTotal.Width = 75
		'
		'colSaldo
		'
		Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
		Me.colSaldo.Format = "#,##.00"
		Me.colSaldo.FormatInfo = Nothing
		Me.colSaldo.HeaderText = "Saldo"
		Me.colSaldo.MappingName = "Saldo"
		Me.colSaldo.Width = 75
		'
		'lnkConsultaFichaDeposito
		'
		Me.lnkConsultaFichaDeposito.AutoSize = True
		Me.lnkConsultaFichaDeposito.Location = New System.Drawing.Point(160, 16)
		Me.lnkConsultaFichaDeposito.Name = "lnkConsultaFichaDeposito"
		Me.lnkConsultaFichaDeposito.Size = New System.Drawing.Size(123, 13)
		Me.lnkConsultaFichaDeposito.TabIndex = 4
		Me.lnkConsultaFichaDeposito.TabStop = True
		Me.lnkConsultaFichaDeposito.Text = "Ver datos completos"
		'
		'Label3
		'
		Me.Label3.Location = New System.Drawing.Point(80, 64)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(144, 56)
		Me.Label3.TabIndex = 5
		Me.Label3.Text = "El movimiento no tiene cobros con ficha de depósito"
		Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'lblTotalTarjetaCredito
		'
		Me.lblTotalTarjetaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalTarjetaCredito.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalTarjetaCredito.Location = New System.Drawing.Point(64, 552)
		Me.lblTotalTarjetaCredito.Name = "lblTotalTarjetaCredito"
		Me.lblTotalTarjetaCredito.Size = New System.Drawing.Size(80, 16)
		Me.lblTotalTarjetaCredito.TabIndex = 53
		Me.lblTotalTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'LabelBase6
		'
		Me.LabelBase6.AutoSize = True
		Me.LabelBase6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase6.Location = New System.Drawing.Point(4, 552)
		Me.LabelBase6.Name = "LabelBase6"
		Me.LabelBase6.Size = New System.Drawing.Size(53, 13)
		Me.LabelBase6.TabIndex = 54
		Me.LabelBase6.Text = "T.Crédito:"
		'
		'grpCobroTC
		'
		Me.grpCobroTC.Controls.Add(Me.grdTarjetaCredito)
		Me.grpCobroTC.Controls.Add(Me.lnkConsultaTarjetaCredito)
		Me.grpCobroTC.Controls.Add(Me.Label2)
		Me.grpCobroTC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grpCobroTC.Location = New System.Drawing.Point(320, 336)
		Me.grpCobroTC.Name = "grpCobroTC"
		Me.grpCobroTC.Size = New System.Drawing.Size(288, 152)
		Me.grpCobroTC.TabIndex = 52
		Me.grpCobroTC.TabStop = False
		Me.grpCobroTC.Text = "Tarjeta"
		'
		'grdTarjetaCredito
		'
		Me.grdTarjetaCredito.BackgroundColor = System.Drawing.Color.Gainsboro
		Me.grdTarjetaCredito.CaptionBackColor = System.Drawing.Color.Brown
		Me.grdTarjetaCredito.CaptionText = "Cobro con tarjeta de crédito"
		Me.grdTarjetaCredito.DataMember = ""
		Me.grdTarjetaCredito.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.grdTarjetaCredito.Location = New System.Drawing.Point(8, 32)
		Me.grdTarjetaCredito.Name = "grdTarjetaCredito"
		Me.grdTarjetaCredito.ReadOnly = True
		Me.grdTarjetaCredito.Size = New System.Drawing.Size(272, 112)
		Me.grdTarjetaCredito.TabIndex = 3
		'
		'lnkConsultaTarjetaCredito
		'
		Me.lnkConsultaTarjetaCredito.AutoSize = True
		Me.lnkConsultaTarjetaCredito.Location = New System.Drawing.Point(160, 16)
		Me.lnkConsultaTarjetaCredito.Name = "lnkConsultaTarjetaCredito"
		Me.lnkConsultaTarjetaCredito.Size = New System.Drawing.Size(123, 13)
		Me.lnkConsultaTarjetaCredito.TabIndex = 1
		Me.lnkConsultaTarjetaCredito.TabStop = True
		Me.lnkConsultaTarjetaCredito.Text = "Ver datos completos"
		'
		'Label2
		'
		Me.Label2.Location = New System.Drawing.Point(80, 56)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(144, 56)
		Me.Label2.TabIndex = 2
		Me.Label2.Text = "El movimiento no tiene cobros con tarjeta de crédito"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
		'
		'btnCambio
		'
		Me.btnCambio.BackColor = System.Drawing.SystemColors.Control
		Me.btnCambio.Image = CType(resources.GetObject("btnCambio.Image"), System.Drawing.Image)
		Me.btnCambio.ImageAlign = System.Drawing.ContentAlignment.TopCenter
		Me.btnCambio.Location = New System.Drawing.Point(248, 504)
		Me.btnCambio.Name = "btnCambio"
		Me.btnCambio.Size = New System.Drawing.Size(56, 112)
		Me.btnCambio.TabIndex = 46
		Me.btnCambio.Text = "Cambio"
		Me.btnCambio.UseVisualStyleBackColor = False
		'
		'Panel1
		'
		Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.Panel1.Controls.Add(Me.LabelBase11)
		Me.Panel1.Controls.Add(Me.lblFaltante)
		Me.Panel1.Controls.Add(Me.lblCambioEntregado)
		Me.Panel1.Controls.Add(Me.LabelBase10)
		Me.Panel1.Controls.Add(Me.lblCambio)
		Me.Panel1.Controls.Add(Me.lblCambio2)
		Me.Panel1.Controls.Add(Me.lblImporteTotalCobro)
		Me.Panel1.Controls.Add(Me.lblImporteTotalCobros)
		Me.Panel1.ForeColor = System.Drawing.SystemColors.ControlText
		Me.Panel1.Location = New System.Drawing.Point(312, 504)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Size = New System.Drawing.Size(296, 112)
		Me.Panel1.TabIndex = 45
		'
		'LabelBase11
		'
		Me.LabelBase11.AutoSize = True
		Me.LabelBase11.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase11.Location = New System.Drawing.Point(8, 37)
		Me.LabelBase11.Name = "LabelBase11"
		Me.LabelBase11.Size = New System.Drawing.Size(61, 14)
		Me.LabelBase11.TabIndex = 52
		Me.LabelBase11.Text = "Faltante:"
		'
		'lblFaltante
		'
		Me.lblFaltante.BackColor = System.Drawing.Color.Gainsboro
		Me.lblFaltante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblFaltante.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblFaltante.ForeColor = System.Drawing.Color.Red
		Me.lblFaltante.Location = New System.Drawing.Point(168, 32)
		Me.lblFaltante.Name = "lblFaltante"
		Me.lblFaltante.Size = New System.Drawing.Size(114, 24)
		Me.lblFaltante.TabIndex = 51
		Me.lblFaltante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblCambioEntregado
		'
		Me.lblCambioEntregado.BackColor = System.Drawing.Color.LemonChiffon
		Me.lblCambioEntregado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblCambioEntregado.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCambioEntregado.Location = New System.Drawing.Point(168, 80)
		Me.lblCambioEntregado.Name = "lblCambioEntregado"
		Me.lblCambioEntregado.Size = New System.Drawing.Size(114, 24)
		Me.lblCambioEntregado.TabIndex = 50
		Me.lblCambioEntregado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'LabelBase10
		'
		Me.LabelBase10.AutoSize = True
		Me.LabelBase10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase10.Location = New System.Drawing.Point(8, 85)
		Me.LabelBase10.Name = "LabelBase10"
		Me.LabelBase10.Size = New System.Drawing.Size(124, 14)
		Me.LabelBase10.TabIndex = 49
		Me.LabelBase10.Text = "Cambio entregado:"
		'
		'lblCambio
		'
		Me.lblCambio.BackColor = System.Drawing.Color.Gainsboro
		Me.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblCambio.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCambio.Location = New System.Drawing.Point(168, 56)
		Me.lblCambio.Name = "lblCambio"
		Me.lblCambio.Size = New System.Drawing.Size(114, 24)
		Me.lblCambio.TabIndex = 48
		Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblCambio2
		'
		Me.lblCambio2.AutoSize = True
		Me.lblCambio2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblCambio2.Location = New System.Drawing.Point(8, 61)
		Me.lblCambio2.Name = "lblCambio2"
		Me.lblCambio2.Size = New System.Drawing.Size(154, 14)
		Me.lblCambio2.TabIndex = 47
		Me.lblCambio2.Text = "Cambio del movimiento:"
		'
		'lblImporteTotalCobro
		'
		Me.lblImporteTotalCobro.BackColor = System.Drawing.Color.Khaki
		Me.lblImporteTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblImporteTotalCobro.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblImporteTotalCobro.ForeColor = System.Drawing.Color.Blue
		Me.lblImporteTotalCobro.Location = New System.Drawing.Point(168, 8)
		Me.lblImporteTotalCobro.Name = "lblImporteTotalCobro"
		Me.lblImporteTotalCobro.Size = New System.Drawing.Size(114, 24)
		Me.lblImporteTotalCobro.TabIndex = 46
		Me.lblImporteTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblImporteTotalCobros
		'
		Me.lblImporteTotalCobros.AutoSize = True
		Me.lblImporteTotalCobros.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblImporteTotalCobros.Location = New System.Drawing.Point(8, 13)
		Me.lblImporteTotalCobros.Name = "lblImporteTotalCobros"
		Me.lblImporteTotalCobros.Size = New System.Drawing.Size(159, 14)
		Me.lblImporteTotalCobros.TabIndex = 45
		Me.lblImporteTotalCobros.Text = "Importe total de cobros:"
		'
		'lblTotalEfectivo
		'
		Me.lblTotalEfectivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalEfectivo.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalEfectivo.Location = New System.Drawing.Point(64, 520)
		Me.lblTotalEfectivo.Name = "lblTotalEfectivo"
		Me.lblTotalEfectivo.Size = New System.Drawing.Size(80, 16)
		Me.lblTotalEfectivo.TabIndex = 47
		Me.lblTotalEfectivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'lblTotalCheques
		'
		Me.lblTotalCheques.BackColor = System.Drawing.Color.Gainsboro
		Me.lblTotalCheques.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
		Me.lblTotalCheques.ForeColor = System.Drawing.SystemColors.ControlText
		Me.lblTotalCheques.Location = New System.Drawing.Point(64, 536)
		Me.lblTotalCheques.Name = "lblTotalCheques"
		Me.lblTotalCheques.Size = New System.Drawing.Size(80, 16)
		Me.lblTotalCheques.TabIndex = 42
		Me.lblTotalCheques.TextAlign = System.Drawing.ContentAlignment.MiddleRight
		'
		'LabelBase5
		'
		Me.LabelBase5.AutoSize = True
		Me.LabelBase5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase5.Location = New System.Drawing.Point(8, 520)
		Me.LabelBase5.Name = "LabelBase5"
		Me.LabelBase5.Size = New System.Drawing.Size(49, 13)
		Me.LabelBase5.TabIndex = 51
		Me.LabelBase5.Text = "Efectivo:"
		'
		'LabelBase4
		'
		Me.LabelBase4.AutoSize = True
		Me.LabelBase4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelBase4.Location = New System.Drawing.Point(5, 536)
		Me.LabelBase4.Name = "LabelBase4"
		Me.LabelBase4.Size = New System.Drawing.Size(52, 13)
		Me.LabelBase4.TabIndex = 50
		Me.LabelBase4.Text = "Cheques:"
		'
		'LinkLabel1
		'
		Me.LinkLabel1.AutoSize = True
		Me.LinkLabel1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LinkLabel1.Location = New System.Drawing.Point(152, 604)
		Me.LinkLabel1.Name = "LinkLabel1"
		Me.LinkLabel1.Size = New System.Drawing.Size(68, 13)
		Me.LinkLabel1.TabIndex = 31
		Me.LinkLabel1.TabStop = True
		Me.LinkLabel1.Text = "Ver detalle"
		Me.ttMensaje.SetToolTip(Me.LinkLabel1, "Ver detalle de autocarburación y obsequios")
		Me.LinkLabel1.Visible = False
		'
		'lblTipoOperacion
		'
		Me.lblTipoOperacion.AutoSize = True
		Me.lblTipoOperacion.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblTipoOperacion.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblTipoOperacion.ForeColor = System.Drawing.Color.Green
		Me.lblTipoOperacion.Location = New System.Drawing.Point(8, 8)
		Me.lblTipoOperacion.Name = "lblTipoOperacion"
		Me.lblTipoOperacion.Size = New System.Drawing.Size(155, 19)
		Me.lblTipoOperacion.TabIndex = 39
		Me.lblTipoOperacion.Text = "Tipo de operación"
		'
		'lblMovimientoCajaClave
		'
		Me.lblMovimientoCajaClave.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblMovimientoCajaClave.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblMovimientoCajaClave.ForeColor = System.Drawing.Color.DarkGreen
		Me.lblMovimientoCajaClave.Location = New System.Drawing.Point(16, 32)
		Me.lblMovimientoCajaClave.Name = "lblMovimientoCajaClave"
		Me.lblMovimientoCajaClave.Size = New System.Drawing.Size(376, 32)
		Me.lblMovimientoCajaClave.TabIndex = 40
		'
		'Panel2
		'
		Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
			Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
		Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
		Me.Panel2.Controls.Add(Me.LabelNombreEmpresa1)
		Me.Panel2.Controls.Add(Me.PanelMensaje)
		Me.Panel2.Controls.Add(Me.lblMovimientoCajaClave)
		Me.Panel2.Controls.Add(Me.lblTipoOperacion)
		Me.Panel2.Location = New System.Drawing.Point(0, 0)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(1040, 72)
		Me.Panel2.TabIndex = 41
		'
		'LabelNombreEmpresa1
		'
		Me.LabelNombreEmpresa1.AutoSize = True
		Me.LabelNombreEmpresa1.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.LabelNombreEmpresa1.Location = New System.Drawing.Point(556, 36)
		Me.LabelNombreEmpresa1.Name = "LabelNombreEmpresa1"
		Me.LabelNombreEmpresa1.Size = New System.Drawing.Size(0, 19)
		Me.LabelNombreEmpresa1.TabIndex = 46
		Me.LabelNombreEmpresa1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		'
		'PanelMensaje
		'
		Me.PanelMensaje.Controls.Add(Me.lblPanelMensaje)
		Me.PanelMensaje.Controls.Add(Me.PictureBox1)
		Me.PanelMensaje.Location = New System.Drawing.Point(0, 32)
		Me.PanelMensaje.Name = "PanelMensaje"
		Me.PanelMensaje.Size = New System.Drawing.Size(480, 32)
		Me.PanelMensaje.TabIndex = 45
		Me.PanelMensaje.Visible = False
		'
		'lblPanelMensaje
		'
		Me.lblPanelMensaje.BackColor = System.Drawing.Color.WhiteSmoke
		Me.lblPanelMensaje.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.lblPanelMensaje.ForeColor = System.Drawing.Color.Red
		Me.lblPanelMensaje.Location = New System.Drawing.Point(32, 12)
		Me.lblPanelMensaje.Name = "lblPanelMensaje"
		Me.lblPanelMensaje.Size = New System.Drawing.Size(440, 16)
		Me.lblPanelMensaje.TabIndex = 44
		Me.lblPanelMensaje.Text = "La liquidación pertenece al día "
		Me.lblPanelMensaje.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
		Me.ttMensaje.SetToolTip(Me.lblPanelMensaje, "La liquidación pertenece a otro día.")
		'
		'PictureBox1
		'
		Me.PictureBox1.BackColor = System.Drawing.Color.WhiteSmoke
		Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
		Me.PictureBox1.Location = New System.Drawing.Point(8, 11)
		Me.PictureBox1.Name = "PictureBox1"
		Me.PictureBox1.Size = New System.Drawing.Size(18, 18)
		Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
		Me.PictureBox1.TabIndex = 45
		Me.PictureBox1.TabStop = False
		'
		'ttMensaje
		'
		Me.ttMensaje.Active = False
		'
		'frmCapMovimiento
		'
		Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
		Me.BackColor = System.Drawing.Color.Gainsboro
		Me.CancelButton = Me.btnCancelar
		Me.ClientSize = New System.Drawing.Size(1024, 701)
		Me.Controls.Add(Me.grpDatosMovimiento)
		Me.Controls.Add(Me.grpCabecera)
		Me.Controls.Add(Me.grpLiquidacionConsulta)
		Me.Controls.Add(Me.grpCobroDocumentos)
		Me.Controls.Add(Me.btnCancelar)
		Me.Controls.Add(Me.btnAceptar)
		Me.Controls.Add(Me.Panel2)
		Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
		Me.KeyPreview = True
		Me.MinimumSize = New System.Drawing.Size(560, 296)
		Me.Name = "frmCapMovimiento"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
		Me.Text = "Movimientos de Caja"
		Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
		Me.grpLiquidacionConsulta.ResumeLayout(False)
		Me.grpLiquidacionConsulta.PerformLayout()
		CType(Me.grdInfoPreLiq, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpCabecera.ResumeLayout(False)
		Me.grpCabecera.PerformLayout()
		CType(Me.picAviso, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpDatosMovimiento.ResumeLayout(False)
		Me.grpDatosMovimiento.PerformLayout()
		Me.grpCobroEficiencia.ResumeLayout(False)
		Me.grpCobroVale.ResumeLayout(False)
		Me.grpCobroCheque.ResumeLayout(False)
		Me.grpCobroCheque.PerformLayout()
		CType(Me.grdCheque, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpCobroEfectivo.ResumeLayout(False)
		Me.grpCobroEfectivo.PerformLayout()
		Me.grpCobroDocumentos.ResumeLayout(False)
		Me.grpCobroDocumentos.PerformLayout()
		Me.grpCobroFicha.ResumeLayout(False)
		Me.grpCobroFicha.PerformLayout()
		CType(Me.grdFichaDeposito, System.ComponentModel.ISupportInitialize).EndInit()
		Me.grpCobroTC.ResumeLayout(False)
		Me.grpCobroTC.PerformLayout()
		CType(Me.grdTarjetaCredito, System.ComponentModel.ISupportInitialize).EndInit()
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		Me.Panel2.PerformLayout()
		Me.PanelMensaje.ResumeLayout(False)
		CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

#End Region

#Region "Variables"

	Private Titulo As String
	Private MovimientoCajaClave As String
	Private TipoOperacion As TipoOperacionMovimientoCaja  'Indica el tipo de operacion que se está realizando.
	Private bytCaja As Byte
	Private dtmFOperacion As Date
	Private bytConsecutivo As Byte
	Private intFolio As Integer
	Private shrAnoCobro As Short
	Private intCobro As Integer
	Private dtmFAlta As Date
	Private RutaMovimiento As Short 'Es la ruta a la que le pertenece el movimiento
	Private AutotanqueTurno_AnoAtt As Short 'Dato del registro en AutotanqueTurno (Liquidacion)
	Private AutotanqueTurno_Folio As Integer 'Dato del registro en AutotanqueTurno (Liquidacion)
	Private TipoMovimientoCaja As Byte 'Tipo de movimiento que se está efectuando
	Private arrCambio As Array 'Arreglo para las denominaciones del cambio desglosado
	Private decImporteTotalMovimiento As Decimal 'Importe total del movimiento
	Private decImporteTotalCobros As Decimal 'Importe de la suma total de los cobros
	Private decImporteCambio As Decimal 'Importe del cambio que se genera del movimiento
	Private decImporteCambioDesglosado As Decimal
	Private decImporteRealACobrar As Decimal '20 de feb
	Private strNombreEmpleado As String 'Nombre del empleado que capturó el movimiento
	Private blnNotaIngreso As Boolean


	Private PorCobrarEfectivo As Decimal = 0
	Private PorCobrarVales As Decimal = 0
	Private AFavorVales As Decimal = 0
	Private PorCobrarCheques As Decimal = 0
	Private AFavorCheques As Decimal = 0
	Private AFavorOperadorCheques As Decimal = 0
	Private PorCobrarEfectivoVales As Decimal = 0
	Private AFavorEfectivoVales As Decimal = 0
	Private PorCobrarTarjetaCredito As Decimal = 0
	Private AFavorTarjetaCredito As Decimal = 0
	Private PorCobrarTarjetaDebito As Decimal = 0
	Private AFavorTarjetaDebito As Decimal = 0
	Private PorCobrarFichaDeposito As Decimal = 0
	Private AfavorFichaDeposito As Decimal = 0

	Private dr As DataRow

	Private dtCobroPedido As MiDataTable
	Private dtCambio As MiDataTableCambio
	Private dtDenominacion As DataTable
	Private dtCobroPedidoLiq As DataTable
	Private dtCobro As DataTable
	Private dtTarjetaCreditoLiq As DataTable
	Private dtEfectivoVales As DataTable
	Private dtVales As DataTable
	Private dtCheques As DataTable
	Private dtTarjetaCredito As DataTable
	Private dtFichaDeposito As DataTable
	Private ImporteEficiencia As Decimal
	Private Celula As Integer

	'para mostrar el importe de obsequios y autocarburaciones
	Private dtObsequios As DataTable

	'Para control de saldos a favor
	Private saldoAFavor As Decimal = 0

	'Control de vales promocionales
	Dim frmConsultaValePromocion As New ControlDeValesPromocionales.frmCapturaPagosConVale()
#End Region

#Region "Inicio"

	Public Sub New(ByVal DatosMovimiento As DataSet)
		'************************
		'LIQUIDACION A OPERADORES
		'************************
		MyBase.New()
		InitializeComponent()
		Titulo = "Liquidación a Operadores"
		TipoOperacion = TipoOperacionMovimientoCaja.Liquidacion

		grdInfoPreLiq.DataSource = DatosMovimiento.Tables("InfoPreLiq")

		Dim _Celula As Byte = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("Celula"), Byte)

		dtCobro = DatosMovimiento.Tables("Cobro")
		dtCobroPedidoLiq = DatosMovimiento.Tables("CobroPedido")

		'Importe total del movimiento
		decImporteTotalMovimiento = SumaColumna(dtCobroPedidoLiq, "CobroPedidoTotal")
		lblImporteMovimiento.Text = decImporteTotalMovimiento.ToString("C")

		'Checo si el Importe total del movimiento es válido
		'18 de noviembre del 2002
		If decImporteTotalMovimiento <= 0 Then
			'btnAceptar.Enabled = False
		End If

		'Valida la aplicación de la promoción
		RegistroValeCredito1.Visible = GLOBAL_Promocion
		AFavorOperadorCheques = 0
		If DatosMovimiento.Tables("EfectivoVales").Rows.Count <= 0 Then
			CobroEfectivo.Enabled = False


			If GLOBAL_Promocion Then
				RegistroValeCredito1.Enabled = False
			End If
		Else
			dtEfectivoVales = DatosMovimiento.Tables("EfectivoVales")
			PorCobrarEfectivoVales = SumaColumna(dtEfectivoVales, "Total")
			AFavorEfectivoVales = SumaColumna(dtEfectivoVales, "Saldo")
			AFavorOperadorCheques += AFavorEfectivoVales
		End If

		If DatosMovimiento.Tables("Vales").Rows.Count <= 0 Then

			'Vales.Enabled = False

			'If GLOBAL_Promocion Then
			'	RegistroValeCredito1.Enabled = False
			'End If
		Else
			dtVales = DatosMovimiento.Tables("Vales")
			PorCobrarVales = SumaColumna(dtVales, "Total")
			AFavorVales = SumaColumna(dtVales, "Saldo")
			AFavorOperadorCheques += AFavorVales
		End If

		If DatosMovimiento.Tables("Cheques").Rows.Count <= 0 Then
			lnkConsultaCheques.Visible = False
			grdCheque.Visible = False
		Else
			dtCheques = DatosMovimiento.Tables("Cheques")

			Dim lTransformadorCRM As New TransformadorCRM()
			dtCheques = lTransformadorCRM.ConsultaChequesCRM(dtCheques)

			grdCheque.DataSource = dtCheques
			PorCobrarCheques = SumaColumna(dtCheques, "Total")
			AFavorCheques = SumaColumna(dtCheques, "Saldo")
			AFavorOperadorCheques += AFavorCheques
		End If

		If DatosMovimiento.Tables("TarjetaCredito").Rows.Count <= 0 Then
			lnkConsultaTarjetaCredito.Visible = False
			grdTarjetaCredito.Visible = False
		Else
			dtTarjetaCreditoLiq = DatosMovimiento.Tables("TarjetaCredito")
			grdTarjetaCredito.DataSource = dtTarjetaCreditoLiq

			PorCobrarTarjetaCredito = SumaColumna(6, dtTarjetaCreditoLiq, "Total")
			AFavorTarjetaCredito = SumaColumna(6, dtTarjetaCreditoLiq, "Saldo")
			AFavorOperadorCheques += AFavorTarjetaCredito

			PorCobrarTarjetaDebito = SumaColumna(19, dtTarjetaCreditoLiq, "Total")
			AFavorTarjetaDebito = SumaColumna(19, dtTarjetaCreditoLiq, "Saldo")
			AFavorOperadorCheques += AFavorTarjetaDebito
		End If

		If DatosMovimiento.Tables("FichaDeposito").Rows.Count <= 0 Then
			lnkConsultaFichaDeposito.Visible = False
			grdFichaDeposito.Visible = False
		Else
			dtFichaDeposito = DatosMovimiento.Tables("FichaDeposito")
			grdFichaDeposito.DataSource = dtFichaDeposito
			PorCobrarFichaDeposito = SumaColumna(dtFichaDeposito, "Total")
			'20 de marzo del 2003
			AfavorFichaDeposito = SumaColumna(dtFichaDeposito, "Saldo")
			AFavorOperadorCheques += AfavorFichaDeposito
		End If

		'Parametrización del saldo a favor:
		If GLOBAL_SaldoAFavor And (Not (dtCheques Is Nothing) _
			AndAlso dtCheques.Rows.Count > 0) Then
			saldoAFavor = CType(IIf(dtCheques.Compute("SUM(Saldo)", "SaldoAFavor = 1") Is DBNull.Value,
			0, dtCheques.Compute("SUM(Saldo)", "SaldoAFavor = 1")), Decimal)
		End If

		'Datos de obsequios
		If DatosMovimiento.Tables("Obsequios").Rows.Count <= 0 Then
			LinkLabel1.Visible = False
		Else
			dtObsequios = DatosMovimiento.Tables("Obsequios")
		End If


		lblTipoOperacion.Text = Titulo
		lblFOperacion.Text = Main.FechaOperacion.Date.ToShortDateString

		'Datos de la preliquidación en células 
		'Ult.Mod: 19 de noviembre del 2002
		If DatosMovimiento.Tables("InfoPreLiq").Rows.Count = 1 Then
			lblRuta.Text = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("RutaDescripcion"), String)
			Celula = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("Celula"), Integer)
			RutaMovimiento = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("Ruta"), Short)
			AutotanqueTurno_AnoAtt = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("AñoAtt"), Short)
			AutotanqueTurno_Folio = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("Folio"), Integer)

			'11 de marzo del 2003

			Dim FInicioRuta As Date = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("FInicioRuta"), Date).Date

			'**************************************
			'Regla de la hora maxima de liquidacion
			'19 de junio del 2003
			'**************************************

			If FInicioRuta = Now.Date Then
				dtpFMovimiento.Value = Now.Date
			Else
				If Main.GLOBAL_ReglaHoraLiquidacion = True Then
					If Now <= GLOBAL_MaxHoraLiquidacion Then
						dtpFMovimiento.Value = FInicioRuta
						lblFMovimiento.BackColor = Color.Red
						lblFMovimiento.ForeColor = Color.White
						picAviso.Visible = True
						ttMensaje.Active = True
					Else
						lblPanelMensaje.Text &= FInicioRuta.ToLongDateString
						PanelMensaje.Visible = True
						dtpFMovimiento.Value = Now.Date
					End If
				Else
					lblPanelMensaje.Text &= FInicioRuta.ToLongDateString
					PanelMensaje.Visible = True
					dtpFMovimiento.Value = Now.Date
				End If
			End If

			lblFMovimiento.Text = dtpFMovimiento.Value.ToLongDateString
			'Fin

			If CType(DatosMovimiento.Tables("InfoPreliq").Rows(0).Item("ImporteContado"), Decimal) <> decImporteTotalMovimiento Then
				MessageBox.Show("El movimiento tiene cifras incongruentes entre los documentos y la báscula." & Chr(13) &
								"El movimiento no podra ser dado de alta." & Chr(13) &
								"Reporte este problema al administrador del sistema.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				grpDatosMovimiento.BackColor = Color.Red
				btnAceptar.Enabled = False
			End If


			If Not IsDBNull(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("TipoPagoEficiencia")) Then
				If CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("TipoPagoEficiencia"), Byte) = 1 Or
				   CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("TipoPagoEficiencia"), Byte) = 2 Then
					ImporteEficiencia = CType(DatosMovimiento.Tables("InfoPreLiq").Rows(0).Item("ImporteEficiencia"), Decimal)
				End If
			End If
		Else
			btnAceptar.Enabled = False
		End If

		'Desactivo la opción del cobro de la eficiencia si
		'la eficiencia de esa ruta es menor o igual a cero
		If ImporteEficiencia <= 0 Then
			grpCobroEficiencia.Enabled = False
		End If

		AsignaValores()

		btnConsultaDocumentos.Visible = True
		'Modificación del día 03 de junio
		'Carga el tipo de movimiento correcto para cuando son servicios técnicos

		If _Celula <> 14 Then
			ComboTipoMovimientoCaja.CargaDatos(2, False)
		Else
			ComboTipoMovimientoCaja.CargaDatos(32, False)
		End If

		ComboTipoMovimientoCaja.SelectedIndex = 0
		ComboTipoMovimientoCaja.Visible = True


		lnkConsultaIVA.Visible = True
	End Sub


	Public Sub New(ByVal Tipo As TipoOperacionMovimientoCaja,
				   ByVal DatosMovimiento As DataSet,
				   ByVal Caja As Byte,
				   ByVal FOperacion As Date,
				   ByVal Consecutivo As Byte,
				   ByVal Folio As Integer,
				   ByVal FAlta As Date)

		MyBase.New()
		InitializeComponent()


		'Pre-cargo los datos que vienen desde la consulta

		TipoOperacion = Tipo
		dtCobroPedido = CType(DatosMovimiento.Tables("Cobro"), MiDataTable)
		dtDenominacion = DatosMovimiento.Tables("Denominacion")
		dtCambio = CType(DatosMovimiento.Tables("Cambio"), MiDataTableCambio)
		bytCaja = Caja
		dtmFOperacion = FOperacion
		bytConsecutivo = Consecutivo
		intFolio = Folio
		dtmFAlta = FAlta
		MovimientoCajaClave = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("Clave"), String)
		decImporteTotalMovimiento = SumaColumna(dtCobroPedido, "CobroPedidoTotal")
		lblImporteMovimiento.Text = decImporteTotalMovimiento.ToString("C")
		lblStatus.Text = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("MovimientoCajaStatus"), String)
		If Trim(CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("MovimientoCajaStatus"), String)) = "CANCELADO" Then
			lblMotivoCancelacion1.Visible = True
			lblMotivoCancelacion2.Visible = True
			lblMotivoCancelacion2.Text = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("MotivoCancelacion"), String)
		End If
		lblTipoMovimientoCaja.Text = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("TipoMovimientoCajaDescripcion"), String)
		lblFOperacion.Text = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("FOperacion"), Date).ToShortDateString
		blnNotaIngreso = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("NotaIngreso"), Boolean)

		'11 de marzo del 2003
		If Now.Date.Day <= Main.GLOBAL_DiasAjuste Then
			dtpFMovimiento.Value = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("FMovimiento"), Date)
			lblFMovimiento.BackColor = Color.LemonChiffon
			lblPanelMensaje.Text = "La cobranza pertenece al día " & dtpFMovimiento.Value.ToLongDateString
			PanelMensaje.Visible = True
		Else
			dtpFMovimiento.Value = Now.Date
		End If
		lblFMovimiento.Text = dtpFMovimiento.Value.ToLongDateString

		lblRuta.Text = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("RutaDescripcion"), String)
		lblNombreEmpleado.Text = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("Empleado"), String) & " " &
								 CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("EmpleadoNombre"), String)
		lblObservaciones.Text = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("Observaciones"), String)



		'Fin del pre-cargo

		AFavorOperadorCheques = 0

		If dtCobroPedido.Rows.Count > 0 Then
			dr = dtCobroPedido.Rows(0)
			shrAnoCobro = CType(dr("AñoCobro"), Short)
			intCobro = CType(dr("Cobro"), Integer)
			btnConsultaDocumentos.Visible = True
		Else
			btnConsultaDocumentos.Visible = False
		End If

		dtVales = DatosMovimiento.Tables("Vales")

		'Paso la lista de cheques al grid si tiene cheques relacionados
		'de lo contrario escondo el grid y el link.
		If DatosMovimiento.Tables("Cheques").Rows.Count <= 0 Then
			lnkConsultaCheques.Visible = False
			grdCheque.Visible = False
		Else
			dtCheques = DatosMovimiento.Tables("Cheques")
			grdCheque.DataSource = dtCheques
			'PorCobrarCheques = dtCobroPedido.ImporteTotalCheques
			PorCobrarCheques = SumaColumna(dtCheques, "Total")
			AFavorCheques = SumaColumna(dtCheques, "Saldo")
			AFavorOperadorCheques += AFavorCheques
		End If

		'Paso la lista de cobros con tarjeta de crédito al grid si tiene 
		'de lo contrario escondo el grid y el link.
		If DatosMovimiento.Tables("TarjetaCredito").Rows.Count <= 0 Then
			lnkConsultaTarjetaCredito.Visible = False
			grdTarjetaCredito.Visible = False
		Else
			dtTarjetaCredito = DatosMovimiento.Tables("TarjetaCredito")
			grdTarjetaCredito.DataSource = dtTarjetaCredito
			PorCobrarTarjetaCredito = SumaColumna(6, dtTarjetaCredito, "Total")
			AFavorTarjetaCredito = SumaColumna(6, dtTarjetaCredito, "Saldo")
			AFavorOperadorCheques += AFavorTarjetaCredito

			PorCobrarTarjetaDebito = SumaColumna(19, dtTarjetaCredito, "Total")
			AFavorTarjetaDebito = SumaColumna(19, dtTarjetaCredito, "Saldo")
			AFavorOperadorCheques += AFavorTarjetaDebito
		End If

		If DatosMovimiento.Tables("FichaDeposito").Rows.Count <= 0 Then
			lnkConsultaFichaDeposito.Visible = False
			grdFichaDeposito.Visible = False
		Else
			dtFichaDeposito = DatosMovimiento.Tables("FichaDeposito")
			grdFichaDeposito.DataSource = dtFichaDeposito
			PorCobrarFichaDeposito = SumaColumna(dtFichaDeposito, "Total")
			AfavorFichaDeposito = SumaColumna(dtFichaDeposito, "Saldo")
			'Cambio hecho el 20 de marzo del 2003
			AFavorOperadorCheques += AfavorFichaDeposito
		End If

		'Consulta de los datos de los cobros.
		PorCobrarEfectivo = dtCobroPedido.ImporteTotalEfectivo
		PorCobrarVales = dtCobroPedido.ImporteTotalVales
		'27 de junio del 2003
		If CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("NotaIngreso"), Boolean) = False Then
			PorCobrarEfectivoVales = dtCobroPedido.ImporteTotalEfectivoVales
		Else
			PorCobrarEfectivoVales = dtCobroPedido.ImporteTotalEfectivoValesNI
			decImporteTotalMovimiento = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("Total"), Decimal)
			lblImporteMovimiento.Text = decImporteTotalMovimiento.ToString("C")
		End If


		AsignaValores()

		'Deshabilito los controles de cobro que no corresponden con este movimiento.
		'If PorCobrarCheques <= 0 Then grdCheque.Visible = False
		If PorCobrarEfectivo <= 0 Then
			CobroEfectivo.Visible = False
			lblNoTieneEfectivo.Visible = True
		End If
		If PorCobrarVales <= 0 Then
			Vales.Visible = False
			lblNoTieneVales.Visible = True
		End If
		If PorCobrarEfectivoVales > 0 Then
			CobroEfectivo.Visible = True
			Vales.Visible = True
		End If

		lblMovimientoCajaClave.Text = MovimientoCajaClave

		AutotanqueTurno_AnoAtt = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("AñoAtt"), Short)
		AutotanqueTurno_Folio = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("FolioAtt"), Integer)

		'CONSULTA
		If Tipo = TipoOperacionMovimientoCaja.Consulta Then
			Dim dr As DataRow
			Titulo = "Consulta de operación"
			lblTipoOperacion.Text = Titulo

			For Each dr In dtDenominacion.Rows
				If CType(dr("TipoCobro"), Byte) = 1 Then
					Select Case CType(dr("Valor"), Double)
						Case Is = 1000 : CobroEfectivo.M1000 = CType(dr("Cantidad"), Short)
						Case Is = 500 : CobroEfectivo.M500 = CType(dr("Cantidad"), Short)
						Case Is = 200 : CobroEfectivo.M200 = CType(dr("Cantidad"), Short)
						Case Is = 100 : CobroEfectivo.M100 = CType(dr("Cantidad"), Short)
						Case Is = 50 : CobroEfectivo.M50 = CType(dr("Cantidad"), Short)
						Case Is = 20 : CobroEfectivo.M20 = CType(dr("Cantidad"), Short)
						Case Is = 10 : CobroEfectivo.M10 = CType(dr("Cantidad"), Short)
						Case Is = 5 : CobroEfectivo.M5 = CType(dr("Cantidad"), Short)
						Case Is = 2 : CobroEfectivo.M2 = CType(dr("Cantidad"), Short)
						Case Is = 1 : CobroEfectivo.M1 = CType(dr("Cantidad"), Short)
						Case Is = 0.5 : CobroEfectivo.M50c = CType(dr("Cantidad"), Short)
						Case Is = 0.2 : CobroEfectivo.M20c = CType(dr("Cantidad"), Short)
						Case Is = 0.1 : CobroEfectivo.M10c = CType(dr("Cantidad"), Short)
						Case Is = 0.05 : CobroEfectivo.M5c = CType(dr("Cantidad"), Short)
						Case Is = 0 : CobroEfectivo.Morralla = CType(dr("Total"), Decimal)
					End Select
				End If
				If CType(dr("TipoCobro"), Byte) = 2 Then
					Select Case CType(dr("Valor"), Double)
						Case Is = 100 : Vales.V100 = CType(dr("Cantidad"), Short)
						Case Is = 50 : Vales.V50 = CType(dr("Cantidad"), Short)
						Case Is = 35 : Vales.V35 = CType(dr("Cantidad"), Short)
						Case Is = 30 : Vales.V30 = CType(dr("Cantidad"), Short)
						Case Is = 25 : Vales.V25 = CType(dr("Cantidad"), Short)
						Case Is = 20 : Vales.V20 = CType(dr("Cantidad"), Short)
						Case Is = 15 : Vales.V15 = CType(dr("Cantidad"), Short)
						Case Is = 10 : Vales.V10 = CType(dr("Cantidad"), Short)
						Case Is = 5 : Vales.V5 = CType(dr("Cantidad"), Short)
						Case Is = 4 : Vales.V4 = CType(dr("Cantidad"), Short)
						Case Is = 3 : Vales.V3 = CType(dr("Cantidad"), Short)
						Case Is = 2 : Vales.V2 = CType(dr("Cantidad"), Short)
						Case Is = 1 : Vales.V1 = CType(dr("Cantidad"), Short)
					End Select
				End If
				'Consulta de los vales de promoción
				'If CType(dr("TipoCobro"), Byte) = 16 Then
				'    Select Case CType(dr("Valor"), Double)
				'        Case Is = 50
				'            ControlValesPromocion1.V50 = CType(dr("Cantidad"), Short)
				'            ControlValesPromocion1.Visible = True
				'    End Select
				'End I
			Next

			CobroEfectivo.CalculaTotalEfectivo()
			Vales.CalculaTotalVales()

			'ControlValesPromocion1.CalculaTotalVales()
			frmConsultaValePromocion = New ControlDeValesPromocionales.frmCapturaPagosConVale(Caja, FOperacion, Consecutivo, Folio)
			RegistroValeCredito1.Total = frmConsultaValePromocion.Total

			CobroEfectivo.Enabled = False
			Vales.Enabled = False

			'RegistroValeCredito1.Enabled = False

			'24 de marzo del 2003
			dtpFMovimiento.Value = CType(DatosMovimiento.Tables("Cabecera").Rows(0).Item("FMovimiento"), Date)
			lblFMovimiento.Text = dtpFMovimiento.Value.ToLongDateString
			'11-10-2005 control de vales promocionales
			'lblImporteTotalCobro.Text = (CobroEfectivo.CalculaTotalEfectivo + Vales.CalculaTotalVales + PorCobrarCheques + PorCobrarTarjetaCredito + PorCobrarFichaDeposito).ToString("C")
			lblImporteTotalCobro.Text = (CobroEfectivo.CalculaTotalEfectivo + Vales.CalculaTotalVales + frmConsultaValePromocion.Total +
				PorCobrarCheques + PorCobrarTarjetaCredito + PorCobrarTarjetaDebito + PorCobrarFichaDeposito - AFavorOperadorCheques).ToString("C")

			If decImporteTotalMovimiento > CType(lblImporteTotalCobro.Text, Decimal) Then
				lblFaltante.Text = (decImporteTotalMovimiento - CType(lblImporteTotalCobro.Text, Decimal)).ToString("C")
			Else
				lblFaltante.Text = ""
			End If

			lblCambio.Text = (CType(lblImporteTotalCobro.Text, Decimal) - decImporteTotalMovimiento).ToString("C")
			lblCambioEntregado.Text = dtCambio.ImporteTotalCambio.ToString("C")
			grpCobroEficiencia.Enabled = False
			dtpFMovimiento.Enabled = False
			btnAceptar.Enabled = False
		End If

		'VALIDACION
		If Tipo = TipoOperacionMovimientoCaja.Validacion Then
			Titulo = "Validación de captura de cobranza"
			lblTipoOperacion.Text = Titulo
			grpLiquidacionConsulta.Enabled = False
			decImporteTotalCobros = CalculaTotalCobros()
			lblImporteTotalCobro.Text = decImporteTotalCobros.ToString("C")

			lblCaptAFAvor.Text = "A favor cliente / otros ingresos"
		End If
	End Sub

	Private Sub frmCapMovimiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		'ControlValesPromocion1.Valor = GLOBAL_ValorValePromocional

		If TipoOperacion = TipoOperacionMovimientoCaja.Liquidacion Then
			lblFechaAlta.Text = Now.ToString
		Else
			lblFechaAlta.Text = dtmFAlta.ToString
		End If
	End Sub

#End Region

#Region "Paneles de cobro"
	Private Sub ManejadorCobros() Handles Vales.TotalActualizado, CobroEfectivo.TotalActualizado
		decImporteTotalCobros = CalculaTotalCobros()
		lblImporteTotalCobro.Text = decImporteTotalCobros.ToString("C")
		'If (decImporteTotalMovimiento - AFavorOperadorCheques) - decImporteTotalCobros >= 0 Then
		'    lblFaltante.Text = ((decImporteTotalMovimiento - AFavorOperadorCheques) - decImporteTotalCobros).ToString("C")
		'Else
		'    lblFaltante.Text = ""
		'End If
		'***Integración de cobros con tarjeta de crédito
		If (decImporteRealACobrar + Me.PorCobrarCheques + Me.PorCobrarFichaDeposito + Me.PorCobrarTarjetaCredito + Me.PorCobrarTarjetaDebito - AFavorOperadorCheques) - decImporteTotalCobros >= 0 Then
			lblFaltante.Text = ((decImporteRealACobrar + Me.PorCobrarCheques + Me.PorCobrarFichaDeposito + Me.PorCobrarTarjetaCredito + Me.PorCobrarTarjetaDebito - AFavorOperadorCheques) - decImporteTotalCobros).ToString("C")
		Else
			lblFaltante.Text = ""
		End If


		If TipoOperacion = TipoOperacionMovimientoCaja.Validacion Or TipoOperacion = TipoOperacionMovimientoCaja.Liquidacion Then
			'Se resta el importe del saldo a favor del cambio
			decImporteCambio = decImporteTotalCobros - decImporteTotalMovimiento
			If decImporteCambio > 0 Then
				lblCambio.Text = decImporteCambio.ToString("C")
			Else
				lblCambio.Text = ""
			End If
		End If

	End Sub

	Private Sub ManejaPanelActivo(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpCobroVale.Enter, grpCobroVale.Leave, grpCobroCheque.Enter, grpCobroCheque.Leave, grpCobroEfectivo.Enter, grpCobroEfectivo.Leave
		Select Case ActiveControl.Name
			Case Is = "CobroEfectivo"
				grpCobroEfectivo.BackColor = Color.Khaki
				grpCobroVale.BackColor = Color.FromName("Control")
			Case Is = "Vales"
				grpCobroEfectivo.BackColor = Color.FromName("Control")
				grpCobroVale.BackColor = Color.Khaki
			Case Else
				grpCobroEfectivo.BackColor = Color.FromName("Control")
				grpCobroVale.BackColor = Color.FromName("Control")
		End Select
	End Sub

	Private Sub frmCapMovimiento_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
		Select Case e.KeyCode
			Case Is = Keys.F3
				CobroEfectivo.ComienzaCaptura()
			Case Is = Keys.F4
				Vales.ComienzaCaptura()
			Case Is = Keys.F10
				btnAceptar.PerformClick()
			Case Is = Keys.Escape
				btnCancelar.PerformClick()
		End Select
	End Sub

	Private Sub CobroEfectivo_FlechaDerecha() Handles CobroEfectivo.FlechaDerecha
		Vales.Focus()
	End Sub

	Private Sub Vales_FlechaIzquierda() Handles Vales.FlechaIzquierda
		CobroEfectivo.Focus()
	End Sub

	'Función que regresa el total de lo que se tiene que cobrar
	Private Function CalculaTotalCobros() As Decimal
		'Cambio realizado el 20 de febrero
		If Not GLOBAL_Promocion Then
			Return CDec(CobroEfectivo.TotalEfectivo + Vales.TotalVales) + PorCobrarTarjetaCredito + PorCobrarFichaDeposito + PorCobrarCheques + PorCobrarTarjetaDebito - AFavorOperadorCheques
		Else
			Return CDec(CobroEfectivo.TotalEfectivo + Vales.TotalVales + frmConsultaValePromocion.Total) + PorCobrarTarjetaCredito + PorCobrarFichaDeposito + PorCobrarCheques + PorCobrarTarjetaDebito - AFavorOperadorCheques
		End If
	End Function

#End Region

#Region "Grabado de datos"

	Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
		If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then

			Dim arrDenomEfectivo As Array = CobroEfectivo.CalculaDenominaciones
			Dim arrDenomVales As Array = Vales.CalculaDenominaciones


			'Dim arrDenomValesPromocion As Array = ControlValesPromocion1.CalculaDenominaciones

			Dim arrCheques(0, 2) As Decimal
			Dim arrTarjetas(0, 2) As Decimal
			Dim arrFichas(0, 2) As Decimal
			Dim i As Integer = 0
			Try
				'Se arma el arreglo con los cheques
				If Not dtCheques Is Nothing Then
					If dtCheques.Rows.Count > 0 Then
						Dim r As DataRow
						ReDim arrCheques(dtCheques.Rows.Count - 1, 2)
						For Each r In dtCheques.Rows
							arrCheques(i, 0) = CType(r("AñoCobro"), Decimal)
							arrCheques(i, 1) = CType(r("Cobro"), Decimal)
							arrCheques(i, 2) = CType(r("Total"), Decimal)
							i += 1
						Next
					End If
				End If

				'Se arma el arreglo con las tarjetas de crédito
				i = 0
				If Not dtTarjetaCredito Is Nothing Then
					If dtTarjetaCredito.Rows.Count > 0 And PorCobrarTarjetaCredito > 0 Then
						Dim r As DataRow
						ReDim arrTarjetas(dtTarjetaCredito.Rows.Count - 1, 2)
						For Each r In dtTarjetaCredito.Rows
							arrTarjetas(i, 0) = CType(r("AñoCobro"), Decimal)
							arrTarjetas(i, 1) = CType(r("Cobro"), Decimal)
							arrTarjetas(i, 2) = CType(r("Total"), Decimal)
							i += 1
						Next
					End If
				End If

				'Se arma el arreglo con las fichas de depósito
				i = 0
				If Not dtFichaDeposito Is Nothing Then
					If dtFichaDeposito.Rows.Count > 0 And PorCobrarFichaDeposito > 0 Then
						Dim r As DataRow
						ReDim arrFichas(dtFichaDeposito.Rows.Count - 1, 2)
						For Each r In dtFichaDeposito.Rows
							arrFichas(i, 0) = CType(r("AñoCobro"), Decimal)
							arrFichas(i, 1) = CType(r("Cobro"), Decimal)
							arrFichas(i, 2) = CType(r("Total"), Decimal)
							i += 1
						Next
					End If
				End If
			Catch ex As Exception
				MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
				Exit Sub
			End Try

			'Se instancia el objeto que controla la transacción
			Dim objMov As New SigaMetClasses.TransaccionMovimientoCaja()
			Try
				'Verificar si la fecha almacenada en memoria corresponde con la fecha del servidor - JAGD 03032010
				Dim _fechaServidor As Date = SigaMetClasses.FechaServidor
				If FechaOperacion.Date <> _fechaServidor.Date Then
					'Si las fechas son diferentes, solicitar iniciar sesión nuevamente
					MessageBox.Show("La fecha de operación no corresponde con la fecha del servidor." & vbCrLf &
						"Inicie sesión nuevamente por favor", "Error de fecha de operación", MessageBoxButtons.OK, MessageBoxIcon.Error)
					Return
				End If

				If Main.SesionIniciada = False Then
					'Iniciar sesión
					Main.IniciarSesion(FechaInicioSesion)
				End If

				If TipoOperacion = TipoOperacionMovimientoCaja.Validacion Then
					'Se agregó lo siguiente para validar que los abonos de todos los pedidos incluidos en el movimiento sean menores o iguales al saldo
					Dim objValidaSaldo As New ValidaSaldosCaja.DocumentosErroneos(bytCaja, dtmFOperacion, bytConsecutivo, intFolio,
						GLOBAL_Connection)
					If Not (objValidaSaldo.CapturaCorrecta) Then
						objValidaSaldo.ShowDialog()

						'Mostrar cobros de abonos excedidos
						If oSeguridad.TieneAcceso("AUTOMODIFICACION_MOVS") Then
							Dim objListadoCobros As New ValidaSaldosCaja.CobrosErroneos(bytCaja, dtmFOperacion,
								bytConsecutivo, intFolio, GLOBAL_IDUsuario, decImporteTotalMovimiento, GLOBAL_Connection)
							'si se elije borrar los cobros indicados
							If objListadoCobros.ShowDialog() = DialogResult.Yes Then
								'salir de la captura
								Me.Close()
								Exit Sub
							End If
						End If
						Exit Sub
					End If

					objMov.Valida(bytCaja, dtmFOperacion, bytConsecutivo, intFolio, shrAnoCobro, intCobro, arrDenomEfectivo, arrDenomVales, arrCheques, arrTarjetas, arrFichas, arrCambio, dtCobroPedido, , Not blnNotaIngreso,
					 Transferir:=True, CajaDestino:=Main.GLOBAL_CajaUsuario, FOperacionDestino:=Main.FechaOperacion, ConsecutivoDestino:=Main.ConsecutivoInicioDeSesion)
					'Try
					'    objMov.TransfiereMovimientoCaja(bytCaja, dtmFOperacion, bytConsecutivo, intFolio, Main.GLOBAL_CajaUsuario, Main.FechaOperacion, Main.ConsecutivoInicioDeSesion)
					'Catch ex As Exception
					'    MessageBox.Show("Ha ocurrido el siguiente error en la transferencia del movimiento de caja: " & ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Warning)
					'End Try
				End If

				If TipoOperacion = TipoOperacionMovimientoCaja.Liquidacion Then
					If ComboTipoMovimientoCaja.TipoMovimientoCaja <= 0 Then
						MessageBox.Show("Debe seleccionar el tipo de movimiento de caja para esta liquidación.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
						Exit Sub
					Else
						'se suma el valor de saldoAFavor en el argumento Total
						'arrDenomValesPromocion, _
						objMov.AltaLiquidacion(Main.GLOBAL_CajaUsuario,
									Main.FechaOperacion,
									Main.ConsecutivoInicioDeSesion,
									dtpFMovimiento.Value,
									(Me.decImporteTotalMovimiento + Me.saldoAFavor),
									Main.GLOBAL_IDUsuario,
									Main.GLOBAL_IDEmpleado,
									RutaMovimiento,
									CType(ComboTipoMovimientoCaja.TipoMovimientoCaja, Byte),
									dtCobro,
									AutotanqueTurno_AnoAtt,
									AutotanqueTurno_Folio,
									arrDenomEfectivo,
									arrDenomVales,
									arrCheques,
									arrTarjetas,
									arrFichas,
									arrCambio,
									dtCobroPedidoLiq,
									frmConsultaValePromocion.ListaVales,
									saldoAFavor)

						'**********************************
						'Tranferencia inmediata de cargos
						'05 de Julio del 2004
						'**********************************
						'Dim cn As New SqlClient.SqlConnection(Main.ConString)



						Dim cn As SqlClient.SqlConnection = GLOBAL_Connection
						Dim cmd As New SqlClient.SqlCommand("spSTTransfiereCargosCartera", cn)
						With cmd
							.CommandType = CommandType.StoredProcedure
							.CommandTimeout = GLOBAL_TiempoEspera
							.Parameters.Clear()
							.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = AutotanqueTurno_AnoAtt
							.Parameters.Add("@Folio", SqlDbType.Int).Value = AutotanqueTurno_Folio
						End With

						Try
							If cn.State = ConnectionState.Closed Then
								cn.Open()
							End If
							cmd.ExecuteNonQuery()

						Catch ex As Exception
							MessageBox.Show("La transferencia de cargos automática no se pudo realizar debido al siguiente error:" & Chr(13) & ex.Message,
							ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)

						Finally
							If Not cn Is Nothing Then
								If cn.State = ConnectionState.Open Then cn.Close()
							End If
							cmd.Dispose()
							'cn.Dispose()
						End Try

					End If
				End If

				'MessageBox.Show(M_DATOS_OK, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

				'Try
				'    Cursor = Cursors.WaitCursor
				'    objMov.InterfaseCyC(Celula, dtpFMovimiento.Value)
				'    'MessageBox.Show("La interfase de CyC fue ejecutada correctamente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
				'Catch ex As Exception
				'    MessageBox.Show("La interfasé de CyC no pudo ser ejecutada correctamente debido al siguiente motivo: " & Chr(13) & _
				'                ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
				'Finally
				'    Cursor = Cursors.Default
				'End Try

				If AutotanqueTurno_AnoAtt <> 0 And AutotanqueTurno_Folio <> 0 And Main.GLOBAL_URLGATEWAY <> "" Then
					Try
						Dim objLiquida As New LiquidadorEstacionario.liquidadorEstacionario()
						objLiquida.liquidarRuta(Main.GLOBAL_URLGATEWAY, 0, 0, AutotanqueTurno_AnoAtt, AutotanqueTurno_Folio, 3, ConString)
					Catch ex As Exception
						MessageBox.Show("Error al liquidar:" & ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
					End Try
				End If


				DialogResult = DialogResult.OK
				Me.Close()
			Catch ex As Exception

				MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
				DialogResult = DialogResult.Cancel
			Finally
				objMov = Nothing
			End Try
		End If

	End Sub

	'todo: modificar para cargar distintos tipos de movimiento en el parámetro
	'Private Function MovimientoAutoModifValido() As Boolean
	'    If = CType(GLOBAL_TipoMovAutoModif, Integer) Then
	'        Return True
	'    Else
	'        Return False
	'    End If
	'End Function

#End Region

#Region "Manejo del cambio"
	Private Sub btnCambio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCambio.Click
		Dim ofrmCambio As frmCambio
		If TipoOperacion = TipoOperacionMovimientoCaja.Consulta Then
			ofrmCambio = New frmCambio(decImporteCambio, TipoOperacionMovimientoCaja.Consulta)
			Dim dr As DataRow
			For Each dr In dtCambio.Rows
				Select Case CType(dr("Denominacion"), Byte)
					Case Is = 1 : ofrmCambio.Efectivo.M500 = CType(dr("Cantidad"), Short)
					Case Is = 2 : ofrmCambio.Efectivo.M200 = CType(dr("Cantidad"), Short)
					Case Is = 3 : ofrmCambio.Efectivo.M100 = CType(dr("Cantidad"), Short)
					Case Is = 4 : ofrmCambio.Efectivo.M50 = CType(dr("Cantidad"), Short)
					Case Is = 5 : ofrmCambio.Efectivo.M20 = CType(dr("Cantidad"), Short)
					Case Is = 6 : ofrmCambio.Efectivo.M10 = CType(dr("Cantidad"), Short)
					Case Is = 7 : ofrmCambio.Efectivo.M5 = CType(dr("Cantidad"), Short)
					Case Is = 8 : ofrmCambio.Efectivo.M2 = CType(dr("Cantidad"), Short)
					Case Is = 9 : ofrmCambio.Efectivo.M1 = CType(dr("Cantidad"), Short)
					Case Is = 10 : ofrmCambio.Efectivo.M50c = CType(dr("Cantidad"), Short)
					Case Is = 11 : ofrmCambio.Efectivo.M20c = CType(dr("Cantidad"), Short)
					Case Is = 12 : ofrmCambio.Efectivo.M10c = CType(dr("Cantidad"), Short)
					Case Is = 13 : ofrmCambio.Efectivo.M5c = CType(dr("Cantidad"), Short)
					Case Is = 14 : ofrmCambio.Efectivo.Morralla = CType(dr("Cantidad"), Decimal)
				End Select
			Next
			With ofrmCambio
				.Efectivo.CalculaTotalEfectivo()
				.Efectivo.Enabled = False
				.lblCambio.Visible = False
				.lblCambio2.Visible = False
				.lblFaltante.Visible = False
				.lblFaltante2.Visible = False
				.ShowDialog()
			End With

		End If
		If TipoOperacion = TipoOperacionMovimientoCaja.Validacion Or TipoOperacion = TipoOperacionMovimientoCaja.Liquidacion Then
			ofrmCambio = New frmCambio(decImporteCambio, TipoOperacionMovimientoCaja.Validacion)
			ofrmCambio.ShowDialog()
			arrCambio = ofrmCambio.Efectivo.CalculaDenominaciones
			decImporteCambioDesglosado = CType(ofrmCambio.Efectivo.CalculaTotalEfectivo, Decimal)
			lblCambioEntregado.Text = decImporteCambioDesglosado.ToString("C")
		End If
	End Sub
#End Region

#Region "Consulta de cheques,tarjetas de credito y fichas de depósito"
	Private Sub lnkConsultaCheques_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkConsultaCheques.LinkClicked
		Try

			Dim frmListaCheques As New frmChequeTarjetaMovCaja(3)
			With frmListaCheques
				If dtCheques.Rows.Count() > 0 Then
					For Each dr As DataRow In dtCheques.Rows
						If (Not String.IsNullOrEmpty(Main.GLOBAL_URLGATEWAY)) Then
							Cursor = Cursors.WaitCursor

							Dim oGateway As RTGMGateway.RTGMGateway
							Dim oSolicitud As RTGMGateway.SolicitudGateway
							Dim oDireccionEntrega As RTGMCore.DireccionEntrega

							oGateway = New RTGMGateway.RTGMGateway(3, Main.ConString)
							oSolicitud = New RTGMGateway.SolicitudGateway()
							oGateway.GuardarLog = True
							oGateway.URLServicio = Main.GLOBAL_URLGATEWAY
							oSolicitud.IDCliente = CType(dr("Cliente"), Int32)
							oDireccionEntrega = oGateway.buscarDireccionEntrega(oSolicitud)

							If Not IsNothing(oDireccionEntrega) And IsNothing(oDireccionEntrega.Message) Then
								dr("ClienteNombre") = oDireccionEntrega.Nombre
							Else
								If Not IsNothing(oDireccionEntrega.Message) And oDireccionEntrega.Message.Contains("ERROR") Then
									Throw New Exception(oDireccionEntrega.Message)
								End If
							End If
						End If
					Next
				End If
				.grdConsulta.DataSource = dtCheques
				.grdConsulta.CaptionText = "Cheques en este movimiento"
				.grdConsulta.CaptionBackColor = Color.DarkSeaGreen
				.ShowDialog()
			End With

		Catch ex As Exception
			MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
		Finally
			Cursor = Cursors.Default
		End Try
	End Sub

	Private Sub lnkConsultaTarjetaCredito_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkConsultaTarjetaCredito.LinkClicked


		Dim frmListaTarjetaCredito As New frmChequeTarjetaMovCaja(2)
		With frmListaTarjetaCredito
			.grdConsulta.DataSource = grdTarjetaCredito.DataSource
			.grdConsulta.CaptionText = "Lista de cobros con tarjeta de crédito"
			.grdConsulta.CaptionBackColor = Color.Brown
			.ShowDialog()
		End With
	End Sub

	Private Sub lnkConsultaFichaDeposito_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkConsultaFichaDeposito.LinkClicked
		Dim frmListaFichaDeposito As New frmChequeTarjetaMovCaja(6)
		With frmListaFichaDeposito
			.grdConsulta.DataSource = dtFichaDeposito
			.grdConsulta.CaptionText = "Lista de cobros con notas de crédito, notas de ingreso y fichas de depósito"
			.grdConsulta.CaptionBackColor = Color.SteelBlue
			.ShowDialog()
		End With
	End Sub
#End Region

	Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
		Me.Close()
	End Sub

	Private Sub btnConsultaDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaDocumentos.Click
		'Todo hay que generalizar no manches
		Dim frmDocumentos As New frmConsultaCobranza()

		If TipoOperacion = TipoOperacionMovimientoCaja.Consulta Or TipoOperacion = TipoOperacionMovimientoCaja.Validacion Then
			frmDocumentos.grdCobroPedido.DataSource = dtCobroPedido
			frmDocumentos.stbEstatus.Panels(0).Text = dtCobroPedido.TotalRegistros.ToString & " documento(s)"
			frmDocumentos.stbEstatus.Panels(1).Text = "Importe Total: " & dtCobroPedido.ImporteTotalCobros.ToString("C")
		End If
		If TipoOperacion = TipoOperacionMovimientoCaja.Liquidacion Then
			frmDocumentos.grdCobroPedido.DataSource = dtCobroPedidoLiq
			frmDocumentos.stbEstatus.Panels(0).Text = dtCobroPedidoLiq.Rows.Count.ToString & " documento(s)"
			frmDocumentos.stbEstatus.Panels(1).Text = SumaColumna(dtCobroPedidoLiq, "CobroPedidoTotal").ToString("C")
		End If
		frmDocumentos.ShowDialog()
	End Sub

	Private Sub AsignaValores()
		lblPorCobrarEfectivo.Text = PorCobrarEfectivo.ToString("N")
		lblPorCobrarVales.Text = PorCobrarVales.ToString("N")
		lblTotalCheques.Text = (PorCobrarCheques).ToString("N")
		'
		lblAFavorOperadorCheques.Text = AFavorOperadorCheques.ToString("N")
		lblTotalEfectivo.Text = PorCobrarEfectivoVales.ToString("N")

		lblTotalTarjetaCredito.Text = (PorCobrarTarjetaCredito).ToString("N")
		lblTotalTarjetaDebito.Text = (PorCobrarTarjetaDebito).ToString("N")

		lblTotalVarios.Text = (PorCobrarFichaDeposito).ToString("N")
		lblTotalVale.Text = (PorCobrarVales).ToString("N")

		lblImporteEficiencia.Text = ImporteEficiencia.ToString("C")

		'Para saldo a favor
		If GLOBAL_SaldoAFavor Then 'si aplica el saldo a favor no se resta del importe a pagar
			lblRealEfectivoVales.Text = (PorCobrarEfectivoVales + PorCobrarVales).ToString("N")
			decImporteRealACobrar = (PorCobrarEfectivoVales + PorCobrarVales)
			If saldoAFavor > 0 Then
				lblCaptAFAvor.Text = "A favor:"
			End If
		Else
			lblRealEfectivoVales.Text = (PorCobrarEfectivoVales + PorCobrarVales).ToString("N")
			decImporteRealACobrar = (PorCobrarEfectivoVales + PorCobrarVales)
		End If



		'21-07-2005 Para desplegar el importe de autocarburaciones y obsequios
		If Not IsNothing(dtObsequios) Then
			lblTotalVale.Text = CStr(dtObsequios.Compute("SUM(Total)", ""))
		End If
	End Sub

	Private Sub chkIncluirEficiencia_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluirEficiencia.CheckedChanged
		If chkIncluirEficiencia.Checked = True Then
			decImporteTotalMovimiento += ImporteEficiencia
		Else
			decImporteTotalMovimiento -= ImporteEficiencia
		End If

		lblImporteMovimiento.Text = decImporteTotalMovimiento.ToString("C")
		ManejadorCobros()
	End Sub

	Private Sub lnkConsultaIVA_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkConsultaIVA.LinkClicked
		Try
			Dim consultaIVA As New vistaDeLiquidacionMultiplesIvas.LiquidacionAgrupadaPorPrecioIVA _
				(GLOBAL_Connection, AutotanqueTurno_AnoAtt, AutotanqueTurno_Folio)
		Catch ex As Exception
		End Try
	End Sub

	Private Sub lnkDetalleObs_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
		Dim consultaIVA As New vistaDeLiquidacionMultiplesIvas.DetalleObsequios(AutotanqueTurno_AnoAtt,
							  AutotanqueTurno_Folio, dtObsequios)
	End Sub

	Private Sub Panel2_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel2.Paint
		LabelNombreEmpresa1.CargarNombreEmpresa()
	End Sub

	Private Sub btnValesPromocion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegistroValeCredito1.Click
		If frmConsultaValePromocion Is Nothing Then
			frmConsultaValePromocion = New ControlDeValesPromocionales.frmCapturaPagosConVale()
		End If
		frmConsultaValePromocion.ShowDialog()

		If (frmConsultaValePromocion.CaptureEnabled) Then
			RegistroValeCredito1.Total = frmConsultaValePromocion.Total
			ManejadorCobros()
		End If
	End Sub

	Private Sub RegistroValeCredito1_Load(sender As System.Object, e As System.EventArgs) Handles RegistroValeCredito1.Load

	End Sub

	Private Sub LabelBase14_DoubleClick(sender As Object, e As EventArgs) Handles LabelBase14.DoubleClick

	End Sub

	Private Sub LabelBase14_Click(sender As Object, e As EventArgs) Handles LabelBase14.Click
		If (Not dtVales Is Nothing) Then

			If (dtVales.Rows.Count > 0) Then
				Dim ventanaVales As New frmMuestraValesPorProveedor()
				ventanaVales.Año = AutotanqueTurno_AnoAtt
				ventanaVales.Folio = AutotanqueTurno_Folio
				ventanaVales.ShowDialog()
			End If
		End If
	End Sub
End Class