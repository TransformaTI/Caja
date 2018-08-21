Imports System.Data.SqlClient

Public Class frmConsultaOperador
    Inherits System.Windows.Forms.Form
    Private _Cliente As Integer

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
    Friend WithEvents grdOperador As System.Windows.Forms.DataGrid
    Friend WithEvents tbrBarra As System.Windows.Forms.ToolBar
    Friend WithEvents Sep1 As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbCerrar As System.Windows.Forms.ToolBarButton
    Friend WithEvents imgLista As System.Windows.Forms.ImageList
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colEmpleado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colNombre As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colCliente As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoOperador As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatus As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents tbbConsultar As System.Windows.Forms.ToolBarButton
    Friend WithEvents tbbRefrescar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep2 As System.Windows.Forms.ToolBarButton
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents tbbCapturar As System.Windows.Forms.ToolBarButton
    Friend WithEvents Sep3 As System.Windows.Forms.ToolBarButton
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaOperador))
        Me.grdOperador = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colEmpleado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colNombre = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCliente = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoOperador = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatus = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.tbrBarra = New System.Windows.Forms.ToolBar()
        Me.tbbConsultar = New System.Windows.Forms.ToolBarButton()
        Me.Sep3 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCapturar = New System.Windows.Forms.ToolBarButton()
        Me.Sep2 = New System.Windows.Forms.ToolBarButton()
        Me.tbbRefrescar = New System.Windows.Forms.ToolBarButton()
        Me.Sep1 = New System.Windows.Forms.ToolBarButton()
        Me.tbbCerrar = New System.Windows.Forms.ToolBarButton()
        Me.imgLista = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.btnCerrar = New System.Windows.Forms.Button()
        CType(Me.grdOperador, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdOperador
        '
        Me.grdOperador.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.grdOperador.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdOperador.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdOperador.CaptionText = "Lista de operadores"
        Me.grdOperador.DataMember = ""
        Me.grdOperador.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdOperador.Location = New System.Drawing.Point(6, 48)
        Me.grdOperador.Name = "grdOperador"
        Me.grdOperador.ReadOnly = True
        Me.grdOperador.Size = New System.Drawing.Size(676, 352)
        Me.grdOperador.TabIndex = 0
        Me.grdOperador.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdOperador
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colCelula, Me.colEmpleado, Me.colNombre, Me.colCliente, Me.colTipoOperador, Me.colStatus})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Operador"
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "Celula"
        Me.colCelula.Width = 75
        '
        'colEmpleado
        '
        Me.colEmpleado.Format = ""
        Me.colEmpleado.FormatInfo = Nothing
        Me.colEmpleado.HeaderText = "No.Empleado"
        Me.colEmpleado.MappingName = "Empleado"
        Me.colEmpleado.Width = 75
        '
        'colNombre
        '
        Me.colNombre.Format = ""
        Me.colNombre.FormatInfo = Nothing
        Me.colNombre.HeaderText = "Nombre"
        Me.colNombre.MappingName = "Nombre"
        Me.colNombre.Width = 220
        '
        'colCliente
        '
        Me.colCliente.Format = ""
        Me.colCliente.FormatInfo = Nothing
        Me.colCliente.HeaderText = "Cliente"
        Me.colCliente.MappingName = "Cliente"
        Me.colCliente.Width = 75
        '
        'colTipoOperador
        '
        Me.colTipoOperador.Format = ""
        Me.colTipoOperador.FormatInfo = Nothing
        Me.colTipoOperador.HeaderText = "Tipo operador"
        Me.colTipoOperador.MappingName = "Descripcion"
        Me.colTipoOperador.Width = 75
        '
        'colStatus
        '
        Me.colStatus.Format = ""
        Me.colStatus.FormatInfo = Nothing
        Me.colStatus.HeaderText = "Estatus"
        Me.colStatus.MappingName = "Status"
        Me.colStatus.Width = 75
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbbConsultar, Me.Sep3, Me.tbbCapturar, Me.Sep2, Me.tbbRefrescar, Me.Sep1, Me.tbbCerrar})
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(53, 35)
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.ImageList = Me.imgLista
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(688, 38)
        Me.tbrBarra.TabIndex = 2
        Me.tbrBarra.Wrappable = False
        '
        'tbbConsultar
        '
        Me.tbbConsultar.ImageIndex = 2
        Me.tbbConsultar.Tag = "Consultar"
        Me.tbbConsultar.Text = "Consultar"
        Me.tbbConsultar.ToolTipText = "Consulta los documentos relacionados con este operador"
        '
        'Sep3
        '
        Me.Sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCapturar
        '
        Me.tbbCapturar.ImageIndex = 3
        Me.tbbCapturar.Tag = "Capturar"
        Me.tbbCapturar.Text = "Ca&pturar"
        Me.tbbCapturar.ToolTipText = "Capturar cobranza relacionada con este operador"
        '
        'Sep2
        '
        Me.Sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbRefrescar
        '
        Me.tbbRefrescar.ImageIndex = 1
        Me.tbbRefrescar.Tag = "Refrescar"
        Me.tbbRefrescar.Text = "Refrescar"
        Me.tbbRefrescar.ToolTipText = "Refrescar la información"
        '
        'Sep1
        '
        Me.Sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'tbbCerrar
        '
        Me.tbbCerrar.ImageIndex = 0
        Me.tbbCerrar.Tag = "Cerrar"
        Me.tbbCerrar.Text = "&Cerrar"
        Me.tbbCerrar.ToolTipText = "Cierra esta ventana"
        '
        'imgLista
        '
        Me.imgLista.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgLista.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgLista.ImageStream = CType(resources.GetObject("imgLista.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.imgLista.TransparentColor = System.Drawing.Color.Transparent
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 415)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(688, 22)
        Me.StatusBar1.TabIndex = 4
        Me.StatusBar1.Text = "Seleccione en la lista el operador que desee consultar.  Dé clic en el botón 'Con" & _
        "sultar' para desplegar más información."
        '
        'btnCerrar
        '
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Location = New System.Drawing.Point(592, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(0, 0)
        Me.btnCerrar.TabIndex = 5
        '
        'frmConsultaOperador
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(688, 437)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCerrar, Me.StatusBar1, Me.tbrBarra, Me.grdOperador})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaOperador"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de operadores"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdOperador, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmConsultaOperador_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaLista()
    End Sub

    Private Sub CargaLista()
        _Cliente = 0
        Cursor = Cursors.WaitCursor()
        Dim objOp As New SigaMetClasses.cOperador()
        Try
            Dim dtOperador As DataTable = objOp.Consulta
            grdOperador.DataSource = dtOperador
            grdOperador.CaptionText = "Lista de operadores (" & dtOperador.Rows.Count.ToString & ")"
        Catch ex As Exception
            grdOperador.CaptionText = "No se pudo cargar la lista de operadores."
        Finally
            objOp = Nothing
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Consulta()
        Dim lParametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim lURLGateway As String = CType(lParametro.Parametros.Item("URLGateway"), String)
        lParametro.Dispose()

        If _Cliente <> 0 Then
            Cursor = Cursors.WaitCursor
            Dim frmConsultaDoc As SigaMetClasses.frmConsultaCliente
			If String.IsNullOrEmpty(lURLGateway) Then
				frmConsultaDoc = New SigaMetClasses.frmConsultaCliente(_Cliente, PermiteCapturarNotas:=False)
			Else
                frmConsultaDoc = New SigaMetClasses.frmConsultaCliente(_Cliente,
                                                                       URLGateway:=lURLGateway,
                                                                       PermiteCapturarNotas:=False,
                                                                       CadenaCon:=ConString,
                                                                       Modulo:=GLOBAL_Modulo)
            End If
			frmConsultaDoc.Modulo = 3
			frmConsultaDoc.ShowDialog()
                Cursor = Cursors.Default
            End If
    End Sub

    Private Sub CapturaCobranza()
        If _Cliente <> 0 Then
            Cursor = Cursors.WaitCursor
            ClienteCapturaCobranza = _Cliente
            Dim frmCapCob As New frmCapCobranza(frmCapCobranza.enumTipoCaptura.Eficiencia, 15)
            frmCapCob.ClienteEficienciasNegativas = _Cliente
            frmCapCob.ShowDialog()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Consultar"
                Consulta()
            Case Is = "Capturar"
                CapturaCobranza()
            Case Is = "Refrescar"
                CargaLista()
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub

    Private Sub grdOperador_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOperador.CurrentCellChanged
        grdOperador.Select(grdOperador.CurrentRowIndex)
        Try
            _Cliente = CType(grdOperador.Item(grdOperador.CurrentRowIndex, 3), Integer)
        Catch ex As Exception
            _Cliente = 0
        End Try
    End Sub

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class