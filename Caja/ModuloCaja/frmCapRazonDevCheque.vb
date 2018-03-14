Imports CatalogoBase.frmCatalogo.enumTipoAccion

Public Class frmCapRazonDevCheque
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
    Friend WithEvents txtRazonDevCheque As ControlesBase.TextBoxBase
    Friend WithEvents txtDescripcion As ControlesBase.TextBoxBase
    Friend WithEvents lblRazonDevCheque As ControlesBase.LabelBase
    Friend WithEvents lblDescripcion As ControlesBase.LabelBase
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCapRazonDevCheque))
        Me.txtRazonDevCheque = New ControlesBase.TextBoxBase()
        Me.txtDescripcion = New ControlesBase.TextBoxBase()
        Me.lblRazonDevCheque = New ControlesBase.LabelBase()
        Me.lblDescripcion = New ControlesBase.LabelBase()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.SuspendLayout()
        '
        'txtRazonDevCheque
        '
        Me.txtRazonDevCheque.Location = New System.Drawing.Point(88, 16)
        Me.txtRazonDevCheque.Name = "txtRazonDevCheque"
        Me.txtRazonDevCheque.Size = New System.Drawing.Size(48, 21)
        Me.txtRazonDevCheque.TabIndex = 0
        Me.txtRazonDevCheque.Text = ""
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(88, 40)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(328, 21)
        Me.txtDescripcion.TabIndex = 1
        Me.txtDescripcion.Text = ""
        '
        'lblRazonDevCheque
        '
        Me.lblRazonDevCheque.AutoSize = True
        Me.lblRazonDevCheque.Location = New System.Drawing.Point(16, 19)
        Me.lblRazonDevCheque.Name = "lblRazonDevCheque"
        Me.lblRazonDevCheque.Size = New System.Drawing.Size(39, 14)
        Me.lblRazonDevCheque.TabIndex = 2
        Me.lblRazonDevCheque.Text = "Razón:"
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
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(432, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(432, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCapRazonDevCheque
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(520, 85)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.lblDescripcion, Me.lblRazonDevCheque, Me.txtDescripcion, Me.txtRazonDevCheque})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCapRazonDevCheque"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Razones de devolución de cheques"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub FillData(ByVal RazonDevCheque As String)
        Dim objRazon As New SigaMetClasses.cRazonDevCheque()
        objRazon.Consulta(RazonDevCheque)
        txtRazonDevCheque.Enabled = False
        txtRazonDevCheque.Text = Trim(objRazon.RazonDevCheque)
        txtDescripcion.Text = Trim(objRazon.Descripcion)
        objRazon = Nothing
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim objRazon As New SigaMetClasses.cRazonDevCheque()
        Try
            If TipoAccion = Agregar Then
                objRazon.AltaModifica(txtRazonDevCheque.Text, txtDescripcion.Text)
            End If
            If TipoAccion = Modificar Then
                objRazon.AltaModifica(txtRazonDevCheque.Text, txtDescripcion.Text, False)
            End If
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Razones", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            objRazon = Nothing
            Me.Close()
        End Try
    End Sub
End Class