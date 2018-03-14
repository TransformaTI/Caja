Option Strict On
Option Explicit On
Imports CatalogoBase.frmCatalogo.enumTipoAccion

Public Class frmCatTipoMov
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
    Friend WithEvents txtTipoMovimientoCaja As ControlesBase.TextBoxBase
    Friend WithEvents txtDescripcion As ControlesBase.TextBoxBase
    Friend WithEvents lblTipoMovimientoCaja As ControlesBase.LabelBase
    Friend WithEvents lblDescripcion As ControlesBase.LabelBase
    Friend WithEvents chkAplicaVenta As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.txtTipoMovimientoCaja = New ControlesBase.TextBoxBase()
        Me.lblTipoMovimientoCaja = New ControlesBase.LabelBase()
        Me.lblDescripcion = New ControlesBase.LabelBase()
        Me.txtDescripcion = New ControlesBase.TextBoxBase()
        Me.chkAplicaVenta = New System.Windows.Forms.CheckBox()
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
        Me.tbDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkAplicaVenta, Me.lblDescripcion, Me.txtDescripcion, Me.lblTipoMovimientoCaja, Me.txtTipoMovimientoCaja})
        Me.tbDatos.Size = New System.Drawing.Size(560, 89)
        '
        'txtTipoMovimientoCaja
        '
        Me.txtTipoMovimientoCaja.Enabled = False
        Me.txtTipoMovimientoCaja.Location = New System.Drawing.Point(104, 8)
        Me.txtTipoMovimientoCaja.Name = "txtTipoMovimientoCaja"
        Me.txtTipoMovimientoCaja.Size = New System.Drawing.Size(80, 21)
        Me.txtTipoMovimientoCaja.TabIndex = 0
        Me.txtTipoMovimientoCaja.Text = ""
        '
        'lblTipoMovimientoCaja
        '
        Me.lblTipoMovimientoCaja.AutoSize = True
        Me.lblTipoMovimientoCaja.Location = New System.Drawing.Point(24, 11)
        Me.lblTipoMovimientoCaja.Name = "lblTipoMovimientoCaja"
        Me.lblTipoMovimientoCaja.Size = New System.Drawing.Size(35, 14)
        Me.lblTipoMovimientoCaja.TabIndex = 1
        Me.lblTipoMovimientoCaja.Text = "Clave:"
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
        'txtDescripcion
        '
        Me.txtDescripcion.Enabled = False
        Me.txtDescripcion.Location = New System.Drawing.Point(104, 32)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(336, 21)
        Me.txtDescripcion.TabIndex = 2
        Me.txtDescripcion.Text = ""
        '
        'chkAplicaVenta
        '
        Me.chkAplicaVenta.Enabled = False
        Me.chkAplicaVenta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.chkAplicaVenta.Location = New System.Drawing.Point(104, 64)
        Me.chkAplicaVenta.Name = "chkAplicaVenta"
        Me.chkAplicaVenta.Size = New System.Drawing.Size(120, 16)
        Me.chkAplicaVenta.TabIndex = 4
        Me.chkAplicaVenta.Text = "¿Aplica venta?"
        '
        'frmCatTipoMov
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(568, 421)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabDatos, Me.grdDatos, Me.tbrBarra})
        Me.Name = "frmCatTipoMov"
        Me.ShowInTaskbar = False
        Me.Text = "Catálogo de tipo de movimientos de caja"
        Me.tabDatos.ResumeLayout(False)
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCatTipoMov_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaLista()
        AplicaFormato()
    End Sub

    Private Overloads Sub AplicaFormato()
        NombreTabla = "TipoMovimientoCaja"
        MyBase.AplicaFormato("Tipo de movimientos de caja")
        Dim Col1 As New DataGridTextBoxColumn()
        With Col1
            .HeaderText = "Clave"
            .MappingName = "TipoMovimientoCaja"
            .Width = 50
        End With
        Dim Col2 As New DataGridTextBoxColumn()
        With Col2
            .HeaderText = "Descripción"
            .MappingName = "Descripcion"
            .Width = 350
        End With
        Dim Col3 As New DataGridTextBoxColumn()
        With Col3
            .HeaderText = "Aplica venta"
            .MappingName = "AplicaVenta"
            .Width = 100
        End With
        grdTableStyle1.GridColumnStyles.AddRange(New DataGridColumnStyle() {Col1, Col2, Col3})
        grdDatos.TableStyles.Add(grdTableStyle1)
    End Sub

    Private Sub CargaLista()
        Dim oTipo As New SigaMetClasses.cTipoMovimientoCaja()
        Dim dt As DataTable
        grdDatos.DataSource = Nothing
        dt = oTipo.Consulta()
        dt.TableName = "TipoMovimientoCaja"
        grdDatos.DataSource = dt
        oTipo = Nothing
    End Sub

    Private Sub Refresca()
        CargaLista()
        AplicaFormato()
        txtTipoMovimientoCaja.Text = ""
        txtDescripcion.Text = ""
        chkAplicaVenta.Checked = False
    End Sub

    Public Overrides Sub grdDatos_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        MyBase.grdDatos_CurrentCellChanged(sender, e)
        txtTipoMovimientoCaja.Text = ID
        txtDescripcion.Text = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 1), String)
        chkAplicaVenta.Checked = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 2), Boolean)
    End Sub

    Public Overrides Sub tbrBarra_ButtonClick(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs)
        MyBase.tbrBarra_ButtonClick(sender, e)
        Select Case TipoAccion
            Case Agregar
                Dim frmCaptura As New frmCapTipoMovCaja()
                frmCaptura.TipoAccion = Agregar
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    Refresca()
                End If
            Case Modificar
                Dim frmCaptura As New frmCapTipoMovCaja()
                frmCaptura.TipoAccion = Modificar
                frmCaptura.FillData(CType(ID, Short))
                If frmCaptura.ShowDialog() = DialogResult.OK Then
                    Refresca()
                End If
            Case Eliminar
                If MessageBox.Show("¿Está seguro?", "Borrar tipo", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    Dim oTipo As New SigaMetClasses.cTipoMovimientoCaja()
                    oTipo.Borra(CType(ID, Short))
                    oTipo = Nothing
                    Refresca()
                End If
            Case Refrescar
                Refresca()
        End Select
    End Sub
End Class