Imports System.Data.SqlClient

Public Class frmConsultaDocumentosMovCaja
    Inherits System.Windows.Forms.Form
    Private _Clave As String

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
    Friend WithEvents grdDocumento As System.Windows.Forms.DataGrid
    Friend WithEvents btnCerrar As ControlesBase.BotonBase
    Friend WithEvents sty1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colDocumento As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colStatusCobranza As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colSaldo As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmConsultaDocumentosMovCaja))
        Me.grdDocumento = New System.Windows.Forms.DataGrid()
        Me.btnCerrar = New ControlesBase.BotonBase()
        Me.sty1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colDocumento = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colStatusCobranza = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colSaldo = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grdDocumento
        '
        Me.grdDocumento.DataMember = ""
        Me.grdDocumento.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdDocumento.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdDocumento.Location = New System.Drawing.Point(8, 8)
        Me.grdDocumento.Name = "grdDocumento"
        Me.grdDocumento.ReadOnly = True
        Me.grdDocumento.Size = New System.Drawing.Size(296, 304)
        Me.grdDocumento.TabIndex = 1
        Me.grdDocumento.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.sty1})
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(328, 8)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 24)
        Me.btnCerrar.TabIndex = 0
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'sty1
        '
        Me.sty1.AlternatingBackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.sty1.DataGrid = Me.grdDocumento
        Me.sty1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colDocumento, Me.colStatusCobranza, Me.colSaldo})
        Me.sty1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.sty1.MappingName = "Documentos"
        Me.sty1.ReadOnly = True
        Me.sty1.RowHeadersVisible = False
        '
        'colDocumento
        '
        Me.colDocumento.Format = ""
        Me.colDocumento.FormatInfo = Nothing
        Me.colDocumento.HeaderText = "Documento"
        Me.colDocumento.MappingName = "PedidoReferencia"
        Me.colDocumento.Width = 120
        '
        'colStatusCobranza
        '
        Me.colStatusCobranza.Format = ""
        Me.colStatusCobranza.FormatInfo = Nothing
        Me.colStatusCobranza.HeaderText = "E.Cobranza"
        Me.colStatusCobranza.MappingName = "StatusCobranza"
        Me.colStatusCobranza.Width = 65
        '
        'colSaldo
        '
        Me.colSaldo.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colSaldo.Format = "#,##.00"
        Me.colSaldo.FormatInfo = Nothing
        Me.colSaldo.HeaderText = "Saldo"
        Me.colSaldo.MappingName = "Saldo"
        Me.colSaldo.Width = 40
        '
        'frmConsultaDocumentosMovCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(416, 325)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCerrar, Me.grdDocumento})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmConsultaDocumentosMovCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Documentos del movimiento"
        CType(Me.grdDocumento, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub New(ByVal Clave As String)
        MyBase.New()
        InitializeComponent()

        _Clave = Clave

        Dim cmd As SqlCommand, cn As SqlConnection, da As SqlDataAdapter, dt As DataTable
        da = Nothing
        'cn = New SqlConnection(Main.ConString)
        cn = GLOBAL_Connection

        If cn.State = ConnectionState.Closed Then
            cn.Open()
        End If

        cmd = New SqlCommand("spCAConsultaDocumentosMovCaja")
        With cmd
            .CommandType = CommandType.StoredProcedure
            .Parameters.Add("@Clave", SqlDbType.VarChar, 20).Value = _Clave
            .Connection = cn
        End With

        Try
            da = New SqlDataAdapter(cmd)
            dt = New DataTable("Documentos")
            da.Fill(dt)

            If dt.Rows.Count > 0 Then
                Me.grdDocumento.DataSource = dt
                Me.grdDocumento.CaptionText = "Documentos que se pueden sellar en el movimiento " & _Clave
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            da.Dispose()
            cmd.Dispose()

            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If

        End Try


    End Sub


    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub
End Class
