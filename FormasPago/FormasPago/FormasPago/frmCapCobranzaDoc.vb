Option Strict On
Option Explicit On 
Imports System.Data.SqlClient
Public Class frmCapCobranzaDoc
    Inherits System.Windows.Forms.Form
    Private Titulo As String = "Captura de cobranza"
    Public ListaCobroPedido As New ArrayList()
    Private _Cliente As Integer


#Region "Variables y propiedades"
    Dim decImporteTotalCobranza As Decimal
    Dim aListaPedidos As New ArrayList()
    Dim ListaCobro As New ArrayList() 'Lista de los diferentes cobros (efectivo, vale o cheque)
    Dim objPedido As SigaMetClasses.sPedido
    Private _TipoCobro As SigaMetClasses.Enumeradores.enumTipoCobro
    Private _ImporteCobro As Decimal 'Indica el importe total del cobro (e,v o ch.)
    Private _ImporteRestante As Decimal 'Indica cuanto hace falta por aplicar del documento (efectivo, vale o cheque)

    Public Property TipoCobro() As SigaMetClasses.Enumeradores.enumTipoCobro
        Get
            Return _TipoCobro
        End Get
        Set(ByVal Value As SigaMetClasses.Enumeradores.enumTipoCobro)
            _TipoCobro = Value
        End Set
    End Property

    Public Property ImporteCobro() As Decimal
        Get
            Return _ImporteCobro
        End Get
        Set(ByVal Value As Decimal)
            _ImporteCobro = Value
            _ImporteRestante = Value
        End Set
    End Property

    Public ReadOnly Property ImporteRestante() As Decimal
        Get
            Return _ImporteRestante
        End Get
    End Property

    Private _CadenaConexion As String
    Public Property CadenaConexion() As String
        Get
            Return _CadenaConexion
        End Get
        Set(ByVal value As String)
            _CadenaConexion = value
            ConString = value
        End Set
    End Property

