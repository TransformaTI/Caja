Imports CatalogoBase.frmCatalogo.enumTipoAccion
Public Class frmCapTipoConcepto
    Inherits System.Windows.Forms.Form
    Public TipoAccion As CatalogoBase.frmCatalogo.enumTipoAccion
    Friend WithEvents lblEstatus As Label
    Friend WithEvents comboEstatus As ComboBox
    Dim _IdTipoConcepto As Integer
    Friend WithEvents ComboTipoMovCaja As ComboBox
    Dim esModificacion As Boolean
    Dim TipoConcepto As TipoConcepto = Nothing

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
    Friend WithEvents btnCancelar As ControlesBase.BotonBase
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblTipoMovCaja As Label
    Friend WithEvents lblCuentaContable As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCapTipoConcepto))
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.lblCuentaContable = New System.Windows.Forms.Label()
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.lblTipoMovCaja = New System.Windows.Forms.Label()
        Me.lblEstatus = New System.Windows.Forms.Label()
        Me.comboEstatus = New System.Windows.Forms.ComboBox()
        Me.ComboTipoMovCaja = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(142, 19)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(352, 21)
        Me.txtDescripcion.TabIndex = 0
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(142, 43)
        Me.txtCuenta.MaxLength = 16
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(352, 21)
        Me.txtCuenta.TabIndex = 1
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Location = New System.Drawing.Point(66, 23)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(65, 13)
        Me.lblDescripcion.TabIndex = 2
        Me.lblDescripcion.Text = "Descripcion:"
        '
        'lblCuentaContable
        '
        Me.lblCuentaContable.AutoSize = True
        Me.lblCuentaContable.Location = New System.Drawing.Point(42, 47)
        Me.lblCuentaContable.Name = "lblCuentaContable"
        Me.lblCuentaContable.Size = New System.Drawing.Size(90, 13)
        Me.lblCuentaContable.TabIndex = 3
        Me.lblCuentaContable.Text = "Cuenta contable:"
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(573, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(573, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTipoMovCaja
        '
        Me.lblTipoMovCaja.AutoSize = True
        Me.lblTipoMovCaja.Location = New System.Drawing.Point(49, 71)
        Me.lblTipoMovCaja.Name = "lblTipoMovCaja"
        Me.lblTipoMovCaja.Size = New System.Drawing.Size(83, 13)
        Me.lblTipoMovCaja.TabIndex = 6
        Me.lblTipoMovCaja.Text = "Tipo Mov. Caja:"
        '
        'lblEstatus
        '
        Me.lblEstatus.AutoSize = True
        Me.lblEstatus.Location = New System.Drawing.Point(86, 98)
        Me.lblEstatus.Name = "lblEstatus"
        Me.lblEstatus.Size = New System.Drawing.Size(47, 13)
        Me.lblEstatus.TabIndex = 21
        Me.lblEstatus.Text = "Estatus:"
        Me.lblEstatus.Visible = False
        '
        'comboEstatus
        '
        Me.comboEstatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboEstatus.FormattingEnabled = True
        Me.comboEstatus.Items.AddRange(New Object() {"ACTIVO", "INACTIVO"})
        Me.comboEstatus.Location = New System.Drawing.Point(144, 95)
        Me.comboEstatus.Name = "comboEstatus"
        Me.comboEstatus.Size = New System.Drawing.Size(350, 21)
        Me.comboEstatus.TabIndex = 22
        Me.comboEstatus.Visible = False
        '
        'ComboTipoMovCaja
        '
        Me.ComboTipoMovCaja.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboTipoMovCaja.FormattingEnabled = True
        Me.ComboTipoMovCaja.Location = New System.Drawing.Point(144, 70)
        Me.ComboTipoMovCaja.Name = "ComboTipoMovCaja"
        Me.ComboTipoMovCaja.Size = New System.Drawing.Size(350, 21)
        Me.ComboTipoMovCaja.TabIndex = 23
        '
        'frmCapTipoConcepto
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(661, 133)
        Me.Controls.Add(Me.ComboTipoMovCaja)
        Me.Controls.Add(Me.comboEstatus)
        Me.Controls.Add(Me.lblEstatus)
        Me.Controls.Add(Me.lblTipoMovCaja)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.lblCuentaContable)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "frmCapTipoConcepto"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tipo Concepto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            If TipoAccion = Agregar Then
                Dim objTipoConcepto As TipoConcepto = New TipoConcepto()
                objTipoConcepto.Descripcion = Me.txtDescripcion.Text
                objTipoConcepto.Tipomovimientocaja = Convert.ToInt32(Me.ComboTipoMovCaja.SelectedValue)
                objTipoConcepto.Cuentacontable = Me.txtCuenta.Text
                objTipoConcepto.Usuarioalta = GLOBAL_IDUsuario
                objTipoConcepto.Status = "ACTIVO"
                objTipoConcepto.Falta = DateTime.Now().ToString("dd-MM-yyyy")
                objTipoConcepto.Alta()
            End If
            If TipoAccion = Modificar Then
                Dim objTipoConcepto As TipoConcepto = New TipoConcepto()
                objTipoConcepto.TipoConcepto = _IdTipoConcepto
                objTipoConcepto.Descripcion = Me.txtDescripcion.Text
                objTipoConcepto.Tipomovimientocaja = Convert.ToInt32(Me.ComboTipoMovCaja.SelectedValue)
                objTipoConcepto.Cuentacontable = Me.txtCuenta.Text
                objTipoConcepto.Usuarioalta = GLOBAL_IDUsuario
                objTipoConcepto.Status = Me.comboEstatus.Text
                objTipoConcepto.Falta = DateTime.Now().ToString("dd-MM-yyyy")
                objTipoConcepto.Modifica()
            End If
            DialogResult = DialogResult.OK
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Tipo Concepto", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally

            Me.Close()
        End Try
    End Sub

    Public Sub FillData(ByVal IdTipoConcepto As Integer)
        _IdTipoConcepto = IdTipoConcepto
        Dim m_metodos As New MetodoDatos
        TipoConcepto = m_metodos.CargaTipoConcepto(IdTipoConcepto)
        txtDescripcion.Text = TipoConcepto.Descripcion
        txtCuenta.Text = TipoConcepto.Cuentacontable
        Me.lblEstatus.Visible = True
        Me.comboEstatus.Visible = True
        Me.comboEstatus.Text = TipoConcepto.Status
    End Sub

    Private Sub frmCapTipoConcepto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim m_metodos As New MetodoDatos
        ComboTipoMovCaja.DataSource = m_metodos.ConsultaTipoMovCaja()
        ComboTipoMovCaja.ValueMember = "TipoMovimientoCaja"
        ComboTipoMovCaja.DisplayMember = "Descripcion"
        If Not IsNothing(TipoConcepto) Then
            Me.ComboTipoMovCaja.SelectedValue = TipoConcepto.Tipomovimientocaja
        End If
    End Sub

    Private Sub txtCuenta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCuenta.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = ChrW(Keys.Back) Then
            e.Handled = True
        End If

    End Sub
End Class