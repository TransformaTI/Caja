Public Class frmConsultaCobranza
    Inherits System.Windows.Forms.Form

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
    Public WithEvents grdCobroPedido As System.Windows.Forms.DataGrid
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents btnCerrar As ControlesBase.BotonBase
    Friend WithEvents colPedidoReferencia As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents Documentos As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ImporteTotal As System.Windows.Forms.StatusBarPanel
    Public WithEvents stbEstatus As System.Windows.Forms.StatusBar
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTotal As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCobro As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents btnConsultaCliente As ControlesBase.BotonBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaCobranza))
        Me.grdCobroPedido = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colTipoCobro = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colPedidoReferencia = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTotal = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnCerrar = New ControlesBase.BotonBase()
        Me.stbEstatus = New System.Windows.Forms.StatusBar()
        Me.Documentos = New System.Windows.Forms.StatusBarPanel()
        Me.ImporteTotal = New System.Windows.Forms.StatusBarPanel()
        Me.btnConsultaCliente = New ControlesBase.BotonBase()
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Documentos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ImporteTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdCobroPedido
        '
        Me.grdCobroPedido.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdCobroPedido.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdCobroPedido.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdCobroPedido.CaptionText = "Lista de documentos incluidos en la cobranza"
        Me.grdCobroPedido.DataMember = ""
        Me.grdCobroPedido.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdCobroPedido.Location = New System.Drawing.Point(16, 8)
        Me.grdCobroPedido.Name = "grdCobroPedido"
        Me.grdCobroPedido.ReadOnly = True
        Me.grdCobroPedido.Size = New System.Drawing.Size(664, 368)
        Me.grdCobroPedido.TabIndex = 0
        Me.grdCobroPedido.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.BackColor = System.Drawing.Color.LemonChiffon
        Me.Estilo1.DataGrid = Me.grdCobroPedido
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colTipoCobro, Me.colPedidoReferencia, Me.colCliente, Me.colNombre, Me.colTotal})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Cobro"
        Me.Estilo1.ReadOnly = True
        '
        'colTipoCobro
        '
        Me.colTipoCobro.Format = ""
        Me.colTipoCobro.FormatInfo = Nothing
        Me.colTipoCobro.HeaderText = "Tipo de cobro"
        Me.colTipoCobro.MappingName = "TipoCobroDescripcion"
        Me.colTipoCobro.Width = 110
        '
        'colPedidoReferencia
        '
        Me.colPedidoReferencia.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.colPedidoReferencia.Format = ""
        Me.colPedidoReferencia.FormatInfo = Nothing
        Me.colPedidoReferencia.HeaderText = "Pedido"
        Me.colPedidoReferencia.MappingName = "PedidoReferencia"
        Me.colPedidoReferencia.Width = 75
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre del cliente"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 240
        '
        'colTotal
        '
        Me.colTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colTotal.Format = "#,##.00"
        Me.colTotal.FormatInfo = Nothing
        Me.colTotal.HeaderText = "Total abonado"
        Me.colTotal.MappingName = "CobroPedidoTotal"
        Me.colTotal.Width = 90
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(688, 40)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(88, 24)
        Me.btnCerrar.TabIndex = 5
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'stbEstatus
        '
        Me.stbEstatus.Location = New System.Drawing.Point(0, 391)
        Me.stbEstatus.Name = "stbEstatus"
        Me.stbEstatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Documentos, Me.ImporteTotal})
        Me.stbEstatus.ShowPanels = True
        Me.stbEstatus.Size = New System.Drawing.Size(784, 22)
        Me.stbEstatus.TabIndex = 6
        Me.stbEstatus.Text = "stbEstatus"
        '
        'Documentos
        '
        Me.Documentos.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.Documentos.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.Documentos.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised
        Me.Documentos.Width = 384
        '
        'ImporteTotal
        '
        Me.ImporteTotal.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.ImporteTotal.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.ImporteTotal.BorderStyle = System.Windows.Forms.StatusBarPanelBorderStyle.Raised
        Me.ImporteTotal.Width = 384
        '
        'btnConsultaCliente
        '
        Me.btnConsultaCliente.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnConsultaCliente.Image = CType(resources.GetObject("btnConsultaCliente.Image"), System.Drawing.Bitmap)
        Me.btnConsultaCliente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultaCliente.Location = New System.Drawing.Point(688, 8)
        Me.btnConsultaCliente.Name = "btnConsultaCliente"
        Me.btnConsultaCliente.Size = New System.Drawing.Size(88, 24)
        Me.btnConsultaCliente.TabIndex = 7
        Me.btnConsultaCliente.Text = "Consultar"
        Me.btnConsultaCliente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmConsultaCobranza
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(784, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnConsultaCliente, Me.stbEstatus, Me.btnCerrar, Me.grdCobroPedido})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmConsultaCobranza"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de cobranza"
        CType(Me.grdCobroPedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Documentos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ImporteTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub btnConsultaCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnConsultaCliente.Click
        Dim Cliente As Integer

        If Not IsDBNull(grdCobroPedido.Item(grdCobroPedido.CurrentRowIndex, 2)) Then
            Cliente = CType(grdCobroPedido.Item(grdCobroPedido.CurrentRowIndex, 2), Integer)
        End If
        If Cliente > 0 Then
            Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(Cliente, Nuevo:=0)
            frmConCliente.ShowDialog()
        End If

    End Sub

    Private Sub grdCobroPedido_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCobroPedido.CurrentCellChanged
        grdCobroPedido.Select(grdCobroPedido.CurrentRowIndex)
    End Sub
End Class