Option Strict On
Option Explicit On
Imports System.Collections.Generic
Imports System.Data.SqlClient
Imports System.Linq



Public Class frmSelTipoCobro
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cobranza"

    Private Consecutivo As Integer
    Public Cobro As SigaMetClasses.sCobro
    Public ImporteTotalCobro As Decimal = 0
    Private _TipoCobro As SigaMetClasses.Enumeradores.enumTipoCobro
    Private _CapturaDetalle As Boolean = True
    Private FormadePago As FormaPago
    Private DacionEnPagoVisible As Boolean = False
    Friend WithEvents tbTransferencias As TabPage
    Friend WithEvents tbAplicAnticipo As TabPage
    Friend WithEvents tbEfectivo As TabPage
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents TxtNumeroDecimal1 As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents LabelBase8 As ControlesBase.LabelBase
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents LabelBase11 As ControlesBase.LabelBase
    Friend WithEvents LabelBase10 As ControlesBase.LabelBase
    Friend WithEvents TxtNombreTransferencia As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents LabelBase9 As ControlesBase.LabelBase
    Friend WithEvents Button1 As Button
    Friend WithEvents TxtClienteTransferencia As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtbObservacionesTranferencias As TextBox
    Friend WithEvents TxtImporteTransferencia As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents ComboBancoTransferencia As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents TxtNumeroDocumentoTransferencia As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents TxtNumeroCuentaTransferencia As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents DTPFechaTransferencia As DateTimePicker
    Friend WithEvents LabelBase16 As ControlesBase.LabelBase
    Friend WithEvents LabelBase15 As ControlesBase.LabelBase
    Friend WithEvents LabelBase14 As ControlesBase.LabelBase
    Friend WithEvents LabelBase13 As ControlesBase.LabelBase
    Friend WithEvents tbDacionPagos As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DTPFAplicacion As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents TxtClienteDacionPago As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents TexObservacionDacionPAGO As TextBox
    Friend WithEvents TxtMontoDacionPago As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents DTPFechaConvenioDacionPago As DateTimePicker
    Friend WithEvents LabelBase17 As ControlesBase.LabelBase
    Friend WithEvents LabelBase18 As ControlesBase.LabelBase
    Friend WithEvents LabelBase21 As ControlesBase.LabelBase
    Friend WithEvents LabelBase22 As ControlesBase.LabelBase
    Friend WithEvents LabelBase23 As ControlesBase.LabelBase
    Friend WithEvents TxtNombreDacioPago As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents LabelBase24 As ControlesBase.LabelBase
    Friend WithEvents BotonBase1 As ControlesBase.BotonBase
    Friend WithEvents BotonBase2 As ControlesBase.BotonBase
    Friend WithEvents BotonBase3 As ControlesBase.BotonBase
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents TextObservacionesVales As TextBox
    Friend WithEvents TxtMontoVales As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents LabelBase20 As ControlesBase.LabelBase
    Friend WithEvents LabelBase25 As ControlesBase.LabelBase
    Friend WithEvents ComboTipoVale As SigaMetClasses.Combos.ComboValeTipo
    Friend WithEvents ComboProveedor As SigaMetClasses.Combos.ComboProveedor
    Friend WithEvents LabelBase28 As ControlesBase.LabelBase
    Friend WithEvents FechaDocumentoVales As DateTimePicker
    Friend WithEvents LabelBase29 As ControlesBase.LabelBase
    Friend WithEvents txtClienteVales As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents LabelBase19 As ControlesBase.LabelBase
    Friend WithEvents LabelNombreVales As Label
    Friend WithEvents LabelBase27 As ControlesBase.LabelBase
    Friend WithEvents LabelBase30 As ControlesBase.LabelBase
    Friend WithEvents BtnBuscarClienteVales As Button
    Friend WithEvents LabelBase12 As ControlesBase.LabelBase
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents LabelBase32 As ControlesBase.LabelBase
    Friend WithEvents TextObservacionesAnticipo As TextBox
    Friend WithEvents TxtMontoAnticipo As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents LabelBase26 As ControlesBase.LabelBase
    Friend WithEvents LabelBase31 As ControlesBase.LabelBase
    Friend WithEvents TxtClienteAplicAntic As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents LabelBase34 As ControlesBase.LabelBase
    Friend WithEvents LabelNombreApAntic As Label
    Friend WithEvents LabelBase36 As ControlesBase.LabelBase
    Friend WithEvents BotonBuscarClienteApAnticipo As Button
    Private DetalleCobro As SigaMetClasses.sCobro
    Private TipoCobroliquidacion As Integer
    Private Total As Decimal

    Enum FormaPago
        Efectivo = 0
        ValesDespensa = 1
        Tarjeta = 2
        Cheque = 3
        AplicacionAnticipo = 4
        DacionPago = 5
        Transferencia = 6
    End Enum

    Private _MostrarDacion As Boolean
    Friend WithEvents btn_AnticipoAceptar As ControlesBase.BotonBase
    Friend WithEvents dgvSaldoAnticipo As DataGridView

    Public Property MostrarDacion() As Boolean
        Get
            Return _MostrarDacion
        End Get
        Set(ByVal value As Boolean)
            _MostrarDacion = value
        End Set
    End Property

    Private _listaCobros As New List(Of SigaMetClasses.CobroDetalladoDatos)
    Friend WithEvents año As DataGridViewTextBoxColumn

    Friend WithEvents folio As DataGridViewTextBoxColumn

    Friend WithEvents MontoSaldo As DataGridViewTextBoxColumn

    Public Property Cobros() As List(Of SigaMetClasses.CobroDetalladoDatos)
        Get
            Return _listaCobros
        End Get
        Set(ByVal value As List(Of SigaMetClasses.CobroDetalladoDatos))
            _listaCobros = value
        End Set
    End Property

    Private _ListaDebitoAnticipos As New List(Of DebitoAnticipo)
    Public Property DebitoAnticipos() As List(Of DebitoAnticipo)
        Get
            Return _ListaDebitoAnticipos
        End Get
        Set(ByVal value As List(Of DebitoAnticipo))
            _ListaDebitoAnticipos = value
        End Set
    End Property

    Public Sub New(ByVal intConsecutivo As Integer,
          Optional ByVal CapturaDetalle As Boolean = True, Optional ByVal DetalleCobro As Integer = 0)

        MyBase.New()
        InitializeComponent()
        Consecutivo = intConsecutivo

        If CapturaEfectivoVales = True Then
            btnAceptarVales1.Enabled = False
        End If
        If CapturaMixtaEfectivoVales = True Then
            'btnAceptarEfectivo.Enabled = False
            'btnAceptarVale.Enabled = False
        End If
        _CapturaDetalle = CapturaDetalle
        TipoCobroliquidacion = DetalleCobro
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        dgvSaldoAnticipo.AutoGenerateColumns = False
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
    Friend WithEvents tabTipoCobro As System.Windows.Forms.TabControl
    Friend WithEvents dtpFechaCheque As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblObservaciones As ControlesBase.LabelBase
    Friend WithEvents lblNoCheque As ControlesBase.LabelBase
    Friend WithEvents lblFechaCheque As ControlesBase.LabelBase
    Friend WithEvents lblNoCuenta As ControlesBase.LabelBase
    Friend WithEvents lblImporte As ControlesBase.LabelBase
    Friend WithEvents lblCliente As ControlesBase.LabelBase
    Friend WithEvents tbValesDespensa As System.Windows.Forms.TabPage
    Friend WithEvents btnAceptarVales1 As ControlesBase.BotonBase
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents tbTarjetaCredito As System.Windows.Forms.TabPage
    Friend WithEvents grpTarjetaCredito As System.Windows.Forms.GroupBox
    Friend WithEvents Label20 As ControlesBase.LabelBase
    Friend WithEvents LabelBase1 As ControlesBase.LabelBase
    Friend WithEvents LabelBase2 As ControlesBase.LabelBase
    Friend WithEvents LabelBase3 As ControlesBase.LabelBase
    Friend WithEvents btnAceptarTarjetaCredito As ControlesBase.BotonBase
    Friend WithEvents Label21 As ControlesBase.LabelBase
    Friend WithEvents lblTarjetaCredito As System.Windows.Forms.Label
    Friend WithEvents lblTitularTC As System.Windows.Forms.Label
    Friend WithEvents lblTipoTarjetaCredito As System.Windows.Forms.Label
    Friend WithEvents LabelBase4 As ControlesBase.LabelBase
    Friend WithEvents lblVigenciaTC As System.Windows.Forms.Label
    Friend WithEvents LabelBase5 As ControlesBase.LabelBase
    Friend WithEvents btnBuscarClienteTC As System.Windows.Forms.Button
    Friend WithEvents LabelBase6 As ControlesBase.LabelBase
    Friend WithEvents lblBancoNombre As System.Windows.Forms.Label
    Friend WithEvents LabelBase7 As ControlesBase.LabelBase
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents ComboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteCheque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteTC As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtImporteTC As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnAceptarChequeFicha As ControlesBase.BotonBase
    Friend WithEvents tbChequeFicha As System.Windows.Forms.TabPage
    Friend WithEvents grpChequeFicha As System.Windows.Forms.GroupBox
    Friend WithEvents txtDocumento As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtImporteDocumento As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSelTipoCobro))
        Me.tabTipoCobro = New System.Windows.Forms.TabControl()
        Me.tbEfectivo = New System.Windows.Forms.TabPage()
        Me.BotonBase1 = New ControlesBase.BotonBase()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TxtNumeroDecimal1 = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.LabelBase8 = New ControlesBase.LabelBase()
        Me.tbValesDespensa = New System.Windows.Forms.TabPage()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.TextObservacionesVales = New System.Windows.Forms.TextBox()
        Me.TxtMontoVales = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.LabelBase20 = New ControlesBase.LabelBase()
        Me.LabelBase25 = New ControlesBase.LabelBase()
        Me.ComboTipoVale = New SigaMetClasses.Combos.ComboValeTipo()
        Me.ComboProveedor = New SigaMetClasses.Combos.ComboProveedor()
        Me.LabelBase28 = New ControlesBase.LabelBase()
        Me.FechaDocumentoVales = New System.Windows.Forms.DateTimePicker()
        Me.LabelBase29 = New ControlesBase.LabelBase()
        Me.txtClienteVales = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.LabelBase19 = New ControlesBase.LabelBase()
        Me.LabelNombreVales = New System.Windows.Forms.Label()
        Me.LabelBase27 = New ControlesBase.LabelBase()
        Me.LabelBase30 = New ControlesBase.LabelBase()
        Me.BtnBuscarClienteVales = New System.Windows.Forms.Button()
        Me.btnAceptarVales1 = New ControlesBase.BotonBase()
        Me.tbTarjetaCredito = New System.Windows.Forms.TabPage()
        Me.btnAceptarTarjetaCredito = New ControlesBase.BotonBase()
        Me.grpTarjetaCredito = New System.Windows.Forms.GroupBox()
        Me.txtImporteTC = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtClienteTC = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.LabelBase7 = New ControlesBase.LabelBase()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.LabelBase6 = New ControlesBase.LabelBase()
        Me.lblVigenciaTC = New System.Windows.Forms.Label()
        Me.LabelBase5 = New ControlesBase.LabelBase()
        Me.lblTipoTarjetaCredito = New System.Windows.Forms.Label()
        Me.LabelBase4 = New ControlesBase.LabelBase()
        Me.lblBancoNombre = New System.Windows.Forms.Label()
        Me.LabelBase3 = New ControlesBase.LabelBase()
        Me.lblTarjetaCredito = New System.Windows.Forms.Label()
        Me.LabelBase2 = New ControlesBase.LabelBase()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.Label20 = New ControlesBase.LabelBase()
        Me.lblTitularTC = New System.Windows.Forms.Label()
        Me.btnBuscarClienteTC = New System.Windows.Forms.Button()
        Me.tbChequeFicha = New System.Windows.Forms.TabPage()
        Me.btnAceptarChequeFicha = New ControlesBase.BotonBase()
        Me.grpChequeFicha = New System.Windows.Forms.GroupBox()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtImporteDocumento = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtClienteCheque = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtNumeroCuenta = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtDocumento = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.ComboBanco = New SigaMetClasses.Combos.ComboBanco()
        Me.Label21 = New ControlesBase.LabelBase()
        Me.lblObservaciones = New ControlesBase.LabelBase()
        Me.dtpFechaCheque = New System.Windows.Forms.DateTimePicker()
        Me.lblNoCheque = New ControlesBase.LabelBase()
        Me.lblFechaCheque = New ControlesBase.LabelBase()
        Me.lblNoCuenta = New ControlesBase.LabelBase()
        Me.lblImporte = New ControlesBase.LabelBase()
        Me.lblCliente = New ControlesBase.LabelBase()
        Me.tbTransferencias = New System.Windows.Forms.TabPage()
        Me.BotonBase2 = New ControlesBase.BotonBase()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtClienteTransferencia = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.txtbObservacionesTranferencias = New System.Windows.Forms.TextBox()
        Me.TxtImporteTransferencia = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.ComboBancoTransferencia = New SigaMetClasses.Combos.ComboBanco()
        Me.TxtNumeroDocumentoTransferencia = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.TxtNumeroCuentaTransferencia = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.DTPFechaTransferencia = New System.Windows.Forms.DateTimePicker()
        Me.LabelBase16 = New ControlesBase.LabelBase()
        Me.LabelBase15 = New ControlesBase.LabelBase()
        Me.LabelBase14 = New ControlesBase.LabelBase()
        Me.LabelBase13 = New ControlesBase.LabelBase()
        Me.LabelBase12 = New ControlesBase.LabelBase()
        Me.LabelBase11 = New ControlesBase.LabelBase()
        Me.LabelBase10 = New ControlesBase.LabelBase()
        Me.TxtNombreTransferencia = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.LabelBase9 = New ControlesBase.LabelBase()
        Me.tbAplicAnticipo = New System.Windows.Forms.TabPage()
        Me.btn_AnticipoAceptar = New ControlesBase.BotonBase()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.dgvSaldoAnticipo = New System.Windows.Forms.DataGridView()
        Me.LabelBase32 = New ControlesBase.LabelBase()
        Me.TextObservacionesAnticipo = New System.Windows.Forms.TextBox()
        Me.TxtMontoAnticipo = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.LabelBase26 = New ControlesBase.LabelBase()
        Me.LabelBase31 = New ControlesBase.LabelBase()
        Me.TxtClienteAplicAntic = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.LabelBase34 = New ControlesBase.LabelBase()
        Me.LabelNombreApAntic = New System.Windows.Forms.Label()
        Me.LabelBase36 = New ControlesBase.LabelBase()
        Me.BotonBuscarClienteApAnticipo = New System.Windows.Forms.Button()
        Me.tbDacionPagos = New System.Windows.Forms.TabPage()
        Me.BotonBase3 = New ControlesBase.BotonBase()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DTPFAplicacion = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtClienteDacionPago = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.TexObservacionDacionPAGO = New System.Windows.Forms.TextBox()
        Me.TxtMontoDacionPago = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.DTPFechaConvenioDacionPago = New System.Windows.Forms.DateTimePicker()
        Me.LabelBase17 = New ControlesBase.LabelBase()
        Me.LabelBase18 = New ControlesBase.LabelBase()
        Me.LabelBase21 = New ControlesBase.LabelBase()
        Me.LabelBase22 = New ControlesBase.LabelBase()
        Me.LabelBase23 = New ControlesBase.LabelBase()
        Me.TxtNombreDacioPago = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.LabelBase24 = New ControlesBase.LabelBase()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.año = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.folio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MontoSaldo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tabTipoCobro.SuspendLayout()
        Me.tbEfectivo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbValesDespensa.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.tbTarjetaCredito.SuspendLayout()
        Me.grpTarjetaCredito.SuspendLayout()
        Me.tbChequeFicha.SuspendLayout()
        Me.grpChequeFicha.SuspendLayout()
        Me.tbTransferencias.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.tbAplicAnticipo.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvSaldoAnticipo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDacionPagos.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabTipoCobro
        '
        Me.tabTipoCobro.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabTipoCobro.Controls.Add(Me.tbEfectivo)
        Me.tabTipoCobro.Controls.Add(Me.tbValesDespensa)
        Me.tabTipoCobro.Controls.Add(Me.tbTarjetaCredito)
        Me.tabTipoCobro.Controls.Add(Me.tbChequeFicha)
        Me.tabTipoCobro.Controls.Add(Me.tbTransferencias)
        Me.tabTipoCobro.Controls.Add(Me.tbAplicAnticipo)
        Me.tabTipoCobro.Controls.Add(Me.tbDacionPagos)
        Me.tabTipoCobro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTipoCobro.HotTrack = True
        Me.tabTipoCobro.ImeMode = System.Windows.Forms.ImeMode.Off
        Me.tabTipoCobro.Location = New System.Drawing.Point(0, 0)
        Me.tabTipoCobro.Multiline = True
        Me.tabTipoCobro.Name = "tabTipoCobro"
        Me.tabTipoCobro.SelectedIndex = 0
        Me.tabTipoCobro.Size = New System.Drawing.Size(611, 351)
        Me.tabTipoCobro.TabIndex = 0
        '
        'tbEfectivo
        '
        Me.tbEfectivo.BackColor = System.Drawing.SystemColors.Control
        Me.tbEfectivo.Controls.Add(Me.BotonBase1)
        Me.tbEfectivo.Controls.Add(Me.GroupBox1)
        Me.tbEfectivo.Location = New System.Drawing.Point(4, 4)
        Me.tbEfectivo.Name = "tbEfectivo"
        Me.tbEfectivo.Size = New System.Drawing.Size(603, 325)
        Me.tbEfectivo.TabIndex = 6
        Me.tbEfectivo.Text = "Efectivo"
        '
        'BotonBase1
        '
        Me.BotonBase1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonBase1.Image = CType(resources.GetObject("BotonBase1.Image"), System.Drawing.Image)
        Me.BotonBase1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonBase1.Location = New System.Drawing.Point(515, 152)
        Me.BotonBase1.Name = "BotonBase1"
        Me.BotonBase1.Size = New System.Drawing.Size(80, 24)
        Me.BotonBase1.TabIndex = 34
        Me.BotonBase1.Text = "&Aceptar"
        Me.BotonBase1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TxtNumeroDecimal1)
        Me.GroupBox1.Controls.Add(Me.LabelBase8)
        Me.GroupBox1.Location = New System.Drawing.Point(62, 139)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(272, 48)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos del efectivo"
        '
        'TxtNumeroDecimal1
        '
        Me.TxtNumeroDecimal1.Location = New System.Drawing.Point(146, 16)
        Me.TxtNumeroDecimal1.Name = "TxtNumeroDecimal1"
        Me.TxtNumeroDecimal1.Size = New System.Drawing.Size(120, 21)
        Me.TxtNumeroDecimal1.TabIndex = 0
        '
        'LabelBase8
        '
        Me.LabelBase8.AutoSize = True
        Me.LabelBase8.Location = New System.Drawing.Point(16, 19)
        Me.LabelBase8.Name = "LabelBase8"
        Me.LabelBase8.Size = New System.Drawing.Size(74, 13)
        Me.LabelBase8.TabIndex = 28
        Me.LabelBase8.Text = "Importe total:"
        '
        'tbValesDespensa
        '
        Me.tbValesDespensa.BackColor = System.Drawing.SystemColors.Control
        Me.tbValesDespensa.Controls.Add(Me.GroupBox4)
        Me.tbValesDespensa.Controls.Add(Me.btnAceptarVales1)
        Me.tbValesDespensa.ImageIndex = 0
        Me.tbValesDespensa.Location = New System.Drawing.Point(4, 4)
        Me.tbValesDespensa.Name = "tbValesDespensa"
        Me.tbValesDespensa.Size = New System.Drawing.Size(603, 307)
        Me.tbValesDespensa.TabIndex = 3
        Me.tbValesDespensa.Text = "Vales Despensa"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.TextObservacionesVales)
        Me.GroupBox4.Controls.Add(Me.TxtMontoVales)
        Me.GroupBox4.Controls.Add(Me.LabelBase20)
        Me.GroupBox4.Controls.Add(Me.LabelBase25)
        Me.GroupBox4.Controls.Add(Me.ComboTipoVale)
        Me.GroupBox4.Controls.Add(Me.ComboProveedor)
        Me.GroupBox4.Controls.Add(Me.LabelBase28)
        Me.GroupBox4.Controls.Add(Me.FechaDocumentoVales)
        Me.GroupBox4.Controls.Add(Me.LabelBase29)
        Me.GroupBox4.Controls.Add(Me.txtClienteVales)
        Me.GroupBox4.Controls.Add(Me.LabelBase19)
        Me.GroupBox4.Controls.Add(Me.LabelNombreVales)
        Me.GroupBox4.Controls.Add(Me.LabelBase27)
        Me.GroupBox4.Controls.Add(Me.LabelBase30)
        Me.GroupBox4.Controls.Add(Me.BtnBuscarClienteVales)
        Me.GroupBox4.Location = New System.Drawing.Point(65, 29)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(333, 253)
        Me.GroupBox4.TabIndex = 31
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Datos de los vales de Despensa"
        '
        'TextObservacionesVales
        '
        Me.TextObservacionesVales.Location = New System.Drawing.Point(121, 197)
        Me.TextObservacionesVales.Multiline = True
        Me.TextObservacionesVales.Name = "TextObservacionesVales"
        Me.TextObservacionesVales.Size = New System.Drawing.Size(192, 48)
        Me.TextObservacionesVales.TabIndex = 52
        '
        'TxtMontoVales
        '
        Me.TxtMontoVales.Location = New System.Drawing.Point(121, 171)
        Me.TxtMontoVales.Name = "TxtMontoVales"
        Me.TxtMontoVales.Size = New System.Drawing.Size(192, 21)
        Me.TxtMontoVales.TabIndex = 51
        '
        'LabelBase20
        '
        Me.LabelBase20.AutoSize = True
        Me.LabelBase20.Location = New System.Drawing.Point(17, 201)
        Me.LabelBase20.Name = "LabelBase20"
        Me.LabelBase20.Size = New System.Drawing.Size(78, 13)
        Me.LabelBase20.TabIndex = 50
        Me.LabelBase20.Text = "Observaciones"
        '
        'LabelBase25
        '
        Me.LabelBase25.AutoSize = True
        Me.LabelBase25.Location = New System.Drawing.Point(17, 179)
        Me.LabelBase25.Name = "LabelBase25"
        Me.LabelBase25.Size = New System.Drawing.Size(37, 13)
        Me.LabelBase25.TabIndex = 49
        Me.LabelBase25.Text = "Monto"
        '
        'ComboTipoVale
        '
        Me.ComboTipoVale.Descripcion = Nothing
        Me.ComboTipoVale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoVale.DropDownWidth = 200
        Me.ComboTipoVale.Location = New System.Drawing.Point(120, 144)
        Me.ComboTipoVale.Name = "ComboTipoVale"
        Me.ComboTipoVale.Size = New System.Drawing.Size(192, 21)
        Me.ComboTipoVale.Status = Nothing
        Me.ComboTipoVale.TabIndex = 48
        Me.ComboTipoVale.ValeTipo = 0
        '
        'ComboProveedor
        '
        Me.ComboProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboProveedor.DropDownWidth = 200
        Me.ComboProveedor.Location = New System.Drawing.Point(120, 119)
        Me.ComboProveedor.Name = "ComboProveedor"
        Me.ComboProveedor.Nombre = Nothing
        Me.ComboProveedor.Size = New System.Drawing.Size(192, 21)
        Me.ComboProveedor.Status = Nothing
        Me.ComboProveedor.TabIndex = 46
        Me.ComboProveedor.ValeProveedor = 0
        '
        'LabelBase28
        '
        Me.LabelBase28.AutoSize = True
        Me.LabelBase28.Location = New System.Drawing.Point(17, 122)
        Me.LabelBase28.Name = "LabelBase28"
        Me.LabelBase28.Size = New System.Drawing.Size(57, 13)
        Me.LabelBase28.TabIndex = 45
        Me.LabelBase28.Text = "Proveedor"
        '
        'FechaDocumentoVales
        '
        Me.FechaDocumentoVales.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FechaDocumentoVales.Location = New System.Drawing.Point(120, 94)
        Me.FechaDocumentoVales.Name = "FechaDocumentoVales"
        Me.FechaDocumentoVales.Size = New System.Drawing.Size(192, 21)
        Me.FechaDocumentoVales.TabIndex = 43
        '
        'LabelBase29
        '
        Me.LabelBase29.AutoSize = True
        Me.LabelBase29.Location = New System.Drawing.Point(16, 97)
        Me.LabelBase29.Name = "LabelBase29"
        Me.LabelBase29.Size = New System.Drawing.Size(96, 13)
        Me.LabelBase29.TabIndex = 44
        Me.LabelBase29.Text = "Fecha documento:"
        '
        'txtClienteVales
        '
        Me.txtClienteVales.Location = New System.Drawing.Point(104, 32)
        Me.txtClienteVales.Name = "txtClienteVales"
        Me.txtClienteVales.Size = New System.Drawing.Size(160, 21)
        Me.txtClienteVales.TabIndex = 0
        '
        'LabelBase19
        '
        Me.LabelBase19.AutoSize = True
        Me.LabelBase19.Location = New System.Drawing.Point(16, 65)
        Me.LabelBase19.Name = "LabelBase19"
        Me.LabelBase19.Size = New System.Drawing.Size(48, 13)
        Me.LabelBase19.TabIndex = 40
        Me.LabelBase19.Text = "Nombre:"
        '
        'LabelNombreVales
        '
        Me.LabelNombreVales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelNombreVales.Location = New System.Drawing.Point(104, 56)
        Me.LabelNombreVales.Name = "LabelNombreVales"
        Me.LabelNombreVales.Size = New System.Drawing.Size(208, 32)
        Me.LabelNombreVales.TabIndex = 41
        Me.LabelNombreVales.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase27
        '
        Me.LabelBase27.AutoSize = True
        Me.LabelBase27.Location = New System.Drawing.Point(16, 147)
        Me.LabelBase27.Name = "LabelBase27"
        Me.LabelBase27.Size = New System.Drawing.Size(65, 13)
        Me.LabelBase27.TabIndex = 33
        Me.LabelBase27.Text = "Tipo de Vale"
        '
        'LabelBase30
        '
        Me.LabelBase30.AutoSize = True
        Me.LabelBase30.Location = New System.Drawing.Point(16, 35)
        Me.LabelBase30.Name = "LabelBase30"
        Me.LabelBase30.Size = New System.Drawing.Size(44, 13)
        Me.LabelBase30.TabIndex = 22
        Me.LabelBase30.Text = "Cliente:"
        '
        'BtnBuscarClienteVales
        '
        Me.BtnBuscarClienteVales.Image = CType(resources.GetObject("BtnBuscarClienteVales.Image"), System.Drawing.Image)
        Me.BtnBuscarClienteVales.Location = New System.Drawing.Point(269, 32)
        Me.BtnBuscarClienteVales.Name = "BtnBuscarClienteVales"
        Me.BtnBuscarClienteVales.Size = New System.Drawing.Size(44, 21)
        Me.BtnBuscarClienteVales.TabIndex = 1
        '
        'btnAceptarVales1
        '
        Me.btnAceptarVales1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarVales1.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptarVales1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarVales1.Location = New System.Drawing.Point(505, 150)
        Me.btnAceptarVales1.Name = "btnAceptarVales1"
        Me.btnAceptarVales1.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarVales1.TabIndex = 1
        Me.btnAceptarVales1.Text = "&Aceptar"
        Me.btnAceptarVales1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarVales1.UseVisualStyleBackColor = False
        '
        'tbTarjetaCredito
        '
        Me.tbTarjetaCredito.Controls.Add(Me.btnAceptarTarjetaCredito)
        Me.tbTarjetaCredito.Controls.Add(Me.grpTarjetaCredito)
        Me.tbTarjetaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTarjetaCredito.Location = New System.Drawing.Point(4, 4)
        Me.tbTarjetaCredito.Name = "tbTarjetaCredito"
        Me.tbTarjetaCredito.Size = New System.Drawing.Size(603, 307)
        Me.tbTarjetaCredito.TabIndex = 0
        Me.tbTarjetaCredito.Text = "Tarjeta "
        '
        'btnAceptarTarjetaCredito
        '
        Me.btnAceptarTarjetaCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarTarjetaCredito.Image = CType(resources.GetObject("btnAceptarTarjetaCredito.Image"), System.Drawing.Image)
        Me.btnAceptarTarjetaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarTarjetaCredito.Location = New System.Drawing.Point(505, 150)
        Me.btnAceptarTarjetaCredito.Name = "btnAceptarTarjetaCredito"
        Me.btnAceptarTarjetaCredito.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarTarjetaCredito.TabIndex = 3
        Me.btnAceptarTarjetaCredito.Text = "&Aceptar"
        Me.btnAceptarTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpTarjetaCredito
        '
        Me.grpTarjetaCredito.Controls.Add(Me.txtImporteTC)
        Me.grpTarjetaCredito.Controls.Add(Me.txtClienteTC)
        Me.grpTarjetaCredito.Controls.Add(Me.lblBanco)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase7)
        Me.grpTarjetaCredito.Controls.Add(Me.lblClienteNombre)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase6)
        Me.grpTarjetaCredito.Controls.Add(Me.lblVigenciaTC)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase5)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTipoTarjetaCredito)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase4)
        Me.grpTarjetaCredito.Controls.Add(Me.lblBancoNombre)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase3)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTarjetaCredito)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase2)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase1)
        Me.grpTarjetaCredito.Controls.Add(Me.Label20)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTitularTC)
        Me.grpTarjetaCredito.Controls.Add(Me.btnBuscarClienteTC)
        Me.grpTarjetaCredito.Location = New System.Drawing.Point(48, 36)
        Me.grpTarjetaCredito.Name = "grpTarjetaCredito"
        Me.grpTarjetaCredito.Size = New System.Drawing.Size(372, 253)
        Me.grpTarjetaCredito.TabIndex = 30
        Me.grpTarjetaCredito.TabStop = False
        Me.grpTarjetaCredito.Text = "Datos de la tarjeta de crédito o débito"
        '
        'txtImporteTC
        '
        Me.txtImporteTC.Location = New System.Drawing.Point(104, 216)
        Me.txtImporteTC.Name = "txtImporteTC"
        Me.txtImporteTC.Size = New System.Drawing.Size(160, 21)
        Me.txtImporteTC.TabIndex = 2
        '
        'txtClienteTC
        '
        Me.txtClienteTC.Location = New System.Drawing.Point(104, 32)
        Me.txtClienteTC.Name = "txtClienteTC"
        Me.txtClienteTC.Size = New System.Drawing.Size(160, 21)
        Me.txtClienteTC.TabIndex = 0
        '
        'lblBanco
        '
        Me.lblBanco.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBanco.Location = New System.Drawing.Point(104, 144)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(44, 21)
        Me.lblBanco.TabIndex = 42
        Me.lblBanco.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblBanco.Visible = False
        '
        'LabelBase7
        '
        Me.LabelBase7.AutoSize = True
        Me.LabelBase7.Location = New System.Drawing.Point(16, 65)
        Me.LabelBase7.Name = "LabelBase7"
        Me.LabelBase7.Size = New System.Drawing.Size(48, 13)
        Me.LabelBase7.TabIndex = 40
        Me.LabelBase7.Text = "Nombre:"
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClienteNombre.Location = New System.Drawing.Point(104, 56)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(160, 32)
        Me.lblClienteNombre.TabIndex = 41
        Me.lblClienteNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase6
        '
        Me.LabelBase6.AutoSize = True
        Me.LabelBase6.Location = New System.Drawing.Point(16, 219)
        Me.LabelBase6.Name = "LabelBase6"
        Me.LabelBase6.Size = New System.Drawing.Size(49, 13)
        Me.LabelBase6.TabIndex = 39
        Me.LabelBase6.Text = "Importe:"
        '
        'lblVigenciaTC
        '
        Me.lblVigenciaTC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVigenciaTC.Location = New System.Drawing.Point(104, 192)
        Me.lblVigenciaTC.Name = "lblVigenciaTC"
        Me.lblVigenciaTC.Size = New System.Drawing.Size(160, 21)
        Me.lblVigenciaTC.TabIndex = 38
        Me.lblVigenciaTC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase5
        '
        Me.LabelBase5.AutoSize = True
        Me.LabelBase5.Location = New System.Drawing.Point(16, 195)
        Me.LabelBase5.Name = "LabelBase5"
        Me.LabelBase5.Size = New System.Drawing.Size(50, 13)
        Me.LabelBase5.TabIndex = 37
        Me.LabelBase5.Text = "Vigencia:"
        '
        'lblTipoTarjetaCredito
        '
        Me.lblTipoTarjetaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoTarjetaCredito.Location = New System.Drawing.Point(104, 168)
        Me.lblTipoTarjetaCredito.Name = "lblTipoTarjetaCredito"
        Me.lblTipoTarjetaCredito.Size = New System.Drawing.Size(160, 21)
        Me.lblTipoTarjetaCredito.TabIndex = 36
        Me.lblTipoTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase4
        '
        Me.LabelBase4.AutoSize = True
        Me.LabelBase4.Location = New System.Drawing.Point(16, 171)
        Me.LabelBase4.Name = "LabelBase4"
        Me.LabelBase4.Size = New System.Drawing.Size(82, 13)
        Me.LabelBase4.TabIndex = 35
        Me.LabelBase4.Text = "Tipo de tarjeta:"
        '
        'lblBancoNombre
        '
        Me.lblBancoNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblBancoNombre.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblBancoNombre.Location = New System.Drawing.Point(104, 144)
        Me.lblBancoNombre.Name = "lblBancoNombre"
        Me.lblBancoNombre.Size = New System.Drawing.Size(160, 21)
        Me.lblBancoNombre.TabIndex = 34
        Me.lblBancoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase3
        '
        Me.LabelBase3.AutoSize = True
        Me.LabelBase3.Location = New System.Drawing.Point(16, 147)
        Me.LabelBase3.Name = "LabelBase3"
        Me.LabelBase3.Size = New System.Drawing.Size(40, 13)
        Me.LabelBase3.TabIndex = 33
        Me.LabelBase3.Text = "Banco:"
        '
        'lblTarjetaCredito
        '
        Me.lblTarjetaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTarjetaCredito.Location = New System.Drawing.Point(104, 120)
        Me.lblTarjetaCredito.Name = "lblTarjetaCredito"
        Me.lblTarjetaCredito.Size = New System.Drawing.Size(160, 21)
        Me.lblTarjetaCredito.TabIndex = 32
        Me.lblTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase2
        '
        Me.LabelBase2.AutoSize = True
        Me.LabelBase2.Location = New System.Drawing.Point(16, 123)
        Me.LabelBase2.Name = "LabelBase2"
        Me.LabelBase2.Size = New System.Drawing.Size(66, 13)
        Me.LabelBase2.TabIndex = 26
        Me.LabelBase2.Text = "No. Tarjeta:"
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.Location = New System.Drawing.Point(16, 99)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(41, 13)
        Me.LabelBase1.TabIndex = 24
        Me.LabelBase1.Text = "Titular:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Cliente:"
        '
        'lblTitularTC
        '
        Me.lblTitularTC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitularTC.Location = New System.Drawing.Point(104, 96)
        Me.lblTitularTC.Name = "lblTitularTC"
        Me.lblTitularTC.Size = New System.Drawing.Size(160, 21)
        Me.lblTitularTC.TabIndex = 31
        Me.lblTitularTC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarClienteTC
        '
        Me.btnBuscarClienteTC.Image = CType(resources.GetObject("btnBuscarClienteTC.Image"), System.Drawing.Image)
        Me.btnBuscarClienteTC.Location = New System.Drawing.Point(269, 32)
        Me.btnBuscarClienteTC.Name = "btnBuscarClienteTC"
        Me.btnBuscarClienteTC.Size = New System.Drawing.Size(48, 21)
        Me.btnBuscarClienteTC.TabIndex = 1
        '
        'tbChequeFicha
        '
        Me.tbChequeFicha.Controls.Add(Me.btnAceptarChequeFicha)
        Me.tbChequeFicha.Controls.Add(Me.grpChequeFicha)
        Me.tbChequeFicha.Location = New System.Drawing.Point(4, 4)
        Me.tbChequeFicha.Name = "tbChequeFicha"
        Me.tbChequeFicha.Size = New System.Drawing.Size(603, 307)
        Me.tbChequeFicha.TabIndex = 2
        Me.tbChequeFicha.Text = "Cheque / Ficha de deposito"
        '
        'btnAceptarChequeFicha
        '
        Me.btnAceptarChequeFicha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarChequeFicha.Image = CType(resources.GetObject("btnAceptarChequeFicha.Image"), System.Drawing.Image)
        Me.btnAceptarChequeFicha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarChequeFicha.Location = New System.Drawing.Point(505, 150)
        Me.btnAceptarChequeFicha.Name = "btnAceptarChequeFicha"
        Me.btnAceptarChequeFicha.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarChequeFicha.TabIndex = 7
        Me.btnAceptarChequeFicha.Text = "&Aceptar"
        Me.btnAceptarChequeFicha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpChequeFicha
        '
        Me.grpChequeFicha.Controls.Add(Me.lblNombre)
        Me.grpChequeFicha.Controls.Add(Me.btnBuscarCliente)
        Me.grpChequeFicha.Controls.Add(Me.txtImporteDocumento)
        Me.grpChequeFicha.Controls.Add(Me.txtClienteCheque)
        Me.grpChequeFicha.Controls.Add(Me.txtNumeroCuenta)
        Me.grpChequeFicha.Controls.Add(Me.txtDocumento)
        Me.grpChequeFicha.Controls.Add(Me.txtObservaciones)
        Me.grpChequeFicha.Controls.Add(Me.ComboBanco)
        Me.grpChequeFicha.Controls.Add(Me.Label21)
        Me.grpChequeFicha.Controls.Add(Me.lblObservaciones)
        Me.grpChequeFicha.Controls.Add(Me.dtpFechaCheque)
        Me.grpChequeFicha.Controls.Add(Me.lblNoCheque)
        Me.grpChequeFicha.Controls.Add(Me.lblFechaCheque)
        Me.grpChequeFicha.Controls.Add(Me.lblNoCuenta)
        Me.grpChequeFicha.Controls.Add(Me.lblImporte)
        Me.grpChequeFicha.Controls.Add(Me.lblCliente)
        Me.grpChequeFicha.Location = New System.Drawing.Point(24, 27)
        Me.grpChequeFicha.Name = "grpChequeFicha"
        Me.grpChequeFicha.Size = New System.Drawing.Size(328, 270)
        Me.grpChequeFicha.TabIndex = 28
        Me.grpChequeFicha.TabStop = False
        Me.grpChequeFicha.Text = "Datos del cheque"
        '
        'lblNombre
        '
        Me.lblNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombre.Location = New System.Drawing.Point(120, 128)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(192, 21)
        Me.lblNombre.TabIndex = 34
        Me.lblNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Image)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(286, 104)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(26, 21)
        Me.btnBuscarCliente.TabIndex = 31
        '
        'txtImporteDocumento
        '
        Me.txtImporteDocumento.Location = New System.Drawing.Point(120, 176)
        Me.txtImporteDocumento.Name = "txtImporteDocumento"
        Me.txtImporteDocumento.Size = New System.Drawing.Size(192, 21)
        Me.txtImporteDocumento.TabIndex = 5
        '
        'txtClienteCheque
        '
        Me.txtClienteCheque.Location = New System.Drawing.Point(120, 104)
        Me.txtClienteCheque.Name = "txtClienteCheque"
        Me.txtClienteCheque.Size = New System.Drawing.Size(160, 21)
        Me.txtClienteCheque.TabIndex = 3
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(120, 80)
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(192, 21)
        Me.txtNumeroCuenta.TabIndex = 2
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(120, 32)
        Me.txtDocumento.MaxLength = 7
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(192, 21)
        Me.txtDocumento.TabIndex = 0
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(120, 200)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(192, 48)
        Me.txtObservaciones.TabIndex = 6
        '
        'ComboBanco
        '
        Me.ComboBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco.DropDownWidth = 200
        Me.ComboBanco.Location = New System.Drawing.Point(120, 152)
        Me.ComboBanco.Name = "ComboBanco"
        Me.ComboBanco.Size = New System.Drawing.Size(192, 21)
        Me.ComboBanco.TabIndex = 4
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 155)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Banco:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(16, 200)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(82, 13)
        Me.lblObservaciones.TabIndex = 21
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'dtpFechaCheque
        '
        Me.dtpFechaCheque.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaCheque.Location = New System.Drawing.Point(120, 56)
        Me.dtpFechaCheque.Name = "dtpFechaCheque"
        Me.dtpFechaCheque.Size = New System.Drawing.Size(192, 21)
        Me.dtpFechaCheque.TabIndex = 1
        '
        'lblNoCheque
        '
        Me.lblNoCheque.AutoSize = True
        Me.lblNoCheque.Location = New System.Drawing.Point(16, 35)
        Me.lblNoCheque.Name = "lblNoCheque"
        Me.lblNoCheque.Size = New System.Drawing.Size(85, 13)
        Me.lblNoCheque.TabIndex = 11
        Me.lblNoCheque.Text = "No. Documento:"
        '
        'lblFechaCheque
        '
        Me.lblFechaCheque.AutoSize = True
        Me.lblFechaCheque.Location = New System.Drawing.Point(16, 59)
        Me.lblFechaCheque.Name = "lblFechaCheque"
        Me.lblFechaCheque.Size = New System.Drawing.Size(96, 13)
        Me.lblFechaCheque.TabIndex = 16
        Me.lblFechaCheque.Text = "Fecha documento:"
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Location = New System.Drawing.Point(16, 83)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(66, 13)
        Me.lblNoCuenta.TabIndex = 12
        Me.lblNoCuenta.Text = "No. Cuenta:"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(16, 179)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(49, 13)
        Me.lblImporte.TabIndex = 19
        Me.lblImporte.Text = "Importe:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(16, 107)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(44, 13)
        Me.lblCliente.TabIndex = 13
        Me.lblCliente.Text = "Cliente:"
        '
        'tbTransferencias
        '
        Me.tbTransferencias.BackColor = System.Drawing.SystemColors.Control
        Me.tbTransferencias.Controls.Add(Me.BotonBase2)
        Me.tbTransferencias.Controls.Add(Me.GroupBox2)
        Me.tbTransferencias.Location = New System.Drawing.Point(4, 4)
        Me.tbTransferencias.Name = "tbTransferencias"
        Me.tbTransferencias.Padding = New System.Windows.Forms.Padding(3)
        Me.tbTransferencias.Size = New System.Drawing.Size(603, 307)
        Me.tbTransferencias.TabIndex = 4
        Me.tbTransferencias.Text = "Transferencias"
        '
        'BotonBase2
        '
        Me.BotonBase2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonBase2.Image = CType(resources.GetObject("BotonBase2.Image"), System.Drawing.Image)
        Me.BotonBase2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonBase2.Location = New System.Drawing.Point(496, 151)
        Me.BotonBase2.Name = "BotonBase2"
        Me.BotonBase2.Size = New System.Drawing.Size(80, 24)
        Me.BotonBase2.TabIndex = 34
        Me.BotonBase2.Text = "&Aceptar"
        Me.BotonBase2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button1)
        Me.GroupBox2.Controls.Add(Me.TxtClienteTransferencia)
        Me.GroupBox2.Controls.Add(Me.txtbObservacionesTranferencias)
        Me.GroupBox2.Controls.Add(Me.TxtImporteTransferencia)
        Me.GroupBox2.Controls.Add(Me.ComboBancoTransferencia)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroDocumentoTransferencia)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroCuentaTransferencia)
        Me.GroupBox2.Controls.Add(Me.DTPFechaTransferencia)
        Me.GroupBox2.Controls.Add(Me.LabelBase16)
        Me.GroupBox2.Controls.Add(Me.LabelBase15)
        Me.GroupBox2.Controls.Add(Me.LabelBase14)
        Me.GroupBox2.Controls.Add(Me.LabelBase13)
        Me.GroupBox2.Controls.Add(Me.LabelBase12)
        Me.GroupBox2.Controls.Add(Me.LabelBase11)
        Me.GroupBox2.Controls.Add(Me.LabelBase10)
        Me.GroupBox2.Controls.Add(Me.TxtNombreTransferencia)
        Me.GroupBox2.Controls.Add(Me.LabelBase9)
        Me.GroupBox2.Location = New System.Drawing.Point(38, 24)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(452, 269)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Datos de la Transferencia"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(302, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(42, 21)
        Me.Button1.TabIndex = 44
        '
        'TxtClienteTransferencia
        '
        Me.TxtClienteTransferencia.Location = New System.Drawing.Point(136, 33)
        Me.TxtClienteTransferencia.Name = "TxtClienteTransferencia"
        Me.TxtClienteTransferencia.Size = New System.Drawing.Size(160, 21)
        Me.TxtClienteTransferencia.TabIndex = 43
        '
        'txtbObservacionesTranferencias
        '
        Me.txtbObservacionesTranferencias.Location = New System.Drawing.Point(136, 208)
        Me.txtbObservacionesTranferencias.Multiline = True
        Me.txtbObservacionesTranferencias.Name = "txtbObservacionesTranferencias"
        Me.txtbObservacionesTranferencias.Size = New System.Drawing.Size(208, 48)
        Me.txtbObservacionesTranferencias.TabIndex = 42
        '
        'TxtImporteTransferencia
        '
        Me.TxtImporteTransferencia.Location = New System.Drawing.Point(136, 182)
        Me.TxtImporteTransferencia.Name = "TxtImporteTransferencia"
        Me.TxtImporteTransferencia.Size = New System.Drawing.Size(208, 21)
        Me.TxtImporteTransferencia.TabIndex = 41
        '
        'ComboBancoTransferencia
        '
        Me.ComboBancoTransferencia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBancoTransferencia.DropDownWidth = 200
        Me.ComboBancoTransferencia.Location = New System.Drawing.Point(136, 156)
        Me.ComboBancoTransferencia.Name = "ComboBancoTransferencia"
        Me.ComboBancoTransferencia.Size = New System.Drawing.Size(208, 21)
        Me.ComboBancoTransferencia.TabIndex = 40
        '
        'TxtNumeroDocumentoTransferencia
        '
        Me.TxtNumeroDocumentoTransferencia.Location = New System.Drawing.Point(136, 130)
        Me.TxtNumeroDocumentoTransferencia.MaxLength = 7
        Me.TxtNumeroDocumentoTransferencia.Name = "TxtNumeroDocumentoTransferencia"
        Me.TxtNumeroDocumentoTransferencia.Size = New System.Drawing.Size(208, 21)
        Me.TxtNumeroDocumentoTransferencia.TabIndex = 39
        '
        'TxtNumeroCuentaTransferencia
        '
        Me.TxtNumeroCuentaTransferencia.Location = New System.Drawing.Point(136, 105)
        Me.TxtNumeroCuentaTransferencia.Name = "TxtNumeroCuentaTransferencia"
        Me.TxtNumeroCuentaTransferencia.Size = New System.Drawing.Size(208, 21)
        Me.TxtNumeroCuentaTransferencia.TabIndex = 38
        '
        'DTPFechaTransferencia
        '
        Me.DTPFechaTransferencia.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaTransferencia.Location = New System.Drawing.Point(136, 79)
        Me.DTPFechaTransferencia.Name = "DTPFechaTransferencia"
        Me.DTPFechaTransferencia.Size = New System.Drawing.Size(192, 21)
        Me.DTPFechaTransferencia.TabIndex = 37
        '
        'LabelBase16
        '
        Me.LabelBase16.AutoSize = True
        Me.LabelBase16.Location = New System.Drawing.Point(30, 210)
        Me.LabelBase16.Name = "LabelBase16"
        Me.LabelBase16.Size = New System.Drawing.Size(82, 13)
        Me.LabelBase16.TabIndex = 36
        Me.LabelBase16.Text = "Observaciones:"
        '
        'LabelBase15
        '
        Me.LabelBase15.AutoSize = True
        Me.LabelBase15.Location = New System.Drawing.Point(30, 188)
        Me.LabelBase15.Name = "LabelBase15"
        Me.LabelBase15.Size = New System.Drawing.Size(49, 13)
        Me.LabelBase15.TabIndex = 35
        Me.LabelBase15.Text = "Importe:"
        '
        'LabelBase14
        '
        Me.LabelBase14.AutoSize = True
        Me.LabelBase14.Location = New System.Drawing.Point(30, 162)
        Me.LabelBase14.Name = "LabelBase14"
        Me.LabelBase14.Size = New System.Drawing.Size(40, 13)
        Me.LabelBase14.TabIndex = 34
        Me.LabelBase14.Text = "Banco:"
        '
        'LabelBase13
        '
        Me.LabelBase13.AutoSize = True
        Me.LabelBase13.Location = New System.Drawing.Point(30, 138)
        Me.LabelBase13.Name = "LabelBase13"
        Me.LabelBase13.Size = New System.Drawing.Size(81, 13)
        Me.LabelBase13.TabIndex = 33
        Me.LabelBase13.Text = "No. Documento"
        '
        'LabelBase12
        '
        Me.LabelBase12.AutoSize = True
        Me.LabelBase12.Location = New System.Drawing.Point(30, 113)
        Me.LabelBase12.Name = "LabelBase12"
        Me.LabelBase12.Size = New System.Drawing.Size(99, 13)
        Me.LabelBase12.TabIndex = 32
        Me.LabelBase12.Text = "Número de cuenta:"
        '
        'LabelBase11
        '
        Me.LabelBase11.AutoSize = True
        Me.LabelBase11.Location = New System.Drawing.Point(30, 87)
        Me.LabelBase11.Name = "LabelBase11"
        Me.LabelBase11.Size = New System.Drawing.Size(96, 13)
        Me.LabelBase11.TabIndex = 31
        Me.LabelBase11.Text = "Fecha documento:"
        '
        'LabelBase10
        '
        Me.LabelBase10.AutoSize = True
        Me.LabelBase10.Location = New System.Drawing.Point(30, 65)
        Me.LabelBase10.Name = "LabelBase10"
        Me.LabelBase10.Size = New System.Drawing.Size(48, 13)
        Me.LabelBase10.TabIndex = 30
        Me.LabelBase10.Text = "Nombre:"
        '
        'TxtNombreTransferencia
        '
        Me.TxtNombreTransferencia.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNombreTransferencia.Enabled = False
        Me.TxtNombreTransferencia.Location = New System.Drawing.Point(136, 57)
        Me.TxtNombreTransferencia.Name = "TxtNombreTransferencia"
        Me.TxtNombreTransferencia.Size = New System.Drawing.Size(294, 21)
        Me.TxtNombreTransferencia.TabIndex = 29
        '
        'LabelBase9
        '
        Me.LabelBase9.AutoSize = True
        Me.LabelBase9.Location = New System.Drawing.Point(30, 41)
        Me.LabelBase9.Name = "LabelBase9"
        Me.LabelBase9.Size = New System.Drawing.Size(44, 13)
        Me.LabelBase9.TabIndex = 28
        Me.LabelBase9.Text = "Cliente:"
        '
        'tbAplicAnticipo
        '
        Me.tbAplicAnticipo.BackColor = System.Drawing.SystemColors.Control
        Me.tbAplicAnticipo.Controls.Add(Me.btn_AnticipoAceptar)
        Me.tbAplicAnticipo.Controls.Add(Me.GroupBox5)
        Me.tbAplicAnticipo.Location = New System.Drawing.Point(4, 4)
        Me.tbAplicAnticipo.Name = "tbAplicAnticipo"
        Me.tbAplicAnticipo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAplicAnticipo.Size = New System.Drawing.Size(603, 325)
        Me.tbAplicAnticipo.TabIndex = 5
        Me.tbAplicAnticipo.Text = "Aplicación Anticipo"
        '
        'btn_AnticipoAceptar
        '
        Me.btn_AnticipoAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btn_AnticipoAceptar.Image = CType(resources.GetObject("btn_AnticipoAceptar.Image"), System.Drawing.Image)
        Me.btn_AnticipoAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btn_AnticipoAceptar.Location = New System.Drawing.Point(485, 135)
        Me.btn_AnticipoAceptar.Name = "btn_AnticipoAceptar"
        Me.btn_AnticipoAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btn_AnticipoAceptar.TabIndex = 55
        Me.btn_AnticipoAceptar.Text = "&Aceptar"
        Me.btn_AnticipoAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.dgvSaldoAnticipo)
        Me.GroupBox5.Controls.Add(Me.LabelBase32)
        Me.GroupBox5.Controls.Add(Me.TextObservacionesAnticipo)
        Me.GroupBox5.Controls.Add(Me.TxtMontoAnticipo)
        Me.GroupBox5.Controls.Add(Me.LabelBase26)
        Me.GroupBox5.Controls.Add(Me.LabelBase31)
        Me.GroupBox5.Controls.Add(Me.TxtClienteAplicAntic)
        Me.GroupBox5.Controls.Add(Me.LabelBase34)
        Me.GroupBox5.Controls.Add(Me.LabelNombreApAntic)
        Me.GroupBox5.Controls.Add(Me.LabelBase36)
        Me.GroupBox5.Controls.Add(Me.BotonBuscarClienteApAnticipo)
        Me.GroupBox5.Location = New System.Drawing.Point(56, 32)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(423, 287)
        Me.GroupBox5.TabIndex = 32
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Datos de los vales de Despensa"
        '
        'dgvSaldoAnticipo
        '
        Me.dgvSaldoAnticipo.AllowUserToAddRows = False
        Me.dgvSaldoAnticipo.AllowUserToDeleteRows = False
        Me.dgvSaldoAnticipo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSaldoAnticipo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.año, Me.folio, Me.MontoSaldo})
        Me.dgvSaldoAnticipo.DataMember = "añomovimiento"
        Me.dgvSaldoAnticipo.Location = New System.Drawing.Point(104, 91)
        Me.dgvSaldoAnticipo.Name = "dgvSaldoAnticipo"
        Me.dgvSaldoAnticipo.ReadOnly = True
        Me.dgvSaldoAnticipo.Size = New System.Drawing.Size(313, 126)
        Me.dgvSaldoAnticipo.TabIndex = 54
        '
        'LabelBase32
        '
        Me.LabelBase32.AutoSize = True
        Me.LabelBase32.Location = New System.Drawing.Point(17, 103)
        Me.LabelBase32.Name = "LabelBase32"
        Me.LabelBase32.Size = New System.Drawing.Size(37, 13)
        Me.LabelBase32.TabIndex = 53
        Me.LabelBase32.Text = "Saldo:"
        '
        'TextObservacionesAnticipo
        '
        Me.TextObservacionesAnticipo.Location = New System.Drawing.Point(104, 250)
        Me.TextObservacionesAnticipo.Multiline = True
        Me.TextObservacionesAnticipo.Name = "TextObservacionesAnticipo"
        Me.TextObservacionesAnticipo.Size = New System.Drawing.Size(313, 21)
        Me.TextObservacionesAnticipo.TabIndex = 52
        '
        'TxtMontoAnticipo
        '
        Me.TxtMontoAnticipo.Location = New System.Drawing.Point(104, 223)
        Me.TxtMontoAnticipo.Name = "TxtMontoAnticipo"
        Me.TxtMontoAnticipo.Size = New System.Drawing.Size(154, 21)
        Me.TxtMontoAnticipo.TabIndex = 51
        '
        'LabelBase26
        '
        Me.LabelBase26.AutoSize = True
        Me.LabelBase26.Location = New System.Drawing.Point(16, 258)
        Me.LabelBase26.Name = "LabelBase26"
        Me.LabelBase26.Size = New System.Drawing.Size(78, 13)
        Me.LabelBase26.TabIndex = 50
        Me.LabelBase26.Text = "Observaciones"
        '
        'LabelBase31
        '
        Me.LabelBase31.AutoSize = True
        Me.LabelBase31.Location = New System.Drawing.Point(17, 231)
        Me.LabelBase31.Name = "LabelBase31"
        Me.LabelBase31.Size = New System.Drawing.Size(37, 13)
        Me.LabelBase31.TabIndex = 49
        Me.LabelBase31.Text = "Monto"
        '
        'TxtClienteAplicAntic
        '
        Me.TxtClienteAplicAntic.Location = New System.Drawing.Point(104, 32)
        Me.TxtClienteAplicAntic.Name = "TxtClienteAplicAntic"
        Me.TxtClienteAplicAntic.Size = New System.Drawing.Size(154, 21)
        Me.TxtClienteAplicAntic.TabIndex = 0
        '
        'LabelBase34
        '
        Me.LabelBase34.AutoSize = True
        Me.LabelBase34.Location = New System.Drawing.Point(16, 65)
        Me.LabelBase34.Name = "LabelBase34"
        Me.LabelBase34.Size = New System.Drawing.Size(48, 13)
        Me.LabelBase34.TabIndex = 40
        Me.LabelBase34.Text = "Nombre:"
        '
        'LabelNombreApAntic
        '
        Me.LabelNombreApAntic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.LabelNombreApAntic.Enabled = False
        Me.LabelNombreApAntic.Location = New System.Drawing.Point(104, 56)
        Me.LabelNombreApAntic.Name = "LabelNombreApAntic"
        Me.LabelNombreApAntic.Size = New System.Drawing.Size(313, 32)
        Me.LabelNombreApAntic.TabIndex = 41
        Me.LabelNombreApAntic.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LabelBase36
        '
        Me.LabelBase36.AutoSize = True
        Me.LabelBase36.Location = New System.Drawing.Point(16, 35)
        Me.LabelBase36.Name = "LabelBase36"
        Me.LabelBase36.Size = New System.Drawing.Size(44, 13)
        Me.LabelBase36.TabIndex = 22
        Me.LabelBase36.Text = "Cliente:"
        '
        'BotonBuscarClienteApAnticipo
        '
        Me.BotonBuscarClienteApAnticipo.Image = CType(resources.GetObject("BotonBuscarClienteApAnticipo.Image"), System.Drawing.Image)
        Me.BotonBuscarClienteApAnticipo.Location = New System.Drawing.Point(273, 32)
        Me.BotonBuscarClienteApAnticipo.Name = "BotonBuscarClienteApAnticipo"
        Me.BotonBuscarClienteApAnticipo.Size = New System.Drawing.Size(48, 21)
        Me.BotonBuscarClienteApAnticipo.TabIndex = 1
        '
        'tbDacionPagos
        '
        Me.tbDacionPagos.BackColor = System.Drawing.SystemColors.Control
        Me.tbDacionPagos.Controls.Add(Me.BotonBase3)
        Me.tbDacionPagos.Controls.Add(Me.GroupBox3)
        Me.tbDacionPagos.Location = New System.Drawing.Point(4, 4)
        Me.tbDacionPagos.Name = "tbDacionPagos"
        Me.tbDacionPagos.Padding = New System.Windows.Forms.Padding(3)
        Me.tbDacionPagos.Size = New System.Drawing.Size(603, 307)
        Me.tbDacionPagos.TabIndex = 7
        Me.tbDacionPagos.Text = "Dación de Pagos"
        '
        'BotonBase3
        '
        Me.BotonBase3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BotonBase3.Image = CType(resources.GetObject("BotonBase3.Image"), System.Drawing.Image)
        Me.BotonBase3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BotonBase3.Location = New System.Drawing.Point(515, 137)
        Me.BotonBase3.Name = "BotonBase3"
        Me.BotonBase3.Size = New System.Drawing.Size(80, 24)
        Me.BotonBase3.TabIndex = 35
        Me.BotonBase3.Text = "&Aceptar"
        Me.BotonBase3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.DTPFAplicacion)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.TxtClienteDacionPago)
        Me.GroupBox3.Controls.Add(Me.TexObservacionDacionPAGO)
        Me.GroupBox3.Controls.Add(Me.TxtMontoDacionPago)
        Me.GroupBox3.Controls.Add(Me.DTPFechaConvenioDacionPago)
        Me.GroupBox3.Controls.Add(Me.LabelBase17)
        Me.GroupBox3.Controls.Add(Me.LabelBase18)
        Me.GroupBox3.Controls.Add(Me.LabelBase21)
        Me.GroupBox3.Controls.Add(Me.LabelBase22)
        Me.GroupBox3.Controls.Add(Me.LabelBase23)
        Me.GroupBox3.Controls.Add(Me.TxtNombreDacioPago)
        Me.GroupBox3.Controls.Add(Me.LabelBase24)
        Me.GroupBox3.Location = New System.Drawing.Point(60, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(452, 295)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Dacion de Pagos"
        '
        'DTPFAplicacion
        '
        Me.DTPFAplicacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFAplicacion.Location = New System.Drawing.Point(160, 111)
        Me.DTPFAplicacion.Name = "DTPFAplicacion"
        Me.DTPFAplicacion.Size = New System.Drawing.Size(192, 21)
        Me.DTPFAplicacion.TabIndex = 45
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(326, 29)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 21)
        Me.Button2.TabIndex = 44
        '
        'TxtClienteDacionPago
        '
        Me.TxtClienteDacionPago.Location = New System.Drawing.Point(160, 30)
        Me.TxtClienteDacionPago.Name = "TxtClienteDacionPago"
        Me.TxtClienteDacionPago.Size = New System.Drawing.Size(160, 21)
        Me.TxtClienteDacionPago.TabIndex = 43
        '
        'TexObservacionDacionPAGO
        '
        Me.TexObservacionDacionPAGO.Location = New System.Drawing.Point(160, 165)
        Me.TexObservacionDacionPAGO.Multiline = True
        Me.TexObservacionDacionPAGO.Name = "TexObservacionDacionPAGO"
        Me.TexObservacionDacionPAGO.Size = New System.Drawing.Size(273, 48)
        Me.TexObservacionDacionPAGO.TabIndex = 42
        '
        'TxtMontoDacionPago
        '
        Me.TxtMontoDacionPago.Location = New System.Drawing.Point(160, 138)
        Me.TxtMontoDacionPago.Name = "TxtMontoDacionPago"
        Me.TxtMontoDacionPago.Size = New System.Drawing.Size(192, 21)
        Me.TxtMontoDacionPago.TabIndex = 41
        '
        'DTPFechaConvenioDacionPago
        '
        Me.DTPFechaConvenioDacionPago.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFechaConvenioDacionPago.Location = New System.Drawing.Point(160, 84)
        Me.DTPFechaConvenioDacionPago.Name = "DTPFechaConvenioDacionPago"
        Me.DTPFechaConvenioDacionPago.Size = New System.Drawing.Size(192, 21)
        Me.DTPFechaConvenioDacionPago.TabIndex = 37
        '
        'LabelBase17
        '
        Me.LabelBase17.AutoSize = True
        Me.LabelBase17.Location = New System.Drawing.Point(30, 168)
        Me.LabelBase17.Name = "LabelBase17"
        Me.LabelBase17.Size = New System.Drawing.Size(71, 13)
        Me.LabelBase17.TabIndex = 36
        Me.LabelBase17.Text = "Observación:"
        '
        'LabelBase18
        '
        Me.LabelBase18.AutoSize = True
        Me.LabelBase18.Location = New System.Drawing.Point(30, 141)
        Me.LabelBase18.Name = "LabelBase18"
        Me.LabelBase18.Size = New System.Drawing.Size(41, 13)
        Me.LabelBase18.TabIndex = 35
        Me.LabelBase18.Text = "Monto:"
        '
        'LabelBase21
        '
        Me.LabelBase21.AutoSize = True
        Me.LabelBase21.Location = New System.Drawing.Point(30, 113)
        Me.LabelBase21.Name = "LabelBase21"
        Me.LabelBase21.Size = New System.Drawing.Size(115, 13)
        Me.LabelBase21.TabIndex = 32
        Me.LabelBase21.Text = "Fecha de la aplicación:"
        '
        'LabelBase22
        '
        Me.LabelBase22.AutoSize = True
        Me.LabelBase22.Location = New System.Drawing.Point(30, 90)
        Me.LabelBase22.Name = "LabelBase22"
        Me.LabelBase22.Size = New System.Drawing.Size(103, 13)
        Me.LabelBase22.TabIndex = 31
        Me.LabelBase22.Text = "Fecha del convenio:"
        '
        'LabelBase23
        '
        Me.LabelBase23.AutoSize = True
        Me.LabelBase23.Location = New System.Drawing.Point(30, 60)
        Me.LabelBase23.Name = "LabelBase23"
        Me.LabelBase23.Size = New System.Drawing.Size(48, 13)
        Me.LabelBase23.TabIndex = 30
        Me.LabelBase23.Text = "Nombre:"
        '
        'TxtNombreDacioPago
        '
        Me.TxtNombreDacioPago.BackColor = System.Drawing.SystemColors.Control
        Me.TxtNombreDacioPago.Enabled = False
        Me.TxtNombreDacioPago.Location = New System.Drawing.Point(160, 57)
        Me.TxtNombreDacioPago.Name = "TxtNombreDacioPago"
        Me.TxtNombreDacioPago.Size = New System.Drawing.Size(275, 21)
        Me.TxtNombreDacioPago.TabIndex = 29
        '
        'LabelBase24
        '
        Me.LabelBase24.AutoSize = True
        Me.LabelBase24.Location = New System.Drawing.Point(30, 33)
        Me.LabelBase24.Name = "LabelBase24"
        Me.LabelBase24.Size = New System.Drawing.Size(44, 13)
        Me.LabelBase24.TabIndex = 28
        Me.LabelBase24.Text = "Cliente:"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'año
        '
        Me.año.DataPropertyName = "AñoMovimiento"
        Me.año.HeaderText = "Año"
        Me.año.Name = "año"
        Me.año.ReadOnly = True
        '
        'folio
        '
        Me.folio.DataPropertyName = "FolioMovimiento"
        Me.folio.HeaderText = "Folio"
        Me.folio.Name = "folio"
        Me.folio.ReadOnly = True
        '
        'MontoSaldo
        '
        Me.MontoSaldo.DataPropertyName = "MontoSaldo"
        Me.MontoSaldo.HeaderText = "Saldo"
        Me.MontoSaldo.Name = "MontoSaldo"
        Me.MontoSaldo.ReadOnly = True
        '
        'frmSelTipoCobro
        '
        Me.AcceptButton = Me.btnAceptarVales1
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(611, 351)
        Me.Controls.Add(Me.tabTipoCobro)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelTipoCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de cobros"
        Me.tabTipoCobro.ResumeLayout(False)
        Me.tbEfectivo.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.tbValesDespensa.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.tbTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.PerformLayout()
        Me.tbChequeFicha.ResumeLayout(False)
        Me.grpChequeFicha.ResumeLayout(False)
        Me.grpChequeFicha.PerformLayout()
        Me.tbTransferencias.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbAplicAnticipo.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgvSaldoAnticipo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDacionPagos.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Cobros"


    Private Sub btnRegistrarCobro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        'Select Case DetalleCobro
        '    Case 1
        '        Debug.WriteLine(DetalleCobro)
        '    Case 6, 7, 8
        '        Debug.WriteLine("Between 6 and 8, inclusive")
        '    Case 9 To 10
        '        Debug.WriteLine("Equal to 9 or 10")
        '    Case Else
        '        Debug.WriteLine("Not between 1 and 10, inclusive")
        'End Select


    End Sub
    'EFECTIVO Y / O VALES
    Private Sub btnAceptarVales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarVales1.Click
        If CapturaEfectivoVales = False Then
            If TxtMontoVales.Text <> "" And IsNumeric(TxtMontoVales.Text) Then
                If _CapturaDetalle = True Then
                    AltaVales()
                    LimpiarVales()
                    Remisiones()
                End If
                DialogResult = DialogResult.OK

            End If
        Else
            MessageBox.Show("Ya capturó efectivo o vales")
        End If
    End Sub

    'TARJETA DE CREDITO
    Private Sub btnAceptarTarjetaCredito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarTarjetaCredito.Click
        If lblClienteNombre.Text <> "" Then
            If txtImporteTC.Text <> "" And IsNumeric(txtImporteTC.Text) Then
                If _CapturaDetalle = True Then
                    Dim frmCaptura As New frmCapCobranzaDoc()
                    frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                    frmCaptura.ImporteCobro = CType(txtImporteTC.Text, Decimal)
                    AltaTarjeta()
                    LimpiarTarjeta()
                    Remisiones()
                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("Debe teclear el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Debe teclear el número de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    'CHEQUE Y FICHA DE DEPOSITO
    Private Sub btnAceptarChequeFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarChequeFicha.Click
        If ValidaCapturaChequeFicha() Then
            If _CapturaDetalle = True Then
                AltaCheque()
                LimpiarCheque()
                Remisiones()
                DialogResult = DialogResult.OK
            End If
        End If
    End Sub

#End Region



    Private Function ValidaCapturaChequeFicha() As Boolean
        'Con esta función valido que se estén capturando todos los datos necesarios
        'del cheque ó de la ficha de depósito.
        If txtImporteDocumento.Text <> "" And IsNumeric(txtImporteDocumento.Text) Then
            If txtDocumento.Text <> "" And IsNumeric(txtDocumento.Text) Then
                If txtDocumento.Text.Trim.Length = 7 Then
                    If txtNumeroCuenta.Text <> "" And IsNumeric(txtNumeroCuenta.Text) Then
                        If txtClienteCheque.Text <> "" And IsNumeric(txtClienteCheque.Text) And lblNombre.Text <> "" Then
                            If CType(ComboBanco.SelectedValue, Short) > 0 Then
                                Return True
                            Else
                                MessageBox.Show("Debe seleccionar el banco.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                Return False
                            End If
                        Else
                            MessageBox.Show("Debe teclear el número de un cliente válido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    Else
                        MessageBox.Show("Debe teclear el número de cuenta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Else
                    MessageBox.Show("El número de cheque debe ser de 7 dígitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtDocumento.Focus()
                    txtDocumento.SelectAll()
                    Return False
                End If
            Else
                MessageBox.Show("Debe teclear el número del cheque.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Return False
            End If
        Else
            MessageBox.Show("Debe teclear el importe del cheque.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return False
        End If
    End Function

    Private Sub tabTipoCobro_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabTipoCobro.SelectedIndexChanged
        Select Case tabTipoCobro.SelectedTab.Name
            Case Is = "tbEfectivoVales"
                AcceptButton = btnAceptarVales1
                TxtMontoVales.Focus()
            Case Is = "tbChequeFicha"
                AcceptButton = btnAceptarChequeFicha
                txtDocumento.Focus()
            Case Is = "tbTarjetaCredito"
                AcceptButton = btnAceptarTarjetaCredito
                txtClienteTC.Focus()
        End Select
    End Sub

    Private Sub frmSelTipoCobro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not _MostrarDacion Then
            tabTipoCobro.TabPages.Remove(tbDacionPagos)
        End If

        ComboBanco.CargaDatos(True)
        ComboProveedor.CargaDatos()
        ComboTipoVale.CargaDatos()

        ComboBancoTransferencia.CargaDatos(True)
        If CapturaEfectivoVales = True Then
            btnAceptarVales1.Enabled = False
            tabTipoCobro.SelectedTab = tbChequeFicha
        End If
        SeleccionarTipocobro()
        AddHandler txtImporteTC.KeyDown, AddressOf ManejaFlechas
    End Sub

    Private Sub txtClienteTC_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcceptButton = btnBuscarClienteTC
    End Sub

    Private Sub txtClienteTC_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        AcceptButton = btnAceptarTarjetaCredito
    End Sub

    Private Sub LimpiaInfoTarjetaCredito()
        lblClienteNombre.Text = ""
        lblTitularTC.Text = ""
        lblTarjetaCredito.Text = ""
        lblBancoNombre.Text = ""
        lblTipoTarjetaCredito.Text = ""
        lblVigenciaTC.Text = ""
    End Sub

    Private Sub ConsultaTarjetaCredito(ByVal Cliente As Integer)
        Dim oTC As New SigaMetClasses.cTarjetaCredito()
        Dim dr As SqlDataReader
        dr = oTC.ConsultaActiva(Cliente)
        Do While dr.Read
            lblClienteNombre.Text = CType(dr("ClienteNombre"), String)
            lblTitularTC.Text = CType(dr("Titular"), String)
            lblTarjetaCredito.Text = CType(dr("TarjetaCredito"), String)
            lblBanco.Text = CType(dr("Banco"), String)
            lblBancoNombre.Text = CType(dr("BancoNombre"), String)
            lblTipoTarjetaCredito.Text = CType(dr("TipoTarjetaCreditoDescripcion"), String)
            lblVigenciaTC.Text = CType(dr("MesVigencia"), String) & " / " & CType(dr("AñoVigencia"), String)
        Loop
        dr.Close()
    End Sub

    Private Sub ConsultaTarjetaCredito(ByVal Cliente As Integer, ByVal URLGateway As String)
        Dim lSolicitud As RTGMGateway.SolicitudGateway = New RTGMGateway.SolicitudGateway()
        Dim lRemoteGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway()
        lRemoteGateway.URLServicio = URLGateway


        Dim oTC As New SigaMetClasses.cTarjetaCredito()
        Dim dr As SqlDataReader
        Try
            dr = oTC.ConsultaActiva(Cliente)
            Do While dr.Read
                'lblClienteNombre.Text = CType(dr("ClienteNombre"), String)
                lblTitularTC.Text = CType(dr("Titular"), String)
                lblTarjetaCredito.Text = CType(dr("TarjetaCredito"), String)
                lblBanco.Text = CType(dr("Banco"), String)
                lblBancoNombre.Text = CType(dr("BancoNombre"), String)
                lblTipoTarjetaCredito.Text = CType(dr("TipoTarjetaCreditoDescripcion"), String)
                lblVigenciaTC.Text = CType(dr("MesVigencia"), String) & " / " & CType(dr("AñoVigencia"), String)
            Loop
            If dr.HasRows Then
                lSolicitud.Fuente = RTGMCore.Fuente.CRM
                lSolicitud.Sucursal = GLOBAL_SucursalUsuario
                lSolicitud.IDCliente = Cliente
                Dim lDireccionEntrega As RTGMCore.DireccionEntrega = lRemoteGateway.buscarDireccionEntrega(lSolicitud)
                lblClienteNombre.Text = lDireccionEntrega.Nombre
            End If
            dr.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub btnBuscarClienteTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarClienteTC.Click
        Dim lParametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim lURLGateway As String = ""
        'Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
        lParametro.Dispose()


        If txtClienteTC.Text <> "" And IsNumeric(txtClienteTC.Text) Then
            LimpiaInfoTarjetaCredito()

            If String.IsNullOrEmpty(lURLGateway) Then
                ConsultaTarjetaCredito(CType(txtClienteTC.Text, Integer))
            Else
                ConsultaTarjetaCredito(CType(txtClienteTC.Text, Integer), lURLGateway)
            End If

            If lblTarjetaCredito.Text = "" Then
                MessageBox.Show("No existen tarjetas de crédito del cliente especificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                txtImporteTC.Focus()
            End If
        End If
    End Sub

    Private Sub ManejaFlechas(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dtpFechaCheque.KeyDown, MyBase.KeyDown
        If e.KeyCode = Keys.F5 Then
            tabTipoCobro.SelectedTab = tbValesDespensa
            Exit Sub
        End If
        If e.KeyCode = Keys.F6 Then
            tabTipoCobro.SelectedTab = tbChequeFicha
            Exit Sub
        End If
        If e.KeyCode = Keys.F7 Then
            tabTipoCobro.SelectedTab = tbTarjetaCredito
        End If
        If e.KeyCode = Keys.Down Then
            SendKeys.Send("{TAB}")
        End If
        If e.KeyCode = Keys.Left Or e.KeyCode = Keys.Right Then
            Select Case tabTipoCobro.SelectedTab.Name
                Case Is = "tbEfectivoVales"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbChequeFicha
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbTarjetaCredito
                Case Is = "tbCheque"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbTarjetaCredito
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbValesDespensa
                Case Is = "tbTarjetaCredito"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbValesDespensa
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbChequeFicha
            End Select
        End If
    End Sub

    Private Sub rbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque
    End Sub

    Private Sub rbFicha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click

        Dim lParametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        'Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
        Dim lURLGateway As String = ""
        lParametro.Dispose()

        If Trim(txtClienteCheque.Text) <> "" Then
            Dim frmConCliente As SigaMetClasses.frmConsultaCliente
            If String.IsNullOrEmpty(lURLGateway) Then
                frmConCliente = New SigaMetClasses.frmConsultaCliente(CType(txtClienteCheque.Text, Integer))
            Else
                frmConCliente = New SigaMetClasses.frmConsultaCliente(CType(txtClienteCheque.Text, Integer), lURLGateway)
            End If

            frmConCliente.ShowDialog()
        End If

    End Sub

    Private Sub txtClienteCheque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClienteCheque.Leave
        If txtClienteCheque.Text <> "" Then
            Dim oCliente As New SigaMetClasses.cCliente()
            oCliente.Consulta(CType(txtClienteCheque.Text, Integer))
            lblNombre.Text = oCliente.Nombre
            oCliente = Nothing
        End If

    End Sub

    Private Sub BotonBase1_Click(sender As Object, e As EventArgs) Handles BotonBase1.Click
        If TxtNumeroDecimal1.Text.Trim <> "" Then
            AltaPagoEfectivo()
            TxtNumeroDecimal1.Clear()
            Remisiones()
            DialogResult = DialogResult.OK
        End If
    End Sub

    Public Sub SeleccionarTipocobro()

        If FormadePago.Cheque = TipoCobroliquidacion Then
            tabTipoCobro.SelectedIndex = 3

        End If
        If FormadePago.Tarjeta = TipoCobroliquidacion Then
            tabTipoCobro.SelectedIndex = 2

        End If
        If FormadePago.Transferencia = TipoCobroliquidacion Then
            tabTipoCobro.SelectedIndex = 4

        End If
        If FormadePago.ValesDespensa = TipoCobroliquidacion Then
            tabTipoCobro.SelectedIndex = 1

        End If
        If FormadePago.AplicacionAnticipo = TipoCobroliquidacion Then
            tabTipoCobro.SelectedIndex = 5

        End If
        If FormadePago.Efectivo = TipoCobroliquidacion Then
            tabTipoCobro.SelectedIndex = 0
        End If
    End Sub

    Public Sub AltaPagoEfectivo()
        Dim insertaCobro As New SigaMetClasses.CobroDetalladoDatos()

        With insertaCobro

            .SaldoAFavor = False
            .AñoCobro = CShort(DateTime.Now.Year)
            .Cobro = 7
            .Impuesto = 10
            .Importe = CDec(TxtNumeroDecimal1.Text)
            .Total = 200 + .Impuesto

            If .Total < .Importe Then
                If MessageBox.Show("Se generará un saldo a favor ¿está de acuerdo?", "Captura cobros",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = DialogResult.Yes Then
                    .SaldoAFavor = True
                Else
                    MessageBox.Show("Pago efectivo ¡cancelado!")
                    Exit Sub
                End If
            End If


            .Referencia = "NULL" ' puede ser vacio
            .Banco = CShort("0") 'puede ser null
            .FAlta = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Status = "EMITIDO"
            .TipoCobro = 5
            .NumeroCheque = "NULL" ' puede ser vacio
            .FCheque = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .NumeroCuenta = "NULL"
            .Observaciones = "NULL"
            .FDevolucion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .RazonDevCheque = Nothing
            .Cliente = 0
            .Saldo = 10
            .Usuario = GLOBAL_IDUsuario
            .FActualizacion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Folio = 0
            .FDeposito = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .FolioAtt = 0
            .AñoAtt = CShort("0")
            .NumeroCuentaDestino = "NULL"
            .BancoOrigen = CShort("0")
            .StatusSaldoAFavor = "NULL"
            .AñoCobroOrigen = CShort("0")
            .CobroOrigen = 0
            .TPV = False
        End With
        _listaCobros.Add(insertaCobro)
        MessageBox.Show("Pago con efectivo registrado")
    End Sub

    Public Sub AltaCheque()
        Dim insertaCobro As New SigaMetClasses.CobroDetalladoDatos()

        With insertaCobro
            .SaldoAFavor = False
            .Cobro = 0
            .AñoCobro = CShort(DateTime.Now.Year)
            .Banco = CShort(ComboBanco.SelectedValue)
            .FAlta = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Status = "EMITIDO"
            .TipoCobro = 3 ' el tipo cobro para che que es el numero 3
            .NumeroCheque = txtNumeroCuenta.Text
            .FCheque = dtpFechaCheque.Value
            .NumeroCuenta = txtNumeroCuenta.Text
            .Observaciones = txtObservaciones.Text
            .Cliente = CInt(txtClienteCheque.Text)
            .RazonDevCheque = Nothing
            .Usuario = GLOBAL_IDUsuario
            .Impuesto = 10
            .Importe = CDec(txtImporteDocumento.Text)
            .Total = 100 + .Impuesto
            'datos hardcord
            If .Total < .Importe Then
                If MessageBox.Show("Se generará un saldo a favor ¿está de acuerdo?", "Captura cobros",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = DialogResult.Yes Then
                    .SaldoAFavor = True
                Else
                    MessageBox.Show("Pago cheque ¡cancelado!")
                    Exit Sub
                End If
            End If
            .Referencia = "NULL" ' puede ser vacio
            .FDevolucion = Date.MinValue
            .Saldo = 10
            .FActualizacion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Folio = 0
            .FDeposito = Date.MinValue
            .FolioAtt = 0
            .AñoAtt = CShort("0")
            .NumeroCuentaDestino = "NULL"
            .BancoOrigen = CShort("0") 'cual es banco origen
            .StatusSaldoAFavor = "NULL"
            .AñoCobroOrigen = CShort("0")
            .CobroOrigen = 0
            .TPV = False

        End With
        _listaCobros.Add(insertaCobro)

        MessageBox.Show("Pago con cheque registrado")
        TxtNumeroDecimal1.Clear()
    End Sub

    Public Sub AltaTransferencia()
        Dim insertaCobro As New SigaMetClasses.CobroDetalladoDatos()

        With insertaCobro
            .SaldoAFavor = False
            .AñoCobro = CShort(DateTime.Now.Year)
            .Cobro = 0
            'Datos reales

            .Cliente = CInt(TxtClienteTransferencia.Text)
            .FCheque = CDate(DTPFechaTransferencia.Text)
            .NumeroCuenta = TxtNumeroCuentaTransferencia.Text
            .Banco = CShort(ComboBancoTransferencia.SelectedValue)
            .Observaciones = txtbObservacionesTranferencias.Text
            .TipoCobro = 10
            .FAlta = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Status = "EMITIDO"
            .Usuario = GLOBAL_IDUsuario

            'empieza valores hardcode
            .Impuesto = 10
            .Total = 100 + .Impuesto
            .Importe = CDec(TxtImporteTransferencia.Text)
            If .Total < .Importe Then
                If MessageBox.Show("Se generará un saldo a favor ¿está de acuerdo?", "Captura cobros",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = DialogResult.Yes Then
                    .SaldoAFavor = True
                Else
                    MessageBox.Show("Pago Transferencia ¡cancelado!")
                    .SaldoAFavor = False
                    Exit Sub
                End If
            End If
            .Referencia = "NULL" ' puede ser vacio
            .NumeroCheque = "NULL" ' puede ser vacio
            .FDevolucion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .RazonDevCheque = Nothing
            .Saldo = 10
            .FActualizacion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Folio = 0
            .FDeposito = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .FolioAtt = 0
            .AñoAtt = CShort("0")
            .NumeroCuentaDestino = "NULL"
            .BancoOrigen = CShort("0")
            .StatusSaldoAFavor = "NULL"
            .AñoCobroOrigen = CShort("0")
            .CobroOrigen = 0
            .TPV = False
        End With
        _listaCobros.Add(insertaCobro)

        MessageBox.Show("Pago por transferencia registrado")
        TxtNumeroDecimal1.Clear()
    End Sub

    Private Sub BotonBase2_Click(sender As Object, e As EventArgs) Handles BotonBase2.Click
        If TxtImporteTransferencia.Text <> "" And ComboBancoTransferencia.Text <> "" Then
            AltaTransferencia()
            LimpiarTransferencia()
            Remisiones()
            DialogResult = DialogResult.OK
        End If

    End Sub

    Public Sub AltaTarjeta()
        Dim insertaCobro As New SigaMetClasses.CobroDetalladoDatos()

        With insertaCobro
            .TPV = True
            .SaldoAFavor = False
            .AñoCobro = CShort(DateTime.Now.Year)
            .Cobro = 0
            .Cliente = CInt(txtClienteTC.Text)
            .FCheque = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .NumeroCuenta = "NULL"
            .Banco = CShort(lblBanco.Text)
            .Observaciones = "NULL"
            .TipoCobro = 6
            'credito = 6 en tipocobro
            ' debito =19 en tipo de cobro
            .FAlta = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Status = "EMITIDO"
            .Usuario = GLOBAL_IDUsuario
            'empieza valores hardcode
            .Impuesto = 10
            .Total = 100 + .Impuesto
            .Importe = CDec(txtImporteTC.Text)
            If .Total < .Importe Then
                If MessageBox.Show("Se generará un saldo a favor ¿está de acuerdo?", "Captura cobros",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = DialogResult.Yes Then
                    .SaldoAFavor = True
                Else
                    MessageBox.Show("Pago tarjeta ¡cancelado!")
                    Exit Sub
                End If
            End If
            .Referencia = "NULL" ' puede ser vacio
            .NumeroCheque = "NULL" ' puede ser vacio
            .FDevolucion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .RazonDevCheque = Nothing
            .Saldo = 10
            .FActualizacion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Folio = 0
            .FDeposito = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .FolioAtt = 0
            .AñoAtt = CShort("0")
            .NumeroCuentaDestino = "NULL"
            .BancoOrigen = CShort("0")
            .StatusSaldoAFavor = "NULL"
            .AñoCobroOrigen = CShort("0")
            .CobroOrigen = 0
        End With

        _listaCobros.Add(insertaCobro)

        MessageBox.Show("Pago con tarjeta registrado")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub

    Public Sub LimpiarCheque()
        txtDocumento.Clear()
        txtNumeroCuenta.Clear()
        txtClienteCheque.Clear()
        lblNombre.Text = ""
        ComboBanco.SelectedItem = 1
        txtImporteDocumento.Clear()
        txtObservaciones.Clear()

    End Sub

    Public Sub LimpiarTarjeta()
        txtClienteTC.Clear()
        lblClienteNombre.Text = ""
        lblTitularTC.Text = ""
        lblTarjetaCredito.Text = ""
        lblBancoNombre.Text = ""
        lblTipoTarjetaCredito.Text = ""
        lblVigenciaTC.Text = ""
        txtImporteTC.Clear()



    End Sub

    Public Sub LimpiarTransferencia()
        TxtClienteTransferencia.Clear()
        TxtNombreTransferencia.Clear()
        TxtNumeroCuentaTransferencia.Clear()
        TxtNumeroDocumentoTransferencia.Clear()
        ComboBancoTransferencia.SelectedIndex = 0
        TxtImporteTransferencia.Clear()
        txtbObservacionesTranferencias.Clear()
    End Sub

    Private Sub TxtClienteTransferencia_Leave(sender As Object, e As EventArgs) Handles TxtClienteTransferencia.Leave
        If TxtClienteTransferencia.Text <> "" Then
            Dim oCliente As New SigaMetClasses.cCliente()
            oCliente.Consulta(CType(TxtClienteTransferencia.Text, Integer))
            TxtNombreTransferencia.Text = oCliente.Nombre
            oCliente = Nothing
        End If
    End Sub

    Private Sub TxtClienteTransferencia_TextChanged(sender As Object, e As EventArgs) Handles TxtClienteTransferencia.TextChanged

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub



    Private Sub BtnBuscarClienteVales_Click(sender As Object, e As EventArgs) Handles BtnBuscarClienteVales.Click
        Dim lParametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
        lParametro.Dispose()

        If Trim(txtClienteVales.Text) <> "" Then
            Dim frmConCliente As SigaMetClasses.frmConsultaCliente
            If String.IsNullOrEmpty(lURLGateway) Then
                frmConCliente = New SigaMetClasses.frmConsultaCliente(CType(txtClienteVales.Text, Integer))
            Else
                frmConCliente = New SigaMetClasses.frmConsultaCliente(CType(txtClienteVales.Text, Integer), lURLGateway)
            End If

            frmConCliente.ShowDialog()
        End If
    End Sub



    Private Sub BotonBuscarClienteApAnticipo_Click(sender As Object, e As EventArgs) Handles BotonBuscarClienteApAnticipo.Click
        Dim lParametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim lURLGateway As String = ""
        '= CType(lParametro.Parametros.Item("URLGateway"), String)
        lParametro.Dispose()

        If Trim(txtClienteVales.Text) <> "" Then
            Dim frmConCliente As SigaMetClasses.frmConsultaCliente
            If String.IsNullOrEmpty(lURLGateway) Then
                frmConCliente = New SigaMetClasses.frmConsultaCliente(CType(TxtClienteAplicAntic.Text, Integer))
            Else
                frmConCliente = New SigaMetClasses.frmConsultaCliente(CType(TxtClienteAplicAntic.Text, Integer), lURLGateway)
            End If

            frmConCliente.ShowDialog()
        End If

        BuscarAnticipos(CType(TxtClienteAplicAntic.Text, Integer), "0", 0, 0)



        'Dim oResult As List(Of DebitoAnticipo) = _ListaDebitoAnticipos.GroupBy(Function(v) New With {v.anio, v.folio}).ToList(Of DebitoAnticipo)




    End Sub

    Private Sub BuscarAnticipos(ByVal Cliente As Integer, ByVal Status As String, ByVal Folio As Integer, ByVal Anio As Integer)
        Dim oMvtoConciliarCobro As New SigaMetClasses.cMovimientoAConciliarCobro()
        Dim dt As New DataTable()
        dt = oMvtoConciliarCobro.ConsultarSaldoAnticipo(Cliente, Status, Folio, Anio)
        Dim TextoSaldo As String = ""

        If dt.Rows.Count = 0 Then
            MessageBox.Show(" El Cliente " + Cliente.ToString() + " no dispone de anticipos.")
        Else
            dgvSaldoAnticipo.AutoGenerateColumns = False
            dgvSaldoAnticipo.DataSource = dt
            dgvSaldoAnticipo.AutoGenerateColumns = False
            'For Each row As DataRow In dt.Rows
            '    TextoSaldo = TextoSaldo + row.Item("Saldo").ToString() + Environment.NewLine
            'Next row

            'TxtSaldoAnticipo.Text = TextoSaldo
            ''  TxtSaldoAnticipo.DataBindings.Add("Text", dt, "Saldo")

        End If




    End Sub


    Private Sub txtClienteVales_Leave(sender As Object, e As EventArgs) Handles txtClienteVales.Leave
        Dim oCliente As New SigaMetClasses.cCliente()
        oCliente.Consulta(CType(txtClienteVales.Text, Integer))
        LabelNombreVales.Text = oCliente.Nombre
        oCliente = Nothing
    End Sub

    Private Sub TxtClienteAplicAntic_Leave(sender As Object, e As EventArgs) Handles TxtClienteAplicAntic.Leave
        Dim oCliente As New SigaMetClasses.cCliente()
        If TxtClienteAplicAntic.Text.Trim.Length <> 0 Then
            oCliente.Consulta(CType(TxtClienteAplicAntic.Text, Integer))
            LabelNombreApAntic.Text = oCliente.Nombre
            oCliente = Nothing
        End If
        BuscarAnticipos(CType(TxtClienteAplicAntic.Text, Integer), "0", 0, 0)
    End Sub

    Public Sub Remisiones()
        Dim frmRemisiones As New frmRemisiones(Total)
        frmRemisiones.ObtenerRemisiones = _TablaRemisiones
        If frmRemisiones.ShowDialog() = DialogResult.OK Then
            Cursor = Cursors.WaitCursor
            Cursor = Cursors.Default
        Else
            _TablaRemisiones = frmRemisiones.ObtenerRemisiones
            Close()
        End If
    End Sub



    Public Sub AltaVales()
        Dim insertaCobro As New SigaMetClasses.CobroDetalladoDatos()

        With insertaCobro
            .TPV = True
            .SaldoAFavor = False
            .AñoCobro = CShort(DateTime.Now.Year)
            .Cobro = 0
            .Cliente = CInt(txtClienteVales.Text)
            .FCheque = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .NumeroCuenta = "NULL"
            .Banco = CShort(ComboProveedor.SelectedValue)
            .Observaciones = TextObservacionesVales.Text
            .TipoCobro = CByte(SigaMetClasses.Enumeradores.enumTipoCobro.Vales)
            .FAlta = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Status = "EMITIDO"
            .Usuario = GLOBAL_IDUsuario
            .Impuesto = 10
            .Total = 100 + .Impuesto
            .Importe = CDec(TxtMontoVales.Text)
            If .Total < .Importe Then
                If MessageBox.Show("Se generará un saldo a favor ¿está de acuerdo?", "Captura cobros",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = DialogResult.Yes Then
                    .SaldoAFavor = True
                Else
                    MessageBox.Show("Pago tarjeta ¡cancelado!")
                    Exit Sub
                End If
            End If
            .Referencia = "NULL" ' puede ser vacio
            .NumeroCheque = "NULL" ' puede ser vacio
            .FDevolucion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .RazonDevCheque = Nothing
            .Saldo = 10
            .FActualizacion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Folio = 0
            .FDeposito = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .FolioAtt = 0
            .AñoAtt = CShort("0")
            .NumeroCuentaDestino = "NULL"
            .BancoOrigen = CShort("0")
            .StatusSaldoAFavor = "NULL"
            .AñoCobroOrigen = CShort("0")
            .CobroOrigen = 0
        End With
        _listaCobros.Add(insertaCobro)
    End Sub

    Public Sub AltaAnticipo()
        Dim insertaCobro As New SigaMetClasses.CobroDetalladoDatos()

        With insertaCobro
            .TPV = True
            .SaldoAFavor = False
            .AñoCobro = CShort(DateTime.Now.Year)
            .Cobro = 0
            .Cliente = CInt(TxtClienteAplicAntic.Text)
            .FCheque = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .NumeroCuenta = "NULL"
            .Banco = CShort(ComboProveedor.SelectedValue)
            .Observaciones = TextObservacionesAnticipo.Text
            .TipoCobro = 30
            .FAlta = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Status = "EMITIDO"
            .Usuario = GLOBAL_IDUsuario
            .Impuesto = 10
            .Total = Convert.ToDecimal(TxtMontoAnticipo.Text.Trim) + .Impuesto
            .Importe = CDec(TxtMontoAnticipo.Text)
            If .Total < .Importe Then
                If MessageBox.Show("Se generará un saldo a favor ¿está de acuerdo?", "Captura cobros",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
                        = DialogResult.Yes Then
                    .SaldoAFavor = True
                Else
                    MessageBox.Show("Pago tarjeta ¡cancelado!")
                    Exit Sub
                End If
            End If
            .Referencia = "NULL" ' puede ser vacio
            .NumeroCheque = "NULL" ' puede ser vacio
            .FDevolucion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .RazonDevCheque = Nothing
            .Saldo = 0
            .FActualizacion = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .Folio = 0
            .FDeposito = CDate(DateTime.Now.ToString("dd/MM/yyyy"))
            .FolioAtt = 0
            .AñoAtt = CShort("0")
            .NumeroCuentaDestino = "NULL"
            .BancoOrigen = CShort("0")
            .StatusSaldoAFavor = "NULL"
            .AñoCobroOrigen = CShort("0")
            .CobroOrigen = 0
        End With
        _listaCobros.Add(insertaCobro)
    End Sub


    Private Sub btn_AnticipoAceptar_Click(sender As Object, e As EventArgs) Handles btn_AnticipoAceptar.Click

        Dim visibleSelectedRowCount As Boolean = False
        Dim Año As String = ""
        Dim Folio As String = ""
        Dim Saldo As Decimal = 0
        Dim Col As Integer = 0

        Try
            If Me.dgvSaldoAnticipo.Rows.Count > 0 Then
                Col = Me.dgvSaldoAnticipo.CurrentCell.ColumnIndex
            Else
                Throw New Exception("El cliente no tiene anticipos, la operación solicitada no es válida.")
            End If

            For Each fila As DataGridViewRow In Me.dgvSaldoAnticipo.Rows
                If fila.Selected Then
                    Año = Convert.ToString(fila.Cells(0).Value)
                    Folio = Convert.ToString(fila.Cells(1).Value)
                    Saldo = Convert.ToDecimal(fila.Cells(2).Value)
                    visibleSelectedRowCount = True
                End If
            Next

            If visibleSelectedRowCount = True And TxtMontoAnticipo.Text.Trim <> "" Then
                If Saldo >= Convert.ToDecimal(TxtMontoAnticipo.Text) Then

                    AltaAnticipo()
                    Total = CDec(TxtMontoAnticipo.Text)
                    Dim listaDebito As New List(Of DebitoAnticipo)
                    Dim nuevodebitoanticipo As New DebitoAnticipo
                    nuevodebitoanticipo.folio = Folio
                    nuevodebitoanticipo.anio = Año
                    nuevodebitoanticipo.montodebitado = Convert.ToDecimal(TxtMontoAnticipo.Text)
                    listaDebito.Add(nuevodebitoanticipo)
                    _ListaDebitoAnticipos.Add(nuevodebitoanticipo)

                    ActualizarSaldoAnticipo(DirectCast(dgvSaldoAnticipo.DataSource, DataTable), AgruparDebitoAnticipo(_ListaDebitoAnticipos))

                    Remisiones()
                    LimpiarAnticipo()
                    Total = 0
                    DialogResult = DialogResult.OK
                Else
                    MessageBox.Show("El monto a debitar debe ser menor o igual que el saldo del anticipo elegido, verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                If TxtMontoAnticipo.Text.Trim = "" Then
                    TxtMontoAnticipo.Text = "0"
                    MessageBox.Show("Por favor ingrese un monto para el pago", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
                If visibleSelectedRowCount = False Or TxtMontoAnticipo.Text = "" Then
                    MessageBox.Show("Debe seleccionar un anticipo y escribir el monto, verifique.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Function AgruparDebitoAnticipo(Anticipos As List(Of DebitoAnticipo)) As List(Of DebitoAnticipo)
        Dim Agrupados As New List(Of DebitoAnticipo)

        Dim Agrupado As List(Of DebitoAnticipo) = (From anticipo In Anticipos
                                                   Group anticipo By keys = New With {Key anticipo.anio, Key anticipo.folio}
                       Into Group
                                                   Select New DebitoAnticipo With {.anio = keys.anio, .folio = keys.folio,
                                        .montodebitado = Group.Sum(Function(x) x.montodebitado)}).Take(200).ToList()


        Return Agrupado

    End Function

    Private Sub ActualizarSaldoAnticipo(dtAnticipos As DataTable, Agrupados As List(Of DebitoAnticipo))

        If dtAnticipos IsNot Nothing And dtAnticipos.Rows.Count > 0 Then
            For Each agrupado As DebitoAnticipo In Agrupados
                For Each row As DataRow In dtAnticipos.Rows
                    If row("AñoMovimiento").ToString = agrupado.anio.ToString And row("FolioMovimiento").ToString = agrupado.folio.ToString Then
                        row("MontoSaldo") = Convert.ToDecimal(row("MontoSaldo")) - agrupado.montodebitado
                    End If
                Next
            Next
        Else
            Throw New Exception("El cliente no tiene anticipos, la operación solicitada no es válida.")
        End If

    End Sub





    Public Sub LimpiarVales()
        txtClienteVales.Clear()
        LabelNombreVales.Text = ""
        FechaDocumentoVales.Text = ""
        ComboProveedor.SelectedIndex = 0
        ComboTipoVale.SelectedIndex = 0
        TxtMontoVales.Clear()
        TextObservacionesVales.Clear()

    End Sub

    Public Sub LimpiarAnticipo()
        TxtClienteAplicAntic.Clear()
        LabelNombreApAntic.Text = ""
        dgvSaldoAnticipo.DataSource = Nothing
        TxtMontoAnticipo.Clear()
        TextObservacionesAnticipo.Clear()

    End Sub

    Private Sub TxtClienteAplicAntic_TextChanged(sender As Object, e As EventArgs) Handles TxtClienteAplicAntic.TextChanged

    End Sub

    Private Sub TxtClienteAplicAntic_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtClienteAplicAntic.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub BotonBase3_Click(sender As Object, e As EventArgs) Handles BotonBase3.Click
        DialogResult = DialogResult.OK
    End Sub


    Private Sub TxtNumeroDecimal1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtNumeroDecimal1.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtClienteVales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClienteVales.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtMontoVales_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMontoVales.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtClienteTC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClienteTC.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtImporteTC_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporteTC.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtDocumento.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtClienteCheque_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtClienteCheque.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txtImporteDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtImporteDocumento.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtClienteTransferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtClienteTransferencia.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtImporteTransferencia_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtImporteTransferencia.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtMontoAnticipo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMontoAnticipo.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtClienteDacionPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtClienteDacionPago.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TxtMontoDacionPago_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtMontoDacionPago.KeyPress
        '97 - 122 = Ascii MINÚSCULAS
        '65 - 90  = Ascii MAYÚSCULAS
        '48 - 57  = Ascii NÚMEROS

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 46 Or Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub dgvSaldoAnticipo_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvSaldoAnticipo.CellContentClick

        Dim Año, Folio, Saldo As String
        Dim Col As Integer = Me.dgvSaldoAnticipo.CurrentCell.ColumnIndex
        For Each fila As DataGridViewRow In Me.dgvSaldoAnticipo.Rows
            If fila.Selected Then
                Año = Convert.ToString(fila.Cells(0).Value)
                Folio = Convert.ToString(fila.Cells(1).Value)
                Saldo = Convert.ToString(fila.Cells(2).Value)
            End If
        Next
    End Sub
End Class

Public Class DebitoAnticipo
    Public _anio As String
    Public _folio As String
    Public _montodebitado As Decimal

    Property anio() As String
        Get
            Return _anio
        End Get
        Set(ByVal Value As String)
            _anio = Value
        End Set
    End Property

    Property folio() As String
        Get
            Return _folio
        End Get
        Set(ByVal Value As String)
            _folio = Value
        End Set
    End Property

    Property montodebitado() As Decimal
        Get
            Return _montodebitado
        End Get
        Set(ByVal Value As Decimal)
            _montodebitado = Value
        End Set
    End Property


End Class


