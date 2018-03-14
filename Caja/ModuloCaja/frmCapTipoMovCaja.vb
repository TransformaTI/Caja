Imports CatalogoBase.frmCatalogo.enumTipoAccion
Public Class frmCapTipoMovCaja
    Inherits System.Windows.Forms.Form
    Public TipoAccion As CatalogoBase.frmCatalogo.enumTipoAccion

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
    Friend WithEvents chkAplicaVenta As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents LabelBase1 As ControlesBase.LabelBase
    Friend WithEvents LabelBase2 As ControlesBase.LabelBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapTipoMovCaja))
        Me.txtTipoMovimientoCaja = New ControlesBase.TextBoxBase()
        Me.txtDescripcion = New ControlesBase.TextBoxBase()
        Me.chkAplicaVenta = New System.Windows.Forms.CheckBox()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.LabelBase2 = New ControlesBase.LabelBase()
        Me.SuspendLayout()
        '
        'txtTipoMovimientoCaja
        '
        Me.txtTipoMovimientoCaja.Location = New System.Drawing.Point(88, 16)
        Me.txtTipoMovimientoCaja.Name = "txtTipoMovimientoCaja"
        Me.txtTipoMovimientoCaja.Size = New System.Drawing.Size(56, 21)
        Me.txtTipoMovimientoCaja.TabIndex = 0
        Me.txtTipoMovimientoCaja.Text = ""
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(88, 40)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(304, 21)
        Me.txtDescripcion.TabIndex = 1
        Me.txtDescripcion.Text = ""
        '
        'chkAplicaVenta
        '
        Me.chkAplicaVenta.Location = New System.Drawing.Point(88, 72)
        Me.chkAplicaVenta.Name = "chkAplicaVenta"
        Me.chkAplicaVenta.Size = New System.Drawing.Size(104, 16)
        Me.chkAplicaVenta.TabIndex = 2
        Me.chkAplicaVenta.Text = "¿Aplica venta?"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(416, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 7
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(416, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.Location = New System.Drawing.Point(16, 19)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(35, 14)
        Me.LabelBase1.TabIndex = 8
        Me.LabelBase1.Text = "Clave:"
        '
        'LabelBase2
        '
        Me.LabelBase2.AutoSize = True
        Me.LabelBase2.Location = New System.Drawing.Point(16, 43)
        Me.LabelBase2.Name = "LabelBase2"
        Me.LabelBase2.Size = New System.Drawing.Size(65, 14)
        Me.LabelBase2.TabIndex = 9
        Me.LabelBase2.Text = "Descripción:"
        '
        'frmCapTipoMovCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(504, 101)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.LabelBase2, Me.LabelBase1, Me.btnCancelar, Me.btnAceptar, Me.chkAplicaVenta, Me.txtDescripcion, Me.txtTipoMovimientoCaja})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCapTipoMovCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo de movimiento de caja"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub FillData(ByVal TipoMovimientoCaja As Short)
        Dim oCaja As New SigaMetClasses.cTipoMovimientoCaja()
        oCaja.Consulta(TipoMovimientoCaja)
        txtTipoMovimientoCaja.Enabled = False
        txtTipoMovimientoCaja.Text = oCaja.TipoMovimientoCaja.ToString
        txtDescripcion.Text = Trim(oCaja.Descripcion)
        chkAplicaVenta.Checked = CType(oCaja.AplicaVenta, Boolean)
        oCaja = Nothing
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim oCaja As New SigaMetClasses.cTipoMovimientoCaja()
        Try
            If TipoAccion = Agregar Then
                oCaja.AltaModifica(CType(txtTipoMovimientoCaja.Text, Short), txtDescripcion.Text, chkAplicaVenta.Checked)
            End If
            If TipoAccion = Modificar Then
                oCaja.AltaModifica(CType(txtTipoMovimientoCaja.Text, Short), txtDescripcion.Text, chkAplicaVenta.Checked, False)
            End If
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tipo movimiento", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            oCaja = Nothing
            Me.Close()
        End Try
    End Sub
End Class