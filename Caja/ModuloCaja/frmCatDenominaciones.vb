Imports System.Data.SqlClient

Public Class frmCatDenominaciones
    Inherits Catalogo.frmCatalogo
    Private Titulo As String = "Catálogo de Denominaciones"

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
    Friend WithEvents Estilo1 As System.Windows.Forms.DataGridTableStyle
    Friend WithEvents colDenominacion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colTipoCobroDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colDescripcion As System.Windows.Forms.DataGridTextBoxColumn
    Friend WithEvents colValor As System.Windows.Forms.DataGridTextBoxColumn
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Estilo1 = New System.Windows.Forms.DataGridTableStyle()
        Me.colDenominacion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colTipoCobroDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colDescripcion = New System.Windows.Forms.DataGridTextBoxColumn()
        Me.colValor = New System.Windows.Forms.DataGridTextBoxColumn()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraBotones
        '
        Me.BarraBotones.Size = New System.Drawing.Size(608, 38)
        Me.BarraBotones.Visible = True
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.CaptionText = "Denominaciones"
        Me.grdDatos.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.Estilo1})
        Me.grdDatos.Visible = True
        '
        'Estilo1
        '
        Me.Estilo1.DataGrid = Me.grdDatos
        Me.Estilo1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.colDenominacion, Me.colTipoCobroDescripcion, Me.colDescripcion, Me.colValor})
        Me.Estilo1.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.Estilo1.MappingName = "Denominacion"
        Me.Estilo1.ReadOnly = True
        '
        'colDenominacion
        '
        Me.colDenominacion.Format = ""
        Me.colDenominacion.FormatInfo = Nothing
        Me.colDenominacion.HeaderText = "Denominación"
        Me.colDenominacion.MappingName = "Denominacion"
        Me.colDenominacion.Width = 75
        '
        'colTipoCobroDescripcion
        '
        Me.colTipoCobroDescripcion.Format = ""
        Me.colTipoCobroDescripcion.FormatInfo = Nothing
        Me.colTipoCobroDescripcion.HeaderText = "Tipo cobro"
        Me.colTipoCobroDescripcion.MappingName = "TipoCobroDescripcion"
        Me.colTipoCobroDescripcion.Width = 150
        '
        'colDescripcion
        '
        Me.colDescripcion.Format = ""
        Me.colDescripcion.FormatInfo = Nothing
        Me.colDescripcion.HeaderText = "Descripción"
        Me.colDescripcion.MappingName = "Descripcion"
        Me.colDescripcion.Width = 150
        '
        'colValor
        '
        Me.colValor.Alignment = System.Windows.Forms.HorizontalAlignment.Right
        Me.colValor.Format = "#,##.00"
        Me.colValor.FormatInfo = Nothing
        Me.colValor.HeaderText = "Valor"
        Me.colValor.MappingName = "Valor"
        Me.colValor.Width = 75
        '
        'frmCatDenominaciones
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(608, 413)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.BarraBotones, Me.grdDatos})
        Me.Name = "frmCatDenominaciones"
        Me.Text = "Catálogo de denominaciones"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub CargaGrid()
        Try
            Dim da As New SqlDataAdapter("SELECT * FROM vwDenominacion", ConString)
            Dim dtDenom As New DataTable()
            dtDenom.TableName = "Denominacion"
            da.Fill(dtDenom)
            grdDatos.DataSource = dtDenom
        Catch ex As Exception
            MessageBox.Show(ex.Message, Titulo, MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Private Sub frmCatDenominaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaGrid()
        PermiteAgregar = False
        PermiteModificar = False
        PermiteEliminar = False
        PermiteConsultar = False
    End Sub

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        grdDatos.Select(grdDatos.CurrentRowIndex)
    End Sub

    Public Overrides Sub BarraBotones_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        Select Case e.Button.Tag.ToString()
            Case Is = "Refrescar"
                CargaGrid()
            Case Is = "Cerrar"
                Me.Close()
        End Select
    End Sub
End Class
