Imports System.Data.SqlClient
Imports CatalogoBase.frmCatalogo

Public Class frmCatBanco
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
    Friend WithEvents txtBanco As ControlesBase.TextBoxBase
    Friend WithEvents txtNombre As ControlesBase.TextBoxBase
    Friend WithEvents lblBanco As ControlesBase.LabelBase
    Friend WithEvents lblNombre As ControlesBase.LabelBase
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtBanco = New ControlesBase.TextBoxBase()
        Me.txtNombre = New ControlesBase.TextBoxBase()
        Me.lblBanco = New ControlesBase.LabelBase()
        Me.lblNombre = New ControlesBase.LabelBase()
        Me.tabDatos.SuspendLayout()
        Me.tbDatos.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tbrBarra
        '
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(54, 36)
        '
        'tabDatos
        '
        Me.tabDatos.ItemSize = New System.Drawing.Size(48, 18)
        '
        'tbDatos
        '
        Me.tbDatos.Controls.Add(Me.lblNombre)
        Me.tbDatos.Controls.Add(Me.lblBanco)
        Me.tbDatos.Controls.Add(Me.txtNombre)
        Me.tbDatos.Controls.Add(Me.txtBanco)
        Me.tbDatos.Size = New System.Drawing.Size(560, 158)
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        '
        'txtBanco
        '
        Me.txtBanco.Enabled = False
        Me.txtBanco.Location = New System.Drawing.Point(120, 8)
        Me.txtBanco.Name = "txtBanco"
        Me.txtBanco.Size = New System.Drawing.Size(40, 21)
        Me.txtBanco.TabIndex = 0
        '
        'txtNombre
        '
        Me.txtNombre.Enabled = False
        Me.txtNombre.Location = New System.Drawing.Point(120, 32)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(208, 21)
        Me.txtNombre.TabIndex = 1
        '
        'lblBanco
        '
        Me.lblBanco.AutoSize = True
        Me.lblBanco.Location = New System.Drawing.Point(40, 11)
        Me.lblBanco.Name = "lblBanco"
        Me.lblBanco.Size = New System.Drawing.Size(40, 13)
        Me.lblBanco.TabIndex = 2
        Me.lblBanco.Text = "Banco:"
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Location = New System.Drawing.Point(40, 35)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(48, 13)
        Me.lblNombre.TabIndex = 3
        Me.lblNombre.Text = "Nombre:"
        '
        'frmCatBanco
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(568, 397)
        Me.Name = "frmCatBanco"
        Me.Text = "Catálogo de Bancos"
        Me.tabDatos.ResumeLayout(False)
        Me.tbDatos.ResumeLayout(False)
        Me.tbDatos.PerformLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

#Region "CargaLista() y AplicaFormato()"
    Private Sub CargaLista()
        grdDatos.DataSource = Nothing
        Dim oBanco As New SigaMetClasses.cBanco()
        grdDatos.DataSource = oBanco.Consulta
        Dim dr As SqlDataReader = oBanco.ConsultaDR
        oBanco = Nothing

        Do While dr.Read
            Dim b As New SigaMetClasses.cBanco()
            b.Banco = CType(dr("Banco"), Short)
            b.Nombre = CType(dr("Nombre"), String)
            Me.ListaDatos.Add(b)
        Loop
        dr.Close()
    End Sub

    Private Overloads Sub AplicaFormato()
        Me.NombreTabla = "Banco"
        MyBase.AplicaFormato("Catálogo de bancos")
        Dim Col1 As New DataGridTextBoxColumn()
        With Col1
            .HeaderText = "Banco"
            .MappingName = "Banco"
            .Width = 50
        End With
        Dim Col2 As New DataGridTextBoxColumn()
        With Col2
            .HeaderText = "Nombre del banco"
            .MappingName = "Descripcion"
            .Width = 250
        End With
        grdTableStyle1.GridColumnStyles.AddRange(New DataGridColumnStyle() {Col1, Col2})
        grddatos.TableStyles.Add(grdTableStyle1)
    End Sub
#End Region

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ListaDatos.Count > grdDatos.CurrentRowIndex Then
            MyBase.grdDatos_CurrentCellChanged(sender, e)
            txtBanco.Text = Me.ID
            Dim strNombre As String = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String)
            Dim o As New SigaMetClasses.cBanco()
            o.Banco = CType(Me.ID, Short)
            o.Nombre = strNombre
            txtNombre.Text = strNombre
            Try
                Dim i As Integer = ListaDatos.IndexOf(o)
                Me.IndiceID = i
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End If
    End Sub

    Private Sub frmCatBanco_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaLista()
        AplicaFormato()
    End Sub

    Private Overloads Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        MyBase.tbrBarra_ButtonClick(sender, e)
        Select Case TipoAccion
            Case enumTipoAccion.Agregar
                Dim frmCaptura As New frmCapBanco()
                frmCaptura.TipoAccion = enumTipoAccion.Agregar
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    CargaLista()
                    AplicaFormato()
                End If
            Case enumTipoAccion.Modificar
                If Me.ID <> "" Then
                    Dim frmCaptura As New frmCapBanco()
                    frmCaptura.TipoAccion = enumTipoAccion.Modificar
                    frmCaptura.FillData(CType(Me.ID, Short))
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        CargaLista()
                        AplicaFormato()
                    End If
                End If
            Case enumTipoAccion.Eliminar
                If MessageBox.Show("¿Está seguro?", "Borrar banco", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim objBanco As New SigaMetClasses.cBanco()
                    objBanco.Borra(CType(Me.ID, Short))
                    CargaLista()
                    AplicaFormato()
                End If
            Case enumTipoAccion.Refrescar
                CargaLista()
                AplicaFormato()
        End Select
    End Sub
End Class