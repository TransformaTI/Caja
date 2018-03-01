Imports System.Data
Imports System.Data.SqlClient

'2008-001-EIM-01
'REQ 024
'Autor: Ana Juárez
'Agregar comprobante de servicio
Public Class ComprobanteServicio_ed
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private dtSelect As DataTable
    Private dtPapeletas As DataTable
    Private dtFichasDepositoInsertar As DataTable
    Private dtFichasDepositoEliminar As DataTable
    Private dtPlomos As New DataTable()
    Private daSelect As New SqlDataAdapter()
    Private drLeer As SqlDataReader
    Private Total As Decimal
    Private TotalPlomos As Decimal
    Public Modificar As Boolean
    Public Comprobante As Integer
    Private Folio As Integer
    Private EsSeleccionado As Boolean
    Public NumeroCaja As Integer
    Private NumeroFolioPapeleta As Integer
    Private FechaPapeletaDeposito As Date
    Public CorteCajaCerrado As Boolean

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
    Friend WithEvents chkAgregar As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents grdPlomos As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwPlomos As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NumeroPlomo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents MontoPlomo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents txtFolioComprobante As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents txtMachimbradora As System.Windows.Forms.TextBox
    Friend WithEvents cmbProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents FComprobante As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents grdFichasComprobante As DevExpress.XtraGrid.GridControl
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtTotal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents vwFichasComprobante As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Ficha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Descripcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FFicha As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CuentaBanco As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Monto As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FolioPapeleta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents FechaPapeleta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Caja As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents btnAgregarP As System.Windows.Forms.Button
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents riceCalculadora As DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents grdPapeletas As DevExpress.XtraGrid.GridControl
    Friend WithEvents gcTotalPapeleta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcFolioPapeleta As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcAgregar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents gcCaja As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents pbCalculadora As System.Windows.Forms.PictureBox
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents ceCalculadora As DevExpress.XtraEditors.CalcEdit
    Friend WithEvents gbCalculadora As System.Windows.Forms.GroupBox
    Friend WithEvents vwPapeletas As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gcFecha As DevExpress.XtraGrid.Columns.GridColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ComprobanteServicio_ed))
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.chkAgregar = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gbCalculadora = New System.Windows.Forms.GroupBox()
        Me.pbCalculadora = New System.Windows.Forms.PictureBox()
        Me.ceCalculadora = New DevExpress.XtraEditors.CalcEdit()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.grdPlomos = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.riceCalculadora = New DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwPlomos = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NumeroPlomo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.MontoPlomo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnAgregarP = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.grdFichasComprobante = New DevExpress.XtraGrid.GridControl()
        Me.vwFichasComprobante = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Ficha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Descripcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FFicha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CuentaBanco = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Monto = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FolioPapeleta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.FechaPapeleta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Caja = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.grdPapeletas = New DevExpress.XtraGrid.GridControl()
        Me.vwPapeletas = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gcFolioPapeleta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcTotalPapeleta = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcCaja = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcFecha = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.gcAgregar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtTotal = New DevExpress.XtraEditors.TextEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtFolioComprobante = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.cmbCuenta = New System.Windows.Forms.ComboBox()
        Me.txtMachimbradora = New System.Windows.Forms.TextBox()
        Me.cmbProveedor = New System.Windows.Forms.ComboBox()
        Me.FComprobante = New DevExpress.XtraEditors.DateEdit()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        CType(Me.chkAgregar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.gbCalculadora.SuspendLayout()
        CType(Me.ceCalculadora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        CType(Me.grdPlomos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.riceCalculadora, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwPlomos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel8.SuspendLayout()
        CType(Me.grdFichasComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwFichasComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel7.SuspendLayout()
        CType(Me.grdPapeletas, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwPapeletas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        CType(Me.FComprobante, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkAgregar, Me.RepositoryItemTextEdit1})
        '
        'chkAgregar
        '
        Me.chkAgregar.Name = "chkAgregar"
        Me.chkAgregar.Properties.AllowFocused = False
        Me.chkAgregar.Properties.AutoHeight = False
        Me.chkAgregar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.chkAgregar.Properties.CheckAlign = DevExpress.XtraEditors.Controls.CheckAlignStyles.NoText
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
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.gbCalculadora, Me.Panel6, Me.btnEliminar, Me.btnAgregarP})
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 419)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(830, 176)
        Me.Panel2.TabIndex = 35
        '
        'gbCalculadora
        '
        Me.gbCalculadora.Controls.AddRange(New System.Windows.Forms.Control() {Me.pbCalculadora, Me.ceCalculadora})
        Me.gbCalculadora.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbCalculadora.Location = New System.Drawing.Point(600, 40)
        Me.gbCalculadora.Name = "gbCalculadora"
        Me.gbCalculadora.Size = New System.Drawing.Size(208, 120)
        Me.gbCalculadora.TabIndex = 44
        Me.gbCalculadora.TabStop = False
        Me.gbCalculadora.Text = "Calculadora"
        '
        'pbCalculadora
        '
        Me.pbCalculadora.Image = CType(resources.GetObject("pbCalculadora.Image"), System.Drawing.Bitmap)
        Me.pbCalculadora.Location = New System.Drawing.Point(144, 48)
        Me.pbCalculadora.Name = "pbCalculadora"
        Me.pbCalculadora.Size = New System.Drawing.Size(40, 32)
        Me.pbCalculadora.TabIndex = 1
        Me.pbCalculadora.TabStop = False
        '
        'ceCalculadora
        '
        Me.ceCalculadora.Location = New System.Drawing.Point(16, 48)
        Me.ceCalculadora.Name = "ceCalculadora"
        Me.ceCalculadora.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.ceCalculadora.Size = New System.Drawing.Size(120, 21)
        Me.ceCalculadora.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdPlomos})
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(384, 176)
        Me.Panel6.TabIndex = 43
        '
        'grdPlomos
        '
        Me.grdPlomos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPlomos.EditorsRepository = Me.PersistentRepository2
        Me.grdPlomos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPlomos.MainView = Me.vwPlomos
        Me.grdPlomos.Name = "grdPlomos"
        Me.grdPlomos.Size = New System.Drawing.Size(384, 176)
        Me.grdPlomos.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdPlomos.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(207, Byte), CType(175, Byte), CType(183, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPlomos.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(207, Byte), CType(175, Byte), CType(183, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPlomos.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdPlomos.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdPlomos.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPlomos.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Times New Roman", 10.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPlomos.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPlomos.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Green, System.Drawing.Color.FromArgb(CType(128, Byte), CType(255, Byte), CType(128, Byte))))
        Me.grdPlomos.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte)), System.Drawing.Color.FromArgb(CType(221, Byte), CType(221, Byte), CType(221, Byte))))
        Me.grdPlomos.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Blue, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdPlomos.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdPlomos.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Blue, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdPlomos.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(217, Byte), CType(185, Byte), CType(193, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPlomos.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdPlomos.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdPlomos.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(169, Byte), CType(106, Byte), CType(122, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPlomos.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdPlomos.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPlomos.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPlomos.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPlomos.TabIndex = 42
        Me.grdPlomos.Text = "GridControl1"
        '
        'PersistentRepository2
        '
        Me.PersistentRepository2.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.riceCalculadora, Me.RepositoryItemTextEdit3})
        '
        'riceCalculadora
        '
        Me.riceCalculadora.Name = "riceCalculadora"
        Me.riceCalculadora.Properties.AllowFocused = False
        Me.riceCalculadora.Properties.AutoHeight = False
        Me.riceCalculadora.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.riceCalculadora.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.riceCalculadora.Properties.ButtonsBorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit3.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwPlomos
        '
        Me.vwPlomos.BehaviorOptions = (((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.Editable) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.MultiSelect) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwPlomos.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.vwPlomos.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NumeroPlomo, Me.MontoPlomo})
        Me.vwPlomos.DefaultEdit = Me.RepositoryItemTextEdit3
        Me.vwPlomos.GroupPanelText = "Fichas para asignar al Comprobante"
        Me.vwPlomos.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Monto", Me.MontoPlomo, "{0:c}")})
        Me.vwPlomos.Name = "vwPlomos"
        Me.vwPlomos.ViewOptions = (((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'NumeroPlomo
        '
        Me.NumeroPlomo.Caption = "Plomo"
        Me.NumeroPlomo.FieldName = "NumeroPlomo"
        Me.NumeroPlomo.Name = "NumeroPlomo"
        Me.NumeroPlomo.VisibleIndex = 0
        '
        'MontoPlomo
        '
        Me.MontoPlomo.Caption = "Monto"
        Me.MontoPlomo.FieldName = "Monto"
        Me.MontoPlomo.FormatString = "$#,#.00"
        Me.MontoPlomo.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.MontoPlomo.Name = "MontoPlomo"
        Me.MontoPlomo.SummaryItem.DisplayFormat = "{0:c}"
        Me.MontoPlomo.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.MontoPlomo.VisibleIndex = 1
        '
        'btnEliminar
        '
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Bitmap)
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEliminar.Location = New System.Drawing.Point(448, 104)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(80, 48)
        Me.btnEliminar.TabIndex = 8
        Me.btnEliminar.Text = "Eliminar Plomo"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregarP
        '
        Me.btnAgregarP.Image = CType(resources.GetObject("btnAgregarP.Image"), System.Drawing.Bitmap)
        Me.btnAgregarP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarP.Location = New System.Drawing.Point(448, 32)
        Me.btnAgregarP.Name = "btnAgregarP"
        Me.btnAgregarP.Size = New System.Drawing.Size(80, 48)
        Me.btnAgregarP.TabIndex = 7
        Me.btnAgregarP.Text = "Agregar Plomo"
        Me.btnAgregarP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel5
        '
        Me.Panel5.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel3, Me.Panel4, Me.Panel2})
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(830, 595)
        Me.Panel5.TabIndex = 40
        '
        'Panel3
        '
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel8, Me.Splitter1, Me.Panel7, Me.Panel1})
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel3.Location = New System.Drawing.Point(0, 176)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(830, 243)
        Me.Panel3.TabIndex = 41
        '
        'Panel8
        '
        Me.Panel8.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdFichasComprobante})
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel8.Location = New System.Drawing.Point(312, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(518, 203)
        Me.Panel8.TabIndex = 36
        '
        'grdFichasComprobante
        '
        Me.grdFichasComprobante.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFichasComprobante.EditorsRepository = Me.PersistentRepository1
        Me.grdFichasComprobante.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdFichasComprobante.MainView = Me.vwFichasComprobante
        Me.grdFichasComprobante.Name = "grdFichasComprobante"
        Me.grdFichasComprobante.Size = New System.Drawing.Size(518, 203)
        Me.grdFichasComprobante.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(207, Byte), CType(175, Byte), CType(183, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(207, Byte), CType(175, Byte), CType(183, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Ivory, System.Drawing.Color.SeaGreen))
        Me.grdFichasComprobante.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.White))
        Me.grdFichasComprobante.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Times New Roman", 10.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MintCream, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(207, Byte), CType(175, Byte), CType(183, Byte)), System.Drawing.Color.Black))
        Me.grdFichasComprobante.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.SeaGreen))
        Me.grdFichasComprobante.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(217, Byte), CType(185, Byte), CType(193, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.White))
        Me.grdFichasComprobante.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Ivory, System.Drawing.Color.SeaGreen))
        Me.grdFichasComprobante.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(169, Byte), CType(106, Byte), CType(122, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdFichasComprobante.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdFichasComprobante.TabIndex = 39
        Me.grdFichasComprobante.Text = "GridControl1"
        '
        'vwFichasComprobante
        '
        Me.vwFichasComprobante.BehaviorOptions = (((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.Editable) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.MultiSelect) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwFichasComprobante.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.vwFichasComprobante.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Ficha, Me.Descripcion, Me.FFicha, Me.CuentaBanco, Me.Monto, Me.FolioPapeleta, Me.FechaPapeleta, Me.Caja})
        Me.vwFichasComprobante.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwFichasComprobante.GroupPanelText = "Fichas para asignar al Comprobante"
        Me.vwFichasComprobante.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Me.Monto, "{0:c}")})
        Me.vwFichasComprobante.Name = "vwFichasComprobante"
        Me.vwFichasComprobante.ViewOptions = (((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'Ficha
        '
        Me.Ficha.Caption = "Ficha"
        Me.Ficha.FieldName = "Folio"
        Me.Ficha.Name = "Ficha"
        Me.Ficha.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.Ficha.VisibleIndex = 0
        '
        'Descripcion
        '
        Me.Descripcion.Caption = "Descripcion"
        Me.Descripcion.FieldName = "Descripcion"
        Me.Descripcion.Name = "Descripcion"
        Me.Descripcion.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.Descripcion.VisibleIndex = 1
        '
        'FFicha
        '
        Me.FFicha.Caption = "FFicha"
        Me.FFicha.FieldName = "FFicha"
        Me.FFicha.Name = "FFicha"
        Me.FFicha.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.FFicha.VisibleIndex = 2
        '
        'CuentaBanco
        '
        Me.CuentaBanco.Caption = "Cta. Banco"
        Me.CuentaBanco.FieldName = "CuentaBanco"
        Me.CuentaBanco.Name = "CuentaBanco"
        Me.CuentaBanco.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.CuentaBanco.VisibleIndex = 3
        '
        'Monto
        '
        Me.Monto.Caption = "Total"
        Me.Monto.FieldName = "Total"
        Me.Monto.FormatString = "$#,#.00"
        Me.Monto.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.Monto.Name = "Monto"
        Me.Monto.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.Monto.SummaryItem.DisplayFormat = "{0:c}"
        Me.Monto.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.Monto.VisibleIndex = 4
        '
        'FolioPapeleta
        '
        Me.FolioPapeleta.Caption = "F. Papeleta"
        Me.FolioPapeleta.FieldName = "FolioPapeleta"
        Me.FolioPapeleta.Name = "FolioPapeleta"
        Me.FolioPapeleta.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.FolioPapeleta.VisibleIndex = 5
        '
        'FechaPapeleta
        '
        Me.FechaPapeleta.Caption = "FPapeleta"
        Me.FechaPapeleta.FieldName = "Fecha"
        Me.FechaPapeleta.Name = "FechaPapeleta"
        Me.FechaPapeleta.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        '
        'Caja
        '
        Me.Caja.Caption = "Caja"
        Me.Caja.FieldName = "Caja"
        Me.Caja.Name = "Caja"
        Me.Caja.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        '
        'Splitter1
        '
        Me.Splitter1.BackColor = System.Drawing.Color.FromArgb(CType(64, Byte), CType(64, Byte), CType(64, Byte))
        Me.Splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Splitter1.Location = New System.Drawing.Point(304, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(8, 203)
        Me.Splitter1.TabIndex = 35
        Me.Splitter1.TabStop = False
        '
        'Panel7
        '
        Me.Panel7.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdPapeletas})
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(304, 203)
        Me.Panel7.TabIndex = 34
        '
        'grdPapeletas
        '
        Me.grdPapeletas.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdPapeletas.EditorsRepository = Me.PersistentRepository1
        Me.grdPapeletas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdPapeletas.MainView = Me.vwPapeletas
        Me.grdPapeletas.Name = "grdPapeletas"
        Me.grdPapeletas.Size = New System.Drawing.Size(304, 203)
        Me.grdPapeletas.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdPapeletas.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPapeletas.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPapeletas.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Ivory, System.Drawing.Color.SeaGreen))
        Me.grdPapeletas.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.White))
        Me.grdPapeletas.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPapeletas.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Times New Roman", 10.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPapeletas.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.MintCream, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPapeletas.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(224, Byte), CType(224, Byte), CType(224, Byte))))
        Me.grdPapeletas.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.SeaGreen))
        Me.grdPapeletas.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdPapeletas.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPapeletas.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Khaki, System.Drawing.Color.FromArgb(CType(159, Byte), CType(96, Byte), CType(112, Byte))))
        Me.grdPapeletas.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(217, Byte), CType(185, Byte), CType(193, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPapeletas.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.White))
        Me.grdPapeletas.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Ivory, System.Drawing.Color.SeaGreen))
        Me.grdPapeletas.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(169, Byte), CType(106, Byte), CType(122, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPapeletas.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSkyBlue, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPapeletas.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPapeletas.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdPapeletas.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdPapeletas.TabIndex = 40
        Me.grdPapeletas.Text = "grdPapeletas"
        '
        'vwPapeletas
        '
        Me.vwPapeletas.BehaviorOptions = (((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.Editable) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.MultiSelect) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwPapeletas.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.vwPapeletas.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.gcFolioPapeleta, Me.gcTotalPapeleta, Me.gcCaja, Me.gcFecha, Me.gcAgregar})
        Me.vwPapeletas.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwPapeletas.GroupPanelText = "Fichas para asignar al Comprobante"
        Me.vwPapeletas.Name = "vwPapeletas"
        Me.vwPapeletas.VertScrollTipFieldName = Nothing
        Me.vwPapeletas.ViewOptions = ((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'gcFolioPapeleta
        '
        Me.gcFolioPapeleta.Caption = "F. Papeleta"
        Me.gcFolioPapeleta.FieldName = "FolioPapeleta"
        Me.gcFolioPapeleta.Name = "gcFolioPapeleta"
        Me.gcFolioPapeleta.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.gcFolioPapeleta.VisibleIndex = 0
        Me.gcFolioPapeleta.Width = 85
        '
        'gcTotalPapeleta
        '
        Me.gcTotalPapeleta.Caption = "Total"
        Me.gcTotalPapeleta.FieldName = "TotalPapeleta"
        Me.gcTotalPapeleta.FormatString = "$#,#.00"
        Me.gcTotalPapeleta.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.gcTotalPapeleta.Name = "gcTotalPapeleta"
        Me.gcTotalPapeleta.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.gcTotalPapeleta.VisibleIndex = 1
        Me.gcTotalPapeleta.Width = 99
        '
        'gcCaja
        '
        Me.gcCaja.Caption = "Caja"
        Me.gcCaja.FieldName = "Caja"
        Me.gcCaja.Name = "gcCaja"
        Me.gcCaja.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        '
        'gcFecha
        '
        Me.gcFecha.Caption = "Fecha"
        Me.gcFecha.FieldName = "Fecha"
        Me.gcFecha.Name = "gcFecha"
        Me.gcFecha.Options = (((((((DevExpress.XtraGrid.Columns.ColumnOptions.CanFiltered Or DevExpress.XtraGrid.Columns.ColumnOptions.CanMoved) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanGrouped) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanResized) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanSorted) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ReadOnly) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.CanFocused) _
                    Or DevExpress.XtraGrid.Columns.ColumnOptions.ShowInCustomizationForm)
        Me.gcFecha.VisibleIndex = 2
        '
        'gcAgregar
        '
        Me.gcAgregar.Caption = "Agregar"
        Me.gcAgregar.ColumnEdit = Me.chkAgregar
        Me.gcAgregar.FieldName = "Agregar"
        Me.gcAgregar.Name = "gcAgregar"
        Me.gcAgregar.VisibleIndex = 3
        Me.gcAgregar.Width = 72
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtTotal, Me.Label2})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 203)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(830, 40)
        Me.Panel1.TabIndex = 33
        '
        'txtTotal
        '
        Me.txtTotal.Enabled = False
        Me.txtTotal.Location = New System.Drawing.Point(88, 8)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.Properties.DisabledForeColor = System.Drawing.Color.Black
        Me.txtTotal.Properties.Enabled = False
        Me.txtTotal.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                        Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                        Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                        Or DevExpress.Utils.StyleOptions.UseFont) _
                        Or DevExpress.Utils.StyleOptions.UseForeColor) _
                        Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                        Or DevExpress.Utils.StyleOptions.UseImage) _
                        Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                        Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Default, Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtTotal.Size = New System.Drawing.Size(120, 25)
        Me.txtTotal.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkRed
        Me.Label2.Location = New System.Drawing.Point(40, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 15)
        Me.Label2.TabIndex = 35
        Me.Label2.Text = "Total :"
        '
        'Panel4
        '
        Me.Panel4.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFolioComprobante, Me.Label1, Me.btnAceptar, Me.btnCancelar, Me.cmbCuenta, Me.txtMachimbradora, Me.cmbProveedor, Me.FComprobante, Me.Label9, Me.Label5, Me.Label4, Me.Label3})
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(830, 176)
        Me.Panel4.TabIndex = 40
        '
        'txtFolioComprobante
        '
        Me.txtFolioComprobante.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFolioComprobante.Location = New System.Drawing.Point(160, 16)
        Me.txtFolioComprobante.Name = "txtFolioComprobante"
        Me.txtFolioComprobante.Size = New System.Drawing.Size(136, 20)
        Me.txtFolioComprobante.TabIndex = 48
        Me.txtFolioComprobante.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 15)
        Me.Label1.TabIndex = 49
        Me.Label1.Text = "Folio Comprobante :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(664, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(88, 40)
        Me.btnAceptar.TabIndex = 42
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(664, 96)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(88, 40)
        Me.btnCancelar.TabIndex = 43
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCuenta
        '
        Me.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuenta.Location = New System.Drawing.Point(160, 144)
        Me.cmbCuenta.Name = "cmbCuenta"
        Me.cmbCuenta.Size = New System.Drawing.Size(344, 21)
        Me.cmbCuenta.TabIndex = 41
        '
        'txtMachimbradora
        '
        Me.txtMachimbradora.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMachimbradora.Location = New System.Drawing.Point(160, 80)
        Me.txtMachimbradora.MaxLength = 10
        Me.txtMachimbradora.Name = "txtMachimbradora"
        Me.txtMachimbradora.Size = New System.Drawing.Size(136, 20)
        Me.txtMachimbradora.TabIndex = 40
        Me.txtMachimbradora.Text = ""
        '
        'cmbProveedor
        '
        Me.cmbProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbProveedor.Location = New System.Drawing.Point(160, 112)
        Me.cmbProveedor.Name = "cmbProveedor"
        Me.cmbProveedor.Size = New System.Drawing.Size(344, 21)
        Me.cmbProveedor.TabIndex = 38
        '
        'FComprobante
        '
        Me.FComprobante.DateTime = New Date(CType(0, Long))
        Me.FComprobante.Location = New System.Drawing.Point(160, 48)
        Me.FComprobante.Name = "FComprobante"
        Me.FComprobante.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.FComprobante.Size = New System.Drawing.Size(136, 21)
        Me.FComprobante.TabIndex = 39
        '
        'Label9
        '
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(40, 144)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(98, 15)
        Me.Label9.TabIndex = 47
        Me.Label9.Text = "Cuenta Banco :"
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(40, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(110, 15)
        Me.Label5.TabIndex = 46
        Me.Label5.Text = "Machimbradora :"
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(64, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Proveedor :"
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(144, 15)
        Me.Label3.TabIndex = 44
        Me.Label3.Text = "Fecha Comprobante :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'ComprobanteServicio_ed
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(830, 595)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel5})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ComprobanteServicio_ed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobante de Servicio"
        CType(Me.chkAgregar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.gbCalculadora.ResumeLayout(False)
        CType(Me.ceCalculadora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        CType(Me.grdPlomos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.riceCalculadora, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwPlomos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel8.ResumeLayout(False)
        CType(Me.grdFichasComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwFichasComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel7.ResumeLayout(False)
        CType(Me.grdPapeletas, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwPapeletas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.txtTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        CType(Me.FComprobante, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ComprobanteServicio_ed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtSelect = New DataTable()
        dtPapeletas = New DataTable()
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSProveedor"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtSelect)
        cmbProveedor.DataSource = dtSelect
        cmbProveedor.ValueMember = "Proveedor"
        cmbProveedor.DisplayMember = "RazonSocial"
        dtSelect = New DataTable()
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSCuentaBanco"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtSelect)
        cmbCuenta.DataSource = dtSelect
        cmbCuenta.ValueMember = "CuentaBanco"
        cmbCuenta.DisplayMember = "Descripcion"
        'Try
        '    cmbCuenta.SelectedValue = "4686365"
        'Catch
        'End Try
        'Para los plomos
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSSelectPlomosComprobante"
        cmdCommand.Parameters.Clear()
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtPlomos)
        dtPlomos.Clear()
        grdPlomos.DataSource = dtPlomos
        If Modificar Then
            Me.Text = "Modificación de Comprobante de Servicio"
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSDatosComprobante"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comprobante
            drLeer = cmdCommand.ExecuteReader
            drLeer.Read()
            txtFolioComprobante.Text = drLeer("FolioComprobante").ToString()
            txtTotal.Text = drLeer("Total").ToString
            cmbProveedor.SelectedValue = drLeer("Proveedor")
            FComprobante.DateTime = CType(drLeer("FComprobanteServicio"), Date)
            txtMachimbradora.Text = drLeer("Machimbradora").ToString()
            cmbCuenta.SelectedValue = drLeer("CuentaBanco")
            drLeer.Close()
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSSelectPlomosComprobante"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comprobante
            cmdCommand.ExecuteNonQuery()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtPlomos)
            grdPlomos.DataSource = dtPlomos
            dtSelect = New DataTable()

            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSSelectPapeletas"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = NumeroCaja
            cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comprobante
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtPapeletas)

            grdPapeletas.DataSource = dtPapeletas
            CalculaTotal()
        Else
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSConsecutivoComprobante"
            cmdCommand.Parameters.Clear()
            drLeer = cmdCommand.ExecuteReader
            drLeer.Read()
            Comprobante = CType(drLeer("Consecutivo"), Integer)
            drLeer.Close()
            FComprobante.DateTime = Now
            dtSelect = New DataTable()

            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSSelectPapeletas"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = NumeroCaja
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtPapeletas)
            grdPapeletas.DataSource = dtPapeletas

            txtTotal.Text = "0"
        End If
        'dtSelect.DefaultView.RowFilter = "CuentaBanco=" & cmbCuenta.SelectedValue
        vwFichasComprobante.ExpandAllGroups()
        CalculaTotal()
    End Sub

    Function CalculaTotal() As Boolean
        Dim i As Integer
        Dim j As Boolean
        Total = 0
        For i = 0 To vwPapeletas.TotalRowCount - 1
            j = CType(vwPapeletas.GetRow(i).item("Agregar"), Boolean)
            If j Then
                Total = Total + CType(vwPapeletas.GetRow(i).item("TotalPapeleta"), Decimal)
            End If
            txtTotal.Text = Total.ToString("C")
        Next
        TotalPlomos = 0
        Try
            For i = 0 To vwPlomos.TotalRowCount - 1
                TotalPlomos = TotalPlomos + CType(vwPlomos.GetRow(i).item("Monto"), Decimal)

            Next
            Return True
        Catch
            MessageBox.Show("El monto de los plomos no tiene un valor apropiado, por favor verifique", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Return False
        End Try
    End Function


    Private Sub chkAgregar_QueryValueByCheckState(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.QueryValueByCheckStateEventArgs) Handles chkAgregar.QueryValueByCheckState
        Try
            If e.CheckState = CheckState.Checked Then
                vwPapeletas.GetRow(vwPapeletas.FocusedRowHandle).item("Agregar") = True
            Else
                vwPapeletas.GetRow(vwPapeletas.FocusedRowHandle).item("Agregar") = False
            End If
            Dim i As Integer
            Dim j As Boolean
            Total = 0
            For i = 0 To vwPapeletas.TotalRowCount - 1
                j = CType(vwPapeletas.GetRow(i).item("Agregar"), Boolean)
                If j Then
                    Total = Total + CType(vwPapeletas.GetRow(i).item("TotalPapeleta"), Decimal)
                End If
                txtTotal.Text = Total.ToString("C")
            Next

        Catch e1 As Exception
            MsgBox(e1.Message)
        End Try
    End Sub

    Private Sub cmbCuenta_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCuenta.SelectionChangeCommitted
        'dtSelect.Clear()
        'daSelect.Fill(dtSelect)
        'grdFichasComprobante.DataSource = dtSelect
        'dtSelect.DefaultView.RowFilter = "CuentaBanco=" & cmbCuenta.SelectedValue
        'CalculaTotal()
        'vwFichasComprobante.ExpandAllGroups()
    End Sub

    Private Sub grdFichasComprobante_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        CalculaTotal()
    End Sub

    Private Sub btnAgregarP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarP.Click

        Dim Plomos(1) As Object
        Plomos(0) = ""
        Plomos(1) = 0

        dtPlomos.Rows.Add(Plomos)
        grdPlomos.DataSource = dtPlomos
        'btnAgregarP.Enabled = False

    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        Dim numero As String
        If vwPlomos.RowCount = 0 Then
            MessageBox.Show("No hay plomos para eliminar", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        Try
            numero = dtPlomos.Rows(vwPlomos.FocusedRowHandle).Item("NumeroPlomo").ToString()
            dtPlomos.Rows(vwPlomos.FocusedRowHandle).Delete()
        Catch errordelete As Exception
            MessageBox.Show("Debe elegir un plomo para eliminarlo.", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End Try
        grdPlomos.DataSource = dtPlomos

        If Modificar Then

            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSEliminaPlomo"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comprobante
            cmdCommand.Parameters.Add("@NumeroPlomo", SqlDbType.VarChar).Value = numero
            'dtPlomos.Rows(vwPlomos.FocusedRowHandle).Item("NumeroPlomo")
            'vwPlomos.GetRow(vwPlomos.FocusedRowHandle).item("NumeroPlomo")
            'CType(vwPlomos.GetRow(vwPlomos.FocusedRowHandle).item("NumeroPlomo"), String)()
            cmdCommand.ExecuteNonQuery()
        End If


    End Sub
    Private Sub vwPlomos_InvalidValueException(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.InvalidValueExceptionEventArgs)
        vwPlomos.DeleteRow(vwPlomos.FocusedRowHandle)
        MessageBox.Show("Por favor escriba solo cantidades en el monto de los plomos", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        e.DisplayError() = False
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Close()
    End Sub


    '2008-001-EIM-01
    'REQ 153
    'Autor: Ana Juárez
    'modificar o agregar comporbantes de servicio
    Private Sub btnAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Dim Consecutivo As Integer = 0
        ''Dim Contador As Integer

        If CorteCajaCerrado = True Then
            MessageBox.Show("No se puede modificar un comprobante de servicio que contiene " + vbCrLf _
                           + "papeletas que son de un corte de caja ya cerrado", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If vwPapeletas.RowCount <= 0 Then
            MessageBox.Show("No se tienen fichas deposito para agregar", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End If

        If CalculaTotal() = False Then
            Exit Sub
        End If

        If txtFolioComprobante.Text = "" Then
            MessageBox.Show("Debe escribir el Folio del comprobante", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If txtMachimbradora.Text = "" Then
            MessageBox.Show("Debe dar la Machimbradora", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If Total <> TotalPlomos Then
            MessageBox.Show("La suma de los plomos es de $" & TotalPlomos.ToString & " y no coincide con el total del comprobante", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        If MessageBox.Show("El total del comprobante No. " & Comprobante.ToString & " es de  $" & Total.ToString & Chr(13) & "¿Desea continuar?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.No Then
            Exit Sub
        End If



        Dim Transaccion As SqlClient.SqlTransaction
        Transaccion = dmModulo.SqlConnection.BeginTransaction
        cmdCommand.Transaction = Transaccion
        Try

            If Modificar Then
                ModificaComprobante()

            Else
                InsertaComprobante()
            End If

            If Modificar Then
                'Inserción de Varios Plomos  
                Dim i As Integer
                For i = 0 To vwPlomos.TotalRowCount - 1
                    ModificaPlomo(CType(vwPlomos.GetRow(i).item("NumeroPlomo"), String), _
                                  CType(vwPlomos.GetRow(i).item("Monto"), Decimal), _
                                  Comprobante)
                Next
            Else
                'Inserción de Varios Plomos  
                Dim i As Integer
                For i = 0 To vwPlomos.TotalRowCount - 1
                    InsertaPlomo(CType(vwPlomos.GetRow(i).item("NumeroPlomo"), String), _
                                 CType(vwPlomos.GetRow(i).item("Monto"), Decimal))
                Next
            End If
            Transaccion.Commit()
        Catch er As Exception
            Transaccion.Rollback()
            MessageBox.Show("No se pudo agregar el comprobante debio a lo siguiente:" + vbCrLf + er.Message, "Agregar comprobante servicio", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Exit Sub
        End Try
        Transaccion.Dispose()
        Close()
    End Sub

    '2008-001-EIM-01
    'REQ 024
    'Autor: Ana Juárez
    'Método que permite modificar un comprobante
    Private Sub InsertaComprobante()
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSInsertaComprobante"

        cmdCommand.Parameters.Clear()

        cmdCommand.Parameters.Add("@FolioComprobante", SqlDbType.VarChar).Value = txtFolioComprobante.Text
        cmdCommand.Parameters.Add("@TotalComprobante", SqlDbType.Money).Value = Total
        cmdCommand.Parameters.Add("@Proveedor", SqlDbType.Int).Value = cmbProveedor.SelectedValue
        cmdCommand.Parameters.Add("@FComprobante", SqlDbType.DateTime).Value = FComprobante.DateTime
        cmdCommand.Parameters.Add("@Machimbradora", SqlDbType.VarChar).Value = txtMachimbradora.Text
        cmdCommand.Parameters.Add("@Cuenta", SqlDbType.VarChar).Value = cmbCuenta.SelectedValue
        cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Direction = ParameterDirection.Output

        cmdCommand.ExecuteNonQuery()

        InsertaComprobanteServicioPapeleta(CType(cmdCommand.Parameters.Item("@Consecutivo").Value, Integer))

    End Sub

    'Método que permite modificar un comprobante
    Private Sub ModificaComprobante()

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSModificaComprobante"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comprobante

        cmdCommand.Parameters.Add("@FolioComprobante", SqlDbType.VarChar).Value = txtFolioComprobante.Text
        cmdCommand.Parameters.Add("@TotalComprobante", SqlDbType.Money).Value = Total
        cmdCommand.Parameters.Add("@Proveedor", SqlDbType.Int).Value = cmbProveedor.SelectedValue
        cmdCommand.Parameters.Add("@FComprobante", SqlDbType.DateTime).Value = FComprobante.DateTime
        cmdCommand.Parameters.Add("@Machimbradora", SqlDbType.VarChar).Value = txtMachimbradora.Text
        cmdCommand.Parameters.Add("@Cuenta", SqlDbType.VarChar).Value = cmbCuenta.SelectedValue
        cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.SmallInt).Value = CType(vwFichasComprobante.GetRow(vwFichasComprobante.FocusedRowHandle).item("FolioPapeleta"), Integer)
        cmdCommand.Parameters.Add("@FechaPapeleta", SqlDbType.DateTime).Value = CType(vwFichasComprobante.GetRow(vwFichasComprobante.FocusedRowHandle).item("Fecha"), DateTime)
        cmdCommand.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = CType(vwFichasComprobante.GetRow(vwFichasComprobante.FocusedRowHandle).item("Caja"), Integer)
        cmdCommand.Parameters.Add("@FolioFicha", SqlDbType.Int).Value = CType(vwFichasComprobante.GetRow(vwFichasComprobante.FocusedRowHandle).item("Folio"), Integer)

        cmdCommand.ExecuteNonQuery()


        EliminaComprobanteServicioPapeleta(Comprobante)

        InsertaComprobanteServicioPapeleta(Comprobante)

    End Sub

    '2008-001-EIM-01
    'REQ 152
    'Autor: Ana Juárez
    'Método que permite Insertar un comprobante de servicio papeleta
    Private Sub InsertaComprobanteServicioPapeleta(ByVal Consecutivo As Integer)
        Dim ContadorPapeletas As Integer
        Dim ContadorFichas As Integer
        dtFichasDepositoInsertar = New DataTable()
        For ContadorPapeletas = 0 To vwPapeletas.TotalRowCount - 1
            If vwPapeletas.GetRow(ContadorPapeletas).item("Agregar") = True Then

                Try
                    dtFichasDepositoInsertar.Clear()
                Catch
                End Try

                cmdCommand.CommandType = CommandType.StoredProcedure
                cmdCommand.CommandText = "spSSSelectFichaComprobante"
                cmdCommand.Parameters.Clear()
                cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = NumeroCaja
                cmdCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = 0
                cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.Int).Value = vwPapeletas.GetRow(ContadorPapeletas).item("FolioPapeleta")
                cmdCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = vwPapeletas.GetRow(ContadorPapeletas).item("Fecha")
                daSelect.SelectCommand = cmdCommand
                daSelect.Fill(dtFichasDepositoInsertar)

                For ContadorFichas = 0 To dtFichasDepositoInsertar.Rows.Count - 1

                    cmdCommand.CommandType = CommandType.StoredProcedure
                    cmdCommand.CommandText = "spSSInsertaComprobanteServicioPapeleta"
                    cmdCommand.Parameters.Clear()
                    cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.Int).Value = CType(dtFichasDepositoInsertar.Rows(ContadorFichas).Item("FolioPapeleta"), Integer)
                    cmdCommand.Parameters.Add("@FechaPapeleta", SqlDbType.DateTime).Value = CType(dtFichasDepositoInsertar.Rows(ContadorFichas).Item("Fecha"), DateTime)
                    cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = CType(dtFichasDepositoInsertar.Rows(ContadorFichas).Item("Caja"), Integer)
                    cmdCommand.Parameters.Add("@FolioFicha", SqlDbType.Int).Value = CType(dtFichasDepositoInsertar.Rows(ContadorFichas).Item("Folio"), Integer)
                    cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Consecutivo
                    cmdCommand.ExecuteNonQuery()
                Next
            End If
        Next
    End Sub

    '2008-001-EIM-01
    'REQ 152
    'Autor: Ana Juárez
    'Método que permite eliminar un comprobante de servicio papeleta
    Private Sub EliminaComprobanteServicioPapeleta(ByVal Consecutivo As Integer)
        Dim ContadorPapeletas As Integer
        Dim ContadorFichas As Integer
        dtFichasDepositoEliminar = New DataTable()
        For ContadorPapeletas = 0 To vwPapeletas.TotalRowCount - 1
            If vwPapeletas.GetRow(ContadorPapeletas).item("Agregar") = False Then

                Try
                    dtFichasDepositoEliminar.Clear()
                Catch
                End Try

                cmdCommand.CommandType = CommandType.StoredProcedure
                cmdCommand.CommandText = "spSSSelectFichaComprobante"
                cmdCommand.Parameters.Clear()
                cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = NumeroCaja
                cmdCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = 0
                cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.Int).Value = vwPapeletas.GetRow(ContadorPapeletas).item("FolioPapeleta")
                cmdCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = vwPapeletas.GetRow(ContadorPapeletas).item("Fecha")
                daSelect.SelectCommand = cmdCommand
                daSelect.Fill(dtFichasDepositoEliminar)


                For ContadorFichas = 0 To dtFichasDepositoEliminar.Rows.Count - 1
                    cmdCommand.CommandType = CommandType.StoredProcedure
                    cmdCommand.CommandText = "spSSEliminaComprobanteServicioPapeleta"
                    cmdCommand.Parameters.Clear()
                    cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.Int).Value = CType(dtFichasDepositoEliminar.Rows(ContadorFichas).Item("FolioPapeleta"), Integer)
                    cmdCommand.Parameters.Add("@FechaPapeleta", SqlDbType.DateTime).Value = CType(dtFichasDepositoEliminar.Rows(ContadorFichas).Item("Fecha"), DateTime)
                    cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = CType(dtFichasDepositoEliminar.Rows(ContadorFichas).Item("Caja"), Integer)
                    cmdCommand.Parameters.Add("@FolioFicha", SqlDbType.Int).Value = CType(dtFichasDepositoEliminar.Rows(ContadorFichas).Item("Folio"), Integer)
                    cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Consecutivo
                    cmdCommand.ExecuteNonQuery()
                Next
            End If
        Next
    End Sub

    'Método que permite modificar un plomo
    Private Sub ModificaPlomo(ByVal NumeroPlomo As String, ByVal MontoPlomo As Decimal, ByVal Comprobante As Integer)
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSModificaPlomo"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@NumeroPlomo", SqlDbType.VarChar).Value = NumeroPlomo
        cmdCommand.Parameters.Add("@MontoPlomo", SqlDbType.Money).Value = MontoPlomo
        cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = Comprobante
        cmdCommand.ExecuteNonQuery()
    End Sub

    'Método que permite insertar un plomo
    Private Sub InsertaPlomo(ByVal NumeroPlomo As String, ByVal MontoPlomo As Decimal)
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSInsertaPlomo"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@NumeroPlomo", SqlDbType.VarChar).Value = NumeroPlomo
        cmdCommand.Parameters.Add("@MontoPlomo", SqlDbType.Money).Value = MontoPlomo
        cmdCommand.ExecuteNonQuery()
    End Sub

    Private Sub vwPlomos_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles vwPlomos.Click
        grdPlomos.DataSource = dtPlomos
    End Sub

    Private Sub vwPlomos_HiddenEditor(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vwPlomos.HiddenEditor
        Dim Plomo As String
        Dim Monto As Decimal

        Try
            Plomo = CType(vwPlomos.GetDataRow(vwPlomos.FocusedRowHandle).Item(0), String)
        Catch
            Plomo = ""

        End Try

        Try
            Monto = CType(vwPlomos.GetDataRow(vwPlomos.FocusedRowHandle).Item(1), Decimal)
        Catch
            Monto = Nothing
        End Try

        If Plomo = "" And Monto = Nothing Then
            dtPlomos.Rows.RemoveAt(vwPlomos.FocusedRowHandle)
            vwPlomos.FocusedRowHandle = -1
        End If

        'If Plomo <> "" Or Monto <> Nothing Then
        '    btnAgregarP.Enabled = True
        'End If

        vwPlomos.FocusedRowHandle = -1

    End Sub

    'Private Sub riceCalculadora_QueryCloseUp(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles riceCalculadora.QueryCloseUp

    'End Sub

    'Private Sub riceCalculadora_GiveFeedback(ByVal sender As System.Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles riceCalculadora.GiveFeedback

    'End Sub

    'Private Sub riceCalculadora_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles riceCalculadora.ValueChanged
    '    If sender.EditValueCore() = Nothing Then
    '        dtPlomos.Rows(vwPlomos.FocusedRowHandle).Item(1) = 0
    '        sender.EditValueCore() = 0
    '    Else
    '        dtPlomos.Rows(vwPlomos.FocusedRowHandle).Item(1) = sender.EditValueCore()
    '    End If
    'End Sub

    'Private Sub riceCalculadora_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles riceCalculadora.Enter
    '    If sender.EditValueCore() = Nothing Then
    '        dtPlomos.Rows(vwPlomos.FocusedRowHandle).Item(1) = 0
    '        sender.EditValueCore() = 0
    '    Else
    '        dtPlomos.Rows(vwPlomos.FocusedRowHandle).Item(1) = sender.EditValueCore()
    '    End If
    'End Sub


    Private Sub vwPapeletas_FocusedRowChanged(ByVal sender As System.Object, ByVal e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles vwPapeletas.FocusedRowChanged
        Try
            NumeroFolioPapeleta = CType(vwPapeletas.GetRow(vwPapeletas.FocusedRowHandle).item("FolioPapeleta").ToString(), Integer)
            FechaPapeletaDeposito = CType(vwPapeletas.GetRow(vwPapeletas.FocusedRowHandle).item("Fecha"), Date)
        Catch
            NumeroFolioPapeleta = 0
        End Try
        DetallePapeleta()
    End Sub

    Private Sub DetallePapeleta()

        Try
            dtSelect.Clear()
        Catch
        End Try
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSSelectFichaComprobante"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = NumeroCaja
        cmdCommand.Parameters.Add("@Tipo", SqlDbType.Int).Value = 0
        cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.Int).Value = NumeroFolioPapeleta
        cmdCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = FechaPapeletaDeposito
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtSelect)

        grdFichasComprobante.DataSource = dtSelect
        CalculaTotal()

    End Sub

End Class
