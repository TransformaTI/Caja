'Descripcion: Pantalla que despliega el catalogo de Tipoficha
'Fecha: Agosto 25,2005
'Autor: Liliana C.
Imports System.Data
Imports System.Data.SqlClient

Public Class CatalogoTipoFicha
    Inherits System.Windows.Forms.Form
    

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
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Cuenta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Prorrateable As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Descripcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoTramtre As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository3 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents PersistentRepository4 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdTipMovCaja As DevExpress.XtraGrid.GridControl
    Friend WithEvents TipoMov As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CatalogoFicha As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwCatalogoFicha As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TipoFicha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DescFicha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DescCobro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TipoCobro As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents vwTipoMovCaja As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdBancos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwBancos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Bancos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BancoDesc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnAgregar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnModificar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents tlbCatTipFicha As System.Windows.Forms.ToolBar
    Friend WithEvents Automatica As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EspecificarBanco As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents imlTipoFicha As System.Windows.Forms.ImageList
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CatalogoTipoFicha))
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Cuenta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Prorrateable = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Descripcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoTramtre = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository3 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.PersistentRepository4 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.grdBancos = New DevExpress.XtraGrid.GridControl()
        Me.vwBancos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Bancos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BancoDesc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdTipMovCaja = New DevExpress.XtraGrid.GridControl()
        Me.vwTipoMovCaja = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TipoMov = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CatalogoFicha = New DevExpress.XtraGrid.GridControl()
        Me.vwCatalogoFicha = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TipoFicha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DescFicha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DescCobro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TipoCobro = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Automatica = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.EspecificarBanco = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnAgregar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificar = New System.Windows.Forms.ToolBarButton()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.tlbCatTipFicha = New System.Windows.Forms.ToolBar()
        Me.imlTipoFicha = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.grdBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwBancos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdTipMovCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwTipoMovCaja, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.CatalogoFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwCatalogoFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2, Me.RepositoryItemTextEdit1})
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit2.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.RepositoryItemTextEdit2.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                        Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                        Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                        Or DevExpress.Utils.StyleOptions.UseFont) _
                        Or DevExpress.Utils.StyleOptions.UseForeColor) _
                        Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                        Or DevExpress.Utils.StyleOptions.UseImage) _
                        Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                        Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Default, Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit1.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'Cuenta
        '
        Me.Cuenta.Caption = "Cuenta"
        Me.Cuenta.FieldName = "Cuenta"
        Me.Cuenta.Name = "Cuenta"
        Me.Cuenta.VisibleIndex = 2
        Me.Cuenta.Width = 150
        '
        'Prorrateable
        '
        Me.Prorrateable.Caption = "Prorrateable"
        Me.Prorrateable.FieldName = "Prorrateable"
        Me.Prorrateable.Name = "Prorrateable"
        Me.Prorrateable.VisibleIndex = 1
        Me.Prorrateable.Width = 70
        '
        'Descripcion
        '
        Me.Descripcion.Caption = "Descripcion"
        Me.Descripcion.FieldName = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.VisibleIndex = 0
        Me.Descripcion.Width = 100
        '
        'TipoTramtre
        '
        Me.TipoTramtre.FieldName = "TipoTramite"
        Me.TipoTramtre.Name = "TipoTramtre"
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "CentroEmbarcador"
        Me.GridColumn1.FieldName = "CentroEmbarcador"
        Me.GridColumn1.Name = "GridColumn1"
        '
        'Panel2
        '
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdBancos, Me.grdTipMovCaja})
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 520)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1006, 100)
        Me.Panel2.TabIndex = 126
        '
        'grdBancos
        '
        Me.grdBancos.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdBancos.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.grdBancos.EditorsRepository = Me.PersistentRepository1
        Me.grdBancos.Location = New System.Drawing.Point(513, 0)
        Me.grdBancos.MainView = Me.vwBancos
        Me.grdBancos.Name = "grdBancos"
        Me.grdBancos.Size = New System.Drawing.Size(492, 100)
        Me.grdBancos.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(222, Byte), CType(184, Byte), CType(135, Byte)), System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(218, Byte), CType(185, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdBancos.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.None, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Black))
        Me.grdBancos.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("FilterButton", New DevExpress.Utils.ViewStyle("FilterButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.GhostWhite, System.Drawing.SystemColors.ControlText))
        Me.grdBancos.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdBancos.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Arial", 9.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(139, Byte), CType(69, Byte), CType(19, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdBancos.Styles.AddReplace("ColumnFilterButtonPressed", New DevExpress.Utils.ViewStyle("ColumnFilterButtonPressed", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.SystemColors.ControlText, System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdBancos.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdBancos.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("ColumnFilterButton", New DevExpress.Utils.ViewStyle("ColumnFilterButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.SystemColors.ControlText))
        Me.grdBancos.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.ForestGreen))
        Me.grdBancos.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.Navy))
        Me.grdBancos.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(232, Byte), CType(194, Byte), CType(145, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdBancos.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.None, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.ForestGreen))
        Me.grdBancos.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.ForestGreen))
        Me.grdBancos.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.DarkGreen))
        Me.grdBancos.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdBancos.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdBancos.TabIndex = 126
        Me.grdBancos.TabStop = False
        '
        'vwBancos
        '
        Me.vwBancos.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwBancos.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.None
        Me.vwBancos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Bancos, Me.BancoDesc})
        Me.vwBancos.DefaultEdit = Me.RepositoryItemTextEdit2
        Me.vwBancos.GroupPanelText = ""
        Me.vwBancos.Name = "vwBancos"
        Me.vwBancos.ViewOptions = ((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'Bancos
        '
        Me.Bancos.Caption = "Bancos"
        Me.Bancos.FieldName = "Banco"
        Me.Bancos.Name = "Bancos"
        Me.Bancos.Width = 20
        '
        'BancoDesc
        '
        Me.BancoDesc.Caption = "Banco"
        Me.BancoDesc.FieldName = "Descripcion"
        Me.BancoDesc.Name = "BancoDesc"
        Me.BancoDesc.VisibleIndex = 0
        Me.BancoDesc.Width = 492
        '
        'grdTipMovCaja
        '
        Me.grdTipMovCaja.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.grdTipMovCaja.EditorsRepository = Me.PersistentRepository1
        Me.grdTipMovCaja.MainView = Me.vwTipoMovCaja
        Me.grdTipMovCaja.Name = "grdTipMovCaja"
        Me.grdTipMovCaja.Size = New System.Drawing.Size(512, 100)
        Me.grdTipMovCaja.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(222, Byte), CType(184, Byte), CType(135, Byte)), System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(218, Byte), CType(185, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdTipMovCaja.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.None, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Black))
        Me.grdTipMovCaja.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("FilterButton", New DevExpress.Utils.ViewStyle("FilterButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.GhostWhite, System.Drawing.SystemColors.ControlText))
        Me.grdTipMovCaja.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdTipMovCaja.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Arial", 9.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(139, Byte), CType(69, Byte), CType(19, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdTipMovCaja.Styles.AddReplace("ColumnFilterButtonPressed", New DevExpress.Utils.ViewStyle("ColumnFilterButtonPressed", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.SystemColors.ControlText, System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdTipMovCaja.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdTipMovCaja.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("ColumnFilterButton", New DevExpress.Utils.ViewStyle("ColumnFilterButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.SystemColors.ControlText))
        Me.grdTipMovCaja.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.ForestGreen))
        Me.grdTipMovCaja.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.Navy))
        Me.grdTipMovCaja.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(232, Byte), CType(194, Byte), CType(145, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdTipMovCaja.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.None, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.ForestGreen))
        Me.grdTipMovCaja.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.ForestGreen))
        Me.grdTipMovCaja.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.DarkGreen))
        Me.grdTipMovCaja.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdTipMovCaja.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdTipMovCaja.TabIndex = 125
        Me.grdTipMovCaja.TabStop = False
        '
        'vwTipoMovCaja
        '
        Me.vwTipoMovCaja.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwTipoMovCaja.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.None
        Me.vwTipoMovCaja.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TipoMov})
        Me.vwTipoMovCaja.DefaultEdit = Me.RepositoryItemTextEdit2
        Me.vwTipoMovCaja.GroupPanelText = "Detalle del reembolso."
        Me.vwTipoMovCaja.Name = "vwTipoMovCaja"
        Me.vwTipoMovCaja.VertScrollTipFieldName = Nothing
        Me.vwTipoMovCaja.ViewOptions = ((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'TipoMov
        '
        Me.TipoMov.Caption = "Tipo Movimiento Caja"
        Me.TipoMov.FieldName = "Descripcion"
        Me.TipoMov.Name = "TipoMov"
        Me.TipoMov.VisibleIndex = 0
        Me.TipoMov.Width = 500
        '
        'Panel3
        '
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.CatalogoFicha})
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 44)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1006, 476)
        Me.Panel3.TabIndex = 127
        '
        'CatalogoFicha
        '
        Me.CatalogoFicha.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.CatalogoFicha.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CatalogoFicha.EditorsRepository = Me.PersistentRepository1
        Me.CatalogoFicha.MainView = Me.vwCatalogoFicha
        Me.CatalogoFicha.Name = "CatalogoFicha"
        Me.CatalogoFicha.Size = New System.Drawing.Size(1006, 476)
        Me.CatalogoFicha.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(222, Byte), CType(184, Byte), CType(135, Byte)), System.Drawing.SystemColors.ActiveCaption))
        Me.CatalogoFicha.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(218, Byte), CType(185, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.CatalogoFicha.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.None, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Black))
        Me.CatalogoFicha.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("FilterButton", New DevExpress.Utils.ViewStyle("FilterButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.GhostWhite, System.Drawing.SystemColors.ControlText))
        Me.CatalogoFicha.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.CatalogoFicha.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Arial", 9.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(139, Byte), CType(69, Byte), CType(19, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.CatalogoFicha.Styles.AddReplace("ColumnFilterButtonPressed", New DevExpress.Utils.ViewStyle("ColumnFilterButtonPressed", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.SystemColors.ControlText, System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.CatalogoFicha.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.CatalogoFicha.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.SystemColors.ActiveCaption))
        Me.CatalogoFicha.Styles.AddReplace("ColumnFilterButton", New DevExpress.Utils.ViewStyle("ColumnFilterButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.SystemColors.ControlText))
        Me.CatalogoFicha.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.ForestGreen))
        Me.CatalogoFicha.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.Navy))
        Me.CatalogoFicha.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(232, Byte), CType(194, Byte), CType(145, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.CatalogoFicha.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.None, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Gold, System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.ForestGreen))
        Me.CatalogoFicha.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.SystemColors.ControlLightLight, System.Drawing.Color.DarkGreen))
        Me.CatalogoFicha.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.CatalogoFicha.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Tahoma", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightBlue, System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.CatalogoFicha.TabIndex = 125
        Me.CatalogoFicha.TabStop = False
        '
        'vwCatalogoFicha
        '
        Me.vwCatalogoFicha.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwCatalogoFicha.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.None
        Me.vwCatalogoFicha.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TipoFicha, Me.DescFicha, Me.Status, Me.DescCobro, Me.TipoCobro, Me.Automatica, Me.EspecificarBanco})
        Me.vwCatalogoFicha.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwCatalogoFicha.GroupPanelText = "Detalle del reembolso."
        Me.vwCatalogoFicha.Name = "vwCatalogoFicha"
        Me.vwCatalogoFicha.VertScrollTipFieldName = Nothing
        Me.vwCatalogoFicha.ViewOptions = ((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'TipoFicha
        '
        Me.TipoFicha.Caption = "TipoFicha"
        Me.TipoFicha.FieldName = "TipoFicha"
        Me.TipoFicha.Name = "TipoFicha"
        Me.TipoFicha.VisibleIndex = 0
        Me.TipoFicha.Width = 100
        '
        'DescFicha
        '
        Me.DescFicha.Caption = "Descripcion Ficha"
        Me.DescFicha.FieldName = "DescripcionFicha"
        Me.DescFicha.Name = "DescFicha"
        Me.DescFicha.VisibleIndex = 1
        Me.DescFicha.Width = 400
        '
        'Status
        '
        Me.Status.Caption = "Status"
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.VisibleIndex = 2
        Me.Status.Width = 150
        '
        'DescCobro
        '
        Me.DescCobro.Caption = "Descripcion Cobro"
        Me.DescCobro.FieldName = "DescripcionCobro"
        Me.DescCobro.Name = "DescCobro"
        Me.DescCobro.VisibleIndex = 3
        Me.DescCobro.Width = 350
        '
        'TipoCobro
        '
        Me.TipoCobro.Caption = "TipoCobro"
        Me.TipoCobro.FieldName = "TipoCobro"
        Me.TipoCobro.Name = "TipoCobro"
        '
        'Automatica
        '
        Me.Automatica.Caption = "Automatica"
        Me.Automatica.ColumnEdit = Me.RepositoryItemTextEdit1
        Me.Automatica.FieldName = "Automatica"
        Me.Automatica.Name = "Automatica"
        '
        'EspecificarBanco
        '
        Me.EspecificarBanco.Caption = "EspecificarBanco"
        Me.EspecificarBanco.FieldName = "EspecificarBanco"
        Me.EspecificarBanco.Name = "EspecificarBanco"
        '
        'btnAgregar
        '
        Me.btnAgregar.ImageIndex = 0
        Me.btnAgregar.Text = "Agregar"
        '
        'btnModificar
        '
        Me.btnModificar.ImageIndex = 1
        Me.btnModificar.Text = "Modificar"
        '
        'btnEliminar
        '
        Me.btnEliminar.ImageIndex = 2
        Me.btnEliminar.Text = "Eliminar"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 3
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 4
        Me.btnSalir.Text = "Regresar"
        '
        'tlbCatTipFicha
        '
        Me.tlbCatTipFicha.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlbCatTipFicha.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgregar, Me.btnModificar, Me.btnEliminar, Me.ToolBarButton1, Me.btnActualizar, Me.btnSalir})
        Me.tlbCatTipFicha.ButtonSize = New System.Drawing.Size(55, 40)
        Me.tlbCatTipFicha.DropDownArrows = True
        Me.tlbCatTipFicha.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tlbCatTipFicha.ImageList = Me.imlTipoFicha
        Me.tlbCatTipFicha.Name = "tlbCatTipFicha"
        Me.tlbCatTipFicha.ShowToolTips = True
        Me.tlbCatTipFicha.Size = New System.Drawing.Size(1006, 44)
        Me.tlbCatTipFicha.TabIndex = 21
        '
        'imlTipoFicha
        '
        Me.imlTipoFicha.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imlTipoFicha.ImageSize = New System.Drawing.Size(16, 16)
        Me.imlTipoFicha.ImageStream = CType(resources.GetObject("imlTipoFicha.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imlTipoFicha.TransparentColor = System.Drawing.Color.Transparent
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'CatalogoTipoFicha
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1006, 620)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel3, Me.Panel2, Me.tlbCatTipFicha})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "CatalogoTipoFicha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo Ficha"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        CType(Me.grdBancos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwBancos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdTipMovCaja, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwTipoMovCaja, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.CatalogoFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwCatalogoFicha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CatalogoTipoFicha_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Actualizar()
    End Sub

    'Funcion que obtiene la consulta para los datos de TipoFicha
    Private Sub DatosTipoFicha()
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtFicha As New DataTable()
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 1
            cmdCommand.ExecuteNonQuery()
            dtFicha.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtFicha)
            CatalogoFicha.DataSource = dtFicha
            vwCatalogoFicha.ExpandAllGroups()
        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error : " & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Funcion que obtiene la consulta de los datos del tipomovmientocaja para un tipoficha seleccionado
    Private Sub DatosTipoMovimientoCaja()
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtTipoMovCaja As New DataTable()
        Dim TipoFicha As Integer

        Try
            TipoFicha = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("TipoFicha"), Integer)
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 2
            cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha
            cmdCommand.ExecuteNonQuery()
            dtTipoMovCaja.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtTipoMovCaja)
            grdTipMovCaja.DataSource = dtTipoMovCaja
            vwTipoMovCaja.ExpandAllGroups()
            CatalogoFicha.Focus()
        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error : " & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Funcion que obtiene la consulta de los datos de los bancos asociados a un tipoficha seleccionado
    Private Sub DatosBancos()
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim daSelect As New SqlDataAdapter()
        Dim dtBancos As New DataTable()
        Dim TipoFicha As Integer

        Try
            TipoFicha = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("TipoFicha"), Integer)
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "sp_CatalogoTipoFicha"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 3
            cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha
            cmdCommand.ExecuteNonQuery()
            dtBancos.Clear()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtBancos)
            grdBancos.DataSource = dtBancos
            vwBancos.ExpandAllGroups()
            CatalogoFicha.Focus()
        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error : " & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'Funcion que llama a las funciones q consultan los datos del catalogo tipoficha
    Private Sub Actualizar()
        DatosTipoFicha()
        DatosTipoMovimientoCaja()
        DatosBancos()
    End Sub

    Private Sub tlbCatTipFicha_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbCatTipFicha.ButtonClick
        Dim Linea As Integer
        Select Case e.Button.Text
            Case "Agregar"
                Agregar()
                Actualizar()
                Linea = vwCatalogoFicha.RowCount
                vwCatalogoFicha.FocusedRowHandle = Linea - 1
            Case "Modificar"
                Linea = vwCatalogoFicha.FocusedRowHandle
                Modificar()
                Actualizar()
                vwCatalogoFicha.FocusedRowHandle = Linea
            Case "Eliminar" '/*Borra la informacion especificada*/"
                BorrarRegistro()
                Actualizar()
                Linea = 0
                vwCatalogoFicha.FocusedRowHandle = Linea
            Case "Actualizar" '/*Actualizar la infromacion del grid*/
                Actualizar()
            Case "Regresar" '/*Regresa al menu principal*/
                Me.Close()
        End Select
    End Sub

    'funcion que llama a la forma para Agregar un registro de un tipoficha
    Private Sub Agregar()
        Dim frmTipoFicha As TipoFicha = New TipoFicha()
        frmTipoFicha.Entrar()
        frmTipoFicha.ShowDialog()
    End Sub

    'Funcion que llama a la forma para modificar los datos de un registro TipoFicha seleccionado
    Private Sub Modificar()
        Dim frmTipoFicha As TipoFicha = New TipoFicha()
        Dim tipoficha, tipoCobro As Integer
        Dim DescTF, Status As String
        Dim Automatica, EspecBanco As Boolean

        tipoficha = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("TipoFicha"), Integer)
        DescTF = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("DescripcionFicha"), String)
        tipoCobro = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("TipoCobro"), Integer)
        Status = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("Status"), String)
        Automatica = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("Automatica"), Boolean)
        EspecBanco = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("EspecificarBanco"), Boolean)

        frmTipoFicha.Modificar(tipoficha, DescTF, tipoCobro, Status, Automatica, EspecBanco)
        frmTipoFicha.ShowDialog()
    End Sub


    Private Sub peLlenaInfo()
        Dim dtFicha As New DataTable()
        dtFicha.Rows(vwCatalogoFicha.FocusedRowHandle).Item("Status") = "ACTIVO"
    End Sub

    'Funcion que elimina un registro TipoFicha seleccionado
    Private Sub BorrarRegistro()
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
        Dim TipoFicha, TipoCobro As Integer

        Try
            TipoFicha = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("TipoFicha"), Integer)
            TipoCobro = CType(vwCatalogoFicha.GetRow(vwCatalogoFicha.FocusedRowHandle).item("TipoCobro"), Integer)
            If MessageBox.Show("¿Desea eliminar el Tipo de Ficha?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                cmdCommand.CommandType = CommandType.StoredProcedure
                cmdCommand.CommandText = "sp_CatalogoTipoFicha"
                cmdCommand.Parameters.Clear()
                cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 8
                cmdCommand.Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha
                cmdCommand.Parameters.Add("@TipoCobro", SqlDbType.Int).Value = TipoCobro
                cmdCommand.ExecuteNonQuery()
            End If
        Catch e As Exception
            MessageBox.Show("Ha ocurrido el siguiente error : " & e.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    'funcion que cambia el detalle(Tipos de movimientocaja, y bancos asociados) de acuerdo al tipoficha seleccionado
    Private Sub vwCatalogoFicha_FocusedRowChanged(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles vwCatalogoFicha.FocusedRowChanged
        Try
            DatosTipoMovimientoCaja()
            DatosBancos()
        Catch ex As Exception
            MessageBox.Show("Ha ocurrido el siguiente error : " & ex.Message, "Caja", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

End Class

