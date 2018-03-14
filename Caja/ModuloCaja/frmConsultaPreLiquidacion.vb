Imports System.Data.SqlClient
Imports System.Collections.Generic

Public Class frmConsultaPreLiquidacion
    Inherits System.Windows.Forms.Form

    Private Titulo As String = "Consulta de pre-liquidaciones"
    Private _AnoAtt As Short
    Private _Folio As Integer
    Private _Observaciones As String
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbCelula As System.Windows.Forms.ComboBox
    Private dsPreLiq As DataSet

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents grdPreLiq As System.Windows.Forms.DataGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colFolio As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFTerminoRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colRutaDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colImporteCredito As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colImporteContado As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAnoAtt As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents DataGrid1 As System.Windows.Forms.DataGrid
    Friend WithEvents colCelula As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colAutotanque As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colObservaciones As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colFInicioRuta As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents lnkConsultar As System.Windows.Forms.LinkLabel
    Friend WithEvents chkTodas As System.Windows.Forms.CheckBox
    Friend WithEvents LabelNombreEmpresa1 As NombreEmpresa.LabelNombreEmpresa
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaPreLiquidacion))
        Me.grdPreLiq = New System.Windows.Forms.DataGrid()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colAnoAtt = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFolio = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colAutotanque = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colCelula = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colRutaDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFInicioRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colFTerminoRuta = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colImporteCredito = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colImporteContado = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colObservaciones = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.DataGrid1 = New System.Windows.Forms.DataGrid()
        Me.lnkConsultar = New System.Windows.Forms.LinkLabel()
        Me.chkTodas = New System.Windows.Forms.CheckBox()
        Me.LabelNombreEmpresa1 = New NombreEmpresa.LabelNombreEmpresa()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbCelula = New System.Windows.Forms.ComboBox()
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdPreLiq
        '
        Me.grdPreLiq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdPreLiq.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdPreLiq.CaptionText = "Pre-liquidaciones efectuadas en las células"
        Me.grdPreLiq.DataMember = ""
        Me.grdPreLiq.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdPreLiq.Location = New System.Drawing.Point(8, 72)
        Me.grdPreLiq.Name = "grdPreLiq"
        Me.grdPreLiq.ReadOnly = True
        Me.grdPreLiq.Size = New System.Drawing.Size(648, 368)
        Me.grdPreLiq.TabIndex = 0
        Me.grdPreLiq.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdPreLiq
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colAnoAtt, Me.colFolio, Me.colAutotanque, Me.colCelula, Me.colRutaDescripcion, Me.colFInicioRuta, Me.colFTerminoRuta, Me.colImporteCredito, Me.colImporteContado, Me.colObservaciones})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "PreLiq"
        '
        'colAnoAtt
        '
        Me.colAnoAtt.Format = ""
        Me.colAnoAtt.FormatInfo = Nothing
        Me.colAnoAtt.MappingName = "AñoAtt"
        Me.colAnoAtt.Width = 0
        '
        'colFolio
        '
        Me.colFolio.Format = ""
        Me.colFolio.FormatInfo = Nothing
        Me.colFolio.HeaderText = "Folio"
        Me.colFolio.MappingName = "Folio"
        Me.colFolio.Width = 60
        '
        'colAutotanque
        '
        Me.colAutotanque.Format = ""
        Me.colAutotanque.FormatInfo = Nothing
        Me.colAutotanque.HeaderText = "A.T."
        Me.colAutotanque.MappingName = "Autotanque"
        Me.colAutotanque.Width = 50
        '
        'colCelula
        '
        Me.colCelula.Format = ""
        Me.colCelula.FormatInfo = Nothing
        Me.colCelula.HeaderText = "Célula"
        Me.colCelula.MappingName = "Celula"
        Me.colCelula.Width = 50
        '
        'colRutaDescripcion
        '
        Me.colRutaDescripcion.Format = ""
        Me.colRutaDescripcion.FormatInfo = Nothing
        Me.colRutaDescripcion.HeaderText = "Ruta"
        Me.colRutaDescripcion.MappingName = "RutaDescripcion"
        Me.colRutaDescripcion.Width = 140
        '
        'colFInicioRuta
        '
        Me.colFInicioRuta.Format = "dd/MM/yyyy hh:mm:ss"
        Me.colFInicioRuta.FormatInfo = Nothing
        Me.colFInicioRuta.HeaderText = "F.Inicio ruta"
        Me.colFInicioRuta.MappingName = "FInicioRuta"
        Me.colFInicioRuta.Width = 130
        '
        'colFTerminoRuta
        '
        Me.colFTerminoRuta.Format = "dd/MM/yyyy hh:mm:ss"
        Me.colFTerminoRuta.FormatInfo = Nothing
        Me.colFTerminoRuta.HeaderText = "F.Término ruta"
        Me.colFTerminoRuta.MappingName = "FTerminoRuta"
        Me.colFTerminoRuta.Width = 130
        '
        'colImporteCredito
        '
        Me.colImporteCredito.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteCredito.Format = "#,##.00"
        Me.colImporteCredito.FormatInfo = Nothing
        Me.colImporteCredito.HeaderText = "Importe de crédito"
        Me.colImporteCredito.MappingName = "ImporteCredito"
        Me.colImporteCredito.Width = 110
        '
        'colImporteContado
        '
        Me.colImporteContado.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colImporteContado.Format = "#,##.00"
        Me.colImporteContado.FormatInfo = Nothing
        Me.colImporteContado.HeaderText = "Importe de contado"
        Me.colImporteContado.MappingName = "ImporteContado"
        Me.colImporteContado.Width = 110
        '
        'colObservaciones
        '
        Me.colObservaciones.Format = ""
        Me.colObservaciones.FormatInfo = Nothing
        Me.colObservaciones.HeaderText = "Observaciones"
        Me.colObservaciones.MappingName = "Observaciones"
        Me.colObservaciones.NullText = ""
        Me.colObservaciones.Width = 150
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Enabled = False
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(503, 11)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(584, 12)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 6
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(70, 12)
        Me.dtpFecha.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFecha.MinDate = New Date(2000, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(112, 21)
        Me.dtpFecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Del día:"
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(381, 13)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "&Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'DataGrid1
        '
        Me.DataGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGrid1.CaptionText = "Debug"
        Me.DataGrid1.DataMember = ""
        Me.DataGrid1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DataGrid1.Location = New System.Drawing.Point(8, 336)
        Me.DataGrid1.Name = "DataGrid1"
        Me.DataGrid1.Size = New System.Drawing.Size(648, 104)
        Me.DataGrid1.TabIndex = 6
        Me.DataGrid1.Visible = False
        '
        'lnkConsultar
        '
        Me.lnkConsultar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lnkConsultar.AutoSize = True
        Me.lnkConsultar.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.lnkConsultar.DisabledLinkColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.lnkConsultar.Enabled = False
        Me.lnkConsultar.LinkColor = System.Drawing.Color.Yellow
        Me.lnkConsultar.Location = New System.Drawing.Point(576, 72)
        Me.lnkConsultar.Name = "lnkConsultar"
        Me.lnkConsultar.Size = New System.Drawing.Size(76, 13)
        Me.lnkConsultar.TabIndex = 8
        Me.lnkConsultar.TabStop = True
        Me.lnkConsultar.Text = "Consultar folio"
        '
        'chkTodas
        '
        Me.chkTodas.Location = New System.Drawing.Point(19, 42)
        Me.chkTodas.Name = "chkTodas"
        Me.chkTodas.Size = New System.Drawing.Size(336, 21)
        Me.chkTodas.TabIndex = 3
        Me.chkTodas.Text = "Consultar todas las pre-liquidaciones pendientes"
        '
        'LabelNombreEmpresa1
        '
        Me.LabelNombreEmpresa1.AutoSize = True
        Me.LabelNombreEmpresa1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelNombreEmpresa1.Location = New System.Drawing.Point(432, 43)
        Me.LabelNombreEmpresa1.Name = "LabelNombreEmpresa1"
        Me.LabelNombreEmpresa1.Size = New System.Drawing.Size(0, 16)
        Me.LabelNombreEmpresa1.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(188, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Celula: "
        '
        'cmbCelula
        '
        Me.cmbCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCelula.FormattingEnabled = True
        Me.cmbCelula.Location = New System.Drawing.Point(242, 14)
        Me.cmbCelula.Name = "cmbCelula"
        Me.cmbCelula.Size = New System.Drawing.Size(121, 21)
        Me.cmbCelula.TabIndex = 2
        '
        'frmConsultaPreLiquidacion
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(664, 445)
        Me.Controls.Add(Me.cmbCelula)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.LabelNombreEmpresa1)
        Me.Controls.Add(Me.chkTodas)
        Me.Controls.Add(Me.lnkConsultar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grdPreLiq)
        Me.Controls.Add(Me.DataGrid1)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaPreLiquidacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de pre-liquidación en células"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdPreLiq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmConsultaPreLiquidacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpFecha.MaxDate = Now.Date
        dtpFecha.Value = Now.Date

        LabelNombreEmpresa1.CargarNombreEmpresa()
        Dim todasCelulas As Boolean
        Dim m_metodos As New MetodoDatos
        todasCelulas = m_metodos.ValidarParametroCelulasUsuario()

        Dim celulas As New List(Of Celula)

        If (todasCelulas) Then
            celulas = m_metodos.ConsultaCelulasPorUsusario()
        Else
            celulas = m_metodos.ConsultaTodasLasCelulas()
        End If

        cmbCelula.DataSource = celulas
        cmbCelula.DisplayMember = "DescripcionCelula"
        cmbCelula.ValueMember = "IdCelula"

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        CargaGrid()
    End Sub

    Private Sub CargaGrid()
        _AnoAtt = 0 : _Folio = 0
        btnAceptar.Enabled = False
        lnkConsultar.Enabled = False
        Cursor = Cursors.WaitCursor

        'Modificado el 24 de enero del 2003
        'Modificado el 13 de junio del 2003:  La vista ya filtra solo los LIQUIDADOS
        'Modificado el 27 de junio del 2003:  Ahora se permite consultar todas las preliquidaciones
        'Dim strQuery As String = "SET transaction isolation level read uncommitted SELECT * FROM vwConsultaPreLiqAutotanque t1 " & _
        '                         "LEFT JOIN vwFolioDescuadrado t2 on t1.AñoAtt = t2.AñoAtt and t1.Folio = t2.Folio "
        'If chkTodas.Checked = False Then
        '    strQuery &= "WHERE t1.FTerminoRuta BETWEEN '" & dtpFecha.Value.ToShortDateString & "'" & _
        '                                     " AND '" & dtpFecha.Value.ToShortDateString & " 23:59:59'"
        'End If
        'strQuery &= " ORDER BY t1.Folio "

        ' '' '' '' '' '' ''Dim strQuery As String = "EXECUTE spCAConsultaPreLiqAutoTanque"
        ' '' '' '' '' '' ''If chkTodas.Checked = False Then
        ' '' '' '' '' '' ''    strQuery &= " 0," & Chr(39) & dtpFecha.Value.ToShortDateString & Chr(39) & cmbCelula.SelectedValue.ToString() & Chr(39) & GLOBAL_IDUsuario
        ' '' '' '' '' '' ''Else
        ' '' '' '' '' '' ''    strQuery &= " 1" & Chr(39) & "NULL" & Chr(39) & cmbCelula.SelectedValue.ToString() & Chr(39) & GLOBAL_IDUsuario
        ' '' '' '' '' '' ''End If

        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spCAConsultaPreLiqAutoTanque"
            cmd.Connection = GLOBAL_Connection
            cmd.Parameters.Add("@TodasPreliq", SqlDbType.Bit).Value = chkTodas.Checked
            cmd.Parameters.Add("@Fecha", SqlDbType.Date).Value = IIf(dtpFecha.Enabled = True, dtpFecha.Value.ToShortDateString, DBNull.Value)
            cmd.Parameters.Add("@Celula", SqlDbType.SmallInt).Value = cmbCelula.SelectedValue
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = GLOBAL_IDUsuario

            'Dim da As New SqlDataAdapter(strQuery, ConString)
            Dim da As New SqlDataAdapter(cmd)

            da.SelectCommand.CommandTimeout = GLOBAL_TiempoEspera
            Dim dtPreLiq As New DataTable("PreLiq")
            da.Fill(dtPreLiq)
            grdPreLiq.DataSource = dtPreLiq
            grdPreLiq.CaptionText = "Pre-liquidaciones efectuadas en las células pendientes por liquidar (" & dtPreLiq.Rows.Count.ToString & " en total)"

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub CargaPreLiquidacion()
        'Ultima modificación: 12/01/2004 JAGD
        'Las consultas a vistas para los datos de liquidación se incluyeron en procedimientos almacenados
        Cursor = Cursors.WaitCursor
        'COBROPEDIDO
        'Dim strQuery As String = "set transaction isolation level read uncommitted " & _
        '                        "SELECT * FROM vwConsultaPreLiqPedido " & _
        '                         "WHERE AñoAtt = " & _
        '                         "AND Folio = " & _Folio.ToString & _
        '                         " AND PedidoTipoCobro Not In (6,8,9)"
        Dim strQuery As String = "EXECUTE spCAConsultaCobroPedidoLiquidacion " & _AnoAtt.ToString & ", " & _Folio.ToString
        dsPreLiq = New DataSet()
        Dim cmd As New SqlCommand() ', cn As New SqlConnection()
        Try
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandText = strQuery
            'cn.ConnectionString = ConString
            cmd.Connection = GLOBAL_Connection

            Dim da As New SqlDataAdapter(cmd)
            da.Fill(dsPreLiq, "CobroPedido")

            'CARGOS
            'strQuery = "set transaction isolation level read uncommitted SELECT DISTINCT AñoCobro, Cobro FROM vwConsultaPreLiqPedido WHERE AñoAtt = " & _AnoAtt & _
            '           " AND Folio = " & _Folio
            strQuery = "EXECUTE spCAConsultaCobroLiquidacion " & _AnoAtt.ToString & ", " & _Folio.ToString
            cmd.CommandText = strQuery
            da.Fill(dsPreLiq, "Cobro")

            'strQuery = "set transaction isolation level read uncommitted SELECT * From vwConsultaPreLiqAutotanque where AñoAtt = " & _AnoAtt & _
            '           " AND Folio = " & _Folio
            strQuery = "EXECUTE spCAConsultaPreliquidacionAutotanqueLiquidacion " & _AnoAtt.ToString & ", " & _Folio.ToString
            cmd.CommandText = strQuery
            da.Fill(dsPreLiq, "InfoPreLiq")

            'CHEQUES
            'Desactivado por que ocasiona la presencia de cobros no pertenecientes a la liquidación
            'strQuery = "set transaction isolation level read uncommitted SELECT * from vwConsultaCobro " & _
            '           "WHERE cobro in " & _
            '           "(SELECT distinct cobro from vwconsultapreliqpedido where folio in " & _
            '           "(SELECT folio from vwConsultaPreLiqPedido where AñoAtt = " & _AnoAtt & _
            '           " AND Folio = " & _Folio & ") And PedidoTipoCobro = 5) AND AñoCobro = " & _AnoAtt & " AND TipoCobro = 3"
            strQuery = "EXECUTE spCAConsultaChequesLiquidacion " & _AnoAtt.ToString & ", " & _Folio.ToString
            cmd.CommandText = strQuery
            da.Fill(dsPreLiq, "Cheques")

            'EFECTIVO Y VALES
            'Desactivado porque ocasiona la presencia de cobros que no pertenecen a la liquidacion
            'strQuery = "set transaction isolation level read uncommitted SELECT * from vwConsultaCobro " & _
            '           "WHERE cobro in " & _
            '           "(SELECT distinct cobro from vwconsultapreliqpedido where folio in " & _
            '           "(SELECT folio from vwConsultaPreLiqPedido where AñoAtt = " & _AnoAtt & _
            '           " AND Folio = " & _Folio & ") AND PedidoTipoCobro = 5 AND AñoAtt = " & _AnoAtt & ") AND AñoCobro = " & _AnoAtt & " AND TipoCobro = 5"
            strQuery = "EXECUTE spCAConsultaEfectivoValesLiquidacion " & _AnoAtt.ToString & ", " & _Folio.ToString
            cmd.CommandText = strQuery
            da.Fill(dsPreLiq, "EfectivoVales")

            'TARJETAS DE CREDITO
            'Desactivado porque ocasiona la presencia de cobros que no pertenecen a la liquidacion
            'strQuery = "set transaction isolation level read uncommitted SELECT * from vwConsultaCobro " & _
            '           "WHERE cobro in " & _
            '           "(SELECT distinct cobro from vwconsultapreliqpedido where folio in " & _
            '           "(SELECT folio from vwConsultaPreLiqPedido where AñoAtt = " & _AnoAtt & _
            '           " AND Folio = " & _Folio & ") And PedidoTipoCobro = 5) AND AñoCobro = " & _AnoAtt & " AND TipoCobro = 6"
            strQuery = "EXECUTE spCAConsultaTarjetasCreditoLiquidacion " & _AnoAtt.ToString & ", " & _Folio.ToString
            cmd.CommandText = strQuery
            da.Fill(dsPreLiq, "TarjetaCredito")

            'Notas de crédito y fichas de depósito
            'Desactivado temporalmente
            'strQuery = "set transaction isolation level read uncommitted SELECT * from vwConsultaCobro " & _
            '           "WHERE cobro in " & _
            '           "(SELECT distinct cobro from vwconsultapreliqpedido where folio in " & _
            '           "(SELECT folio from vwConsultaPreLiqPedido where AñoAtt = " & _AnoAtt & _
            '           " AND Folio = " & _Folio & ") And PedidoTipoCobro = 5) AND AñoCobro = " & _AnoAtt & " AND (TipoCobro = 7 or TipoCobro = 12)"
            strQuery = "EXECUTE spCAConsultaFichasDepositoNotasDeCreditoLiquidacion " & _AnoAtt.ToString & ", " & _Folio.ToString
            cmd.CommandText = strQuery
            da.Fill(dsPreLiq, "FichaDeposito")

            'Pedidos de obsequio y autocarburación
            strQuery = "EXECUTE spCAConsultaDesgloseObsequios " & _AnoAtt.ToString & ", " & _Folio.ToString
            cmd.CommandText = strQuery
            da.Fill(dsPreLiq, "Obsequios")

        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            Cursor = Cursors.Default
            'Se anexó el cierre de la conexión
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

    End Sub

    Private Sub grdPreLiq_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdPreLiq.CurrentCellChanged
        grdPreLiq.Select(grdPreLiq.CurrentRowIndex)
        _AnoAtt = CType(grdPreLiq.Item(grdPreLiq.CurrentRowIndex, 0), Short)
        _Folio = CType(grdPreLiq.Item(grdPreLiq.CurrentRowIndex, 1), Integer)
        If Not IsDBNull(grdPreLiq.Item(grdPreLiq.CurrentRowIndex, 8)) Then
            _Observaciones = CType(grdPreLiq.Item(grdPreLiq.CurrentRowIndex, 8), String)
        Else
            _Observaciones = ""
        End If

        If (_AnoAtt <> 0 And _Folio <> 0) Then
            If _Observaciones <> "DESCUADRADO" Then
                btnAceptar.Enabled = True
            Else
                btnAceptar.Enabled = False
            End If
            lnkConsultar.Enabled = True
        Else
            btnAceptar.Enabled = False
            lnkConsultar.Enabled = False
        End If
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _AnoAtt <> 0 And _Folio <> 0 Then
            CargaPreLiquidacion()
            'DataGrid1.DataSource = dsPreLiq
            Dim frmMov As New frmCapMovimiento(dsPreLiq)
            If frmMov.ShowDialog() = DialogResult.OK Then
                CargaGrid()
            End If
        End If
    End Sub

    Private Sub lnkConsultar_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) _
    Handles lnkConsultar.LinkClicked
        If _AnoAtt <> 0 And _Folio <> 0 Then
            Dim oConsultaATT As New SigaMetClasses.ConsultaATT(_AnoAtt, _Folio)
            oConsultaATT.ShowDialog()
        End If
    End Sub

    Private Sub chkTodas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTodas.CheckedChanged
        dtpFecha.Enabled = Not chkTodas.Checked
    End Sub

    
    Private Sub grdPreLiq_Navigate(sender As System.Object, ne As System.Windows.Forms.NavigateEventArgs) Handles grdPreLiq.Navigate

    End Sub
End Class