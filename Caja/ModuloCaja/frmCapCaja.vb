Imports CatalogoBase.frmCatalogo.enumTipoAccion

Public Class frmCapCaja
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
    Friend WithEvents txtCaja As ControlesBase.TextBoxBase
    Friend WithEvents lblCaja As ControlesBase.LabelBase
    Friend WithEvents lblDescripcion As ControlesBase.LabelBase
    Friend WithEvents txtDescripcion As ControlesBase.TextBoxBase
    Friend WithEvents lblUsuario As ControlesBase.LabelBase
    Friend WithEvents txtUsuario As ControlesBase.TextBoxBase
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapCaja))
        Me.txtCaja = New ControlesBase.TextBoxBase()
        Me.lblCaja = New ControlesBase.LabelBase()
        Me.lblDescripcion = New ControlesBase.LabelBase()
        Me.txtDescripcion = New ControlesBase.TextBoxBase()
        Me.lblUsuario = New ControlesBase.LabelBase()
        Me.txtUsuario = New ControlesBase.TextBoxBase()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.SuspendLayout()
        '
        'txtCaja
        '
        Me.txtCaja.Location = New System.Drawing.Point(80, 16)
        Me.txtCaja.Name = "txtCaja"
        Me.txtCaja.Size = New System.Drawing.Size(48, 21)
        Me.txtCaja.TabIndex = 0
        Me.txtCaja.Text = ""
        '
        'lblCaja
        '
        Me.lblCaja.AutoSize = True
        Me.lblCaja.Location = New System.Drawing.Point(16, 19)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(30, 14)
        Me.lblCaja.TabIndex = 1
        Me.lblCaja.Text = "Caja:"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(16, 43)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(65, 14)
        Me.lblDescripcion.TabIndex = 3
        Me.lblDescripcion.Text = "Descripción:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(80, 40)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(208, 21)
        Me.txtDescripcion.TabIndex = 2
        Me.txtDescripcion.Text = ""
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.Location = New System.Drawing.Point(16, 67)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(46, 14)
        Me.lblUsuario.TabIndex = 5
        Me.lblUsuario.Text = "Usuario:"
        '
        'txtUsuario
        '
        Me.txtUsuario.Location = New System.Drawing.Point(80, 64)
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.TabIndex = 4
        Me.txtUsuario.Text = ""
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(312, 48)
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
        Me.btnAceptar.Location = New System.Drawing.Point(312, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 6
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapCaja
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(400, 101)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.txtUsuario, Me.txtDescripcion, Me.txtCaja, Me.lblUsuario, Me.lblDescripcion, Me.lblCaja})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCapCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cajas"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub FillData(ByVal Caja As Short)
        Dim oCaja As New SigaMetClasses.cCaja()
        oCaja.Consulta(Caja)
        txtCaja.Enabled = False
        txtCaja.Text = CType(oCaja.Caja, String)
        txtDescripcion.Text = oCaja.Descripcion
        txtUsuario.Text = oCaja.Usuario
        oCaja = Nothing
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim oCaja As New SigaMetClasses.cCaja()
        Try
            If TipoAccion = Agregar Then
                oCaja.AltaModifica(CType(txtCaja.Text, Short), txtDescripcion.Text, txtUsuario.Text)
            End If
            If TipoAccion = Modificar Then
                oCaja.AltaModifica(CType(txtCaja.Text, Short), txtDescripcion.Text, txtUsuario.Text, False)
            End If
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Cajas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            oCaja = Nothing
            Me.Close()
        End Try
    End Sub
End Class