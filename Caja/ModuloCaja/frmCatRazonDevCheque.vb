Imports System.Data.SqlClient
Imports CatalogoBase.frmCatalogo.enumTipoAccion

Public Class frmCatRazonDevCheque
    Inherits CatalogoBase.frmCatalogo
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
    Friend WithEvents txtRazon As ControlesBase.TextBoxBase
    Friend WithEvents txtDescripcion As ControlesBase.TextBoxBase
    Friend WithEvents lblRazon As ControlesBase.LabelBase
    Friend WithEvents lblDescripcion As ControlesBase.LabelBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtRazon = New ControlesBase.TextBoxBase()
        Me.txtDescripcion = New ControlesBase.TextBoxBase()
        Me.lblRazon = New ControlesBase.LabelBase()
        Me.lblDescripcion = New ControlesBase.LabelBase()
        Me.tabDatos.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDatos
        '
        Me.tabDatos.ItemSize = New System.Drawing.Size(48, 18)
        Me.tabDatos.Visible = True
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.Visible = True
        '
        'tbrBarra
        '
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(54, 36)
        Me.tbrBarra.Visible = True
        '
        'tbDatos
        '
        Me.tbDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblDescripcion, Me.lblRazon, Me.txtDescripcion, Me.txtRazon})
        '
        'txtRazon
        '
        Me.txtRazon.Enabled = False
        Me.txtRazon.Location = New System.Drawing.Point(104, 8)
        Me.txtRazon.Name = "txtRazon"
        Me.txtRazon.Size = New System.Drawing.Size(48, 21)
        Me.txtRazon.TabIndex = 0
        Me.txtRazon.Text = ""
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(104, 32)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(304, 21)
        Me.txtDescripcion.TabIndex = 1
        Me.txtDescripcion.Text = ""
        '
        'lblRazon
        '
        Me.lblRazon.AutoSize = True
        Me.lblRazon.Location = New System.Drawing.Point(24, 11)
        Me.lblRazon.Name = "lblRazon"
        Me.lblRazon.Size = New System.Drawing.Size(39, 14)
        Me.lblRazon.TabIndex = 2
        Me.lblRazon.Text = "Razón:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(24, 35)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(65, 14)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "Descripción:"
        '
        'frmCatRazonDevCheque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(568, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabDatos, Me.grdDatos, Me.tbrBarra})
        Me.Name = "frmCatRazonDevCheque"
        Me.ShowInTaskbar = False
        Me.Text = "Catálogo de razones de cheques devueltos"
        Me.tabDatos.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCatRazonDevCheque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaLista()
        AplicaFormato()
    End Sub

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ListaDatos.Count > grdDatos.CurrentRowIndex Then
            MyBase.grdDatos_CurrentCellChanged(sender, e)
            Dim strDescripcion As String = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String)
            Dim o As New SigaMetClasses.cRazonDevCheque()
            o.RazonDevCheque = CType(Me.ID, String)
            o.Descripcion = strDescripcion
            Try
                Dim i As Integer = ListaDatos.IndexOf(o)
                Me.IndiceID = i
                txtRazon.Text = ID
                txtDescripcion.Text = strDescripcion
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Private Overloads Sub AplicaFormato()
        Me.NombreTabla = "RazonDevCheque"
        MyBase.AplicaFormato("Razones de devolución de cheques")

        Dim Col1 As New DataGridTextBoxColumn()
        With Col1
            .HeaderText = "Razón"
            .MappingName = "RazonDevCheque"
            .Width = 50
        End With

        Dim Col2 As New DataGridTextBoxColumn()
        With Col2
            .HeaderText = "Descripción"
            .MappingName = "Descripcion"
            .Width = 350
        End With
        grdTableStyle1.GridColumnStyles.AddRange(New DataGridColumnStyle() {Col1, Col2})
        grddatos.TableStyles.Add(grdTableStyle1)
    End Sub

    Private Sub CargaLista()
        grdDatos.DataSource = Nothing
        Dim oRazon As New SigaMetClasses.cRazonDevCheque()
        Dim dt As New DataTable()
        dt = oRazon.Consulta()
        dt.TableName = "RazonDevCheque"
        grddatos.DataSource = dt
        Dim dr As SqlDataReader = oRazon.ConsultaDR
        oRazon = Nothing

        Do While dr.Read
            Dim r As New SigaMetClasses.cRazonDevCheque()
            r.RazonDevCheque = CType(dr("RazonDevCheque"), String)
            r.Descripcion = CType(dr("Descripcion"), String)
            Me.ListaDatos.Add(r)
        Loop
        dr.Close()
    End Sub

    Public Overrides Sub tbrBarra_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        MyBase.tbrBarra_ButtonClick(sender, e)
        Select Case TipoAccion
            Case Agregar
                Dim frmCapRazon As New frmCapRazonDevCheque()
                frmCapRazon.TipoAccion = Agregar
                If frmCapRazon.ShowDialog() = DialogResult.OK Then
                    RefrescaLista()
                End If
            Case Modificar
                Dim frmCapRazon As New frmCapRazonDevCheque()
                frmCapRazon.TipoAccion = Modificar
                frmCapRazon.FillData(Me.ID)
                If frmCapRazon.ShowDialog() = DialogResult.OK Then
                    RefrescaLista()
                End If
            Case Eliminar
                If MessageBox.Show("¿Esta seguro?", "Borrar razón", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim objRazon As New SigaMetClasses.cRazonDevCheque()
                    Try
                        objRazon.Borra(Me.ID)
                    Catch ex As Exception
                        MessageBox.Show(ex.ToString)
                    Finally
                        objRazon = Nothing
                        RefrescaLista()
                    End Try
                End If
            Case Refrescar
                RefrescaLista()
        End Select
    End Sub

    Private Sub RefrescaLista()
        CargaLista()
        AplicaFormato()
    End Sub
End Class