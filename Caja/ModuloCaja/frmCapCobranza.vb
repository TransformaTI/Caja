Public Class frmCapCobranza
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cobranza"
    Private ListaCobros As New ArrayList()
    Private Consecutivo As Integer
    Private decImporteTotalCobros As Decimal
    Private _FMovimiento As Date
    Private _TipoCaptura As enumTipoCaptura
    Friend WithEvents cboTipoConcepto As ComboBox
    Friend WithEvents lblTipoConcepto As Label
    Private _TipoMovimientoCaja As Short

    Public Enum enumTipoCaptura
        Cobranza = 1
        NotaIngreso = 2
        Eficiencia = 3
    End Enum


    Public Sub New(ByVal TipoCaptura As enumTipoCaptura,
          Optional ByVal TipoDeMovimiento As Short = 0)
        MyBase.New()
        InitializeComponent()
        _TipoCaptura = TipoCaptura
        _TipoMovimientoCaja = TipoDeMovimiento

        _validacionComplementaria =
            New SigaMetClasses.ValidacionCapturaMovimientoCaja.ValidacionCapturaMovCaja()
    End Sub

#Region "ValidacionInformacionComplementaria"
    Private _validacionComplementaria As SigaMetClasses.ValidacionCapturaMovimientoCaja.ValidacionCapturaMovCaja
    Private _cEfectuarValidacion As SigaMetClasses.ValidacionCapturaMovimientoCaja.CMovimientoValidacion
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

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
    Friend WithEvents lstCobro As System.Windows.Forms.ListBox
    Friend WithEvents lstPedido As System.Windows.Forms.ListBox
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents btnAgregar As ControlesBase.BotonBase
    Friend WithEvents ttDatosPedido As System.Windows.Forms.ToolTip
    Friend WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents Documentos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ImporteTotal As System.Windows.Forms.StatusBarPanel
    Friend WithEvents lblNombreEmpleado As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFOperacion As System.Windows.Forms.DateTimePicker
    Friend WithEvents ComboRuta As SigaMetClasses.Combos.ComboRuta
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboTipoMovCaja As SigaMetClasses.Combos.ComboTipoMovimientoCaja
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents lblClienteNombre As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblNombreRequerido As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapCobranza))
        Me.lstCobro = New System.Windows.Forms.ListBox()
        Me.lstPedido = New System.Windows.Forms.ListBox()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.btnAgregar = New ControlesBase.BotonBase()
        Me.ttDatosPedido = New System.Windows.Forms.ToolTip(Me.components)
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.Documentos = New System.Windows.Forms.StatusBarPanel()
        Me.ImporteTotal = New System.Windows.Forms.StatusBarPanel()
        Me.lblNombreEmpleado = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtpFOperacion = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboRuta = New SigaMetClasses.Combos.ComboRuta()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ComboTipoMovCaja = New SigaMetClasses.Combos.ComboTipoMovimientoCaja()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.lblNombreRequerido = New System.Windows.Forms.Label()
        Me.lblClienteNombre = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboTipoConcepto = New System.Windows.Forms.ComboBox()
        Me.lblTipoConcepto = New System.Windows.Forms.Label()
        CType(Me.Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImporteTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lstCobro
        '
        Me.lstCobro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstCobro.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.lstCobro.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstCobro.ItemHeight = 14
        Me.lstCobro.Location = New System.Drawing.Point(8, 287)
        Me.lstCobro.Name = "lstCobro"
        Me.lstCobro.Size = New System.Drawing.Size(728, 60)
        Me.lstCobro.TabIndex = 0
        '
        'lstPedido
        '
        Me.lstPedido.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstPedido.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstPedido.ItemHeight = 14
        Me.lstPedido.Location = New System.Drawing.Point(8, 366)
        Me.lstPedido.Name = "lstPedido"
        Me.lstPedido.Size = New System.Drawing.Size(728, 228)
        Me.lstPedido.TabIndex = 1
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(656, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 2
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(656, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 1
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAgregar
        '
        Me.btnAgregar.Image = CType(resources.GetObject("btnAgregar.Image"), System.Drawing.Image)
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.Location = New System.Drawing.Point(11, 257)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(112, 24)
        Me.btnAgregar.TabIndex = 0
        Me.btnAgregar.Text = "Agregar cobro"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 617)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Documentos, Me.ImporteTotal})
        Me.stbEstatus.ShowPanels = True
        Me.stbEstatus.Size = New System.Drawing.Size(744, 22)
        Me.stbEstatus.TabIndex = 9
        '
        'Documentos
        '
        Me.Documentos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Documentos.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.Documentos.Name = "Documentos"
        Me.Documentos.Text = "0 cobro(s)"
        Me.Documentos.Width = 363
        '
        'ImporteTotal
        '
        Me.ImporteTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ImporteTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.ImporteTotal.Name = "ImporteTotal"
        Me.ImporteTotal.Text = "$0.00"
        Me.ImporteTotal.Width = 363
        '
        'lblNombreEmpleado
        '
        Me.lblNombreEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblNombreEmpleado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreEmpleado.Location = New System.Drawing.Point(136, 16)
        Me.lblNombreEmpleado.Name = "lblNombreEmpleado"
        Me.lblNombreEmpleado.Size = New System.Drawing.Size(352, 21)
        Me.lblNombreEmpleado.TabIndex = 11
        Me.lblNombreEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 13)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Empleado:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Ruta:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dtpFOperacion
        '
        Me.dtpFOperacion.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFOperacion.Location = New System.Drawing.Point(136, 64)
        Me.dtpFOperacion.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFOperacion.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFOperacion.Name = "dtpFOperacion"
        Me.dtpFOperacion.Size = New System.Drawing.Size(352, 21)
        Me.dtpFOperacion.TabIndex = 14
        Me.dtpFOperacion.Value = New Date(2000, 12, 31, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(119, 13)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Fecha de operación:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboRuta
        '
        Me.ComboRuta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboRuta.Location = New System.Drawing.Point(136, 40)
        Me.ComboRuta.Name = "ComboRuta"
        Me.ComboRuta.Size = New System.Drawing.Size(352, 21)
        Me.ComboRuta.TabIndex = 16
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 350)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(229, 13)
        Me.Label4.TabIndex = 17
        Me.Label4.Text = "Lista de documentos relacionados con el cobro"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboTipoMovCaja
        '
        Me.ComboTipoMovCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoMovCaja.Location = New System.Drawing.Point(136, 88)
        Me.ComboTipoMovCaja.Name = "ComboTipoMovCaja"
        Me.ComboTipoMovCaja.Size = New System.Drawing.Size(352, 21)
        Me.ComboTipoMovCaja.TabIndex = 19
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(122, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Tipo de movimiento:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCliente
        '
        Me.txtCliente.Location = New System.Drawing.Point(136, 112)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(352, 21)
        Me.txtCliente.TabIndex = 21
        '
        'lblNombreRequerido
        '
        Me.lblNombreRequerido.AutoSize = True
        Me.lblNombreRequerido.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombreRequerido.Location = New System.Drawing.Point(8, 115)
        Me.lblNombreRequerido.Name = "lblNombreRequerido"
        Me.lblNombreRequerido.Size = New System.Drawing.Size(49, 13)
        Me.lblNombreRequerido.TabIndex = 22
        Me.lblNombreRequerido.Text = "Cliente:"
        Me.lblNombreRequerido.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblClienteNombre
        '
        Me.lblClienteNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblClienteNombre.Location = New System.Drawing.Point(136, 136)
        Me.lblClienteNombre.Name = "lblClienteNombre"
        Me.lblClienteNombre.Size = New System.Drawing.Size(352, 21)
        Me.lblClienteNombre.TabIndex = 23
        '
        'txtObservaciones
        '
        Me.txtObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtObservaciones.Location = New System.Drawing.Point(136, 160)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObservaciones.Size = New System.Drawing.Size(352, 64)
        Me.txtObservaciones.TabIndex = 24
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Concepto:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cboTipoConcepto
        '
        Me.cboTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoConcepto.FormattingEnabled = True
        Me.cboTipoConcepto.Location = New System.Drawing.Point(136, 230)
        Me.cboTipoConcepto.Name = "cboTipoConcepto"
        Me.cboTipoConcepto.Size = New System.Drawing.Size(352, 21)
        Me.cboTipoConcepto.TabIndex = 26
        '
        'lblTipoConcepto
        '
        Me.lblTipoConcepto.AutoSize = True
        Me.lblTipoConcepto.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoConcepto.Location = New System.Drawing.Point(11, 233)
        Me.lblTipoConcepto.Name = "lblTipoConcepto"
        Me.lblTipoConcepto.Size = New System.Drawing.Size(95, 13)
        Me.lblTipoConcepto.TabIndex = 27
        Me.lblTipoConcepto.Text = "Ttipo Concepto:"
        Me.lblTipoConcepto.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblTipoConcepto.Visible = False
        '
        'frmCapCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(744, 639)
        Me.Controls.Add(Me.lblTipoConcepto)
        Me.Controls.Add(Me.cboTipoConcepto)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblNombreRequerido)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtObservaciones)
        Me.Controls.Add(Me.lblClienteNombre)
        Me.Controls.Add(Me.txtCliente)
        Me.Controls.Add(Me.ComboTipoMovCaja)
        Me.Controls.Add(Me.ComboRuta)
        Me.Controls.Add(Me.dtpFOperacion)
        Me.Controls.Add(Me.lblNombreEmpleado)
        Me.Controls.Add(Me.stbEstatus)
        Me.Controls.Add(Me.btnAgregar)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lstPedido)
        Me.Controls.Add(Me.lstCobro)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCapCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de cobranza"
        CType(Me.Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImporteTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Consecutivo += 1
        Dim frmSelTipoCobro As frmSelTipoCobro
        Dim soloEfectivo As Boolean = False
        Dim Movimientos As Boolean
        Movimientos = True
        If ComboTipoMovCaja.TipoMovimientoCaja = 43 Then
            soloEfectivo = True
        End If
        If _TipoMovimientoCaja = 15 Then
            frmSelTipoCobro = New frmSelTipoCobro(Consecutivo, aSoloEfectivo:=soloEfectivo)
        Else
            frmSelTipoCobro = New frmSelTipoCobro(Consecutivo, False, aSoloEfectivo:=soloEfectivo)
        End If
        frmSelTipoCobro.Movimiento = Movimientos
        If frmSelTipoCobro.ShowDialog() = DialogResult.OK Then
            Dim CobroRecuperado As SigaMetClasses.CobroDetalladoDatos
            Dim TipoCobroOriginal As New SigaMetClasses.sCobro()

            If (Not frmSelTipoCobro.Cobros Is Nothing And frmSelTipoCobro.Cobros.Count > 0) Then
                CobroRecuperado = frmSelTipoCobro.Cobros(0)
                TipoCobroOriginal.Consecutivo = Consecutivo
                TipoCobroOriginal.AnoCobro = CobroRecuperado.AñoCobro
                Select Case CobroRecuperado.TipoCobro
                    Case 2
                        TipoCobroOriginal.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Vales
                    Case 5
                        TipoCobroOriginal.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Efectivo
                    Case 6
                        TipoCobroOriginal.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.TarjetaCredito
                    Case 3
                        TipoCobroOriginal.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Cheque
                    Case 10
                        TipoCobroOriginal.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.Transferencia
                    Case 30
                        TipoCobroOriginal.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.AplicacionAnticipo
                    Case 50
                        TipoCobroOriginal.TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.DacionEnPago
                End Select

                TipoCobroOriginal.Total = CobroRecuperado.Total
                TipoCobroOriginal.Saldo = CobroRecuperado.Saldo
                TipoCobroOriginal.NoCheque = CobroRecuperado.NumeroCheque
                TipoCobroOriginal.FechaCheque = CobroRecuperado.FCheque
                TipoCobroOriginal.NoCuenta = CobroRecuperado.NumeroCuenta
                TipoCobroOriginal.Cliente = CobroRecuperado.Cliente
                TipoCobroOriginal.Banco = CobroRecuperado.Banco
                TipoCobroOriginal.Observaciones = CobroRecuperado.Observaciones
                TipoCobroOriginal.Referencia = CobroRecuperado.Referencia
                'TipoCobroOriginal.ListaPedidos = CobroRecuperado.Pedidos

            Else

            End If


            ListaCobros.Add(TipoCobroOriginal)
            lstCobro.Items.Add(TipoCobroOriginal)
            decImporteTotalCobros += frmSelTipoCobro.ImporteTotalCobro
            stbEstatus.Panels(0).Text = lstCobro.Items.Count.ToString & " cobro(s)"
            stbEstatus.Panels(1).Text = decImporteTotalCobros.ToString("C")
        Else
            Consecutivo -= 1
        End If

    End Sub

    Private Sub frmCapCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        dtpFOperacion.Value = Now.Date

        Try
            ComboRuta.CargaDatos()
            Select Case _TipoCaptura
                Case enumTipoCaptura.Cobranza
                    ComboTipoMovCaja.CargaDatos(True, False, True)
                Case enumTipoCaptura.NotaIngreso
                    ComboTipoMovCaja.CargaDatosNotasIngreso()
                Case enumTipoCaptura.Eficiencia
                    ComboTipoMovCaja.CargaDatos(15, True)

            End Select

            ComboTipoMovCaja.SelectedIndex = 0

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

        lblNombreEmpleado.Text = GLOBAL_EmpleadoNombre
        lstCobro.DisplayMember = "InformacionCompleta"
        lstPedido.DisplayMember = "InformacionCompleta"
        HabiltaComboTipoConcepto()

        Dim m_metodos As New MetodoDatos
        Me.cboTipoConcepto.DataSource = m_metodos.CargaTipoConcepto()
        Me.cboTipoConcepto.DisplayMember = "Descripcion"
        Me.cboTipoConcepto.ValueMember = "TipoConcepto"


    End Sub


    Private Sub lstCobro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstCobro.SelectedIndexChanged
        Dim s As SigaMetClasses.sPedido
        lstPedido.Items.Clear()
        If Not CType(lstCobro.Items(lstCobro.SelectedIndex), SigaMetClasses.sCobro).ListaPedidos Is Nothing Then
            For Each s In CType(lstCobro.Items(lstCobro.SelectedIndex), SigaMetClasses.sCobro).ListaPedidos()
                lstPedido.Items.Add(s)
            Next
        End If
    End Sub

    Private Sub lstPedido_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstPedido.SelectedIndexChanged
        If lstPedido.SelectedIndex <> -1 Then
            Dim strTip As String
            strTip = "Documento: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).PedidoReferencia & Chr(13) &
                     "Cliente: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).Cliente.ToString & Chr(13) &
                     "Nombre: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).Nombre & Chr(13) &
                     "Importe del documento: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).Importe.ToString("N") & Chr(13) &
                     "Importe del abono: " & CType(lstPedido.Items(lstPedido.SelectedIndex), SigaMetClasses.sPedido).ImporteAbono.ToString("N")
            ttDatosPedido.SetToolTip(lstPedido, strTip)
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        ' RM 19_07_2018, Se comenta validación, la captura del cliente debe ser opcional
        'If Not ValidacionInformacionComplementariaCierre() Then
        '    Exit Sub
        'End If

        If ComboTipoMovCaja.TipoMovimientoCaja <= 0 Then
            MessageBox.Show("Debe seleccionar el tipo de movimiento de esta captura.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        If lstCobro.Items.Count <= 0 Then
            MessageBox.Show("No se han agregado cobros a esta captura.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'Validar aquí

        If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
            _FMovimiento = CType(dtpFOperacion.Value.ToShortDateString, Date)
            Dim oMov As New SigaMetClasses.TransaccionMovimientoCaja()
            Dim strNuevaClave As String, _Cliente As Integer
            strNuevaClave = Nothing
            Try
                If Main.SesionIniciada = False Then
                    IniciarSesion(FechaInicioSesion)
                End If

                If txtCliente.Text = "" Then
                    _Cliente = 0
                Else
                    _Cliente = CType(txtCliente.Text, Integer)
                End If

                'Captura de notas de ingreso que piden código de empleado
                Dim _idEmpleado As Integer = GLOBAL_IDEmpleado
                'Verificar que se haya generado el objeto de validación
                'Verificar que el campo de validación sea EMPLEADO
                If Not _cEfectuarValidacion Is Nothing AndAlso
                    _cEfectuarValidacion.ValorParaValidacion.Trim().ToUpper() = "EMPLEADO" AndAlso
                    _cEfectuarValidacion.Requerido Then
                    'Si el valor de validación es requerido y el campo a validar es la columna empleado
                    'El valor se guardará en la columna empleado de la tabla MovimientoCaja
                    _idEmpleado = CType(txtCliente.Text, Integer)
                    'Los registros que solicitan como clave de validación el número del empleado,
                    'registraran cero como número de cliente 02/03/2010
                    _Cliente = 0
                End If

                Dim i As Integer = oMov.Alta(Main.GLOBAL_CajaUsuario,
                                FechaOperacion,
                                ConsecutivoInicioDeSesion,
                                _FMovimiento,
                                decImporteTotalCobros,
                                GLOBAL_IDUsuario,
                                _idEmpleado,
                                CType(ComboTipoMovCaja.TipoMovimientoCaja, Byte),
                                ComboRuta.Ruta,
                                _Cliente,
                                ListaCobros,
                                Main.GLOBAL_IDUsuario,
                                Trim(txtObservaciones.Text),
                                strNuevaClave)

                MessageBox.Show(M_DATOS_OK, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Information)

                If _TipoCaptura = enumTipoCaptura.Eficiencia Then
                    If MessageBox.Show("¿Desea imprimir la eficiencia negativa: " & strNuevaClave & "?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Dim frmrep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RepMovimientoCajaDetalle, 0, Now.Date, FechaOperacion, Main.GLOBAL_CajaUsuario, i, ConsecutivoInicioDeSesion, strNuevaClave)
                        frmrep.ShowDialog()
                    End If
                End If

                If _TipoCaptura = enumTipoCaptura.NotaIngreso Then
                    If MessageBox.Show("¿Desea imprimir la nota: " & strNuevaClave & "?", Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = DialogResult.Yes Then
                        Dim frmRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RepFormatoNotaIngreso, 0, Now, Now, , , , strNuevaClave)
                        frmRep.ShowDialog()
                    End If
                End If


                CapturaEfectivoVales = False
                CapturaMixtaEfectivoVales = False
                Me.Close()
            Catch ex As Exception
                MessageBox.Show(ex.ToString, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                oMov = Nothing
            End Try
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmCapCobranza_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
        CapturaEfectivoVales = False
        CapturaMixtaEfectivoVales = False
        ClienteCapturaCobranza = 0
    End Sub

    Private Sub txtCliente_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCliente.Leave
        If txtCliente.Text <> "" Then
            ValidarInformacionCaptura()

            'TODO: JAGD se ubica dentro de ValidarInformacionCaptura
            'Dim oCliente As New SigaMetClasses.cCliente()
            'oCliente.Consulta(CType(txtCliente.Text, Integer))
            'lblClienteNombre.Text = oCliente.Nombre
        End If
    End Sub

    Private Sub ValidacionInformacionComplementaria()
        _cEfectuarValidacion = Nothing
        Dim cValidacion As SigaMetClasses.ValidacionCapturaMovimientoCaja.CMovimientoValidacion =
            _validacionComplementaria.ConsultaValidacion(ComboTipoMovCaja.TipoMovimientoCaja)

        If Not cValidacion Is Nothing Then
            lblNombreRequerido.Text = cValidacion.ValorParaValidacion & ":"
            _cEfectuarValidacion = cValidacion
        End If
    End Sub

    Private Function ValidacionInformacionComplementariaCierre() As Boolean
        If _cEfectuarValidacion Is Nothing Then
            ValidacionInformacionComplementaria()
        End If
        If Not _cEfectuarValidacion Is Nothing Then
            If txtCliente.Text.Length > 0 Then
                If _cEfectuarValidacion.ValidacionCaptura AndAlso
                Not _cEfectuarValidacion.EfectuarValidacion(Convert.ToInt32(txtCliente.Text)) Then
                    MessageBox.Show("Debe proporcionar una clave de " & _cEfectuarValidacion.ValorParaValidacion & " válida.", Me.Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            Else
                If _cEfectuarValidacion.Requerido Then
                    MessageBox.Show("Debe capturar la clave de " & _cEfectuarValidacion.ValorParaValidacion & ".", Me.Name,
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Return False
                End If
            End If
        End If
        Return True
    End Function

    Private Sub ValidarInformacionCaptura()
        Dim oConfig As SigaMetClasses.cConfig = New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim URLGateway As String = "" ' CType(oConfig.Parametros.Item("URLGateway"), String)
        oConfig.Dispose()

        If _cEfectuarValidacion Is Nothing Then
            ValidacionInformacionComplementaria()
        End If

        If Not _cEfectuarValidacion Is Nothing Then

            If String.IsNullOrEmpty(URLGateway) Then
                If _cEfectuarValidacion.ValidacionCaptura AndAlso _cEfectuarValidacion.EfectuarValidacion(Convert.ToInt32(txtCliente.Text)) Then
                    lblClienteNombre.Text = _cEfectuarValidacion.DescripcionValorValidacion
                    Return
                End If
            Else
                If _cEfectuarValidacion.ValidacionCaptura AndAlso _cEfectuarValidacion.EfectuarValidacion(Convert.ToInt32(txtCliente.Text), URLGateway) Then
                    lblClienteNombre.Text = _cEfectuarValidacion.DescripcionValorValidacion
                    Return
                End If
            End If
        End If
    End Sub

    Private Sub ComboTipoMovCaja_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboTipoMovCaja.SelectedIndexChanged
        If ComboTipoMovCaja.TipoMovimientoCaja <> 0 Then
            ValidacionInformacionComplementaria()
            HabiltaComboTipoConcepto()
        End If
    End Sub
    Private Sub HabiltaComboTipoConcepto()
        If Me.ComboTipoMovCaja.TipoMovimientoCaja = 43 Then
            Me.cboTipoConcepto.Visible = True
            If Me.cboTipoConcepto.Items.Count = 0 Then
                MessageBox.Show("No existe tipo de cocepto, registre en el catalogo un tipo de concepto", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        Else
            Me.cboTipoConcepto.Visible = False
        End If
        lblTipoConcepto.Visible = Me.cboTipoConcepto.Visible
    End Sub

    Private Sub txtCliente_MouseCaptureChanged(sender As Object, e As EventArgs) Handles txtCliente.MouseCaptureChanged

    End Sub

End Class

#Region "Estructuras"
'Estructura de Pedidos para el llenado del listbox

'Public Structure sCobro
'    Private _Consecutivo As Integer
'    Private _AnoCobro As Short
'    Private _TipoCobro As enumTipoCobro
'    Private _Total As Decimal
'    Private _NoCheque As String
'    Private _FechaCheque As Date
'    Private _NoCuenta As String
'    Private _Cliente As Integer
'    Private _Banco As Short
'    Private _Observaciones As String
'    Private _ListaPedidos As ArrayList

'    Public Property Consecutivo() As Integer
'        Get
'            Return _Consecutivo
'        End Get
'        Set(ByVal Value As Integer)
'            _Consecutivo = Value
'        End Set
'    End Property

'    Public Property AnoCobro() As Short
'        Get
'            Return _AnoCobro
'        End Get
'        Set(ByVal Value As Short)
'            _AnoCobro = Value
'        End Set
'    End Property

'    Public Property TipoCobro() As enumTipoCobro
'        Get
'            Return _TipoCobro
'        End Get
'        Set(ByVal Value As enumTipoCobro)
'            _TipoCobro = Value
'        End Set
'    End Property

'    Public Property Total() As Decimal
'        Get
'            Return _Total
'        End Get
'        Set(ByVal Value As Decimal)
'            _Total = Value
'        End Set
'    End Property

'    Public Property NoCheque() As String
'        Get
'            Return _NoCheque
'        End Get
'        Set(ByVal Value As String)
'            _NoCheque = Value
'        End Set
'    End Property

'    Public Property FechaCheque() As Date
'        Get
'            Return _FechaCheque
'        End Get
'        Set(ByVal Value As Date)
'            _FechaCheque = Value
'        End Set
'    End Property

'    Public Property NoCuenta() As String
'        Get
'            Return _NoCuenta
'        End Get
'        Set(ByVal Value As String)
'            _NoCuenta = Value
'        End Set
'    End Property

'    Public Property Cliente() As Integer
'        Get
'            Return _Cliente
'        End Get
'        Set(ByVal Value As Integer)
'            _Cliente = Value
'        End Set
'    End Property

'    Public Property Banco() As Short
'        Get
'            Return _Banco
'        End Get
'        Set(ByVal Value As Short)
'            _Banco = Value
'        End Set
'    End Property

'    Public Property Observaciones() As String
'        Get
'            Return _Observaciones
'        End Get
'        Set(ByVal Value As String)
'            _Observaciones = Value
'        End Set
'    End Property

'    Public Property ListaPedidos() As ArrayList
'        Get
'            Return _ListaPedidos
'        End Get
'        Set(ByVal Value As ArrayList)
'            _ListaPedidos = Value
'        End Set
'    End Property

'    Public ReadOnly Property InformacionCompleta() As String
'        Get
'            Return "Cobro: " & LSet(Trim(_Consecutivo.ToString), 3) & " " & LSet(Trim(_TipoCobro.ToString), 20) & " Importe:" & RSet(Trim(_Total.ToString("C")), 20) & " " & RSet(Trim(_ListaPedidos.Count.ToString), 5) & " documento(s)"
'        End Get
'    End Property

'End Structure


'Public Structure sPedido
'    Private _Cobro As Integer
'    Private _Celula As Byte
'    Private _AnoPed As Short
'    Private _Pedido As Integer
'    Private _Importe As Decimal
'    Private _ImporteAbono As Decimal
'    Private _PedidoReferencia As String
'    Private _Cliente As Integer
'    Private _Nombre As String

'    Public Property Cobro() As Integer
'        Get
'            Return _Cobro
'        End Get
'        Set(ByVal Value As Integer)
'            _Cobro = Value
'        End Set
'    End Property

'    Public Property Celula() As Byte
'        Get
'            Return _Celula
'        End Get
'        Set(ByVal Value As Byte)
'            _Celula = Value
'        End Set
'    End Property

'    Public Property AnoPed() As Short
'        Get
'            Return _AnoPed
'        End Get
'        Set(ByVal Value As Short)
'            _AnoPed = Value
'        End Set
'    End Property

'    Public Property Pedido() As Integer
'        Get
'            Return _Pedido
'        End Get
'        Set(ByVal Value As Integer)
'            _Pedido = Value
'        End Set
'    End Property

'    Public Property Importe() As Decimal
'        Get
'            Return _Importe
'        End Get
'        Set(ByVal Value As Decimal)
'            _Importe = Value
'        End Set
'    End Property

'    Public Property ImporteAbono() As Decimal
'        Get
'            Return _ImporteAbono
'        End Get
'        Set(ByVal Value As Decimal)
'            _ImporteAbono = Value
'        End Set
'    End Property

'    Public Property PedidoReferencia() As String
'        Get
'            Return _PedidoReferencia
'        End Get
'        Set(ByVal Value As String)
'            _PedidoReferencia = Value
'        End Set
'    End Property

'    Public ReadOnly Property InformacionCompleta() As String
'        Get
'            Return LSet(_PedidoReferencia, 20) & " " & RSet(Trim(_ImporteAbono.ToString("N")), 15)
'        End Get
'    End Property

'    Public Property Cliente() As Integer
'        Get
'            Return _Cliente
'        End Get
'        Set(ByVal Value As Integer)
'            _Cliente = Value
'        End Set
'    End Property

'    Public Property Nombre() As String
'        Get
'            Return _Nombre
'        End Get
'        Set(ByVal Value As String)
'            _Nombre = Value
'        End Set
'    End Property
'End Structure
#End Region
