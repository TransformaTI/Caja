'***************************************
'Modifico: Santiago Mendoza Carlos Nirari
'Fecha: 19-09-2017 al 31-10-2017
'Descripcion: Adecuacion relacionada a las fichas de deposito configurables, esta adecuacion comparte modificaciones con la vista  frmFichaDepositoConfigurable.vb
'Identificador de Cambios: -$CNSM19092017
'***************************************

Imports System.Data.SqlClient
Imports System.Data
Imports CrystalDecisions.Shared.Json

Public Class MovimientosCajaDesglozados
    Inherits System.Windows.Forms.Form

    Private cmdCommand As SqlClient.SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private daSelect As New SqlDataAdapter()
    Private dtDesgloce As New DataTable()
    Private rdrSelect As SqlDataReader
    Private dtFichaEfectivo As New DataTable()
    Private dtAcumulado As New DataTable()
    Private dtFichasDepositoCaja As New DataTable()
    Private dtFichasAcumuladas As New DataTable()
    Private VGN_TipoCorte As Integer
    Private VGN_Folio As Integer
    Private VGN_MontoAplicado As Decimal
    Private Caja As Integer
    Private intPapeletaMaxima As Integer
    Private Papeleta As Integer
    Private Fecha As DateTime
    Private Folio As Integer
    Private TipoTablaAcumulado, TipoTablaAutomaticas As String
    Private blnAgregarAlCorte As Boolean
    Private dcmTotalAcumulados, dcmTotalAutomaticos As Decimal

    'Guardamos los registros que seran procesados en la asociacion de MovimientoCajaFichaDeposito
    Private  dtMovimientoCaja AS DataTable
    


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
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
    Friend WithEvents btnEliminar As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtFechaFicha As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents lblTipoCorte As System.Windows.Forms.Label
    Friend WithEvents mnuFichasAutomaticas As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents lblFolioCorte As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Panel7 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel10 As System.Windows.Forms.Panel
    Friend WithEvents grdFichasDeposito As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFichasDeposito As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdcFichaDeposito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcMovimiento As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcTipo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents Panel6 As System.Windows.Forms.Panel
    Friend WithEvents Panel9 As System.Windows.Forms.Panel
    Friend WithEvents Panel5 As System.Windows.Forms.Panel
    Friend WithEvents grdFichaEfectivo As DevExpress.XtraGrid.GridControl
    Friend WithEvents Panel8 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents vwFichaEfectivo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents grdMontoporTipo As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwMontoporTipo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Tipo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents Splitter4 As System.Windows.Forms.Splitter
    Friend WithEvents grdFichaDepositoCorte As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFichaDepositoCorte As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel13 As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuFichasDeposito As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuFichasAcumuladas As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents imgMain As System.Windows.Forms.ImageList
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PersistentRepository3 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PersistentRepository4 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BotonEliminar As System.Windows.Forms.ContextMenu
    Friend WithEvents mnFichaDep As System.Windows.Forms.MenuItem
    Friend WithEvents mnPapeleta As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MovimientosCajaDesglozados))
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
        Dim ColumnFilterInfo18 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo19 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo20 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo17 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Me.ToolBar1 = New System.Windows.Forms.ToolBar()
        Me.btnEliminar = New System.Windows.Forms.ToolBarButton()
        Me.BotonEliminar = New System.Windows.Forms.ContextMenu()
        Me.mnFichaDep = New System.Windows.Forms.MenuItem()
        Me.mnPapeleta = New System.Windows.Forms.MenuItem()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblFolioCorte = New System.Windows.Forms.Label()
        Me.lblTipoCorte = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.dtFechaFicha = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.mnuFichasDeposito = New System.Windows.Forms.ContextMenu()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.mnuFichasAutomaticas = New System.Windows.Forms.ContextMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.mnuFichasAcumuladas = New System.Windows.Forms.ContextMenu()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.grdFichasDeposito = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwFichasDeposito = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdcFichaDeposito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcMovimiento = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTipo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Splitter4 = New System.Windows.Forms.Splitter()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.grdFichaDepositoCorte = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwFichaDepositoCorte = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel13 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.grdMontoporTipo = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository3 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwMontoporTipo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Tipo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Splitter3 = New System.Windows.Forms.Splitter()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.grdFichaEfectivo = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository4 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwFichaEfectivo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel1.SuspendLayout
        Me.Panel3.SuspendLayout
        Me.Panel10.SuspendLayout
        CType(Me.grdFichasDeposito,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vwFichasDeposito,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel7.SuspendLayout
        Me.Panel11.SuspendLayout
        Me.Panel12.SuspendLayout
        CType(Me.grdFichaDepositoCorte,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit2,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vwFichaDepositoCorte,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel13.SuspendLayout
        Me.Panel4.SuspendLayout
        CType(Me.grdMontoporTipo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit3,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vwMontoporTipo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel2.SuspendLayout
        Me.Panel6.SuspendLayout
        Me.Panel5.SuspendLayout
        CType(Me.grdFichaEfectivo,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.RepositoryItemTextEdit4,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.vwFichaEfectivo,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel8.SuspendLayout
        Me.SuspendLayout
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnEliminar, Me.ToolBarButton1, Me.btnImprimir, Me.ToolBarButton4, Me.btnActualizar, Me.btnSalir})
        Me.ToolBar1.ButtonSize = New System.Drawing.Size(60, 40)
        Me.ToolBar1.DropDownArrows = true
        Me.ToolBar1.ImageList = Me.imgMain
        Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = true
        Me.ToolBar1.Size = New System.Drawing.Size(1028, 50)
        Me.ToolBar1.TabIndex = 1
        '
        'btnEliminar
        '
        Me.btnEliminar.DropDownMenu = Me.BotonEliminar
        Me.btnEliminar.ImageIndex = 9
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        Me.btnEliminar.Text = "Eliminar"
        '
        'BotonEliminar
        '
        Me.BotonEliminar.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnFichaDep, Me.mnPapeleta})
        '
        'mnFichaDep
        '
        Me.mnFichaDep.Index = 0
        Me.mnFichaDep.Text = "Ficha Deposito"
        '
        'mnPapeleta
        '
        Me.mnPapeleta.Index = 1
        Me.mnPapeleta.Text = "Papeleta"
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
        'ToolBarButton4
        '
        Me.ToolBarButton4.Name = "ToolBarButton4"
        Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnActualizar
        '
        Me.btnActualizar.ImageIndex = 4
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 5
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Salir"
        '
        'imgMain
        '
        Me.imgMain.ImageStream = CType(resources.GetObject("imgMain.ImageStream"),System.Windows.Forms.ImageListStreamer)
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
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.lblFolioCorte)
        Me.Panel1.Controls.Add(Me.lblTipoCorte)
        Me.Panel1.Controls.Add(Me.lblCaja)
        Me.Panel1.Controls.Add(Me.dtFechaFicha)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 50)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1028, 29)
        Me.Panel1.TabIndex = 40
        '
        'lblFolioCorte
        '
        Me.lblFolioCorte.AutoSize = true
        Me.lblFolioCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblFolioCorte.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblFolioCorte.Location = New System.Drawing.Point(327, 6)
        Me.lblFolioCorte.Name = "lblFolioCorte"
        Me.lblFolioCorte.Size = New System.Drawing.Size(55, 20)
        Me.lblFolioCorte.TabIndex = 49
        Me.lblFolioCorte.Text = "Caja :"
        Me.lblFolioCorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTipoCorte
        '
        Me.lblTipoCorte.AutoSize = true
        Me.lblTipoCorte.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTipoCorte.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblTipoCorte.Location = New System.Drawing.Point(677, 6)
        Me.lblTipoCorte.Name = "lblTipoCorte"
        Me.lblTipoCorte.Size = New System.Drawing.Size(55, 20)
        Me.lblTipoCorte.TabIndex = 48
        Me.lblTipoCorte.Text = "Caja :"
        Me.lblTipoCorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaja
        '
        Me.lblCaja.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblCaja.Font = New System.Drawing.Font("Microsoft Sans Serif", 18!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCaja.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblCaja.Location = New System.Drawing.Point(884, 0)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(144, 29)
        Me.lblCaja.TabIndex = 47
        Me.lblCaja.Text = "Caja :"
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtFechaFicha
        '
        Me.dtFechaFicha.Enabled = false
        Me.dtFechaFicha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFicha.Location = New System.Drawing.Point(72, 4)
        Me.dtFechaFicha.Name = "dtFechaFicha"
        Me.dtFechaFicha.Size = New System.Drawing.Size(104, 20)
        Me.dtFechaFicha.TabIndex = 46
        Me.dtFechaFicha.Value = New Date(2005, 6, 3, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.BackColor = System.Drawing.SystemColors.Control
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(9, 7)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 16)
        Me.Label3.TabIndex = 45
        Me.Label3.Text = "Fecha :"
        '
        'mnuFichasDeposito
        '
        Me.mnuFichasDeposito.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem3, Me.MenuItem4})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Desgloce"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Cambio de cheques"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Cheques posfechados "
        '
        'mnuFichasAutomaticas
        '
        Me.mnuFichasAutomaticas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem5})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Agregar al corte"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 1
        Me.MenuItem5.Text = "Desgloce"
        '
        'mnuFichasAcumuladas
        '
        Me.mnuFichasAcumuladas.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6})
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "Agregar al corte"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel10)
        Me.Panel3.Controls.Add(Me.Panel7)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 79)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(320, 642)
        Me.Panel3.TabIndex = 42
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.grdFichasDeposito)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel10.Location = New System.Drawing.Point(0, 40)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(320, 602)
        Me.Panel10.TabIndex = 14
        '
        'grdFichasDeposito
        '
        Me.grdFichasDeposito.ContextMenu = Me.mnuFichasAutomaticas
        Me.grdFichasDeposito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFichasDeposito.EditorsRepository = Me.PersistentRepository1
        Me.grdFichasDeposito.Location = New System.Drawing.Point(0, 0)
        Me.grdFichasDeposito.MainView = Me.vwFichasDeposito
        Me.grdFichasDeposito.Name = "grdFichasDeposito"
        Me.grdFichasDeposito.Size = New System.Drawing.Size(320, 602)
        Me.grdFichasDeposito.TabIndex = 14
        Me.grdFichasDeposito.Text = "GridControl1"
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1})
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.Properties.AllowFocused = false
        Me.RepositoryItemTextEdit1.Properties.AutoHeight = false
        Me.RepositoryItemTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwFichasDeposito
        '
        Me.vwFichasDeposito.BehaviorOptions = CType(((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.MultiSelect)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary),DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwFichasDeposito.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.grdcFichaDeposito, Me.grdcMovimiento, Me.grdcTipo, Me.grdcTotal, Me.GridColumn9, Me.GridColumn13, Me.GridColumn14})
        Me.vwFichasDeposito.DefaultEdit = Me.RepositoryItemTextEdit1
        Me.vwFichasDeposito.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Me.grdcTotal, "{0:c}")})
        Me.vwFichasDeposito.Name = "vwFichasDeposito"
        Me.vwFichasDeposito.PrintOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllDetails)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines),DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags)
        Me.vwFichasDeposito.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle),DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'grdcFichaDeposito
        '
        Me.grdcFichaDeposito.FieldName = "Ficha"
        Me.grdcFichaDeposito.FilterInfo = ColumnFilterInfo1
        Me.grdcFichaDeposito.Name = "grdcFichaDeposito"
        Me.grdcFichaDeposito.SortOrder = DevExpress.XtraGrid.ColumnSortOrder.Ascending
        '
        'grdcMovimiento
        '
        Me.grdcMovimiento.Caption = "MovimientoCaja"
        Me.grdcMovimiento.FieldName = "MovimientoCaja"
        Me.grdcMovimiento.FilterInfo = ColumnFilterInfo2
        Me.grdcMovimiento.GroupIndex = 0
        Me.grdcMovimiento.Name = "grdcMovimiento"
        '
        'grdcTipo
        '
        Me.grdcTipo.Caption = "Tipo"
        Me.grdcTipo.FieldName = "Descripcion"
        Me.grdcTipo.FilterInfo = ColumnFilterInfo3
        Me.grdcTipo.Name = "grdcTipo"
        Me.grdcTipo.VisibleIndex = 0
        Me.grdcTipo.Width = 140
        '
        'grdcTotal
        '
        Me.grdcTotal.Caption = "Total"
        Me.grdcTotal.FieldName = "Total"
        Me.grdcTotal.FilterInfo = ColumnFilterInfo4
        Me.grdcTotal.FormatString = "$#,#.00"
        Me.grdcTotal.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcTotal.Name = "grdcTotal"
        Me.grdcTotal.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcTotal.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcTotal.VisibleIndex = 1
        Me.grdcTotal.Width = 150
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "TipoFicha"
        Me.GridColumn9.FieldName = "TipoFicha"
        Me.GridColumn9.FilterInfo = ColumnFilterInfo5
        Me.GridColumn9.Name = "GridColumn9"
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "TipoMovimientoCaja"
        Me.GridColumn13.FieldName = "TipoMovimientoCaja"
        Me.GridColumn13.FilterInfo = ColumnFilterInfo6
        Me.GridColumn13.Name = "GridColumn13"
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "TipoCobro"
        Me.GridColumn14.FieldName = "TipoCobro"
        Me.GridColumn14.FilterInfo = ColumnFilterInfo7
        Me.GridColumn14.Name = "GridColumn14"
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.LightGray
        Me.Panel7.Controls.Add(Me.Label1)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel7.Location = New System.Drawing.Point(0, 0)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(320, 40)
        Me.Panel7.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Navy
        Me.Label1.Location = New System.Drawing.Point(-12, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(344, 40)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Fichas de depósito AUTOMÁTICAS"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Splitter4)
        Me.Panel11.Controls.Add(Me.Panel12)
        Me.Panel11.Controls.Add(Me.Panel4)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(320, 79)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(708, 642)
        Me.Panel11.TabIndex = 43
        '
        'Splitter4
        '
        Me.Splitter4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter4.Location = New System.Drawing.Point(0, 304)
        Me.Splitter4.Name = "Splitter4"
        Me.Splitter4.Size = New System.Drawing.Size(708, 3)
        Me.Splitter4.TabIndex = 50
        Me.Splitter4.TabStop = false
        '
        'Panel12
        '
        Me.Panel12.Controls.Add(Me.grdFichaDepositoCorte)
        Me.Panel12.Controls.Add(Me.Panel13)
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel12.Location = New System.Drawing.Point(0, 304)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(708, 338)
        Me.Panel12.TabIndex = 49
        '
        'grdFichaDepositoCorte
        '
        Me.grdFichaDepositoCorte.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFichaDepositoCorte.EditorsRepository = Me.PersistentRepository2
        Me.grdFichaDepositoCorte.Location = New System.Drawing.Point(0, 32)
        Me.grdFichaDepositoCorte.MainView = Me.vwFichaDepositoCorte
        Me.grdFichaDepositoCorte.Name = "grdFichaDepositoCorte"
        Me.grdFichaDepositoCorte.Size = New System.Drawing.Size(708, 306)
        Me.grdFichaDepositoCorte.TabIndex = 55
        Me.grdFichaDepositoCorte.Text = "GridControl1"
        '
        'PersistentRepository2
        '
        Me.PersistentRepository2.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit2})
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.Properties.AllowFocused = false
        Me.RepositoryItemTextEdit2.Properties.AutoHeight = false
        Me.RepositoryItemTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwFichaDepositoCorte
        '
        Me.vwFichaDepositoCorte.BehaviorOptions = CType(((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.MultiSelect)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary),DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwFichaDepositoCorte.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn2, Me.GridColumn7, Me.GridColumn10, Me.GridColumn8, Me.GridColumn6, Me.GridColumn11, Me.GridColumn12})
        Me.vwFichaDepositoCorte.DefaultEdit = Me.RepositoryItemTextEdit2
        Me.vwFichaDepositoCorte.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Me.GridColumn8, "{0:c}")})
        Me.vwFichaDepositoCorte.Name = "vwFichaDepositoCorte"
        Me.vwFichaDepositoCorte.PrintOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllDetails)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines),DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags)
        Me.vwFichaDepositoCorte.VertScrollTipFieldName = Nothing
        Me.vwFichaDepositoCorte.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle),DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Folio"
        Me.GridColumn2.FieldName = "Folio"
        Me.GridColumn2.FilterInfo = ColumnFilterInfo8
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.VisibleIndex = 0
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Tipo"
        Me.GridColumn7.FieldName = "Tipo"
        Me.GridColumn7.FilterInfo = ColumnFilterInfo9
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.VisibleIndex = 1
        Me.GridColumn7.Width = 140
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Cuenta banco"
        Me.GridColumn10.FieldName = "CuentaBanco"
        Me.GridColumn10.FilterInfo = ColumnFilterInfo10
        Me.GridColumn10.MinWidth = 100
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.VisibleIndex = 2
        Me.GridColumn10.Width = 100
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Total"
        Me.GridColumn8.FieldName = "Total"
        Me.GridColumn8.FilterInfo = ColumnFilterInfo11
        Me.GridColumn8.FormatString = "$#,#.00"
        Me.GridColumn8.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn8.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn8.VisibleIndex = 3
        Me.GridColumn8.Width = 150
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "NumeroCheque"
        Me.GridColumn6.FilterInfo = ColumnFilterInfo12
        Me.GridColumn6.Name = "GridColumn6"
        '
        'GridColumn11
        '
        Me.GridColumn11.FieldName = "TipoFicha"
        Me.GridColumn11.FilterInfo = ColumnFilterInfo13
        Me.GridColumn11.Name = "GridColumn11"
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Folio Papeleta"
        Me.GridColumn12.FieldName = "FolioPapeleta"
        Me.GridColumn12.FilterInfo = ColumnFilterInfo14
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.VisibleIndex = 4
        Me.GridColumn12.Width = 90
        '
        'Panel13
        '
        Me.Panel13.BackColor = System.Drawing.Color.LavenderBlush
        Me.Panel13.Controls.Add(Me.Label5)
        Me.Panel13.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel13.Location = New System.Drawing.Point(0, 0)
        Me.Panel13.Name = "Panel13"
        Me.Panel13.Size = New System.Drawing.Size(708, 32)
        Me.Panel13.TabIndex = 54
        '
        'Label5
        '
        Me.Label5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Navy
        Me.Label5.Location = New System.Drawing.Point(0, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(708, 32)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Fichas de depósito del corte de caja"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer))
        Me.Panel4.Controls.Add(Me.grdMontoporTipo)
        Me.Panel4.Controls.Add(Me.Panel2)
        Me.Panel4.Controls.Add(Me.Splitter3)
        Me.Panel4.Controls.Add(Me.Panel6)
        Me.Panel4.Controls.Add(Me.Panel5)
        Me.Panel4.Controls.Add(Me.Splitter2)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel4.Location = New System.Drawing.Point(0, 0)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(708, 304)
        Me.Panel4.TabIndex = 48
        '
        'grdMontoporTipo
        '
        Me.grdMontoporTipo.ContextMenu = Me.mnuFichasAcumuladas
        Me.grdMontoporTipo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdMontoporTipo.EditorsRepository = Me.PersistentRepository3
        Me.grdMontoporTipo.Location = New System.Drawing.Point(355, 40)
        Me.grdMontoporTipo.MainView = Me.vwMontoporTipo
        Me.grdMontoporTipo.Name = "grdMontoporTipo"
        Me.grdMontoporTipo.Size = New System.Drawing.Size(353, 264)
        Me.grdMontoporTipo.TabIndex = 49
        Me.grdMontoporTipo.Text = "grdMontoporTipo"
        '
        'PersistentRepository3
        '
        Me.PersistentRepository3.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit3})
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.Properties.AllowFocused = false
        Me.RepositoryItemTextEdit3.Properties.AutoHeight = false
        Me.RepositoryItemTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwMontoporTipo
        '
        Me.vwMontoporTipo.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary),DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwMontoporTipo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Tipo, Me.GridColumn3, Me.GridColumn15})
        Me.vwMontoporTipo.DefaultEdit = Me.RepositoryItemTextEdit3
        Me.vwMontoporTipo.Name = "vwMontoporTipo"
        Me.vwMontoporTipo.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowForFocusedRow
        Me.vwMontoporTipo.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle),DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'Tipo
        '
        Me.Tipo.Caption = "Tipo"
        Me.Tipo.FieldName = "Tipo"
        Me.Tipo.FilterInfo = ColumnFilterInfo15
        Me.Tipo.Name = "Tipo"
        Me.Tipo.VisibleIndex = 0
        Me.Tipo.Width = 140
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Total"
        Me.GridColumn3.FieldName = "Total"
        Me.GridColumn3.FilterInfo = ColumnFilterInfo16
        Me.GridColumn3.FormatString = "$#,##.00"
        Me.GridColumn3.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn3.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn3.VisibleIndex = 1
        Me.GridColumn3.Width = 150
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(355, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(353, 40)
        Me.Panel2.TabIndex = 47
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Navy
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(353, 40)
        Me.Label4.TabIndex = 47
        Me.Label4.Text = "Fichas de depósito para ACUMULADAS"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Splitter3
        '
        Me.Splitter3.Location = New System.Drawing.Point(352, 0)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(3, 304)
        Me.Splitter3.TabIndex = 46
        Me.Splitter3.TabStop = false
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Panel6.Controls.Add(Me.Panel9)
        Me.Panel6.Location = New System.Drawing.Point(824, 0)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(224, 304)
        Me.Panel6.TabIndex = 45
        '
        'Panel9
        '
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel9.Location = New System.Drawing.Point(0, 0)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(224, 40)
        Me.Panel9.TabIndex = 11
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.Panel5.Controls.Add(Me.grdFichaEfectivo)
        Me.Panel5.Controls.Add(Me.Panel8)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel5.Location = New System.Drawing.Point(3, 0)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(349, 304)
        Me.Panel5.TabIndex = 43
        '
        'grdFichaEfectivo
        '
        Me.grdFichaEfectivo.ContextMenu = Me.mnuFichasDeposito
        Me.grdFichaEfectivo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFichaEfectivo.EditorsRepository = Me.PersistentRepository4
        Me.grdFichaEfectivo.Location = New System.Drawing.Point(0, 40)
        Me.grdFichaEfectivo.MainView = Me.vwFichaEfectivo
        Me.grdFichaEfectivo.Name = "grdFichaEfectivo"
        Me.grdFichaEfectivo.Size = New System.Drawing.Size(349, 264)
        Me.grdFichaEfectivo.TabIndex = 15
        Me.grdFichaEfectivo.Text = "GridControl1"
        '
        'PersistentRepository4
        '
        Me.PersistentRepository4.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit4})
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        Me.RepositoryItemTextEdit4.Properties.AllowFocused = false
        Me.RepositoryItemTextEdit4.Properties.AutoHeight = false
        Me.RepositoryItemTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwFichaEfectivo
        '
        Me.vwFichaEfectivo.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup)  _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary),DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwFichaEfectivo.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn4, Me.GridColumn5})
        Me.vwFichaEfectivo.DefaultEdit = Me.RepositoryItemTextEdit4
        Me.vwFichaEfectivo.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Total", Me.GridColumn5, "{0:c}")})
        Me.vwFichaEfectivo.Name = "vwFichaEfectivo"
        Me.vwFichaEfectivo.PrintOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllGroups)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.ExpandAllDetails)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintGroupFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHeader)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintHorzLines)  _
            Or DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags.PrintVertLines),DevExpress.XtraGrid.Views.Grid.PrintOptionsFlags)
        Me.vwFichaEfectivo.VertScrollTipFieldName = Nothing
        Me.vwFichaEfectivo.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons)  _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle),DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "GridColumn1"
        Me.GridColumn1.FieldName = "Tipo"
        Me.GridColumn1.FilterInfo = ColumnFilterInfo18
        Me.GridColumn1.Name = "GridColumn1"
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Tipo"
        Me.GridColumn4.FieldName = "Concepto"
        Me.GridColumn4.FilterInfo = ColumnFilterInfo19
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.VisibleIndex = 0
        Me.GridColumn4.Width = 140
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Total"
        Me.GridColumn5.FieldName = "MontoTotal"
        Me.GridColumn5.FilterInfo = ColumnFilterInfo20
        Me.GridColumn5.FormatString = "$#,#.00"
        Me.GridColumn5.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn5.SummaryItem.FieldName = "Total"
        Me.GridColumn5.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn5.VisibleIndex = 1
        Me.GridColumn5.Width = 150
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.Label2)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel8.Location = New System.Drawing.Point(0, 0)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(349, 40)
        Me.Panel8.TabIndex = 14
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Navy
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(349, 40)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Fichas de depósito de EFECTIVO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(0, 0)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 304)
        Me.Splitter2.TabIndex = 42
        Me.Splitter2.TabStop = false
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(320, 79)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 642)
        Me.Splitter1.TabIndex = 44
        Me.Splitter1.TabStop = false
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "TipoCobro"
        Me.GridColumn15.FieldName = "TipoCobro"
        Me.GridColumn15.FilterInfo = ColumnFilterInfo17
        Me.GridColumn15.Name = "GridColumn15"
        '
        'MovimientosCajaDesglozados
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1028, 721)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel11)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolBar1)
        Me.Name = "MovimientosCajaDesglozados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fichas de depósito"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.Panel3.ResumeLayout(false)
        Me.Panel10.ResumeLayout(false)
        CType(Me.grdFichasDeposito,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit1,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vwFichasDeposito,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel7.ResumeLayout(false)
        Me.Panel11.ResumeLayout(false)
        Me.Panel12.ResumeLayout(false)
        CType(Me.grdFichaDepositoCorte,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit2,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vwFichaDepositoCorte,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel13.ResumeLayout(false)
        Me.Panel4.ResumeLayout(false)
        CType(Me.grdMontoporTipo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit3,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vwMontoporTipo,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(false)
        Me.Panel6.ResumeLayout(false)
        Me.Panel5.ResumeLayout(false)
        CType(Me.grdFichaEfectivo,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.RepositoryItemTextEdit4,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.vwFichaEfectivo,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel8.ResumeLayout(false)
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

#End Region
    Private Sub ActualizaFichas()

        Try
            dtFichasDepositoCaja.Clear()
        Catch

        End Try

        Try
            'Fichas del corte de caja
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSFichasDepositoCaja"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            End With
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtFichasDepositoCaja)

            grdFichaDepositoCorte.DataSource = dtFichasDepositoCaja
            vwFichaDepositoCorte.ExpandAllGroups()
        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Sub

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
                .CommandText = "spSSFichaDepositoEfectivo"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                If VGN_TipoCorte = 2 Then
                    .Parameters.Add("@TipoCorte", SqlDbType.Int).Value = VGN_TipoCorte
                End If
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

    Private Sub ActualizarAcumulado()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            dtAcumulado.Clear()
        Catch
        End Try

        Try
            'Montos acumulados de fichas
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSFichasDepositoAutomaticas"
                .Parameters.Clear()
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                .Parameters.Add("@Vista", SqlDbType.Int).Value = 1
                .Parameters.Add("@TipoCorte", SqlDbType.Int).Value = VGN_TipoCorte
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            End With

            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtAcumulado)

            grdMontoporTipo.DataSource = dtAcumulado
            vwMontoporTipo.ExpandAllGroups()

        Catch err As Exception
            MsgBox(err.Message)
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub

    '2008-001-EIM-01
    'REQ 026
    'Autor: Ana Juárez
    Private Sub ActualizarFichas()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            dtFichasDepositoCaja.Clear()
        Catch
        End Try

        Try
            'Fichas del corte de caja
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSFichasDepositoCaja"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            End With

            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtFichasDepositoCaja)

            grdFichaDepositoCorte.DataSource = dtFichasDepositoCaja
            vwFichaDepositoCorte.ExpandAllGroups()

        Catch err As Exception
            MsgBox(err.Message)
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default

    End Sub


    Private Sub ActualizarAutomaticas()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            dtDesgloce.Clear()
        Catch
        End Try

        Try
            'Fichas Automáticas
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSFichasDepositoAutomaticas"
                .Parameters.Clear()
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                .Parameters.Add("@TipoCorte", SqlDbType.Int).Value = VGN_TipoCorte
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            End With

            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtDesgloce)

            grdFichasDeposito.DataSource = dtDesgloce
            vwFichasDeposito.ExpandAllGroups()

        Catch err As Exception
            MsgBox(err.Message)
        End Try

        Cursor.Current = System.Windows.Forms.Cursors.Default
    End Sub



    Public Sub Entrar(ByVal TipoCorte As Integer, ByVal DescripcionTipo As String)
        VGN_TipoCorte = TipoCorte

        lblFolioCorte.Text = "Folio Corte : " & CType(dmModulo.VGN_Consecutivo, String)
        lblTipoCorte.Text = "Tipo Corte : " & DescripcionTipo
        dtFechaFicha.Value = CType(dmModulo.VGS_FOperacion, Date)
        lblCaja.Text = "Caja: " & CType(dmModulo.VGN_Caja, String)

        ActualizarAutomaticas()
        ActualizarEfectivo()
        ActualizarAcumulado()
        '2008-001-EIM-01
        'REQ 026
        'Autor: Ana Juárez
        ActualizaFichas()
        Me.ShowDialog()
    End Sub

    '2008-001-EIM-01
    'REQ 027
    'Autor: Ana Juárez
    'Eliminar fichas de depósito
    Private Sub Eliminar(ByVal Folio As Integer)
        'Elimina la ficha especifica del corte de caja
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSEliminaFichaDeposito"
                .Parameters.Clear()
                .Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                .ExecuteNonQuery()
            End With
        Catch err As Exception
            MsgBox(err.Message)
        End Try

    End Sub

    '-$CNSM19092017
    'Eliminar la relacion de la ficha 
    Private Sub EliminarRelacionFichaDeposito(ByVal Folio As Integer)
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSMovimientoCajaFichaDeposito"
                .Parameters.Clear()
                .Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = 1
                .Parameters.Add("@Caja", SqlDbType.Int).Value =0
                .Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = CType(dmModulo.VGS_FOperacion, DateTime)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value =0
                .Parameters.Add("@FolioMovimientoCaja", SqlDbType.Int).Value =0
                .Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                .Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = 0
                .Parameters.Add("@Cobro", SqlDbType.Int).Value =0
                .ExecuteNonQuery()
            End With
        Catch err As Exception
            MsgBox(err.Message)
        End Try

    End Sub

    Private Sub EliminarCheque(ByVal FolioEliminar As Integer, ByVal NumeroCheque As String, ByVal CuentaBanco As String, ByVal TipoFicha As Integer, ByVal Monto As Decimal)
        'Elimina el cheque cambiado por efectivo 
        Try

            With cmdCommand
                .CommandText = "spSSEliminaFichaDepositoCambioCheque"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = NumeroCheque
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = CuentaBanco
                .Parameters.Add("@Folio", SqlDbType.Int).Value = FolioEliminar
                .ExecuteNonQuery()
            End With


            With cmdCommand
                .CommandText = "spSSEliminaCorteCajaCheque"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha
                .Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = NumeroCheque
                .Parameters.Add("@CuentaBanco", SqlDbType.Char).Value = CuentaBanco
                .Parameters.Add("@Monto", SqlDbType.Money).Value = Monto
                .ExecuteNonQuery()
            End With

            Eliminar(FolioEliminar)

        Catch er As Exception
            Exit Sub
        End Try

    End Sub



    '-$CNSM19092017
    'Metodo para mandar a llamar la instancia del formulario frmFichaDepositoConfigurable.vb
    Private Sub AgregarFichaAgrupada(ByVal tipoFicha As Integer, ByVal tipoFichaDescripcion As String, _ 
                             ByVal movimientoCaja As String,  _
                             ByVal fFicha As DateTime, _
                             ByVal desgloce As Boolean, _
                                     ByVal monto As Decimal, _
                             Optional ByVal tipoMovimientoCaja As Integer=0, _ 
                             Optional  ByVal tipoCobro As Integer =0)
            
        Dim Configuracion as Short

        If ((tipoCobro = 6) Or (tipoCobro = 19)) Then
            Configuracion = 3
        ElseIf tipoCobro = 3 Then
            Configuracion = 4
        ElseIf tipoCobro = 10 Then
            Configuracion = 7
        End If

            Dim frmFichaDepositoConfigurable As frmFichaDepositoConfigurable = New frmFichaDepositoConfigurable()
            frmFichaDepositoConfigurable.Entrar(tipoFicha, tipoFichaDescripcion, movimientoCaja, fFicha, desgloce, monto, configuracion, tipoMovimientoCaja, tipoCobro)
            'Almacenamos el dt con el agrupado
            dtMovimientoCaja=frmFichaDepositoConfigurable.dtMovimientoCaja

            VGN_Folio = CType(frmFichaDepositoConfigurable.VGN_Folio, Integer)
            VGN_MontoAplicado = CType(frmFichaDepositoConfigurable.txtMonto.Text, Decimal)
            Me.blnAgregarAlCorte = CType(frmFichaDepositoConfigurable.blnAgregarAlCorte, Boolean)

    End Sub




    '-$CNSM19092017
    'Metodo para mandar a llamar la instancia del formulario frmFichaDepositoConfigurable.vb
    Private Sub AgregarFichaUnitaria(ByVal tipoFicha As Integer, ByVal tipoFichaDescripcion As String, _ 
                             ByVal movimientoCaja As String,  _
                             ByVal fFicha As DateTime,  _
                             ByVal desgloce As Boolean, _
                            ByVal monto As Decimal, _
                             Optional ByVal tipoMovimientoCaja As Integer=0, _ 
                             Optional  ByVal tipoCobro As Integer =0)
            
        Dim configuracion As Short

        If movimientoCaja = "Cheques Posfechados Vencidos" Then
            configuracion = 5
        Else
            If tipoCobro = 7 Then
                configuracion = 0
            ElseIf ((tipoCobro = 6) Or (tipoCobro = 19)) Then
                configuracion = 1
            ElseIf tipoCobro = 3 Then
                configuracion = 2
            ElseIf tipoCobro = 10 Then
                configuracion = 6
            End If
        End If



        Dim frmFichaDepositoConfigurable As frmFichaDepositoConfigurable = New frmFichaDepositoConfigurable()
        frmFichaDepositoConfigurable.Entrar(tipoFicha, tipoFichaDescripcion, movimientoCaja, fFicha, desgloce, monto, configuracion, tipoMovimientoCaja, tipoCobro)
        'Almacenamos el dt con el agrupado
        dtMovimientoCaja = frmFichaDepositoConfigurable.dtMovimientoCaja

        VGN_Folio = CType(frmFichaDepositoConfigurable.VGN_Folio, Integer)
        VGN_MontoAplicado = CType(frmFichaDepositoConfigurable.txtMonto.Text, Decimal)
        Me.blnAgregarAlCorte = CType(frmFichaDepositoConfigurable.blnAgregarAlCorte, Boolean)

    End Sub




    Private Sub AgregarFicha(ByVal TipoFicha As Integer, ByVal TipoFichaDescripcion As String, _ 
                             ByVal MovimientoCaja As String, ByVal Monto As Decimal, _ 
                             ByVal FFicha As DateTime, ByVal Desgloce As Boolean)
        
            Dim frmFichaDeposito_ed As FichaDeposito_ed = New FichaDeposito_ed()
            frmFichaDeposito_ed.Entrar(TipoFicha, TipoFichaDescripcion, MovimientoCaja, Monto, FFicha, Desgloce)

            VGN_Folio = CType(frmFichaDeposito_ed.VGN_Folio, Integer)
            VGN_MontoAplicado = CType(frmFichaDeposito_ed.txtMonto.Text, Decimal)
            Me.blnAgregarAlCorte = CType(frmFichaDeposito_ed.blnAgregarAlCorte, Boolean)
            frmFichaDeposito_ed.Dispose()
    End Sub


    '-$CNSM19092017
    Private Sub AgregarFichaCorte(ByVal tipoFicha As Integer, ByVal TipoFichaDescripcion As String, _ 
        ByVal MovimientoCaja As String, ByVal Monto As Decimal, ByVal FFicha As String, ByVal Desgloce As Boolean, Optional ByVal tipoMovimientoCaja As Integer=0, _ 
                             Optional  ByVal tipoCobro As Integer =0 )
        If ((tipoFicha = 7) Or (tipoCobro = 6) Or (tipoCobro = 3) Or (tipoCobro = 19) Or (tipoCobro = 10)) Then
            'Agrega la ficha al corte
            AgregarFichaUnitaria(tipoFicha, TipoFichaDescripcion, MovimientoCaja, CType(FFicha, Date), Desgloce, Monto, tipoMovimientoCaja, tipoCobro)
        Else
            'Agrega la ficha al corte
            AgregarFicha(tipoFicha, TipoFichaDescripcion, MovimientoCaja, Monto, CType(FFicha, Date), Desgloce)
        End If

        If VGN_Folio <> 0 Then 'Esto quiere decir que si se inserto una ficha de depósito
            'La relaciona al corte correspondiente
            RelacionaFichaCorte(VGN_Folio)
            
            'Relaciona el movimiento caja con la ficha deposito
                If(dtMovimientoCaja IsNot Nothing)
                    For Each row As DataRow In dtMovimientoCaja.Rows
                    RelacionaFichaDeposito(VGN_Folio, CType(row("Consecutivo"), Short), CType(row("Folio"), Integer), CType(row("Cobro"), Integer), CType(row("AnioCobro"), Short), CType(row("FOperacion"), DateTime))
                    Next
                End If

            'Agrega el detalle de la ficha que inserto
            AgregaFichaDetalle(VGN_Folio, tipoFicha, VGN_MontoAplicado)
            'Actualiza la información del corte de caja
            ActualizarFichas()

            Else
            If (dtMovimientoCaja IsNot Nothing) Then
                Dim FolioAnt As Integer = 0
                For Each row As DataRow In dtMovimientoCaja.Rows

                    If FolioAnt <> CType(row("FolioGenerado"), Integer) Then
                        'La relaciona al corte correspondiente
                        RelacionaFichaCorte(CType(row("FolioGenerado"), Integer))
                        'Agrega el detalle de la ficha que inserto
                        AgregaFichaDetalle(CType(row("FolioGenerado"), Integer), CType(row("TipoFicha"), Integer), CType(row("Total"), Decimal))
                    End If

                    FolioAnt = CType(row("FolioGenerado"), Integer)

                    'Relaciona el movimiento caja con la ficha deposito
                    RelacionaFichaDeposito(CType(row("FolioGenerado"), Integer), CType(row("Consecutivo"), Short), CType(row("Folio"), Integer), CType(row("Cobro"), Integer), CType(row("AnioCobro"), Short), CType(row("FOperacion"), DateTime))

                    'Actualiza la información del corte de caja
                    ActualizarFichas()

                Next
            End If

        End If
        dtMovimientoCaja = Nothing

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


    '-$CNSM19092017
    Private Sub AgregaFichasAcumuladas()
        Try
            dtFichasAcumuladas.Clear()


            Dim tipoCobro As Integer= CType(vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("TipoCobro").ToString().Trim, integer)


            If ((tipoCobro = 6) Or (tipoCobro = 3) Or (tipoCobro = 19) Or (tipoCobro = 10)) Then
                AgregarFichaAgrupada(0, vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Tipo").ToString().Trim, _
                         vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Tipo").ToString().Trim,
                         CType(dmModulo.VGS_FOperacion, Date), False, CType(vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Total"), Decimal), 0, tipoCobro)
            Else
                AgregarFicha(0, vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Tipo").ToString().Trim, _
                         vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Tipo").ToString().Trim, _
                         CType(vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Total").ToString().Trim, Decimal), _
                         CType(dmModulo.VGS_FOperacion, Date), False)
            End If
            

            If VGN_Folio <> 0 Then
                Dim i As Integer = 0

                With cmdCommand
                    .CommandType = CommandType.StoredProcedure
                    '.CommandTimeout = 0
                    .CommandText = "spSSFichasDepositoAutomaticas"
                    .Parameters.Clear()
                    .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                    .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
                    .Parameters.Add("@Vista", SqlDbType.Int).Value = 2
                    .Parameters.Add("@Descripcion", SqlDbType.Char).Value = vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Tipo")
                    .Parameters.Add("@TipoCorte", SqlDbType.Int).Value = dmModulo.VGN_TipoCorte
                    .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                    daSelect.SelectCommand = cmdCommand
                    daSelect.Fill(dtFichasAcumuladas)
                End With
                
                
                RelacionaFichaCorte(VGN_Folio)

                'Relaciona el movimiento caja con la ficha deposito
                If(dtMovimientoCaja IsNot Nothing)
                    For Each row As DataRow In dtMovimientoCaja.Rows
                        RelacionaFichaDeposito(VGN_Folio, CType(row("Consecutivo"), Short), CType(row("Folio"), Integer), CType(row("Cobro"), Integer), CType(row("AnioCobro"), Short), CType(row("FOperacion"), DateTime))
                    Next
                End If

                While (dtFichasAcumuladas.Rows.Count - 1) >= i
                    'Agrega el detalle de la ficha que inserto
                    AgregaFichaDetalle(VGN_Folio, CType(dtFichasAcumuladas.Rows(i).Item("TipoFicha").ToString().Trim, Integer), _
                                       CType(dtFichasAcumuladas.Rows(i).Item("Total").ToString().Trim, Decimal))
                    dmModulo.MontoPendienteTipoFicha(CType(dtFichasAcumuladas.Rows(i).Item("TipoFicha").ToString().Trim, Integer), _
                                                     False, CType(dtFichasAcumuladas.Rows(i).Item("Total").ToString().Trim, Decimal), _
                                                     CType(dtFichasAcumuladas.Rows(i).Item("Total").ToString().Trim, Decimal))
                    i = i + 1
                End While


            ELse 
                'Relaciona el movimiento caja con la ficha deposito
                Dim FolioAnt As Integer = 0
                If(dtMovimientoCaja IsNot Nothing)
                    For Each row As DataRow In dtMovimientoCaja.Rows

                        If FolioAnt <> CType(row("FolioGenerado"), Integer) Then
                            RelacionaFichaCorte(CType(row("FolioGenerado"), Integer))

                            'Agrega el detalle de la ficha que inserto
                            AgregaFichaDetalle(CType(row("FolioGenerado"), Integer), CType(row("TipoFicha"), Integer), _
                                           CType(row("Total"), Decimal))


                        End If
                        FolioAnt = CType(row("FolioGenerado"), Integer)

                        RelacionaFichaDeposito(CType(row("FolioGenerado"), Integer), CType(row("Consecutivo"), Short), CType(row("Folio"), Integer), CType(row("Cobro"), Integer), CType(row("AnioCobro"), Short), CType(row("FOperacion"), DateTime))
                        'dmModulo.MontoPendienteTipoFicha(CType(row("TipoFicha"), Integer), False, CType(row("Total"), Decimal), _
                        '     CType(row("Total"), Decimal))
                        dmModulo.MontoPendienteTipoFicha(CType(row("TipoFicha"), Integer), False, _
                                                         CType(row("Total"), Decimal), _
                                                         CType(vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Total").ToString().Trim, Decimal))

                    Next
                End If

            End If
            dtMovimientoCaja = Nothing
        Catch err As Exception
            MsgBox(err.Message)
        End Try
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

    '-$CNSM19092017
    Private Sub RelacionaFichaDeposito(ByVal Folio As Integer, ByVal Consecutivo As Short, ByVal FolioMovimientoCaja As Integer, _
                                       ByVal Cobro As Integer, ByVal Anio As Short, ByVal FOperacionP As DateTime)
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                '.CommandTimeout = 0
                .CommandText = "spSSMovimientoCajaFichaDeposito"
                .Parameters.Clear()
                .Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = 0
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                '.Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = CType(dmModulo.VGS_FOperacion, DateTime)
                .Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = FOperacionP
                .Parameters.Add("@Consecutivo", SqlDbType.TinyInt).Value = Consecutivo
                .Parameters.Add("@FolioMovimientoCaja", SqlDbType.Int).Value = FolioMovimientoCaja
                .Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                .Parameters.Add("@AñoCobro", SqlDbType.SmallInt).Value = Anio
                .Parameters.Add("@Cobro", SqlDbType.Int).Value = Cobro
                .ExecuteNonQuery()
            End With
        Catch err As Exception
            MsgBox(err.Message)
        End Try

    End Sub


    Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        Select Case e.Button.Text
            Case "Agregar"
            Case "Modificar"
            Case "Eliminar"
                'Try
                '    If vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio") <> 0 Then
                '        If (MessageBox.Show("¿Desea eliminar la ficha de deposito " & CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio"), String) & " ?", "Fichas de depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes) Then
                '            Eliminar(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio"))
                '            ActualizarAutomaticas()
                '            ActualizarEfectivo()
                '            ActualizarAcumulado()
                '        End If
                '    Else
                '        If MessageBox.Show("¿Desea eliminar el cheque " & Trim(CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("NumeroCheque"), String)) & " ?", "Fichas de depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                '            EliminarCheque(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("NumeroCheque"), vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("CuentaBanco"), vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("TipoFicha"), vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Total"))
                '            ActualizarEfectivo()
                '        End If
                '    End If

                '    ActualizarFichas()
                'Catch
                '    MessageBox.Show("No hay fichas de depósito para eliminar.", "Fichas de depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                'End Try

            Case "Imprimir"
                Try
                    btnImprimir.Enabled = False

                    Dim frmImprimeFicha As ViewReport = New ViewReport()
                    Dim Seleccion As Array
                    Seleccion = vwFichaDepositoCorte.GetSelectedRows
                    Dim Elemento As Integer
                    ''Dim TipoFicha As String
                    Dim Cuenta As String
                    Dim indice As Integer
                    Dim dato1 As String
                    Dim dato2 As String
                    Dim cantidad As Integer

                    ' verifica que sean del mismo Tipo de Ficha
                    cantidad = 0
                    dato1 = ""
                    dato2 = ""
                    Elemento = CType(Seleccion.GetValue(0), Integer)

                    dato1 = (vwFichaDepositoCorte.GetRow(Elemento).item("Tipo")).Substring(0, 8).ToString().Trim

                    '2008-001-EIM-01
                    'REQ 023
                    'Autor: Fernando Correa
                    'Reimpresion de la Papeleta
                    If VerificaSeleccionMismaPapeleta() = True Then
                        MessageBox.Show("Debe de seleccionar solo un folio de papeleta", "Corte caja - Papeleta deposito", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        btnImprimir.Enabled = True
                        Exit Sub
                    End If

                    '2007-016-EIM-01
                    'REQ XXX
                    'Autor: Fernando Correa
                    'Reimpresion de la Papeleta
                    If VerificaSeleccionMismaCuentaBanco() = True Then
                        MessageBox.Show("Debe de seleccionar elementos ccon un mismo número de cuenta bancaria", "Corte caja - Papeleta deposito", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                        btnImprimir.Enabled = True
                        Exit Sub
                    End If

                    For indice = 0 To vwFichaDepositoCorte.SelectedRowsCount - 1
                        Elemento = Integer.Parse(Seleccion.GetValue(indice).ToString())
                        Folio = Integer.Parse(Trim(CType(vwFichaDepositoCorte.GetRow(Elemento).item("Folio"), String)))
                        Papeleta = Integer.Parse(vwFichaDepositoCorte.GetRow(Elemento).Item("FolioPapeleta").ToString())
                        Caja = Integer.Parse(Trim(CType(vwFichaDepositoCorte.GetRow(Elemento).Item("Caja"), String)))
                        Fecha = Date.Parse(Trim(CType(vwFichaDepositoCorte.GetRow(Elemento).Item("FFicha"), String)))

                        '2008-001-EIM-01
                        'REQ 024
                        'Autor: Ana Juárez
                        'Reimpresion de la Papeleta
                        If Papeleta <> 0 Then
                            If (MessageBox.Show("La ficha deposito: " & Folio & " ya esta contenida en la Papeleta: " & Papeleta & " ¿Desea reimprimirla?", "Fichas de depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes) Then

                                'Impresión de las fichas seleccionadas
                                frmImprimeFicha.Entrar(Papeleta, Caja.ToString(), dtFechaFicha.Value.ToShortDateString)
                                frmImprimeFicha.Dispose()

                            End If
                            ''Seleccion.Clear(Seleccion, 0, vwFichaDepositoCorte.SelectedRowsCount)
                            Array.Clear(Seleccion, 0, vwFichaDepositoCorte.SelectedRowsCount)

                            btnImprimir.Enabled = True
                            Exit Sub
                        End If
                        If Folio = 0 Then
                            MessageBox.Show("Esta ficha no puede ser mandada a una papeleta, ya que es de cambio cheque", "Fichas deposito", MessageBoxButtons.OK, MessageBoxIcon.Stop)
                            btnImprimir.Enabled = True
                            Exit Sub
                        End If
                        dato2 = (vwFichaDepositoCorte.GetRow(Elemento).item("Tipo")).Substring(0, 8).ToString().Trim

                        If dato1 <> dato2 Then
                            cantidad = cantidad + 1
                        End If
                    Next
                    If cantidad > 0 Then
                        MessageBox.Show("Hay diferentes Tipos de Fichas en la selección.", "Fichas de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ''Seleccion.Clear(Seleccion, 0, vwFichaDepositoCorte.SelectedRowsCount)
                        Array.Clear(Seleccion, 0, vwFichaDepositoCorte.SelectedRowsCount)
                        btnImprimir.Enabled = True
                        Exit Sub
                    End If

                    ' Si todo lo anterior es correcto...

                    Caja = CType(Trim(CType(vwFichaDepositoCorte.GetRow(Elemento).Item("Caja"), String)), Integer)
                    PapeletaMaxima(Caja)

                    If vwFichaDepositoCorte.RowCount >= 1 Then
                        Seleccion = vwFichaDepositoCorte.GetSelectedRows
                        For indice = 0 To vwFichaDepositoCorte.SelectedRowsCount - 1
                            Elemento = CType(Seleccion.GetValue(indice), Integer)
                            Folio = CType(vwFichaDepositoCorte.GetRow(Elemento).Item("Folio").ToString().Trim, Integer)
                            Cuenta = Trim(CType(vwFichaDepositoCorte.GetRow(Elemento).Item("CuentaBanco"), String))
                            Caja = CType(vwFichaDepositoCorte.GetRow(Elemento).Item("Caja").ToString().Trim, Integer)

                            'Se guarda el historico y se crea la Papeleta
                            cmdCommand.CommandType = CommandType.StoredProcedure
                            cmdCommand.CommandText = "spUpdatePapeletaDeposito"
                            cmdCommand.Parameters.Clear()

                            cmdCommand.Parameters.Add("@Folio", SqlDbType.Int).Value = Folio
                            cmdCommand.Parameters.Add("@Caja", SqlDbType.Char).Value = Caja
                            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Char).Value = intPapeletaMaxima
                            cmdCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = dtFechaFicha.Value

                            cmdCommand.ExecuteNonQuery()
                        Next
                        If cantidad > 0 Then
                            MessageBox.Show("Hay diferentes tipos de ficha en la selección.", "Fichas de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            ''Seleccion.Clear(Seleccion, 0, vwFichaDepositoCorte.SelectedRowsCount)
                            Array.Clear(Seleccion, 0, vwFichaDepositoCorte.SelectedRowsCount)
                            Exit Sub
                        End If
                    End If

                    'Impresión de las fichas seleccionadas
                    frmImprimeFicha.Entrar(intPapeletaMaxima, Caja.ToString(), dtFechaFicha.Value.ToShortDateString)
                    frmImprimeFicha.Dispose()

                    ActualizaFichas()
                    btnImprimir.Enabled = True
                Catch
                    MessageBox.Show("No hay fichas de depósito para imprimir.", "Fichas de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    btnImprimir.Enabled = True
                End Try

            Case "Actualizar"
                ActualizarAutomaticas()
                ActualizarEfectivo()
                ActualizarFichas()
                ActualizarAcumulado()
            Case "Salir"
                Close()
        End Select
    End Sub

    '2008-001-EIM-01
    'REQ 023
    'Autor: Fernando Correa
    'Funcion que permite verificar que no se hayan seleccionado dos papeletas distintas
    Function VerificaSeleccionMismaPapeleta() As Boolean
        Dim cont As Integer
        Dim iguales As Integer = 0
        Try
            If vwFichaDepositoCorte.SelectedRowsCount > 1 Then
                For cont = 1 To vwFichaDepositoCorte.SelectedRowsCount - 1
                    If CType(vwFichaDepositoCorte.GetRow(CType(vwFichaDepositoCorte.GetSelectedRows().GetValue(0), Integer)).Item("FolioPapeleta").ToString(), Integer) <> _
                       CType(vwFichaDepositoCorte.GetRow(CType(vwFichaDepositoCorte.GetSelectedRows().GetValue(cont), Integer)).Item("FolioPapeleta").ToString(), Integer) Then
                        iguales += 1
                    End If
                Next
            End If

            If iguales > 0 Then
                Return True
            Else
                Return False
            End If

            ''Return IIf(iguales > 0, True, False)
        Catch
            MessageBox.Show("Error al validad Papeletas", "Corte caja - Fichas deposito", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Function

    '2007-016-EIM-01
    'REQ XXX
    'Autor: Fernando Correa
    'Funcion que permite verificar que no se hayan seleccionado dos cuenta banco distintas
    Function VerificaSeleccionMismaCuentaBanco() As Boolean
        Dim cont As Integer
        Dim iguales As Integer = 0
        Try
            If vwFichaDepositoCorte.SelectedRowsCount > 1 Then
                For cont = 1 To vwFichaDepositoCorte.SelectedRowsCount - 1
                    If CType(vwFichaDepositoCorte.GetRow(CType(vwFichaDepositoCorte.GetSelectedRows().GetValue(0), Integer)).Item("CuentaBanco"), String).Trim() <> _
                       CType(vwFichaDepositoCorte.GetRow(CType(vwFichaDepositoCorte.GetSelectedRows().GetValue(cont), Integer)).Item("CuentaBanco"), String).Trim() Then
                        iguales += 1
                    End If
                Next
            End If

            ''Return IIf(iguales > 0, True, False)
            If iguales > 0 Then
                Return True
            Else
                Return False
            End If
        Catch
            MessageBox.Show("Error al validad Papeletas", "Corte caja - Fichas deposito", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        End Try

    End Function



    'Verifica cual es la máxima papeleta
    Private Sub PapeletaMaxima(ByVal Caja As Integer)

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spMaximaPapeleta"
        cmdCommand.Parameters.Clear()

        cmdCommand.Parameters.Add("@Caja", SqlDbType.Char).Value = Caja
        cmdCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = dtFechaFicha.Value

        rdrSelect = cmdCommand.ExecuteReader

        If rdrSelect.Read() Then
            intPapeletaMaxima = CType(rdrSelect("Maximo"), Integer)
        End If
        rdrSelect.Close()
        intPapeletaMaxima = intPapeletaMaxima
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        Try
            If Double.Parse(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("MontoTotal").ToString()) > 0 Then
                AgregarFichaCorte(CType(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Tipo").ToString().Trim, Integer), _
                                  vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Concepto").ToString().Trim, _
                                  vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Concepto").ToString().Trim, _
                                  CType(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("MontoTotal").ToString().Trim, Decimal), _
                                  dtFechaFicha.Value.ToShortDateString, True)
            Else
                MessageBox.Show("¡No es posible realizar la operación porque el monto de la ficha es 0!", "Fichas de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch
        End Try
        ActualizarEfectivo()
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Dim VLN_Indice As Integer
        Dim VLN_ElementoSeleccionado As String
        Dim VLS_Tipo As String
        Dim VLS_TipoSeleccionado As String
        Dim VLS_Seleccionados As Array = vwFichasDeposito.GetSelectedRows
        Dim VLN_Total As Decimal

        Try
            VLN_ElementoSeleccionado = VLS_Seleccionados.GetValue(VLN_Indice).ToString()
            VLS_Tipo = Trim(CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).item("Descripcion"), String))
            VLN_Total = 0


            'Verifica que todas las fichas seleccionadas sean del mismo tipo, si es asi me obtiene el monto total por todas ellas
            For VLN_Indice = 0 To vwFichasDeposito.SelectedRowsCount - 1
                VLN_ElementoSeleccionado = VLS_Seleccionados.GetValue(VLN_Indice).ToString()
                VLS_TipoSeleccionado = Trim(CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("Descripcion"), String))
                VLN_Total = VLN_Total + CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("Total"), Decimal)

                'Si no son del mismo tipo sale del procedimiento
                If VLS_Tipo <> VLS_TipoSeleccionado Then
                    MessageBox.Show("Las fichas que ha seleccionando no son del mismo tipo.", "Corte de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    ''VLS_Seleccionados.Clear(VLS_Seleccionados, 0, vwFichasDeposito.SelectedRowsCount)
                    Array.Clear(VLS_Seleccionados, 0, vwFichasDeposito.SelectedRowsCount)
                    Exit Sub
                End If
            Next

            Try

                Dim tipoCobro As Integer = CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("TipoCobro"), Integer)

                '-$CNSM19092017
                'Agrega la ficha deposito general de las seleccionadas
                If (tipoCobro = 6) Or (tipoCobro = 3) Or (tipoCobro = 19) Or (tipoCobro = 10) Then
                    AgregarFichaUnitaria(CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).Item("TipoFicha").ToString(), Integer), vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).Item("Descripcion").ToString(), _
                             vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("MovimientoCaja").ToString(), _
                             CDate(dtFechaFicha.Value.ToShortDateString), False, CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("Total"), Decimal), _
                             CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("TipoMovimientoCaja"), Integer), tipoCobro)
                Else
                    AgregarFicha(0, vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).Item("Descripcion").ToString(), _
                             vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("MovimientoCaja").ToString(), VLN_Total, _
                             CDate(dtFechaFicha.Value.ToShortDateString), False)

                End If

                '-$CNSM19092017
                'Condicion para definir que tipo de porceso se ejecutara
                If VGN_Folio <> 0 Then
                    'Relaciona la ficha de deposito con el corte de caja que se esta 
                    RelacionaFichaCorte(VGN_Folio)

                    'Relaciona el movimiento caja con la ficha deposito
                    If (dtMovimientoCaja IsNot Nothing) Then
                        For Each row As DataRow In dtMovimientoCaja.Rows
                            RelacionaFichaDeposito(VGN_Folio, CType(row("Consecutivo"), Short), CType(row("Folio"), Integer), CType(row("Cobro"), Integer), CType(row("AnioCobro"), Short), CType(row("FOperacion"), DateTime))
                        Next
                    End If

                    'Agrega las fichas detalle, con los tipos movimiento caja correspondiente
                    For VLN_Indice = 0 To vwFichasDeposito.SelectedRowsCount - 1
                        VLN_ElementoSeleccionado = VLS_Seleccionados.GetValue(VLN_Indice).ToString()
                        'Inserta el monto pendiente por el tipo de ficha
                        dmModulo.MontoPendienteTipoFicha(CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("TipoFicha").ToString(), Integer), False, _
                                                         CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("Total").ToString(), Decimal), _
                                                         CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("Total").ToString(), Decimal))
                        'Agrega el detalle de la ficha 
                        AgregaFichaDetalle(VGN_Folio, CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("TipoFicha"), Integer), _
                                           CType(vwFichasDeposito.GetRow(CType(VLN_ElementoSeleccionado, Integer)).Item("Total"), Decimal))
                    Next
                    ActualizarFichas()

                    If Me.blnAgregarAlCorte Then
                        Dim rowAcumulado, rowDesgloce As DataRow

                        Try
                            dcmTotalAutomaticos = 0
                            'Se actualiza el grdFichasDeposito
                            For Each rowDesgloce In Me.dtDesgloce.Rows
                                TipoTablaAutomaticas = vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("Descripcion").ToString().Trim

                                If rowDesgloce.Item("Descripcion").ToString().Trim = TipoTablaAutomaticas Then
                                    dcmTotalAutomaticos = dcmTotalAutomaticos + CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("Total").ToString(), Integer)
                                    rowDesgloce.Delete()
                                    Exit For
                                End If
                            Next
                            dtDesgloce.AcceptChanges()

                            grdFichasDeposito.DataSource = dtDesgloce
                            vwFichasDeposito.ExpandAllGroups()
                        Catch ER As Exception
                            MsgBox(ER.Message)
                        End Try

                        Try
                            Dim i As Integer
                            i = 0
                            'Se actualiza el grdMontoporTipo
                            For Each rowAcumulado In Me.dtAcumulado.Rows
                                i = i + 1
                                If rowAcumulado.Item("Tipo").ToString().Trim = TipoTablaAutomaticas Then
                                    dcmTotalAcumulados = CType(vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Total").ToString(), Decimal) - dcmTotalAutomaticos
                                    If dcmTotalAcumulados = 0 Then
                                        rowAcumulado.Delete()
                                    Else
                                        dtAcumulado.Rows(i - 1).Item(1) = dcmTotalAcumulados
                                    End If
                                    Exit For
                                End If
                            Next
                            dtAcumulado.AcceptChanges()

                            grdMontoporTipo.DataSource = dtAcumulado
                            vwMontoporTipo.ExpandAllGroups()
                        Catch ER As Exception
                            MsgBox(ER.Message)
                        End Try
                    End If

                Else
                    If (tipoCobro = 6) Or (tipoCobro = 3) Or (tipoCobro = 19) Or (tipoCobro = 10) Then
                        'Relaciona el movimiento caja con la ficha deposito
                        If (dtMovimientoCaja IsNot Nothing) Then

                            Dim Descripcion As String = vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).Item("Descripcion").ToString()
                            Dim FolioAnt As Integer = 0

                            For Each row As DataRow In dtMovimientoCaja.Rows
                                If FolioAnt <> CType(row("FolioGenerado"), Integer) Then
                                    'Relaciona la ficha de deposito con el corte de caja que se esta 
                                    RelacionaFichaCorte(CType(row("FolioGenerado"), Integer))

                                    'Agrega el detalle de la ficha 
                                    AgregaFichaDetalle(CType(row("FolioGenerado"), Integer), CType(row("TipoFicha"), Integer), _
                                                           CType(row("Total"), Decimal))

                                    'Inserta el monto pendiente por el tipo de ficha
                                    'dmModulo.MontoPendienteTipoFicha(CType(row("TipoFicha"), Integer), False, _
                                    '                                     CType(row("Total"), Decimal), _
                                    '                                     CType(row("Total"), Decimal))
                                End If
                                FolioAnt = CType(row("FolioGenerado"), Integer)

                                'Relaciona el movimiento caja con la ficha deposito
                                RelacionaFichaDeposito(CType(row("FolioGenerado"), Integer), CType(row("Consecutivo"), Short), CType(row("Folio"), Integer), CType(row("Cobro"), Integer), CType(row("AnioCobro"), Short), CType(row("FOperacion"), DateTime))

                                ActualizarFichas()

                                If Me.blnAgregarAlCorte Then
                                    Dim rowAcumulado, rowDesgloce As DataRow

                                    Try
                                        dcmTotalAutomaticos = 0
                                        'Se actualiza el grdFichasDeposito
                                        For Each rowDesgloce In Me.dtDesgloce.Rows
                                            TipoTablaAutomaticas = Descripcion.Trim

                                            If rowDesgloce.Item("Descripcion").ToString().Trim = TipoTablaAutomaticas Then
                                                dcmTotalAutomaticos = dcmTotalAutomaticos + CType(row("Total"), Decimal)
                                                rowDesgloce.Delete()
                                                Exit For
                                            End If
                                        Next
                                        dtDesgloce.AcceptChanges()

                                        grdFichasDeposito.DataSource = dtDesgloce
                                        vwFichasDeposito.ExpandAllGroups()
                                    Catch ER As Exception
                                        MsgBox(ER.Message)
                                    End Try

                                    Try
                                        Dim i As Integer
                                        i = 0
                                        'Se actualiza el grdMontoporTipo
                                        For Each rowAcumulado In Me.dtAcumulado.Rows
                                            i = i + 1
                                            If rowAcumulado.Item("Tipo").ToString().Trim = TipoTablaAutomaticas Then
                                                dcmTotalAcumulados = CType(row("Total"), Decimal) - dcmTotalAutomaticos
                                                If dcmTotalAcumulados = 0 Then
                                                    rowAcumulado.Delete()
                                                Else
                                                    dtAcumulado.Rows(i - 1).Item(1) = dcmTotalAcumulados
                                                End If
                                                Exit For
                                            End If
                                        Next
                                        dtAcumulado.AcceptChanges()

                                        grdMontoporTipo.DataSource = dtAcumulado
                                        vwMontoporTipo.ExpandAllGroups()
                                    Catch ER As Exception
                                        MsgBox(ER.Message)
                                    End Try
                                End If

                            Next
                        End If
                    End If
                End If

                '-$CNSM19092017
                ActualizarAutomaticas()
                ActualizarAcumulado()
                dtMovimientoCaja = Nothing
            Catch ER As Exception
                MessageBox.Show("Se genero este error: " + ER.Message, "Menu 2", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

        Catch
            MessageBox.Show("Favor de seleccionar un registro.", "Corte de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        
    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Dim VLN_MultiSelect As Boolean

        Try
            If vwFichasDeposito.SelectedRowsCount > 1 Then
                VLN_MultiSelect = False
            Else
                VLN_MultiSelect = True
            End If
            '-$CNSM19092017
            AgregarFichaCorte(CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).Item("TipoFicha").ToString(), Integer), _
                              vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).Item("Descripcion").ToString(), _
                              vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("MovimientoCaja").ToString(), _
                              CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).Item("Total").ToString(), Decimal), _
                              dtFechaFicha.Value.ToShortDateString, VLN_MultiSelect,CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("TipoMovimientoCaja"), Integer), _ 
                              CType(vwFichasDeposito.GetRow(vwFichasDeposito.FocusedRowHandle).item("TipoCobro"), Integer))
        Catch Ex As Exception
            'MessageBox.Show("Se genero la siguiente Excepsión: " + Ex.Message, "Menu 5", MessageBoxButtons.OK, MessageBoxIcon.Error)
            MessageBox.Show("Favor de seleccionar un registro.", "Corte de caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try

        ActualizarAutomaticas()
        ActualizarAcumulado()
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        If vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("MontoTotal") > 0 Then
            Dim frmCambioCheques As New CambioCheques()
            frmCambioCheques.Entrar(dtFechaFicha.Value, _
                                    CType(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Tipo").ToString(), Integer), _
                                    vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Concepto").ToString(), _
                                    CType(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("MontoTotal").ToString(), Decimal))
            frmCambioCheques.Dispose()

            ActualizarEfectivo()
            ActualizarFichas()
        Else
            MessageBox.Show("¡No es posible realizar la operación porque el monto de la ficha es 0!", "Fichas de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim frmChequesPosfechados As New ChequesPosfechados()
        frmChequesPosfechados.Entrar(CType(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("Tipo").ToString().Trim, Integer), _
                                     CType(vwFichaEfectivo.GetRow(vwFichaEfectivo.FocusedRowHandle).item("MontoTotal").ToString().Trim, Decimal))
        ActualizarEfectivo()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Try
            AgregaFichasAcumuladas()
            ActualizarFichas()

            If Me.blnAgregarAlCorte Then
                Dim rowAcumulado, rowDesgloce As DataRow

                Try
                    'Se actualiza el grdMontoporTipo
                    For Each rowAcumulado In Me.dtAcumulado.Rows
                        TipoTablaAcumulado = rowAcumulado.Item("Tipo").ToString().Trim

                        If rowAcumulado.Item("Tipo").ToString().Trim = vwMontoporTipo.GetRow(vwMontoporTipo.FocusedRowHandle).item("Tipo").ToString().Trim Then
                            rowAcumulado.Delete()
                            Exit For
                        End If
                    Next
                    dtAcumulado.AcceptChanges()

                    grdMontoporTipo.DataSource = dtAcumulado
                    vwMontoporTipo.ExpandAllGroups()
                Catch ER As Exception
                    MsgBox(ER.Message)
                End Try

                Try
                    'Se actualiza el grdFichasDeposito
                    For Each rowDesgloce In Me.dtDesgloce.Rows
                        If rowDesgloce.Item("Descripcion").ToString().Trim = TipoTablaAcumulado Then
                            rowDesgloce.Delete()
                        End If
                    Next
                    dtDesgloce.AcceptChanges()

                    grdFichasDeposito.DataSource = dtDesgloce
                    vwFichasDeposito.ExpandAllGroups()
                Catch ER As Exception
                    MsgBox(ER.Message)
                End Try
            End If
        Catch
        End Try
    End Sub

    '2008-001-EIM-01
    'REQ 027
    'Autor: Ana Juárez
    'Eliminar fichas de depósito
    Private Sub mnFichaDep_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnFichaDep.Click
        Try
            If Not CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Tipo"), String).StartsWith("CAMBIO CHEQUE") Then
                If vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("FolioPapeleta") = 0 Then
                    If (MessageBox.Show("¿Desea eliminar la ficha de deposito " & CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio"), String) & " ?", "Fichas de depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes) Then

                        '-$CNSM19092017
                        'Eliminar la relacion de la ficha 
                        EliminarRelacionFichaDeposito(CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio").ToString().Trim, Integer))
                        Eliminar(CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio").ToString().Trim, Integer))
                        ActualizarAutomaticas()
                        ActualizarEfectivo()
                        ActualizarAcumulado()
                    End If
                Else
                    MessageBox.Show("No se puede eliminar la ficha de depósito: " & CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio"), String) & " porque ya  esta impresa en la papeleta: " & CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("FolioPapeleta"), String), "AVISO", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If

            Else
                If MessageBox.Show("¿Desea eliminar el cheque " & Trim(CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("NumeroCheque"), String)) & " ?", "Fichas de depósito", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes Then
                    EliminarCheque(CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio").ToString().Trim, Integer), _
                                   vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("NumeroCheque").ToString().Trim, _
                                   vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("CuentaBanco").ToString().Trim, _
                                   CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("TipoFicha").ToString().Trim, Integer), _
                                   CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Total").ToString().Trim, Decimal))
                    ActualizarEfectivo()
                End If
            End If

            ActualizarFichas()
        Catch
            MessageBox.Show("No hay fichas de depósito para eliminar.", "Fichas de depósito", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub mnPapeleta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnPapeleta.Click
        Try
            If VerificaSeleccionMismaPapeleta() = True Then
                MessageBox.Show("Debe de seleccionar un solo folio de papeleta", "Corte caja - Papeleta deposito", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If

            Papeleta = CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("FolioPapeleta").ToString().Trim, Integer)
            Folio = CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("Folio").ToString().Trim, Integer)

            '2007-016-EIM-01
            'REQ 156
            'Autor: Fernando Correa
            'Validar que no se puedan eliminar fichas de depósito (papeletas) si ya  estan asociadas a un comprobante de valores.
            If VerificaPapeletaContenidaComprobanteServicio(Papeleta) > 0 Then
                MessageBox.Show("No se puede eliminar la papeleta seleccionada " + vbCrLf _
                                + "ya que esta asociada a un comprobante se servicio", "Corte caja - Papeleta deposito", MessageBoxButtons.OK, MessageBoxIcon.Hand)
                Exit Sub
            End If

            If Folio <> 0 And Papeleta <> 0 Then
                If (MessageBox.Show("¿Desea eliminar la Papeleta " + CType(vwFichaDepositoCorte.GetRow(vwFichaDepositoCorte.FocusedRowHandle).item("FolioPapeleta"), String) + vbCrLf _
                    + " con todas las fichas que contiene ?", "Papeleta", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.Yes) Then

                    cmdCommand.CommandType = CommandType.StoredProcedure
                    cmdCommand.CommandText = "spSSEliminarPapeleta"
                    cmdCommand.Parameters.Clear()

                    cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.Int).Value = Papeleta
                    cmdCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = dtFechaFicha.Value
                    cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja

                    cmdCommand.ExecuteNonQuery()
                End If
            Else
                MessageBox.Show("No hay Papeleta para eliminar.", "Papeleta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            ActualizarFichas()
        Catch errormnPapeleta_Click As Exception
            MessageBox.Show("No hay Papeleta para eliminar." + vbCrLf + errormnPapeleta_Click.ToString(), "Papeleta", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub

    Private Sub vwFichaDepositoCorte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles vwFichaDepositoCorte.Click
        If vwFichaDepositoCorte.RowCount > 1 Then
            Exit Sub
        End If
        If vwFichaDepositoCorte.IsRowSelected(vwFichaDepositoCorte.FocusedRowHandle) = False Then
            vwFichaDepositoCorte.SelectRow(vwFichaDepositoCorte.FocusedRowHandle)
        Else
            vwFichaDepositoCorte.UnselectRow(vwFichaDepositoCorte.FocusedRowHandle)
        End If
    End Sub


    '2007-016-EIM-01
    'REQ 156
    'Autor: Fernando Correa
    'Validar que no se puedan eliminar fichas de depósito (papeletas) si ya  estan asociadas a un comprobante de valores.
    Private Function VerificaPapeletaContenidaComprobanteServicio(ByVal Papeleta As Integer) As Integer

        Dim drLeer As SqlDataReader = Nothing

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSPapeletaContenidaComprobanteServicio"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@FolioPapeleta", SqlDbType.Int).Value = Papeleta
            cmdCommand.Parameters.Add("@Fecha", SqlDbType.DateTime).Value = dtFechaFicha.Value
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            drLeer = cmdCommand.ExecuteReader
            drLeer.Read()

            Return CType(drLeer("ContenidaComprobanteServicio").ToString().Trim, Integer)

        Catch errorVerificaPapeletaContenidaComprobanteServicio As Exception
            MessageBox.Show("No se pudo VerificaPapeletaContenidaComprobanteServicio" + vbCrLf _
                           + errorVerificaPapeletaContenidaComprobanteServicio.ToString(), "Fichas Depósito", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            Return 1
        Finally
            drLeer.Close()
        End Try
    End Function

End Class