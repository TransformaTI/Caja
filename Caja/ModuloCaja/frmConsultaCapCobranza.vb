Imports System.Collections.Generic

Public Class frmConsultaCapCobranza
    Inherits System.Windows.Forms.Form
    Private _Clave As String
    Private _Caja As Byte
    Private _FOperacion As Date
    Private _Consecutivo As Byte
    Private _Folio As Integer
    Private _Status As String
    Private _TipoMovimientoCaja As Short
    Private _FolioAtt As Integer = 0
    Private _AñoAtt As Short = 0
    Public FAlta As Date
    Private dtCobranza As New DataTable()
    Private Titulo As String = "Consulta de cobranza"
    Friend WithEvents btnCapturaRemision As System.Windows.Forms.ToolBarButton
    Friend WithEvents colFolioAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAñoAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents cmbCelula As System.Windows.Forms.ComboBox
    Friend WithEvents colTipoProducto As System.Windows.Forms.DataGridTextBoxColumn
    Private _ListaCargada As Boolean = False

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
    Friend WithEvents colCaja As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFOperacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colConsecutivo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFolio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFAlta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Grid As System.Windows.Forms.DataGrid
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colRutaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRutaCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblCelula As System.Windows.Forms.Label
    Friend WithEvents dtpFOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFOperacion As System.Windows.Forms.Label
    Friend WithEvents tbrBarra As System.Windows.Forms.ToolBar
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents btnCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents colEmpleadoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoMovimientoCajaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoMovimientoCaja As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lblConsecutivo As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboCelula As SigaMetClasses.Combos.ComboCelula
    Friend WithEvents colFMovimiento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grpFiltro As System.Windows.Forms.GroupBox
    Friend WithEvents colCajaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblFolio As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents colClave As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents ComboStatus As SigaMetClasses.Combos.ComboStatus
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents colCobroTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnCerrar2 As System.Windows.Forms.Button
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnDocumentos As System.Windows.Forms.ToolBarButton
    Friend WithEvents mnuImpresion As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuCobrosEliminados As System.Windows.Forms.MenuItem
    Friend WithEvents LabelNombreEmpresa1 As NombreEmpresa.LabelNombreEmpresa
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaCapCobranza))
        Me.Grid = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colClave = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCaja = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCajaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRutaCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFMovimiento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRutaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFOperacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colConsecutivo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpleadoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFAlta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoMovimientoCajaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoMovimientoCaja = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCobroTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolioAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAñoAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblFolio = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblConsecutivo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.lblCelula = New System.Windows.Forms.Label()
        Me.dtpFOperacion = New System.Windows.Forms.DateTimePicker()
        Me.lblFOperacion = New System.Windows.Forms.Label()
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.btnDocumentos = New System.Windows.Forms.ToolBarButton()
        Me.btnCapturaRemision = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.mnuImpresion = New System.Windows.Forms.ContextMenu()
        Me.mnuCobrosEliminados = New System.Windows.Forms.MenuItem()
        Me.btnSep1 = New System.Windows.Forms.ToolBarButton()
        Me.btnRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.btnSep2 = New System.Windows.Forms.ToolBarButton()
        Me.btnCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.ComboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.grpFiltro = New System.Windows.Forms.GroupBox()
        Me.cmbCelula = New System.Windows.Forms.ComboBox()
        Me.LabelNombreEmpresa1 = New NombreEmpresa.LabelNombreEmpresa()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboStatus = New SigaMetClasses.Combos.ComboStatus()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnCerrar2 = New System.Windows.Forms.Button()
        Me.colTipoProducto = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.grpFiltro.SuspendLayout()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.Grid.CaptionText = "Lista de documentos"
        Me.Grid.DataMember = ""
        Me.Grid.FlatMode = True
        Me.Grid.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Grid.Location = New System.Drawing.Point(0, 120)
        Me.Grid.Name = "Grid"
        Me.Grid.ReadOnly = True
        Me.Grid.Size = New System.Drawing.Size(816, 232)
        Me.Grid.TabIndex = 0
        Me.Grid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.Grid
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colClave, Me.colCaja, Me.colCajaDescripcion, Me.colRutaCelula, Me.colRuta, Me.colFMovimiento, Me.colRutaDescripcion, Me.colFOperacion, Me.colConsecutivo, Me.colFolio, Me.colEmpleadoNombre, Me.colFAlta, Me.colTipoMovimientoCajaDescripcion, Me.colStatus, Me.colTotal, Me.colTipoMovimientoCaja, Me.colCobroTotal, Me.colObservaciones, Me.colFolioAtt, Me.colAñoAtt, Me.colTipoProducto})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.ReadOnly = True
        '
        'colClave
        '
        Me.colClave.Format = ""
        Me.colClave.FormatInfo = Nothing
        Me.colClave.HeaderText = "Clave"
        Me.colClave.MappingName = "Clave"
        Me.colClave.Width = 110
        '
        'colCaja
        '
        Me.colCaja.Format = ""
        Me.colCaja.FormatInfo = Nothing
        Me.colCaja.MappingName = "Caja"
        Me.colCaja.ReadOnly = True
        Me.colCaja.Width = 0
        '
        'colCajaDescripcion
        '
        Me.colCajaDescripcion.Format = ""
        Me.colCajaDescripcion.FormatInfo = Nothing
        Me.colCajaDescripcion.HeaderText = "Caja"
        Me.colCajaDescripcion.MappingName = "CajaDescripcion"
        Me.colCajaDescripcion.Width = 75
        '
        'colRutaCelula
        '
        Me.colRutaCelula.Format = ""
        Me.colRutaCelula.FormatInfo = Nothing
        Me.colRutaCelula.HeaderText = "Célula"
        Me.colRutaCelula.MappingName = "RutaCelula"
        Me.colRutaCelula.Width = 40
        '
        'colRuta
        '
        Me.colRuta.Format = ""
        Me.colRuta.FormatInfo = Nothing
        Me.colRuta.HeaderText = "Ruta"
        Me.colRuta.MappingName = "Ruta"
        Me.colRuta.Width = 0
        '
        'colFMovimiento
        '
        Me.colFMovimiento.Format = ""
        Me.colFMovimiento.FormatInfo = Nothing
        Me.colFMovimiento.HeaderText = "F.Movimiento"
        Me.colFMovimiento.MappingName = "FMovimiento"
        Me.colFMovimiento.Width = 75
        '
        'colRutaDescripcion
        '
        Me.colRutaDescripcion.Format = ""
        Me.colRutaDescripcion.FormatInfo = Nothing
        Me.colRutaDescripcion.HeaderText = "Ruta"
        Me.colRutaDescripcion.MappingName = "RutaDescripcion"
        Me.colRutaDescripcion.Width = 75
        '
        'colFOperacion
        '
        Me.colFOperacion.Format = ""
        Me.colFOperacion.FormatInfo = Nothing
        Me.colFOperacion.HeaderText = "F.Operación"
        Me.colFOperacion.MappingName = "FOperacion"
        Me.colFOperacion.ReadOnly = True
        Me.colFOperacion.Width = 80
        '
        'colConsecutivo
        '
        Me.colConsecutivo.Format = ""
        Me.colConsecutivo.FormatInfo = Nothing
        Me.colConsecutivo.MappingName = "Consecutivo"
        Me.colConsecutivo.ReadOnly = True
        Me.colConsecutivo.Width = 0
        '
        'colFolio
        '
        Me.colFolio.Format = ""
        Me.colFolio.FormatInfo = Nothing
        Me.colFolio.MappingName = "Folio"
        Me.colFolio.ReadOnly = True
        Me.colFolio.Width = 0
        '
        'colEmpleadoNombre
        '
        Me.colEmpleadoNombre.Format = ""
        Me.colEmpleadoNombre.FormatInfo = Nothing
        Me.colEmpleadoNombre.HeaderText = "Capturó"
        Me.colEmpleadoNombre.MappingName = "EmpleadoNombre"
        Me.colEmpleadoNombre.Width = 0
        '
        'colFAlta
        '
        Me.colFAlta.Format = ""
        Me.colFAlta.FormatInfo = Nothing
        Me.colFAlta.HeaderText = "F.Alta"
        Me.colFAlta.MappingName = "FAlta"
        Me.colFAlta.ReadOnly = True
        Me.colFAlta.Width = 130
        '
        'colTipoMovimientoCajaDescripcion
        '
        Me.colTipoMovimientoCajaDescripcion.Format = ""
        Me.colTipoMovimientoCajaDescripcion.FormatInfo = Nothing
        Me.colTipoMovimientoCajaDescripcion.HeaderText = "Tipo movimiento"
        Me.colTipoMovimientoCajaDescripcion.MappingName = "TipoMovimientoCajaDescripcion"
        Me.colTipoMovimientoCajaDescripcion.Width = 130
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Status"
        Me.colStatus.MappingName = "MovimientoCajaStatus"
        Me.colStatus.Width = 75
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total mov."
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 75
        '
        'colTipoMovimientoCaja
        '
        Me.colTipoMovimientoCaja.Format = ""
        Me.colTipoMovimientoCaja.FormatInfo = Nothing
        Me.colTipoMovimientoCaja.MappingName = "TipoMovimientoCaja"
        Me.colTipoMovimientoCaja.Width = 0
        '
        'colCobroTotal
        '
        Me.colCobroTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colCobroTotal.Format = "#,##.00"
        Me.colCobroTotal.FormatInfo = Nothing
        Me.colCobroTotal.HeaderText = "Cobranza"
        Me.colCobroTotal.MappingName = "CobroPedidoTotal"
        Me.colCobroTotal.NullText = ""
        Me.colCobroTotal.Width = 75
        '
        'colObservaciones
        '
        Me.colObservaciones.Format = ""
        Me.colObservaciones.FormatInfo = Nothing
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.MappingName = "Observaciones"
        Me.colObservaciones.Width = 0
        '
        'colFolioAtt
        '
        Me.colFolioAtt.Format = ""
        Me.colFolioAtt.FormatInfo = Nothing
        Me.colFolioAtt.HeaderText = "FolioAtt"
        Me.colFolioAtt.MappingName = "FolioAtt"
        Me.colFolioAtt.Width = 0
        '
        'colAñoAtt
        '
        Me.colAñoAtt.Format = ""
        Me.colAñoAtt.FormatInfo = Nothing
        Me.colAñoAtt.HeaderText = "AñoAtt"
        Me.colAñoAtt.MappingName = "AñoAtt"
        Me.colAñoAtt.Width = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TabControl1.Location = New System.Drawing.Point(0, 357)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(832, 112)
        Me.TabControl1.TabIndex = 8
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.lblObservaciones)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.lblTotal)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.lblFolio)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.lblConsecutivo)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.lblNombreEmpleado)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(824, 86)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Datos"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 51)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(82, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Observaciones:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblObservaciones
        '
        Me.lblObservaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblObservaciones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblObservaciones.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblObservaciones.Location = New System.Drawing.Point(104, 48)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(712, 21)
        Me.lblObservaciones.TabIndex = 10
        Me.lblObservaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(672, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(35, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Total:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotal
        '
        Me.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotal.Location = New System.Drawing.Point(712, 24)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(104, 21)
        Me.lblTotal.TabIndex = 8
        Me.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(552, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Folio:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblFolio
        '
        Me.lblFolio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFolio.Location = New System.Drawing.Point(584, 24)
        Me.lblFolio.Name = "lblFolio"
        Me.lblFolio.Size = New System.Drawing.Size(80, 21)
        Me.lblFolio.TabIndex = 6
        Me.lblFolio.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(392, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Consecutivo:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblConsecutivo
        '
        Me.lblConsecutivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblConsecutivo.Location = New System.Drawing.Point(464, 24)
        Me.lblConsecutivo.Name = "lblConsecutivo"
        Me.lblConsecutivo.Size = New System.Drawing.Size(80, 21)
        Me.lblConsecutivo.TabIndex = 4
        Me.lblConsecutivo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Responsable:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombreEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpleado.ForeColor = System.Drawing.Color.MediumBlue
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(104, 24)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(272, 21)
        Me.lblNombreEmpleado.TabIndex = 2
        Me.lblNombreEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.BackColor = System.Drawing.SystemColors.Control
        Me.lblCelula.Location = New System.Drawing.Point(16, 20)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(78, 13)
        Me.lblCelula.TabIndex = 10
        Me.lblCelula.Text = "Mostrar célula:"
        '
        'dtpFOperacion
        '
        Me.dtpFOperacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFOperacion.Location = New System.Drawing.Point(688, 20)
        Me.dtpFOperacion.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFOperacion.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.dtpFOperacion.Name = "dtpFOperacion"
        Me.dtpFOperacion.Size = New System.Drawing.Size(112, 21)
        Me.dtpFOperacion.TabIndex = 11
        Me.dtpFOperacion.Value = New Date(2010, 12, 31, 0, 0, 0, 0)
        '
        'lblFOperacion
        '
        Me.lblFOperacion.AutoSize = True
        Me.lblFOperacion.BackColor = System.Drawing.SystemColors.Control
        Me.lblFOperacion.Location = New System.Drawing.Point(576, 20)
        Me.lblFOperacion.Name = "lblFOperacion"
        Me.lblFOperacion.Size = New System.Drawing.Size(90, 13)
        Me.lblFOperacion.TabIndex = 12
        Me.lblFOperacion.Text = "Fecha operación:"
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnConsultar, Me.btnDocumentos, Me.btnCapturaRemision, Me.ToolBarButton1, Me.btnImprimir, Me.btnSep1, Me.btnRefrescar, Me.btnSep2, Me.btnCerrar})
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(53, 35)
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista
        Me.tbrBarra.Location = New System.Drawing.Point(0, 0)
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(832, 50)
        Me.tbrBarra.TabIndex = 13
        '
        'btnConsultar
        '
        Me.btnConsultar.ImageIndex = 0
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Tag = "Consultar"
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.ToolTipText = "Consultar movimiento seleccionado"
        '
        'btnDocumentos
        '
        Me.btnDocumentos.ImageIndex = 4
        Me.btnDocumentos.Name = "btnDocumentos"
        Me.btnDocumentos.Tag = "Documentos"
        Me.btnDocumentos.Text = "Sellos"
        Me.btnDocumentos.ToolTipText = "Consulta los documentos que se pueden sellar"
        '
        'btnCapturaRemision
        '
        Me.btnCapturaRemision.ImageIndex = 5
        Me.btnCapturaRemision.Name = "btnCapturaRemision"
        Me.btnCapturaRemision.Tag = "CapturaRemision"
        Me.btnCapturaRemision.Text = "&Remisión"
        Me.btnCapturaRemision.ToolTipText = "Captura de remisión manual"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImprimir
        '
        Me.btnImprimir.DropDownMenu = Me.mnuImpresion
        Me.btnImprimir.ImageIndex = 3
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnImprimir.Tag = "Imprimir"
        Me.btnImprimir.Text = "&Imprimir"
        Me.btnImprimir.ToolTipText = "Imprimir el Comprobante de Caja"
        '
        'mnuImpresion
        '
        Me.mnuImpresion.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuCobrosEliminados})
        '
        'mnuCobrosEliminados
        '
        Me.mnuCobrosEliminados.Index = 0
        Me.mnuCobrosEliminados.Text = "&Cobros eliminados"
        '
        'btnSep1
        '
        Me.btnSep1.Name = "btnSep1"
        Me.btnSep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRefrescar
        '
        Me.btnRefrescar.ImageIndex = 1
        Me.btnRefrescar.Name = "btnRefrescar"
        Me.btnRefrescar.Tag = "Refrescar"
        Me.btnRefrescar.Text = "Refrescar"
        Me.btnRefrescar.ToolTipText = "Refrescar información"
        '
        'btnSep2
        '
        Me.btnSep2.Name = "btnSep2"
        Me.btnSep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnCerrar
        '
        Me.btnCerrar.ImageIndex = 2
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Tag = "Cerrar"
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.ToolTipText = "Cerrar"
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
        Me.imgLista.Images.SetKeyName(5, "edit.ico")
        '
        'ComboCelula
        '
        Me.ComboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.ComboCelula.Location = New System.Drawing.Point(112, 20)
        Me.ComboCelula.Name = "ComboCelula"
        Me.ComboCelula.Size = New System.Drawing.Size(200, 21)
        Me.ComboCelula.TabIndex = 0
        '
        'grpFiltro
        '
        Me.grpFiltro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpFiltro.Controls.Add(Me.cmbCelula)
        Me.grpFiltro.Controls.Add(Me.LabelNombreEmpresa1)
        Me.grpFiltro.Controls.Add(Me.Label5)
        Me.grpFiltro.Controls.Add(Me.ComboStatus)
        Me.grpFiltro.Controls.Add(Me.lblCelula)
        Me.grpFiltro.Controls.Add(Me.ComboCelula)
        Me.grpFiltro.Controls.Add(Me.lblFOperacion)
        Me.grpFiltro.Controls.Add(Me.dtpFOperacion)
        Me.grpFiltro.Location = New System.Drawing.Point(8, 48)
        Me.grpFiltro.Name = "grpFiltro"
        Me.grpFiltro.Size = New System.Drawing.Size(816, 64)
        Me.grpFiltro.TabIndex = 14
        Me.grpFiltro.TabStop = False
        Me.grpFiltro.Text = "Seleccione el filtro para la consulta de documentos"
        '
        'cmbCelula
        '
        Me.cmbCelula.FormattingEnabled = True
        Me.cmbCelula.Location = New System.Drawing.Point(112, 20)
        Me.cmbCelula.Name = "cmbCelula"
        Me.cmbCelula.Size = New System.Drawing.Size(200, 21)
        Me.cmbCelula.TabIndex = 16
        '
        'LabelNombreEmpresa1
        '
        Me.LabelNombreEmpresa1.AutoSize = True
        Me.LabelNombreEmpresa1.Location = New System.Drawing.Point(112, 44)
        Me.LabelNombreEmpresa1.Name = "LabelNombreEmpresa1"
        Me.LabelNombreEmpresa1.Size = New System.Drawing.Size(116, 13)
        Me.LabelNombreEmpresa1.TabIndex = 15
        Me.LabelNombreEmpresa1.Text = "LabelNombreEmpresa1"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.SystemColors.Control
        Me.Label5.Location = New System.Drawing.Point(376, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Estatus:"
        '
        'ComboStatus
        '
        Me.ComboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboStatus.ForeColor = System.Drawing.Color.MediumBlue
        Me.ComboStatus.Location = New System.Drawing.Point(432, 20)
        Me.ComboStatus.Name = "ComboStatus"
        Me.ComboStatus.Size = New System.Drawing.Size(121, 21)
        Me.ComboStatus.TabIndex = 13
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.ForeColor = System.Drawing.Color.DarkBlue
        Me.txtClave.Location = New System.Drawing.Point(549, 9)
        Me.txtClave.Name = "txtClave"
        Me.txtClave.Size = New System.Drawing.Size(160, 21)
        Me.txtClave.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label6.Location = New System.Drawing.Point(437, 12)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(104, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "Búsqueda rápida:"
        '
        'btnBuscar
        '
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(717, 8)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 17
        Me.btnBuscar.TabStop = False
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar2
        '
        Me.btnCerrar2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar2.Location = New System.Drawing.Point(0, 136)
        Me.btnCerrar2.Name = "btnCerrar2"
        Me.btnCerrar2.Size = New System.Drawing.Size(0, 0)
        Me.btnCerrar2.TabIndex = 18
        Me.btnCerrar2.Text = "Button1"
        '
        'colTipoProducto
        '
        Me.colTipoProducto.Format = ""
        Me.colTipoProducto.FormatInfo = Nothing
        Me.colTipoProducto.HeaderText = "TipoProducto"
        Me.colTipoProducto.MappingName = "TipoProducto"
        Me.colTipoProducto.Width = 0
        '
        'frmConsultaCapCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar2
        Me.ClientSize = New System.Drawing.Size(832, 469)
        Me.Controls.Add(Me.btnCerrar2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.grpFiltro)
        Me.Controls.Add(Me.tbrBarra)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Grid)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaCapCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de liquidaciones y capturas de cobranza"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.grpFiltro.ResumeLayout(False)
        Me.grpFiltro.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub LimpiaDatos()
        _Caja = 0
        _Consecutivo = 0
        _Folio = 0
        _FolioAtt = 0
        _AñoAtt = 0
        lblNombreEmpleado.Text = ""
        lblObservaciones.Text = ""
        lblConsecutivo.Text = ""
        ComboStatus.SelectedIndex = 0
    End Sub

    Private Sub frmConsultaCapCobranza_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'ComboCelula.CargaDatos()

        Dim todasCelulas As Boolean
        Dim m_metodos As New MetodoDatos
        todasCelulas = m_metodos.ValidarParametroCelulasUsuario()

        Dim celulas As New List(Of Celula)

        If (todasCelulas) Then
            celulas = m_metodos.ConsultaCelulasPorUsusario()
        Else
            celulas = m_metodos.ConsultaTodasLasCelulas()
        End If

        cmbCelula.DataSource = celulas
        cmbCelula.DisplayMember = "DescripcionCelula"
        cmbCelula.ValueMember = "IdCelula"        

        ComboStatus.CargaDatos()
        ComboStatus.SelectedIndex = 0
        dtpFOperacion.Value = Now.Date
        'CargaLista()
        CargaLista2()
        txtClave.SelectAll()

        LabelNombreEmpresa1.CargarNombreEmpresa()
    End Sub

    Private Sub CargaLista(Optional ByVal Filtro As String = "")
        Cursor = Cursors.WaitCursor()
        'TODO Filtrar para checar solamente las que faltan por liquidar en caja
        Dim strQuery As String = "SET transaction isolation level read uncommitted SELECT * FROM vwMovimientoCaja1 WHERE FOperacion = '" & dtpFOperacion.Value.ToShortDateString & "'" & " ORDER BY Clave"

        Try
            Grid.DataSource = Nothing
            dtCobranza.Clear()
            Dim da As New SqlClient.SqlDataAdapter(strQuery, GLOBAL_Connection)
            da.SelectCommand.CommandTimeout = 180

            da.Fill(dtCobranza)

            If Filtro <> "" Then dtCobranza.DefaultView.RowFilter = Filtro


            If dtCobranza.Rows.Count > 0 Then
                btnConsultar.Enabled = True
                Grid.DataSource = dtCobranza
            Else
                btnConsultar.Enabled = False
            End If
            If Filtro <> "" Then
                Grid.CaptionText = "Lista de documentos (" & dtCobranza.DefaultView.Count & ")"
            Else
                Grid.CaptionText = "Lista de documentos (" & dtCobranza.Rows.Count & ")"
            End If

            lblTotal.Text = SumaColumna(dtCobranza, "Total").ToString("C")
            _ListaCargada = True


        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
            Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargaLista2()
        _ListaCargada = True
        Dim cmdCyL As New SqlClient.SqlCommand("spConsultaCobranzasyLiqs", GLOBAL_Connection)
        cmdCyL.CommandType = CommandType.StoredProcedure
        cmdCyL.Parameters.Add("@FOperacion", SqlDbType.Date).Value = dtpFOperacion.Value
        If ComboStatus.Text = "" Or ComboStatus.Text = "<Todos>" Then
            cmdCyL.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = DBNull.Value
        Else
            cmdCyL.Parameters.Add("@Estatus", SqlDbType.VarChar).Value = ComboStatus.Text
        End If        
        If CInt(cmbCelula.SelectedValue) <> 0 Then
            cmdCyL.Parameters.Add("@Celula", SqlDbType.Int).Value = cmbCelula.SelectedValue
        Else
            cmdCyL.Parameters.Add("@Celula", SqlDbType.Int).Value = DBNull.Value
        End If


        Dim daCyL As New SqlClient.SqlDataAdapter(cmdCyL)
        Dim dtCyL As New DataTable
        Grid.DataSource = Nothing
        Try
            Cursor = Cursors.WaitCursor
            daCyL.Fill(dtCyL)

            If dtCyL.Rows.Count > 0 Then
                btnConsultar.Enabled = True
                Grid.DataSource = dtCyL
            Else
                btnConsultar.Enabled = False
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Me.Close()
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
            Cursor = Cursors.Default
        End Try

        If dtCyL.Rows.Count > 0 Then
            Grid.Select(0)
            Grid_CurrentCellChanged(Grid, New EventArgs)
        End If
    End Sub

    Private Sub Grid_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.CurrentCellChanged
        lblNombreEmpleado.Text = CType(Grid.Item(Grid.CurrentRowIndex, 10), String)
        lblObservaciones.Text = CType(Grid.Item(Grid.CurrentRowIndex, 17), String)
        _Clave = CType(Grid.Item(Grid.CurrentRowIndex, 0), String).Trim
        _Caja = CType(Grid.Item(Grid.CurrentRowIndex, 1), Byte)
        _FOperacion = CType(Grid.Item(Grid.CurrentRowIndex, 7), Date)
        _Consecutivo = CType(Grid.Item(Grid.CurrentRowIndex, 8), Byte)
        _Folio = CType(Grid.Item(Grid.CurrentRowIndex, 9), Integer)
        FAlta = CType(Grid.Item(Grid.CurrentRowIndex, 11), Date)
        _Status = Trim(CType(Grid.Item(Grid.CurrentRowIndex, 13), String))
        _TipoMovimientoCaja = CType(Grid.Item(Grid.CurrentRowIndex, 15), Short)
        _FolioAtt = CType(Grid.Item(Grid.CurrentRowIndex, 18), Integer)
        _AñoAtt = CType(Grid.Item(Grid.CurrentRowIndex, 19), Short)
        lblConsecutivo.Text = _Consecutivo.ToString
        lblFolio.Text = _Folio.ToString
        
        Grid.Select(Grid.CurrentRowIndex)

    End Sub

    Private Function ConsultaMovimientoPorClave(ByVal strClave As String) As DataTable
        '20 de febrero del 2003
        Dim strQuery As String = "Select Caja, FOperacion, Consecutivo, Folio, TipoMovimientoCaja, Status, FAlta From MovimientoCaja Where Clave = '" & strClave & "'"
        Dim dt As New DataTable("MovCaja")
        'Dim da As New Data.SqlClient.SqlDataAdapter(strQuery, ConString)
        Dim da As New Data.SqlClient.SqlDataAdapter(strQuery, GLOBAL_Connection)
        Try
            da.Fill(dt)
            Return dt
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        Return dt
    End Function

    Private Sub ConsultaMovimientoCaja(ByVal Caja As Byte, _
                                       ByVal FOperacion As Date, _
                                       ByVal Consecutivo As Byte, _
                                       ByVal Folio As Integer, _
                                       ByVal TipoMovimientoCaja As Short)

        If _Folio > 0 Then
            Cursor = Cursors.WaitCursor
            Try
                Dim ds As DataSet = ConsultaMovimiento(Caja, FOperacion, Consecutivo, Folio, TipoMovimientoCaja)
                Dim frmCapMov As frmCapMovimiento

                If _Status <> "EMITIDO" Then
                    frmCapMov = New frmCapMovimiento(TipoOperacionMovimientoCaja.Consulta, ds, _Caja, _FOperacion, _Consecutivo, _Folio, FAlta)
                Else
                    frmCapMov = New frmCapMovimiento(TipoOperacionMovimientoCaja.Validacion, ds, _Caja, _FOperacion, _Consecutivo, _Folio, FAlta)
                End If
                If frmCapMov.ShowDialog() = DialogResult.OK Then
                    LimpiaDatos()
                    CargaLista()

                    If _Status = "EMITIDO" Then
                        ConsultaDocumentos()
                    End If
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                Cursor = Cursors.Default
            End Try

        End If
    End Sub

    'Funcion para consultar completo el movimiento especificado segun lo que se 
    'seleccione en el grid del form.
    Private Function ConsultaMovimiento(ByVal Caja As Byte, _
                                        ByVal FOperacion As Date, _
                                        ByVal Consecutivo As Byte, _
                                        ByVal Folio As Integer, _
                                        ByVal TipoMovimientoCaja As Short) As DataSet

        Dim dtCobro As New MiDataTable()
        'Dim dtTarjetaCredito As New MiDataTableTarjetaCredito()
        Dim dtCambio As New MiDataTableCambio()
        Dim decTotalMovimientoCaja As Decimal
        Dim strQuery As String
        Dim strFOperacion As String = "'" & FOperacion.ToShortDateString & "'"
        Dim dsDatosMov As New DataSet()
        Dim FiltroSeleccion As String = " WHERE Caja = " & Caja & _
                                        " AND FOPeracion = " & strFOperacion & _
                                        " AND Consecutivo = " & Consecutivo & _
                                        " AND Folio = " & Folio


        'Dim cn As New SqlClient.SqlConnection(ConString)
        Dim cn As SqlClient.SqlConnection = GLOBAL_Connection

        strQuery = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaCapturaCobranza1" & FiltroSeleccion

        '08 de febrero del 2003 (solo los de contado)
        If _TipoMovimientoCaja = 2 Then
            strQuery &= " AND PedidoTipoCobro = 5"
        End If


        Dim cmd As New SqlClient.SqlCommand(strQuery)
        cmd.Connection = cn

        Dim da As New SqlClient.SqlDataAdapter(cmd)

        da.Fill(dtCobro)
        dtCobro.TableName = "Cobro"

        'Cabecera
        cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwMovimientoCaja1" & FiltroSeleccion
        da.Fill(dsDatosMov, "Cabecera")

        'Consulto la lista de cheques de este movimiento
        cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaDeChequesPorMovimientoCaja" & FiltroSeleccion
        da.Fill(dsDatosMov, "Cheques")

        'Consulto la lista de fichas de depósito de este movimiento
        cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaDeFichasPorMovimientoCaja" & FiltroSeleccion
        da.Fill(dsDatosMov, "FichaDeposito")

        'Consulto la lista de cobros con tarjeta de crédito de este movimiento
        cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaDeTarjetaPorMovimientoCaja" & FiltroSeleccion
        da.Fill(dsDatosMov, "TarjetaCredito")

        'Consulto la lista de denominaciones que tiene este movimiento
        cmd.CommandText = "SET transaction isolation level read uncommitted SELECT * FROM vwMovimientoCajaEntrada1" & FiltroSeleccion & " AND TipoCobro <> 3"
        da.Fill(dsDatosMov, "Denominacion")

        'Consulto el cambio que resultó de este movimiento
        cmd.CommandText = "SET transaction isolation level read uncommitted SELECT Denominacion, Cantidad, Pesos, Total FROM MovimientoCajaSalida" & FiltroSeleccion
        da.Fill(dtCambio)
        dtCambio.TableName = "Cambio"

        strQuery = "SET transaction isolation level read uncommitted SELECT Total FROM MovimientoCaja" & FiltroSeleccion

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        cmd.CommandText = strQuery

        decTotalMovimientoCaja = CDec(cmd.ExecuteScalar())
        dtCobro.TotalMovimientoCaja = decTotalMovimientoCaja

        dsDatosMov.Tables.Add(dtCobro)
        dsDatosMov.Tables.Add(dtCambio)

        If cn.State = ConnectionState.Open Then
            cn.Close()
        End If

        Return dsDatosMov

    End Function

    Private Sub dtpFOperacion_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFOperacion.ValueChanged
        'Filtro()        
        If _ListaCargada Then
            CargaLista2()
        End If
    End Sub

    Private Sub Filtro()

        If _ListaCargada Then
            Try
                Dim strQuery As String

                'LUSATE 09/10/2015 Se modifica para consultar por usuariocelula
                'If ComboCelula.Celula <= 0 And ComboCelula.SelectedIndex < 0 Then
                '    strQuery = "FOperacion = '" & dtpFOperacion.Value.ToShortDateString & "'"
                '    'dtCobranza.DefaultView.RowFilter()
                'Else
                '    'dtCobranza.DefaultView.RowFilter 
                '    strQuery = "FOperacion = '" & dtpFOperacion.Value.ToShortDateString & "' AND RutaCelula = " & ComboCelula.Celula.ToString
                'End If
                strQuery = "FOperacion = '" & dtpFOperacion.Value.ToShortDateString & "' AND RutaCelula = " & cmbCelula.SelectedValue.ToString
                'LUSATE 09/10/2015

                If ComboStatus.Text <> "<Todos>" And ComboStatus.Text <> "" Then
                    strQuery &= " AND MovimientoCajaStatus = '" & ComboStatus.Text & "'"
                End If

                Me.CargaLista(strQuery)
                Grid.CaptionText = "Lista de documentos (" & dtCobranza.DefaultView.Count.ToString & ")"
            Catch ex As Exception
                MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
       

    End Sub

    Private Sub ConsultaDocumentos()
        Cursor = Cursors.WaitCursor
        Dim oDocs As New frmConsultaDocumentosMovCaja(_Clave)
        oDocs.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Consultar"
                ConsultaMovimientoCaja(_Caja, _FOperacion, _Consecutivo, _Folio, _TipoMovimientoCaja)
            Case Is = "Documentos"
                ConsultaDocumentos()
            Case Is = "CapturaRemision"
                CapturaRemision()
            Case Is = "Imprimir"
                Imprimir()
            Case Is = "Refrescar"
                LimpiaDatos()
                CargaLista2()
                'CargaLista()
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub ComboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCelula.SelectedIndexChanged
        'If ComboCelula.DatosCargados = True Then Filtro()        
    End Sub

    Private Sub Imprimir()
        Cursor = Cursors.WaitCursor
        Dim frmConRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RepComprobanteCaja, 0, Now, _FOperacion, _Caja, _Folio, _Consecutivo, _Clave)
        frmConRep.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Private Sub ComboStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboStatus.SelectedIndexChanged
        'If ComboCelula.DatosCargados Then Filtro()
        If _ListaCargada Then CargaLista2()
    End Sub


    Private Sub txtClave_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.Enter
        Me.AcceptButton = btnBuscar
    End Sub

    Private Sub txtClave_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.Leave
        Me.AcceptButton = Nothing
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Trim(txtClave.Text) <> "" Then
            Dim dt As DataTable = ConsultaMovimientoPorClave(txtClave.Text.Trim.ToUpper)
            If dt.Rows.Count = 1 Then
                _Caja = CType(dt.Rows(0).Item("Caja"), Byte)
                _FOperacion = CType(dt.Rows(0).Item("FOperacion"), Date)
                _Consecutivo = CType(dt.Rows(0).Item("Consecutivo"), Byte)
                _Folio = CType(dt.Rows(0).Item("Folio"), Integer)
                _TipoMovimientoCaja = CType(dt.Rows(0).Item("TipoMovimientoCaja"), Byte)
                FAlta = CType(dt.Rows(0).Item("FAlta"), Date)
                _Status = CType(dt.Rows(0).Item("Status"), String).Trim
                ConsultaMovimientoCaja(_Caja, _FOperacion, _Consecutivo, _Folio, _TipoMovimientoCaja)
                LimpiaDatos()
                'CargaLista()
                CargaLista2()
            Else
                MessageBox.Show("El movimiento con clave: " & Trim(UCase(txtClave.Text)) & " no existe en la base de datos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub


    Private Sub Grid_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Grid.DoubleClick
        ConsultaMovimientoCaja(_Caja, _FOperacion, _Consecutivo, _Folio, _TipoMovimientoCaja)
    End Sub

    Private Sub btnCerrar2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCerrar2.Click
        Me.Close()
    End Sub

    Private Sub mnuCobrosEliminados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCobrosEliminados.Click
        Cursor = Cursors.WaitCursor
        Dim frmConRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RepMovimientoCobrosEliminados, 0, Now, _FOperacion, _Caja, _Folio, _Consecutivo, _Clave)
        frmConRep.ShowDialog()
        Cursor = Cursors.Default
    End Sub
    Private Sub CapturaRemision()
        Cursor = Cursors.WaitCursor
        If _TipoMovimientoCaja = 2 Then
            If CType(Grid.Item(Grid.CurrentRowIndex, 20), Short) = 5 Then
                If _FolioAtt <> 0 And _AñoAtt <> 0 Then
                    Dim oRemisionManual As New LiquidacionPortatil.frmRemisionManual(_FolioAtt, _AñoAtt, 0, New DataTable, New DataTable, 0)
                    oRemisionManual.ShowDialog()
                End If
            Else
                MessageBox.Show("La captura de remisiones aplica únicamente para liquidaciones portátil.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("El registro seleccionado no es un movimiento de liquidación.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub cmbCelula_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCelula.SelectedIndexChanged
        If cmbCelula.SelectedIndex <> -1 And _ListaCargada Then
            'Filtro()
            CargaLista2()
        End If
    End Sub

End Class