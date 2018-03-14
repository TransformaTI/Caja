Option Explicit On 
Option Strict On
Imports CatalogoBase.frmCatalogo.enumTipoAccion

Public Class frmCatCaja
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
    Friend WithEvents txtCaja As ControlesBase.TextBoxBase
    Friend WithEvents txtDescripcion As ControlesBase.TextBoxBase
    Friend WithEvents lblCaja As ControlesBase.LabelBase
    Friend WithEvents lblDescripcion As ControlesBase.LabelBase
    Friend WithEvents txtUsuario As ControlesBase.TextBoxBase
    Friend WithEvents lblUsuario As ControlesBase.LabelBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtCaja = New ControlesBase.TextBoxBase()
        Me.txtDescripcion = New ControlesBase.TextBoxBase()
        Me.lblCaja = New ControlesBase.LabelBase()
        Me.lblDescripcion = New ControlesBase.LabelBase()
        Me.txtUsuario = New ControlesBase.TextBoxBase()
        Me.lblUsuario = New ControlesBase.LabelBase()
        Me.tabDatos.SuspendLayout()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDatos
        '
        Me.tabDatos.ItemSize = New System.Drawing.Size(48, 18)
        Me.tabDatos.Size = New System.Drawing.Size(568, 115)
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
        Me.tbDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblUsuario, Me.txtUsuario, Me.lblDescripcion, Me.lblCaja, Me.txtDescripcion, Me.txtCaja})
        Me.tbDatos.Size = New System.Drawing.Size(560, 89)
        '
        'txtCaja
        '
        Me.txtCaja.Enabled = False
        Me.txtCaja.Location = New System.Drawing.Point(104, 8)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Size = New System.Drawing.Size(56, 21)
        Me.txtCaja.TabIndex = 0
        Me.txtCaja.Text = ""
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(104, 32)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(192, 21)
        Me.txtDescripcion.TabIndex = 1
        Me.txtDescripcion.Text = ""
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Location = New System.Drawing.Point(24, 11)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(30, 14)
        Me.lblCaja.TabIndex = 2
        Me.lblCaja.Text = "Caja:"
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
        'txtUsuario
        '
        Me.txtUsuario.Enabled = False
        Me.txtUsuario.Location = New System.Drawing.Point(104, 56)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(192, 21)
        Me.txtUsuario.TabIndex = 4
        Me.txtUsuario.Text = ""
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(24, 59)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(46, 14)
        Me.lblUsuario.TabIndex = 5
        Me.lblUsuario.Text = "Usuario:"
        '
        'frmCatCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(568, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabDatos, Me.grdDatos, Me.tbrBarra})
        Me.Name = "frmCatCaja"
        Me.Text = "Catálogo de Cajas"
        Me.tabDatos.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CargaLista()
        grdDatos.DataSource = Nothing
        Dim oCaja As New SigaMetClasses.cCaja()
        Dim dt As DataTable = oCaja.Consulta
        dt.TableName = "Caja"
        grdDatos.DataSource = dt
        oCaja = Nothing
    End Sub

    Private Overloads Sub AplicaFormato()
        MyBase.AplicaFormato("Caja")
        NombreTabla = "Caja"
        Dim Col1 As New DataGridTextBoxColumn()
        With Col1
            .HeaderText = "Caja"
            .MappingName = "Caja"
            .Width = 50
        End With
        Dim Col2 As New DataGridTextBoxColumn()
        With Col2
            .HeaderText = "Descripción"
            .MappingName = "Descripcion"
            .Width = 150
        End With
        Dim Col3 As New DataGridTextBoxColumn()
        With Col3
            .HeaderText = "Usuario"
            .MappingName = "Usuario"
            .Width = 150
        End With
        grdTableStyle1.GridColumnStyles.AddRange(New DataGridColumnStyle() {Col1, Col2, Col3})
        grddatos.TableStyles.Add(grdTableStyle1)
    End Sub

    Private Sub frmCatCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Refresca()
        AplicaFormato()
    End Sub

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.grdDatos_CurrentCellChanged(sender, e)
        txtCaja.Text = ID
        txtDescripcion.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String)
        txtUsuario.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 2), String)
    End Sub

    Public Overrides Sub tbrBarra_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        MyBase.tbrBarra_ButtonClick(sender, e)
        Select Case TipoAccion
            Case Agregar
                Dim frmCaptura As New frmCapCaja()
                frmCaptura.TipoAccion = Agregar
                If frmCaptura.ShowDialog = DialogResult.OK Then
                    Refresca()
                End If
                frmCaptura.Dispose()
            Case Modificar
                Dim frmCaptura As New frmCapCaja()
                frmCaptura.TipoAccion = Modificar
                frmCaptura.FillData(CType(ID, Short))
                If frmCaptura.ShowDialog = DialogResult.OK Then
                    Refresca()
                End If
                frmCaptura.Dispose()
            Case Eliminar
                If MessageBox.Show("¿Está seguro?", "Borra caja", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim oCaja As New SigaMetClasses.cCaja()
                    oCaja.Borra(CType(ID, Short))
                    oCaja = Nothing
                    Refresca()
                End If
            Case Refrescar
                Refresca()
        End Select
    End Sub

    Private Sub Refresca()
        CargaLista()
        AplicaFormato()
        txtCaja.Text = ""
        txtDescripcion.Text = ""
        txtUsuario.Text = ""
    End Sub
End Class