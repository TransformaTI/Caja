Public Class frmCorteCajaTipoAplicacion
    Inherits System.Windows.Forms.Form
    Private _TipoAplicacionIngreso As Byte
    Private _Descripcion As String
    Private _Importe As Decimal
    Private _Caja As Byte

#Region "Propiedades"
    Public ReadOnly Property TipoAplicacionIngreso() As Byte
        Get
            Return _TipoAplicacionIngreso
        End Get
    End Property

    Public ReadOnly Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
    End Property

    Public ReadOnly Property Importe() As Decimal
        Get
            Return _Importe
        End Get
    End Property
#End Region

    Public Sub New(ByVal Caja As Byte)
        MyBase.New()
        InitializeComponent()
        _Caja = Caja
    End Sub

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
    Friend WithEvents txtImporte As SigaMetClasses.Controles.txtNumeroDecimal
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipoAplicacionIngreso As SigaMetClasses.Combos.ComboTipoAplicacionIngreso
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCorteCajaTipoAplicacion))
        Me.btnCancelar = New ControlesBase.BotonBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.cboTipoAplicacionIngreso = New SigaMetClasses.Combos.ComboTipoAplicacionIngreso()
        Me.txtImporte = New SigaMetClasses.Controles.txtNumeroDecimal()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnCancelar
        '
        Me.btnCancelar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(242, 40)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 24)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "&Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(242, 8)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboTipoAplicacionIngreso
        '
        Me.cboTipoAplicacionIngreso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTipoAplicacionIngreso.Location = New System.Drawing.Point(16, 24)
        Me.cboTipoAplicacionIngreso.Name = "cboTipoAplicacionIngreso"
        Me.cboTipoAplicacionIngreso.Size = New System.Drawing.Size(208, 21)
        Me.cboTipoAplicacionIngreso.TabIndex = 0
        '
        'txtImporte
        '
        Me.txtImporte.Location = New System.Drawing.Point(16, 64)
        Me.txtImporte.Name = "txtImporte"
        Me.txtImporte.TabIndex = 1
        Me.txtImporte.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(94, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Tipo de aplicación"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Importe"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'frmCorteCajaTipoAplicacion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(330, 95)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label2, Me.Label1, Me.txtImporte, Me.cboTipoAplicacionIngreso, Me.btnCancelar, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCorteCajaTipoAplicacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Seleccione el tipo de aplicación"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCorteCajaTipoAplicacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboTipoAplicacionIngreso.CargaDatos(_Caja)
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If Trim(txtImporte.Text) <> "" Then
            If CType(Me.cboTipoAplicacionIngreso.SelectedValue, Byte) <> 0 Then
                _TipoAplicacionIngreso = CType(cboTipoAplicacionIngreso.SelectedValue, Byte)
                _Descripcion = cboTipoAplicacionIngreso.Text
                _Importe = CType(txtImporte.Text, Decimal)
                DialogResult = DialogResult.OK
            Else
                MessageBox.Show("Debe seleccionar el tipo de aplicación.", Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                cboTipoAplicacionIngreso.Focus()
            End If

        Else
            MessageBox.Show("Debe definir el importe de la aplicación.", Me.Name, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtImporte.Focus()
        End If
    End Sub
End Class
