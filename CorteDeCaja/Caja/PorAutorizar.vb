'Proposito : Pantalla para AUTORIZAR, RECHAZAR o CANCELAR un gasto mayor al monto permitido
'Autor : Izanami Mendoza 
'FCreacion : Mayo del 2006

Imports System.Data.SqlClient

Public Class PorAutorizar
    Inherits System.Windows.Forms.Form

    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private dtMontoPendiente As New DataTable()
    Private dtAplicaciones As New DataTable()
    Private daSelect As New SqlDataAdapter()
    Private rdrSelect As SqlDataReader
    Private VGM_MontoPendiente As Decimal
    Private VGN_TipoFicha As Decimal
    Private dcmMontoMaximo As Decimal
    Private intCaja As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Caja As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.intCaja = Caja

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
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents dtFechaOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents imgMain As System.Windows.Forms.ImageList
    Friend WithEvents btnAutorizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnRechazar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdPorAutorizar As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwPorAutorizar As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents clmCaja As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmFolio As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmTipoAplicacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmConsecutivoTipoAplicacion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmMonto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmTipoFicha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmTipoAplicacionIngreso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents clmObservaciones As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblObservaciones As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.ToolBarButton
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PorAutorizar))
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnAutorizar = New System.Windows.Forms.ToolBarButton()
        Me.btnRechazar = New System.Windows.Forms.ToolBarButton()
        Me.btnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dtFechaOperacion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.lblObservaciones = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdPorAutorizar = New DevExpress.XtraGrid.GridControl()
        Me.vwPorAutorizar = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.clmCaja = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmFolio = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmTipoAplicacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmConsecutivoTipoAplicacion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmMonto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmTipoFicha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmTipoAplicacionIngreso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.clmObservaciones = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdPorAutorizar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwPorAutorizar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAutorizar, Me.btnRechazar, Me.btnCancelar, Me.ToolBarButton1, Me.ToolBarButton4, Me.btnActualizar, Me.btnSalir})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(60, 40)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgMain
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(602, 43)
        Me.ToolBar1.TabIndex = 1
        '
        'btnAutorizar
        '
        Me.btnAutorizar.ImageIndex = 0
        Me.btnAutorizar.Text = "Autorizar"
        '
        'btnRechazar
        '
        Me.btnRechazar.ImageIndex = 15
        Me.btnRechazar.Text = "Rechazar"
        '
        'btnCancelar
        '
        Me.btnCancelar.ImageIndex = 9
        Me.btnCancelar.Text = "Cancelar"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'ToolBarButton4
        '
        Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 4
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 5
        Me.btnSalir.Text = "Regresar"
        '
        'imgMain
        '
        Me.imgMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgMain.ImageStream = CType(resources.GetObject("imgMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMain.TransparentColor = System.Drawing.Color.Transparent
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtFechaOperacion, Me.Label1})
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 43)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(602, 45)
        Me.Panel2.TabIndex = 4
        '
        'dtFechaOperacion
        '
        Me.dtFechaOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaOperacion.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtFechaOperacion.Location = New System.Drawing.Point(62, 11)
        Me.dtFechaOperacion.Name = "dtFechaOperacion"
        Me.dtFechaOperacion.Size = New System.Drawing.Size(96, 22)
        Me.dtFechaOperacion.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label1.Location = New System.Drawing.Point(8, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 15)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "FECHA :"
        '
        'Panel3
        '
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblObservaciones, Me.Panel1, Me.Label2})
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 88)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(602, 248)
        Me.Panel3.TabIndex = 5
        '
        'lblObservaciones
        '
        Me.lblObservaciones.Location = New System.Drawing.Point(128, 196)
        Me.lblObservaciones.Name = "lblObservaciones"
        Me.lblObservaciones.Size = New System.Drawing.Size(440, 12)
        Me.lblObservaciones.TabIndex = 29
        Me.lblObservaciones.Text = "Observaciones"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdPorAutorizar})
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(600, 184)
        Me.Panel1.TabIndex = 0
        '
        'grdPorAutorizar
        '
        Me.grdPorAutorizar.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPorAutorizar.EditorsRepository = Me.PersistentRepository1
        Me.grdPorAutorizar.MainView = Me.vwPorAutorizar
        Me.grdPorAutorizar.Name = "grdPorAutorizar"
        Me.grdPorAutorizar.Size = New System.Drawing.Size(600, 184)
        Me.grdPorAutorizar.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))))
        Me.grdPorAutorizar.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPorAutorizar.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightYellow, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(58, Byte), CType(110, Byte), CType(165, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPorAutorizar.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Lavender, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightYellow, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdPorAutorizar.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.SteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdPorAutorizar.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.MediumSlateBlue))
        Me.grdPorAutorizar.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdPorAutorizar.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPorAutorizar.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPorAutorizar.TabIndex = 3
        Me.grdPorAutorizar.Text = "GridControl1"
        '
        'vwPorAutorizar
        '
        Me.vwPorAutorizar.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwPorAutorizar.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.clmCaja, Me.clmFolio, Me.clmTipoAplicacion, Me.clmConsecutivoTipoAplicacion, Me.clmStatus, Me.clmMonto, Me.clmTipoFicha, Me.clmTipoAplicacionIngreso, Me.clmObservaciones})
        Me.vwPorAutorizar.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwPorAutorizar.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {New DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.None, Nothing, "", Nothing, Nothing, Nothing, False), New DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.None, Nothing, "", Nothing, Nothing, Nothing, False)})
        Me.vwPorAutorizar.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Nothing, "{0:c}")})
        Me.vwPorAutorizar.Name = "vwPorAutorizar"
        Me.vwPorAutorizar.PrintOptions = (((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllDetails) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines)
        Me.vwPorAutorizar.ViewOptions = ((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'clmCaja
        '
        Me.clmCaja.Caption = "Caja"
        Me.clmCaja.FieldName = "Caja"
        Me.clmCaja.Name = "clmCaja"
        Me.clmCaja.VisibleIndex = 0
        Me.clmCaja.Width = 60
        '
        'clmFolio
        '
        Me.clmFolio.Caption = "Folio Corte"
        Me.clmFolio.FieldName = "Consecutivo"
        Me.clmFolio.Name = "clmFolio"
        Me.clmFolio.VisibleIndex = 1
        Me.clmFolio.Width = 81
        '
        'clmTipoAplicacion
        '
        Me.clmTipoAplicacion.Caption = "Tipo Aplicación"
        Me.clmTipoAplicacion.FieldName = "Concepto"
        Me.clmTipoAplicacion.Name = "clmTipoAplicacion"
        Me.clmTipoAplicacion.VisibleIndex = 2
        Me.clmTipoAplicacion.Width = 165
        '
        'clmConsecutivoTipoAplicacion
        '
        Me.clmConsecutivoTipoAplicacion.Caption = "ConsecutivoTipo"
        Me.clmConsecutivoTipoAplicacion.FieldName = "ConsecutivoTipoAplicacion"
        Me.clmConsecutivoTipoAplicacion.Name = "clmConsecutivoTipoAplicacion"
        Me.clmConsecutivoTipoAplicacion.VisibleIndex = 3
        Me.clmConsecutivoTipoAplicacion.Width = 112
        '
        'clmStatus
        '
        Me.clmStatus.Caption = "Status"
        Me.clmStatus.FieldName = "Status"
        Me.clmStatus.Name = "clmStatus"
        Me.clmStatus.VisibleIndex = 4
        Me.clmStatus.Width = 90
        '
        'clmMonto
        '
        Me.clmMonto.Caption = "Monto"
        Me.clmMonto.FieldName = "Total"
        Me.clmMonto.FormatString = "$#,#.00"
        Me.clmMonto.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.clmMonto.Name = "clmMonto"
        Me.clmMonto.SummaryItem.DisplayFormat = "{0:c}"
        Me.clmMonto.SummaryItem.FieldName = "$#,#.00"
        Me.clmMonto.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.clmMonto.VisibleIndex = 5
        Me.clmMonto.Width = 80
        '
        'clmTipoFicha
        '
        Me.clmTipoFicha.Caption = "GridColumn1"
        Me.clmTipoFicha.FieldName = "TipoFicha"
        Me.clmTipoFicha.Name = "clmTipoFicha"
        '
        'clmTipoAplicacionIngreso
        '
        Me.clmTipoAplicacionIngreso.Caption = "GridColumn1"
        Me.clmTipoAplicacionIngreso.FieldName = "TipoAplicacionIngreso"
        Me.clmTipoAplicacionIngreso.Name = "clmTipoAplicacionIngreso"
        '
        'clmObservaciones
        '
        Me.clmObservaciones.Caption = "Observaciones"
        Me.clmObservaciones.FieldName = "Observaciones"
        Me.clmObservaciones.Name = "clmObservaciones"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.MediumBlue
        Me.Label2.Location = New System.Drawing.Point(8, 195)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 15)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "OBSERVACIONES :"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 336)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(602, 3)
        Me.Splitter1.TabIndex = 6
        Me.Splitter1.TabStop = False
        '
        'PorAutorizar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(602, 336)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Splitter1, Me.Panel3, Me.Panel2, Me.ToolBar1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "PorAutorizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Autorizar"
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdPorAutorizar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwPorAutorizar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Entrar()
        dtFechaOperacion.Value = CType(dmModulo.VGS_FOperacion, Date)
        Actualizar(False)
        Me.ShowDialog()
    End Sub

    'Verifica cual es el monto máximo para realizar un gasto
    Private Sub MontoMaximo()
        cmdCommand.CommandType = CommandType.Text
        cmdCommand.CommandText = "Select Valor From Parametro Where Modulo=3 and Parametro='MontoMaximoGasto'"
        cmdCommand.Parameters.Clear()

        rdrSelect = cmdCommand.ExecuteReader
        If rdrSelect.Read() Then
            dcmMontoMaximo = CType(rdrSelect("Valor"), Decimal)
        End If
        rdrSelect.Close()
    End Sub

    Private Sub Actualizar(ByVal Buscar As Boolean)
        MontoMaximo()
        Try
            dtMontoPendiente.Clear()
            dtAplicaciones.Clear()

            With cmdCommand
                .Parameters.Clear()
                .CommandType = CommandType.StoredProcedure

                .CommandText = "spSSCorteCajaAplicaciones"

                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = Me.intCaja
                If Buscar Then
                    .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dtFechaOperacion.Value
                Else
                    .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                End If
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@Accion", SqlDbType.Int).Value = 1   '--Muestra los gastos mayores al monto permitido de todos los status
                .Parameters.Add("@MontoMaximo", SqlDbType.Decimal).Value = dcmMontoMaximo
                daSelect.SelectCommand = cmdCommand
                daSelect.Fill(dtAplicaciones)
                grdPorAutorizar.DataSource = dtAplicaciones
            End With
        Catch e As Exception
            MsgBox(e.Message)
        End Try
    End Sub

    Private Sub vwPorAutorizar_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles vwPorAutorizar.FocusedRowChanged
        lblObservaciones.Text = vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Observaciones").ToString()
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Dim strStatus As String = ""

        If vwPorAutorizar.RowCount > 0 Then
            strStatus = vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Status").ToString()
        End If

        Select Case e.Button.Text
            Case "Autorizar"
                If strStatus = "AUTORIZADO" Then
                    MessageBox.Show("Sólo se puede autorizar con estatus PENDIENTE o RECHAZADO, verifique.", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    Dim frmAutorizar As New Autorizar(CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Caja").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Consecutivo").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoFicha").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoAplicacionIngreso").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("ConsecutivoTipoAplicacion").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Total").ToString(), Decimal), _
                                                      "AUTORIZAR", dtFechaOperacion.Value)
                    frmAutorizar.ShowDialog()
                    Actualizar(False)
                End If
            Case "Rechazar"
                If Trim(strStatus) = "PENDIENTE" Then
                    ''Dim frmAutorizar As New Autorizar(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Caja"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Consecutivo"), vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoFicha"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoAplicacionIngreso"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("ConsecutivoTipoAplicacion"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Total"), "RECHAZAR", dtFechaOperacion.Value)

                    Dim frmAutorizar As New Autorizar(CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Caja").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Consecutivo").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoFicha").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoAplicacionIngreso").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("ConsecutivoTipoAplicacion").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Total").ToString(), Decimal), _
                                                      "RECHAZAR", dtFechaOperacion.Value)
                    frmAutorizar.ShowDialog()
                    Actualizar(False)
                Else
                    MessageBox.Show("Sólo se puede rechazar con estatus PENDIENTE, verifique.", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case "Cancelar"
                If strStatus = "AUTORIZADO" Then
                    MessageBox.Show("Sólo se puede cancelar con estatus PENDIENTE o RECHAZADO, verifique.", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Else
                    ''Dim frmAutorizar As 
                    ''New Autorizar(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Caja"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Consecutivo"), vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoFicha"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoAplicacionIngreso"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("ConsecutivoTipoAplicacion"), 
                    ''vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Total"), "CANCELAR", dtFechaOperacion.Value)

                    Dim frmAutorizar As New Autorizar(CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Caja").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Consecutivo").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoFicha").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("TipoAplicacionIngreso").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("ConsecutivoTipoAplicacion").ToString(), Integer), _
                                                      CType(vwPorAutorizar.GetRow(vwPorAutorizar.FocusedRowHandle).item("Total").ToString(), Decimal), _
                                                      "CANCELAR", dtFechaOperacion.Value)
                    frmAutorizar.ShowDialog()
                    Actualizar(False)
                End If
            Case "Actualizar"
                Actualizar(False)
            Case "Regresar"
                Close()
        End Select

    End Sub

    Private Sub dtFechaOperacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaOperacion.ValueChanged
        Actualizar(True)
    End Sub

End Class
