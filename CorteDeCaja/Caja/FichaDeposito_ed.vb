Option Strict On
Imports System.Data
Imports System.Data.SqlClient

Public Class FichaDeposito_ed
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private daSelect As New SqlDataAdapter()
    Private drLeer As SqlDataReader
    Private dtSelect As New DataTable()
    Private VGN_TipoFicha As Integer
    Private VGN_FFicha As DateTime
    Private VGS_Concepto As String
    Public VGN_Folio As Integer
    Public blnAgregarAlCorte As Boolean

    Public EmpreContableOriginal As Boolean = False

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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFolio As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFAlta As DevExpress.XtraEditors.TextEdit
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(FichaDeposito_ed))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFolio = New DevExpress.XtraEditors.TextEdit()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtFAlta = New DevExpress.XtraEditors.TextEdit()
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
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtFAlta, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.chkAgregar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoFicha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTipoMovimiento, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtMontoPendiente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(97, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Folio :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFolio
        '
        Me.txtFolio.Location = New System.Drawing.Point(141, 49)
        Me.txtFolio.Name = "txtFolio"
        Me.txtFolio.Properties.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFolio.Properties.Enabled = False
        Me.txtFolio.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                        Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                        Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                        Or DevExpress.Utils.StyleOptions.UseFont) _
                        Or DevExpress.Utils.StyleOptions.UseForeColor) _
                        Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                        Or DevExpress.Utils.StyleOptions.UseImage) _
                        Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                        Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Default, Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtFolio.Size = New System.Drawing.Size(128, 27)
        Me.txtFolio.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(58, 202)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Fecha Ficha :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(66, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(69, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Tipo Ficha :"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(66, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Fecha Alta :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFAlta
        '
        Me.txtFAlta.Enabled = False
        Me.txtFAlta.Location = New System.Drawing.Point(141, 140)
        Me.txtFAlta.Name = "txtFAlta"
        Me.txtFAlta.Properties.DisabledForeColor = System.Drawing.Color.Black
        Me.txtFAlta.Properties.Enabled = False
        Me.txtFAlta.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                        Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                        Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                        Or DevExpress.Utils.StyleOptions.UseFont) _
                        Or DevExpress.Utils.StyleOptions.UseForeColor) _
                        Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                        Or DevExpress.Utils.StyleOptions.UseImage) _
                        Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                        Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Default, Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtFAlta.Size = New System.Drawing.Size(128, 23)
        Me.txtFAlta.TabIndex = 7
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(47, 175)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 15)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Cuenta Banco :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbCuenta
        '
        Me.cmbCuenta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCuenta.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCuenta.Location = New System.Drawing.Point(141, 169)
        Me.cmbCuenta.Name = "cmbCuenta"
        Me.cmbCuenta.Size = New System.Drawing.Size(320, 22)
        Me.cmbCuenta.TabIndex = 4
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(511, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(96, 32)
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(511, 61)
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
        Me.chkAgregar.Properties.AllowFocused = False
        Me.chkAgregar.Properties.AutoHeight = False
        Me.chkAgregar.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder
        Me.chkAgregar.Properties.CheckAlign = DevExpress.XtraEditors.Controls.CheckAlignStyles.NoText
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(31, 232)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 15)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "Fecha Operación :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtFechaFicha
        '
        Me.dtFechaFicha.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFechaFicha.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtFechaFicha.Location = New System.Drawing.Point(141, 198)
        Me.dtFechaFicha.Name = "dtFechaFicha"
        Me.dtFechaFicha.Size = New System.Drawing.Size(128, 23)
        Me.dtFechaFicha.TabIndex = 34
        Me.dtFechaFicha.Value = New Date(2005, 1, 28, 0, 0, 0, 0)
        '
        'dtFOperacion
        '
        Me.dtFOperacion.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtFOperacion.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.dtFOperacion.Location = New System.Drawing.Point(141, 228)
        Me.dtFOperacion.Name = "dtFOperacion"
        Me.dtFOperacion.Size = New System.Drawing.Size(128, 23)
        Me.dtFOperacion.TabIndex = 35
        Me.dtFOperacion.Value = New Date(2005, 1, 28, 0, 0, 0, 0)
        '
        'txtTipoFicha
        '
        Me.txtTipoFicha.Enabled = False
        Me.txtTipoFicha.Location = New System.Drawing.Point(141, 110)
        Me.txtTipoFicha.Name = "txtTipoFicha"
        Me.txtTipoFicha.Properties.DisabledForeColor = System.Drawing.Color.Black
        Me.txtTipoFicha.Properties.Enabled = False
        Me.txtTipoFicha.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                        Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                        Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                        Or DevExpress.Utils.StyleOptions.UseFont) _
                        Or DevExpress.Utils.StyleOptions.UseForeColor) _
                        Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                        Or DevExpress.Utils.StyleOptions.UseImage) _
                        Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                        Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Default, Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtTipoFicha.Size = New System.Drawing.Size(320, 23)
        Me.txtTipoFicha.TabIndex = 36
        '
        'txtTipoMovimiento
        '
        Me.txtTipoMovimiento.Enabled = False
        Me.txtTipoMovimiento.Location = New System.Drawing.Point(140, 81)
        Me.txtTipoMovimiento.Name = "txtTipoMovimiento"
        Me.txtTipoMovimiento.Properties.DisabledForeColor = System.Drawing.Color.Black
        Me.txtTipoMovimiento.Properties.Enabled = False
        Me.txtTipoMovimiento.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                        Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                        Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                        Or DevExpress.Utils.StyleOptions.UseFont) _
                        Or DevExpress.Utils.StyleOptions.UseForeColor) _
                        Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                        Or DevExpress.Utils.StyleOptions.UseImage) _
                        Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                        Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, True, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Default, Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtTipoMovimiento.Size = New System.Drawing.Size(320, 23)
        Me.txtTipoMovimiento.TabIndex = 38
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(34, 85)
        Me.Label7.Name = "Label7"
        Me.Label7.TabIndex = 37
        Me.Label7.Text = "Tipo movimiento:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMontoPendiente
        '
        Me.txtMontoPendiente.Enabled = False
        Me.txtMontoPendiente.Location = New System.Drawing.Point(141, 258)
        Me.txtMontoPendiente.Name = "txtMontoPendiente"
        Me.txtMontoPendiente.Properties.DisabledBackColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.txtMontoPendiente.Properties.DisabledForeColor = System.Drawing.Color.Brown
        Me.txtMontoPendiente.Properties.Enabled = False
        Me.txtMontoPendiente.Properties.Style = New DevExpress.Utils.ViewStyle("ControlStyle", "BaseEdit", New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte)), "", (((((((((DevExpress.Utils.StyleOptions.StyleEnabled Or DevExpress.Utils.StyleOptions.UseBackColor) _
                        Or DevExpress.Utils.StyleOptions.UseDrawEndEllipsis) _
                        Or DevExpress.Utils.StyleOptions.UseDrawFocusRect) _
                        Or DevExpress.Utils.StyleOptions.UseFont) _
                        Or DevExpress.Utils.StyleOptions.UseForeColor) _
                        Or DevExpress.Utils.StyleOptions.UseHorzAlignment) _
                        Or DevExpress.Utils.StyleOptions.UseImage) _
                        Or DevExpress.Utils.StyleOptions.UseWordWrap) _
                        Or DevExpress.Utils.StyleOptions.UseVertAlignment), True, False, False, DevExpress.Utils.HorzAlignment.Default, DevExpress.Utils.VertAlignment.Default, Nothing, System.Drawing.SystemColors.Window, System.Drawing.SystemColors.WindowText)
        Me.txtMontoPendiente.Size = New System.Drawing.Size(207, 25)
        Me.txtMontoPendiente.TabIndex = 40
        Me.txtMontoPendiente.Text = "0"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(22, 263)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(113, 15)
        Me.Label12.TabIndex = 39
        Me.Label12.Text = "Efectivo pendiente :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMonto
        '
        Me.txtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(141, 289)
        Me.txtMonto.MaxLength = 20
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(207, 23)
        Me.txtMonto.TabIndex = 41
        Me.txtMonto.Text = "0"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Blue
        Me.Label2.Location = New System.Drawing.Point(82, 293)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Monto :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCaja.ForeColor = System.Drawing.Color.Blue
        Me.lblCaja.Location = New System.Drawing.Point(86, 20)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(69, 19)
        Me.lblCaja.TabIndex = 44
        Me.lblCaja.Text = "Caja :  5"
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FichaDeposito_ed
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(626, 360)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCaja, Me.Label2, Me.txtMonto, Me.txtMontoPendiente, Me.Label12, Me.txtTipoMovimiento, Me.Label7, Me.txtTipoFicha, Me.dtFOperacion, Me.dtFechaFicha, Me.Label8, Me.Label9, Me.Label6, Me.Label4, Me.Label3, Me.Label1, Me.btnAceptar, Me.btnCancelar, Me.cmbCuenta, Me.txtFAlta, Me.txtFolio})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FichaDeposito_ed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Fichas de depósito "
        CType(Me.txtFolio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtFAlta, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.chkAgregar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoFicha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTipoMovimiento, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtMontoPendiente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Entrar(ByVal TipoFicha As Integer, ByVal TipoFichaDescripcion As String, ByVal Concepto As String, ByVal Monto As Decimal, ByVal FFicha As DateTime, ByVal Desgloce As Boolean)
        Dim VLM_MontoPendiente As Decimal

        'Folio de la Ficha
        lblCaja.Text = "Caja :  " + CType(dmModulo.VGN_Caja, String)
        With cmdCommand
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spSSConsecutivoFicha"
            drLeer = .ExecuteReader
            If drLeer.Read Then
                txtFolio.Text = CType(drLeer("Consecutivo"), String)
                drLeer.Close()
            End If
            If EmpreContableOriginal Then
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

        txtTipoFicha.Text = TipoFichaDescripcion
        txtTipoMovimiento.Text = Concepto
        VGS_Concepto = TipoFichaDescripcion
        txtFAlta.Text = Now.ToShortDateString
        dtFechaFicha.Value = FFicha
        dtFOperacion.Value = CType(dmModulo.VGS_FOperacion, DateTime)
        txtMonto.Text = Monto.ToString("c")
        VGN_TipoFicha = TipoFicha
        VGN_FFicha = FFicha


        If Desgloce Then
            txtMonto.Enabled = True
        Else
            txtMonto.Enabled = False
        End If

        VLM_MontoPendiente = dmModulo.MontoPendienteTipoFicha(TipoFicha, True, 0, 0)
        If (VLM_MontoPendiente <> -1) And (VGN_TipoFicha <> 0) Then
            txtMontoPendiente.Text = VLM_MontoPendiente.ToString("c")
        Else
            'En este caso, se insertaria como primera vez el MONTO PENDIENTE DE ESTE TIPO DE FICHA
            'En el caso de que VGN_TipoFicha <> 0, quiere decir que se va a insertar una ficha multiple
            txtMontoPendiente.Text = Monto.ToString("c")
        End If



        Me.ShowDialog()
    End Sub

    '2008-001-EIM-01
    'REQ 025
    'Autor: Ana Juárez
    'Insercion de fichas
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

                If VGN_TipoFicha <> 0 Then
                    dmModulo.MontoPendienteTipoFicha(VGN_TipoFicha, False, CType(txtMonto.Text, Decimal), CType(txtMontoPendiente.Text, Decimal))
                End If

                Me.blnAgregarAlCorte = True
            End With
        Catch err As Exception
            MsgBox(err.Message)
        End Try

    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        VGN_Folio = 0
        Me.blnAgregarAlCorte = False

        Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If CType(txtMontoPendiente.Text, Decimal) >= CType(txtMonto.Text, Decimal) Then
            InsertaFicha()
        Else
            MessageBox.Show("El monto de la ficha que se esta capturando en mayor al monto pendiente, NO SE PUEDE REALIZAR LA OPERACIÓN. Verique!", "Caja", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

        Close()

    End Sub

    Private Sub FichaDeposito_ed_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
