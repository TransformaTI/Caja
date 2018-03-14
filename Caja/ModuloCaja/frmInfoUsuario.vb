Public Class frmInfoUsuario
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblUsuarioNombre As System.Windows.Forms.Label
    Friend WithEvents lblEmpleadoNombre As System.Windows.Forms.Label
    Friend WithEvents lblEmpleado As System.Windows.Forms.Label
    Friend WithEvents lblCaja As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCadenaConexion As System.Windows.Forms.Label
    Friend WithEvents lblRutaReportes As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblReportesAppPath As System.Windows.Forms.Label
    Friend WithEvents lblMaxHoraLiquidacion As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents chkReglaHoraMaximaLiquidacion As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmInfoUsuario))
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.lblUsuarioNombre = New System.Windows.Forms.Label()
        Me.lblEmpleadoNombre = New System.Windows.Forms.Label()
        Me.lblEmpleado = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.lblCaja = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblCadenaConexion = New System.Windows.Forms.Label()
        Me.lblRutaReportes = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblReportesAppPath = New System.Windows.Forms.Label()
        Me.lblMaxHoraLiquidacion = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.chkReglaHoraMaximaLiquidacion = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'lblUsuario
        '
        Me.lblUsuario.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblUsuario.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUsuario.ForeColor = System.Drawing.Color.Navy
        Me.lblUsuario.Location = New System.Drawing.Point(184, 40)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(248, 21)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Bitmap)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(456, 16)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.TabIndex = 1
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblUsuarioNombre
        '
        Me.lblUsuarioNombre.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblUsuarioNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblUsuarioNombre.ForeColor = System.Drawing.Color.Navy
        Me.lblUsuarioNombre.Location = New System.Drawing.Point(184, 64)
        Me.lblUsuarioNombre.Name = "lblUsuarioNombre"
        Me.lblUsuarioNombre.Size = New System.Drawing.Size(248, 21)
        Me.lblUsuarioNombre.TabIndex = 2
        Me.lblUsuarioNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpleadoNombre
        '
        Me.lblEmpleadoNombre.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblEmpleadoNombre.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpleadoNombre.ForeColor = System.Drawing.Color.Navy
        Me.lblEmpleadoNombre.Location = New System.Drawing.Point(184, 112)
        Me.lblEmpleadoNombre.Name = "lblEmpleadoNombre"
        Me.lblEmpleadoNombre.Size = New System.Drawing.Size(248, 21)
        Me.lblEmpleadoNombre.TabIndex = 4
        Me.lblEmpleadoNombre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEmpleado
        '
        Me.lblEmpleado.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblEmpleado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblEmpleado.ForeColor = System.Drawing.Color.Navy
        Me.lblEmpleado.Location = New System.Drawing.Point(184, 88)
        Me.lblEmpleado.Name = "lblEmpleado"
        Me.lblEmpleado.Size = New System.Drawing.Size(248, 21)
        Me.lblEmpleado.TabIndex = 3
        Me.lblEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(46, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Usuario:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 67)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 14)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Nombre del usuario:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 91)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Empleado:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(16, 115)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(118, 14)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "Nombre del empleado:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 14)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Caja:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCaja
        '
        Me.lblCaja.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCaja.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCaja.ForeColor = System.Drawing.Color.Navy
        Me.lblCaja.Location = New System.Drawing.Point(184, 136)
        Me.lblCaja.Name = "lblCaja"
        Me.lblCaja.Size = New System.Drawing.Size(248, 21)
        Me.lblCaja.TabIndex = 9
        Me.lblCaja.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(109, 14)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Cadena de conexión:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblCadenaConexion
        '
        Me.lblCadenaConexion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblCadenaConexion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblCadenaConexion.ForeColor = System.Drawing.Color.Navy
        Me.lblCadenaConexion.Location = New System.Drawing.Point(184, 16)
        Me.lblCadenaConexion.Name = "lblCadenaConexion"
        Me.lblCadenaConexion.Size = New System.Drawing.Size(248, 21)
        Me.lblCadenaConexion.TabIndex = 11
        Me.lblCadenaConexion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRutaReportes
        '
        Me.lblRutaReportes.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblRutaReportes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRutaReportes.ForeColor = System.Drawing.Color.Navy
        Me.lblRutaReportes.Location = New System.Drawing.Point(184, 184)
        Me.lblRutaReportes.Name = "lblRutaReportes"
        Me.lblRutaReportes.Size = New System.Drawing.Size(248, 21)
        Me.lblRutaReportes.TabIndex = 13
        Me.lblRutaReportes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 187)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(119, 14)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Ruta para los reportes:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 163)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(128, 14)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Ruta local para reportes:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblReportesAppPath
        '
        Me.lblReportesAppPath.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblReportesAppPath.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblReportesAppPath.ForeColor = System.Drawing.Color.Navy
        Me.lblReportesAppPath.Location = New System.Drawing.Point(184, 160)
        Me.lblReportesAppPath.Name = "lblReportesAppPath"
        Me.lblReportesAppPath.Size = New System.Drawing.Size(248, 21)
        Me.lblReportesAppPath.TabIndex = 15
        Me.lblReportesAppPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblMaxHoraLiquidacion
        '
        Me.lblMaxHoraLiquidacion.BackColor = System.Drawing.Color.WhiteSmoke
        Me.lblMaxHoraLiquidacion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMaxHoraLiquidacion.ForeColor = System.Drawing.Color.Navy
        Me.lblMaxHoraLiquidacion.Location = New System.Drawing.Point(184, 232)
        Me.lblMaxHoraLiquidacion.Name = "lblMaxHoraLiquidacion"
        Me.lblMaxHoraLiquidacion.Size = New System.Drawing.Size(248, 21)
        Me.lblMaxHoraLiquidacion.TabIndex = 17
        Me.lblMaxHoraLiquidacion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 235)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(141, 14)
        Me.Label10.TabIndex = 18
        Me.Label10.Text = "Hora máxima para liquidar:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 211)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(166, 14)
        Me.Label11.TabIndex = 20
        Me.Label11.Text = "Regla de liquidación post-Fecha:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkReglaHoraMaximaLiquidacion
        '
        Me.chkReglaHoraMaximaLiquidacion.Enabled = False
        Me.chkReglaHoraMaximaLiquidacion.Location = New System.Drawing.Point(184, 208)
        Me.chkReglaHoraMaximaLiquidacion.Name = "chkReglaHoraMaximaLiquidacion"
        Me.chkReglaHoraMaximaLiquidacion.Size = New System.Drawing.Size(248, 24)
        Me.chkReglaHoraMaximaLiquidacion.TabIndex = 21
        Me.chkReglaHoraMaximaLiquidacion.Text = "Hora máxima de liquidación"
        '
        'frmInfoUsuario
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(538, 271)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.chkReglaHoraMaximaLiquidacion, Me.Label11, Me.Label10, Me.lblMaxHoraLiquidacion, Me.lblReportesAppPath, Me.lblRutaReportes, Me.lblCadenaConexion, Me.Label9, Me.lblCaja, Me.lblEmpleadoNombre, Me.lblEmpleado, Me.lblUsuarioNombre, Me.btnCerrar, Me.lblUsuario, Me.Label2, Me.Label3, Me.Label1, Me.Label8, Me.Label7, Me.Label6, Me.Label5})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmInfoUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Información del usuario"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmInfoUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblCadenaConexion.Text = Replace(ConString, "Password", Space(200))
        lblUsuario.Text = Main.GLOBAL_IDUsuario
        lblUsuarioNombre.Text = Main.GLOBAL_UsuarioNombre
        lblEmpleado.Text = Main.GLOBAL_IDEmpleado.ToString
        lblEmpleadoNombre.Text = Main.GLOBAL_EmpleadoNombre
        lblCaja.Text = Main.GLOBAL_CajaUsuario.ToString
        lblReportesAppPath.Text = Main.GLOBAL_ReportesAppPath.ToString
        lblRutaReportes.Text = Main.GLOBAL_RutaReportes
        Me.chkReglaHoraMaximaLiquidacion.Checked = Main.GLOBAL_ReglaHoraLiquidacion
        lblMaxHoraLiquidacion.Text = Main.GLOBAL_MaxHoraLiquidacion.ToShortTimeString

    End Sub
End Class
