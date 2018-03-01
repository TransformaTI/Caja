Option Strict On

Imports System.Collections.Generic
Imports System.Data
Imports System.Data.SqlClient

Public Class frmFichaDepositoConfigurable
    Inherits System.Windows.Forms.Form
    'Variables para comandos sql
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private daSelect As New SqlDataAdapter()
    Private dtSelect As New DataTable()

    'Guarda los datos originales de la consulta para poder ser utilizados posteriormente
    Private dtConsulta As DataTable
    private  dtConsultaAgrupado AS DataTable
    Private totalizadorGeneral as Decimal
    Private operacion as Operaciones

    'Variables
    Private VGN_TipoFicha As Integer
    Private VGS_Concepto As String
    Private desgloce as Boolean
    private monto as decimal 

    Public VGN_Folio As Integer
    Public blnAgregarAlCorte As Boolean
    Public EmpreContableOriginal As Boolean = False
    Public  dtMovimientoCaja AS DataTable


    #Region "Operaciones"
    Private Enum Operaciones
        Cobranza = 1
        TVP = 2
        Cheque = 3
    End Enum
#End Region


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
    Friend WithEvents chkSeleccionCheque As CheckBox
    Friend WithEvents gbInfoFicha As GroupBox
    Friend WithEvents gbDetalle As GroupBox
    Friend WithEvents chkSeleccion As CheckBox
    Friend WithEvents dgvDetalleDeposito As DataGridView
    Private components As System.ComponentModel.IContainer
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cmbCuenta As System.Windows.Forms.ComboBox
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents chkAgregar As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtFechaFicha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtFOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtTipoFicha As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTipoMovimiento As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMontoPendiente As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFichaDepositoConfigurable))
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCuenta = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.chkAgregar = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtFechaFicha = New System.Windows.Forms.DateTimePicker()
        Me.dtFOperacion = New System.Windows.Forms.DateTimePicker()
        Me.txtTipoFicha = New DevExpress.XtraEditors.TextEdit()
        Me.txtTipoMovimiento = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtMontoPendiente = New DevExpress.XtraEditors.TextEdit()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.gbInfoFicha = New System.Windows.Forms.GroupBox()
        Me.gbDetalle = New System.Windows.Forms.GroupBox()
        Me.chkSeleccion = New System.Windows.Forms.CheckBox()
        Me.dgvDetalleDeposito = New System.Windows.Forms.DataGridView()
        Me.chkSeleccionCheque = New System.Windows.Forms.CheckBox()
        CType(Me.chkAgregar,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtTipoFicha,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtTipoMovimiento,System.ComponentModel.ISupportInitialize).BeginInit
        CType(Me.txtMontoPendiente,System.ComponentModel.ISupportInitialize).BeginInit
        Me.gbInfoFicha.SuspendLayout
        Me.gbDetalle.SuspendLayout
        CType(Me.dgvDetalleDeposito,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(44, 110)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha Ficha :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(52, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tipo Ficha :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = true
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label9.Location = New System.Drawing.Point(33, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 14)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Cuenta Banco :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCuenta
        '
        Me.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuenta.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbCuenta.Location = New System.Drawing.Point(127, 77)
        Me.cmbCuenta.Name = "cmbCuenta"
        Me.cmbCuenta.Size = New System.Drawing.Size(320, 22)
        Me.cmbCuenta.TabIndex = 4
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"),System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(804, 12)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 32)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"),System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(804, 49)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(96, 32)
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PersistentRepository1
        '
        Me.PersistentRepository1.Items.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.chkAgregar})
        '
        'chkAgregar
        '
        Me.chkAgregar.Name = "chkAgregar"
        Me.chkAgregar.Properties.AllowFocused = false
        Me.chkAgregar.Properties.AutoHeight = false
        Me.chkAgregar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.chkAgregar.Properties.CheckAlign = DevExpress.XtraEditors.Controls.CheckAlignStyles.NoText
        '
        'Label8
        '
        Me.Label8.AutoSize = true
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 14)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Fecha Operación :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtFechaFicha
        '
        Me.dtFechaFicha.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtFechaFicha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFechaFicha.Location = New System.Drawing.Point(127, 106)
        Me.dtFechaFicha.Name = "dtFechaFicha"
        Me.dtFechaFicha.Size = New System.Drawing.Size(128, 23)
        Me.dtFechaFicha.TabIndex = 34
        Me.dtFechaFicha.Value = New Date(2005, 1, 28, 0, 0, 0, 0)
        '
        'dtFOperacion
        '
        Me.dtFOperacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.dtFOperacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtFOperacion.Location = New System.Drawing.Point(127, 136)
        Me.dtFOperacion.Name = "dtFOperacion"
        Me.dtFOperacion.Size = New System.Drawing.Size(128, 23)
        Me.dtFOperacion.TabIndex = 35
        Me.dtFOperacion.Value = New Date(2005, 1, 28, 0, 0, 0, 0)
        '
        'txtTipoFicha
        '
        Me.txtTipoFicha.Enabled = false
        Me.txtTipoFicha.Location = New System.Drawing.Point(127, 48)
        Me.txtTipoFicha.Name = "txtTipoFicha"
        Me.txtTipoFicha.Properties.DisabledForeColor = System.Drawing.Color.Black
        Me.txtTipoFicha.Properties.Enabled = false
        Me.txtTipoFicha.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte)), "", CType((((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor)  _
                Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis)  _
                Or DevExpress.Utils.StyleOptions.UseDrawFocusRect)  _
                Or DevExpress.Utils.StyleOptions.UseFont)  _
                Or DevExpress.Utils.StyleOptions.UseForeColor)  _
                Or DevExpress.Utils.StyleOptions.UseHorzAlignment)  _
                Or DevExpress.Utils.StyleOptions.UseImage)  _
                Or DevExpress.Utils.StyleOptions.UseWordWrap)  _
                Or DevExpress.Utils.StyleOptions.UseVertAlignment),DevExpress.Utils.StyleOptions), true, false, false, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Utils.VertAlignment.[Default], Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtTipoFicha.Size = New System.Drawing.Size(320, 23)
        Me.txtTipoFicha.TabIndex = 36
        '
        'txtTipoMovimiento
        '
        Me.txtTipoMovimiento.Enabled = false
        Me.txtTipoMovimiento.Location = New System.Drawing.Point(126, 19)
        Me.txtTipoMovimiento.Name = "txtTipoMovimiento"
        Me.txtTipoMovimiento.Properties.DisabledForeColor = System.Drawing.Color.Black
        Me.txtTipoMovimiento.Properties.Enabled = false
        Me.txtTipoMovimiento.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte)), "", CType((((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor)  _
                Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis)  _
                Or DevExpress.Utils.StyleOptions.UseDrawFocusRect)  _
                Or DevExpress.Utils.StyleOptions.UseFont)  _
                Or DevExpress.Utils.StyleOptions.UseForeColor)  _
                Or DevExpress.Utils.StyleOptions.UseHorzAlignment)  _
                Or DevExpress.Utils.StyleOptions.UseImage)  _
                Or DevExpress.Utils.StyleOptions.UseWordWrap)  _
                Or DevExpress.Utils.StyleOptions.UseVertAlignment),DevExpress.Utils.StyleOptions), true, true, false, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Utils.VertAlignment.[Default], Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtTipoMovimiento.Size = New System.Drawing.Size(320, 23)
        Me.txtTipoMovimiento.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label7.Location = New System.Drawing.Point(20, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 14)
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Tipo movimiento:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMontoPendiente
        '
        Me.txtMontoPendiente.Enabled = false
        Me.txtMontoPendiente.Location = New System.Drawing.Point(127, 166)
        Me.txtMontoPendiente.Name = "txtMontoPendiente"
        Me.txtMontoPendiente.Properties.DisabledBackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtMontoPendiente.Properties.DisabledForeColor = System.Drawing.Color.Brown
        Me.txtMontoPendiente.Properties.Enabled = false
        Me.txtMontoPendiente.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte)), "", CType((((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor)  _
                Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis)  _
                Or DevExpress.Utils.StyleOptions.UseDrawFocusRect)  _
                Or DevExpress.Utils.StyleOptions.UseFont)  _
                Or DevExpress.Utils.StyleOptions.UseForeColor)  _
                Or DevExpress.Utils.StyleOptions.UseHorzAlignment)  _
                Or DevExpress.Utils.StyleOptions.UseImage)  _
                Or DevExpress.Utils.StyleOptions.UseWordWrap)  _
                Or DevExpress.Utils.StyleOptions.UseVertAlignment),DevExpress.Utils.StyleOptions), true, false, false, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Utils.VertAlignment.[Default], Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtMontoPendiente.Size = New System.Drawing.Size(207, 25)
        Me.txtMontoPendiente.TabIndex = 40
        Me.txtMontoPendiente.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = true
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(8, 171)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(119, 14)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Efectivo pendiente :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMonto
        '
        Me.txtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMonto.Enabled = false
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtMonto.Location = New System.Drawing.Point(127, 197)
        Me.txtMonto.MaxLength = 20
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(207, 23)
        Me.txtMonto.TabIndex = 41
        Me.txtMonto.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(68, 201)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 14)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Monto :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = true
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblCaja.ForeColor = System.Drawing.Color.Blue
        Me.lblCaja.Location = New System.Drawing.Point(23, 12)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(68, 18)
        Me.lblCaja.TabIndex = 44
        Me.lblCaja.Text = "Caja :  5"
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'gbInfoFicha
        '
        Me.gbInfoFicha.Controls.Add(Me.Label4)
        Me.gbInfoFicha.Controls.Add(Me.Label2)
        Me.gbInfoFicha.Controls.Add(Me.txtMonto)
        Me.gbInfoFicha.Controls.Add(Me.cmbCuenta)
        Me.gbInfoFicha.Controls.Add(Me.txtMontoPendiente)
        Me.gbInfoFicha.Controls.Add(Me.Label12)
        Me.gbInfoFicha.Controls.Add(Me.Label3)
        Me.gbInfoFicha.Controls.Add(Me.txtTipoMovimiento)
        Me.gbInfoFicha.Controls.Add(Me.Label7)
        Me.gbInfoFicha.Controls.Add(Me.Label9)
        Me.gbInfoFicha.Controls.Add(Me.txtTipoFicha)
        Me.gbInfoFicha.Controls.Add(Me.Label8)
        Me.gbInfoFicha.Controls.Add(Me.dtFOperacion)
        Me.gbInfoFicha.Controls.Add(Me.dtFechaFicha)
        Me.gbInfoFicha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.gbInfoFicha.Location = New System.Drawing.Point(327, 49)
        Me.gbInfoFicha.Name = "gbInfoFicha"
        Me.gbInfoFicha.Size = New System.Drawing.Size(462, 304)
        Me.gbInfoFicha.TabIndex = 45
        Me.gbInfoFicha.TabStop = false
        Me.gbInfoFicha.Text = "Información de la ficha"
        '
        'gbDetalle
        '
        Me.gbDetalle.Controls.Add(Me.chkSeleccion)
        Me.gbDetalle.Controls.Add(Me.dgvDetalleDeposito)
        Me.gbDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.gbDetalle.Location = New System.Drawing.Point(26, 49)
        Me.gbDetalle.Name = "gbDetalle"
        Me.gbDetalle.Size = New System.Drawing.Size(295, 304)
        Me.gbDetalle.TabIndex = 46
        Me.gbDetalle.TabStop = false
        Me.gbDetalle.Text = "DetalleDeposito"
        '
        'chkSeleccion
        '
        Me.chkSeleccion.AutoSize = true
        Me.chkSeleccion.Location = New System.Drawing.Point(64, 23)
        Me.chkSeleccion.Name = "chkSeleccion"
        Me.chkSeleccion.Size = New System.Drawing.Size(15, 14)
        Me.chkSeleccion.TabIndex = 48
        Me.chkSeleccion.UseVisualStyleBackColor = true
        '
        'dgvDetalleDeposito
        '
        Me.dgvDetalleDeposito.AllowUserToAddRows = false
        Me.dgvDetalleDeposito.AllowUserToDeleteRows = false
        Me.dgvDetalleDeposito.AllowUserToResizeColumns = false
        Me.dgvDetalleDeposito.AllowUserToResizeRows = false
        Me.dgvDetalleDeposito.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.dgvDetalleDeposito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.dgvDetalleDeposito.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalleDeposito.Location = New System.Drawing.Point(6, 18)
        Me.dgvDetalleDeposito.Name = "dgvDetalleDeposito"
        Me.dgvDetalleDeposito.ReadOnly = true
        Me.dgvDetalleDeposito.Size = New System.Drawing.Size(283, 274)
        Me.dgvDetalleDeposito.TabIndex = 49
        Me.dgvDetalleDeposito.TabStop = false
        '
        'chkSeleccionCheque
        '
        Me.chkSeleccionCheque.AutoSize = true
        Me.chkSeleccionCheque.Font = New System.Drawing.Font("Tahoma", 9!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.chkSeleccionCheque.Location = New System.Drawing.Point(692, 20)
        Me.chkSeleccionCheque.Name = "chkSeleccionCheque"
        Me.chkSeleccionCheque.Size = New System.Drawing.Size(97, 18)
        Me.chkSeleccionCheque.TabIndex = 47
        Me.chkSeleccionCheque.Text = "Por Cheque"
        Me.chkSeleccionCheque.UseVisualStyleBackColor = true
        Me.chkSeleccionCheque.Visible = false
        '
        'frmFichaDepositoConfigurable
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(923, 364)
        Me.Controls.Add(Me.chkSeleccionCheque)
        Me.Controls.Add(Me.gbDetalle)
        Me.Controls.Add(Me.gbInfoFicha)
        Me.Controls.Add(Me.lblCaja)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"),System.Drawing.Icon)
        Me.MaximizeBox = false
        Me.MinimizeBox = false
        Me.Name = "frmFichaDepositoConfigurable"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Titulo"
        CType(Me.chkAgregar,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTipoFicha,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtTipoMovimiento,System.ComponentModel.ISupportInitialize).EndInit
        CType(Me.txtMontoPendiente,System.ComponentModel.ISupportInitialize).EndInit
        Me.gbInfoFicha.ResumeLayout(false)
        Me.gbInfoFicha.PerformLayout
        Me.gbDetalle.ResumeLayout(false)
        Me.gbDetalle.PerformLayout
        CType(Me.dgvDetalleDeposito,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub

#End Region

    Public Sub Entrar(ByVal _tipoFicha As Integer, ByVal _tipoFichaDescripcion As String, _ 
                      ByVal _concepto As String,  ByVal _fFicha As DateTime, ByVal _desgloce As Boolean, _ 
                      byval _monto as decimal, ByVal _configuracion As Short,
                      Optional ByVal _tipoMovimientoCaja As Integer=0, Optional ByVal _tipoCobro As Integer=0 )
        Try
        
            'Folio de la Ficha
        lblCaja.Text = "Caja :  " + CType(dmModulo.VGN_Caja, String)

        'Carga de elementos iniciales
        txtTipoFicha.Text = _tipoFichaDescripcion
        txtTipoMovimiento.Text = _concepto
        VGS_Concepto = _tipoFichaDescripcion
        dtFechaFicha.Value = _fFicha
        dtFOperacion.Value = CType(dmModulo.VGS_FOperacion, DateTime)
        VGN_TipoFicha = _tipoFicha

            monto = _monto
            chkSeleccionCheque.Checked = False

            'Titulos de las formas
            If (_tipoFicha=7)Then
                Me.Text="Fichas de depósito de EFECTIVO COBRANZA"
                gbDetalle.Text="Movimientos de cobranza"
                operacion=Operaciones.Cobranza
       Else if (_tipoCobro=6)
                Me.Text="Fichas de depósito de TPV"
                gbDetalle.Text="Movimientos liquidados"
                operacion = Operaciones.TVP
                If _tipoFicha > 0 Then
                    chkSeleccionCheque.Visible = True
                    chkSeleccionCheque.Checked = _LiquidacionPorFicha
                    chkSeleccionCheque.Text = "Por Clave"
                End If

       Else if (_tipoCobro=3)
                Me.Text="Fichas de depósito de CHEQUES"
                gbDetalle.Text = "Movimientos liquidados"
                operacion = Operaciones.Cheque
                If _tipoFicha > 0 Then
                    chkSeleccionCheque.Visible = True
                    chkSeleccionCheque.Checked = _ChequePorFicha
                    chkSeleccionCheque.Text = "Por Cheque"
                End If

       End if 

        'Carga combo cuenta
        ConsultarCuenta()

        'Consultar la informacion
        ConsultarDetalleDeposito(_configuracion,_tipoMovimientoCaja,_tipoFichaDescripcion)

        'Cargar 
        CargarDatosConculta()

        desgloce=_desgloce
            If (_desgloce = False) Then
                chkSeleccion.Checked = True
                chkSeleccion.Enabled = False
                SeleccionarTodos()
            End If

            Me.ShowDialog()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    'Metodos de Base de Datos
    Private Sub InsertaFicha()
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSInsertaFicha"
                .Parameters.Clear()
                .Parameters.Add("@Total", SqlDbType.Money).Value = CType(txtMonto.Text, Decimal)
                .Parameters.Add("@FFicha", SqlDbType.Char).Value = CType(dtFechaFicha.Value.ToShortDateString, String)
                .Parameters.Add("@Descripcion", SqlDbType.Char).Value = CType(VGS_Concepto, String)
                .Parameters.Add("@Cuenta", SqlDbType.Char).Value = CType(cmbCuenta.SelectedValue, String)
                .Parameters.Add("@Folio", SqlDbType.Int).Direction = ParameterDirection.Output
                .ExecuteNonQuery()
                VGN_Folio = CType(.Parameters("@Folio").Value, Integer)

                If (VGN_TipoFicha <> 0) Then
                    dmModulo.MontoPendienteTipoFicha(VGN_TipoFicha, False, CType(txtMonto.Text, Decimal), CType(txtMontoPendiente.Text, Decimal))
                End If

                Me.blnAgregarAlCorte = True
            End With
        Catch ex As Exception
            Throw ex
        End Try

    End Sub


    Private Function InsertaFicha(Byval monto as Decimal) As Integer
        Dim Folio As Integer
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSInsertaFicha"
                .Parameters.Clear()
                .Parameters.Add("@Total", SqlDbType.Money).Value = monto
                .Parameters.Add("@FFicha", SqlDbType.Char).Value = CType(dtFechaFicha.Value.ToShortDateString, String)
                .Parameters.Add("@Descripcion", SqlDbType.Char).Value = CType(VGS_Concepto, String)
                .Parameters.Add("@Cuenta", SqlDbType.Char).Value = CType(cmbCuenta.SelectedValue, String)
                .Parameters.Add("@Folio", SqlDbType.Int).Direction = ParameterDirection.Output
                .ExecuteNonQuery()

                Folio=CType(.Parameters("@Folio").Value, Integer)

                If (VGN_TipoFicha <> 0) Then
                    dmModulo.MontoPendienteTipoFicha(VGN_TipoFicha, False, monto, CType(txtMontoPendiente.Text, Decimal))
                End If
                Me.blnAgregarAlCorte = True
            End With
        Catch ex As Exception
            Throw ex
        End Try

        return Folio

    End Function


    Private Sub ConsultarCuenta()
        Try
            With cmdCommand
            .CommandType = CommandType.StoredProcedure
            If (EmpreContableOriginal) Then
                .CommandText = "spSSCuentaBancoGral"
            Else
                .CommandText = "spSSCuentaBanco"
            End If

            .Parameters.Clear()
            .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtSelect)
        End With

        cmbCuenta.DataSource = dtSelect
        cmbCuenta.ValueMember = "CuentaBanco"
        cmbCuenta.DisplayMember = "Descripcion"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private sub ConsultarDetalleDeposito(ByVal configuracion As Short, ByVal tipoMovimientoCaja As Integer, ByVal descripcion As  String)
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSConsultaMovimientoCaja"
                .Parameters.Clear()
                .Parameters.Add("@Configuracion", SqlDbType.SmallInt).Value = configuracion
                .Parameters.Add("@Caja", SqlDbType.SmallInt).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.DateTime).Value = CType(dmModulo.VGS_FOperacion, DateTime)
                .Parameters.Add("@TipoCorte", SqlDbType.Int).Value = dmModulo.VGN_TipoCorte
                .Parameters.Add("@TipoMovimientoCa", SqlDbType.Int).Value = tipoMovimientoCaja'Esta no es de tipo obligatoria en esta configuracion
                .Parameters.Add("@Descripcion", SqlDbType.VarChar).Value = descripcion'Esta no es de tipo obligatoria en esta configuracion
                .CommandType = CommandType.StoredProcedure
                daSelect = New SqlDataAdapter(cmdCommand)
                dtConsulta = New DataTable()
                daSelect.Fill(dtConsulta)
            End With
        Catch ex As Exception
            Throw ex
        End Try
    End sub



    'Eventos de las formas
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Try
            VGN_Folio = 0
        Me.blnAgregarAlCorte = False
        Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Cursor = Cursors.WaitCursor
        Try

            If (CType(txtMonto.Text, Decimal) > 0) Then
                If chkSeleccionCheque.Checked = False Then
                    CargarDatosGuardar()
                    InsertaFicha()
                    Close()
                Else
                    If operacion = Operaciones.Cheque Then
                        CargarDatosGuardarSeleccionCheque()
                        GuardarDatosPorDetalle()
                    Else
                        CargarDatosGuardarSelecionTPV()
                        GuardarDatosPorDetalleTPV()
                    End If

                    Close()
                End If

                'If ((operacion <> Operaciones.Cheque) Or (operacion = Operaciones.Cheque And chkSeleccionCheque.Checked = False)) Then
                '    CargarDatosGuardar()
                '    InsertaFicha()
                '    Close()
                'Else
                '    CargarDatosGuardarSeleccionCheque()
                '    GuardarDatosPorDetalle()
                '    Close()
                'End If
            Else
                MessageBox.Show("Debe de seleccionar al menos un registro, NO SE PUEDE REALIZAR LA OPERACIÓN. Verifique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
         Finally
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub chkSelecciondgvSinAsignacion_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccion.CheckedChanged
        Try
            
           If(chkSeleccion.Focused And dgvDetalleDeposito.RowCount > 0 )Then
            SeleccionarTodos()
                ElseIf (chkSeleccion.Focused And dgvDetalleDeposito.RowCount = 0 )Then
            chkSeleccion.Checked = False
           End If
          
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvDetalleDeposito_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalleDeposito.CellContentClick
        Try
            Dim senderGrid  AS DataGridView= DirectCast(sender, DataGridView)
        If (TypeOf senderGrid.Columns(e.ColumnIndex) Is DataGridViewCheckBoxColumn AndAlso
           e.RowIndex >= 0) Then
                If(desgloce)
                    ModificarSeleccion(e.RowIndex)
                End If
        End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Eventos asociados al grid
    private sub GuardarDatosPorDetalle()

        dtMovimientoCaja.Columns.Add("FolioGenerado", GetType(Integer))

        For Each row As DataRow In dtMovimientoCaja.Rows
            Dim Folio As Integer= InsertaFicha(CType(row("Total"), Decimal))
            row("FolioGenerado")=Folio
        Next
    End sub

    Private Sub GuardarDatosPorDetalleTPV()
        dtMovimientoCaja.Columns.Add("FolioGenerado", GetType(Integer))

        For Each rowAgrupado As DataRow In dtConsultaAgrupado.Rows
            If (CType(rowAgrupado("Seleccion"), Boolean)) Then
                Dim Folio As Integer = InsertaFicha(CType(rowAgrupado("Total"), Decimal))

                For Each row As DataRow In dtMovimientoCaja.Rows
                    If rowAgrupado("Clave").ToString() = row("Clave").ToString() Then
                        row("FolioGenerado") = Folio
                    End If
                Next
            End If
        Next
    End Sub

    
    Private  sub CargarDatosGuardar()
        dtMovimientoCaja= new DataTable()
        dtMovimientoCaja.Columns.Add("Consecutivo", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Folio", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Cobro", GetType(Integer))
        dtMovimientoCaja.Columns.Add("AnioCobro", GetType(Short))

        dtMovimientoCaja.Columns.Add("FOperacion", GetType(Date))

        For Each rowAgrupado As DataRow In dtConsultaAgrupado.Rows

            If (CType(rowAgrupado("Seleccion"), Boolean)) Then

                For Each rowDetalle As DataRow In dtConsulta.Rows

                    If (operacion <> Operaciones.Cheque) Then
                        If (rowAgrupado("Clave").ToString() = rowDetalle("Clave").ToString()) Then
                            dtMovimientoCaja.Rows.Add(CType(rowDetalle("Consecutivo"), Integer), CType(rowDetalle("Folio"), Integer), CType(rowDetalle("Cobro"), Integer), CType(rowDetalle("AñoCobro"), Short), CType(rowDetalle("FOperacion"), Date))
                        End If
                    Else
                        If (rowAgrupado("Clave").ToString() = rowDetalle("Clave").ToString() And rowAgrupado("Cobro").ToString() = rowDetalle("Cobro").ToString()) Then
                            dtMovimientoCaja.Rows.Add(CType(rowDetalle("Consecutivo"), Integer), CType(rowDetalle("Folio"), Integer), CType(rowDetalle("Cobro"), Integer), CType(rowDetalle("AñoCobro"), Short), CType(rowDetalle("FOperacion"), Date))
                        End If
                    End If


                Next

            End If

        Next

        Dim dvMovimientoCaja As New DataView(dtMovimientoCaja)
        dtMovimientoCaja = dvMovimientoCaja.ToTable(True, "Consecutivo", "Folio", "Cobro", "AnioCobro", "FOperacion")

    End Sub

    Private Sub CargarDatosGuardarSelecionTPV()
        dtMovimientoCaja = New DataTable()
        dtMovimientoCaja.Columns.Add("TipoFicha", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Consecutivo", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Folio", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Cobro", GetType(Integer))
        dtMovimientoCaja.Columns.Add("AnioCobro", GetType(Short))
        dtMovimientoCaja.Columns.Add("Total", GetType(Decimal))

        dtMovimientoCaja.Columns.Add("FOperacion", GetType(Date))

        dtMovimientoCaja.Columns.Add("Clave", GetType(String))

        For Each rowAgrupado As DataRow In dtConsultaAgrupado.Rows

            If (CType(rowAgrupado("Seleccion"), Boolean)) Then

                For Each rowDetalle As DataRow In dtConsulta.Rows

                    If (operacion <> Operaciones.Cheque) Then
                        If (rowAgrupado("Clave").ToString() = rowDetalle("Clave").ToString()) Then
                            dtMovimientoCaja.Rows.Add(CType(rowDetalle("TipoFicha"), Integer), CType(rowDetalle("Consecutivo"), Integer), CType(rowDetalle("Folio"), Integer), CType(rowDetalle("Cobro"), Integer), CType(rowDetalle("AñoCobro"), Short), CType(rowDetalle("Total"), Decimal), CType(rowDetalle("FOperacion"), Date), rowDetalle("Clave").ToString())
                        End If
                    Else
                        If (rowAgrupado("Clave").ToString() = rowDetalle("Clave").ToString() And rowAgrupado("Cobro").ToString() = rowDetalle("Cobro").ToString()) Then
                            dtMovimientoCaja.Rows.Add(CType(rowDetalle("TipoFicha"), Integer), CType(rowDetalle("Consecutivo"), Integer), CType(rowDetalle("Folio"), Integer), CType(rowDetalle("Cobro"), Integer), CType(rowDetalle("AñoCobro"), Short), CType(rowDetalle("Total"), Decimal), CType(rowDetalle("FOperacion"), Date), rowDetalle("Clave").ToString())
                        End If
                    End If


                Next

            End If

        Next

        Dim dvMovimientoCaja As New DataView(dtMovimientoCaja)
        dtMovimientoCaja = dvMovimientoCaja.ToTable(True, "TipoFicha", "Consecutivo", "Folio", "Cobro", "AnioCobro", "Total", "FOperacion", "Clave")

    End Sub

    Private  sub CargarDatosGuardarSeleccionCheque()
        dtMovimientoCaja= new DataTable()
        dtMovimientoCaja.Columns.Add("TipoFicha", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Consecutivo", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Folio", GetType(Integer))
        dtMovimientoCaja.Columns.Add("Cobro", GetType(Integer))
        dtMovimientoCaja.Columns.Add("AnioCobro", GetType(Short))
        dtMovimientoCaja.Columns.Add("Total", GetType(Decimal))

        dtMovimientoCaja.Columns.Add("FOperacion", GetType(Date))

        For Each rowAgrupado As DataRow In dtConsultaAgrupado.Rows

            If (CType(rowAgrupado("Seleccion"), Boolean)) Then

                For Each rowDetalle As DataRow In dtConsulta.Rows

                    If (rowAgrupado("Clave").ToString() = rowDetalle("Clave").ToString() And rowAgrupado("Cobro").ToString() = rowDetalle("Cobro").ToString()) Then
                        dtMovimientoCaja.Rows.Add(CType(rowDetalle("TipoFicha"), Integer), CType(rowDetalle("Consecutivo"), Integer), CType(rowDetalle("Folio"), Integer), CType(rowDetalle("Cobro"), Integer), CType(rowDetalle("AñoCobro"), Short), CType(rowDetalle("Total"), Decimal), CType(rowDetalle("FOperacion"), Date))
                    End If

                Next

            End If

        Next

        Dim dvMovimientoCaja As New DataView(dtMovimientoCaja)
        dtMovimientoCaja = dvMovimientoCaja.ToTable(True, "TipoFicha", "Consecutivo", "Folio", "Cobro", "AnioCobro", "Total", "FOperacion")

    End Sub


    Private sub CargarDatosConculta()
        Try
            'Hacer una copia del grid 
            dtConsultaAgrupado = New DataTable()
            Dim dvAgrupado As New DataView(dtConsulta)
            Dim dtAgrupado As DataTable
            If (operacion <> Operaciones.Cheque) Then
                dtConsultaAgrupado.Columns.Add("Seleccion", GetType(Boolean)).DefaultValue = False
                dtConsultaAgrupado.Columns.Add("Total", GetType(Decimal))
                dtConsultaAgrupado.Columns.Add("Clave", GetType(String))

                dtAgrupado = dvAgrupado.ToTable(True, "Clave")
            Else
                dtConsultaAgrupado.Columns.Add("Seleccion", GetType(Boolean)).DefaultValue = False
                dtConsultaAgrupado.Columns.Add("NumeroCheque", GetType(String))
                dtConsultaAgrupado.Columns.Add("Total", GetType(Decimal))
                dtConsultaAgrupado.Columns.Add("Clave", GetType(String))

                dtConsultaAgrupado.Columns.Add("Cobro", GetType(Integer))
                dtAgrupado = dvAgrupado.ToTable(True, "Clave", "NumeroCheque", "Cobro")
            End If



            'Iniciamos el totalizador general
            totalizadorGeneral =0

            For Each rowAgrupado As DataRow In dtAgrupado.Rows
               dim totalAcomulado AS Decimal =0
                For Each rowDetalle As DataRow In dtConsulta.Rows
                    If (operacion <> Operaciones.Cheque) Then
                        If (rowAgrupado("Clave").ToString() = rowDetalle("Clave").ToString()) Then
                            totalAcomulado = totalAcomulado + CType(rowDetalle("Total"), Decimal)
                        End If
                    Else
                        If (rowAgrupado("Clave").ToString() = rowDetalle("Clave").ToString() And rowAgrupado("NumeroCheque").ToString() = rowDetalle("NumeroCheque").ToString() _
                            And rowAgrupado("Cobro").ToString() = rowDetalle("Cobro").ToString()) Then
                            totalAcomulado = totalAcomulado + CType(rowDetalle("Total"), Decimal)
                        End If
                    End If

                Next
                totalizadorGeneral = totalizadorGeneral + totalAcomulado
                If (operacion <> Operaciones.Cheque) Then
                    dtConsultaAgrupado.Rows.Add(Convert.ToBoolean(0), totalAcomulado, rowAgrupado("Clave").ToString())
                Else
                    dtConsultaAgrupado.Rows.Add(Convert.ToBoolean(0),
                                            rowAgrupado("NumeroCheque").ToString(), totalAcomulado, rowAgrupado("Clave").ToString(), rowAgrupado("Cobro").ToString())

                End If

            Next
        
            Dim dvConsultaAgrupado AS New DataView(dtConsultaAgrupado)
            dgvDetalleDeposito.DataSource = dvConsultaAgrupado

            FormatoDataGridView()


            if (totalizadorGeneral=monto)
                'Cargar datos de las formas
                txtMontoPendiente.Text=totalizadorGeneral.ToString("c")'CType(totalizadorGeneral, String)
                else
                txtMontoPendiente.Text=monto.ToString("c")
            end if

        Catch ex As Exception
            Throw ex
        End Try
    End Sub




    Private Sub FormatoDataGridView()
        Try

            Dim inicio As Integer
        Dim final As Integer
        Dim subCaracter As String


            'Asignacion propiedades del gridview
            Dim arrMapa() As String = CType(IIf(operacion <> Operaciones.Cheque, {"Seleccion", "Total", "Clave"}, {"Seleccion", "NumeroCheque", "Total", "Clave"}), String())

            Dim arrAnchura() As Integer = CType(IIf(operacion <> Operaciones.Cheque, {40, 85, 90}, {40, 110, 85, 90}), Integer())

            Dim arrTexto() As String = {"Seleccion= "} 'CType(IIf(operacion <> Operaciones.Cheque, {"Seleccion= "}, {"Seleccion= ", "NumeroCheque=Cheque"}), String())

            Dim arrFormato() As String = {"Total=##,##0.00"}

        Dim arrInmovilizar() As String = {"Seleccion"}


        'Que columnas estarán visibles
        For i As Integer = 0 To arrMapa.Length - 1

            'Cual sera el orden de las columnas
            dgvDetalleDeposito.Columns(arrMapa(i)).DisplayIndex = i

            'Ajustamiento del tamaño de las columnas
            dgvDetalleDeposito.Columns(arrMapa(i)).Width = arrAnchura(i)



            'Encabezado de las columnas
            For j As Integer = 0 To arrTexto.Length - 1
                inicio = 0
                final = arrTexto(j).LastIndexOf("=")
                subCaracter = arrTexto(j).Substring(inicio, final)

                If (arrMapa(i) = subCaracter) Then
                    inicio = arrTexto(j).LastIndexOf("=") + 1
                    final = arrTexto(j).Length
                    subCaracter = arrTexto(j).Substring(inicio, final - inicio)
                    dgvDetalleDeposito.Columns(arrMapa(i)).HeaderText = subCaracter
                    Exit For
                End If
            Next


            'El formato de las columnas numéricas
            For k As Integer = 0 To arrFormato.Length - 1
                inicio = 0
                final = arrFormato(k).LastIndexOf("=")
                subCaracter = arrFormato(k).Substring(inicio, final)

                If (arrMapa(i) = subCaracter) Then
                    inicio = arrFormato(k).LastIndexOf("=") + 1
                    final = arrFormato(k).Length
                    subCaracter = arrFormato(k).Substring(inicio, final - inicio)
                    dgvDetalleDeposito.Columns(arrMapa(i)).DefaultCellStyle.Format = subCaracter
                    Exit For
                End If
            Next

            'Determina que columnas estaran visibles
            For m As Integer = 0 To arrInmovilizar.Length - 1
                If (arrMapa(i) = arrInmovilizar(m) )Then
                    dgvDetalleDeposito.Columns(arrMapa(i)).Frozen = True
                    Exit For
                End If
            Next

        Next

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub SeleccionarTodos()
        Try
            If (chkSeleccion.Checked )Then

                If (totalizadorGeneral <= monto) Then

                    For Each rowSeleccion As DataRow In dtConsultaAgrupado.Rows
                        rowSeleccion("Seleccion") = True
                    Next
                    txtMonto.Text = totalizadorGeneral.ToString("c")
                Else
                    MessageBox.Show("El monto total del detalle excede el monto total pendiente. Verifique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        Else
            chkSeleccion.Checked = False
            For Each rowSeleccion As DataRow In dtConsultaAgrupado.Rows
                rowSeleccion("Seleccion") = False
            Next
            txtMonto.Text="0"
        End If
        Catch ex As Exception
            Throw ex
        End Try
        
    End Sub

    Private Sub ModificarSeleccion(ByVal index As Integer)
        Try
            If (CType(dgvDetalleDeposito.Item("Seleccion", index).Value, Boolean)) Then
            dgvDetalleDeposito.Item("Seleccion", index).Value = False
            txtMonto.Text=CType(CType(txtMonto.Text, Decimal)-CType(dgvDetalleDeposito.Item("Total", index).Value, Decimal), String)
        Else
            dgvDetalleDeposito.Item("Seleccion", index).Value = true
                Dim  montoNuevo  AS Decimal = CType(txtMonto.Text, Decimal)+CType(dgvDetalleDeposito.Item("Total", index).Value, Decimal)
                if (montoNuevo<=monto)
                    txtMonto.Text=montoNuevo.ToString("c")
                    Else
                    dgvDetalleDeposito.Item("Seleccion", index).Value = False
                    MessageBox.Show("La suma total del detalle seleccionado excede el monto total pendiente. Verifique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
        End If 
            ValidarTotalSeleccion()
        Catch ex As Exception
           Throw ex
        End Try
    End Sub

    Private Sub ValidarTotalSeleccion()

        Dim numVerdadero As Integer = 0

        Dim numColumnas As Integer = dtConsultaAgrupado.Rows.Count

        For Each row As DataRow In dtConsultaAgrupado.Rows

            If (CType(row("Seleccion"), Boolean) = True )Then
                numVerdadero = numVerdadero + 1
            End If
        Next

        If (numVerdadero = numColumnas) Then
            chkSeleccion.Checked = True
        Else
            chkSeleccion.Checked = False
        End If

    End Sub

    
End Class
