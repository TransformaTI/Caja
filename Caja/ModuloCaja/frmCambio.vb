Public Class frmCambio
    Inherits System.Windows.Forms.Form
    Private Cambio As Decimal
    Private _TipoOperacion As TipoOperacionMovimientoCaja
    Public arrCambio As Array

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal decCambio As Decimal, ByVal TipoOperacion As TipoOperacionMovimientoCaja)
        MyBase.New()
        InitializeComponent()

        Cambio = decCambio
        _TipoOperacion = TipoOperacion
        lblCambio.Text = Cambio.ToString("N")
        lblFaltante.Text = Cambio.ToString("N")
        If _TipoOperacion = TipoOperacionMovimientoCaja.Consulta Then Me.Text = "Consulta de cambio"
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAceptar As ControlesBase.BotonBase
    Friend WithEvents Efectivo As CapturaEfectivo.Efectivo
    Public WithEvents lblCambio As System.Windows.Forms.Label
    Public WithEvents lblFaltante As System.Windows.Forms.Label
    Public WithEvents lblCambio2 As ControlesBase.LabelBase
    Public WithEvents lblFaltante2 As ControlesBase.LabelBase
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmCambio))
        Me.Efectivo = New CapturaEfectivo.Efectivo()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lblCambio = New System.Windows.Forms.Label()
        Me.lblCambio2 = New ControlesBase.LabelBase()
        Me.lblFaltante = New System.Windows.Forms.Label()
        Me.lblFaltante2 = New ControlesBase.LabelBase()
        Me.btnAceptar = New ControlesBase.BotonBase()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Efectivo
        '
        Me.Efectivo.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Efectivo.Location = New System.Drawing.Point(19, 8)
        Me.Efectivo.M1 = CType(0, Short)
        Me.Efectivo.M10 = CType(0, Short)
        Me.Efectivo.M100 = CType(0, Short)
        Me.Efectivo.M1000 = CType(0, Short)
        Me.Efectivo.M10c = CType(0, Short)
        Me.Efectivo.M2 = CType(0, Short)
        Me.Efectivo.M20 = CType(0, Short)
        Me.Efectivo.M200 = CType(0, Short)
        Me.Efectivo.M20c = CType(0, Short)
        Me.Efectivo.M5 = CType(0, Short)
        Me.Efectivo.M50 = CType(0, Short)
        Me.Efectivo.M500 = CType(0, Short)
        Me.Efectivo.M50c = CType(0, Short)
        Me.Efectivo.M5c = CType(0, Short)
        Me.Efectivo.Morralla = 0
        Me.Efectivo.Name = "Efectivo"
        Me.Efectivo.Size = New System.Drawing.Size(136, 376)
        Me.Efectivo.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.lblCambio, Me.lblCambio2, Me.Efectivo, Me.lblFaltante, Me.lblFaltante2, Me.btnAceptar})
        Me.Panel1.Location = New System.Drawing.Point(4, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(179, 505)
        Me.Panel1.TabIndex = 2
        '
        'lblCambio
        '
        Me.lblCambio.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCambio.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCambio.ForeColor = System.Drawing.Color.Blue
        Me.lblCambio.Location = New System.Drawing.Point(59, 392)
        Me.lblCambio.Name = "lblCambio"
        Me.lblCambio.Size = New System.Drawing.Size(88, 23)
        Me.lblCambio.TabIndex = 8
        Me.lblCambio.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblCambio2
        '
        Me.lblCambio2.AutoSize = True
        Me.lblCambio2.ForeColor = System.Drawing.Color.Blue
        Me.lblCambio2.Location = New System.Drawing.Point(8, 396)
        Me.lblCambio2.Name = "lblCambio2"
        Me.lblCambio2.Size = New System.Drawing.Size(45, 14)
        Me.lblCambio2.TabIndex = 9
        Me.lblCambio2.Text = "Cambio:"
        '
        'lblFaltante
        '
        Me.lblFaltante.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFaltante.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFaltante.ForeColor = System.Drawing.Color.Red
        Me.lblFaltante.Location = New System.Drawing.Point(59, 424)
        Me.lblFaltante.Name = "lblFaltante"
        Me.lblFaltante.Size = New System.Drawing.Size(88, 23)
        Me.lblFaltante.TabIndex = 3
        Me.lblFaltante.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFaltante2
        '
        Me.lblFaltante2.AutoSize = True
        Me.lblFaltante2.ForeColor = System.Drawing.Color.Red
        Me.lblFaltante2.Location = New System.Drawing.Point(8, 428)
        Me.lblFaltante2.Name = "lblFaltante2"
        Me.lblFaltante2.Size = New System.Drawing.Size(48, 14)
        Me.lblFaltante2.TabIndex = 2
        Me.lblFaltante2.Text = "Faltante:"
        '
        'btnAceptar
        '
        Me.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnAceptar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(47, 464)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 24)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "&Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmCambio
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.ClientSize = New System.Drawing.Size(186, 519)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Panel1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCambio"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cambio"
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Efectivo_TotalActualizado() Handles Efectivo.TotalActualizado
        lblFaltante.Text = (Cambio - Efectivo.TotalEfectivo).ToString("N")
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If _TipoOperacion = TipoOperacionMovimientoCaja.Consulta Then Me.Close()
        If _TipoOperacion = TipoOperacionMovimientoCaja.Validacion Then
            If Efectivo.TotalEfectivo > Cambio Then
                If MessageBox.Show("El importe desglosado es mayor al importe del cambio." & Chr(13) & _
                            "¿Desea continuar?", "Cambio", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) = DialogResult.Yes Then
                    arrCambio = Efectivo.CalculaDenominaciones
                    Me.Close()
                Else
                    Efectivo.ComienzaCaptura()
                End If
            End If
            If Efectivo.TotalEfectivo <= Cambio Then
                arrCambio = Efectivo.CalculaDenominaciones
                Me.Close()
            End If
        End If
    End Sub
End Class