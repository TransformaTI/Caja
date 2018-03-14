Imports System.Data.SqlClient
Public Class frmCorteCajaAlta
    Inherits System.Windows.Forms.Form
    Private _Caja As Byte
    Private _FOperacion As Date
    Private _Consecutivo As Byte
    Private TotalAplicacion As Decimal
    Private Titulo As String = "Corte de caja"

    Public Sub New(ByVal Caja As Byte, _
                   ByVal FOperacion As Date, _
                   ByVal Consecutivo As Byte)
        MyBase.New()
        InitializeComponent()

        _Caja = Caja
        _FOperacion = FOperacion
        _Consecutivo = Consecutivo

        lblFOperacion.Text = FOperacion.ToLongDateString
        lblCaja.Text = Caja.ToString
        grdCorteCaja.CaptionText = "Corte de caja del día " & FOperacion.ToLongDateString & ", Caja: " & Caja.ToString
        CargaDatosIngreso(_Caja, _FOperacion)

        Me.Text = "Alta de corte de caja"
    End Sub

    Public Sub New(ByVal Caja As Byte, _
                   ByVal FOperacion As Date, _
                   ByVal Consecutivo As Byte, _
                   ByVal ListaAplicaciones As ArrayList)
        'Modificación
        MyBase.New()
        InitializeComponent()

        _Caja = Caja
        _FOperacion = FOperacion
        _Consecutivo = Consecutivo

        lblFOperacion.Text = FOperacion.ToLongDateString
        lblCaja.Text = Caja.ToString
        grdCorteCaja.CaptionText = "Corte de caja del día " & FOperacion.ToLongDateString & ", Caja: " & Caja.ToString
        lstAplicacion.ValueMember = "TipoAplicacionIngreso"
        lstAplicacion.DisplayMember = "InformacionCompleta"

        CargaDatosAplicaciones(ListaAplicaciones)
        CargaDatosIngreso(_Caja, _FOperacion)

        pnlAplicaciones.BackColor = Color.LightCoral

        Me.Text = "Modificación de corte de caja"
        lblWarning.Visible = True
        picWarning.Visible = True

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
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents lblFOperacion As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdCorteCaja As System.Windows.Forms.DataGrid
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colVentasContado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colVentasCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colChequesDev As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNotaIngreso As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotalCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblDiferencia As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ttMensaje As System.Windows.Forms.ToolTip
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblTotalAplicacion As System.Windows.Forms.Label
    Friend WithEvents lstAplicacion As System.Windows.Forms.ListBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents lblEgVentaCredito As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents pnlAplicaciones As System.Windows.Forms.Panel
    Friend WithEvents lblWarning As System.Windows.Forms.Label
    Friend WithEvents picWarning As System.Windows.Forms.PictureBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblTotalIngreso As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblInNotaIngreso As System.Windows.Forms.Label
    Friend WithEvents lblInChequesDevueltos As System.Windows.Forms.Label
    Friend WithEvents lblInCobranza As System.Windows.Forms.Label
    Friend WithEvents lblInVentaCredito As System.Windows.Forms.Label
    Friend WithEvents lblInVentaContado As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents tabIngresos As System.Windows.Forms.TabControl
    Friend WithEvents tpIngresos1 As System.Windows.Forms.TabPage
    Friend WithEvents tpIngresos2 As System.Windows.Forms.TabPage
    Friend WithEvents lblc7TotalIngresos As System.Windows.Forms.Label
    Friend WithEvents lblc7ChequesDevueltos As System.Windows.Forms.Label
    Friend WithEvents lblc7VentaCredito As System.Windows.Forms.Label
    Friend WithEvents lblc7VentaContado As System.Windows.Forms.Label
    Friend WithEvents lblc7NotasIngreso As System.Windows.Forms.Label
    Friend WithEvents lblc7Cobranza As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCorteCajaAlta))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.lblFOperacion = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdCorteCaja = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colVentasContado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colVentasCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colChequesDev = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNotaIngreso = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotalCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.lblDiferencia = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ttMensaje = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.pnlAplicaciones = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTotalAplicacion = New System.Windows.Forms.Label()
        Me.lstAplicacion = New System.Windows.Forms.ListBox()
        Me.lblEgVentaCredito = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblWarning = New System.Windows.Forms.Label()
        Me.picWarning = New System.Windows.Forms.PictureBox()
        Me.tabIngresos = New System.Windows.Forms.TabControl()
        Me.tpIngresos1 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalIngreso = New System.Windows.Forms.Label()
        Me.lblInChequesDevueltos = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblInVentaCredito = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.lblInVentaContado = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblInNotaIngreso = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblInCobranza = New System.Windows.Forms.Label()
        Me.tpIngresos2 = New System.Windows.Forms.TabPage()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.lblc7TotalIngresos = New System.Windows.Forms.Label()
        Me.lblc7ChequesDevueltos = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblc7VentaCredito = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.lblc7VentaContado = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.lblc7NotasIngreso = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.lblc7Cobranza = New System.Windows.Forms.Label()
        CType(Me.grdCorteCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAplicaciones.SuspendLayout()
        Me.tabIngresos.SuspendLayout()
        Me.tpIngresos1.SuspendLayout()
        Me.tpIngresos2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(560, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(560, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFOperacion
        '
        Me.lblFOperacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFOperacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFOperacion.Location = New System.Drawing.Point(96, 16)
        Me.lblFOperacion.Name = "lblFOperacion"
        Me.lblFOperacion.Size = New System.Drawing.Size(296, 21)
        Me.lblFOperacion.TabIndex = 5
        Me.lblFOperacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 14)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "F.Operación:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaja
        '
        Me.lblCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.Location = New System.Drawing.Point(96, 40)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(72, 21)
        Me.lblCaja.TabIndex = 7
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 43)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 14)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Caja:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'grdCorteCaja
        '
        Me.grdCorteCaja.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.grdCorteCaja.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
        Me.grdCorteCaja.DataMember = ""
        Me.grdCorteCaja.ForeColor = System.Drawing.Color.Crimson
        Me.grdCorteCaja.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCorteCaja.Location = New System.Drawing.Point(6, 88)
        Me.grdCorteCaja.Name = "grdCorteCaja"
        Me.grdCorteCaja.ReadOnly = True
        Me.grdCorteCaja.Size = New System.Drawing.Size(634, 160)
        Me.grdCorteCaja.TabIndex = 11
        Me.grdCorteCaja.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.AlternatingBackColor = System.Drawing.Color.LemonChiffon
        Me.Estilo1.DataGrid = Me.grdCorteCaja
        Me.Estilo1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCelula, Me.colDescripcion, Me.colVentasContado, Me.colVentasCredito, Me.colCobranza, Me.colChequesDev, Me.colNotaIngreso, Me.colTotalCelula})
        Me.Estilo1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None
        Me.Estilo1.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "CorteCaja"
        Me.Estilo1.ReadOnly = True
        Me.Estilo1.RowHeadersVisible = False
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "Celula"
        Me.colCelula.Width = 50
        '
        'colDescripcion
        '
        Me.colDescripcion.Format = ""
        Me.colDescripcion.FormatInfo = Nothing
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.MappingName = "Descripcion"
        Me.colDescripcion.Width = 75
        '
        'colVentasContado
        '
        Me.colVentasContado.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colVentasContado.Format = "#,##.00"
        Me.colVentasContado.FormatInfo = Nothing
        Me.colVentasContado.HeaderText = "V. Contado"
        Me.colVentasContado.MappingName = "VentasContado"
        Me.colVentasContado.Width = 90
        '
        'colVentasCredito
        '
        Me.colVentasCredito.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colVentasCredito.Format = "#,##.00"
        Me.colVentasCredito.FormatInfo = Nothing
        Me.colVentasCredito.HeaderText = "V. Crédito"
        Me.colVentasCredito.MappingName = "VentasCredito"
        Me.colVentasCredito.Width = 90
        '
        'colCobranza
        '
        Me.colCobranza.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCobranza.Format = "#,##.00"
        Me.colCobranza.FormatInfo = Nothing
        Me.colCobranza.HeaderText = "Cobranza"
        Me.colCobranza.MappingName = "Cobranza"
        Me.colCobranza.Width = 90
        '
        'colChequesDev
        '
        Me.colChequesDev.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colChequesDev.Format = "#,##.00"
        Me.colChequesDev.FormatInfo = Nothing
        Me.colChequesDev.HeaderText = "Cheques dev."
        Me.colChequesDev.MappingName = "ChequesDev"
        Me.colChequesDev.Width = 90
        '
        'colNotaIngreso
        '
        Me.colNotaIngreso.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colNotaIngreso.Format = "#,##.00"
        Me.colNotaIngreso.FormatInfo = Nothing
        Me.colNotaIngreso.HeaderText = "N. Ingreso"
        Me.colNotaIngreso.MappingName = "NotaIngreso"
        Me.colNotaIngreso.Width = 90
        '
        'colTotalCelula
        '
        Me.colTotalCelula.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotalCelula.Format = "#,##.00"
        Me.colTotalCelula.FormatInfo = Nothing
        Me.colTotalCelula.MappingName = "TotalCelula"
        Me.colTotalCelula.Width = 0
        '
        'lblDiferencia
        '
        Me.lblDiferencia.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblDiferencia.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferencia.ForeColor = System.Drawing.Color.Crimson
        Me.lblDiferencia.Location = New System.Drawing.Point(520, 480)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(120, 21)
        Me.lblDiferencia.TabIndex = 37
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(448, 483)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(58, 14)
        Me.Label15.TabIndex = 38
        Me.Label15.Text = "Diferencia:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Bitmap)
        Me.btnEliminar.Location = New System.Drawing.Point(248, 39)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(24, 23)
        Me.btnEliminar.TabIndex = 48
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnEliminar, "Elimina la aplicación seleccionada")
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Bitmap)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(277, 39)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.TabIndex = 42
        Me.btnAgregar.Text = "&Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ttMensaje.SetToolTip(Me.btnAgregar, "Agregar una aplicación al corte de caja")
        '
        'pnlAplicaciones
        '
        Me.pnlAplicaciones.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.pnlAplicaciones.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnEliminar, Me.Label8, Me.Label6, Me.lblTotalAplicacion, Me.lstAplicacion, Me.btnAgregar, Me.lblEgVentaCredito, Me.Label4})
        Me.pnlAplicaciones.Location = New System.Drawing.Point(288, 256)
        Me.pnlAplicaciones.Name = "pnlAplicaciones"
        Me.pnlAplicaciones.Size = New System.Drawing.Size(352, 216)
        Me.pnlAplicaciones.TabIndex = 39
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(96, 179)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(127, 14)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Total de aplicaciones:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 43)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 14)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Venta a crédito:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalAplicacion
        '
        Me.lblTotalAplicacion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalAplicacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalAplicacion.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotalAplicacion.Location = New System.Drawing.Point(232, 176)
        Me.lblTotalAplicacion.Name = "lblTotalAplicacion"
        Me.lblTotalAplicacion.Size = New System.Drawing.Size(120, 21)
        Me.lblTotalAplicacion.TabIndex = 44
        Me.lblTotalAplicacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lstAplicacion
        '
        Me.lstAplicacion.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAplicacion.ItemHeight = 14
        Me.lstAplicacion.Location = New System.Drawing.Point(16, 72)
        Me.lstAplicacion.Name = "lstAplicacion"
        Me.lstAplicacion.Size = New System.Drawing.Size(336, 88)
        Me.lstAplicacion.TabIndex = 43
        '
        'lblEgVentaCredito
        '
        Me.lblEgVentaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEgVentaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEgVentaCredito.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblEgVentaCredito.Location = New System.Drawing.Point(112, 40)
        Me.lblEgVentaCredito.Name = "lblEgVentaCredito"
        Me.lblEgVentaCredito.Size = New System.Drawing.Size(120, 21)
        Me.lblEgVentaCredito.TabIndex = 40
        Me.lblEgVentaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 11.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(360, 21)
        Me.Label4.TabIndex = 35
        Me.Label4.Text = "Aplicaciones"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWarning
        '
        Me.lblWarning.BackColor = System.Drawing.Color.LemonChiffon
        Me.lblWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblWarning.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWarning.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblWarning.Location = New System.Drawing.Point(8, 64)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(384, 21)
        Me.lblWarning.TabIndex = 40
        Me.lblWarning.Text = "          Se está modificando un corte de caja ya cerrado."
        Me.lblWarning.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblWarning.Visible = False
        '
        'picWarning
        '
        Me.picWarning.BackColor = System.Drawing.Color.LemonChiffon
        Me.picWarning.Image = CType(resources.GetObject("picWarning.Image"), System.Drawing.Bitmap)
        Me.picWarning.Location = New System.Drawing.Point(16, 66)
        Me.picWarning.Name = "picWarning"
        Me.picWarning.Size = New System.Drawing.Size(16, 16)
        Me.picWarning.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picWarning.TabIndex = 41
        Me.picWarning.TabStop = False
        Me.picWarning.Visible = False
        '
        'tabIngresos
        '
        Me.tabIngresos.Alignment = System.Windows.Forms.TabAlignment.Bottom
        Me.tabIngresos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tpIngresos1, Me.tpIngresos2})
        Me.tabIngresos.Location = New System.Drawing.Point(0, 252)
        Me.tabIngresos.Name = "tabIngresos"
        Me.tabIngresos.SelectedIndex = 0
        Me.tabIngresos.Size = New System.Drawing.Size(288, 224)
        Me.tabIngresos.TabIndex = 42
        '
        'tpIngresos1
        '
        Me.tpIngresos1.BackColor = System.Drawing.Color.Khaki
        Me.tpIngresos1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label5, Me.lblTotalIngreso, Me.lblInChequesDevueltos, Me.Label13, Me.lblInVentaCredito, Me.Label11, Me.Label12, Me.lblInVentaContado, Me.Label10, Me.Label9, Me.lblInNotaIngreso, Me.Label3, Me.lblInCobranza})
        Me.tpIngresos1.Location = New System.Drawing.Point(4, 4)
        Me.tpIngresos1.Name = "tpIngresos1"
        Me.tpIngresos1.Size = New System.Drawing.Size(280, 198)
        Me.tpIngresos1.TabIndex = 0
        Me.tpIngresos1.Text = "Células comerciales"
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 11.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(280, 21)
        Me.Label5.TabIndex = 34
        Me.Label5.Text = "Ingresos Células comerciales"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalIngreso
        '
        Me.lblTotalIngreso.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblTotalIngreso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalIngreso.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblTotalIngreso.Location = New System.Drawing.Point(152, 168)
        Me.lblTotalIngreso.Name = "lblTotalIngreso"
        Me.lblTotalIngreso.Size = New System.Drawing.Size(120, 21)
        Me.lblTotalIngreso.TabIndex = 32
        Me.lblTotalIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblInChequesDevueltos
        '
        Me.lblInChequesDevueltos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInChequesDevueltos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInChequesDevueltos.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblInChequesDevueltos.Location = New System.Drawing.Point(152, 104)
        Me.lblInChequesDevueltos.Name = "lblInChequesDevueltos"
        Me.lblInChequesDevueltos.Size = New System.Drawing.Size(120, 21)
        Me.lblInChequesDevueltos.TabIndex = 25
        Me.lblInChequesDevueltos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 131)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(92, 14)
        Me.Label13.TabIndex = 31
        Me.Label13.Text = "Notas de ingreso:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInVentaCredito
        '
        Me.lblInVentaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInVentaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInVentaCredito.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblInVentaCredito.Location = New System.Drawing.Point(152, 56)
        Me.lblInVentaCredito.Name = "lblInVentaCredito"
        Me.lblInVentaCredito.Size = New System.Drawing.Size(120, 21)
        Me.lblInVentaCredito.TabIndex = 23
        Me.lblInVentaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 83)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 14)
        Me.Label11.TabIndex = 29
        Me.Label11.Text = "Cobranza:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 14)
        Me.Label12.TabIndex = 30
        Me.Label12.Text = "Cheques devueltos:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInVentaContado
        '
        Me.lblInVentaContado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInVentaContado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInVentaContado.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblInVentaContado.Location = New System.Drawing.Point(152, 32)
        Me.lblInVentaContado.Name = "lblInVentaContado"
        Me.lblInVentaContado.Size = New System.Drawing.Size(120, 21)
        Me.lblInVentaContado.TabIndex = 22
        Me.lblInVentaContado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(84, 14)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Venta a crédito:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(90, 14)
        Me.Label9.TabIndex = 27
        Me.Label9.Text = "Venta a contado:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInNotaIngreso
        '
        Me.lblInNotaIngreso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInNotaIngreso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInNotaIngreso.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblInNotaIngreso.Location = New System.Drawing.Point(152, 128)
        Me.lblInNotaIngreso.Name = "lblInNotaIngreso"
        Me.lblInNotaIngreso.Size = New System.Drawing.Size(120, 21)
        Me.lblInNotaIngreso.TabIndex = 26
        Me.lblInNotaIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 171)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 14)
        Me.Label3.TabIndex = 33
        Me.Label3.Text = "Total de ingresos:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblInCobranza
        '
        Me.lblInCobranza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblInCobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInCobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblInCobranza.Location = New System.Drawing.Point(152, 80)
        Me.lblInCobranza.Name = "lblInCobranza"
        Me.lblInCobranza.Size = New System.Drawing.Size(120, 21)
        Me.lblInCobranza.TabIndex = 24
        Me.lblInCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpIngresos2
        '
        Me.tpIngresos2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.tpIngresos2.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label26, Me.lblc7TotalIngresos, Me.lblc7ChequesDevueltos, Me.Label16, Me.lblc7VentaCredito, Me.Label18, Me.Label19, Me.lblc7VentaContado, Me.Label21, Me.Label22, Me.lblc7NotasIngreso, Me.Label24, Me.lblc7Cobranza})
        Me.tpIngresos2.Location = New System.Drawing.Point(4, 4)
        Me.tpIngresos2.Name = "tpIngresos2"
        Me.tpIngresos2.Size = New System.Drawing.Size(280, 198)
        Me.tpIngresos2.TabIndex = 1
        Me.tpIngresos2.Text = "Célula 7"
        '
        'Label26
        '
        Me.Label26.BackColor = System.Drawing.Color.Silver
        Me.Label26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label26.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label26.Font = New System.Drawing.Font("Tahoma", 11.25!, (System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(280, 21)
        Me.Label26.TabIndex = 46
        Me.Label26.Text = "Ingresos C-7"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblc7TotalIngresos
        '
        Me.lblc7TotalIngresos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblc7TotalIngresos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc7TotalIngresos.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblc7TotalIngresos.Location = New System.Drawing.Point(152, 168)
        Me.lblc7TotalIngresos.Name = "lblc7TotalIngresos"
        Me.lblc7TotalIngresos.Size = New System.Drawing.Size(120, 21)
        Me.lblc7TotalIngresos.TabIndex = 44
        Me.lblc7TotalIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblc7ChequesDevueltos
        '
        Me.lblc7ChequesDevueltos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblc7ChequesDevueltos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc7ChequesDevueltos.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblc7ChequesDevueltos.Location = New System.Drawing.Point(152, 104)
        Me.lblc7ChequesDevueltos.Name = "lblc7ChequesDevueltos"
        Me.lblc7ChequesDevueltos.Size = New System.Drawing.Size(120, 21)
        Me.lblc7ChequesDevueltos.TabIndex = 37
        Me.lblc7ChequesDevueltos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(16, 131)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(92, 14)
        Me.Label16.TabIndex = 43
        Me.Label16.Text = "Notas de ingreso:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblc7VentaCredito
        '
        Me.lblc7VentaCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblc7VentaCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc7VentaCredito.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblc7VentaCredito.Location = New System.Drawing.Point(152, 56)
        Me.lblc7VentaCredito.Name = "lblc7VentaCredito"
        Me.lblc7VentaCredito.Size = New System.Drawing.Size(120, 21)
        Me.lblc7VentaCredito.TabIndex = 35
        Me.lblc7VentaCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(16, 83)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(55, 14)
        Me.Label18.TabIndex = 41
        Me.Label18.Text = "Cobranza:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(16, 107)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(102, 14)
        Me.Label19.TabIndex = 42
        Me.Label19.Text = "Cheques devueltos:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblc7VentaContado
        '
        Me.lblc7VentaContado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblc7VentaContado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc7VentaContado.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblc7VentaContado.Location = New System.Drawing.Point(152, 32)
        Me.lblc7VentaContado.Name = "lblc7VentaContado"
        Me.lblc7VentaContado.Size = New System.Drawing.Size(120, 21)
        Me.lblc7VentaContado.TabIndex = 34
        Me.lblc7VentaContado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 59)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(84, 14)
        Me.Label21.TabIndex = 40
        Me.Label21.Text = "Venta a crédito:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(16, 35)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(90, 14)
        Me.Label22.TabIndex = 39
        Me.Label22.Text = "Venta a contado:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblc7NotasIngreso
        '
        Me.lblc7NotasIngreso.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblc7NotasIngreso.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc7NotasIngreso.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblc7NotasIngreso.Location = New System.Drawing.Point(152, 128)
        Me.lblc7NotasIngreso.Name = "lblc7NotasIngreso"
        Me.lblc7NotasIngreso.Size = New System.Drawing.Size(120, 21)
        Me.lblc7NotasIngreso.TabIndex = 38
        Me.lblc7NotasIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(8, 171)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(106, 14)
        Me.Label24.TabIndex = 45
        Me.Label24.Text = "Total de ingresos:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblc7Cobranza
        '
        Me.lblc7Cobranza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblc7Cobranza.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblc7Cobranza.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblc7Cobranza.Location = New System.Drawing.Point(152, 80)
        Me.lblc7Cobranza.Name = "lblc7Cobranza"
        Me.lblc7Cobranza.Size = New System.Drawing.Size(120, 21)
        Me.lblc7Cobranza.TabIndex = 36
        Me.lblc7Cobranza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCorteCajaAlta
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(650, 511)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabIngresos, Me.picWarning, Me.lblWarning, Me.pnlAplicaciones, Me.Label15, Me.Label2, Me.Label1, Me.lblDiferencia, Me.grdCorteCaja, Me.lblCaja, Me.lblFOperacion, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCorteCajaAlta"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Corte de caja"
        CType(Me.grdCorteCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAplicaciones.ResumeLayout(False)
        Me.tabIngresos.ResumeLayout(False)
        Me.tpIngresos1.ResumeLayout(False)
        Me.tpIngresos2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargaDatosAplicaciones(ByVal Lista As ArrayList)
        Dim oAplicacion As SigaMetClasses.sTipoAplicacionIngreso
        For Each oAplicacion In Lista
            If oAplicacion.TipoAplicacionIngreso <> 12 And oAplicacion.TipoAplicacionIngreso <> 11 Then
                TotalAplicacion += oAplicacion.Importe
                lstAplicacion.Items.Add(oAplicacion)
            End If
        Next
    End Sub

    Private Sub CargaDatosIngreso(ByVal Caja As Byte, ByVal FOperacion As Date)
        Cursor = Cursors.WaitCursor
        Dim cmd As New SqlCommand("spReporteCorteCajaIngresos")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Caja", SqlDbType.TinyInt).Value = Caja
            .Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacion
        End With
        Dim da As New SqlDataAdapter(cmd)
        Dim dt As New DataTable("CorteCaja")
        'Dim cn As New SqlConnection(Main.ConString)
        Dim cn As SqlConnection = GLOBAL_Connection

        Try
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            da.Fill(dt)
            If dt.Rows.Count > 0 Then
                grdCorteCaja.DataSource = dt

                '07 de junio del 2004

                lblEgVentaCredito.Text = SigaMetClasses.SumaColumna(dt, "VentasCredito").ToString("N")

                Dim dv As DataView
                dv = New DataView(dt)
                dv.RowFilter = "Grupo=0"

                lblInVentaContado.Text = SigaMetClasses.SumaColumnaVista(dv, "VentasContado").ToString("N")
                lblInVentaCredito.Text = SigaMetClasses.SumaColumnaVista(dv, "VentasCredito").ToString("N")
                lblInCobranza.Text = SigaMetClasses.SumaColumnaVista(dv, "Cobranza").ToString("N")
                lblInChequesDevueltos.Text = SigaMetClasses.SumaColumnaVista(dv, "ChequesDev").ToString("N")
                lblInNotaIngreso.Text = SigaMetClasses.SumaColumnaVista(dv, "NotaIngreso").ToString("N")
                'lblEgNotaIngreso.Text = SumaColumna(dt, "NotaIngreso").ToString("N")
                lblTotalIngreso.Text = SigaMetClasses.SumaColumnaVista(dv, "TotalCelula").ToString("N")

                dv.RowFilter = "Grupo=1"
                Me.lblc7VentaContado.Text = SigaMetClasses.SumaColumnaVista(dv, "VentasContado").ToString("N")
                Me.lblc7VentaCredito.Text = SigaMetClasses.SumaColumnaVista(dv, "VentasCredito").ToString("N")
                Me.lblc7Cobranza.Text = SigaMetClasses.SumaColumnaVista(dv, "Cobranza").ToString("N")
                Me.lblc7ChequesDevueltos.Text = SigaMetClasses.SumaColumnaVista(dv, "ChequesDev").ToString("N")
                Me.lblc7NotasIngreso.Text = SigaMetClasses.SumaColumnaVista(dv, "NotaIngreso").ToString("N")
                Me.lblc7TotalIngresos.Text = SigaMetClasses.SumaColumnaVista(dv, "TotalCelula").ToString("N")

                CalculaTotales()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            dt.Dispose()
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.DialogResult = DialogResult.Cancel
    End Sub

    Private Sub frmCorteCajaAlta_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstAplicacion.ValueMember = "TipoAplicacionIngreso"
        lstAplicacion.DisplayMember = "InformacionCompleta"
    End Sub

    Private Function CalculaTotalAplicacion() As Decimal
        Return CType(lblEgVentaCredito.Text, Decimal) + TotalAplicacion
    End Function

    Private Sub CalculaTotales()
        lblTotalAplicacion.Text = CalculaTotalAplicacion.ToString("N")
        lblDiferencia.Text = _
        ((CType(lblTotalIngreso.Text, Decimal) + _
            CType(Me.lblc7TotalIngresos.Text, Decimal)) - _
            CType(lblTotalAplicacion.Text, Decimal)).ToString("N")

    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If MessageBox.Show(SigaMetClasses.M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Cursor = Cursors.WaitCursor
            Try
                Dim oCorte As New SigaMetClasses.CorteCaja()

                If CType(lblEgVentaCredito.Text, Decimal) <> 0 Then
                    Dim sAplicacion As SigaMetClasses.sTipoAplicacionIngreso
                    sAplicacion.TipoAplicacionIngreso = 50
                    sAplicacion.Importe = CType(lblEgVentaCredito.Text, Decimal)
                    lstAplicacion.Items.Add(sAplicacion)
                End If

                oCorte.Aplicacion(Main.GLOBAL_CajaUsuario, Main.FechaOperacion, Main.ConsecutivoInicioDeSesion, Me.lstAplicacion.Items)

                MessageBox.Show("El corte de caja fue grabado correctamente.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK

            Catch ex As Exception
                MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default

            End Try

        End If
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim frmSelAp As New frmCorteCajaTipoAplicacion(_Caja)
        If frmSelAp.ShowDialog() = DialogResult.OK Then

            If frmSelAp.Importe + CalculaTotalAplicacion() <= (CType(lblTotalIngreso.Text, Decimal) + CType(Me.lblc7TotalIngresos.Text, Decimal)) Then
                Dim oAplicacion As New SigaMetClasses.sTipoAplicacionIngreso()
                oAplicacion.TipoAplicacionIngreso = frmSelAp.TipoAplicacionIngreso
                oAplicacion.Descripcion = frmSelAp.Descripcion
                oAplicacion.Importe = frmSelAp.Importe

                lstAplicacion.Items.Add(oAplicacion)

                TotalAplicacion += oAplicacion.Importe

                CalculaTotales()
            Else
                MessageBox.Show("El importe de la aplicación rebasa el total de ingresos.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)

            End If

        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        TotalAplicacion -= CType(lstAplicacion.SelectedItem, SigaMetClasses.sTipoAplicacionIngreso).Importe
        lstAplicacion.Items.Remove(lstAplicacion.SelectedItem)
        CalculaTotales()
    End Sub
End Class