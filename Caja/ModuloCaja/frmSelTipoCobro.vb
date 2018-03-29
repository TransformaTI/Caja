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

    Public Sub New(ByVal intConsecutivo As Integer, _
          Optional ByVal CapturaDetalle As Boolean = True)

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
    Friend WithEvents tbEfectivoVales As System.Windows.Forms.TabPage
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmSelTipoCobro))
        Me.tabTipoCobro = New System.Windows.Forms.TabControl()
        Me.tbEfectivoVales = New System.Windows.Forms.TabPage()
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
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.tabTipoCobro.SuspendLayout()
        Me.tbEfectivoVales.SuspendLayout()
        Me.grpEfectivoVales.SuspendLayout()
        Me.tbTarjetaCredito.SuspendLayout()
        Me.grpTarjetaCredito.SuspendLayout()
        Me.tbChequeFicha.SuspendLayout()
        Me.grpChequeFicha.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabTipoCobro
        '
        Me.tabTipoCobro.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabTipoCobro.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbEfectivoVales, Me.tbTarjetaCredito, Me.tbChequeFicha})
        Me.tabTipoCobro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabTipoCobro.HotTrack = True
        Me.tabTipoCobro.Multiline = True
        Me.tabTipoCobro.Name = "tabTipoCobro"
        Me.tabTipoCobro.SelectedIndex = 0
        Me.tabTipoCobro.Size = New System.Drawing.Size(474, 351)
        Me.tabTipoCobro.TabIndex = 0
        '
        'tbEfectivoVales
        '
        Me.tbEfectivoVales.BackColor = System.Drawing.SystemColors.Control
        Me.tbEfectivoVales.Controls.AddRange(New System.Windows.Forms.Control() {Me.grpEfectivoVales, Me.btnAceptarEfectivoVales})
        Me.tbEfectivoVales.ImageIndex = 0
        Me.tbEfectivoVales.Location = New System.Drawing.Point(4, 4)
        Me.tbEfectivoVales.Name = "tbEfectivoVales"
        Me.tbEfectivoVales.Size = New System.Drawing.Size(466, 325)
        Me.tbEfectivoVales.TabIndex = 3
        Me.tbEfectivoVales.Text = "Efectivo y / o vales"
        '
        'grpEfectivoVales
        '
        Me.grpEfectivoVales.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTotalEfectivoVales, Me.lblTotalEfectivoVales})
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
        Me.txtTotalEfectivoVales.Text = ""
        '
        'lblTotalEfectivoVales
        '
        Me.lblTotalEfectivoVales.AutoSize = True
        Me.lblTotalEfectivoVales.Location = New System.Drawing.Point(16, 19)
        Me.lblTotalEfectivoVales.Name = "lblTotalEfectivoVales"
        Me.lblTotalEfectivoVales.Size = New System.Drawing.Size(74, 14)
        Me.lblTotalEfectivoVales.TabIndex = 28
        Me.lblTotalEfectivoVales.Text = "Importe total:"
        '
        'btnAceptarEfectivoVales
        '
        Me.btnAceptarEfectivoVales.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptarEfectivoVales.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptarEfectivoVales.Image = CType(resources.GetObject("btnAceptarEfectivoVales.Image"), System.Drawing.Bitmap)
        Me.btnAceptarEfectivoVales.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarEfectivoVales.Location = New System.Drawing.Point(368, 150)
        Me.btnAceptarEfectivoVales.Name = "btnAceptarEfectivoVales"
        Me.btnAceptarEfectivoVales.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarEfectivoVales.TabIndex = 1
        Me.btnAceptarEfectivoVales.Text = "&Aceptar"
        Me.btnAceptarEfectivoVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbTarjetaCredito
        '
        Me.tbTarjetaCredito.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptarTarjetaCredito, Me.grpTarjetaCredito})
        Me.tbTarjetaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTarjetaCredito.Location = New System.Drawing.Point(4, 4)
        Me.tbTarjetaCredito.Name = "tbTarjetaCredito"
        Me.tbTarjetaCredito.Size = New System.Drawing.Size(466, 325)
        Me.tbTarjetaCredito.TabIndex = 0
        Me.tbTarjetaCredito.Text = "Tarjeta de crédito"
        '
        'btnAceptarTarjetaCredito
        '
        Me.btnAceptarTarjetaCredito.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptarTarjetaCredito.Image = CType(resources.GetObject("btnAceptarTarjetaCredito.Image"), System.Drawing.Bitmap)
        Me.btnAceptarTarjetaCredito.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarTarjetaCredito.Location = New System.Drawing.Point(368, 150)
        Me.btnAceptarTarjetaCredito.Name = "btnAceptarTarjetaCredito"
        Me.btnAceptarTarjetaCredito.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarTarjetaCredito.TabIndex = 3
        Me.btnAceptarTarjetaCredito.Text = "&Aceptar"
        Me.btnAceptarTarjetaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpTarjetaCredito
        '
        Me.grpTarjetaCredito.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtImporteTC, Me.txtClienteTC, Me.lblBanco, Me.LabelBase7, Me.lblClienteNombre, Me.LabelBase6, Me.lblVigencia, Me.LabelBase5, Me.lblTipoTarjetaCredito, Me.LabelBase4, Me.lblBancoNombre, Me.LabelBase3, Me.lblTarjetaCredito, Me.LabelBase2, Me.LabelBase1, Me.Label20, Me.lblTitular, Me.btnBuscarClienteTC})
        Me.grpTarjetaCredito.Location = New System.Drawing.Point(48, 36)
        Me.grpTarjetaCredito.Name = "grpTarjetaCredito"
        Me.grpTarjetaCredito.Size = New System.Drawing.Size(280, 253)
        Me.grpTarjetaCredito.TabIndex = 30
        Me.grpTarjetaCredito.TabStop = False
        Me.grpTarjetaCredito.Text = "Datos de la tarjeta de crédito"
        '
        'txtImporteTC
        '
        Me.txtImporteTC.Location = New System.Drawing.Point(104, 216)
        Me.txtImporteTC.Name = "txtImporteTC"
        Me.txtImporteTC.Size = New System.Drawing.Size(160, 21)
        Me.txtImporteTC.TabIndex = 2
        Me.txtImporteTC.Text = ""
        '
        'txtClienteTC
        '
        Me.txtClienteTC.Location = New System.Drawing.Point(104, 32)
        Me.txtClienteTC.Name = "txtClienteTC"
        Me.txtClienteTC.TabIndex = 0
        Me.txtClienteTC.Text = ""
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
        Me.LabelBase7.Size = New System.Drawing.Size(48, 14)
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
        Me.LabelBase6.Size = New System.Drawing.Size(48, 14)
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
        Me.LabelBase5.Size = New System.Drawing.Size(50, 14)
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
        Me.LabelBase4.Size = New System.Drawing.Size(82, 14)
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
        Me.LabelBase3.Size = New System.Drawing.Size(38, 14)
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
        Me.LabelBase2.Size = New System.Drawing.Size(64, 14)
        Me.LabelBase2.TabIndex = 26
        Me.LabelBase2.Text = "No. Tarjeta:"
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.Location = New System.Drawing.Point(16, 99)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(40, 14)
        Me.LabelBase1.TabIndex = 24
        Me.LabelBase1.Text = "Titular:"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 35)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(42, 14)
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
        Me.btnBuscarClienteTC.Image = CType(resources.GetObject("btnBuscarClienteTC.Image"), System.Drawing.Bitmap)
        Me.btnBuscarClienteTC.Location = New System.Drawing.Point(216, 32)
        Me.btnBuscarClienteTC.Name = "btnBuscarClienteTC"
        Me.btnBuscarClienteTC.Size = New System.Drawing.Size(48, 21)
        Me.btnBuscarClienteTC.TabIndex = 1
        '
        'tbChequeFicha
        '
        Me.tbChequeFicha.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptarChequeFicha, Me.grpChequeFicha})
        Me.tbChequeFicha.Location = New System.Drawing.Point(4, 4)
        Me.tbChequeFicha.Name = "tbChequeFicha"
        Me.tbChequeFicha.Size = New System.Drawing.Size(466, 325)
        Me.tbChequeFicha.TabIndex = 2
        Me.tbChequeFicha.Text = "Cheque / Ficha de deposito"
        '
        'btnAceptarChequeFicha
        '
        Me.btnAceptarChequeFicha.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptarChequeFicha.Image = CType(resources.GetObject("btnAceptarChequeFicha.Image"), System.Drawing.Bitmap)
        Me.btnAceptarChequeFicha.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptarChequeFicha.Location = New System.Drawing.Point(368, 150)
        Me.btnAceptarChequeFicha.Name = "btnAceptarChequeFicha"
        Me.btnAceptarChequeFicha.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptarChequeFicha.TabIndex = 7
        Me.btnAceptarChequeFicha.Text = "&Aceptar"
        Me.btnAceptarChequeFicha.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpChequeFicha
        '
        Me.grpChequeFicha.Controls.AddRange(New System.Windows.Forms.Control() {Me.rbNotaCredito, Me.lblNombre, Me.btnBuscarCliente, Me.txtImporteDocumento, Me.txtClienteCheque, Me.txtNumeroCuenta, Me.txtDocumento, Me.txtObservaciones, Me.ComboBanco, Me.Label21, Me.lblObservaciones, Me.dtpFechaCheque, Me.lblNoCheque, Me.lblFechaCheque, Me.lblNoCuenta, Me.lblImporte, Me.lblCliente, Me.rbCheque, Me.rbFicha})
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
        Me.rbNotaCredito.Text = "&Nota de crédito"
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
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Bitmap)
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
        Me.txtImporteDocumento.Text = ""
        '
        'txtClienteCheque
        '
        Me.txtClienteCheque.Location = New System.Drawing.Point(120, 104)
        Me.txtClienteCheque.Name = "txtClienteCheque"
        Me.txtClienteCheque.Size = New System.Drawing.Size(88, 21)
        Me.txtClienteCheque.TabIndex = 3
        Me.txtClienteCheque.Text = ""
        '
        'txtNumeroCuenta
        '
        Me.txtNumeroCuenta.Location = New System.Drawing.Point(120, 80)
        Me.txtNumeroCuenta.Name = "txtNumeroCuenta"
        Me.txtNumeroCuenta.Size = New System.Drawing.Size(192, 21)
        Me.txtNumeroCuenta.TabIndex = 2
        Me.txtNumeroCuenta.Text = ""
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(120, 32)
        Me.txtDocumento.MaxLength = 7
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.Size = New System.Drawing.Size(192, 21)
        Me.txtDocumento.TabIndex = 0
        Me.txtDocumento.Text = ""
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoSize = False
        Me.txtObservaciones.Location = New System.Drawing.Point(120, 200)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(192, 48)
        Me.txtObservaciones.TabIndex = 6
        Me.txtObservaciones.Text = ""
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
        Me.Label21.Size = New System.Drawing.Size(38, 14)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Banco:"
        '
        'lblObservaciones
        '
        Me.lblObservaciones.AutoSize = True
        Me.lblObservaciones.Location = New System.Drawing.Point(16, 200)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(80, 14)
        Me.lblObservaciones.TabIndex = 21
        Me.lblObservaciones.Text = "Observaciones:"
        '
        'dtpFechaCheque
        '
        Me.dtpFechaCheque.Format = System.Windows.Forms.DateTimePickerFormat.Short
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
        Me.lblNoCheque.Size = New System.Drawing.Size(86, 14)
        Me.lblNoCheque.TabIndex = 11
        Me.lblNoCheque.Text = "No. Documento:"
        '
        'lblFechaCheque
        '
        Me.lblFechaCheque.AutoSize = True
        Me.lblFechaCheque.Location = New System.Drawing.Point(16, 59)
        Me.lblFechaCheque.Name = "lblFechaCheque"
        Me.lblFechaCheque.Size = New System.Drawing.Size(97, 14)
        Me.lblFechaCheque.TabIndex = 16
        Me.lblFechaCheque.Text = "Fecha documento:"
        '
        'lblNoCuenta
        '
        Me.lblNoCuenta.AutoSize = True
        Me.lblNoCuenta.Location = New System.Drawing.Point(16, 83)
        Me.lblNoCuenta.Name = "lblNoCuenta"
        Me.lblNoCuenta.Size = New System.Drawing.Size(64, 14)
        Me.lblNoCuenta.TabIndex = 12
        Me.lblNoCuenta.Text = "No. Cuenta:"
        '
        'lblImporte
        '
        Me.lblImporte.AutoSize = True
        Me.lblImporte.Location = New System.Drawing.Point(16, 179)
        Me.lblImporte.Name = "lblImporte"
        Me.lblImporte.Size = New System.Drawing.Size(48, 14)
        Me.lblImporte.TabIndex = 19
        Me.lblImporte.Text = "Importe:"
        '
        'lblCliente
        '
        Me.lblCliente.AutoSize = True
        Me.lblCliente.Location = New System.Drawing.Point(16, 107)
        Me.lblCliente.Name = "lblCliente"
        Me.lblCliente.Size = New System.Drawing.Size(42, 14)
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
        Me.rbFicha.Text = "&Ficha de depósito"
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
        Me.ClientSize = New System.Drawing.Size(474, 351)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabTipoCobro})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSelTipoCobro"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de cobros"
        Me.tabTipoCobro.ResumeLayout(False)
        Me.tbEfectivoVales.ResumeLayout(False)
        Me.grpEfectivoVales.ResumeLayout(False)
        Me.tbTarjetaCredito.ResumeLayout(False)
        Me.grpTarjetaCredito.ResumeLayout(False)
        Me.tbChequeFicha.ResumeLayout(False)
        Me.grpChequeFicha.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Cobros"

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
            MessageBox.Show("Debe teclear el número de cliente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            lblVigencia.Text = CType(dr("MesVigencia"), String) & " / " & CType(dr("AñoVigencia"), String)
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
                lblTitular.Text = CType(dr("Titular"), String)
                lblTarjetaCredito.Text = CType(dr("TarjetaCredito"), String)
                lblBanco.Text = CType(dr("Banco"), String)
                lblBancoNombre.Text = CType(dr("BancoNombre"), String)
                lblTipoTarjetaCredito.Text = CType(dr("TipoTarjetaCreditoDescripcion"), String)
                lblVigencia.Text = CType(dr("MesVigencia"), String) & " / " & CType(dr("AñoVigencia"), String)
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
        Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
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
            tabTipoCobro.SelectedTab = tbEfectivoVales
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
                    If e.KeyCode = Keys.Left Then tabTipoCobro.SelectedTab = tbEfectivoVales
                Case Is = "tbTarjetaCredito"
                    If e.KeyCode = Keys.Right Then tabTipoCobro.SelectedTab = tbEfectivoVales
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

        Dim lParametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
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
        Dim oCliente As New SigaMetClasses.cCliente()
        oCliente.Consulta(CType(txtClienteCheque.Text, Integer))
        lblNombre.Text = oCliente.Nombre
        oCliente = Nothing
    End Sub

End Class