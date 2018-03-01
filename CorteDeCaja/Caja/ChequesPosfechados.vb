Imports System.Data
Imports System.Data.SqlClient

Public Class ChequesPosfechados
    Inherits System.Windows.Forms.Form
    Public VGM_MontoPendiente As Decimal
    Public VGM_MontoTipoFicha As Decimal
    Public daSelect As New SqlDataAdapter()
    Public dtChequesPosfechados As New DataTable()
    Public dtChequesAplicados As New DataTable()
    Public cmdCommand As SqlClient.SqlCommand = dmModulo.SqlConnection.CreateCommand
    Public VGN_TipoFicha As Integer
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
    Friend WithEvents imgMain As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblDatos As System.Windows.Forms.Label
    Friend WithEvents dtFechaOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents lblMontoPendiente As System.Windows.Forms.Label
    Friend WithEvents grdChequesPosfechadosV As DevExpress.XtraGrid.GridControl
    Friend WithEvents grdChequesAplicados As DevExpress.XtraGrid.GridControl
    Friend WithEvents cmbTipoFicha As System.Windows.Forms.ComboBox
    Friend WithEvents btnDesAplicar As System.Windows.Forms.Button
    Friend WithEvents bbtAplicar As System.Windows.Forms.Button
    Friend WithEvents vwChequesPosfechadosV As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents vwChequesAplicados As DevExpress.XtraGrid.Views.Grid.GridView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ChequesPosfechados))
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblMontoPendiente = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipoFicha = New System.Windows.Forms.ComboBox()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.lblDatos = New System.Windows.Forms.Label()
        Me.dtFechaOperacion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.grdChequesPosfechadosV = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwChequesPosfechadosV = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnDesAplicar = New System.Windows.Forms.Button()
        Me.bbtAplicar = New System.Windows.Forms.Button()
        Me.grdChequesAplicados = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwChequesAplicados = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.grdChequesPosfechadosV, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwChequesPosfechadosV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.grdChequesAplicados, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwChequesAplicados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'imgMain
        '
        Me.imgMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgMain.ImageStream = CType(resources.GetObject("imgMain.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.MintCream
        Me.Panel2.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblMontoPendiente, Me.Label2, Me.cmbTipoFicha, Me.btnSalir, Me.lblDatos, Me.dtFechaOperacion, Me.Label1})
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(536, 104)
        Me.Panel2.TabIndex = 7
        '
        'lblMontoPendiente
        '
        Me.lblMontoPendiente.BackColor = System.Drawing.Color.FloralWhite
        Me.lblMontoPendiente.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMontoPendiente.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoPendiente.ForeColor = System.Drawing.Color.Red
        Me.lblMontoPendiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblMontoPendiente.Location = New System.Drawing.Point(9, 71)
        Me.lblMontoPendiente.Name = "lblMontoPendiente"
        Me.lblMontoPendiente.Size = New System.Drawing.Size(392, 23)
        Me.lblMontoPendiente.TabIndex = 32
        Me.lblMontoPendiente.Text = "Monto máximo a disminuir"
        Me.lblMontoPendiente.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(8, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 15)
        Me.Label2.TabIndex = 31
        Me.Label2.Text = "Efectivo  :"
        '
        'cmbTipoFicha
        '
        Me.cmbTipoFicha.Enabled = False
        Me.cmbTipoFicha.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoFicha.Items.AddRange(New Object() {"Liquidacion del día", "Cobranza"})
        Me.cmbTipoFicha.Location = New System.Drawing.Point(80, 37)
        Me.cmbTipoFicha.Name = "cmbTipoFicha"
        Me.cmbTipoFicha.Size = New System.Drawing.Size(192, 22)
        Me.cmbTipoFicha.TabIndex = 30
        '
        'btnSalir
        '
        Me.btnSalir.BackColor = System.Drawing.SystemColors.ControlLight
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Bitmap)
        Me.btnSalir.Location = New System.Drawing.Point(472, 56)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(56, 32)
        Me.btnSalir.TabIndex = 29
        '
        'lblDatos
        '
        Me.lblDatos.AutoSize = True
        Me.lblDatos.BackColor = System.Drawing.Color.MintCream
        Me.lblDatos.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDatos.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblDatos.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDatos.Location = New System.Drawing.Point(416, 14)
        Me.lblDatos.Name = "lblDatos"
        Me.lblDatos.Size = New System.Drawing.Size(114, 16)
        Me.lblDatos.TabIndex = 28
        Me.lblDatos.Text = "CORTE DE CAJA "
        Me.lblDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtFechaOperacion
        '
        Me.dtFechaOperacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaOperacion.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtFechaOperacion.Location = New System.Drawing.Point(80, 8)
        Me.dtFechaOperacion.Name = "dtFechaOperacion"
        Me.dtFechaOperacion.Size = New System.Drawing.Size(96, 22)
        Me.dtFechaOperacion.TabIndex = 27
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 15)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Fecha :"
        '
        'Panel1
        '
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdChequesPosfechadosV})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 104)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(536, 144)
        Me.Panel1.TabIndex = 8
        '
        'grdChequesPosfechadosV
        '
        Me.grdChequesPosfechadosV.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChequesPosfechadosV.EditorsRepository = Me.PersistentRepository1
        Me.grdChequesPosfechadosV.MainView = Me.vwChequesPosfechadosV
        Me.grdChequesPosfechadosV.Name = "grdChequesPosfechadosV"
        Me.grdChequesPosfechadosV.Size = New System.Drawing.Size(536, 144)
        Me.grdChequesPosfechadosV.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))))
        Me.grdChequesPosfechadosV.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdChequesPosfechadosV.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightYellow, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(58, Byte), CType(110, Byte), CType(165, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdChequesPosfechadosV.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Blue, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightYellow, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdChequesPosfechadosV.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.SteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdChequesPosfechadosV.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.MediumSlateBlue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGray, System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesPosfechadosV.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdChequesPosfechadosV.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdChequesPosfechadosV.TabIndex = 7
        Me.grdChequesPosfechadosV.Text = "GridControl1"
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
        'vwChequesPosfechadosV
        '
        Me.vwChequesPosfechadosV.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwChequesPosfechadosV.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11})
        Me.vwChequesPosfechadosV.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwChequesPosfechadosV.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {New DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.None, Nothing, "", Nothing, Nothing, Nothing, False), New DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.None, Nothing, "", Nothing, Nothing, Nothing, False)})
        Me.vwChequesPosfechadosV.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Nothing, "{0:c}")})
        Me.vwChequesPosfechadosV.Name = "vwChequesPosfechadosV"
        Me.vwChequesPosfechadosV.PrintOptions = (((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllDetails) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines)
        Me.vwChequesPosfechadosV.ViewOptions = ((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
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
        Me.GridColumn1.Caption = "Tipo Movimiento"
        Me.GridColumn1.FieldName = "Descripcion"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.VisibleIndex = 0
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Banco"
        Me.GridColumn2.FieldName = "BancoD"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Cheque"
        Me.GridColumn3.FieldName = "numerocheque"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.VisibleIndex = 2
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Monto"
        Me.GridColumn4.FieldName = "total"
        Me.GridColumn4.FormatString = "$#,#.00"
        Me.GridColumn4.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn4.SummaryItem.FieldName = "Total"
        Me.GridColumn4.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "GridColumn8"
        Me.GridColumn8.FieldName = "TipoFicha"
        Me.GridColumn8.Name = "GridColumn8"
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "GridColumn9"
        Me.GridColumn9.FieldName = "AñoCobro"
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "GridColumn10"
        Me.GridColumn10.FieldName = "Cobro"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "GridColumn11"
        Me.GridColumn11.FieldName = "Banco"
        Me.GridColumn11.Name = "GridColumn11"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.HighlightText
        Me.Panel3.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnDesAplicar, Me.bbtAplicar})
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 248)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(536, 56)
        Me.Panel3.TabIndex = 9
        '
        'btnDesAplicar
        '
        Me.btnDesAplicar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesAplicar.Image = CType(resources.GetObject("btnDesAplicar.Image"), System.Drawing.Bitmap)
        Me.btnDesAplicar.Location = New System.Drawing.Point(304, 10)
        Me.btnDesAplicar.Name = "btnDesAplicar"
        Me.btnDesAplicar.Size = New System.Drawing.Size(50, 38)
        Me.btnDesAplicar.TabIndex = 32
        Me.btnDesAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bbtAplicar
        '
        Me.bbtAplicar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bbtAplicar.Image = CType(resources.GetObject("bbtAplicar.Image"), System.Drawing.Bitmap)
        Me.bbtAplicar.Location = New System.Drawing.Point(185, 10)
        Me.bbtAplicar.Name = "bbtAplicar"
        Me.bbtAplicar.Size = New System.Drawing.Size(50, 38)
        Me.bbtAplicar.TabIndex = 33
        Me.bbtAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grdChequesAplicados
        '
        Me.grdChequesAplicados.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdChequesAplicados.EditorsRepository = Me.PersistentRepository2
        Me.grdChequesAplicados.Location = New System.Drawing.Point(0, 304)
        Me.grdChequesAplicados.MainView = Me.vwChequesAplicados
        Me.grdChequesAplicados.Name = "grdChequesAplicados"
        Me.grdChequesAplicados.Size = New System.Drawing.Size(536, 174)
        Me.grdChequesAplicados.Styles.AddReplace("Preview", New DevExpress.Utils.ViewStyle("Preview", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Top, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(128, Byte))))
        Me.grdChequesAplicados.Styles.AddReplace("FooterPanel", New DevExpress.Utils.ViewStyle("FooterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(192, Byte), CType(192, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdChequesAplicados.Styles.AddReplace("GroupButton", New DevExpress.Utils.ViewStyle("GroupButton", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightYellow, System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("EvenRow", New DevExpress.Utils.ViewStyle("EvenRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("HideSelectionRow", New DevExpress.Utils.ViewStyle("HideSelectionRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("PressedColumn", New DevExpress.Utils.ViewStyle("PressedColumn", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "HeaderPanel", ((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("GroupPanel", New DevExpress.Utils.ViewStyle("GroupPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(58, Byte), CType(110, Byte), CType(165, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdChequesAplicados.Styles.AddReplace("Empty", New DevExpress.Utils.ViewStyle("Empty", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.White, System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("HeaderPanel", New DevExpress.Utils.ViewStyle("HeaderPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.Blue, System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("GroupRow", New DevExpress.Utils.ViewStyle("GroupRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightYellow, System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("HorzLine", New DevExpress.Utils.ViewStyle("HorzLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightSteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdChequesAplicados.Styles.AddReplace("FocusedRow", New DevExpress.Utils.ViewStyle("FocusedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("VertLine", New DevExpress.Utils.ViewStyle("VertLine", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.SteelBlue, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte))))
        Me.grdChequesAplicados.Styles.AddReplace("GroupFooter", New DevExpress.Utils.ViewStyle("GroupFooter", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Far, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("FocusedCell", New DevExpress.Utils.ViewStyle("FocusedCell", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("OddRow", New DevExpress.Utils.ViewStyle("OddRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.LightGoldenrodYellow, System.Drawing.Color.MediumSlateBlue))
        Me.grdChequesAplicados.Styles.AddReplace("SelectedRow", New DevExpress.Utils.ViewStyle("SelectedRow", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseImage), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("FocusedGroup", New DevExpress.Utils.ViewStyle("FocusedGroup", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "FocusedRow", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("Row", New DevExpress.Utils.ViewStyle("Row", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", DevExpress.Utils.StyleOptions.StyleEnabled, True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(192, Byte)), System.Drawing.Color.Blue))
        Me.grdChequesAplicados.Styles.AddReplace("FilterPanel", New DevExpress.Utils.ViewStyle("FilterPanel", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Near, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(128, Byte), CType(128, Byte), CType(128, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(255, Byte))))
        Me.grdChequesAplicados.Styles.AddReplace("DetailTip", New DevExpress.Utils.ViewStyle("DetailTip", "GridView", New System.Drawing.Font("Microsoft Sans Serif", 8.0!), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                            Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                            Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                            Or DevExpress.Utils.StyleOptions.UseFont) _
                            Or DevExpress.Utils.StyleOptions.UseForeColor) _
                            Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                            Or DevExpress.Utils.StyleOptions.UseImage) _
                            Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                            Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Center, Nothing, System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(225, Byte)), System.Drawing.Color.FromArgb(CType(0, Byte), CType(0, Byte), CType(0, Byte))))
        Me.grdChequesAplicados.TabIndex = 10
        Me.grdChequesAplicados.Text = "GridControl1"
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
        'vwChequesAplicados
        '
        Me.vwChequesAplicados.BehaviorOptions = (((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
                    Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary)
        Me.vwChequesAplicados.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn5, Me.GridColumn7, Me.GridColumn6, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14})
        Me.vwChequesAplicados.DefaultEdit = Me.RepositoryItemTextEdit2
        Me.vwChequesAplicados.FormatConditions.AddRange(New DevExpress.XtraGrid.StyleFormatCondition() {New DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.None, Nothing, "", Nothing, Nothing, Nothing, False), New DevExpress.XtraGrid.StyleFormatCondition(DevExpress.XtraGrid.FormatConditionEnum.None, Nothing, "", Nothing, Nothing, Nothing, False)})
        Me.vwChequesAplicados.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Nothing, "{0:c}")})
        Me.vwChequesAplicados.Name = "vwChequesAplicados"
        Me.vwChequesAplicados.PrintOptions = (((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllDetails) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines)
        Me.vwChequesAplicados.ViewOptions = ((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
                    Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle)
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Tipo Ficha"
        Me.GridColumn5.FieldName = "DescripcionTipoF"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Cheque"
        Me.GridColumn7.FieldName = "Cheque"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.VisibleIndex = 1
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Monto"
        Me.GridColumn6.FieldName = "Monto"
        Me.GridColumn6.FormatString = "$#,#.00"
        Me.GridColumn6.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn6.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn6.VisibleIndex = 2
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "GridColumn12"
        Me.GridColumn12.FieldName = "TipoFicha"
        Me.GridColumn12.Name = "GridColumn12"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "GridColumn13"
        Me.GridColumn13.FieldName = "AñoCobro"
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "GridColumn14"
        Me.GridColumn14.FieldName = "Cobro"
        Me.GridColumn14.Name = "GridColumn14"
        '
        'ChequesPosfechados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(536, 478)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.grdChequesAplicados, Me.Panel3, Me.Panel1, Me.Panel2})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "ChequesPosfechados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Cheques Posfechados"
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.grdChequesPosfechadosV, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwChequesPosfechadosV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.grdChequesAplicados, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwChequesAplicados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Entrar(ByVal TipoFicha As Integer, ByVal Monto As Decimal)
        VGN_TipoFicha = TipoFicha
        VGM_MontoTipoFicha = Monto
        If VGN_TipoFicha = 1 Then
            cmbTipoFicha.SelectedIndex = 0
        Else
            cmbTipoFicha.SelectedIndex = 1
        End If

        CargaChequesPosfechadoV()
        CargaChequesAplicados()
        Me.dtFechaOperacion.Enabled = False
        lblDatos.Text = "CAJA = " & CType(dmModulo.VGN_Caja, String) & "   FOLIO = " & CType(VGN_Consecutivo, String)
        Me.ShowDialog()
    End Sub

    Public Sub CargaChequesPosfechadoV()
        Try
            dtChequesPosfechados.Clear()
        Catch
        End Try

        Try

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSChequesPosfechadosV"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            End With

            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtChequesPosfechados)

            grdChequesPosfechadosV.DataSource = dtChequesPosfechados

        Catch
        End Try
    End Sub

    Public Sub CargaChequesAplicados()
        Try
            dtChequesAplicados.Clear()
        Catch
        End Try

        Try

            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSChequesAplicados"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            End With

            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtChequesAplicados)

            grdChequesAplicados.DataSource = dtChequesAplicados

        Catch

        End Try
    End Sub

    Public Sub AplicaCheque()
        Try
            dmModulo.MontoPendienteTipoFicha(VGN_TipoFicha, False, CType(vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("total").ToString().Trim, Decimal), VGM_MontoPendiente)
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSAplicaCheque"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
                .Parameters.Add("@Cheque", SqlDbType.Char).Value = vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("numerocheque")
                .Parameters.Add("@Banco", SqlDbType.Int).Value = vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("Banco")
                .Parameters.Add("@AñoCobro", SqlDbType.Int).Value = vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("AñoCobro")
                .Parameters.Add("@Cobro", SqlDbType.Int).Value = vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("cobro")
                .Parameters.Add("@Monto", SqlDbType.Money).Value = vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("total")
                .ExecuteNonQuery()
            End With
        Catch ER As Exception
            MessageBox.Show(ER.Message & " " & vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("numerocheque").ToString().Trim)
        End Try

    End Sub

    Public Sub EliminaChequeAplicado()
        With cmdCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spSSEliminaChequeAplicado"
            .Parameters.Clear()
            .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
            .Parameters.Add("@Cheque", SqlDbType.Char).Value = vwChequesAplicados.GetRow(vwChequesAplicados.FocusedRowHandle).item("Cheque")
            .Parameters.Add("@AñoCobro", SqlDbType.Int).Value = vwChequesAplicados.GetRow(vwChequesAplicados.FocusedRowHandle).item("AñoCobro")
            .Parameters.Add("@Cobro", SqlDbType.Int).Value = vwChequesAplicados.GetRow(vwChequesAplicados.FocusedRowHandle).item("Cobro")
            .Parameters.Add("@Monto", SqlDbType.Int).Value = vwChequesAplicados.GetRow(vwChequesAplicados.FocusedRowHandle).item("Monto")
            .ExecuteNonQuery()
        End With
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub


    Public Sub MontoADisminuir(ByVal TipoFicha As Integer)
        VGM_MontoPendiente = dmModulo.MontoPendienteTipoFicha(TipoFicha, True, 0, 0)
        lblMontoPendiente.Text = "Monto máximo a disminuir = " & VGM_MontoPendiente.ToString("c")

        If (VGM_MontoPendiente <> -1) Then
            lblMontoPendiente.Text = "Monto máximo a disminuir = " & VGM_MontoPendiente.ToString("c")
        Else
            'En este caso, se insertaria como primera vez el MONTO PENDIENTE DE ESTE TIPO DE FICHA
            'En el caso de que VGN_TipoFicha <> 0, quiere decir que se va a insertar una ficha multiple
            VGM_MontoPendiente = VGM_MontoTipoFicha
            lblMontoPendiente.Text = "Monto máximo a disminuir = " & VGM_MontoPendiente.ToString("c")
        End If

    End Sub


    Private Sub cmbTipoFicha_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoFicha.SelectedIndexChanged
        If cmbTipoFicha.SelectedIndex = 0 Then
            Me.VGN_TipoFicha = 1
            MontoADisminuir(VGN_TipoFicha)
        Else
            Me.VGN_TipoFicha = 7
            MontoADisminuir(VGN_TipoFicha)
        End If
    End Sub

    Private Sub bbtAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bbtAplicar.Click
        If (vwChequesPosfechadosV.RowCount > 0) Then
            If (VGM_MontoPendiente > 0) Then
                If MessageBox.Show("¿Desea disminuir de " & cmbTipoFicha.Text & " el cheque " & _
                                   vwChequesPosfechadosV.GetRow(vwChequesPosfechadosV.FocusedRowHandle).item("numerocheque").ToString().Trim & " ?", "Caja", _
                                   MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    AplicaCheque()
                    MontoADisminuir(VGN_TipoFicha)
                    Me.CargaChequesPosfechadoV()
                    Me.CargaChequesAplicados()
                Else
                    MessageBox.Show("No se puede realizar la operación. Verifique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Else
                MessageBox.Show("No tiene monto disponible para APLICAR el cheque. Verifique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub btnDesAplicar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDesAplicar.Click
        If vwChequesAplicados.RowCount > 0 Then
            Me.EliminaChequeAplicado()
            MontoADisminuir(VGN_TipoFicha)
            Me.CargaChequesPosfechadoV()
            Me.CargaChequesAplicados()
        Else
            MessageBox.Show("No hay cheques para regresar como NO APLICADOS. Verifique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class
