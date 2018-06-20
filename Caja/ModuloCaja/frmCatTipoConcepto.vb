Imports System.Data.SqlClient
Imports CatalogoBase.frmCatalogo

Public Class frmCatTipoConcepto
    Inherits CatalogoBase.frmCatalogo
    Dim Id As String

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
    Friend WithEvents txtUsuario As ControlesBase.TextBoxBase
    Friend WithEvents txtEstatus As ControlesBase.TextBoxBase
    Friend WithEvents lblUsuarioAlta As ControlesBase.LabelBase
    Friend WithEvents lblFalta As ControlesBase.LabelBase
    Friend WithEvents txtFalta As ControlesBase.TextBoxBase
    Friend WithEvents lblEstatus As ControlesBase.LabelBase
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.txtUsuario = New ControlesBase.TextBoxBase()
        Me.txtEstatus = New ControlesBase.TextBoxBase()
        Me.lblUsuarioAlta = New ControlesBase.LabelBase()
        Me.lblEstatus = New ControlesBase.LabelBase()
        Me.lblFalta = New ControlesBase.LabelBase()
        Me.txtFalta = New ControlesBase.TextBoxBase()
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
        Me.tbDatos.Controls.Add(Me.lblFalta)
        Me.tbDatos.Controls.Add(Me.txtFalta)
        Me.tbDatos.Controls.Add(Me.lblEstatus)
        Me.tbDatos.Controls.Add(Me.lblUsuarioAlta)
        Me.tbDatos.Controls.Add(Me.txtEstatus)
        Me.tbDatos.Controls.Add(Me.txtUsuario)
        Me.tbDatos.Size = New System.Drawing.Size(560, 158)
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        '
        'txtUsuario
        '
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Location = New System.Drawing.Point(120, 8)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(112, 21)
        Me.txtUsuario.TabIndex = 0
        '
        'txtEstatus
        '
        Me.txtEstatus.Enabled = False
        Me.txtEstatus.Location = New System.Drawing.Point(120, 32)
        Me.txtEstatus.Name = "txtEstatus"
        Me.txtEstatus.Size = New System.Drawing.Size(112, 21)
        Me.txtEstatus.TabIndex = 1
        '
        'lblUsuarioAlta
        '
        Me.lblUsuarioAlta.AutoSize = True
        Me.lblUsuarioAlta.Location = New System.Drawing.Point(40, 11)
        Me.lblUsuarioAlta.Name = "lblUsuarioAlta"
        Me.lblUsuarioAlta.Size = New System.Drawing.Size(72, 13)
        Me.lblUsuarioAlta.TabIndex = 2
        Me.lblUsuarioAlta.Text = "Usuario Alta :"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(40, 35)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(47, 13)
        Me.lblEstatus.TabIndex = 3
        Me.lblEstatus.Text = "Estatus:"
        '
        'lblFalta
        '
        Me.lblFalta.AutoSize = True
        Me.lblFalta.Location = New System.Drawing.Point(40, 62)
        Me.lblFalta.Name = "lblFalta"
        Me.lblFalta.Size = New System.Drawing.Size(40, 13)
        Me.lblFalta.TabIndex = 5
        Me.lblFalta.Text = "F.Alta:"
        '
        'txtFalta
        '
        Me.txtFalta.Enabled = False
        Me.txtFalta.Location = New System.Drawing.Point(120, 59)
        Me.txtFalta.Name = "txtFalta"
        Me.txtFalta.Size = New System.Drawing.Size(112, 21)
        Me.txtFalta.TabIndex = 4
        '
        'frmCatTipoConcepto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(568, 397)
        Me.Name = "frmCatTipoConcepto"
        Me.Text = "Catálogo de Tipo Concepto"
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
        Dim m_metodos As New MetodoDatos
        Me.grdDatos.DataSource = m_metodos.ConsultaTipoConcepto()
        Me.ListaDatos.AddRange(m_metodos.CargaTipoConcepto())
    End Sub

    Private Overloads Sub AplicaFormato()
        NombreTabla = "TipoConcepto"
        MyBase.AplicaFormato("Catálogo de Tipo Concepto")
        Dim Col1 As New DataGridTextBoxColumn()
        With Col1
            .HeaderText = "Id"
            .MappingName = "TipoConcepto"
            .Width = 50
        End With
        Dim Col2 As New DataGridTextBoxColumn()
        With Col2
            .HeaderText = "Concepto"
            .MappingName = "Descripcion"
            .Width = 250
        End With

        Dim Col3 As New DataGridTextBoxColumn()
        With Col3
            .HeaderText = "Usuario"
            .MappingName = "UsuarioAlta"
            .Width = 70
        End With
        Dim Col4 As New DataGridTextBoxColumn()
        With Col4
            .HeaderText = "Estatus"
            .MappingName = "Estatus"
            .Width = 70
        End With
        Dim Col5 As New DataGridTextBoxColumn()
        With Col5
            .HeaderText = "F.Alta"
            .MappingName = "falta"
            .Width = 70
        End With
        grdTableStyle1.GridColumnStyles.AddRange(New DataGridColumnStyle() {Col1, Col2, Col3, Col4, Col5})
        grdDatos.TableStyles.Add(grdTableStyle1)
    End Sub
#End Region

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If ListaDatos.Count > grdDatos.CurrentRowIndex Then
            MyBase.grdDatos_CurrentCellChanged(sender, e)
            Id = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String)
            Dim strUsuario As String = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 2), String)
            Dim strEstatus As String = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 3), String)
            Dim strFecha As String = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 4), String)

            txtUsuario.Text = strUsuario
            txtFalta.Text = strFecha
            txtEstatus.Text = strEstatus
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
                Dim frmCaptura As New frmCapTipoConcepto()
                frmCaptura.TipoAccion = enumTipoAccion.Agregar
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    CargaLista()
                    AplicaFormato()
                End If
            Case enumTipoAccion.Modificar
                If Id <> "" Then
                    Dim frmCaptura As New frmCapTipoConcepto()
                    frmCaptura.TipoAccion = enumTipoAccion.Modificar
                    frmCaptura.FillData(CType(Id, Integer))
                    If frmCaptura.ShowDialog() = DialogResult.OK Then
                        CargaLista()
                        AplicaFormato()
                    End If
                End If
            Case enumTipoAccion.Refrescar
                CargaLista()
                AplicaFormato()
        End Select
    End Sub
End Class