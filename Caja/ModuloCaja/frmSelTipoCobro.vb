Option Strict On
Option Explicit On 
Imports System.Data.SqlClient

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
    Friend WithEvents TxtNumeroDecimal3 As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents LabelBase9 As ControlesBase.LabelBase
    Friend WithEvents Button1 As Button
    Friend WithEvents TxtNumeroEntero3 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TxtNumeroDecimal4 As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents ComboBanco1 As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents TxtNumeroEntero2 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents TxtNumeroEntero1 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents LabelBase16 As ControlesBase.LabelBase
    Friend WithEvents LabelBase15 As ControlesBase.LabelBase
    Friend WithEvents LabelBase14 As ControlesBase.LabelBase
    Friend WithEvents LabelBase13 As ControlesBase.LabelBase
    Friend WithEvents LabelBase12 As ControlesBase.LabelBase
    Friend WithEvents tbDacionPagos As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents DateTimePicker3 As DateTimePicker
    Friend WithEvents Button2 As Button
    Friend WithEvents TxtNumeroEntero4 As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TxtNumeroDecimal2 As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents DateTimePicker2 As DateTimePicker
    Friend WithEvents LabelBase17 As ControlesBase.LabelBase
    Friend WithEvents LabelBase18 As ControlesBase.LabelBase
    Friend WithEvents LabelBase21 As ControlesBase.LabelBase
    Friend WithEvents LabelBase22 As ControlesBase.LabelBase
    Friend WithEvents LabelBase23 As ControlesBase.LabelBase
    Friend WithEvents TxtNumeroDecimal5 As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents LabelBase24 As ControlesBase.LabelBase
    Friend WithEvents BotonBase1 As ControlesBase.BotonBase
    Friend WithEvents BotonBase2 As ControlesBase.BotonBase
    Friend WithEvents BotonBase3 As ControlesBase.BotonBase
    Private DetalleCobro As SigaMetClasses.sCobro

    Enum FormaPago
        Efectivo = 0
        ValesDespensa = 1
        Tarjeta = 2
        Cheque = 3
        AplicacionAnticipo = 4
        DacionPago = 5
        Transferencia = 6
    End Enum


    Public Sub New(ByVal intConsecutivo As Integer,
          Optional ByVal CapturaDetalle As Boolean = True, Optional ByVal DetalleCobro As Integer = 0)

        MyBase.New()
        InitializeComponent()
        Consecutivo = intConsecutivo

        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
        End If
        If CapturaMixtaEfectivoVales = True Then
            'btnAceptarEfectivo.Enabled = False
            'btnAceptarVale.Enabled = False
        End If
        _CapturaDetalle = CapturaDetalle
    End Sub

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
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
    Friend WithEvents btnAceptarEfectivoVales As ControlesBase.BotonBase
    Friend WithEvents grpEfectivoVales As System.Windows.Forms.GroupBox
    Friend WithEvents lblTotalEfectivoVales As ControlesBase.LabelBase
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
    Friend WithEvents lblTitular As System.Windows.Forms.Label
    Friend WithEvents lblTipoTarjetaCredito As System.Windows.Forms.Label
    Friend WithEvents LabelBase4 As ControlesBase.LabelBase
    Friend WithEvents lblVigencia As System.Windows.Forms.Label
    Friend WithEvents LabelBase5 As ControlesBase.LabelBase
    Friend WithEvents btnBuscarClienteTC As System.Windows.Forms.Button
    Friend WithEvents LabelBase6 As ControlesBase.LabelBase
    Friend WithEvents lblBancoNombre As System.Windows.Forms.Label
    Friend WithEvents LabelBase7 As ControlesBase.LabelBase
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents lblBanco As System.Windows.Forms.Label
    Friend WithEvents ComboBanco As SigaMetClasses.Combos.ComboBanco
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtTotalEfectivoVales As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents txtNumeroCuenta As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteCheque As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtClienteTC As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtImporteTC As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnAceptarChequeFicha As ControlesBase.BotonBase
    Friend WithEvents tbChequeFicha As System.Windows.Forms.TabPage
    Friend WithEvents grpChequeFicha As System.Windows.Forms.GroupBox
    Friend WithEvents rbCheque As System.Windows.Forms.RadioButton
    Friend WithEvents rbFicha As System.Windows.Forms.RadioButton
    Friend WithEvents txtDocumento As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents txtImporteDocumento As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents rbNotaCredito As System.Windows.Forms.RadioButton
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
        Me.grpEfectivoVales = New System.Windows.Forms.GroupBox()
        Me.txtTotalEfectivoVales = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.lblTotalEfectivoVales = New ControlesBase.LabelBase()
        Me.btnAceptarEfectivoVales = New ControlesBase.BotonBase()
        Me.tbTarjetaCredito = New System.Windows.Forms.TabPage()
        Me.btnAceptarTarjetaCredito = New ControlesBase.BotonBase()
        Me.grpTarjetaCredito = New System.Windows.Forms.GroupBox()
        Me.txtImporteTC = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.txtClienteTC = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblBanco = New System.Windows.Forms.Label()
        Me.LabelBase7 = New ControlesBase.LabelBase()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.LabelBase6 = New ControlesBase.LabelBase()
        Me.lblVigencia = New System.Windows.Forms.Label()
        Me.LabelBase5 = New ControlesBase.LabelBase()
        Me.lblTipoTarjetaCredito = New System.Windows.Forms.Label()
        Me.LabelBase4 = New ControlesBase.LabelBase()
        Me.lblBancoNombre = New System.Windows.Forms.Label()
        Me.LabelBase3 = New ControlesBase.LabelBase()
        Me.lblTarjetaCredito = New System.Windows.Forms.Label()
        Me.LabelBase2 = New ControlesBase.LabelBase()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.Label20 = New ControlesBase.LabelBase()
        Me.lblTitular = New System.Windows.Forms.Label()
        Me.btnBuscarClienteTC = New System.Windows.Forms.Button()
        Me.tbChequeFicha = New System.Windows.Forms.TabPage()
        Me.btnAceptarChequeFicha = New ControlesBase.BotonBase()
        Me.grpChequeFicha = New System.Windows.Forms.GroupBox()
        Me.rbNotaCredito = New System.Windows.Forms.RadioButton()
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
        Me.rbCheque = New System.Windows.Forms.RadioButton()
        Me.rbFicha = New System.Windows.Forms.RadioButton()
        Me.tbTransferencias = New System.Windows.Forms.TabPage()
        Me.BotonBase2 = New ControlesBase.BotonBase()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TxtNumeroEntero3 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TxtNumeroDecimal4 = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.ComboBanco1 = New SigaMetClasses.Combos.ComboBanco()
        Me.TxtNumeroEntero2 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.TxtNumeroEntero1 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.LabelBase16 = New ControlesBase.LabelBase()
        Me.LabelBase15 = New ControlesBase.LabelBase()
        Me.LabelBase14 = New ControlesBase.LabelBase()
        Me.LabelBase13 = New ControlesBase.LabelBase()
        Me.LabelBase12 = New ControlesBase.LabelBase()
        Me.LabelBase11 = New ControlesBase.LabelBase()
        Me.LabelBase10 = New ControlesBase.LabelBase()
        Me.TxtNumeroDecimal3 = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.LabelBase9 = New ControlesBase.LabelBase()
        Me.tbAplicAnticipo = New System.Windows.Forms.TabPage()
        Me.tbDacionPagos = New System.Windows.Forms.TabPage()
        Me.BotonBase3 = New ControlesBase.BotonBase()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.DateTimePicker3 = New System.Windows.Forms.DateTimePicker()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TxtNumeroEntero4 = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.TxtNumeroDecimal2 = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.LabelBase17 = New ControlesBase.LabelBase()
        Me.LabelBase18 = New ControlesBase.LabelBase()
        Me.LabelBase21 = New ControlesBase.LabelBase()
        Me.LabelBase22 = New ControlesBase.LabelBase()
        Me.LabelBase23 = New ControlesBase.LabelBase()
        Me.TxtNumeroDecimal5 = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.LabelBase24 = New ControlesBase.LabelBase()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.tabTipoCobro.SuspendLayout()
        Me.tbEfectivo.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.tbValesDespensa.SuspendLayout()
        Me.grpEfectivoVales.SuspendLayout()
        Me.tbTarjetaCredito.SuspendLayout()
        Me.grpTarjetaCredito.SuspendLayout()
        Me.tbChequeFicha.SuspendLayout()
        Me.grpChequeFicha.SuspendLayout()
        Me.tbTransferencias.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
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
        Me.GroupBox1.Text = "Datos del efectivo o vales de despensa"
        '
        'TxtNumeroDecimal1
        '
        Me.TxtNumeroDecimal1.Location = New System.Drawing.Point(136, 16)
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
        Me.tbValesDespensa.Controls.Add(Me.grpEfectivoVales)
        Me.tbValesDespensa.Controls.Add(Me.btnAceptarEfectivoVales)
        Me.tbValesDespensa.ImageIndex = 0
        Me.tbValesDespensa.Location = New System.Drawing.Point(4, 4)
        Me.tbValesDespensa.Name = "tbValesDespensa"
        Me.tbValesDespensa.Size = New System.Drawing.Size(603, 307)
        Me.tbValesDespensa.TabIndex = 3
        Me.tbValesDespensa.Text = "Vales Despensa"
        '
        'grpEfectivoVales
        '
        Me.grpEfectivoVales.Controls.Add(Me.txtTotalEfectivoVales)
        Me.grpEfectivoVales.Controls.Add(Me.lblTotalEfectivoVales)
        Me.grpEfectivoVales.Location = New System.Drawing.Point(48, 138)
        Me.grpEfectivoVales.Name = "grpEfectivoVales"
        Me.grpEfectivoVales.Size = New System.Drawing.Size(272, 48)
        Me.grpEfectivoVales.TabIndex = 32
        Me.grpEfectivoVales.TabStop = False
        Me.grpEfectivoVales.Text = "Datos del efectivo o vales de despensa"
        '
        'txtTotalEfectivoVales
        '
        Me.txtTotalEfectivoVales.Location = New System.Drawing.Point(136, 16)
        Me.txtTotalEfectivoVales.Name = "txtTotalEfectivoVales"
        Me.txtTotalEfectivoVales.Size = New System.Drawing.Size(120, 21)
        Me.txtTotalEfectivoVales.TabIndex = 0
        '
        'lblTotalEfectivoVales
        '
        Me.lblTotalEfectivoVales.AutoSize = True
        Me.lblTotalEfectivoVales.Location = New System.Drawing.Point(16, 19)
        Me.lblTotalEfectivoVales.Name = "lblTotalEfectivoVales"
        Me.lblTotalEfectivoVales.Size = New System.Drawing.Size(74, 13)
        Me.lblTotalEfectivoVales.TabIndex = 28
        Me.lblTotalEfectivoVales.Text = "Importe total:"
        '
        'btnAceptarEfectivoVales
        '
        Me.btnAceptarEfectivoVales.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptarEfectivoVales.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptarEfectivoVales.Image = CType(resources.GetObject("btnAceptarEfectivoVales.Image"), System.Drawing.Image)
        Me.btnAceptarEfectivoVales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarEfectivoVales.Location = New System.Drawing.Point(505, 150)
        Me.btnAceptarEfectivoVales.Name = "btnAceptarEfectivoVales"
        Me.btnAceptarEfectivoVales.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarEfectivoVales.TabIndex = 1
        Me.btnAceptarEfectivoVales.Text = "&Aceptar"
        Me.btnAceptarEfectivoVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptarEfectivoVales.UseVisualStyleBackColor = False
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
        Me.grpTarjetaCredito.Controls.Add(Me.lblVigencia)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase5)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTipoTarjetaCredito)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase4)
        Me.grpTarjetaCredito.Controls.Add(Me.lblBancoNombre)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase3)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTarjetaCredito)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase2)
        Me.grpTarjetaCredito.Controls.Add(Me.LabelBase1)
        Me.grpTarjetaCredito.Controls.Add(Me.Label20)
        Me.grpTarjetaCredito.Controls.Add(Me.lblTitular)
        Me.grpTarjetaCredito.Controls.Add(Me.btnBuscarClienteTC)
        Me.grpTarjetaCredito.Location = New System.Drawing.Point(48, 36)
        Me.grpTarjetaCredito.Name = "grpTarjetaCredito"
        Me.grpTarjetaCredito.Size = New System.Drawing.Size(280, 253)
        Me.grpTarjetaCredito.TabIndex = 30
        Me.grpTarjetaCredito.TabStop = False
        Me.grpTarjetaCredito.Text = "Datos de la tarjeta de cr�dito"
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
        Me.txtClienteTC.Size = New System.Drawing.Size(100, 21)
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
        'lblVigencia
        '
        Me.lblVigencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblVigencia.Location = New System.Drawing.Point(104, 192)
        Me.lblVigencia.Name = "lblVigencia"
        Me.lblVigencia.Size = New System.Drawing.Size(160, 21)
        Me.lblVigencia.TabIndex = 38
        Me.lblVigencia.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        'lblTitular
        '
        Me.lblTitular.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTitular.Location = New System.Drawing.Point(104, 96)
        Me.lblTitular.Name = "lblTitular"
        Me.lblTitular.Size = New System.Drawing.Size(160, 21)
        Me.lblTitular.TabIndex = 31
        Me.lblTitular.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnBuscarClienteTC
        '
        Me.btnBuscarClienteTC.Image = CType(resources.GetObject("btnBuscarClienteTC.Image"), System.Drawing.Image)
        Me.btnBuscarClienteTC.Location = New System.Drawing.Point(216, 32)
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
        Me.grpChequeFicha.Controls.Add(Me.rbNotaCredito)
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
        Me.grpChequeFicha.Controls.Add(Me.rbCheque)
        Me.grpChequeFicha.Controls.Add(Me.rbFicha)
        Me.grpChequeFicha.Location = New System.Drawing.Point(24, 27)
        Me.grpChequeFicha.Name = "grpChequeFicha"
        Me.grpChequeFicha.Size = New System.Drawing.Size(328, 270)
        Me.grpChequeFicha.TabIndex = 28
        Me.grpChequeFicha.TabStop = False
        '
        'rbNotaCredito
        '
        Me.rbNotaCredito.Location = New System.Drawing.Point(208, 0)
        Me.rbNotaCredito.Name = "rbNotaCredito"
        Me.rbNotaCredito.Size = New System.Drawing.Size(104, 16)
        Me.rbNotaCredito.TabIndex = 35
        Me.rbNotaCredito.Text = "&Nota de cr�dito"
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
        Me.btnBuscarCliente.Location = New System.Drawing.Point(264, 104)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(48, 21)
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
        Me.txtClienteCheque.Size = New System.Drawing.Size(88, 21)
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
        'rbCheque
        '
        Me.rbCheque.Checked = True
        Me.rbCheque.Location = New System.Drawing.Point(16, 0)
        Me.rbCheque.Name = "rbCheque"
        Me.rbCheque.Size = New System.Drawing.Size(64, 16)
        Me.rbCheque.TabIndex = 29
        Me.rbCheque.TabStop = True
        Me.rbCheque.Text = "&Cheque"
        '
        'rbFicha
        '
        Me.rbFicha.Location = New System.Drawing.Point(88, 0)
        Me.rbFicha.Name = "rbFicha"
        Me.rbFicha.Size = New System.Drawing.Size(112, 16)
        Me.rbFicha.TabIndex = 30
        Me.rbFicha.Text = "&Ficha de dep�sito"
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
        Me.GroupBox2.Controls.Add(Me.TxtNumeroEntero3)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroDecimal4)
        Me.GroupBox2.Controls.Add(Me.ComboBanco1)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroEntero2)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroEntero1)
        Me.GroupBox2.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox2.Controls.Add(Me.LabelBase16)
        Me.GroupBox2.Controls.Add(Me.LabelBase15)
        Me.GroupBox2.Controls.Add(Me.LabelBase14)
        Me.GroupBox2.Controls.Add(Me.LabelBase13)
        Me.GroupBox2.Controls.Add(Me.LabelBase12)
        Me.GroupBox2.Controls.Add(Me.LabelBase11)
        Me.GroupBox2.Controls.Add(Me.LabelBase10)
        Me.GroupBox2.Controls.Add(Me.TxtNumeroDecimal3)
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
        Me.Button1.Location = New System.Drawing.Point(280, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(48, 21)
        Me.Button1.TabIndex = 44
        '
        'TxtNumeroEntero3
        '
        Me.TxtNumeroEntero3.Location = New System.Drawing.Point(136, 33)
        Me.TxtNumeroEntero3.Name = "TxtNumeroEntero3"
        Me.TxtNumeroEntero3.Size = New System.Drawing.Size(88, 21)
        Me.TxtNumeroEntero3.TabIndex = 43
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(136, 208)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(192, 48)
        Me.TextBox1.TabIndex = 42
        '
        'TxtNumeroDecimal4
        '
        Me.TxtNumeroDecimal4.Location = New System.Drawing.Point(136, 182)
        Me.TxtNumeroDecimal4.Name = "TxtNumeroDecimal4"
        Me.TxtNumeroDecimal4.Size = New System.Drawing.Size(192, 21)
        Me.TxtNumeroDecimal4.TabIndex = 41
        '
        'ComboBanco1
        '
        Me.ComboBanco1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBanco1.DropDownWidth = 200
        Me.ComboBanco1.Location = New System.Drawing.Point(136, 156)
        Me.ComboBanco1.Name = "ComboBanco1"
        Me.ComboBanco1.Size = New System.Drawing.Size(192, 21)
        Me.ComboBanco1.TabIndex = 40
        '
        'TxtNumeroEntero2
        '
        Me.TxtNumeroEntero2.Location = New System.Drawing.Point(136, 130)
        Me.TxtNumeroEntero2.MaxLength = 7
        Me.TxtNumeroEntero2.Name = "TxtNumeroEntero2"
        Me.TxtNumeroEntero2.Size = New System.Drawing.Size(192, 21)
        Me.TxtNumeroEntero2.TabIndex = 39
        '
        'TxtNumeroEntero1
        '
        Me.TxtNumeroEntero1.Location = New System.Drawing.Point(136, 105)
        Me.TxtNumeroEntero1.Name = "TxtNumeroEntero1"
        Me.TxtNumeroEntero1.Size = New System.Drawing.Size(192, 21)
        Me.TxtNumeroEntero1.TabIndex = 38
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(136, 79)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(192, 21)
        Me.DateTimePicker1.TabIndex = 37
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
        Me.LabelBase12.Text = "N�mero de cuenta:"
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
        'TxtNumeroDecimal3
        '
        Me.TxtNumeroDecimal3.Location = New System.Drawing.Point(136, 57)
        Me.TxtNumeroDecimal3.Name = "TxtNumeroDecimal3"
        Me.TxtNumeroDecimal3.Size = New System.Drawing.Size(294, 21)
        Me.TxtNumeroDecimal3.TabIndex = 29
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
        Me.tbAplicAnticipo.Location = New System.Drawing.Point(4, 4)
        Me.tbAplicAnticipo.Name = "tbAplicAnticipo"
        Me.tbAplicAnticipo.Padding = New System.Windows.Forms.Padding(3)
        Me.tbAplicAnticipo.Size = New System.Drawing.Size(603, 307)
        Me.tbAplicAnticipo.TabIndex = 5
        Me.tbAplicAnticipo.Text = "Aplicaci�n Anticipo"
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
        Me.tbDacionPagos.Text = "Daci�n de Pagos"
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
        Me.GroupBox3.Controls.Add(Me.DateTimePicker3)
        Me.GroupBox3.Controls.Add(Me.Button2)
        Me.GroupBox3.Controls.Add(Me.TxtNumeroEntero4)
        Me.GroupBox3.Controls.Add(Me.TextBox2)
        Me.GroupBox3.Controls.Add(Me.TxtNumeroDecimal2)
        Me.GroupBox3.Controls.Add(Me.DateTimePicker2)
        Me.GroupBox3.Controls.Add(Me.LabelBase17)
        Me.GroupBox3.Controls.Add(Me.LabelBase18)
        Me.GroupBox3.Controls.Add(Me.LabelBase21)
        Me.GroupBox3.Controls.Add(Me.LabelBase22)
        Me.GroupBox3.Controls.Add(Me.LabelBase23)
        Me.GroupBox3.Controls.Add(Me.TxtNumeroDecimal5)
        Me.GroupBox3.Controls.Add(Me.LabelBase24)
        Me.GroupBox3.Location = New System.Drawing.Point(60, 24)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(452, 295)
        Me.GroupBox3.TabIndex = 34
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Dacion de Pagos"
        '
        'DateTimePicker3
        '
        Me.DateTimePicker3.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker3.Location = New System.Drawing.Point(160, 106)
        Me.DateTimePicker3.Name = "DateTimePicker3"
        Me.DateTimePicker3.Size = New System.Drawing.Size(192, 21)
        Me.DateTimePicker3.TabIndex = 45
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(304, 33)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(48, 21)
        Me.Button2.TabIndex = 44
        '
        'TxtNumeroEntero4
        '
        Me.TxtNumeroEntero4.Location = New System.Drawing.Point(160, 34)
        Me.TxtNumeroEntero4.Name = "TxtNumeroEntero4"
        Me.TxtNumeroEntero4.Size = New System.Drawing.Size(88, 21)
        Me.TxtNumeroEntero4.TabIndex = 43
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(162, 167)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(192, 48)
        Me.TextBox2.TabIndex = 42
        '
        'TxtNumeroDecimal2
        '
        Me.TxtNumeroDecimal2.Location = New System.Drawing.Point(162, 141)
        Me.TxtNumeroDecimal2.Name = "TxtNumeroDecimal2"
        Me.TxtNumeroDecimal2.Size = New System.Drawing.Size(192, 21)
        Me.TxtNumeroDecimal2.TabIndex = 41
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker2.Location = New System.Drawing.Point(160, 79)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(192, 21)
        Me.DateTimePicker2.TabIndex = 37
        '
        'LabelBase17
        '
        Me.LabelBase17.AutoSize = True
        Me.LabelBase17.Location = New System.Drawing.Point(30, 169)
        Me.LabelBase17.Name = "LabelBase17"
        Me.LabelBase17.Size = New System.Drawing.Size(71, 13)
        Me.LabelBase17.TabIndex = 36
        Me.LabelBase17.Text = "Observaci�n:"
        '
        'LabelBase18
        '
        Me.LabelBase18.AutoSize = True
        Me.LabelBase18.Location = New System.Drawing.Point(30, 147)
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
        Me.LabelBase21.Text = "Fecha de la aplicaci�n:"
        '
        'LabelBase22
        '
        Me.LabelBase22.AutoSize = True
        Me.LabelBase22.Location = New System.Drawing.Point(30, 87)
        Me.LabelBase22.Name = "LabelBase22"
        Me.LabelBase22.Size = New System.Drawing.Size(103, 13)
        Me.LabelBase22.TabIndex = 31
        Me.LabelBase22.Text = "Fecha del convenio:"
        '
        'LabelBase23
        '
        Me.LabelBase23.AutoSize = True
        Me.LabelBase23.Location = New System.Drawing.Point(30, 65)
        Me.LabelBase23.Name = "LabelBase23"
        Me.LabelBase23.Size = New System.Drawing.Size(48, 13)
        Me.LabelBase23.TabIndex = 30
        Me.LabelBase23.Text = "Nombre:"
        '
        'TxtNumeroDecimal5
        '
        Me.TxtNumeroDecimal5.Location = New System.Drawing.Point(160, 57)
        Me.TxtNumeroDecimal5.Name = "TxtNumeroDecimal5"
        Me.TxtNumeroDecimal5.Size = New System.Drawing.Size(286, 21)
        Me.TxtNumeroDecimal5.TabIndex = 29
        '
        'LabelBase24
        '
        Me.LabelBase24.AutoSize = True
        Me.LabelBase24.Location = New System.Drawing.Point(30, 41)
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
        'frmSelTipoCobro
        '
        Me.AcceptButton = Me.btnAceptarEfectivoVales
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
        Me.grpEfectivoVales.ResumeLayout(False)
        Me.grpEfectivoVales.PerformLayout()
        Me.tbTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.PerformLayout()
        Me.tbChequeFicha.ResumeLayout(False)
        Me.grpChequeFicha.ResumeLayout(False)
        Me.grpChequeFicha.PerformLayout()
        Me.tbTransferencias.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Private Sub btnAceptarEfectivoVales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarEfectivoVales.Click
        If CapturaEfectivoVales = False Then
            If txtTotalEfectivoVales.Text <> "" And IsNumeric(txtTotalEfectivoVales.Text) Then
                If _CapturaDetalle = True Then
                    Dim frmCaptura As New frmCapCobranzaDoc()
                    frmCaptura.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                    frmCaptura.ImporteCobro = CType(txtTotalEfectivoVales.Text, Decimal)

                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        With Cobro
                            .Consecutivo = Consecutivo
                            .AnoCobro = CType(Year(Today), Short)
                            .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                            .Total = CType(txtTotalEfectivoVales.Text, Decimal)
                            .ListaPedidos = frmCaptura.ListaCobroPedido
                            ImporteTotalCobro = .Total
                        End With
                    End If
                Else
                    With Cobro
                        .Consecutivo = Consecutivo
                        .AnoCobro = CType(Year(Today), Short)
                        .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales
                        .Total = CType(txtTotalEfectivoVales.Text, Decimal)
                        .ListaPedidos = Nothing
                        ImporteTotalCobro = .Total
                    End With
                End If
                DialogResult = DialogResult.OK

            End If
        Else
            MessageBox.Show("Ya captur� efectivo o vales")
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

                    If frmCaptura.ShowDialog = DialogResult.OK Then
                        With Cobro
                            .Consecutivo = Consecutivo
                            .AnoCobro = CType(Year(Today), Short)
                            .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                            .Total = CType(txtImporteTC.Text, Decimal)
                            .Cliente = CType(txtClienteTC.Text, Integer)
                            .Banco = CType(lblBanco.Text, Short)
                            .NoCuenta = lblTarjetaCredito.Text
                            .ListaPedidos = frmCaptura.ListaCobroPedido
                            ImporteTotalCobro = .Total
                        End With
                    End If
                Else
                    With Cobro
                        .Consecutivo = Consecutivo
                        .AnoCobro = CType(Year(Today), Short)
                        .TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                        .Total = CType(txtImporteTC.Text, Decimal)
                        .Cliente = CType(txtClienteTC.Text, Integer)
                        .Banco = CType(lblBanco.Text, Short)
                        .NoCuenta = lblTarjetaCredito.Text
                        .ListaPedidos = Nothing
                        ImporteTotalCobro = .Total
                    End With
                End If
                DialogResult = DialogResult.OK
            Else
                MessageBox.Show("Debe teclear el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("Debe teclear el n�mero de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub



    'CHEQUE Y FICHA DE DEPOSITO
    Private Sub btnAceptarChequeFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptarChequeFicha.Click
        If ValidaCapturaChequeFicha() Then
            If _CapturaDetalle = True Then
                Dim frmCaptura As New frmCapCobranzaDoc()
                frmCaptura.TipoCobro = _TipoCobro
                frmCaptura.ImporteCobro = CType(txtImporteDocumento.Text, Decimal)
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    With Cobro
                        .Consecutivo = Consecutivo
                        .AnoCobro = CType(Year(Today), Short)
                        .TipoCobro = _TipoCobro
                        .Total = CType(txtImporteDocumento.Text, Decimal)
                        .NoCheque = Trim(txtDocumento.Text)
                        .FechaCheque = CType(dtpFechaCheque.Value.ToShortDateString, Date)
                        .NoCuenta = Trim(txtNumeroCuenta.Text)
                        .Cliente = CType(txtClienteCheque.Text, Integer)
                        .Banco = CType(ComboBanco.SelectedValue, Short)
                        .Observaciones = Trim(txtObservaciones.Text)
                        .ListaPedidos = frmCaptura.ListaCobroPedido
                        ImporteTotalCobro = .Total
                    End With
                End If
            Else
                With Cobro
                    .Consecutivo = Consecutivo
                    .AnoCobro = CType(Year(Today), Short)
                    .TipoCobro = _TipoCobro
                    .Total = CType(txtImporteDocumento.Text, Decimal)
                    .NoCheque = Trim(txtDocumento.Text)
                    .FechaCheque = CType(dtpFechaCheque.Value.ToShortDateString, Date)
                    .NoCuenta = Trim(txtNumeroCuenta.Text)
                    .Cliente = CType(txtClienteCheque.Text, Integer)
                    .Banco = CType(ComboBanco.SelectedValue, Short)
                    .Observaciones = Trim(txtObservaciones.Text)
                    .ListaPedidos = Nothing
                    ImporteTotalCobro = .Total
                End With
            End If
            DialogResult = DialogResult.OK
        End If
    End Sub

#End Region



    Private Function ValidaCapturaChequeFicha() As Boolean
        'Con esta funci�n valido que se est�n capturando todos los datos necesarios
        'del cheque � de la ficha de dep�sito.
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
                            MessageBox.Show("Debe teclear el n�mero de un cliente v�lido.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Return False
                        End If
                    Else
                        MessageBox.Show("Debe teclear el n�mero de cuenta.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        Return False
                    End If
                Else
                    MessageBox.Show("El n�mero de cheque debe ser de 7 d�gitos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    txtDocumento.Focus()
                    txtDocumento.SelectAll()
                    Return False
                End If
            Else
                MessageBox.Show("Debe teclear el n�mero del cheque.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
                AcceptButton = btnAceptarEfectivoVales
                txtTotalEfectivoVales.Focus()
            Case Is = "tbChequeFicha"
                AcceptButton = btnAceptarChequeFicha
                txtDocumento.Focus()
            Case Is = "tbTarjetaCredito"
                AcceptButton = btnAceptarTarjetaCredito
                txtClienteTC.Focus()
        End Select
    End Sub

    Private Sub frmSelTipoCobro_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ComboBanco.CargaDatos(True)

        If CapturaEfectivoVales = True Then
            btnAceptarEfectivoVales.Enabled = False
            tabTipoCobro.SelectedTab = tbChequeFicha
        End If
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
        lblTitular.Text = ""
        lblTarjetaCredito.Text = ""
        lblBancoNombre.Text = ""
        lblTipoTarjetaCredito.Text = ""
        lblVigencia.Text = ""
    End Sub

    Private Sub ConsultaTarjetaCredito(ByVal Cliente As Integer)
        Dim oTC As New SigaMetClasses.cTarjetaCredito()
        Dim dr As SqlDataReader
        dr = oTC.ConsultaActiva(Cliente)
        Do While dr.Read
            lblClienteNombre.Text = CType(dr("ClienteNombre"), String)
            lblTitular.Text = CType(dr("Titular"), String)
            lblTarjetaCredito.Text = CType(dr("TarjetaCredito"), String)
            lblBanco.Text = CType(dr("Banco"), String)
            lblBancoNombre.Text = CType(dr("BancoNombre"), String)
            lblTipoTarjetaCredito.Text = CType(dr("TipoTarjetaCreditoDescripcion"), String)
            lblVigencia.Text = CType(dr("MesVigencia"), String) & " / " & CType(dr("A�oVigencia"), String)
        Loop
        dr.Close()
    End Sub

    Private Sub btnBuscarClienteTC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarClienteTC.Click
        If txtClienteTC.Text <> "" And IsNumeric(txtClienteTC.Text) Then
            LimpiaInfoTarjetaCredito()
            ConsultaTarjetaCredito(CType(txtClienteTC.Text, Integer))
            If lblTarjetaCredito.Text = "" Then
                MessageBox.Show("No existen tarjetas de cr�dito del cliente especificado.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub rbCheque_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbCheque.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque
    End Sub

    Private Sub rbFicha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFicha.CheckedChanged
        _TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.FichaDeposito
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        If Trim(txtClienteCheque.Text) <> "" Then
            Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(CType(txtClienteCheque.Text, Integer))
            frmConCliente.ShowDialog()
        End If
    End Sub

    Private Sub txtClienteCheque_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClienteCheque.Leave
        Dim oCliente As New SigaMetClasses.cCliente()
        oCliente.Consulta(CType(txtClienteCheque.Text, Integer))
        lblNombre.Text = oCliente.Nombre
        oCliente = Nothing
    End Sub


End Class