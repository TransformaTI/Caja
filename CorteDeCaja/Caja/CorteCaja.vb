'Proposito : Pantalla para consulta del corte de caja 
'Autor : Ana Juárez 
'FCreacion : 14 de septiembre del 2005

Option Strict On

Imports System.Data.SqlClient
Imports System.Data

Public Class CorteCaja
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private dtIngresos As New DataTable()
    Private dtServiciosTecnicos As New DataTable()
    Private dtAño As New DataTable()
    Private dtTipoCorte As New DataTable()
    Private dtCaja As New DataTable()
    Private dtEmpresaConatble As New DataTable()
    Private dtFichasDeposito As New DataTable()
    Private dtGastos As New DataTable()
    Private dtVentaCredito As New DataTable()
    Private daSelect As New SqlDataAdapter()
    Private da As New SqlDataAdapter()
    Private rdrSelect As SqlDataReader
    Private drLeer As SqlDataReader

    Private Total As Decimal
    Private TotalSAF As Decimal
    Private TotalCredito As Decimal
    Private TotalAplicaciones As Decimal
    Private GastoCobranza As Decimal
    Private Descuentos As Decimal
    Private FondoNomina As Decimal
    Private PTU As Decimal
    Private Efectivales As Decimal
    Private TiendaPass As Decimal
    Private TotalFichas As Decimal
    Private VGN_FolioCorte As Integer
    Private VGM_Diferencia As Decimal
    Private VGS_Status As String
    Private strUsuario As String
    Private strUsuarioConsulta As String
    Private strStatus As String
    Friend WithEvents grdeReciboCaja As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblIngresosSAF As Label
    Public blnAdministrador As Boolean

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
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents btnImprimir As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnSalir As System.Windows.Forms.ToolBarButton
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView6 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Panel11 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GridControl3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumn36 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn35 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn33 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn32 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn34 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn40 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn41 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn42 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn43 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn44 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridView9 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn39 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn38 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn37 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Panel12 As System.Windows.Forms.Panel
    Friend WithEvents GridControl4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridColumn54 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn55 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn45 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn46 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn47 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn48 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn51 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn50 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn53 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn52 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn49 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn57 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn56 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn59 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn58 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn60 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn61 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents tlbCorteCaja As System.Windows.Forms.ToolBar
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GridView11 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridView12 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Public WithEvents btnGuardar As System.Windows.Forms.ToolBarButton
    Friend WithEvents PersistentRepository2 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents imgIconos As System.Windows.Forms.ImageList
    Friend WithEvents pnlIngresos As System.Windows.Forms.Panel
    Friend WithEvents pnlGeneral As System.Windows.Forms.Panel
    Friend WithEvents pnlAplicaciones As System.Windows.Forms.Panel
    Friend WithEvents lblIngresos As System.Windows.Forms.Label
    Friend WithEvents btnAgrergar As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnGastos As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents dtFechaOperacion As DevExpress.XtraEditors.DateEdit
    Friend WithEvents pnlServicios As System.Windows.Forms.Panel
    Friend WithEvents pnlGastos As System.Windows.Forms.Panel
    Friend WithEvents btnAplicaciones As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents lblFolioCorte As System.Windows.Forms.Label
    Friend WithEvents RepositoryItemTextEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdIngresos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView8 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdcDescripcion As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcVentaContado As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcVentaCredito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcTarjetaCredito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcParcial1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcCobranza As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcNotaIngreso As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcChequesDev As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcParcial2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents grdServiciosTecnicos As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView10 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn84 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn75 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn76 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn77 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn78 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn79 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn80 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn81 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn82 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents pnlAplicacion As System.Windows.Forms.Panel
    Friend WithEvents lblDiferencia As System.Windows.Forms.Label
    Friend WithEvents lblAplicaciones As System.Windows.Forms.Label
    Friend WithEvents pnlConceptosGasto As System.Windows.Forms.Panel
    Friend WithEvents Splitter2 As System.Windows.Forms.Splitter
    Friend WithEvents Splitter3 As System.Windows.Forms.Splitter
    Friend WithEvents pnlVentaCredito As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents pnlFichasDeposito As System.Windows.Forms.Panel
    Friend WithEvents pnAplicaciones As System.Windows.Forms.Panel
    Friend WithEvents grdAplicaciones As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwAplicaciones As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn62 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcTotalConceptoGastos As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdVentaCredito As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwVentaCredito As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn64 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcTotalVentaCredito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdFichaDeposito As DevExpress.XtraGrid.GridControl
    Friend WithEvents vwFichasDeposito As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents grdcFichaDeposito As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents grdcTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PersistentRepository3 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PersistentRepository4 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents PersistentRepository5 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents RepositoryItemTextEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents cmbTipoCorte As System.Windows.Forms.ComboBox
    Friend WithEvents btnPorAutorizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents cmbCaja As System.Windows.Forms.ComboBox
    Friend WithEvents lblCajaCmb As System.Windows.Forms.Label
    Friend WithEvents btnModificarStatus As System.Windows.Forms.ToolBarButton
    Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnActualizar As System.Windows.Forms.ToolBarButton
    Friend WithEvents lblServiciosTecnicos As System.Windows.Forms.Label
    Friend WithEvents grdcTarjetaAT As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn63 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn65 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblPosFechAnt As System.Windows.Forms.Label
    Friend WithEvents GridColumn66 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtEmpresa As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CorteCaja))
        Dim ColumnFilterInfo102 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo103 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo104 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo105 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo106 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo107 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo91 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo92 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo93 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo94 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo95 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo96 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo97 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo98 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo99 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo100 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo101 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo108 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo109 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo110 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo111 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo112 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo113 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo114 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo115 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo116 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo117 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo118 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo119 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo120 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo121 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo122 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo123 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo124 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo125 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo126 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo127 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo128 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo129 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo130 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo131 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo132 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo133 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo134 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo135 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo136 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo137 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo138 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo139 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo140 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo141 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo142 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo143 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo144 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo145 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo146 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo147 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo148 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo149 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo150 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo151 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo152 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo153 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo154 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo155 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo156 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo157 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo158 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo159 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo160 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo161 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo162 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo163 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo164 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo165 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo166 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo167 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo168 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo169 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo170 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo171 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo172 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo173 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo174 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo175 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo176 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo177 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo178 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo179 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Dim ColumnFilterInfo180 As DevExpress.XtraGrid.Columns.ColumnFilterInfo = New DevExpress.XtraGrid.Columns.ColumnFilterInfo()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tlbCorteCaja = New System.Windows.Forms.ToolBar()
        Me.btnAgrergar = New System.Windows.Forms.ToolBarButton()
        Me.btnAplicaciones = New System.Windows.Forms.ToolBarButton()
        Me.btnGastos = New System.Windows.Forms.ToolBarButton()
        Me.btnGuardar = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
        Me.btnPorAutorizar = New System.Windows.Forms.ToolBarButton()
        Me.btnModificarStatus = New System.Windows.Forms.ToolBarButton()
        Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
        Me.btnImprimir = New System.Windows.Forms.ToolBarButton()
        Me.btnActualizar = New System.Windows.Forms.ToolBarButton()
        Me.btnConsultar = New System.Windows.Forms.ToolBarButton()
        Me.btnSalir = New System.Windows.Forms.ToolBarButton()
        Me.imgIconos = New System.Windows.Forms.ImageList(Me.components)
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtEmpresa = New System.Windows.Forms.TextBox()
        Me.cboEmpresa = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipoCorte = New System.Windows.Forms.ComboBox()
        Me.dtFechaOperacion = New DevExpress.XtraEditors.DateEdit()
        Me.lblFolioCorte = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnlGeneral = New System.Windows.Forms.Panel()
        Me.pnlGastos = New System.Windows.Forms.Panel()
        Me.pnlAplicaciones = New System.Windows.Forms.Panel()
        Me.pnlVentaCredito = New System.Windows.Forms.Panel()
        Me.grdVentaCredito = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository3 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwVentaCredito = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn64 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTotalVentaCredito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Splitter3 = New System.Windows.Forms.Splitter()
        Me.pnAplicaciones = New System.Windows.Forms.Panel()
        Me.grdAplicaciones = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository4 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwAplicaciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn62 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTotalConceptoGastos = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Splitter2 = New System.Windows.Forms.Splitter()
        Me.pnlFichasDeposito = New System.Windows.Forms.Panel()
        Me.grdFichaDeposito = New DevExpress.XtraGrid.GridControl()
        Me.PersistentRepository5 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.RepositoryItemTextEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.vwFichasDeposito = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdcFichaDeposito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.pnlConceptosGasto = New System.Windows.Forms.Panel()
        Me.pnlAplicacion = New System.Windows.Forms.Panel()
        Me.lblDiferencia = New System.Windows.Forms.Label()
        Me.lblAplicaciones = New System.Windows.Forms.Label()
        Me.pnlServicios = New System.Windows.Forms.Panel()
        Me.lblIngresosSAF = New System.Windows.Forms.Label()
        Me.lblPosFechAnt = New System.Windows.Forms.Label()
        Me.lblServiciosTecnicos = New System.Windows.Forms.Label()
        Me.grdServiciosTecnicos = New DevExpress.XtraGrid.GridControl()
        Me.GridView10 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn84 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn75 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn66 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn76 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn77 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn63 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn78 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn79 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn80 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn81 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn82 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblIngresos = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.pnlIngresos = New System.Windows.Forms.Panel()
        Me.grdIngresos = New DevExpress.XtraGrid.GridControl()
        Me.GridView8 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.grdcDescripcion = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcVentaContado = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn65 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcVentaCredito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTarjetaCredito = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcTarjetaAT = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcParcial1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcCobranza = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcNotaIngreso = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdeReciboCaja = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcChequesDev = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.grdcParcial2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PersistentRepository2 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView6 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GridControl3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView11 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn36 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn35 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn33 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn32 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn34 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn40 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn41 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn42 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn43 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn44 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridView9 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn39 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn38 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn37 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Panel12 = New System.Windows.Forms.Panel()
        Me.GridControl4 = New DevExpress.XtraGrid.GridControl()
        Me.GridView12 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn54 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn55 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn45 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn46 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn47 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn48 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn51 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn50 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn53 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn52 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn49 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn57 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn56 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn59 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn58 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn60 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn61 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.lblCajaCmb = New System.Windows.Forms.Label()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dtFechaOperacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlGeneral.SuspendLayout()
        Me.pnlGastos.SuspendLayout()
        Me.pnlAplicaciones.SuspendLayout()
        Me.pnlVentaCredito.SuspendLayout()
        CType(Me.grdVentaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwVentaCredito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnAplicaciones.SuspendLayout()
        CType(Me.grdAplicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwAplicaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlFichasDeposito.SuspendLayout()
        CType(Me.grdFichaDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.vwFichasDeposito, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlAplicacion.SuspendLayout()
        Me.pnlServicios.SuspendLayout()
        CType(Me.grdServiciosTecnicos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlIngresos.SuspendLayout()
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel11.SuspendLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView12, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Turquoise
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        Me.ImageList1.Images.SetKeyName(2, "")
        Me.ImageList1.Images.SetKeyName(3, "")
        Me.ImageList1.Images.SetKeyName(4, "")
        Me.ImageList1.Images.SetKeyName(5, "")
        Me.ImageList1.Images.SetKeyName(6, "")
        Me.ImageList1.Images.SetKeyName(7, "")
        '
        'tlbCorteCaja
        '
        Me.tlbCorteCaja.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tlbCorteCaja.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.btnAgrergar, Me.btnAplicaciones, Me.btnGastos, Me.btnGuardar, Me.ToolBarButton2, Me.btnPorAutorizar, Me.btnModificarStatus, Me.ToolBarButton1, Me.btnImprimir, Me.btnActualizar, Me.btnConsultar, Me.btnSalir})
        Me.tlbCorteCaja.ButtonSize = New System.Drawing.Size(85, 40)
        Me.tlbCorteCaja.DropDownArrows = True
        Me.tlbCorteCaja.ImageList = Me.imgIconos
        Me.tlbCorteCaja.Location = New System.Drawing.Point(0, 0)
        Me.tlbCorteCaja.Name = "tlbCorteCaja"
        Me.tlbCorteCaja.ShowToolTips = True
        Me.tlbCorteCaja.Size = New System.Drawing.Size(1175, 43)
        Me.tlbCorteCaja.TabIndex = 22
        '
        'btnAgrergar
        '
        Me.btnAgrergar.ImageIndex = 0
        Me.btnAgrergar.Name = "btnAgrergar"
        Me.btnAgrergar.Text = "Agregar "
        '
        'btnAplicaciones
        '
        Me.btnAplicaciones.Enabled = False
        Me.btnAplicaciones.ImageIndex = 5
        Me.btnAplicaciones.Name = "btnAplicaciones"
        Me.btnAplicaciones.Text = "Fichas"
        '
        'btnGastos
        '
        Me.btnGastos.Enabled = False
        Me.btnGastos.ImageIndex = 1
        Me.btnGastos.Name = "btnGastos"
        Me.btnGastos.Text = "Gastos"
        '
        'btnGuardar
        '
        Me.btnGuardar.Enabled = False
        Me.btnGuardar.ImageIndex = 6
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Text = "Guardar"
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.Name = "ToolBarButton2"
        Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnPorAutorizar
        '
        Me.btnPorAutorizar.Enabled = False
        Me.btnPorAutorizar.ImageIndex = 2
        Me.btnPorAutorizar.Name = "btnPorAutorizar"
        Me.btnPorAutorizar.Text = "Por Autorizar"
        '
        'btnModificarStatus
        '
        Me.btnModificarStatus.Enabled = False
        Me.btnModificarStatus.ImageIndex = 0
        Me.btnModificarStatus.Name = "btnModificarStatus"
        Me.btnModificarStatus.Text = "Modificar Status"
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnImprimir
        '
        Me.btnImprimir.Enabled = False
        Me.btnImprimir.ImageIndex = 3
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Text = "Imprimir"
        '
        'btnActualizar
        '
        Me.btnActualizar.Enabled = False
        Me.btnActualizar.ImageIndex = 0
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Text = "Actualizar"
        '
        'btnConsultar
        '
        Me.btnConsultar.Enabled = False
        Me.btnConsultar.ImageIndex = 7
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Text = "Consultar"
        Me.btnConsultar.Visible = False
        '
        'btnSalir
        '
        Me.btnSalir.ImageIndex = 4
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Text = "Regresar"
        '
        'imgIconos
        '
        Me.imgIconos.ImageStream = CType(resources.GetObject("imgIconos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgIconos.TransparentColor = System.Drawing.Color.Transparent
        Me.imgIconos.Images.SetKeyName(0, "")
        Me.imgIconos.Images.SetKeyName(1, "")
        Me.imgIconos.Images.SetKeyName(2, "")
        Me.imgIconos.Images.SetKeyName(3, "")
        Me.imgIconos.Images.SetKeyName(4, "")
        Me.imgIconos.Images.SetKeyName(5, "")
        Me.imgIconos.Images.SetKeyName(6, "")
        Me.imgIconos.Images.SetKeyName(7, "")
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit6, Me.RepositoryItemTextEdit7, Me.RepositoryItemTextEdit3, Me.RepositoryItemTextEdit2})
        '
        'RepositoryItemTextEdit6
        '
        Me.RepositoryItemTextEdit6.Name = "RepositoryItemTextEdit6"
        Me.RepositoryItemTextEdit6.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit6.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit6.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'RepositoryItemTextEdit7
        '
        Me.RepositoryItemTextEdit7.Name = "RepositoryItemTextEdit7"
        Me.RepositoryItemTextEdit7.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit7.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit7.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'RepositoryItemTextEdit3
        '
        Me.RepositoryItemTextEdit3.Name = "RepositoryItemTextEdit3"
        Me.RepositoryItemTextEdit3.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit3.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit3.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        Me.RepositoryItemTextEdit2.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit2.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit2.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.txtEmpresa)
        Me.Panel1.Controls.Add(Me.cboEmpresa)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.cmbTipoCorte)
        Me.Panel1.Controls.Add(Me.dtFechaOperacion)
        Me.Panel1.Controls.Add(Me.lblFolioCorte)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 43)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1175, 36)
        Me.Panel1.TabIndex = 24
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
        'Label6
        '
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(584, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 42
        Me.Label6.Text = "Tipo Corte :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoCorte
        '
        Me.cmbTipoCorte.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoCorte.Location = New System.Drawing.Point(672, 6)
        Me.cmbTipoCorte.Name = "cmbTipoCorte"
        Me.cmbTipoCorte.Size = New System.Drawing.Size(130, 21)
        Me.cmbTipoCorte.TabIndex = 3
        '
        'dtFechaOperacion
        '
        Me.dtFechaOperacion.DateTime = New Date(2005, 6, 3, 0, 0, 0, 0)
        Me.dtFechaOperacion.Location = New System.Drawing.Point(480, 6)
        Me.dtFechaOperacion.Name = "dtFechaOperacion"
        Me.dtFechaOperacion.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.dtFechaOperacion.Size = New System.Drawing.Size(96, 25)
        Me.dtFechaOperacion.TabIndex = 2
        '
        'lblFolioCorte
        '
        Me.lblFolioCorte.Dock = System.Windows.Forms.DockStyle.Right
        Me.lblFolioCorte.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFolioCorte.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblFolioCorte.Location = New System.Drawing.Point(979, 0)
        Me.lblFolioCorte.Name = "lblFolioCorte"
        Me.lblFolioCorte.Size = New System.Drawing.Size(192, 32)
        Me.lblFolioCorte.TabIndex = 31
        Me.lblFolioCorte.Text = "Folio Corte :"
        Me.lblFolioCorte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(424, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 16)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "Fecha :"
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.PapayaWhip
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(1175, 21)
        Me.Label3.TabIndex = 26
        Me.Label3.Text = "I N G R E S O S     "
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlGeneral
        '
        Me.pnlGeneral.BackColor = System.Drawing.Color.DarkGray
        Me.pnlGeneral.Controls.Add(Me.pnlGastos)
        Me.pnlGeneral.Controls.Add(Me.pnlAplicacion)
        Me.pnlGeneral.Controls.Add(Me.pnlServicios)
        Me.pnlGeneral.Controls.Add(Me.pnlIngresos)
        Me.pnlGeneral.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGeneral.Location = New System.Drawing.Point(0, 79)
        Me.pnlGeneral.Name = "pnlGeneral"
        Me.pnlGeneral.Size = New System.Drawing.Size(1175, 567)
        Me.pnlGeneral.TabIndex = 25
        '
        'pnlGastos
        '
        Me.pnlGastos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlGastos.Controls.Add(Me.pnlAplicaciones)
        Me.pnlGastos.Controls.Add(Me.pnlConceptosGasto)
        Me.pnlGastos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlGastos.Location = New System.Drawing.Point(0, 232)
        Me.pnlGastos.Name = "pnlGastos"
        Me.pnlGastos.Size = New System.Drawing.Size(1175, 271)
        Me.pnlGastos.TabIndex = 58
        '
        'pnlAplicaciones
        '
        Me.pnlAplicaciones.BackColor = System.Drawing.SystemColors.Control
        Me.pnlAplicaciones.Controls.Add(Me.pnlVentaCredito)
        Me.pnlAplicaciones.Controls.Add(Me.Splitter3)
        Me.pnlAplicaciones.Controls.Add(Me.pnAplicaciones)
        Me.pnlAplicaciones.Controls.Add(Me.Splitter2)
        Me.pnlAplicaciones.Controls.Add(Me.pnlFichasDeposito)
        Me.pnlAplicaciones.Controls.Add(Me.Label4)
        Me.pnlAplicaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlAplicaciones.Location = New System.Drawing.Point(0, 0)
        Me.pnlAplicaciones.Name = "pnlAplicaciones"
        Me.pnlAplicaciones.Size = New System.Drawing.Size(1171, 267)
        Me.pnlAplicaciones.TabIndex = 30
        '
        'pnlVentaCredito
        '
        Me.pnlVentaCredito.BackColor = System.Drawing.Color.Lavender
        Me.pnlVentaCredito.Controls.Add(Me.grdVentaCredito)
        Me.pnlVentaCredito.Controls.Add(Me.Label11)
        Me.pnlVentaCredito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlVentaCredito.Location = New System.Drawing.Point(683, 21)
        Me.pnlVentaCredito.Name = "pnlVentaCredito"
        Me.pnlVentaCredito.Size = New System.Drawing.Size(488, 246)
        Me.pnlVentaCredito.TabIndex = 7
        '
        'grdVentaCredito
        '
        Me.grdVentaCredito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdVentaCredito.EditorsRepository = Me.PersistentRepository3
        Me.grdVentaCredito.Location = New System.Drawing.Point(0, 24)
        Me.grdVentaCredito.MainView = Me.vwVentaCredito
        Me.grdVentaCredito.Name = "grdVentaCredito"
        Me.grdVentaCredito.Size = New System.Drawing.Size(488, 222)
        Me.grdVentaCredito.TabIndex = 36
        Me.grdVentaCredito.Text = "GridControl2"
        '
        'PersistentRepository3
        '
        Me.PersistentRepository3.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit4})
        '
        'RepositoryItemTextEdit4
        '
        Me.RepositoryItemTextEdit4.Name = "RepositoryItemTextEdit4"
        Me.RepositoryItemTextEdit4.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit4.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit4.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwVentaCredito
        '
        Me.vwVentaCredito.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwVentaCredito.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn64, Me.grdcTotalVentaCredito})
        Me.vwVentaCredito.DefaultEdit = Me.RepositoryItemTextEdit4
        Me.vwVentaCredito.Name = "vwVentaCredito"
        Me.vwVentaCredito.ViewOptions = CType(((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn64
        '
        Me.GridColumn64.Caption = "Concepto"
        Me.GridColumn64.FieldName = "Concepto"
        Me.GridColumn64.FilterInfo = ColumnFilterInfo102
        Me.GridColumn64.Name = "GridColumn64"
        Me.GridColumn64.VisibleIndex = 0
        Me.GridColumn64.Width = 150
        '
        'grdcTotalVentaCredito
        '
        Me.grdcTotalVentaCredito.Caption = "Total"
        Me.grdcTotalVentaCredito.FieldName = "Total"
        Me.grdcTotalVentaCredito.FilterInfo = ColumnFilterInfo103
        Me.grdcTotalVentaCredito.FormatString = "$#,#.00"
        Me.grdcTotalVentaCredito.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcTotalVentaCredito.Name = "grdcTotalVentaCredito"
        Me.grdcTotalVentaCredito.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcTotalVentaCredito.SummaryItem.FieldName = "VentasContado"
        Me.grdcTotalVentaCredito.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcTotalVentaCredito.VisibleIndex = 1
        Me.grdcTotalVentaCredito.Width = 150
        '
        'Label11
        '
        Me.Label11.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label11.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(0, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(488, 24)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "DOCUMENTOS"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Splitter3
        '
        Me.Splitter3.Location = New System.Drawing.Point(680, 21)
        Me.Splitter3.Name = "Splitter3"
        Me.Splitter3.Size = New System.Drawing.Size(3, 246)
        Me.Splitter3.TabIndex = 6
        Me.Splitter3.TabStop = False
        '
        'pnAplicaciones
        '
        Me.pnAplicaciones.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.pnAplicaciones.Controls.Add(Me.grdAplicaciones)
        Me.pnAplicaciones.Controls.Add(Me.Label7)
        Me.pnAplicaciones.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnAplicaciones.Location = New System.Drawing.Point(339, 21)
        Me.pnAplicaciones.Name = "pnAplicaciones"
        Me.pnAplicaciones.Size = New System.Drawing.Size(341, 246)
        Me.pnAplicaciones.TabIndex = 5
        '
        'grdAplicaciones
        '
        Me.grdAplicaciones.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdAplicaciones.EditorsRepository = Me.PersistentRepository4
        Me.grdAplicaciones.Location = New System.Drawing.Point(0, 24)
        Me.grdAplicaciones.MainView = Me.vwAplicaciones
        Me.grdAplicaciones.Name = "grdAplicaciones"
        Me.grdAplicaciones.Size = New System.Drawing.Size(341, 222)
        Me.grdAplicaciones.TabIndex = 35
        Me.grdAplicaciones.Text = "GridControl2"
        '
        'PersistentRepository4
        '
        Me.PersistentRepository4.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit5})
        '
        'RepositoryItemTextEdit5
        '
        Me.RepositoryItemTextEdit5.Name = "RepositoryItemTextEdit5"
        Me.RepositoryItemTextEdit5.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit5.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit5.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwAplicaciones
        '
        Me.vwAplicaciones.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwAplicaciones.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn62, Me.grdcTotalConceptoGastos})
        Me.vwAplicaciones.DefaultEdit = Me.RepositoryItemTextEdit5
        Me.vwAplicaciones.Name = "vwAplicaciones"
        Me.vwAplicaciones.VertScrollTipFieldName = Nothing
        Me.vwAplicaciones.ViewOptions = CType(((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn62
        '
        Me.GridColumn62.Caption = "Concepto"
        Me.GridColumn62.FieldName = "Concepto"
        Me.GridColumn62.FilterInfo = ColumnFilterInfo104
        Me.GridColumn62.Name = "GridColumn62"
        Me.GridColumn62.VisibleIndex = 0
        Me.GridColumn62.Width = 150
        '
        'grdcTotalConceptoGastos
        '
        Me.grdcTotalConceptoGastos.Caption = "Total"
        Me.grdcTotalConceptoGastos.FieldName = "Total"
        Me.grdcTotalConceptoGastos.FilterInfo = ColumnFilterInfo105
        Me.grdcTotalConceptoGastos.FormatString = "$#,#.00"
        Me.grdcTotalConceptoGastos.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcTotalConceptoGastos.Name = "grdcTotalConceptoGastos"
        Me.grdcTotalConceptoGastos.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcTotalConceptoGastos.SummaryItem.FieldName = "VentasContado"
        Me.grdcTotalConceptoGastos.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcTotalConceptoGastos.VisibleIndex = 1
        Me.grdcTotalConceptoGastos.Width = 150
        '
        'Label7
        '
        Me.Label7.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(0, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(341, 24)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "OTROS"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Splitter2
        '
        Me.Splitter2.Location = New System.Drawing.Point(336, 21)
        Me.Splitter2.Name = "Splitter2"
        Me.Splitter2.Size = New System.Drawing.Size(3, 246)
        Me.Splitter2.TabIndex = 4
        Me.Splitter2.TabStop = False
        '
        'pnlFichasDeposito
        '
        Me.pnlFichasDeposito.BackColor = System.Drawing.Color.Azure
        Me.pnlFichasDeposito.Controls.Add(Me.grdFichaDeposito)
        Me.pnlFichasDeposito.Controls.Add(Me.Label2)
        Me.pnlFichasDeposito.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnlFichasDeposito.Location = New System.Drawing.Point(0, 21)
        Me.pnlFichasDeposito.Name = "pnlFichasDeposito"
        Me.pnlFichasDeposito.Size = New System.Drawing.Size(336, 246)
        Me.pnlFichasDeposito.TabIndex = 3
        '
        'grdFichaDeposito
        '
        Me.grdFichaDeposito.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdFichaDeposito.EditorsRepository = Me.PersistentRepository5
        Me.grdFichaDeposito.Location = New System.Drawing.Point(0, 24)
        Me.grdFichaDeposito.MainView = Me.vwFichasDeposito
        Me.grdFichaDeposito.Name = "grdFichaDeposito"
        Me.grdFichaDeposito.Size = New System.Drawing.Size(336, 222)
        Me.grdFichaDeposito.TabIndex = 34
        Me.grdFichaDeposito.Text = "GridControl2"
        '
        'PersistentRepository5
        '
        Me.PersistentRepository5.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit8})
        '
        'RepositoryItemTextEdit8
        '
        Me.RepositoryItemTextEdit8.Name = "RepositoryItemTextEdit8"
        Me.RepositoryItemTextEdit8.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit8.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit8.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'vwFichasDeposito
        '
        Me.vwFichasDeposito.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.vwFichasDeposito.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.grdcFichaDeposito, Me.grdcTotal})
        Me.vwFichasDeposito.DefaultEdit = Me.RepositoryItemTextEdit8
        Me.vwFichasDeposito.Name = "vwFichasDeposito"
        Me.vwFichasDeposito.ViewOptions = CType(((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'grdcFichaDeposito
        '
        Me.grdcFichaDeposito.Caption = "Ficha de depósito"
        Me.grdcFichaDeposito.FieldName = "Tipo"
        Me.grdcFichaDeposito.FilterInfo = ColumnFilterInfo106
        Me.grdcFichaDeposito.Name = "grdcFichaDeposito"
        Me.grdcFichaDeposito.VisibleIndex = 0
        Me.grdcFichaDeposito.Width = 150
        '
        'grdcTotal
        '
        Me.grdcTotal.Caption = "Total"
        Me.grdcTotal.FieldName = "Total"
        Me.grdcTotal.FilterInfo = ColumnFilterInfo107
        Me.grdcTotal.FormatString = "$#,#.00"
        Me.grdcTotal.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcTotal.Name = "grdcTotal"
        Me.grdcTotal.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcTotal.SummaryItem.FieldName = "VentasContado"
        Me.grdcTotal.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcTotal.VisibleIndex = 1
        Me.grdcTotal.Width = 150
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.InactiveCaptionText
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(336, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "FICHAS DE DEPÓSITO"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AllowDrop = True
        Me.Label4.BackColor = System.Drawing.Color.Azure
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkBlue
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(1171, 21)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "A P L I C A C I O N E S"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pnlConceptosGasto
        '
        Me.pnlConceptosGasto.BackColor = System.Drawing.Color.White
        Me.pnlConceptosGasto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pnlConceptosGasto.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pnlConceptosGasto.Location = New System.Drawing.Point(0, 0)
        Me.pnlConceptosGasto.Name = "pnlConceptosGasto"
        Me.pnlConceptosGasto.Size = New System.Drawing.Size(1171, 267)
        Me.pnlConceptosGasto.TabIndex = 31
        Me.pnlConceptosGasto.Visible = False
        '
        'pnlAplicacion
        '
        Me.pnlAplicacion.BackColor = System.Drawing.Color.White
        Me.pnlAplicacion.Controls.Add(Me.lblDiferencia)
        Me.pnlAplicacion.Controls.Add(Me.lblAplicaciones)
        Me.pnlAplicacion.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlAplicacion.Location = New System.Drawing.Point(0, 503)
        Me.pnlAplicacion.Name = "pnlAplicacion"
        Me.pnlAplicacion.Size = New System.Drawing.Size(1175, 64)
        Me.pnlAplicacion.TabIndex = 57
        '
        'lblDiferencia
        '
        Me.lblDiferencia.BackColor = System.Drawing.Color.White
        Me.lblDiferencia.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblDiferencia.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiferencia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblDiferencia.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblDiferencia.Location = New System.Drawing.Point(0, 32)
        Me.lblDiferencia.Name = "lblDiferencia"
        Me.lblDiferencia.Size = New System.Drawing.Size(1175, 32)
        Me.lblDiferencia.TabIndex = 56
        Me.lblDiferencia.Text = "Diferencia"
        Me.lblDiferencia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAplicaciones
        '
        Me.lblAplicaciones.BackColor = System.Drawing.Color.White
        Me.lblAplicaciones.Dock = System.Windows.Forms.DockStyle.Top
        Me.lblAplicaciones.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAplicaciones.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblAplicaciones.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblAplicaciones.Location = New System.Drawing.Point(0, 0)
        Me.lblAplicaciones.Name = "lblAplicaciones"
        Me.lblAplicaciones.Size = New System.Drawing.Size(1175, 32)
        Me.lblAplicaciones.TabIndex = 55
        Me.lblAplicaciones.Text = "Aplicaciones"
        Me.lblAplicaciones.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'pnlServicios
        '
        Me.pnlServicios.Controls.Add(Me.lblIngresosSAF)
        Me.pnlServicios.Controls.Add(Me.lblPosFechAnt)
        Me.pnlServicios.Controls.Add(Me.lblServiciosTecnicos)
        Me.pnlServicios.Controls.Add(Me.grdServiciosTecnicos)
        Me.pnlServicios.Controls.Add(Me.lblIngresos)
        Me.pnlServicios.Controls.Add(Me.Label10)
        Me.pnlServicios.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlServicios.Location = New System.Drawing.Point(0, 128)
        Me.pnlServicios.Name = "pnlServicios"
        Me.pnlServicios.Size = New System.Drawing.Size(1175, 104)
        Me.pnlServicios.TabIndex = 30
        '
        'lblIngresosSAF
        '
        Me.lblIngresosSAF.AutoSize = True
        Me.lblIngresosSAF.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblIngresosSAF.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIngresosSAF.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblIngresosSAF.Location = New System.Drawing.Point(528, 1)
        Me.lblIngresosSAF.Name = "lblIngresosSAF"
        Me.lblIngresosSAF.Size = New System.Drawing.Size(246, 19)
        Me.lblIngresosSAF.TabIndex = 61
        Me.lblIngresosSAF.Text = "INGRESOS (SALDO A FAVOR)"
        Me.lblIngresosSAF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblPosFechAnt
        '
        Me.lblPosFechAnt.AutoSize = True
        Me.lblPosFechAnt.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblPosFechAnt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPosFechAnt.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblPosFechAnt.Location = New System.Drawing.Point(932, 1)
        Me.lblPosFechAnt.Name = "lblPosFechAnt"
        Me.lblPosFechAnt.Size = New System.Drawing.Size(231, 19)
        Me.lblPosFechAnt.TabIndex = 60
        Me.lblPosFechAnt.Text = "CHEQUES PV ANTERIORES "
        Me.lblPosFechAnt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblServiciosTecnicos
        '
        Me.lblServiciosTecnicos.AutoSize = True
        Me.lblServiciosTecnicos.BackColor = System.Drawing.Color.CornflowerBlue
        Me.lblServiciosTecnicos.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblServiciosTecnicos.ForeColor = System.Drawing.Color.DarkBlue
        Me.lblServiciosTecnicos.Location = New System.Drawing.Point(128, 2)
        Me.lblServiciosTecnicos.Name = "lblServiciosTecnicos"
        Me.lblServiciosTecnicos.Size = New System.Drawing.Size(142, 19)
        Me.lblServiciosTecnicos.TabIndex = 59
        Me.lblServiciosTecnicos.Text = "SALDO A FAVOR"
        Me.lblServiciosTecnicos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'grdServiciosTecnicos
        '
        Me.grdServiciosTecnicos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdServiciosTecnicos.EditorsRepository = Me.PersistentRepository1
        Me.grdServiciosTecnicos.Location = New System.Drawing.Point(0, 24)
        Me.grdServiciosTecnicos.MainView = Me.GridView10
        Me.grdServiciosTecnicos.Name = "grdServiciosTecnicos"
        Me.grdServiciosTecnicos.Size = New System.Drawing.Size(1175, 56)
        Me.grdServiciosTecnicos.TabIndex = 32
        Me.grdServiciosTecnicos.Text = "GridControl5"
        '
        'GridView10
        '
        Me.GridView10.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.GridView10.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn84, Me.GridColumn75, Me.GridColumn66, Me.GridColumn76, Me.GridColumn77, Me.GridColumn63, Me.GridColumn78, Me.GridColumn79, Me.GridColumn80, Me.GridColumn81, Me.GridColumn82})
        Me.GridView10.DefaultEdit = Me.RepositoryItemTextEdit2
        Me.GridView10.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "VentasContado", Me.GridColumn75, "#,#.00")})
        Me.GridView10.Name = "GridView10"
        Me.GridView10.ViewOptions = CType(((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn84
        '
        Me.GridColumn84.Caption = "GridColumn84"
        Me.GridColumn84.FieldName = "Descripcion"
        Me.GridColumn84.FilterInfo = ColumnFilterInfo91
        Me.GridColumn84.Name = "GridColumn84"
        Me.GridColumn84.VisibleIndex = 0
        '
        'GridColumn75
        '
        Me.GridColumn75.Caption = "GridColumn75"
        Me.GridColumn75.FieldName = "VentasContado"
        Me.GridColumn75.FilterInfo = ColumnFilterInfo92
        Me.GridColumn75.FormatString = "$#,#.00"
        Me.GridColumn75.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn75.Name = "GridColumn75"
        Me.GridColumn75.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn75.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn75.VisibleIndex = 1
        '
        'GridColumn66
        '
        Me.GridColumn66.Caption = "GridColumn66"
        Me.GridColumn66.FieldName = "ChequesPV"
        Me.GridColumn66.FilterInfo = ColumnFilterInfo93
        Me.GridColumn66.FormatString = "$#,#.00"
        Me.GridColumn66.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn66.Name = "GridColumn66"
        Me.GridColumn66.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn66.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn66.VisibleIndex = 2
        '
        'GridColumn76
        '
        Me.GridColumn76.Caption = "GridColumn76"
        Me.GridColumn76.FieldName = "VentasCredito"
        Me.GridColumn76.FilterInfo = ColumnFilterInfo94
        Me.GridColumn76.FormatString = "$#,#.00"
        Me.GridColumn76.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn76.Name = "GridColumn76"
        Me.GridColumn76.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn76.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn76.VisibleIndex = 3
        '
        'GridColumn77
        '
        Me.GridColumn77.Caption = "GridColumn77"
        Me.GridColumn77.FieldName = "TarjetaCredito"
        Me.GridColumn77.FilterInfo = ColumnFilterInfo95
        Me.GridColumn77.FormatString = "$#,#.00"
        Me.GridColumn77.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn77.Name = "GridColumn77"
        Me.GridColumn77.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn77.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn77.VisibleIndex = 4
        '
        'GridColumn63
        '
        Me.GridColumn63.Caption = "GridColumn63"
        Me.GridColumn63.FieldName = "TarjetaAT"
        Me.GridColumn63.FilterInfo = ColumnFilterInfo96
        Me.GridColumn63.FormatString = "$#,#.00"
        Me.GridColumn63.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn63.Name = "GridColumn63"
        Me.GridColumn63.SummaryItem.DisplayFormat = "{0:C}"
        Me.GridColumn63.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn63.VisibleIndex = 5
        '
        'GridColumn78
        '
        Me.GridColumn78.Caption = "PARCIAL1"
        Me.GridColumn78.FieldName = "Parcial1"
        Me.GridColumn78.FilterInfo = ColumnFilterInfo97
        Me.GridColumn78.FormatString = "$#,#.00"
        Me.GridColumn78.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn78.Name = "GridColumn78"
        Me.GridColumn78.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn78.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn78.VisibleIndex = 6
        '
        'GridColumn79
        '
        Me.GridColumn79.Caption = "GridColumn79"
        Me.GridColumn79.FieldName = "Cobranza"
        Me.GridColumn79.FilterInfo = ColumnFilterInfo98
        Me.GridColumn79.FormatString = "$#,#.00"
        Me.GridColumn79.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn79.Name = "GridColumn79"
        Me.GridColumn79.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn79.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn79.VisibleIndex = 7
        '
        'GridColumn80
        '
        Me.GridColumn80.Caption = "GridColumn80"
        Me.GridColumn80.FieldName = "NotaIngreso"
        Me.GridColumn80.FilterInfo = ColumnFilterInfo99
        Me.GridColumn80.FormatString = "$#,#.00"
        Me.GridColumn80.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn80.Name = "GridColumn80"
        Me.GridColumn80.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn80.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn80.VisibleIndex = 8
        '
        'GridColumn81
        '
        Me.GridColumn81.Caption = "GridColumn81"
        Me.GridColumn81.FieldName = "ChequesDev"
        Me.GridColumn81.FilterInfo = ColumnFilterInfo100
        Me.GridColumn81.FormatString = "$#,#.00"
        Me.GridColumn81.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn81.Name = "GridColumn81"
        Me.GridColumn81.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn81.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn81.VisibleIndex = 9
        '
        'GridColumn82
        '
        Me.GridColumn82.Caption = "PARCIAL2"
        Me.GridColumn82.FieldName = "Parcial2"
        Me.GridColumn82.FilterInfo = ColumnFilterInfo101
        Me.GridColumn82.FormatString = "$#,#.00"
        Me.GridColumn82.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn82.Name = "GridColumn82"
        Me.GridColumn82.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn82.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn82.VisibleIndex = 10
        '
        'lblIngresos
        '
        Me.lblIngresos.BackColor = System.Drawing.Color.White
        Me.lblIngresos.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblIngresos.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIngresos.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblIngresos.Location = New System.Drawing.Point(0, 80)
        Me.lblIngresos.Name = "lblIngresos"
        Me.lblIngresos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIngresos.Size = New System.Drawing.Size(1175, 24)
        Me.lblIngresos.TabIndex = 31
        Me.lblIngresos.Text = "Ingresos"
        Me.lblIngresos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.BackColor = System.Drawing.Color.Lavender
        Me.Label10.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label10.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(0, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label10.Size = New System.Drawing.Size(1175, 24)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Servicios Técnicos"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnlIngresos
        '
        Me.pnlIngresos.Controls.Add(Me.grdIngresos)
        Me.pnlIngresos.Controls.Add(Me.Label3)
        Me.pnlIngresos.Dock = System.Windows.Forms.DockStyle.Top
        Me.pnlIngresos.Location = New System.Drawing.Point(0, 0)
        Me.pnlIngresos.Name = "pnlIngresos"
        Me.pnlIngresos.Size = New System.Drawing.Size(1175, 128)
        Me.pnlIngresos.TabIndex = 27
        '
        'grdIngresos
        '
        Me.grdIngresos.BackColor = System.Drawing.Color.Khaki
        Me.grdIngresos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdIngresos.EditorsRepository = Me.PersistentRepository1
        Me.grdIngresos.ForeColor = System.Drawing.Color.Green
        Me.grdIngresos.Location = New System.Drawing.Point(0, 21)
        Me.grdIngresos.MainView = Me.GridView8
        Me.grdIngresos.Name = "grdIngresos"
        Me.grdIngresos.Size = New System.Drawing.Size(1175, 107)
        Me.grdIngresos.TabIndex = 30
        Me.grdIngresos.Text = "GridControl2"
        '
        'GridView8
        '
        Me.GridView8.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.GridView8.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.grdcDescripcion, Me.grdcVentaContado, Me.GridColumn65, Me.grdcVentaCredito, Me.grdcTarjetaCredito, Me.grdcTarjetaAT, Me.grdcParcial1, Me.grdcCobranza, Me.grdcNotaIngreso, Me.grdeReciboCaja, Me.grdcChequesDev, Me.grdcParcial2})
        Me.GridView8.DefaultEdit = Me.RepositoryItemTextEdit3
        Me.GridView8.GroupSummary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "VentasContado", Me.grdcVentaContado, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "VentasCredito", Me.grdcVentaCredito, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "TarjetaCredito", Me.grdcTarjetaCredito, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Parcial1", Me.grdcParcial1, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Cobranza", Me.grdcCobranza, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "NotaIngreso", Me.grdcNotaIngreso, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "ChequesDev", Me.grdcChequesDev, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "Parcial2", Me.grdcParcial2, "{0:c}"), New DevExpress.XtraGrid.GridSummaryItem(DevExpress.XtraGrid.SummaryItemType.Sum, "ReciboCaja", Me.grdeReciboCaja, "{0:c}")})
        Me.GridView8.Name = "GridView8"
        Me.GridView8.VertScrollTipFieldName = Nothing
        Me.GridView8.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFooter) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'grdcDescripcion
        '
        Me.grdcDescripcion.Caption = "Descripción"
        Me.grdcDescripcion.FieldName = "Descripcion"
        Me.grdcDescripcion.FilterInfo = ColumnFilterInfo108
        Me.grdcDescripcion.Name = "grdcDescripcion"
        Me.grdcDescripcion.VisibleIndex = 0
        '
        'grdcVentaContado
        '
        Me.grdcVentaContado.Caption = "V. Contado"
        Me.grdcVentaContado.FieldName = "VentasContado"
        Me.grdcVentaContado.FilterInfo = ColumnFilterInfo109
        Me.grdcVentaContado.FormatString = "$#,#.00"
        Me.grdcVentaContado.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcVentaContado.Name = "grdcVentaContado"
        Me.grdcVentaContado.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcVentaContado.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcVentaContado.VisibleIndex = 1
        '
        'GridColumn65
        '
        Me.GridColumn65.Caption = "Cheques Posf.V"
        Me.GridColumn65.FieldName = "ChequesPV"
        Me.GridColumn65.FilterInfo = ColumnFilterInfo110
        Me.GridColumn65.FormatString = "$#,#.00"
        Me.GridColumn65.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.GridColumn65.Name = "GridColumn65"
        Me.GridColumn65.SummaryItem.DisplayFormat = "{0:c}"
        Me.GridColumn65.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.GridColumn65.VisibleIndex = 2
        '
        'grdcVentaCredito
        '
        Me.grdcVentaCredito.Caption = "V. Crédito"
        Me.grdcVentaCredito.FieldName = "VentasCredito"
        Me.grdcVentaCredito.FilterInfo = ColumnFilterInfo111
        Me.grdcVentaCredito.FormatString = "$#,#.00"
        Me.grdcVentaCredito.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcVentaCredito.Name = "grdcVentaCredito"
        Me.grdcVentaCredito.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcVentaCredito.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcVentaCredito.VisibleIndex = 3
        '
        'grdcTarjetaCredito
        '
        Me.grdcTarjetaCredito.Caption = "T. Crédito"
        Me.grdcTarjetaCredito.FieldName = "TarjetaCredito"
        Me.grdcTarjetaCredito.FilterInfo = ColumnFilterInfo112
        Me.grdcTarjetaCredito.FormatString = "$#,#.00"
        Me.grdcTarjetaCredito.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcTarjetaCredito.Name = "grdcTarjetaCredito"
        Me.grdcTarjetaCredito.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcTarjetaCredito.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcTarjetaCredito.VisibleIndex = 4
        '
        'grdcTarjetaAT
        '
        Me.grdcTarjetaAT.Caption = "Tarjeta AT"
        Me.grdcTarjetaAT.FieldName = "TarjetaAT"
        Me.grdcTarjetaAT.FilterInfo = ColumnFilterInfo113
        Me.grdcTarjetaAT.FormatString = "$#,#.00"
        Me.grdcTarjetaAT.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcTarjetaAT.Name = "grdcTarjetaAT"
        Me.grdcTarjetaAT.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcTarjetaAT.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcTarjetaAT.VisibleIndex = 5
        '
        'grdcParcial1
        '
        Me.grdcParcial1.Caption = "Edificios"
        Me.grdcParcial1.FieldName = "Edificios"
        Me.grdcParcial1.FilterInfo = ColumnFilterInfo114
        Me.grdcParcial1.FormatString = "$#,#.00"
        Me.grdcParcial1.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcParcial1.Name = "grdcParcial1"
        Me.grdcParcial1.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcParcial1.SummaryItem.FieldName = "Parcial1"
        Me.grdcParcial1.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcParcial1.VisibleIndex = 6
        '
        'grdcCobranza
        '
        Me.grdcCobranza.Caption = "Cobranzas"
        Me.grdcCobranza.FieldName = "Cobranza"
        Me.grdcCobranza.FilterInfo = ColumnFilterInfo115
        Me.grdcCobranza.FormatString = "$#,#.00"
        Me.grdcCobranza.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcCobranza.Name = "grdcCobranza"
        Me.grdcCobranza.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcCobranza.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcCobranza.VisibleIndex = 7
        '
        'grdcNotaIngreso
        '
        Me.grdcNotaIngreso.Caption = "N. Ingreso"
        Me.grdcNotaIngreso.FieldName = "NotaIngreso"
        Me.grdcNotaIngreso.FilterInfo = ColumnFilterInfo116
        Me.grdcNotaIngreso.FormatString = "$#,#.00"
        Me.grdcNotaIngreso.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcNotaIngreso.Name = "grdcNotaIngreso"
        Me.grdcNotaIngreso.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcNotaIngreso.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcNotaIngreso.VisibleIndex = 8
        '
        'grdeReciboCaja
        '
        Me.grdeReciboCaja.Caption = "Recibo de caja"
        Me.grdeReciboCaja.FieldName = "ValeCaja"
        Me.grdeReciboCaja.FilterInfo = ColumnFilterInfo117
        Me.grdeReciboCaja.FormatString = "$#,#.00"
        Me.grdeReciboCaja.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdeReciboCaja.Name = "grdeReciboCaja"
        Me.grdeReciboCaja.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdeReciboCaja.SummaryItem.FieldName = "ReciboCaja"
        Me.grdeReciboCaja.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdeReciboCaja.VisibleIndex = 9
        '
        'grdcChequesDev
        '
        Me.grdcChequesDev.Caption = "Cheques dev."
        Me.grdcChequesDev.FieldName = "ChequesDev"
        Me.grdcChequesDev.FilterInfo = ColumnFilterInfo118
        Me.grdcChequesDev.FormatString = "$#,#.00"
        Me.grdcChequesDev.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcChequesDev.Name = "grdcChequesDev"
        Me.grdcChequesDev.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcChequesDev.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcChequesDev.VisibleIndex = 10
        '
        'grdcParcial2
        '
        Me.grdcParcial2.Caption = "PARCIAL "
        Me.grdcParcial2.FieldName = "Parcial2"
        Me.grdcParcial2.FilterInfo = ColumnFilterInfo119
        Me.grdcParcial2.FormatString = "$#,#.00"
        Me.grdcParcial2.FormatType = DevExpress.XtraGrid.Columns.FormatTypeEnum.Numeric
        Me.grdcParcial2.Name = "grdcParcial2"
        Me.grdcParcial2.SummaryItem.DisplayFormat = "{0:c}"
        Me.grdcParcial2.SummaryItem.SummaryType = DevExpress.XtraGrid.SummaryItemType.Sum
        Me.grdcParcial2.VisibleIndex = 11
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "T. Crédito"
        Me.GridColumn17.FilterInfo = ColumnFilterInfo120
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.VisibleIndex = 3
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Crédito"
        Me.GridColumn7.FieldName = "VentasCredito"
        Me.GridColumn7.FilterInfo = ColumnFilterInfo121
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.VisibleIndex = 2
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Contado"
        Me.GridColumn6.FieldName = "VentasContado"
        Me.GridColumn6.FilterInfo = ColumnFilterInfo122
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.VisibleIndex = 1
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Descripción"
        Me.GridColumn5.FieldName = "Descripcion"
        Me.GridColumn5.FilterInfo = ColumnFilterInfo123
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.VisibleIndex = 0
        '
        'GridView5
        '
        Me.GridView5.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.GridView5.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.GridView5.GroupPanelText = "I N G R E S O S             (GAS L.P.)"
        Me.GridView5.Name = "GridView5"
        Me.GridView5.VertScrollTipFieldName = Nothing
        Me.GridView5.ViewOptions = CType(((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Contado"
        Me.GridColumn13.FieldName = "VentasContado"
        Me.GridColumn13.FilterInfo = ColumnFilterInfo124
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.VisibleIndex = 1
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "T. Crédito"
        Me.GridColumn18.FilterInfo = ColumnFilterInfo125
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.VisibleIndex = 3
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Descripción"
        Me.GridColumn12.FieldName = "Descripcion"
        Me.GridColumn12.FilterInfo = ColumnFilterInfo126
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.VisibleIndex = 0
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Crédito"
        Me.GridColumn14.FieldName = "VentasCredito"
        Me.GridColumn14.FilterInfo = ColumnFilterInfo127
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.VisibleIndex = 2
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Importe"
        Me.GridColumn16.FieldName = "VentaContado"
        Me.GridColumn16.FilterInfo = ColumnFilterInfo128
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.VisibleIndex = 1
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Descripción"
        Me.GridColumn15.FieldName = "Descripcion"
        Me.GridColumn15.FilterInfo = ColumnFilterInfo129
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.VisibleIndex = 0
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        Me.RepositoryItemTextEdit1.Properties.AllowFocused = False
        Me.RepositoryItemTextEdit1.Properties.AutoHeight = False
        Me.RepositoryItemTextEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        '
        'GridView3
        '
        Me.GridView3.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.GridView3.GroupPanelText = "A P L I C A C I O N E S   (Fichas de depósito)"
        Me.GridView3.Name = "GridView3"
        '
        'GridView2
        '
        Me.GridView2.Name = "GridView2"
        Me.GridView2.VertScrollTipFieldName = Nothing
        Me.GridView2.ViewOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowFilterPanel) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "PARCIAL  (2)"
        Me.GridColumn20.FilterInfo = ColumnFilterInfo130
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.VisibleIndex = 8
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "E. Negativas"
        Me.GridColumn10.FilterInfo = ColumnFilterInfo131
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.VisibleIndex = 7
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "N. Ingreso"
        Me.GridColumn9.FilterInfo = ColumnFilterInfo132
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.VisibleIndex = 6
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Cobranzas"
        Me.GridColumn8.FilterInfo = ColumnFilterInfo133
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.VisibleIndex = 5
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "PARCIAL  (1)"
        Me.GridColumn19.FilterInfo = ColumnFilterInfo134
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.VisibleIndex = 4
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "T. Crédito"
        Me.GridColumn4.FilterInfo = ColumnFilterInfo135
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.VisibleIndex = 3
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Crédito"
        Me.GridColumn2.FieldName = "VentasCredito"
        Me.GridColumn2.FilterInfo = ColumnFilterInfo136
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.VisibleIndex = 2
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "Contado"
        Me.GridColumn1.FieldName = "VentasContado"
        Me.GridColumn1.FilterInfo = ColumnFilterInfo137
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.VisibleIndex = 1
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Descripción"
        Me.GridColumn3.FieldName = "Descripcion"
        Me.GridColumn3.FilterInfo = ColumnFilterInfo138
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.VisibleIndex = 0
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "GridColumn28"
        Me.GridColumn28.FilterInfo = ColumnFilterInfo139
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.VisibleIndex = 7
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "GridColumn27"
        Me.GridColumn27.FilterInfo = ColumnFilterInfo140
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.VisibleIndex = 6
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "GridColumn26"
        Me.GridColumn26.FilterInfo = ColumnFilterInfo141
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.VisibleIndex = 5
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "GridColumn25"
        Me.GridColumn25.FilterInfo = ColumnFilterInfo142
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.VisibleIndex = 4
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "GridColumn24"
        Me.GridColumn24.FilterInfo = ColumnFilterInfo143
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.VisibleIndex = 3
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "GridColumn23"
        Me.GridColumn23.FilterInfo = ColumnFilterInfo144
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.VisibleIndex = 2
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "GridColumn22"
        Me.GridColumn22.FilterInfo = ColumnFilterInfo145
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.VisibleIndex = 1
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "GridColumn21"
        Me.GridColumn21.FilterInfo = ColumnFilterInfo146
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.VisibleIndex = 0
        '
        'GridView6
        '
        Me.GridView6.Name = "GridView6"
        Me.GridView6.VertScrollTipFieldName = Nothing
        Me.GridView6.ViewOptions = CType((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridView1
        '
        Me.GridView1.BehaviorOptions = CType((((((((DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowFilter Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowZoomDetail) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.EnableMasterViewMode) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.SmartVertScrollBar) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.UseTabKey) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowSort) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AllowGroup) _
            Or DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags.AutoUpdateTotalSummary), DevExpress.XtraGrid.Views.Grid.BehaviorOptionsFlags)
        Me.GridView1.BorderStyle = DevExpress.XtraGrid.Views.Grid.ViewBorderStyle.Flat
        Me.GridView1.GroupPanelText = "I N G R E S O S             (GAS L.P.)"
        Me.GridView1.Name = "GridView1"
        Me.GridView1.ViewOptions = CType(((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowColumns) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.Label8)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel11.Location = New System.Drawing.Point(0, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(816, 24)
        Me.Panel11.TabIndex = 28
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(50, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Servicios"
        '
        'GridControl3
        '
        Me.GridControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridControl3.EditorsRepository = Me.PersistentRepository1
        Me.GridControl3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl3.Location = New System.Drawing.Point(0, 0)
        Me.GridControl3.MainView = Me.GridView11
        Me.GridControl3.Name = "GridControl3"
        Me.GridControl3.Size = New System.Drawing.Size(816, 64)
        Me.GridControl3.TabIndex = 29
        Me.GridControl3.Text = "GridControl1"
        '
        'GridView11
        '
        Me.GridView11.DefaultEdit = Me.RepositoryItemTextEdit6
        Me.GridView11.Name = "GridView11"
        '
        'GridColumn36
        '
        Me.GridColumn36.Caption = "PARCIAL  (2)"
        Me.GridColumn36.FilterInfo = ColumnFilterInfo147
        Me.GridColumn36.Name = "GridColumn36"
        Me.GridColumn36.VisibleIndex = 8
        '
        'GridColumn35
        '
        Me.GridColumn35.Caption = "E. Negativas"
        Me.GridColumn35.FilterInfo = ColumnFilterInfo148
        Me.GridColumn35.Name = "GridColumn35"
        Me.GridColumn35.VisibleIndex = 7
        '
        'GridColumn33
        '
        Me.GridColumn33.Caption = "Cobranzas"
        Me.GridColumn33.FilterInfo = ColumnFilterInfo149
        Me.GridColumn33.Name = "GridColumn33"
        Me.GridColumn33.VisibleIndex = 5
        '
        'GridColumn32
        '
        Me.GridColumn32.Caption = "PARCIAL  (1)"
        Me.GridColumn32.FilterInfo = ColumnFilterInfo150
        Me.GridColumn32.Name = "GridColumn32"
        Me.GridColumn32.VisibleIndex = 4
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Crédito"
        Me.GridColumn30.FieldName = "VentasCredito"
        Me.GridColumn30.FilterInfo = ColumnFilterInfo151
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.VisibleIndex = 2
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Contado"
        Me.GridColumn29.FieldName = "VentasContado"
        Me.GridColumn29.FilterInfo = ColumnFilterInfo152
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.VisibleIndex = 1
        '
        'GridColumn34
        '
        Me.GridColumn34.Caption = "N. Ingreso"
        Me.GridColumn34.FilterInfo = ColumnFilterInfo153
        Me.GridColumn34.Name = "GridColumn34"
        Me.GridColumn34.VisibleIndex = 6
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "T. Crédito"
        Me.GridColumn31.FilterInfo = ColumnFilterInfo154
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.VisibleIndex = 3
        '
        'GridColumn40
        '
        Me.GridColumn40.Caption = "GridColumn24"
        Me.GridColumn40.FilterInfo = ColumnFilterInfo155
        Me.GridColumn40.Name = "GridColumn40"
        Me.GridColumn40.VisibleIndex = 0
        '
        'GridColumn41
        '
        Me.GridColumn41.Caption = "GridColumn25"
        Me.GridColumn41.FilterInfo = ColumnFilterInfo156
        Me.GridColumn41.Name = "GridColumn41"
        Me.GridColumn41.VisibleIndex = 1
        '
        'GridColumn42
        '
        Me.GridColumn42.Caption = "GridColumn26"
        Me.GridColumn42.FilterInfo = ColumnFilterInfo157
        Me.GridColumn42.Name = "GridColumn42"
        Me.GridColumn42.VisibleIndex = 2
        '
        'GridColumn43
        '
        Me.GridColumn43.Caption = "GridColumn27"
        Me.GridColumn43.FilterInfo = ColumnFilterInfo158
        Me.GridColumn43.Name = "GridColumn43"
        Me.GridColumn43.VisibleIndex = 3
        '
        'GridColumn44
        '
        Me.GridColumn44.Caption = "GridColumn28"
        Me.GridColumn44.FilterInfo = ColumnFilterInfo159
        Me.GridColumn44.Name = "GridColumn44"
        Me.GridColumn44.VisibleIndex = 4
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Descripción"
        Me.GridColumn11.FieldName = "Descripcion"
        Me.GridColumn11.FilterInfo = ColumnFilterInfo160
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.VisibleIndex = 0
        '
        'GridView9
        '
        Me.GridView9.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn40, Me.GridColumn41, Me.GridColumn42, Me.GridColumn43, Me.GridColumn44})
        Me.GridView9.Name = "GridView9"
        Me.GridView9.ViewOptions = CType((((((DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.AutoWidth Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowHorzLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowIndicator) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowVertLines) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.ShowDetailButtons) _
            Or DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags.SingleFocusStyle), DevExpress.XtraGrid.Views.Grid.ViewOptionsFlags)
        '
        'GridColumn39
        '
        Me.GridColumn39.FilterInfo = ColumnFilterInfo161
        Me.GridColumn39.Name = "GridColumn39"
        '
        'GridColumn38
        '
        Me.GridColumn38.FilterInfo = ColumnFilterInfo162
        Me.GridColumn38.Name = "GridColumn38"
        '
        'GridColumn37
        '
        Me.GridColumn37.FilterInfo = ColumnFilterInfo163
        Me.GridColumn37.Name = "GridColumn37"
        '
        'Panel12
        '
        Me.Panel12.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel12.Location = New System.Drawing.Point(0, 0)
        Me.Panel12.Name = "Panel12"
        Me.Panel12.Size = New System.Drawing.Size(810, 24)
        Me.Panel12.TabIndex = 28
        '
        'GridControl4
        '
        Me.GridControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GridControl4.EditorsRepository = Me.PersistentRepository1
        Me.GridControl4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridControl4.Location = New System.Drawing.Point(0, 0)
        Me.GridControl4.MainView = Me.GridView12
        Me.GridControl4.Name = "GridControl4"
        Me.GridControl4.Size = New System.Drawing.Size(810, 64)
        Me.GridControl4.TabIndex = 29
        Me.GridControl4.Text = "GridControl1"
        '
        'GridView12
        '
        Me.GridView12.DefaultEdit = Me.RepositoryItemTextEdit7
        Me.GridView12.Name = "GridView12"
        '
        'GridColumn54
        '
        Me.GridColumn54.Caption = "GridColumn21"
        Me.GridColumn54.FilterInfo = ColumnFilterInfo164
        Me.GridColumn54.Name = "GridColumn54"
        Me.GridColumn54.VisibleIndex = 0
        '
        'GridColumn55
        '
        Me.GridColumn55.Caption = "GridColumn22"
        Me.GridColumn55.FilterInfo = ColumnFilterInfo165
        Me.GridColumn55.Name = "GridColumn55"
        Me.GridColumn55.VisibleIndex = 1
        '
        'GridColumn45
        '
        Me.GridColumn45.Caption = "Descripción"
        Me.GridColumn45.FieldName = "Descripcion"
        Me.GridColumn45.FilterInfo = ColumnFilterInfo166
        Me.GridColumn45.Name = "GridColumn45"
        Me.GridColumn45.VisibleIndex = 0
        '
        'GridColumn46
        '
        Me.GridColumn46.Caption = "Contado"
        Me.GridColumn46.FieldName = "VentasContado"
        Me.GridColumn46.FilterInfo = ColumnFilterInfo167
        Me.GridColumn46.Name = "GridColumn46"
        Me.GridColumn46.VisibleIndex = 1
        '
        'GridColumn47
        '
        Me.GridColumn47.Caption = "Crédito"
        Me.GridColumn47.FieldName = "VentasCredito"
        Me.GridColumn47.FilterInfo = ColumnFilterInfo168
        Me.GridColumn47.Name = "GridColumn47"
        Me.GridColumn47.VisibleIndex = 2
        '
        'GridColumn48
        '
        Me.GridColumn48.Caption = "T. Crédito"
        Me.GridColumn48.FilterInfo = ColumnFilterInfo169
        Me.GridColumn48.Name = "GridColumn48"
        Me.GridColumn48.VisibleIndex = 3
        '
        'GridColumn51
        '
        Me.GridColumn51.Caption = "N. Ingreso"
        Me.GridColumn51.FilterInfo = ColumnFilterInfo170
        Me.GridColumn51.Name = "GridColumn51"
        Me.GridColumn51.VisibleIndex = 6
        '
        'GridColumn50
        '
        Me.GridColumn50.Caption = "Cobranzas"
        Me.GridColumn50.FilterInfo = ColumnFilterInfo171
        Me.GridColumn50.Name = "GridColumn50"
        Me.GridColumn50.VisibleIndex = 5
        '
        'GridColumn53
        '
        Me.GridColumn53.Caption = "PARCIAL  (2)"
        Me.GridColumn53.FilterInfo = ColumnFilterInfo172
        Me.GridColumn53.Name = "GridColumn53"
        Me.GridColumn53.VisibleIndex = 8
        '
        'GridColumn52
        '
        Me.GridColumn52.FilterInfo = ColumnFilterInfo173
        Me.GridColumn52.Name = "GridColumn52"
        '
        'GridColumn49
        '
        Me.GridColumn49.FilterInfo = ColumnFilterInfo174
        Me.GridColumn49.Name = "GridColumn49"
        '
        'GridColumn57
        '
        Me.GridColumn57.FilterInfo = ColumnFilterInfo175
        Me.GridColumn57.Name = "GridColumn57"
        '
        'GridColumn56
        '
        Me.GridColumn56.FilterInfo = ColumnFilterInfo176
        Me.GridColumn56.Name = "GridColumn56"
        '
        'GridColumn59
        '
        Me.GridColumn59.FilterInfo = ColumnFilterInfo177
        Me.GridColumn59.Name = "GridColumn59"
        '
        'GridColumn58
        '
        Me.GridColumn58.FilterInfo = ColumnFilterInfo178
        Me.GridColumn58.Name = "GridColumn58"
        '
        'GridColumn60
        '
        Me.GridColumn60.FilterInfo = ColumnFilterInfo179
        Me.GridColumn60.Name = "GridColumn60"
        '
        'GridColumn61
        '
        Me.GridColumn61.FilterInfo = ColumnFilterInfo180
        Me.GridColumn61.Name = "GridColumn61"
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.SystemColors.Control
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.ForeColor = System.Drawing.Color.Crimson
        Me.lblCaja.Location = New System.Drawing.Point(888, 5)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(120, 23)
        Me.lblCaja.TabIndex = 42
        Me.lblCaja.Text = "Caja : 1"
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCajaCmb
        '
        Me.lblCajaCmb.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCajaCmb.Location = New System.Drawing.Point(788, 12)
        Me.lblCajaCmb.Name = "lblCajaCmb"
        Me.lblCajaCmb.Size = New System.Drawing.Size(40, 24)
        Me.lblCajaCmb.TabIndex = 43
        Me.lblCajaCmb.Text = "Caja:"
        '
        'cmbCaja
        '
        Me.cmbCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCaja.Location = New System.Drawing.Point(832, 8)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(80, 21)
        Me.cmbCaja.TabIndex = 4
        '
        'CorteCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(1175, 646)
        Me.Controls.Add(Me.cmbCaja)
        Me.Controls.Add(Me.lblCajaCmb)
        Me.Controls.Add(Me.lblCaja)
        Me.Controls.Add(Me.pnlGeneral)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tlbCorteCaja)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "CorteCaja"
        Me.Text = "Corte de Caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.RepositoryItemTextEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtFechaOperacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlGeneral.ResumeLayout(False)
        Me.pnlGastos.ResumeLayout(False)
        Me.pnlAplicaciones.ResumeLayout(False)
        Me.pnlVentaCredito.ResumeLayout(False)
        CType(Me.grdVentaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwVentaCredito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnAplicaciones.ResumeLayout(False)
        CType(Me.grdAplicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwAplicaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlFichasDeposito.ResumeLayout(False)
        CType(Me.grdFichaDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.vwFichasDeposito, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlAplicacion.ResumeLayout(False)
        Me.pnlServicios.ResumeLayout(False)
        Me.pnlServicios.PerformLayout()
        CType(Me.grdServiciosTecnicos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView10, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlIngresos.ResumeLayout(False)
        CType(Me.grdIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.GridControl3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridControl4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView12, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub CorteCaja_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lblCaja.Text = "Caja : " & VerificaUsuario().ToString
        Me.lblFolioCorte.Visible = False
        Me.pnlGeneral.Visible = False
        dtFechaOperacion.DateTime = Now

        txtEmpresa.Text = dmModulo._NombreEmpresaContable
    End Sub

    Public Sub Entrar()

        'Se obtiene el Usuario Administrador
        strUsuario = ObtenParametroSistema(3, _Sucursal, _Corporativo, "UsuarioAdministrador")

        'Se obtiene el Usuario Consulta
        strUsuarioConsulta = ObtenParametroSistema(3, _Sucursal, _Corporativo, "UsuarioConsulta")

        'Si el usuario logueado es el adminitrador se activan los botones:
        'btnPorAutorizar,btnModificarStatus y la eleccion de las cajas
        'Para el usuario de consulta solo es la eleccion de las cajas

        If (Trim(strUsuario) <> Trim(dmModulo._Usuario)) And (Trim(strUsuarioConsulta) <> Trim(dmModulo._Usuario)) Then
            'de lo contrario se ocultan
            lblCajaCmb.Visible = False
            cmbCaja.Visible = False
            btnPorAutorizar.Visible = False
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
                btnPorAutorizar.Visible = False
                btnModificarStatus.Visible = False
            End If
        End If

        With cmdCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spSSSelectTipoCorte"
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtTipoCorte)
        End With

        cmbTipoCorte.DataSource = dtTipoCorte
        cmbTipoCorte.ValueMember = "TipoCorte"
        cmbTipoCorte.DisplayMember = "Descripcion"

        VGN_TipoCorte = CType(cmbTipoCorte.SelectedValue, Integer)
        VGS_FOperacion = dtFechaOperacion.DateTime.ToShortDateString

        Me.ShowDialog()
    End Sub

    Private Sub CargaCorte()
        Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Ingresos()
        CargaFichas()
        CargaGastos()
        VentaCredito()
        CalculaMontos()

        btnAplicaciones.Enabled = True
        btnImprimir.Enabled = True
        btnPorAutorizar.Enabled = True
        btnActualizar.Enabled = True
        Me.btnAgrergar.Enabled = False

        If blnAdministrador Then
            Me.dtFechaOperacion.Enabled = True
            Me.cmbTipoCorte.Enabled = True
        Else
            Me.dtFechaOperacion.Enabled = False
            Me.cmbTipoCorte.Enabled = False
        End If

        lblFolioCorte.Text = "Folio Corte : " + CType(dmModulo.VGN_Consecutivo, String)
        lblFolioCorte.Visible = True
        Me.pnlGeneral.Visible = True

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
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = Me.cmbTipoCorte.SelectedValue
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
            cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = Me.cmbTipoCorte.SelectedValue

            If Alta Then
                cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Direction = ParameterDirection.Output
            Else
                cmdCommand.Parameters.Add("@Alta", SqlDbType.Bit).Value = 0
                cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                cmdCommand.Parameters.Add("@TotalIngresos", SqlDbType.Money).Value = Total
                cmdCommand.Parameters.Add("@TotalAplicaciones", SqlDbType.Money).Value = TotalAplicaciones
                cmdCommand.Parameters.Add("@ImporteContado", SqlDbType.Money).Value = CType(grdcVentaContado.SummaryItem.SummaryValue, Decimal)
                cmdCommand.Parameters.Add("@ImporteCredito", SqlDbType.Money).Value = CType(grdcVentaCredito.SummaryItem.SummaryValue, Decimal)
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
        cmdCommand.CommandText = "spSSIngresosCorteCaja"
        cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
        cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dtFechaOperacion.DateTime.Date, String)

        If (CType(cmbTipoCorte.SelectedValue, Integer) = 1) Then
            cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Bit).Value = VGN_TipoCorte
        End If

        Try
            cmdCommand.ExecuteNonQuery()
            daSelect.SelectCommand = cmdCommand

            If dtIngresos.Rows.Count > 0 Then
                dtIngresos.Clear()
            End If

            If dtServiciosTecnicos.Rows.Count > 0 Then
                dtServiciosTecnicos.Clear()
            End If

            'Try
            '    dtIngresos.Clear()
            '    dtServiciosTecnicos.Clear()
            'Catch
            'End Try

            daSelect.Fill(dtIngresos)
            dtServiciosTecnicos = dtIngresos.Copy()

            dtIngresos.DefaultView.RowFilter = "Grupo = 0"
            dtServiciosTecnicos.DefaultView.RowFilter = "Grupo = 1"

            Total = CType(dtIngresos.Rows(0).Item("Total"), Decimal)
            TotalSAF = CType(dtIngresos.Rows(0).Item("MontoSaldoAplicado"), Decimal)
            lblIngresos.Text = "Total Ingresos :     " + Total.ToString("C")
            lblServiciosTecnicos.Text = "SALDO A FAVOR GENERADO = " & CType(dtIngresos.Rows(0).Item("MontoSaldoGenerado"), Decimal).ToString("c")
            lblIngresosSAF.Text = "INGRESOS (SALDO A FAVOR) = " + TotalSAF.ToString("C")
            grdIngresos.DataSource = dtIngresos
            grdServiciosTecnicos.DataSource = dtServiciosTecnicos
            Me.pnlGeneral.Visible = True
            Me.pnlAplicacion.Visible = False
            pnlIngresos.Visible = True
            pnlServicios.Visible = True
            pnlGastos.Visible = False

        Catch er As Exception
            MsgBox(er.Message)
        End Try

        '''''''''''''''''''''''''
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSSaldosChequesPosfechadosVencidosAnteriores"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)

            If dmModulo.VGN_TipoCorte = 2 Then
                cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = dmModulo.VGN_TipoCorte
            End If

            rdrSelect = cmdCommand.ExecuteReader
            rdrSelect.Read()
            lblPosFechAnt.Text = "CHEQUES PV ANTERIORES = " & CType(rdrSelect("Total"), Decimal).ToString("c")
            rdrSelect.Close()
        Catch e As Exception
            MsgBox(e.Message)
        End Try
        '''''''''''''''''''''''''

    End Sub

    Private Sub VentaCredito()
        ''Dim i As Int16

        cmdCommand.Parameters.Clear()
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSCorteCajaTotales"
        cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = dtFechaOperacion.DateTime.ToShortDateString
        cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
        If VGN_TipoCorte = 1 Then
            cmdCommand.Parameters.Add("@DiaAnterior", SqlDbType.Bit).Value = VGN_TipoCorte
        End If
        daSelect.SelectCommand = cmdCommand

        Try
            If dtVentaCredito.Rows.Count > 0 Then
                dtVentaCredito.Clear()
            End If

            daSelect.Fill(dtVentaCredito)
            grdVentaCredito.DataSource = dtVentaCredito

        Catch er As Exception
            MsgBox(er.Message)
        End Try

    End Sub

    Private Sub Bloquea()
        btnImprimir.Enabled = True
        btnSalir.Enabled = True
        btnAgrergar.Enabled = False
        btnAplicaciones.Enabled = False
        btnGastos.Enabled = False
        btnGuardar.Enabled = False
        btnPorAutorizar.Enabled = False
        btnModificarStatus.Enabled = True
    End Sub

    Private Sub tlbCatTipTra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tlbCorteCaja.ButtonClick
        Select Case RTrim(e.Button.Text)
            Case "Agregar"
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
                    If MessageBox.Show("YA EXISTE el corte de caja para el día " & dtFechaOperacion.DateTime.ToShortDateString & " del tipo de corte """ & Trim(cmbTipoCorte.Text) & """ con el Folio = " & Trim(CType(VGN_FolioCorte, String)) & Chr(13) & " ¿Desea cargarlo ?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        dmModulo.VGS_FOperacion = CType(dtFechaOperacion.DateTime.ToShortDateString, String)
                        dmModulo.VGN_Consecutivo = VGN_FolioCorte
                        lblFolioCorte.Text = "Folio Corte : " + CType(dmModulo.VGN_Consecutivo, String)
                        CargaCorte()
                    End If
                End If
                Me.lblCaja.Text = "Caja : " & VerificaUsuario().ToString
            Case "Fichas"
                Dim frmMovimientoCajaDesglozados As New MovimientosCajaDesglozados()
                frmMovimientoCajaDesglozados.Entrar(CType(cmbTipoCorte.SelectedValue, Integer), cmbTipoCorte.Text)
                frmMovimientoCajaDesglozados.Dispose()
                CargaFichas()
                CalculaMontos()
            Case "Gastos"
                Dim frmGastos As New Gastos(VerificaUsuario())
                frmGastos.Entrar()
                frmGastos.Dispose()
                CargaGastos()
                VentaCredito()
                CalculaMontos()
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

            Case "Por Autorizar"
                Dim frmPorAutorizar As New PorAutorizar(VerificaUsuario())
                frmPorAutorizar.Entrar()
            Case "Modificar Status"
                VerificarStatus()
                If Not Trim(strStatus) = "CERRADO" Then
                    MessageBox.Show("El corte ya esta CAPTURADO, verifique.", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Exit Sub
                End If

                If MessageBox.Show("¿Desea cambiar el status del corte de " + Trim(strStatus) + " a CAPTURADO?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                    CambiarStatus("CAPTURADO")
                    btnAplicaciones.Enabled = True
                    btnGastos.Enabled = True
                    btnGuardar.Enabled = True
                    btnPorAutorizar.Enabled = True
                    btnModificarStatus.Enabled = False
                End If
            Case "Imprimir"
                Dim frmImprimeCorteCaja As ViewReport = New ViewReport()
                frmImprimeCorteCaja.CorteCaja(dmModulo._NombreEmpresaContable, dtFechaOperacion.DateTime.ToShortDateString, VerificaUsuario(), dmModulo.VGN_Consecutivo, dmModulo.VGN_TipoCorte)
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
                    If MessageBox.Show("YA EXISTE el corte de caja para el día " & dtFechaOperacion.DateTime.ToShortDateString & " del tipo de corte """ & Trim(cmbTipoCorte.Text) & """ con el Folio = " & Trim(CType(VGN_FolioCorte, String)) & Chr(13) & " ¿Desea cargarlo ?", "Caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
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
        Dim VLD_TotalConceptosGastos As Decimal
        Dim VLD_VentaCredito As Decimal
        VLD_Total = Total
        VLD_TotalFichas = CType(Me.grdcTotal.SummaryItem.SummaryValue, Decimal)
        VLD_TotalConceptosGastos = CType(Me.grdcTotalConceptoGastos.SummaryItem.SummaryValue, Decimal)
        VLD_VentaCredito = CType(Me.grdcTotalVentaCredito.SummaryItem.SummaryValue, Decimal)

        TotalAplicaciones = VLD_TotalFichas + VLD_TotalConceptosGastos + VLD_VentaCredito
        VGM_Diferencia = VLD_Total - TotalAplicaciones

        lblAplicaciones.Text = "Total Aplicaciones:     " + TotalAplicaciones.ToString("C")
        lblDiferencia.Text = "Diferencia : " + VGM_Diferencia.ToString("C2")
    End Sub

    Private Sub CargaFichas()
        If dtFichasDeposito.Rows.Count > 0 Then
            dtFichasDeposito.Clear()
        End If

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSFichasDepositoCaja"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtFichasDeposito)
        Catch e As Exception
            MessageBox.Show("Se genero el siguiente error: " + e.Message, "Cargar Fichas", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        grdFichaDeposito.DataSource = dtFichasDeposito

        pnlGastos.Visible = True
        pnlAplicacion.Visible = True
        btnGastos.Enabled = True
    End Sub

    Private Sub CargaGastos()
        If dtGastos.Rows.Count > 0 Then
            dtGastos.Clear()
        End If

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSCorteCajaAplicaciones"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = VerificaUsuario()
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            cmdCommand.Parameters.Add("@Accion", SqlDbType.Int).Value = 0
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtGastos)
        Catch e As Exception
            MessageBox.Show("Se genero el siguiente error: " + e.Message, "Cargar Gastos", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        grdAplicaciones.DataSource = dtGastos

        pnlConceptosGasto.Visible = True
        pnlVentaCredito.Visible = True
        btnGuardar.Enabled = True
    End Sub

    Private Sub Agregar()

        Me.lblCaja.Visible = True
        Me.lblFolioCorte.Visible = True
        Me.cboEmpresa.Enabled = False
        Me.cmbTipoCorte.Enabled = False
        Me.btnAgrergar.Enabled = False
        Me.btnGastos.Enabled = False
        Me.btnConsultar.Enabled = False
        Me.btnGuardar.Enabled = False
        Me.btnImprimir.Enabled = False
        Me.btnAplicaciones.Enabled = True
        Me.btnSalir.Enabled = False
        Me.dtFechaOperacion.Enabled = False
        InsertaCorte(True)

    End Sub

    Private Sub dtFechaOperacion_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtFechaOperacion.ValueChanged
        VGS_FOperacion = dtFechaOperacion.DateTime.ToShortDateString
    End Sub

    Private Sub cmbCaja_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCaja.SelectionChangeCommitted
        dmModulo.VGN_Caja = CType(cmbCaja.SelectedValue, Integer)
    End Sub

    Private Sub cmbTipoCorte_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoCorte.SelectedValueChanged
        Try
            VGN_TipoCorte = CType(cmbTipoCorte.SelectedValue, Integer)
        Catch
            VGN_TipoCorte = 0
        End Try
    End Sub

End Class