#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    'Public Sub New(ByVal intConsecutivo As Integer)
    '    MyBase.New()
    '    InitializeComponent()
    '    Consecutivo = intConsecutivo
    'End Sub

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
    Friend WithEvents ttDatosPedido As System.Windows.Forms.ToolTip
    Friend WithEvents cmListaPedidos As System.Windows.Forms.ContextMenu
    Friend WithEvents mnuEliminar As System.Windows.Forms.MenuItem
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents txtPedidoReferencia As ControlesBase.TextBoxBase
    Friend WithEvents lstDocumento As System.Windows.Forms.ListBox
    Friend WithEvents lblImporteTotalCobranza As System.Windows.Forms.Label
    Friend WithEvents lblImportePorAplicar As System.Windows.Forms.Label
    Friend WithEvents lblTotalCobro As System.Windows.Forms.Label
    Friend WithEvents lblTipoCobro As System.Windows.Forms.Label
    Friend WithEvents Label5 As ControlesBase.LabelBase
    Friend WithEvents Label3 As ControlesBase.LabelBase
    Friend WithEvents Label4 As ControlesBase.LabelBase
    Friend WithEvents Label6 As ControlesBase.LabelBase
    Friend WithEvents grpDatosCobro As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As ControlesBase.LabelBase
    Friend WithEvents Label1 As ControlesBase.LabelBase
    Friend WithEvents Label7 As ControlesBase.LabelBase
    Friend WithEvents lblPedidoReferenciaImporte As System.Windows.Forms.Label
    Friend WithEvents txtImporteAbono As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnBuscarCliente As System.Windows.Forms.Button
    Friend WithEvents txtCliente As SigaMetClasses.Controles.txtNumeroEntero
    Friend WithEvents LabelBase1 As ControlesBase.LabelBase
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapCobranzaDoc))
        Me.txtPedidoReferencia = New ControlesBase.TextBoxBase()
        Me.lstDocumento = New System.Windows.Forms.ListBox()
        Me.cmListaPedidos = New System.Windows.Forms.ContextMenu()
        Me.mnuEliminar = New System.Windows.Forms.MenuItem()
        Me.lblImporteTotalCobranza = New System.Windows.Forms.Label()
        Me.ttDatosPedido = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label5 = New ControlesBase.LabelBase()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.Label3 = New ControlesBase.LabelBase()
        Me.Label4 = New ControlesBase.LabelBase()
        Me.Label6 = New ControlesBase.LabelBase()
        Me.lblImportePorAplicar = New System.Windows.Forms.Label()
        Me.grpDatosCobro = New System.Windows.Forms.GroupBox()
        Me.Label2 = New ControlesBase.LabelBase()
        Me.Label1 = New ControlesBase.LabelBase()
        Me.lblTotalCobro = New System.Windows.Forms.Label()
        Me.lblTipoCobro = New System.Windows.Forms.Label()
        Me.Label7 = New ControlesBase.LabelBase()
        Me.lblPedidoReferenciaImporte = New System.Windows.Forms.Label()
        Me.txtImporteAbono = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnBuscarCliente = New System.Windows.Forms.Button()
        Me.txtCliente = New SigaMetClasses.Controles.txtNumeroEntero()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.grpDatosCobro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtPedidoReferencia
        '
        Me.txtPedidoReferencia.Location = New System.Drawing.Point(80, 144)
        Me.txtPedidoReferencia.Name = "txtPedidoReferencia"
        Me.txtPedidoReferencia.Size = New System.Drawing.Size(112, 21)
        Me.txtPedidoReferencia.TabIndex = 0
        Me.txtPedidoReferencia.Text = ""
        '
        'lstDocumento
        '
        Me.lstDocumento.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lstDocumento.ContextMenu = Me.cmListaPedidos
        Me.lstDocumento.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstDocumento.ItemHeight = 14
        Me.lstDocumento.Location = New System.Drawing.Point(8, 264)
        Me.lstDocumento.Name = "lstDocumento"
        Me.lstDocumento.Size = New System.Drawing.Size(472, 158)
        Me.lstDocumento.TabIndex = 2
        '
        'cmListaPedidos
        '
        Me.cmListaPedidos.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuEliminar})
        '
        'mnuEliminar
        '
        Me.mnuEliminar.Index = 0
        Me.mnuEliminar.Text = "Eliminar pedido"
        '
        'lblImporteTotalCobranza
        '
        Me.lblImporteTotalCobranza.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblImporteTotalCobranza.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.lblImporteTotalCobranza.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteTotalCobranza.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteTotalCobranza.Location = New System.Drawing.Point(336, 432)
        Me.lblImporteTotalCobranza.Name = "lblImporteTotalCobranza"
        Me.lblImporteTotalCobranza.Size = New System.Drawing.Size(144, 24)
        Me.lblImporteTotalCobranza.TabIndex = 32
        Me.lblImporteTotalCobranza.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(176, 437)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(150, 14)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Importe total en pedidos:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(498, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(498, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 147)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 14)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Documento:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(336, 147)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 14)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Abono:"
        '
        'Label6
        '
        Me.Label6.Anchor = (System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left)
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(176, 469)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 14)
        Me.Label6.TabIndex = 40
        Me.Label6.Text = "Por aplicar:"
        '
        'lblImportePorAplicar
        '
        Me.lblImportePorAplicar.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.lblImportePorAplicar.BackColor = System.Drawing.Color.Khaki
        Me.lblImportePorAplicar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImportePorAplicar.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImportePorAplicar.ForeColor = System.Drawing.Color.Red
        Me.lblImportePorAplicar.Location = New System.Drawing.Point(336, 464)
        Me.lblImportePorAplicar.Name = "lblImportePorAplicar"
        Me.lblImportePorAplicar.Size = New System.Drawing.Size(144, 24)
        Me.lblImportePorAplicar.TabIndex = 39
        Me.lblImportePorAplicar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'grpDatosCobro
        '
        Me.grpDatosCobro.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.lblTotalCobro, Me.lblTipoCobro})
        Me.grpDatosCobro.Location = New System.Drawing.Point(8, 8)
        Me.grpDatosCobro.Name = "grpDatosCobro"
        Me.grpDatosCobro.Size = New System.Drawing.Size(472, 72)
        Me.grpDatosCobro.TabIndex = 41
        Me.grpDatosCobro.TabStop = False
        Me.grpDatosCobro.Text = "Datos del cobro por aplicar"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(304, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 14)
        Me.Label2.TabIndex = 48
        Me.Label2.Text = "Total:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 14)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "Tipo de cobro:"
        '
        'lblTotalCobro
        '
        Me.lblTotalCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTotalCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalCobro.Location = New System.Drawing.Point(352, 32)
        Me.lblTotalCobro.Name = "lblTotalCobro"
        Me.lblTotalCobro.Size = New System.Drawing.Size(112, 21)
        Me.lblTotalCobro.TabIndex = 46
        Me.lblTotalCobro.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipoCobro
        '
        Me.lblTipoCobro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTipoCobro.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoCobro.Location = New System.Drawing.Point(96, 32)
        Me.lblTipoCobro.Name = "lblTipoCobro"
        Me.lblTipoCobro.Size = New System.Drawing.Size(112, 21)
        Me.lblTipoCobro.TabIndex = 45
        Me.lblTipoCobro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(200, 147)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(33, 14)
        Me.Label7.TabIndex = 43
        Me.Label7.Text = "Total:"
        '
        'lblPedidoReferenciaImporte
        '
        Me.lblPedidoReferenciaImporte.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPedidoReferenciaImporte.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPedidoReferenciaImporte.Location = New System.Drawing.Point(248, 144)
        Me.lblPedidoReferenciaImporte.Name = "lblPedidoReferenciaImporte"
        Me.lblPedidoReferenciaImporte.Size = New System.Drawing.Size(80, 21)
        Me.lblPedidoReferenciaImporte.TabIndex = 49
        Me.lblPedidoReferenciaImporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtImporteAbono
        '
        Me.txtImporteAbono.BackColor = System.Drawing.SystemColors.Window
        Me.txtImporteAbono.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtImporteAbono.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtImporteAbono.Location = New System.Drawing.Point(376, 144)
        Me.txtImporteAbono.Name = "txtImporteAbono"
        Me.txtImporteAbono.Size = New System.Drawing.Size(104, 21)
        Me.txtImporteAbono.TabIndex = 50
        Me.txtImporteAbono.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label8})
        Me.GroupBox1.Location = New System.Drawing.Point(8, 192)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(472, 56)
        Me.GroupBox1.TabIndex = 51
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(8, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(424, 32)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Lista de documentos agregados a la cobranza.  Dé doble clic en los registros de l" & _
        "a lista para desplegar más información acerca de los documentos."
        '
        'btnBuscarCliente
        '
        Me.btnBuscarCliente.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscarCliente.Image = CType(resources.GetObject("btnBuscarCliente.Image"), System.Drawing.Bitmap)
        Me.btnBuscarCliente.Location = New System.Drawing.Point(408, 16)
        Me.btnBuscarCliente.Name = "btnBuscarCliente"
        Me.btnBuscarCliente.Size = New System.Drawing.Size(48, 21)
        Me.btnBuscarCliente.TabIndex = 53
        '
        'txtCliente
        '
        Me.txtCliente.BackColor = System.Drawing.Color.Black
        Me.txtCliente.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCliente.ForeColor = System.Drawing.Color.Gold
        Me.txtCliente.Location = New System.Drawing.Point(288, 16)
        Me.txtCliente.Name = "txtCliente"
        Me.txtCliente.Size = New System.Drawing.Size(112, 21)
        Me.txtCliente.TabIndex = 54
        Me.txtCliente.Text = ""
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.ForeColor = System.Drawing.Color.Blue
        Me.LabelBase1.Location = New System.Drawing.Point(40, 19)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(242, 14)
        Me.LabelBase1.TabIndex = 55
        Me.LabelBase1.Text = "Desplegar los documentos del siguiente cliente:"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.LabelBase1, Me.txtCliente, Me.btnBuscarCliente})
        Me.GroupBox2.Location = New System.Drawing.Point(8, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(472, 48)
        Me.GroupBox2.TabIndex = 56
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Búsqueda avanzada de documentos (F3)"
        '
        'frmCapCobranzaDoc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(586, 503)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.txtImporteAbono, Me.Label7, Me.grpDatosCobro, Me.Label6, Me.lblImportePorAplicar, Me.Label4, Me.btnCancelar, Me.btnAceptar, Me.Label5, Me.lblImporteTotalCobranza, Me.lstDocumento, Me.txtPedidoReferencia, Me.lblPedidoReferenciaImporte, Me.Label3, Me.GroupBox1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCapCobranzaDoc"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura relación de cobranza"
        Me.grpDatosCobro.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Funciones"
    Private Function ConsultaPedido(ByVal PedidoReferencia As String) As Boolean
        'Modificado el 3 de febrero del 2003
        'Para no tener dependencia en la vista de los cargos, porque se usa en los reportes
        'y puede ser muy cambiable.
        Dim strQuery As String = _
        "SELECT p.Celula, p.AñoPed, p.Pedido, p.Total, p.Saldo, p.Cliente, c.Nombre, p.PedidoReferencia, p.CyC " & _
        "FROM Pedido p " & _
        "JOIN Cliente c ON p.Cliente = c.Cliente " & _
        "WHERE p.TipoCargo = 4 " & _
        "AND p.PedidoReferencia = '" & PedidoReferencia & "'"


        If AmarraClienteCapturaCobranza = True Then
            strQuery &= " AND p.Cliente = " & _Cliente.ToString
        End If
        Dim cn As New SqlConnection(ConString)
        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If
        Dim cmd As New SqlCommand(strQuery)
        cmd.Connection = cn
        Dim dr As SqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

        Try
            LimpiaPedido()
            Do While dr.Read
                objPedido.Celula = CType(dr("Celula"), Byte)
                objPedido.AnoPed = CType(dr("AñoPed"), Short)
                objPedido.Pedido = CType(dr("Pedido"), Integer)
                objPedido.Importe = CType(dr("Total"), Decimal)
                objPedido.ImporteAbono = 0
                objPedido.Cliente = CType(dr("Cliente"), Integer)
                objPedido.Nombre = Trim(CType(dr("Nombre"), String))
                objPedido.PedidoReferencia = Trim(CType(dr("PedidoReferencia"), String))
            Loop
            If objPedido.PedidoReferencia <> "" Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            Return False
            MessageBox.Show(ex.Message)
        Finally
            dr.Close()
            cn.Close()
        End Try
    End Function

    Private Sub LimpiaPedido()
        With objPedido
            .Celula = 0
            .AnoPed = 0
            .Pedido = 0
            .Importe = 0
            .ImporteAbono = 0
            .Cliente = 0
            .Nombre = ""
            .PedidoReferencia = ""
        End With
    End Sub

    Private Function BuscaPedido(ByVal PedidoReferencia As String) As Integer
        'Funcion que busca en el ArrayList el pedido a ver si ya se capturo
        'Devuelve -1 si no encontro nada, de lo contrario devuelve el indice en donde
        'se encuentra el pedido.
        Dim a As Integer = 0
        For a = 0 To aListaPedidos.Count - 1
            If CType(aListaPedidos(a), String) = PedidoReferencia Then
                'El pedido ya se capturó
                Return a
                Exit Function
            End If
        Next
        Return -1
    End Function

    Private Sub LimpiaCaptura()
        txtPedidoReferencia.Text = ""
        lblPedidoReferenciaImporte.Text = ""
        txtImporteAbono.Text = ""
        txtPedidoReferencia.Focus()
    End Sub

    Private Sub AgregaPedido()
        'Metodo para agregar el pedido especificado en el ListBox
        decImporteTotalCobranza += objPedido.ImporteAbono
        lblImporteTotalCobranza.Text = decImporteTotalCobranza.ToString("C")

        'Verifico que la suma de los importes de los pedidos no sobrepase el importe
        'del cobro al que estan relacionados.
        _ImporteRestante -= objPedido.ImporteAbono
        lblImportePorAplicar.Text = _ImporteRestante.ToString("C")

        'Agrego el objeto al ListBox
        lstDocumento.Items.Add(objPedido)
        'Agrego la referencia unicamente al ArrayList
        aListaPedidos.Add(CType(objPedido.PedidoReferencia, String))
    End Sub

#End Region

#Region "Menu contextual"
    Private Sub mnuEliminar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuEliminar.Click
        If lstDocumento.SelectedIndex <> -1 Then
            Dim decImporteEliminado As Decimal = CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).ImporteAbono
            Dim i As Integer = BuscaPedido(CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).PedidoReferencia)
            lstDocumento.Items.RemoveAt(lstDocumento.SelectedIndex)
            aListaPedidos.RemoveAt(i)
            decImporteTotalCobranza -= decImporteEliminado
            _ImporteRestante += decImporteEliminado
            lblImporteTotalCobranza.Text = decImporteTotalCobranza.ToString("C")
            lblImportePorAplicar.Text = ImporteRestante.ToString("C")
            txtPedidoReferencia.Focus()
        End If
    End Sub

    Private Sub cmListaPedidos_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmListaPedidos.Popup
        If lstDocumento.Items.Count <= 0 Then
            mnuEliminar.Enabled = False
        Else
            If lstDocumento.SelectedIndex <> -1 Then
                mnuEliminar.Enabled = True
            Else
                mnuEliminar.Enabled = False
            End If
        End If
    End Sub
