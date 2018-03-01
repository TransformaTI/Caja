Imports System.Data
Imports System.Data.SqlClient

Public Class CambioCheques
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private dtSelect As DataTable
    Private daSelect As New SqlDataAdapter()
    Private VGS_Concepto As String
    Private VGN_TipoFicha As Integer
    Private VGM_MontoPendiente As Decimal
    Private FechaCorte As DateTime


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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents tbtnCancelar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgMain As System.Windows.Forms.ImageList
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents tbtnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbtnRegresar As System.Windows.Forms.ToolBarButton
    Friend WithEvents txtCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents cmbCuentaBanco As System.Windows.Forms.ComboBox
    Friend WithEvents grdCheques As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwCheques As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents txtBeneficiario As System.Windows.Forms.TextBox
    Friend WithEvents ll As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents lblMontoPendiente As System.Windows.Forms.Label
    Friend WithEvents lblDatos As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCuentaCheque As System.Windows.Forms.TextBox
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CambioCheques))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdCheques = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.ll = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwCheques = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtCuentaCheque = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblMontoPendiente = New System.Windows.Forms.Label()
        Me.cmbCuentaBanco = New System.Windows.Forms.ComboBox()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBeneficiario = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCheque = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnGuardar = New System.Windows.Forms.ToolBarButton()
        Me.tbtnCancelar = New System.Windows.Forms.ToolBarButton()
        Me.tbtnModificar = New System.Windows.Forms.ToolBarButton()
        Me.tbtnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.tbtnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.tbtnRegresar = New System.Windows.Forms.ToolBarButton()
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.lblDatos = New System.Windows.Forms.Label()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel2.SuspendLayout()
        CType(Me.grdCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwCheques, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdCheques})
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 264)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(730, 144)
        Me.Panel2.TabIndex = 23
        '
        'grdCheques
        '
        Me.grdCheques.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdCheques.EditorsRepository = Me.PersistentRepository1
        Me.grdCheques.MainView = Me.vwCheques
        Me.grdCheques.Name = "grdCheques"
        Me.grdCheques.Size = New System.Drawing.Size(730, 144)
        Me.grdCheques.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))))
        Me.grdCheques.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdCheques.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdCheques.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Lavender, System.Drawing.Color.MediumSlateBlue))
        Me.grdCheques.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.DimGray))
        Me.grdCheques.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdCheques.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(58, Byte), CType(110, Byte), CType(165, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdCheques.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.AliceBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdCheques.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdCheques.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte))))
        Me.grdCheques.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightCyan, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdCheques.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.DimGray))
        Me.grdCheques.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightCyan, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdCheques.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(202, Byte), CType(202, Byte), CType(202, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdCheques.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.DimGray))
        Me.grdCheques.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Lavender, System.Drawing.Color.MediumSlateBlue))
        Me.grdCheques.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(10, Byte), CType(10, Byte), CType(138, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdCheques.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.DimGray))
        Me.grdCheques.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdCheques.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdCheques.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdCheques.TabIndex = 0
        Me.grdCheques.Text = "GridControl1"
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.ll})
        '
        'll
        '
        Me.ll.Name = "ll"
        Me.ll.Properties.AllowFocused = False
        Me.ll.Properties.AutoHeight = False
        Me.ll.Properties.BorderSides = DevExpress.XtraEditors.Controls.BorderSide.None
        Me.ll.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple
        '
        'vwCheques
        '
        Me.vwCheques.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwCheques.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn5, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn6})
        Me.vwCheques.DefaultEdit = Me.ll
        Me.vwCheques.Name = "vwCheques"
        Me.vwCheques.ViewOptions = ((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Cheque"
        Me.GridColumn1.FieldName = "NumeroCheque"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Cuenta cheque"
        Me.GridColumn5.FieldName = "CuentaCheque"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Cuenta depósito"
        Me.GridColumn2.FieldName = "CuentaBanco"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 176
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Beneficiario"
        Me.GridColumn3.FieldName = "Beneficiario"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 249
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Total"
        Me.GridColumn4.FieldName = "Total"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn4.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn4.VisibleIndex = 4
        Me.GridColumn4.Width = 116
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtCuentaCheque, Me.Label5, Me.lblMontoPendiente, Me.cmbCuentaBanco, Me.txtObservaciones, Me.Label6, Me.txtBeneficiario, Me.Label4, Me.txtCheque, Me.Label3, Me.txtMonto, Me.Label2, Me.Label1})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(730, 221)
        Me.Panel1.TabIndex = 22
        '
        'txtCuentaCheque
        '
        Me.txtCuentaCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCuentaCheque.Location = New System.Drawing.Point(117, 36)
        Me.txtCuentaCheque.MaxLength = 10
        Me.txtCuentaCheque.Name = "txtCuentaCheque"
        Me.txtCuentaCheque.Size = New System.Drawing.Size(339, 20)
        Me.txtCuentaCheque.TabIndex = 2
        Me.txtCuentaCheque.Text = ""
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(14, 39)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(94, 15)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Cuenta cheque :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMontoPendiente
        '
        Me.lblMontoPendiente.BackColor = System.Drawing.Color.PapayaWhip
        Me.lblMontoPendiente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMontoPendiente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoPendiente.ForeColor = System.Drawing.Color.Red
        Me.lblMontoPendiente.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblMontoPendiente.Location = New System.Drawing.Point(264, 8)
        Me.lblMontoPendiente.Name = "lblMontoPendiente"
        Me.lblMontoPendiente.Size = New System.Drawing.Size(464, 23)
        Me.lblMontoPendiente.TabIndex = 25
        Me.lblMontoPendiente.Text = "Monto Pendiente por tipo de ficha"
        Me.lblMontoPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCuentaBanco
        '
        Me.cmbCuentaBanco.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuentaBanco.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCuentaBanco.Location = New System.Drawing.Point(117, 63)
        Me.cmbCuentaBanco.Name = "cmbCuentaBanco"
        Me.cmbCuentaBanco.Size = New System.Drawing.Size(337, 22)
        Me.cmbCuentaBanco.TabIndex = 3
        '
        'txtObservaciones
        '
        Me.txtObservaciones.AutoSize = False
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(117, 149)
        Me.txtObservaciones.MaxLength = 0
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(336, 60)
        Me.txtObservaciones.TabIndex = 6
        Me.txtObservaciones.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 149)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(92, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Observaciones :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBeneficiario
        '
        Me.txtBeneficiario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtBeneficiario.Location = New System.Drawing.Point(117, 92)
        Me.txtBeneficiario.MaxLength = 0
        Me.txtBeneficiario.Name = "txtBeneficiario"
        Me.txtBeneficiario.Size = New System.Drawing.Size(337, 20)
        Me.txtBeneficiario.TabIndex = 4
        Me.txtBeneficiario.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 95)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Beneficiario :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCheque
        '
        Me.txtCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCheque.Location = New System.Drawing.Point(117, 9)
        Me.txtCheque.MaxLength = 10
        Me.txtCheque.Name = "txtCheque"
        Me.txtCheque.Size = New System.Drawing.Size(128, 20)
        Me.txtCheque.TabIndex = 1
        Me.txtCheque.Text = ""
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(54, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 15)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Cheque :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMonto
        '
        Me.txtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMonto.Location = New System.Drawing.Point(117, 120)
        Me.txtMonto.MaxLength = 0
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(128, 20)
        Me.txtMonto.TabIndex = 5
        Me.txtMonto.Text = ""
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(61, 123)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Monto :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Cuenta depósito :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnGuardar, Me.tbtnCancelar, Me.tbtnModificar, Me.tbtnEliminar, Me.tbtnActualizar, Me.tbtnRegresar})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(60, 40)
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.imgMain
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New System.Drawing.Size(730, 43)
        Me.ToolBar1.TabIndex = 7
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Text = "Agregar"
        '
        'btnGuardar
        '
        Me.btnGuardar.ImageIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.Visible = False
        '
        'tbtnCancelar
        '
        Me.tbtnCancelar.ImageIndex = 6
        Me.tbtnCancelar.Text = "Cancelar"
        Me.tbtnCancelar.Visible = False
        '
        'tbtnModificar
        '
        Me.tbtnModificar.ImageIndex = 1
        Me.tbtnModificar.Text = "Modificar"
        '
        'tbtnEliminar
        '
        Me.tbtnEliminar.ImageIndex = 2
        Me.tbtnEliminar.Text = "Eliminar"
        '
        'tbtnActualizar
        '
        Me.tbtnActualizar.ImageIndex = 3
        Me.tbtnActualizar.Text = "Actualizar"
        '
        'tbtnRegresar
        '
        Me.tbtnRegresar.ImageIndex = 4
        Me.tbtnRegresar.Text = "Regresar"
        '
        'imgMain
        '
        Me.imgMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgMain.ImageStream = CType(resources.GetObject("imgMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'lblDatos
        '
        Me.lblDatos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatos.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDatos.Location = New System.Drawing.Point(384, 9)
        Me.lblDatos.Name = "lblDatos"
        Me.lblDatos.Size = New System.Drawing.Size(344, 23)
        Me.lblDatos.TabIndex = 26
        Me.lblDatos.Text = "datos corte"
        Me.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Folio"
        Me.GridColumn6.FieldName = "Folio"
        Me.GridColumn6.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.VisibleIndex = 5
        '
        'CambioCheques
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(730, 408)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDatos, Me.Panel2, Me.Panel1, Me.ToolBar1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "CambioCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio de cheques"
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdCheques, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwCheques, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub ActualizaMontoPendiente()
        VGM_MontoPendiente = dmModulo.MontoPendienteTipoFicha(VGN_TipoFicha, True, 0, 0)
        lblMontoPendiente.Text = VGS_Concepto & "= " & VGM_MontoPendiente.ToString("c")
    End Sub

    Private Sub Actualizar()
        txtCheque.Text = ""
        txtMonto.Text = "0"
        txtBeneficiario.Text = ""
        txtObservaciones.Text = ""
        txtCuentaCheque.Text = ""
        Dim linea As Integer
        linea = vwCheques.FocusedRowHandle
        Try
            dtSelect.Clear()
        Catch
        End Try

        With cmdCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spSSSelectCorteCajaCheques"
            .Parameters.Clear()
            .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(VGS_FOperacion, String)
            .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
            daSelect.SelectCommand = cmdCommand
        End With
        daSelect.Fill(dtSelect)
        grdCheques.DataSource = dtSelect

    End Sub

    Public Sub Entrar(ByVal FechaCorte As DateTime, ByVal TipoFicha As Integer, ByVal Concepto As String, ByVal Monto As Decimal)
        VGN_TipoFicha = TipoFicha
        Me.FechaCorte = FechaCorte
        VGM_MontoPendiente = dmModulo.MontoPendienteTipoFicha(TipoFicha, True, 0, 0)
        VGS_Concepto = Concepto
        lblDatos.Text = "CAJA = " & CType(dmModulo.VGN_Caja, String) & "   FOLIO = " & CType(VGN_Consecutivo, String)

        If (VGM_MontoPendiente <> -1) Then
            lblMontoPendiente.Text = VGS_Concepto & "= " & VGM_MontoPendiente.ToString("c")
        Else
            'En este caso, se insertaria como primera vez el MONTO PENDIENTE DE ESTE TIPO DE FICHA
            'En el caso de que VGN_TipoFicha <> 0, quiere decir que se va a insertar una ficha multiple
            VGM_MontoPendiente = Monto
            lblMontoPendiente.Text = VGS_Concepto & "= " & VGM_MontoPendiente.ToString("c")
        End If
        Me.ShowDialog()

    End Sub

    Private Sub CambioCheques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnGuardar.Visible = False

        dtSelect = New DataTable()
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSCuentaBanco"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtSelect)
        cmbCuentaBanco.DataSource = dtSelect
        cmbCuentaBanco.ValueMember = "CuentaBanco"
        cmbCuentaBanco.DisplayMember = "Descripcion"

        dtSelect = New DataTable()
        Actualizar()
    End Sub

    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        If e.Button.Text = "Agregar" Then
            If CType(VGM_MontoPendiente, Decimal) >= CType(txtMonto.Text, Decimal) Then
                Agregar(True)
            Else
                MessageBox.Show("El monto del cheque que esta capturando en mayor al monto pendiente, NO SE PUEDE REALIZAR LA OPERACIÓN. Verique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        ElseIf e.Button.Text = "Guardar" Then
            Agregar(False)
            btnGuardar.Visible = False
            btnAgregar.Visible = True
            Actualizar()
        ElseIf e.Button.Text = "Cancelar" Then
        ElseIf e.Button.Text = "Modificar" Then
            Modificar()
        ElseIf e.Button.Text = "Eliminar" Then
            If MessageBox.Show("Desea eliminar el cheque " & vwCheques.GetRow(vwCheques.FocusedRowHandle).item("NumeroCheque").ToString().Trim & " ?", "Caja", _
                               MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Eliminar(CType(vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Folio"), Integer))
            End If
        ElseIf e.Button.Text = "Actualizar" Then
            Actualizar()
        ElseIf e.Button.Text = "Regresar" Then
            Close()
        End If
    End Sub

    Private Sub AgregarFolio(ByVal FolioUltimo As Integer)
        ''Dim Monto As Decimal

        Dim Transaccion As SqlClient.SqlTransaction
        Transaccion = dmModulo.SqlConnection.BeginTransaction
        cmdCommand.Transaction = Transaccion

        Try

            ActualizarFichaDeposito(FolioUltimo)
            'FolioUltimo = CType(vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Folio"), Integer)

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSCambioChequesAltaModifica"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = cmbCuentaBanco.SelectedValue
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = CType(txtCheque.Text, String)
                .Parameters.Add("@CuentaCheque", SqlDbType.Char).Value = CType(txtCuentaCheque.Text, String)
                .Parameters.Add("@Beneficiario", SqlDbType.Char).Value = CType(txtBeneficiario.Text, String)
                .Parameters.Add("@Total", SqlDbType.Money).Value = CType(txtMonto.Text, Decimal)
                .Parameters.Add("@Observaciones", SqlDbType.Char).Value = CType(txtObservaciones.Text, String)
                .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0                
                .ExecuteNonQuery()
            End With


            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSUpdateFichaDepositoCambioCheque"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = cmbCuentaBanco.SelectedValue
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = CType(txtCheque.Text, String)
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioUltimo
                .ExecuteNonQuery()
            End With


            Transaccion.Commit()
        Catch er As Exception
            Transaccion.Rollback()
            MessageBox.Show("¡No se pudo realizar la operación, por favor verifique! " + er.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Finally
            Transaccion.Dispose()
        End Try
        dmModulo.MontoPendienteTipoFicha(VGN_TipoFicha, False, CType(txtMonto.Text, Decimal), VGM_MontoPendiente)
        ActualizaMontoPendiente()
        Actualizar()

    End Sub

    Private Sub Agregar(ByVal Agrega As Boolean)
        Dim Monto As Decimal
        Dim FolioUltimo As Integer
        Try
            Monto = CType(txtMonto.Text, Decimal)
        Catch
            MessageBox.Show("El valor del monto no es valido, por favor verifique", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End Try


        If txtCheque.Text = "" Then
            MessageBox.Show("No se ha capturado el NÚMERO DEL CHEQUE, por favor verifique", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If
        Dim Transaccion As SqlClient.SqlTransaction
        Transaccion = dmModulo.SqlConnection.BeginTransaction
        cmdCommand.Transaction = Transaccion

        Try

            If Agrega Then
                FolioUltimo = AgregarFichaDeposito()
            Else
                ActualizarFichaDeposito(CType(vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Folio"), Integer))
                FolioUltimo = CType(vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Folio"), Integer)
            End If

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSCambioChequesAltaModifica"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = cmbCuentaBanco.SelectedValue
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = CType(txtCheque.Text, String)
                .Parameters.Add("@CuentaCheque", SqlDbType.Char).Value = CType(txtCuentaCheque.Text, String)
                .Parameters.Add("@Beneficiario", SqlDbType.Char).Value = CType(txtBeneficiario.Text, String)
                .Parameters.Add("@Total", SqlDbType.Money).Value = CType(txtMonto.Text, Decimal)
                .Parameters.Add("@Observaciones", SqlDbType.Char).Value = CType(txtObservaciones.Text, String)
                If Not (Agrega) Then
                    .Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
                End If
                .ExecuteNonQuery()
            End With


            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                If Agrega Then
                    .CommandText = "spSSInsertaFichaDepositoCambioCheque"
                Else
                    .CommandText = "spSSUpdateFichaDepositoCambioCheque"
                End If
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = cmbCuentaBanco.SelectedValue
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = CType(txtCheque.Text, String)
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioUltimo
                .ExecuteNonQuery()
            End With


            Transaccion.Commit()
        Catch er As Exception
            Transaccion.Rollback()
            MessageBox.Show("¡No se pudo realizar la operación, por favor verifique! " + er.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        Finally
            Transaccion.Dispose()
        End Try
        dmModulo.MontoPendienteTipoFicha(VGN_TipoFicha, False, CType(txtMonto.Text, Decimal), VGM_MontoPendiente)
        ActualizaMontoPendiente()
        If Agrega Then
            AgregarFolio(FolioUltimo)
        End If

        Actualizar()

    End Sub


    Private Function AgregarFichaDeposito() As Integer
        Dim FolioUltimo As Integer
        Try

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSInsertaFicha"
                .Parameters.Clear()
                .Parameters.Add("@Total", SqlDbType.Money).Value = CType(txtMonto.Text, Decimal)
                .Parameters.Add("@FFicha", SqlDbType.Char).Value = Me.FechaCorte.ToShortDateString()
                .Parameters.Add("@Descripcion", SqlDbType.Char).Value = CType(VGS_Concepto, String)
                .Parameters.Add("@Cuenta", SqlDbType.Char).Value = CType(cmbCuentaBanco.SelectedValue, String)
                .Parameters.Add("@Folio", SqlDbType.Int).Direction = ParameterDirection.Output
                .ExecuteNonQuery()
                FolioUltimo = CType(.Parameters("@Folio").Value, Integer)

            End With

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSInsertaFichaDepositoDetalle"
                .Parameters.Clear()
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioUltimo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@Monto", SqlDbType.Money).Value = CType(txtMonto.Text, Decimal)
                .ExecuteNonQuery()
            End With

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSInsertaCorteCajaFichaDeposito"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioUltimo
                .ExecuteNonQuery()
            End With
            Return FolioUltimo
        Catch errorAgregarFichaDeposito As Exception
            MessageBox.Show("Error al insertar ficha deposito de cambio cheque" + vbCrLf _
                            + errorAgregarFichaDeposito.ToString(), "Fichas deposito", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try
    End Function


    Public Sub ActualizarFichaDeposito(ByVal FolioFicha As Integer)
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSUpdateFicha"
                .Parameters.Clear()
                .Parameters.Add("@Total", SqlDbType.Money).Value = CType(txtMonto.Text, Decimal)
                .Parameters.Add("@FFicha", SqlDbType.Char).Value = Me.FechaCorte.ToShortDateString()
                .Parameters.Add("@Descripcion", SqlDbType.Char).Value = CType(VGS_Concepto, String)
                .Parameters.Add("@Cuenta", SqlDbType.Char).Value = CType(cmbCuentaBanco.SelectedValue, String)
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioFicha
                .ExecuteNonQuery()

            End With

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSUpdateFichaDepositoDetalle"
                .Parameters.Clear()
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioFicha
                .Parameters.Add("@Monto", SqlDbType.Money).Value = CType(txtMonto.Text, Decimal)
                .ExecuteNonQuery()
            End With
        Catch errorActualizarFichaDeposito As Exception
            MessageBox.Show("Error al intentar actualizar la parte de ficha deposito de cambio cheque" + vbCrLf _
                             + errorActualizarFichaDeposito.ToString(), "Fichas depósito", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Sub

    Private Sub Modificar()
        If vwCheques.SelectedRowsCount = 1 Then
            btnGuardar.Visible = True
            btnAgregar.Visible = False
            txtCheque.Text = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("NumeroCheque").ToString().Trim
            txtCuentaCheque.Text = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("CuentaCheque").ToString().Trim
            cmbCuentaBanco.SelectedValue = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("CuentaBanco")
            txtBeneficiario.Text = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Beneficiario").ToString().Trim
            txtMonto.Text = CType(vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Total"), Decimal).ToString("c")
            txtObservaciones.Text = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Observaciones").ToString().Trim
        Else
            MessageBox.Show("¡No se pudo realizar la operación, no hay datos para modificar! ", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If


    End Sub

    Private Sub Eliminar(ByVal FolioEliminar As Integer)
        Try

            With cmdCommand
                .CommandText = "spSSEliminaFichaDepositoCambioCheque"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("NumeroCheque")
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("CuentaBanco")
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioEliminar
                .ExecuteNonQuery()
            End With

            With cmdCommand
                .CommandText = "spSSEliminaCorteCajaCheque"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("NumeroCheque")
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("CuentaBanco")
                .Parameters.Add("@Monto", SqlDbType.Money).Value = vwCheques.GetRow(vwCheques.FocusedRowHandle).item("Total")
                .ExecuteNonQuery()
            End With
            ActualizaMontoPendiente()
            Actualizar()
        Catch er As Exception
            Exit Sub
        End Try
    End Sub

End Class
