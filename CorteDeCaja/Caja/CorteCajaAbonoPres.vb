'Proposito : Pantalla para consulta del corte de caja de los prestamos comisionistas
'Autor : Claudia García
'FCreacion : 24 de Enero del 2012

'Option Strict On

Imports System.Data.SqlClient
Imports System.Data

Public Class CorteCajaAbonoPres
    Inherits System.Windows.Forms.Form

    Private dtIngresos As New DataTable()
    Private dtFichasDeposito As New DataTable()

    Private dtCaja As New DataTable()
    Private daSelect As New SqlDataAdapter()
    Private rdrSelect As SqlDataReader
    Private dtFichaEfectivo As New DataTable()

    Private Total As Decimal
    Private TotalAplicaciones As Decimal
    Private strUsuario As String
    Private strUsuarioConsulta As String
    Private VGN_FolioCorte As Integer
    Private VGM_Diferencia As Decimal
    Private VGS_Status As String
    Private strStatus As String
    Private VGN_FolioFicha As Integer
    Private VGN_MontoAplicadoFicha As Decimal
    Private blnAgregarAlCorte As Boolean

    Public blnAdministrador As Boolean

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
    Friend WithEvents imgIconos As System.Windows.Forms.ImageList
    Friend WithEvents tlbCorteCaja As System.Windows.Forms.ToolBar
    Friend WithEvents btnAgrergar As System.Windows.Forms.ToolBarButton
    Public WithEvents btnGuardar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificarStatus As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtFechaOperacion As DevExpress.XtraEditors.DateEdit
    Friend WithEvents lblFolioCorte As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents lblCajaCmb As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents grdIngresos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdcComisionista As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdFichaDeposito As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFichasDeposito As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdcFichaDeposito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcNombre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcImporte As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents lblDiferencia As System.Windows.Forms.Label
    Friend WithEvents mnuFichasDeposito As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents grdFichaEfectivo As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFichaEfectivo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository3 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CorteCajaAbonoPres))
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        Me.lblCajaCmb = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.tlbCorteCaja = New System.Windows.Forms.ToolBar()
        Me.btnAgrergar = New System.Windows.Forms.ToolBarButton()
        Me.btnGuardar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.btnModificarStatus = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtFechaOperacion = New DevExpress.XtraEditors.DateEdit()
        Me.lblFolioCorte = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.grdIngresos = New DevExpress.XtraGrid.GridControl()
        Me.mnuFichasDeposito = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdcComisionista = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcNombre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcImporte = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdFichaDeposito = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwFichasDeposito = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdcFichaDeposito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblDiferencia = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grdFichaEfectivo = New DevExpress.XtraGrid.GridControl()
        Me.vwFichaEfectivo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository3 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.dtFechaOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFichaDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwFichasDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdFichaEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwFichaEfectivo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgIconos
        '
        Me.imgIconos.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgIconos.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        '
        'cmbCaja
        '
        Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaja.Location = New System.Drawing.Point(832, 8)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(80, 21)
        Me.cmbCaja.TabIndex = 48
        '
        'lblCajaCmb
        '
        Me.lblCajaCmb.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajaCmb.Location = New System.Drawing.Point(788, 12)
        Me.lblCajaCmb.Name = "lblCajaCmb"
        Me.lblCajaCmb.Size = New System.Drawing.Size(40, 24)
        Me.lblCajaCmb.TabIndex = 51
        Me.lblCajaCmb.Text = "Caja:"
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.SystemColors.Control
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.ForeColor = System.Drawing.Color.Crimson
        Me.lblCaja.Location = New System.Drawing.Point(888, 5)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(120, 23)
        Me.lblCaja.TabIndex = 50
        Me.lblCaja.Text = "Caja : 1"
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tlbCorteCaja
        '
        Me.tlbCorteCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlbCorteCaja.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgrergar, Me.btnGuardar, Me.ToolBarButton2, Me.btnModificarStatus, Me.ToolBarButton1, Me.btnImprimir, Me.btnActualizar, Me.btnConsultar, Me.btnSalir})
        Me.tlbCorteCaja.ButtonSize = New System.Drawing.Size(85, 40)
        Me.tlbCorteCaja.DropDownArrows = True
        Me.tlbCorteCaja.ImageList = Me.imgIconos
        Me.tlbCorteCaja.Name = "tlbCorteCaja"
        Me.tlbCorteCaja.ShowToolTips = True
        Me.tlbCorteCaja.Size = New System.Drawing.Size(1016, 44)
        Me.tlbCorteCaja.TabIndex = 49
        '
        'btnAgrergar
        '
        Me.btnAgrergar.ImageIndex = 0
        Me.btnAgrergar.Text = "Agregar "
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ImageIndex = 6
        Me.btnGuardar.Text = "Guardar"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnModificarStatus
        '
        Me.btnModificarStatus.Enabled = False
        Me.btnModificarStatus.ImageIndex = 0
        Me.btnModificarStatus.Text = "Modificar Status"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.ImageIndex = 3
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnActualizar
        '
        Me.btnActualizar.Enabled = False
        Me.btnActualizar.ImageIndex = 0
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnConsultar
        '
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.ImageIndex = 7
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 4
        Me.btnSalir.Text = "Regresar"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtEmpresa, Me.cboEmpresa, Me.Label5, Me.dtFechaOperacion, Me.lblFolioCorte, Me.Label3})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1016, 36)
        Me.Panel1.TabIndex = 52
        '
        'txtEmpresa
        '
        Me.txtEmpresa.Cursor = System.Windows.Forms.Cursors.No
        Me.txtEmpresa.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmpresa.Location = New System.Drawing.Point(86, 6)
        Me.txtEmpresa.Name = "txtEmpresa"
        Me.txtEmpresa.ReadOnly = True
        Me.txtEmpresa.Size = New System.Drawing.Size(322, 21)
        Me.txtEmpresa.TabIndex = 1
        Me.txtEmpresa.Text = "Gas Metropolitano S.A de C.V."
        '
        'cboEmpresa
        '
        Me.cboEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmpresa.Location = New System.Drawing.Point(87, 6)
        Me.cboEmpresa.Name = "cboEmpresa"
        Me.cboEmpresa.Size = New System.Drawing.Size(210, 21)
        Me.cboEmpresa.TabIndex = 44
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(-7, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 16)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Empresa :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtFechaOperacion
        '
        Me.dtFechaOperacion.DateTime = New Date(2005, 6, 3, 0, 0, 0, 0)
        Me.dtFechaOperacion.Location = New System.Drawing.Point(480, 6)
        Me.dtFechaOperacion.Name = "dtFechaOperacion"
        Me.dtFechaOperacion.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.dtFechaOperacion.Size = New System.Drawing.Size(96, 21)
        Me.dtFechaOperacion.TabIndex = 2
        '
        'lblFolioCorte
        '
        Me.lblFolioCorte.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFolioCorte.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioCorte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFolioCorte.Location = New System.Drawing.Point(820, 0)
        Me.lblFolioCorte.Name = "lblFolioCorte"
        Me.lblFolioCorte.Size = New System.Drawing.Size(192, 32)
        Me.lblFolioCorte.TabIndex = 31
        Me.lblFolioCorte.Text = "Folio Corte :"
        Me.lblFolioCorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(424, 8)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 16)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Fecha :"
        '
        'Label4
        '
        Me.Label4.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label4.BackColor = System.Drawing.Color.PapayaWhip
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(0, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label4.Size = New System.Drawing.Size(552, 21)
        Me.Label4.TabIndex = 53
        Me.Label4.Text = "I N G R E S O S     "
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdIngresos
        '
        Me.grdIngresos.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdIngresos.BackColor = System.Drawing.Color.Khaki
        Me.grdIngresos.ContextMenu = Me.mnuFichasDeposito
        Me.grdIngresos.EditorsRepository = Me.PersistentRepository1
        Me.grdIngresos.ForeColor = System.Drawing.Color.Green
        Me.grdIngresos.Location = New System.Drawing.Point(0, 101)
        Me.grdIngresos.MainView = Me.GridView8
        Me.grdIngresos.Name = "grdIngresos"
        Me.grdIngresos.Size = New System.Drawing.Size(552, 515)
        Me.grdIngresos.TabIndex = 54
        Me.grdIngresos.Text = "GridControl2"
        '
        'mnuFichasDeposito
        '
        Me.mnuFichasDeposito.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Desgloce"
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit1.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'GridView8
        '
        Me.GridView8.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.GridView8.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.grdcComisionista, Me.grdcNombre, Me.grdcImporte})
        Me.GridView8.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.GridView8.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Importe", Me.grdcImporte, "{0:c}")})
        Me.GridView8.Name = "GridView8"
        Me.GridView8.ViewOptions = (((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'grdcComisionista
        '
        Me.grdcComisionista.Caption = "Comisionista"
        Me.grdcComisionista.FieldName = "Cliente"
        Me.grdcComisionista.Name = "grdcComisionista"
        Me.grdcComisionista.VisibleIndex = 0
        Me.grdcComisionista.Width = 65
        '
        'grdcNombre
        '
        Me.grdcNombre.Caption = "Nombre"
        Me.grdcNombre.FieldName = "Nombre"
        Me.grdcNombre.Name = "grdcNombre"
        Me.grdcNombre.VisibleIndex = 1
        Me.grdcNombre.Width = 406
        '
        'grdcImporte
        '
        Me.grdcImporte.Caption = "Importe"
        Me.grdcImporte.FieldName = "Importe"
        Me.grdcImporte.Name = "grdcImporte"
        Me.grdcImporte.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcImporte.VisibleIndex = 2
        Me.grdcImporte.Width = 100
        '
        'grdFichaDeposito
        '
        Me.grdFichaDeposito.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdFichaDeposito.EditorsRepository = Me.PersistentRepository2
        Me.grdFichaDeposito.Location = New System.Drawing.Point(552, 320)
        Me.grdFichaDeposito.MainView = Me.vwFichasDeposito
        Me.grdFichaDeposito.Name = "grdFichaDeposito"
        Me.grdFichaDeposito.Size = New System.Drawing.Size(464, 296)
        Me.grdFichaDeposito.TabIndex = 56
        Me.grdFichaDeposito.Text = "GridControl2"
        '
        'PersistentRepository2
        '
        Me.PersistentRepository2.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2})
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit2.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwFichasDeposito
        '
        Me.vwFichasDeposito.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwFichasDeposito.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.grdcFichaDeposito, Me.grdcTotal})
        Me.vwFichasDeposito.DefaultEdit = Me.RepositoryItemTextEdit2
        Me.vwFichasDeposito.Name = "vwFichasDeposito"
        Me.vwFichasDeposito.ViewOptions = ((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'grdcFichaDeposito
        '
        Me.grdcFichaDeposito.Caption = "Ficha de depósito"
        Me.grdcFichaDeposito.FieldName = "Tipo"
        Me.grdcFichaDeposito.Name = "grdcFichaDeposito"
        Me.grdcFichaDeposito.VisibleIndex = 0
        Me.grdcFichaDeposito.Width = 150
        '
        'grdcTotal
        '
        Me.grdcTotal.Caption = "Total"
        Me.grdcTotal.FieldName = "Total"
        Me.grdcTotal.FormatString = "$#,#.00"
        Me.grdcTotal.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcTotal.Name = "grdcTotal"
        Me.grdcTotal.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcTotal.SummaryItem.FieldName = "VentasContado"
        Me.grdcTotal.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcTotal.VisibleIndex = 1
        Me.grdcTotal.Width = 150
        '
        'lblDiferencia
        '
        Me.lblDiferencia.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblDiferencia.BackColor = System.Drawing.Color.White
        Me.lblDiferencia.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferencia.ForeColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(0, Byte), CType(0, Byte))
        Me.lblDiferencia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDiferencia.Location = New System.Drawing.Point(3, 613)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(1013, 32)
        Me.lblDiferencia.TabIndex = 57
        Me.lblDiferencia.Text = "Diferencia"
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte))
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(552, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(464, 21)
        Me.Label2.TabIndex = 58
        Me.Label2.Text = "Fichas de depósito de EFECTIVO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdFichaEfectivo
        '
        Me.grdFichaEfectivo.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdFichaEfectivo.ContextMenu = Me.mnuFichasDeposito
        Me.grdFichaEfectivo.EditorsRepository = Me.PersistentRepository3
        Me.grdFichaEfectivo.Location = New System.Drawing.Point(552, 101)
        Me.grdFichaEfectivo.MainView = Me.vwFichaEfectivo
        Me.grdFichaEfectivo.Name = "grdFichaEfectivo"
        Me.grdFichaEfectivo.Size = New System.Drawing.Size(472, 195)
        Me.grdFichaEfectivo.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdFichaEfectivo.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Lavender, System.Drawing.Color.MediumSlateBlue))
        Me.grdFichaEfectivo.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MistyRose, System.Drawing.Color.Firebrick))
        Me.grdFichaEfectivo.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MistyRose, System.Drawing.Color.Firebrick))
        Me.grdFichaEfectivo.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(58, Byte), CType(110, Byte), CType(165, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdFichaEfectivo.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.DarkBlue))
        Me.grdFichaEfectivo.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.SteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MistyRose, System.Drawing.Color.Firebrick))
        Me.grdFichaEfectivo.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.SteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(192, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MistyRose, System.Drawing.Color.Firebrick))
        Me.grdFichaEfectivo.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Lavender, System.Drawing.Color.MediumSlateBlue))
        Me.grdFichaEfectivo.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MistyRose, System.Drawing.Color.Firebrick))
        Me.grdFichaEfectivo.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MistyRose, System.Drawing.Color.Firebrick))
        Me.grdFichaEfectivo.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", ((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichaEfectivo.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichaEfectivo.TabIndex = 59
        Me.grdFichaEfectivo.Text = "GridControl1"
        '
        'vwFichaEfectivo
        '
        Me.vwFichaEfectivo.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwFichaEfectivo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn4, Me.GridColumn5})
        Me.vwFichaEfectivo.DefaultEdit = Me.RepositoryItemTextEdit3
        Me.vwFichaEfectivo.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Me.GridColumn5, "{0:c}")})
        Me.vwFichaEfectivo.Name = "vwFichaEfectivo"
        Me.vwFichaEfectivo.PrintOptions = (((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllDetails) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines)
        Me.vwFichaEfectivo.ViewOptions = (((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "Tipo"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Tipo"
        Me.GridColumn4.FieldName = "Concepto"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 140
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Total"
        Me.GridColumn5.FieldName = "MontoTotal"
        Me.GridColumn5.FormatString = "$#,#.00"
        Me.GridColumn5.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn5.SummaryItem.FieldName = "Total"
        Me.GridColumn5.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 150
        '
        'PersistentRepository3
        '
        Me.PersistentRepository3.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit3})
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit3.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'Label1
        '
        Me.Label1.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.Label1.BackColor = System.Drawing.Color.LavenderBlush
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(552, 296)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(464, 21)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Fichas de depósito del corte de caja"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CorteCajaAbonoPres
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1016, 646)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdFichaEfectivo, Me.lblDiferencia, Me.grdFichaDeposito, Me.grdIngresos, Me.Label4, Me.Panel1, Me.cmbCaja, Me.lblCajaCmb, Me.lblCaja, Me.tlbCorteCaja, Me.Label2, Me.Label1})
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CorteCajaAbonoPres"
        Me.Text = "Corte de Caja Cobranza a Comisionistas"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtFechaOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFichaDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwFichasDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdFichaEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwFichaEfectivo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ActualizarEfectivo()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            dtFichaEfectivo.Clear()
        Catch

        End Try
        Try
            'Fichas de depósito en EFECTIVO
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSFichaDepositoEfectivoPrestamos"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = VGS_FOperacion
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoCorte", SqlDbType.Int).Value = VGN_TipoCorte

            End With

            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtFichaEfectivo)

            grdFichaEfectivo.DataSource = dtFichaEfectivo
            vwFichaEfectivo.ExpandAllGroups()
        Catch err As Exception
            MsgBox(err.Message)
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub


    Private Sub Bloquea()
        btnImprimir.Enabled = True
        btnSalir.Enabled = True
        btnAgrergar.Enabled = False
        btnGuardar.Enabled = False
        btnModificarStatus.Enabled = True
    End Sub

    Public Sub Entrar()
        'Se obtiene el Usuario Administrador
        cmdCommand.CommandType = CommandType.Text
        cmdCommand.CommandText = "Select Valor " & _
                                 "   From Parametro" & _
                                 "   Where Modulo=3 and Parametro='UsuarioAdministrador'"
        cmdCommand.Parameters.Clear()

        rdrSelect = cmdCommand.ExecuteReader
        If rdrSelect.Read() Then
            strUsuario = CType(rdrSelect("Valor"), String)
        End If
        rdrSelect.Close()

        'Se obtiene el Usuario Consulta
        cmdCommand.CommandType = CommandType.Text
        cmdCommand.CommandText = "Select Valor " & _
                                 "   From Parametro" & _
                                 "   Where Modulo=3 and Parametro='UsuarioConsulta'"
        cmdCommand.Parameters.Clear()

        rdrSelect = cmdCommand.ExecuteReader
        If rdrSelect.Read() Then
            strUsuarioConsulta = CType(rdrSelect("Valor"), String)
        End If
        rdrSelect.Close()

        'Si el usuario logueado es el adminitrador se activan los botones:
        'btnPorAutorizar,btnModificarStatus y la eleccion de las cajas
        'Para el usuario de consulta solo es la eleccion de las cajas

        If (Trim(strUsuario) <> Trim(dmModulo._Usuario)) And (Trim(strUsuarioConsulta) <> Trim(dmModulo._Usuario)) Then
            'de lo contrario se ocultan
            lblCajaCmb.Visible = False
            cmbCaja.Visible = False
            btnModificarStatus.Visible = False
            blnAdministrador = False
        Else
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSSelectCaja"
                daSelect.SelectCommand = cmdCommand
                daSelect.Fill(dtCaja)
            End With
            lblCajaCmb.Visible = True
            cmbCaja.Visible = True
            cmbCaja.DataSource = dtCaja
            cmbCaja.ValueMember = "Caja"
            cmbCaja.DisplayMember = "Descripcion"
            blnAdministrador = True
            If (Trim(strUsuarioConsulta) = Trim(dmModulo._Usuario)) Then
                btnModificarStatus.Visible = False
            End If
        End If


        VGN_TipoCorte = 0
        VGS_FOperacion = dtFechaOperacion.DateTime.ToShortDateString


        Me.ShowDialog()
    End Sub

    Private Sub CargaFichas()
        Try
            dtFichasDeposito.Clear()
        Catch
        End Try
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSFichasDepositoCaja"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = VGS_FOperacion
            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtFichasDeposito)
        Catch e As Exception
        End Try
        grdFichaDeposito.DataSource = dtFichasDeposito

    End Sub

    Private Sub ConsultarCorte()

        Total = 0
        TotalAplicaciones = 0
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Dim frmConsultaCorte As New ConsultaCorte()
        frmConsultaCorte.Entrar()
        If frmConsultaCorte.txtFolioCorte.Text <> "0" Then
            dmModulo.VGS_FOperacion = frmConsultaCorte.dtFechaOperacion.DateTime.ToShortDateString
            dmModulo.VGN_Consecutivo = CType(frmConsultaCorte.txtFolioCorte.Text, Integer)
            dtFechaOperacion.DateTime = CType(dmModulo.VGS_FOperacion, DateTime)
            Me.btnAgrergar.Enabled = False
            Me.dtFechaOperacion.Enabled = False
            CargaCorte()
        End If
        frmConsultaCorte.Dispose()
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Sub CalculaMontos()
        Dim VLD_Total As Decimal
        Dim VLD_TotalFichas As Decimal

        VLD_Total = Total
        VLD_TotalFichas = CType(Me.grdcTotal.SummaryItem.SummaryValue, Decimal)

        TotalAplicaciones = VLD_TotalFichas
        VGM_Diferencia = VLD_Total - TotalAplicaciones

        lblDiferencia.Text = "Diferencia : " + VGM_Diferencia.ToString("C")

        If Total > 0 Then
            btnGuardar.Enabled = True
        End If
    End Sub

    Private Sub CargaCorte()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Ingresos()
        CargaFichas()
        CalculaMontos()

        btnImprimir.Enabled = True
        btnActualizar.Enabled = True
        Me.btnAgrergar.Enabled = False
        If blnAdministrador Then
            Me.dtFechaOperacion.Enabled = True
        Else
            Me.dtFechaOperacion.Enabled = False
        End If
        lblFolioCorte.Text = "Folio Corte : " + CType(dmModulo.VGN_Consecutivo, String)
        lblFolioCorte.Visible = True

        If Trim(VGS_Status) = "CERRADO" Then
            Bloquea()
        End If
        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub

    Private Function ExisteCorteCaja() As Boolean
        Dim dr As SqlDataReader
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSExisteCorteCaja"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = VGS_FOperacion
            cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = VGN_TipoCorte
            'cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Direction = ParameterDirection.Output
            'cmdCommand.Parameters.Add("@Status", SqlDbType.Char).Direction = ParameterDirection.Output
            dr = cmdCommand.ExecuteReader
            If dr.Read() Then
                VGN_FolioCorte = CType(dr("Consecutivo"), Integer)
                VGS_Status = CType(dr("Status"), String)
            End If
            dr.Close()

        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try

        If VGN_FolioCorte <> 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Private Sub InsertaCorte(ByVal Alta As Boolean)
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSCorteCajaAltaModifica"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = VGN_TipoCorte
            If Alta Then
                cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Direction = ParameterDirection.Output
            Else
                cmdCommand.Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
                cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                cmdCommand.Parameters.Add("@TotalIngresos", SqlDbType.Money).Value = Total
                cmdCommand.Parameters.Add("@TotalAplicaciones", SqlDbType.Money).Value = TotalAplicaciones
                cmdCommand.Parameters.Add("@ImporteContado", SqlDbType.Money).Value = CType(grdcImporte.SummaryItem.SummaryValue, Decimal)
                cmdCommand.Parameters.Add("@ImporteCredito", SqlDbType.Money).Value = 0
            End If
            cmdCommand.ExecuteNonQuery()
            VGN_FolioCorte = CType(cmdCommand.Parameters("@Consecutivo").Value, Integer)
        Catch e As Exception
            MessageBox.Show(e.Message)
        End Try
        dmModulo.VGS_FOperacion = CType(dtFechaOperacion.DateTime.ToShortDateString, String)
        dmModulo.VGN_Consecutivo = VGN_FolioCorte
        dmModulo.VGN_TipoCorte = VGN_TipoCorte
        lblFolioCorte.Text = "Folio Corte : " + CType(dmModulo.VGN_Consecutivo, String)
    End Sub

    Private Sub Ingresos()
        cmdCommand.Parameters.Clear()
        cmdCommand.CommandTimeout = 0
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSIngresosCorteCajaPrestamos"
        cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
        cmdCommand.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = dtFechaOperacion.DateTime.Date

        Try
            cmdCommand.ExecuteNonQuery()
            daSelect.SelectCommand = cmdCommand
            Try
                dtIngresos.Clear()
                daSelect.Fill(dtIngresos)

                grdIngresos.DataSource = dtIngresos
                Total = CType(Me.grdcImporte.SummaryItem.SummaryValue, Decimal)
            Catch
                Total = 0
            End Try



        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Sub

    Private Sub Agregar()
        Me.lblCaja.Visible = True
        Me.lblFolioCorte.Visible = True
        Me.cboEmpresa.Enabled = False
        Me.btnAgrergar.Enabled = False
        Me.btnConsultar.Enabled = False
        Me.btnGuardar.Enabled = False
        Me.btnImprimir.Enabled = False
        Me.btnSalir.Enabled = False
        Me.dtFechaOperacion.Enabled = False
        InsertaCorte(True)
    End Sub

    'Si el usuario logueado es el adminitrador el numero de caja depende del cmbCaja
    'sino del dmModulo.VGN_Caja
    Private Function VerificaUsuario() As Integer
        Dim intCaja As Integer
        If blnAdministrador Then
            intCaja = CType(cmbCaja.SelectedValue, Integer)
        Else
            intCaja = dmModulo.VGN_Caja
        End If
        Return intCaja
    End Function

    'Obtiene el ststus del corte de caja de la tabla CorteCajaF
    Private Sub VerificarStatus()
        With cmdCommand
            .Parameters.Clear()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spSSCorteCajaF"
            .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            .Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
            .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            .Parameters.Add("@Accion", SqlDbType.Int).Value = 1  'Muestra el Status del Corte
        End With
        drLeer = cmdCommand.ExecuteReader
        If drLeer.Read() Then
            strStatus = CType(drLeer("Status"), String)
        End If
        drLeer.Close()
    End Sub

    'Se realiza el cambio de Status del corte caja en la tabla CorteCajaF
    Private Sub CambiarStatus(ByVal StatusUpdate As String)
        Try
            With cmdCommand
                .Parameters.Clear()
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSCorteCajaF"
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                .Parameters.Add("@Accion", SqlDbType.Int).Value = 2  'Cambia el Status CAPTURADO-CERRADO o CERRADO-CAPTURADO
                .Parameters.Add("@Status", SqlDbType.Char).Value = StatusUpdate
                .ExecuteNonQuery()
            End With
        Catch er As Exception
            MsgBox(er.Message)
        End Try
    End Sub

    Private Sub AgregarFicha(ByVal TipoFicha As Integer, ByVal TipoFichaDescripcion As String, ByVal MovimientoCaja As String, ByVal Monto As Decimal, ByVal FFicha As DateTime, ByVal Desgloce As Boolean)
        Dim frmFichaDeposito_ed As FichaDeposito_ed = New FichaDeposito_ed()
        frmFichaDeposito_ed.EmpreContableOriginal = True
        frmFichaDeposito_ed.Entrar(TipoFicha, TipoFichaDescripcion, MovimientoCaja, Monto, FFicha, Desgloce)
        VGN_FolioFicha = CType(frmFichaDeposito_ed.VGN_Folio, Integer)
        VGN_MontoAplicadoFicha = CType(frmFichaDeposito_ed.txtMonto.Text, Decimal)
        Me.blnAgregarAlCorte = CType(frmFichaDeposito_ed.blnAgregarAlCorte, Boolean)
        frmFichaDeposito_ed.Dispose()
    End Sub

    Private Sub RelacionaFichaCorte(ByVal Folio As Integer)
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSInsertaCorteCajaFichaDeposito"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                .ExecuteNonQuery()
            End With
        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Sub

    Private Sub AgregaFichaDetalle(ByVal Folio As Integer, ByVal TipoFicha As Integer, ByVal Monto As Decimal)
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSInsertaFichaDepositoDetalle"
                .Parameters.Clear()
                .Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha
                .Parameters.Add("@Monto", SqlDbType.Money).Value = Monto
                .ExecuteNonQuery()
            End With
        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Sub

    Private Sub AgregarFichaCorte(ByVal TipoFicha As Integer, ByVal TipoFichaDescripcion As String, ByVal MovimientoCaja As String, ByVal Monto As Decimal, ByVal FFicha As String, ByVal Desgloce As Boolean)
        'Agrega la ficha al corte
        AgregarFicha(TipoFicha, TipoFichaDescripcion, MovimientoCaja, Monto, CType(FFicha, Date), Desgloce)

        If VGN_FolioFicha <> 0 Then 'Esto quiere decir que si se inserto una ficha de depósito
            'La relaciona al corte correspondiente
            RelacionaFichaCorte(VGN_FolioFicha)
            'Agrega el detalle de la ficha que inserto
            AgregaFichaDetalle(VGN_FolioFicha, TipoFicha, VGN_MontoAplicadoFicha)
            'Actualiza la información del corte de caja
            CargaFichas()
        End If
    End Sub

    Private Sub CorteCajaAbonoPres_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblCaja.Text = "Caja : " & VerificaUsuario().ToString
        Me.lblFolioCorte.Visible = False
        dtFechaOperacion.DateTime = Now

        txtEmpresa.Text = dmModulo._NombreEmpresaContable
    End Sub

    Private Sub tlbCorteCaja_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbCorteCaja.ButtonClick
        VGS_FOperacion = dtFechaOperacion.DateTime.ToShortDateString
        Select Case RTrim(e.Button.Text)
            Case "Agregar"
                If Not (ExisteCorteCaja()) Then
                    If Me.blnAdministrador = False Then
                        If MessageBox.Show("¿Desea agregar el corte para la caja " + VerificaUsuario().ToString + " y fecha " + dtFechaOperacion.DateTime.ToShortDateString + " ?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                            Agregar()
                            Ingresos()
                            ActualizarEfectivo()
                        End If
                    Else
                        MessageBox.Show("No existe corte de caja  " + VerificaUsuario().ToString + " y fecha " + dtFechaOperacion.DateTime.ToShortDateString + " ?", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    If MessageBox.Show("YA EXISTE el corte de caja para el día " & dtFechaOperacion.DateTime.ToShortDateString & " del tipo de corte """ & "Prestamos" & """ con el Folio = " & Trim(CType(VGN_FolioCorte, String)) & Chr(13) & " ¿Desea cargarlo ?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        dmModulo.VGS_FOperacion = CType(dtFechaOperacion.DateTime.ToShortDateString, String)
                        dmModulo.VGN_Consecutivo = VGN_FolioCorte
                        lblFolioCorte.Text = "Folio Corte : " + CType(dmModulo.VGN_Consecutivo, String)
                        CargaCorte()
                        ActualizarEfectivo()
                    End If
                End If
                Me.lblCaja.Text = "Caja : " & VerificaUsuario().ToString
                'Case "Fichas"
                '    Dim frmMovimientoCajaDesglozados As New MovimientosCajaDesglozados()
                '    frmMovimientoCajaDesglozados.Entrar(0, "Prestamos")
                '    frmMovimientoCajaDesglozados.Dispose()
                '    CargaFichas()
                '    CalculaMontos()
            Case "Guardar"
                If VGM_Diferencia <> 0 Then
                    MessageBox.Show("El corte de caja no ha cuadrado, no puede GUARDAR.", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    If MessageBox.Show("¿Desea guardar los datos del corte de caja ? ", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        CambiarStatus("CERRADO")
                        InsertaCorte(False)
                        Bloquea()
                    End If
                End If
            Case "Modificar Status"
                VerificarStatus()
                If Not Trim(strStatus) = "CERRADO" Then
                    MessageBox.Show("El corte ya esta CAPTURADO, verifique.", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If MessageBox.Show("¿Desea cambiar el status del corte de " + Trim(strStatus) + " a CAPTURADO?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    CambiarStatus("CAPTURADO")
                    btnGuardar.Enabled = True
                    btnModificarStatus.Enabled = False
                End If
            Case "Imprimir"
                Dim frmImprimeCorteCaja As ViewReport = New ViewReport()
                frmImprimeCorteCaja.CorteCajaPrestamos(dmModulo._NombreEmpresaContable, dtFechaOperacion.DateTime.ToShortDateString, VerificaUsuario(), dmModulo.VGN_Consecutivo, dmModulo.VGN_TipoCorte)
            Case "Consultar"
                ConsultarCorte()
            Case "Actualizar"
                If Not (ExisteCorteCaja()) Then
                    If Me.blnAdministrador = False Then
                        If MessageBox.Show("¿Desea agregar el corte para la caja " + VerificaUsuario().ToString + " y fecha " + dtFechaOperacion.DateTime.ToShortDateString + " ?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                            Agregar()
                            Ingresos()
                        End If
                    Else
                        MessageBox.Show("No existe corte de caja  " + VerificaUsuario().ToString + " y fecha " + dtFechaOperacion.DateTime.ToShortDateString + " ?", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                    End If
                Else
                    If MessageBox.Show("YA EXISTE el corte de caja para el día " & dtFechaOperacion.DateTime.ToShortDateString & " del tipo de corte """ & "Prestamos" & """ con el Folio = " & Trim(CType(VGN_FolioCorte, String)) & Chr(13) & " ¿Desea cargarlo ?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        dmModulo.VGS_FOperacion = CType(dtFechaOperacion.DateTime.ToShortDateString, String)
                        dmModulo.VGN_Consecutivo = VGN_FolioCorte
                        lblFolioCorte.Text = "Folio Corte : " + CType(dmModulo.VGN_Consecutivo, String)
                        CargaCorte()
                    End If
                End If
                Me.lblCaja.Text = "Caja : " & VerificaUsuario().ToString
            Case "Regresar"
                Me.Close()
        End Select
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Try
            If Total - TotalAplicaciones > 0 Then
                AgregarFichaCorte(Integer.Parse(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Tipo").ToString().Trim), _
                                  vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Concepto").ToString(), _
                                  vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Concepto").ToString(), _
                                  Decimal.Parse(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("MontoTotal").ToString().Trim), _
                                  dtFechaOperacion.DateTime.ToString(), True)
            Else
                MessageBox.Show("¡No es posible realizar la operación porque el monto de la ficha es 0!", "Fichas de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch
        End Try
        ActualizarEfectivo()
        CalculaMontos()
    End Sub
End Class