#End Region

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If lstDocumento.Items.Count > 0 Then
            If _ImporteRestante <= 0 Then
                If MessageBox.Show(M_ESTAN_CORRECTOS, Titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim s As SigaMetClasses.sPedido
                    For Each s In lstDocumento.Items
                        ListaCobroPedido.Add(s)
                    Next
                    'If TipoCobro = enumTipoCobro.Efectivo Or TipoCobro = enumTipoCobro.Vales Then CapturaEfectivoVales = True
                    'Cambiado el 09 de octubre del 2002
                    'Bloqueamos el boton para que no se captura dos veces EfectivoVales
                    If TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then CapturaEfectivoVales = True
                    If TipoCobro = SigaMetClasses.Enumeradores.enumTipoCobro.EfectivoVales Then CapturaMixtaEfectivoVales = True
                    DialogResult = DialogResult.OK
                End If
            Else
                MessageBox.Show("Falta por relacionar " & _ImporteRestante.ToString("C"), Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        Else
            MessageBox.Show("No se han capturado documentos en la cobranza.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        objPedido = Nothing
        Me.Close()
    End Sub


    Private Sub txtPedidoReferencia_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPedidoReferencia.KeyDown
        If e.KeyCode = Keys.Enter Then
            Dim i As Integer = BuscaPedido(UCase(Trim(txtPedidoReferencia.Text)))
            If i = -1 Then
                If ConsultaPedido(UCase(Trim(txtPedidoReferencia.Text))) = True Then
                    lblPedidoReferenciaImporte.Text = objPedido.Importe.ToString("N")
                    If ImporteRestante > objPedido.Importe Then
                        txtImporteAbono.Text = objPedido.Importe.ToString("N")
                    Else
                        txtImporteAbono.Text = ImporteRestante.ToString("N")
                    End If
                    txtImporteAbono.Focus()
                Else
                    MessageBox.Show("El documento no existe en la base de datos.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            Else
                MessageBox.Show("El pedido ya se capturó.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                lstDocumento.SelectedIndex = i
            End If
        End If
    End Sub

    Private Sub frmCapRelacionCobranza_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lstDocumento.DisplayMember = "InformacionCompleta"
        lstDocumento.ValueMember = "Pedido"

        lblTipoCobro.Text = TipoCobro.ToString
        lblTotalCobro.Text = ImporteCobro.ToString("C")
        lblImportePorAplicar.Text = ImporteRestante.ToString("C")

        '27 de diciembre del 2002
        _Cliente = ClienteCapturaCobranza
        txtCliente.Text = _Cliente.ToString
        txtCliente.Enabled = False

    End Sub

    Private Sub lstDocumento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstDocumento.SelectedIndexChanged
        'Armo el tooltip segun el registro seleccionado
        If lstDocumento.SelectedIndex <> -1 Then
            Dim strTip As String
            strTip = "Documento: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).PedidoReferencia & Chr(13) & _
                     "Cliente: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).Cliente.ToString & Chr(13) & _
                     "Nombre: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).Nombre & Chr(13) & _
                     "Importe del documento: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).Importe.ToString("N") & Chr(13) & _
                     "Importe del abono: " & CType(lstDocumento.Items(lstDocumento.SelectedIndex), SigaMetClasses.sPedido).ImporteAbono.ToString("N")
            ttDatosPedido.SetToolTip(lstDocumento, strTip)
        End If
    End Sub

    Private Sub txtImporteAbono_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtImporteAbono.KeyDown
        If e.KeyCode = Keys.Enter Then
            If txtImporteAbono.Text <> "" Then
                If IsNumeric(txtImporteAbono.Text) Then
                    If CDec(txtImporteAbono.Text) > 0 Then
                        If decImporteTotalCobranza + CDec(txtImporteAbono.Text) <= ImporteCobro Then
                            If CDec(txtImporteAbono.Text) <= objPedido.Importe Then
                                If CDec(txtImporteAbono.Text) <= ImporteCobro Then
                                    objPedido.ImporteAbono = CType(txtImporteAbono.Text, Decimal)
                                    AgregaPedido()
                                    LimpiaCaptura()
                                Else
                                    MessageBox.Show("El importe del abono no puede sobrepasar el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                                End If
                            Else
                                MessageBox.Show("El importe del abono no puede sobrepasar el saldo del documento.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            End If
                        Else
                            MessageBox.Show("El importe de los abonos no puede sobrepasar el importe del cobro.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        End If
                    Else
                        MessageBox.Show("El importe del abono debe ser mayor que cero.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    End If
                End If
            Else
                MessageBox.Show("Debe teclear el importe del abono.", Titulo, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub

    Private Sub ConsultaDocumentosCliente()
        If txtCliente.Text.Trim <> "" Then
            Dim frmConCliente As New SigaMetClasses.frmConsultaCliente(CType(txtCliente.Text, Integer), _
                      PermiteSeleccionarDocumento:=True)
            If frmConCliente.ShowDialog() = DialogResult.OK Then
                txtPedidoReferencia.Text = frmConCliente.PedidoReferenciaSeleccionado
                txtPedidoReferencia.Focus()
            End If
        End If
    End Sub

    Private Sub btnBuscarCliente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarCliente.Click
        ConsultaDocumentosCliente()
    End Sub

    Private Sub txtCliente_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCliente.KeyPress
        If e.KeyChar = Chr(13) Then
            ConsultaDocumentosCliente()
        End If
    End Sub

    Private Sub frmCapCobranzaDoc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F3 Then
            txtCliente.Focus()
        End If
    End Sub

    Private Sub txtCliente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCliente.TextChanged

    End Sub
End Class