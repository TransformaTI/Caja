Public Class frmChequeTarjetaMovCaja
    Inherits System.Windows.Forms.Form
    Private ColumnaCliente As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal ColumnaClaveCliente As Integer)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        ColumnaCliente = ColumnaClaveCliente

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
    Friend WithEvents colNumeroCheque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colClienteNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFCheque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNumeroCuenta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents mnuConsulta As System.Windows.Forms.ContextMenu
    Friend WithEvents miConsultaCliente As System.Windows.Forms.MenuItem
    Friend WithEvents btnConsultaCliente As ControlesBase.BotonBase
    Friend WithEvents btnCerrar As ControlesBase.BotonBase
    Friend WithEvents EstiloCheques As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents EstiloTarjetaCredito As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colTCTarjetaCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents grdConsulta As System.Windows.Forms.DataGrid
    Friend WithEvents colTCBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTCCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTCClienteNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTCTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTCObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents EstiloFichaDeposito As System.Windows.Forms.DataGridTableStyle
    Private WithEvents colFDNumeroCuenta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDBancoNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDClienteNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDSaldo As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFDFDocumento As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmChequeTarjetaMovCaja))
        Me.grdConsulta = New System.Windows.Forms.DataGrid()
        Me.EstiloCheques = New System.Windows.Forms.DataGridTableStyle()
        Me.colNumeroCheque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNumeroCuenta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colClienteNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFCheque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.EstiloTarjetaCredito = New System.Windows.Forms.DataGridTableStyle()
        Me.colTCTarjetaCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTCBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTCCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTCClienteNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTCTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTCObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.EstiloFichaDeposito = New System.Windows.Forms.DataGridTableStyle()
        Me.colFDTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDFDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDNumeroCuenta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDBancoNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDClienteNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFDObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.mnuConsulta = New System.Windows.Forms.ContextMenu()
        Me.miConsultaCliente = New System.Windows.Forms.MenuItem()
        Me.btnConsultaCliente = New ControlesBase.BotonBase()
        Me.btnCerrar = New ControlesBase.BotonBase()
        CType(Me.grdConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdConsulta
        '
        Me.grdConsulta.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdConsulta.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdConsulta.CaptionBackColor = System.Drawing.Color.Gainsboro
        Me.grdConsulta.CaptionText = "Cobros"
        Me.grdConsulta.DataMember = ""
        Me.grdConsulta.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdConsulta.Location = New System.Drawing.Point(8, 8)
        Me.grdConsulta.Name = "grdConsulta"
        Me.grdConsulta.ReadOnly = True
        Me.grdConsulta.Size = New System.Drawing.Size(600, 376)
        Me.grdConsulta.TabIndex = 1
        Me.grdConsulta.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.EstiloCheques, Me.EstiloTarjetaCredito, Me.EstiloFichaDeposito})
        '
        'EstiloCheques
        '
        Me.EstiloCheques.DataGrid = Me.grdConsulta
        Me.EstiloCheques.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colNumeroCheque, Me.colNumeroCuenta, Me.colBancoNombre, Me.colCliente, Me.colClienteNombre, Me.colFCheque, Me.colTotal, Me.colSaldo, Me.colObservaciones})
        Me.EstiloCheques.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloCheques.MappingName = "Cheques"
        Me.EstiloCheques.ReadOnly = True
        '
        'colNumeroCheque
        '
        Me.colNumeroCheque.Format = ""
        Me.colNumeroCheque.FormatInfo = Nothing
        Me.colNumeroCheque.HeaderText = "Cheque"
        Me.colNumeroCheque.MappingName = "NumeroCheque"
        Me.colNumeroCheque.Width = 75
        '
        'colNumeroCuenta
        '
        Me.colNumeroCuenta.Format = ""
        Me.colNumeroCuenta.FormatInfo = Nothing
        Me.colNumeroCuenta.HeaderText = "No.Cuenta"
        Me.colNumeroCuenta.MappingName = "NumeroCuenta"
        Me.colNumeroCuenta.Width = 75
        '
        'colBancoNombre
        '
        Me.colBancoNombre.Format = ""
        Me.colBancoNombre.FormatInfo = Nothing
        Me.colBancoNombre.HeaderText = "Banco"
        Me.colBancoNombre.MappingName = "BancoNombre"
        Me.colBancoNombre.Width = 95
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 60
        '
        'colClienteNombre
        '
        Me.colClienteNombre.Format = ""
        Me.colClienteNombre.FormatInfo = Nothing
        Me.colClienteNombre.HeaderText = "Nombre"
        Me.colClienteNombre.MappingName = "ClienteNombre"
        Me.colClienteNombre.Width = 250
        '
        'colFCheque
        '
        Me.colFCheque.Format = ""
        Me.colFCheque.FormatInfo = Nothing
        Me.colFCheque.HeaderText = "Fecha"
        Me.colFCheque.MappingName = "FCheque"
        Me.colFCheque.Width = 75
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Importe"
        Me.colTotal.MappingName = "Total"
        Me.colTotal.Width = 75
        '
        'colSaldo
        '
        Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Format = "#,##.00"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.Width = 75
        '
        'colObservaciones
        '
        Me.colObservaciones.Format = ""
        Me.colObservaciones.FormatInfo = Nothing
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.MappingName = "Observaciones"
        Me.colObservaciones.Width = 250
        '
        'EstiloTarjetaCredito
        '
        Me.EstiloTarjetaCredito.DataGrid = Me.grdConsulta
        Me.EstiloTarjetaCredito.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colTCTarjetaCredito, Me.colTCBancoNombre, Me.colTCCliente, Me.colTCClienteNombre, Me.colTCTotal, Me.colTCObservaciones})
        Me.EstiloTarjetaCredito.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloTarjetaCredito.MappingName = "TarjetaCredito"
        Me.EstiloTarjetaCredito.ReadOnly = True
        '
        'colTCTarjetaCredito
        '
        Me.colTCTarjetaCredito.Format = ""
        Me.colTCTarjetaCredito.FormatInfo = Nothing
        Me.colTCTarjetaCredito.HeaderText = "No. Tarjeta"
        Me.colTCTarjetaCredito.MappingName = "TarjetaCredito"
        Me.colTCTarjetaCredito.Width = 150
        '
        'colTCBancoNombre
        '
        Me.colTCBancoNombre.Format = ""
        Me.colTCBancoNombre.FormatInfo = Nothing
        Me.colTCBancoNombre.HeaderText = "Banco"
        Me.colTCBancoNombre.MappingName = "BancoNombre"
        Me.colTCBancoNombre.Width = 95
        '
        'colTCCliente
        '
        Me.colTCCliente.Format = ""
        Me.colTCCliente.FormatInfo = Nothing
        Me.colTCCliente.HeaderText = "Cliente"
        Me.colTCCliente.MappingName = "Cliente"
        Me.colTCCliente.Width = 75
        '
        'colTCClienteNombre
        '
        Me.colTCClienteNombre.Format = ""
        Me.colTCClienteNombre.FormatInfo = Nothing
        Me.colTCClienteNombre.HeaderText = "Nombre"
        Me.colTCClienteNombre.MappingName = "ClienteNombre"
        Me.colTCClienteNombre.Width = 150
        '
        'colTCTotal
        '
        Me.colTCTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTCTotal.Format = "#,##.00"
        Me.colTCTotal.FormatInfo = Nothing
        Me.colTCTotal.HeaderText = "Importe"
        Me.colTCTotal.MappingName = "Total"
        Me.colTCTotal.Width = 75
        '
        'colTCObservaciones
        '
        Me.colTCObservaciones.Format = ""
        Me.colTCObservaciones.FormatInfo = Nothing
        Me.colTCObservaciones.HeaderText = "Observaciones"
        Me.colTCObservaciones.MappingName = "Observaciones"
        Me.colTCObservaciones.NullText = ""
        Me.colTCObservaciones.Width = 250
        '
        'EstiloFichaDeposito
        '
        Me.EstiloFichaDeposito.DataGrid = Me.grdConsulta
        Me.EstiloFichaDeposito.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colFDTipoCobro, Me.colFDFDocumento, Me.colFDNumeroCuenta, Me.colFDBancoNombre, Me.colFDTotal, Me.colFDSaldo, Me.colFDCliente, Me.colFDClienteNombre, Me.colFDObservaciones})
        Me.EstiloFichaDeposito.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.EstiloFichaDeposito.MappingName = "FichaDeposito"
        Me.EstiloFichaDeposito.ReadOnly = True
        '
        'colFDTipoCobro
        '
        Me.colFDTipoCobro.Format = ""
        Me.colFDTipoCobro.FormatInfo = Nothing
        Me.colFDTipoCobro.HeaderText = "Tipo de cobro"
        Me.colFDTipoCobro.MappingName = "TipoCobroDescripcion"
        Me.colFDTipoCobro.Width = 130
        '
        'colFDFDocumento
        '
        Me.colFDFDocumento.Format = ""
        Me.colFDFDocumento.FormatInfo = Nothing
        Me.colFDFDocumento.HeaderText = "F.Documento"
        Me.colFDFDocumento.MappingName = "FCheque"
        Me.colFDFDocumento.Width = 75
        '
        'colFDNumeroCuenta
        '
        Me.colFDNumeroCuenta.Format = ""
        Me.colFDNumeroCuenta.FormatInfo = Nothing
        Me.colFDNumeroCuenta.HeaderText = "No. Cuenta"
        Me.colFDNumeroCuenta.MappingName = "NumeroCuenta"
        Me.colFDNumeroCuenta.Width = 75
        '
        'colFDBancoNombre
        '
        Me.colFDBancoNombre.Format = ""
        Me.colFDBancoNombre.FormatInfo = Nothing
        Me.colFDBancoNombre.HeaderText = "Banco"
        Me.colFDBancoNombre.MappingName = "BancoNombre"
        Me.colFDBancoNombre.Width = 75
        '
        'colFDTotal
        '
        Me.colFDTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colFDTotal.Format = "#,##.00"
        Me.colFDTotal.FormatInfo = Nothing
        Me.colFDTotal.HeaderText = "Total"
        Me.colFDTotal.MappingName = "Total"
        Me.colFDTotal.Width = 75
        '
        'colFDSaldo
        '
        Me.colFDSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colFDSaldo.Format = "#,##.00"
        Me.colFDSaldo.FormatInfo = Nothing
        Me.colFDSaldo.HeaderText = "Saldo"
        Me.colFDSaldo.MappingName = "Saldo"
        Me.colFDSaldo.Width = 75
        '
        'colFDCliente
        '
        Me.colFDCliente.Format = ""
        Me.colFDCliente.FormatInfo = Nothing
        Me.colFDCliente.HeaderText = "Cliente"
        Me.colFDCliente.MappingName = "Cliente"
        Me.colFDCliente.Width = 75
        '
        'colFDClienteNombre
        '
        Me.colFDClienteNombre.Format = ""
        Me.colFDClienteNombre.FormatInfo = Nothing
        Me.colFDClienteNombre.HeaderText = "Nombre"
        Me.colFDClienteNombre.MappingName = "ClienteNombre"
        Me.colFDClienteNombre.Width = 150
        '
        'colFDObservaciones
        '
        Me.colFDObservaciones.Format = ""
        Me.colFDObservaciones.FormatInfo = Nothing
        Me.colFDObservaciones.HeaderText = "Observaciones"
        Me.colFDObservaciones.MappingName = "Observaciones"
        Me.colFDObservaciones.Width = 200
        '
        'mnuConsulta
        '
        Me.mnuConsulta.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.miConsultaCliente})
        '
        'miConsultaCliente
        '
        Me.miConsultaCliente.Index = 0
        Me.miConsultaCliente.Text = "Consulta cliente"
        '
        'btnConsultaCliente
        '
        Me.btnConsultaCliente.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnConsultaCliente.Image = CType(resources.GetObject("btnConsultaCliente.Image"), System.Drawing.Bitmap)
        Me.btnConsultaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaCliente.Location = New System.Drawing.Point(624, 8)
        Me.btnConsultaCliente.Name = "btnConsultaCliente"
        Me.btnConsultaCliente.Size = New System.Drawing.Size(80, 24)
        Me.btnConsultaCliente.TabIndex = 9
        Me.btnConsultaCliente.Text = "Ver cliente"
        Me.btnConsultaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(624, 40)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 24)
        Me.btnCerrar.TabIndex = 8
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmChequeTarjetaMovCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(712, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConsultaCliente, Me.btnCerrar, Me.grdConsulta})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmChequeTarjetaMovCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de documentos de cobro"
        CType(Me.grdConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnConsultaCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click
        If Not IsDBNull(grdConsulta.Item(grdConsulta.CurrentRowIndex, ColumnaCliente)) Then
            Dim iCliente As Integer = CType(grdConsulta.Item(grdConsulta.CurrentRowIndex, ColumnaCliente), Integer)
            Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(iCliente)
            frmConCliente.ShowDialog()
        End If
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub grdConsulta_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdConsulta.CurrentCellChanged
        grdConsulta.Select(grdConsulta.CurrentRowIndex)
    End Sub
End Class
