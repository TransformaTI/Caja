Imports System.Data
Imports System.Data.SqlClient
Public Class ComprobanteServicio
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private dtSelect As New DataTable()
    Private dtFichas As New DataTable()
    Private dtPlomos As New DataTable()
    Private daSelect As New SqlDataAdapter()
    Private Comp As Integer
    Private dtCaja As New DataTable()
    Public blnAdministrador As Boolean
    Private CorteCajaCerrado As Boolean

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgMain As System.Windows.Forms.ImageList
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdComprobante As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwComprobante As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Comprobante As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Folio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CuentaBanco As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FComprobante As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Machimbradora As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Proveedor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FAlta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents grdFichasComprobante As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFichasComprobante As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TipoFicha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Ficha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Monto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Caja As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FFicha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FAltaFicha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents PersistentRepository3 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents grdPlomos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwPlomos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NumeroPlomo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MontoPlomo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents lblCajaCmb As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents lblPeriodo As System.Windows.Forms.Label
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents deFFinal As DevExpress.XtraEditors.DateEdit
    Friend WithEvents deFInicial As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Cerrado As DevExpress.XtraGrid.Columns.GridColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ComprobanteServicio))
        Dim ColumnFilterInfo1 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo2 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo3 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo4 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo5 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo6 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo7 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo8 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo9 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo10 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo11 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo12 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo13 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo14 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo15 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo16 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo17 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo18 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdPlomos = New DevExpress.XtraGrid.GridControl()
        Me.vwPlomos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NumeroPlomo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MontoPlomo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.grdFichasComprobante = New DevExpress.XtraGrid.GridControl()
        Me.vwFichasComprobante = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TipoFicha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Ficha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Monto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Caja = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FFicha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FAltaFicha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdComprobante = New DevExpress.XtraGrid.GridControl()
        Me.vwComprobante = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Comprobante = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Folio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CuentaBanco = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FComprobante = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Machimbradora = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Proveedor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FAlta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Cerrado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository3 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        Me.lblCajaCmb = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.deFInicial = New DevExpress.XtraEditors.DateEdit()
        Me.deFFinal = New DevExpress.XtraEditors.DateEdit()
        Me.lblPeriodo = New System.Windows.Forms.Label()
        Me.lblA = New System.Windows.Forms.Label()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.grdPlomos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwPlomos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.grdFichasComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwFichasComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.deFFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 4
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Text = "Agregar"
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageIndex = 9
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Text = "Eliminar"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 42)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(936, 3)
        Me.Splitter1.TabIndex = 6
        Me.Splitter1.TabStop = False
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 5
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        '
        'imgMain
        '
        Me.imgMain.ImageStream = CType(resources.GetObject("imgMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMain.TransparentColor = System.Drawing.Color.Transparent
        Me.imgMain.Images.SetKeyName(0, "")
        Me.imgMain.Images.SetKeyName(1, "")
        Me.imgMain.Images.SetKeyName(2, "")
        Me.imgMain.Images.SetKeyName(3, "")
        Me.imgMain.Images.SetKeyName(4, "")
        Me.imgMain.Images.SetKeyName(5, "")
        Me.imgMain.Images.SetKeyName(6, "")
        Me.imgMain.Images.SetKeyName(7, "")
        Me.imgMain.Images.SetKeyName(8, "")
        Me.imgMain.Images.SetKeyName(9, "")
        Me.imgMain.Images.SetKeyName(10, "")
        Me.imgMain.Images.SetKeyName(11, "")
        Me.imgMain.Images.SetKeyName(12, "")
        Me.imgMain.Images.SetKeyName(13, "")
        Me.imgMain.Images.SetKeyName(14, "")
        Me.imgMain.Images.SetKeyName(15, "")
        Me.imgMain.Images.SetKeyName(16, "")
        Me.imgMain.Images.SetKeyName(17, "")
        Me.imgMain.Images.SetKeyName(18, "")
        Me.imgMain.Images.SetKeyName(19, "")
        Me.imgMain.Images.SetKeyName(20, "")
        Me.imgMain.Images.SetKeyName(21, "")
        Me.imgMain.Images.SetKeyName(22, "")
        Me.imgMain.Images.SetKeyName(23, "")
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
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnEliminar, Me.ToolBarButton1, Me.btnImprimir, Me.btnActualizar, Me.btnSalir})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(60, 40)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgMain
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(936, 42)
        Me.ToolBar1.TabIndex = 4
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 6
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Text = "Modificar"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImprimir
        '
        Me.btnImprimir.ImageIndex = 11
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Text = "Imprimir"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Panel4)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 398)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(936, 168)
        Me.Panel1.TabIndex = 5
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.grdPlomos)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(752, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(184, 168)
        Me.Panel4.TabIndex = 1
        '
        'grdPlomos
        '
        Me.grdPlomos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPlomos.EditorsRepository = Me.PersistentRepository1
        Me.grdPlomos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPlomos.Location = New System.Drawing.Point(0, 0)
        Me.grdPlomos.MainView = Me.vwPlomos
        Me.grdPlomos.Name = "grdPlomos"
        Me.grdPlomos.Size = New System.Drawing.Size(184, 168)
        Me.grdPlomos.TabIndex = 41
        Me.grdPlomos.Text = "GridControl1"
        '
        'vwPlomos
        '
        Me.vwPlomos.BehaviorOptions = CType(((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.MultiSelect) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwPlomos.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.vwPlomos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NumeroPlomo, Me.MontoPlomo})
        Me.vwPlomos.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwPlomos.GroupPanelText = "Fichas para asignar al Comprobante"
        Me.vwPlomos.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Monto", Me.MontoPlomo, "{0:c}")})
        Me.vwPlomos.Name = "vwPlomos"
        Me.vwPlomos.VertScrollTipFieldName = Nothing
        Me.vwPlomos.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'NumeroPlomo
        '
        Me.NumeroPlomo.Caption = "Plomo"
        Me.NumeroPlomo.FieldName = "NumeroPlomo"
        Me.NumeroPlomo.FilterInfo = ColumnFilterInfo1
        Me.NumeroPlomo.Name = "NumeroPlomo"
        Me.NumeroPlomo.VisibleIndex = 0
        '
        'MontoPlomo
        '
        Me.MontoPlomo.Caption = "Monto"
        Me.MontoPlomo.FieldName = "Monto"
        Me.MontoPlomo.FilterInfo = ColumnFilterInfo2
        Me.MontoPlomo.FormatString = "$#,#.00"
        Me.MontoPlomo.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.MontoPlomo.Name = "MontoPlomo"
        Me.MontoPlomo.SummaryItem.DisplayFormat = "{0:c}"
        Me.MontoPlomo.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.MontoPlomo.VisibleIndex = 1
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.grdFichasComprobante)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(752, 168)
        Me.Panel3.TabIndex = 0
        '
        'grdFichasComprobante
        '
        Me.grdFichasComprobante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFichasComprobante.EditorsRepository = Me.PersistentRepository1
        Me.grdFichasComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdFichasComprobante.Location = New System.Drawing.Point(0, 0)
        Me.grdFichasComprobante.MainView = Me.vwFichasComprobante
        Me.grdFichasComprobante.Name = "grdFichasComprobante"
        Me.grdFichasComprobante.Size = New System.Drawing.Size(752, 168)
        Me.grdFichasComprobante.TabIndex = 40
        Me.grdFichasComprobante.Text = "GridControl1"
        '
        'vwFichasComprobante
        '
        Me.vwFichasComprobante.BehaviorOptions = CType(((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.MultiSelect) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwFichasComprobante.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.vwFichasComprobante.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TipoFicha, Me.Ficha, Me.Monto, Me.Caja, Me.FFicha, Me.Status, Me.FAltaFicha})
        Me.vwFichasComprobante.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwFichasComprobante.GroupPanelText = "Fichas para asignar al Comprobante"
        Me.vwFichasComprobante.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Me.Monto, "{0:c}")})
        Me.vwFichasComprobante.Name = "vwFichasComprobante"
        Me.vwFichasComprobante.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'TipoFicha
        '
        Me.TipoFicha.Caption = "Tipo de Ficha"
        Me.TipoFicha.FieldName = "Tipo"
        Me.TipoFicha.FilterInfo = ColumnFilterInfo3
        Me.TipoFicha.GroupIndex = 0
        Me.TipoFicha.Name = "TipoFicha"
        '
        'Ficha
        '
        Me.Ficha.Caption = "Ficha"
        Me.Ficha.FieldName = "Folio"
        Me.Ficha.FilterInfo = ColumnFilterInfo4
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Options = CType((((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.[ReadOnly]) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm), DevExpress.XtraGrid.Columns.ColumnOptions)
        Me.Ficha.VisibleIndex = 0
        '
        'Monto
        '
        Me.Monto.Caption = "Monto"
        Me.Monto.FieldName = "Total"
        Me.Monto.FilterInfo = ColumnFilterInfo5
        Me.Monto.FormatString = "$#,#.00"
        Me.Monto.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.Monto.Name = "Monto"
        Me.Monto.Options = CType((((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.[ReadOnly]) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
            Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm), DevExpress.XtraGrid.Columns.ColumnOptions)
        Me.Monto.SummaryItem.DisplayFormat = "{0:c}"
        Me.Monto.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.Monto.VisibleIndex = 1
        '
        'Caja
        '
        Me.Caja.Caption = "Caja"
        Me.Caja.FieldName = "Caja"
        Me.Caja.FilterInfo = ColumnFilterInfo6
        Me.Caja.Name = "Caja"
        Me.Caja.VisibleIndex = 2
        '
        'FFicha
        '
        Me.FFicha.Caption = "Fecha Ficha"
        Me.FFicha.FieldName = "FFicha"
        Me.FFicha.FilterInfo = ColumnFilterInfo7
        Me.FFicha.Name = "FFicha"
        Me.FFicha.VisibleIndex = 3
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "Status"
        Me.Status.FilterInfo = ColumnFilterInfo8
        Me.Status.Name = "Status"
        Me.Status.VisibleIndex = 4
        '
        'FAltaFicha
        '
        Me.FAltaFicha.Caption = "Fecha Alta"
        Me.FAltaFicha.FieldName = "FAlta"
        Me.FAltaFicha.FilterInfo = ColumnFilterInfo9
        Me.FAltaFicha.Name = "FAltaFicha"
        Me.FAltaFicha.VisibleIndex = 5
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.grdComprobante)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 45)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(936, 353)
        Me.Panel2.TabIndex = 7
        '
        'grdComprobante
        '
        Me.grdComprobante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdComprobante.EditorsRepository = Me.PersistentRepository1
        Me.grdComprobante.Location = New System.Drawing.Point(0, 0)
        Me.grdComprobante.MainView = Me.vwComprobante
        Me.grdComprobante.Name = "grdComprobante"
        Me.grdComprobante.Size = New System.Drawing.Size(936, 353)
        Me.grdComprobante.TabIndex = 2
        '
        'vwComprobante
        '
        Me.vwComprobante.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwComprobante.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.vwComprobante.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Comprobante, Me.Folio, Me.Total, Me.CuentaBanco, Me.FComprobante, Me.Machimbradora, Me.Proveedor, Me.FAlta, Me.Cerrado})
        Me.vwComprobante.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwComprobante.GroupPanelText = "Comprobantes de Servicio"
        Me.vwComprobante.Name = "vwComprobante"
        Me.vwComprobante.VertScrollTipFieldName = Nothing
        Me.vwComprobante.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'Comprobante
        '
        Me.Comprobante.Caption = "Comprobante"
        Me.Comprobante.FieldName = "ComprobanteServicio"
        Me.Comprobante.FilterInfo = ColumnFilterInfo10
        Me.Comprobante.Name = "Comprobante"
        '
        'Folio
        '
        Me.Folio.Caption = "Folio Comprobante"
        Me.Folio.FieldName = "FolioComprobante"
        Me.Folio.FilterInfo = ColumnFilterInfo11
        Me.Folio.Name = "Folio"
        Me.Folio.VisibleIndex = 0
        '
        'Total
        '
        Me.Total.Caption = "Total"
        Me.Total.FieldName = "Total"
        Me.Total.FilterInfo = ColumnFilterInfo12
        Me.Total.FormatString = "$#,#.00"
        Me.Total.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.Total.Name = "Total"
        Me.Total.VisibleIndex = 1
        '
        'CuentaBanco
        '
        Me.CuentaBanco.Caption = "Cuenta Banco"
        Me.CuentaBanco.FieldName = "CuentaBanco"
        Me.CuentaBanco.FilterInfo = ColumnFilterInfo13
        Me.CuentaBanco.Name = "CuentaBanco"
        Me.CuentaBanco.VisibleIndex = 2
        '
        'FComprobante
        '
        Me.FComprobante.Caption = "Fecha Comprobante"
        Me.FComprobante.FieldName = "FComprobanteServicio"
        Me.FComprobante.FilterInfo = ColumnFilterInfo14
        Me.FComprobante.Name = "FComprobante"
        Me.FComprobante.VisibleIndex = 3
        '
        'Machimbradora
        '
        Me.Machimbradora.Caption = "Machimbradora"
        Me.Machimbradora.FieldName = "Machimbradora"
        Me.Machimbradora.FilterInfo = ColumnFilterInfo15
        Me.Machimbradora.Name = "Machimbradora"
        Me.Machimbradora.VisibleIndex = 4
        '
        'Proveedor
        '
        Me.Proveedor.Caption = "Proveedor"
        Me.Proveedor.FieldName = "Proveedor"
        Me.Proveedor.FilterInfo = ColumnFilterInfo16
        Me.Proveedor.Name = "Proveedor"
        Me.Proveedor.VisibleIndex = 5
        '
        'FAlta
        '
        Me.FAlta.Caption = "Fecha Alta"
        Me.FAlta.FieldName = "FAlta"
        Me.FAlta.FilterInfo = ColumnFilterInfo17
        Me.FAlta.Name = "FAlta"
        Me.FAlta.VisibleIndex = 6
        '
        'Cerrado
        '
        Me.Cerrado.Caption = "Cerrado"
        Me.Cerrado.FieldName = "Cerrado"
        Me.Cerrado.FilterInfo = ColumnFilterInfo18
        Me.Cerrado.Name = "Cerrado"
        '
        'cmbCaja
        '
        Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaja.Location = New System.Drawing.Point(736, 16)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(112, 21)
        Me.cmbCaja.TabIndex = 44
        '
        'lblCajaCmb
        '
        Me.lblCajaCmb.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajaCmb.Location = New System.Drawing.Point(696, 24)
        Me.lblCajaCmb.Name = "lblCajaCmb"
        Me.lblCajaCmb.Size = New System.Drawing.Size(40, 16)
        Me.lblCajaCmb.TabIndex = 46
        Me.lblCajaCmb.Text = "Caja:"
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.SystemColors.Control
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.ForeColor = System.Drawing.Color.Crimson
        Me.lblCaja.Location = New System.Drawing.Point(808, 16)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(120, 23)
        Me.lblCaja.TabIndex = 45
        Me.lblCaja.Text = "Caja : 1"
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'deFInicial
        '
        Me.deFInicial.DateTime = New Date(CType(0, Long))
        Me.deFInicial.Location = New System.Drawing.Point(472, 16)
        Me.deFInicial.Name = "deFInicial"
        Me.deFInicial.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.deFInicial.Size = New System.Drawing.Size(88, 25)
        Me.deFInicial.TabIndex = 47
        '
        'deFFinal
        '
        Me.deFFinal.DateTime = New Date(CType(0, Long))
        Me.deFFinal.Location = New System.Drawing.Point(584, 16)
        Me.deFFinal.Name = "deFFinal"
        Me.deFFinal.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.deFFinal.Size = New System.Drawing.Size(88, 25)
        Me.deFFinal.TabIndex = 48
        '
        'lblPeriodo
        '
        Me.lblPeriodo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPeriodo.Location = New System.Drawing.Point(408, 24)
        Me.lblPeriodo.Name = "lblPeriodo"
        Me.lblPeriodo.Size = New System.Drawing.Size(80, 16)
        Me.lblPeriodo.TabIndex = 49
        Me.lblPeriodo.Text = "Periodo :"
        '
        'lblA
        '
        Me.lblA.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblA.Location = New System.Drawing.Point(568, 24)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(8, 16)
        Me.lblA.TabIndex = 50
        Me.lblA.Text = "a"
        '
        'ComprobanteServicio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(936, 566)
        Me.Controls.Add(Me.lblA)
        Me.Controls.Add(Me.deFInicial)
        Me.Controls.Add(Me.lblPeriodo)
        Me.Controls.Add(Me.deFFinal)
        Me.Controls.Add(Me.cmbCaja)
        Me.Controls.Add(Me.lblCajaCmb)
        Me.Controls.Add(Me.lblCaja)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "ComprobanteServicio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ComprobanteServicio"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        CType(Me.grdPlomos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwPlomos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdFichasComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwFichasComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.deFFinal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Text
            '2008-001-EIM-01
            'REQ 024
            'Autor: Ana Juárez
            'Agregar comprobante de servicio
            Case "Agregar"
                Dim Agregar As New ComprobanteServicio_ed()
                Agregar.NumeroCaja = VerificaUsuario()
                Agregar.ShowDialog()
                Actualizar()
            Case "Modificar"
                If CorteCajaCerrado = True Then
                    MessageBox.Show("No se puede modificar un comprobante de servicio que contiene " + vbCrLf _
                           + "papeletas que son de un corte de caja ya cerrado", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                End If
                If Comp = 0 Then
                    MessageBox.Show("Debe seleccionar un registro", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Else
                    Dim Modificar As New ComprobanteServicio_ed()
                    Modificar.NumeroCaja = VerificaUsuario()
                    Modificar.Modificar = True
                    Modificar.Comprobante = Comp
                    Modificar.CorteCajaCerrado = CorteCajaCerrado
                    Modificar.ShowDialog()
                    Actualizar()
                End If
            Case "Eliminar"
                If CorteCajaCerrado = True Then
                    MessageBox.Show("No se puede eliminar un tramite que contiene papeletas que pertenecen a un corte de caja ya cerrado", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If
                If Comp = 0 Then
                    MessageBox.Show("Debe seleccionar un registro", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
                Else
                    Eliminar()
                    Actualizar()
                End If
            Case "Imprimir"
                Imprimir()
            Case "Actualizar"
                Actualizar()
            Case "Salir"
                Close()
        End Select
    End Sub

    Private Sub Eliminar()
        If MessageBox.Show("Desea eliminar el comprobante No. " & Comp.ToString & " y quitar la asignacion de fichas y plomos de este comprobante ?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            Dim Transaccion As SqlClient.SqlTransaction
            Transaccion = dmModulo.SqlConnection.BeginTransaction
            cmdCommand.Transaction = Transaccion
            Try
                cmdCommand.CommandType = CommandType.StoredProcedure
                cmdCommand.CommandText = "spSSEliminaComprobante"
                cmdCommand.Parameters.Clear()
                cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comp
                cmdCommand.ExecuteNonQuery()
                Transaccion.Commit()
                MessageBox.Show("Se ha eliminado el comprobante No. " & Comp.ToString, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Catch er As Exception
                Transaccion.Rollback()
                MessageBox.Show("No se puede eliminar el comprobante No. " & Comp.ToString & Chr(13) & "Debido al siguiente problema : " & er.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1)
            End Try
            Transaccion.Dispose()
        End If
    End Sub

    Private Sub Actualizar()
        Dim Linea As Integer
        Try
            Linea = vwComprobante.FocusedRowHandle
        Catch
            Linea = 0
        End Try
        Try
            dtSelect.Clear()
        Catch
        End Try

        If ValidaFechasInicioFin(deFInicial.DateTime.Date, deFFinal.DateTime.Date) = False Then
            Exit Sub
        End If

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSSelectComprobante"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
        cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable

        '2008-001-EIM-01
        'REQ 152
        'Autor: Ana Juárez
        'Filtro por periodo
        cmdCommand.Parameters.Add("@FInicial", SqlDbType.VarChar).Value = deFInicial.DateTime.ToShortDateString()
        cmdCommand.Parameters.Add("@FFinal", SqlDbType.VarChar).Value = deFFinal.DateTime.ToShortDateString()
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtSelect)
        Try
            ' daSelect.Fill(dtSelect)
            grdComprobante.DataSource = dtSelect
            vwComprobante.FocusedRowHandle = Linea
        Catch es As Exception
            MsgBox(es.Message)
        End Try
    End Sub

    Private Sub Detalles()
        Try
            dtFichas.Clear()
        Catch
        End Try
        Try
            dtPlomos.Clear()
        Catch
        End Try
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSSelectFichaComprobante"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
        cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comp
        cmdCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = 1
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtFichas)
        grdFichasComprobante.DataSource = dtFichas
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSSelectPlomosComprobante"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comp
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtPlomos)
        grdPlomos.DataSource = dtPlomos
    End Sub

    Private Sub ComprobanteServicio_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim rdrSelect As SqlDataReader
        Dim strUsuario, strUsuarioConsulta As String

        strUsuario = ""
        strUsuarioConsulta = ""

        deFInicial.DateTime = DateTime.Now()
        deFFinal.DateTime = DateTime.Now()

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
        End If
        Me.lblCaja.Text = "Caja : " & VerificaUsuario().ToString

        Actualizar()
        If vwComprobante.RowCount > 0 Then
            vwComprobante.FocusedRowHandle = 0
        End If
    End Sub
    Private Sub Imprimir()

        ''Dim ComprobanteServicio As Integer
        ''Dim rdrInsert As SqlClient.SqlDataReader
        ''Dim Datos As Boolean
        Dim Cajas As Integer
        ''Dim Cajera As String
        If vwComprobante.FocusedRowHandle < 0 Then
            MessageBox.Show("Seleccione una Ficha de Deposito", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
        End If
        'Try
        '    cmdCommand.CommandType = CommandType.StoredProcedure
        '    cmdCommand.CommandText = "spssValidaComprobanteServicio"
        '    daSelect.SelectCommand = cmdCommand
        '    cmdCommand.Parameters.Clear()
        '    cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio")
        '    rdrInsert = cmdCommand.ExecuteReader()
        '    If rdrInsert.Read Then
        '        Datos = True
        '        Cajas = CType(rdrInsert("Cajas"), Integer)
        '    Else
        '        Datos = False
        '    End If
        '    rdrInsert.Close()

        'Catch e As Exception
        '    MessageBox.Show("Ha ocurrido el siguiente error : " & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'End Try
        Dim Proveedor As Integer

        Proveedor = CType(vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("Prov"), Integer)

        'If Cajas > 1 Then
        '    Try
        '        Dim frmImpresion As New Impresion()
        '        frmImpresion.Entrar(vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio"))
        '        If frmImpresion.Imprime = True Then
        '            Dim frmViewReport As New ViewReport()
        '            frmViewReport.EntrarComprobante(dmModulo._NombreEmpresaContable, Proveedor, vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio"), frmImpresion.cajera.Trim, Cajas) 'Folio de la Ficah de deposito
        '            frmViewReport.Dispose()
        '        End If
        '    Catch A As Exception
        '        MessageBox.Show("Ha ocurrido el siguiente error : " & A.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        '    End Try
        'Else
        '    Try
        '    cmdCommand.CommandType = CommandType.StoredProcedure
        '    cmdCommand.CommandText = "spssUsuariosCaja"
        '    daSelect.SelectCommand = cmdCommand
        '    cmdCommand.Parameters.Clear()
        '    cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio")
        '    rdrInsert = cmdCommand.ExecuteReader()
        '    If rdrInsert.Read Then
        '        Datos = True
        '        Cajas = CType(rdrInsert("Caja"), Integer)
        '        Cajera = CType(rdrInsert("Usuario"), String)
        '    End If
        '    rdrInsert.Close()
        'Catch A As Exception
        '    MessageBox.Show("Ha ocurrido el siguiente error : " & A.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        'End Try
        Dim frmViewReport As New ViewReport()
        frmViewReport.EntrarComprobante(dmModulo._NombreEmpresaContable, Proveedor, CType(vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio").ToString().Trim, Integer), _
                                        dmModulo._Usuario.Trim(), Cajas) 'Folio de la Ficah de deposito
        frmViewReport.Dispose()
        'End If
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

    Private Sub vwComprobante_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles vwComprobante.FocusedRowChanged
        Try
            Comp = CType(vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio").ToString().Trim, Integer)
            CorteCajaCerrado = CType(vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("Cerrado"), Boolean)
        Catch
            CorteCajaCerrado = True
            Comp = 0
        End Try
        Detalles()
    End Sub

    Private Sub vwComprobante_EndSorting(ByVal sender As Object, ByVal e As System.EventArgs) Handles vwComprobante.EndSorting
        Try
            Comp = CType(vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio").ToString().Trim, Integer)
        Catch
            Comp = 0
        End Try
    End Sub

    'Funcion que permite validad dos fechas
    Private Function ValidaFechasInicioFin(ByVal FInicio As Date, ByVal FFin As Date) As Boolean
        'Verificacion de fechas
        If DateDiff(DateInterval.Day, FInicio, FFin) < 0 Then
            MessageBox.Show("La fecha 'Fin' no puede ser menor a la fecha 'Inicio', por favor verifique", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            deFInicial.DateTime = DateTime.Now
            deFFinal.DateTime = DateTime.Now
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub cmbCaja_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCaja.SelectionChangeCommitted
        Me.lblCaja.Text = "Caja : " + VerificaUsuario().ToString()
    End Sub

    Private Sub vwComprobante_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vwComprobante.Click
        If vwComprobante.RowCount = 1 Then
            Try
                Comp = CType(vwComprobante.GetRow(vwComprobante.FocusedRowHandle).item("ComprobanteServicio").ToString().Trim, Integer)
            Catch
                Comp = 0
            End Try
            Detalles()
        End If
    End Sub
End Class
