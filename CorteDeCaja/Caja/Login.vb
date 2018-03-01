Imports System.IO
Public Class Login
    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

        'Numero de version
        Me.Text = "Acceso modulo [Caja] " & Me.GetType.Assembly.GetName.Version.ToString

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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Login))
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Image)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(72, 104)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 2
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(168, 104)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(68, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(68, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Clave:"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(120, 21)
        Me.txtUsuario.MaxLength = 15
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(120, 23)
        Me.txtUsuario.TabIndex = 0
        '
        'txtClave
        '
        Me.txtClave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(120, 61)
        Me.txtClave.MaxLength = 15
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(120, 23)
        Me.txtClave.TabIndex = 1
        '
        'PictureBox2
        '
        Me.PictureBox2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(16, 25)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox2.TabIndex = 1
        Me.PictureBox2.TabStop = False
        '
        'Login
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(306, 146)
        Me.Controls.Add(Me.txtClave)
        Me.Controls.Add(Me.txtUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Login"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso modulo [Caja]"
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim strConnection As String
        Dim Registro As Integer
        dmModulo.Conexion = False
        strConnection = ""
        dmModulo.strConnection = ""
        dmModulo.CadenaConexion(RTrim(txtUsuario.Text), RTrim(txtClave.Text))
        strConnection = dmModulo.strConnection

        Try
            dmModulo.SqlConnection.ConnectionString = strConnection
            dmModulo.SqlConnection.Open()
            Conexion = True
        Catch dataException As Exception
            MessageBox.Show("No se ha podido conectar a la base de datos. Verifique con el administrador del sistema." + Chr(13) + _
                        "Detalles : " + Chr(13) + dataException.Message, "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
        End Try

        If dmModulo.Conexion = True Then
            Dim cmdInsert As New SqlClient.SqlCommand()
            Dim rdrInsert As SqlClient.SqlDataReader

            Try
                cmdInsert.Connection = dmModulo.SqlConnection
                cmdInsert.CommandTimeout = 30
                cmdInsert.CommandType = CommandType.StoredProcedure
                cmdInsert.CommandText = "spSSExisteUsuario"
                cmdInsert.Parameters.Clear()
                cmdInsert.Parameters.Add("@Usuario", SqlDbType.Char).Value = RTrim(txtUsuario.Text)
                cmdInsert.Parameters.Add("@Clave", SqlDbType.Char).Value = RTrim(txtClave.Text)
                rdrInsert = cmdInsert.ExecuteReader
                rdrInsert.Read()
                Registro = CType(rdrInsert("Registro"), Integer)
                rdrInsert.Close()

                Registro = 1

                If Registro > 0 Then
                    Dim frmSplash As splash = New splash()
                    frmSplash.Show()
                    Application.DoEvents()
                    cmdInsert.Connection = dmModulo.SqlConnection
                    cmdInsert.CommandType = CommandType.StoredProcedure
                    cmdInsert.CommandText = "spSSDatosUsuario"
                    cmdInsert.Parameters.Clear()
                    cmdInsert.Parameters.Add("@Usuario", SqlDbType.Char).Value = RTrim(txtUsuario.Text)
                    cmdInsert.Parameters.Add("@Clave", SqlDbType.Char).Value = RTrim(txtClave.Text)
                    rdrInsert = cmdInsert.ExecuteReader
                    rdrInsert.Read()

                    dmModulo._Celula = CType(rdrInsert("Celula"), Integer)
                    dmModulo._Nombre = CType(rdrInsert("Nombre"), String)
                    dmModulo._Usuario = CType(rdrInsert("Usuario"), String)
                    dmModulo._DesCentroCosto = CType(rdrInsert("DesCelula"), String)
                    dmModulo._blnAdministrador = True
                    dmModulo._TipoUsuario = "Administrador"
                    dmModulo._Servidor = dmModulo.SqlConnection.DataSource
                    dmModulo._DB = dmModulo.SqlConnection.Database
                    rdrInsert.Close()

                    cmdInsert.Connection = dmModulo.SqlConnection
                    cmdInsert.CommandType = CommandType.StoredProcedure
                    cmdInsert.CommandText = "spSSSelectCajaUsuario"
                    cmdInsert.Parameters.Clear()
                    cmdInsert.Parameters.Add("@Usuario", SqlDbType.Char).Value = RTrim(txtUsuario.Text)
                    rdrInsert = cmdInsert.ExecuteReader

                    If rdrInsert.Read() Then
                        dmModulo.VGN_Caja = CType(rdrInsert("Caja"), Integer)
                        dmModulo._DesCaja = CType(rdrInsert("Descripcion"), String)
                    Else
                        dmModulo.VGN_Caja = 1
                    End If

                    dmModulo.SqlConnection.Close()
                    rdrInsert.Close()
                    cmdInsert.Dispose()
                    Me.Visible = False
                    frmSplash.Close()
                    frmSplash.Dispose()
                    Me.Close()
                Else
                    MessageBox.Show("No existe su cuenta de usuario en el sistema o no es un usuario activo.",
                                    "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
                End If
            Catch Ex As Exception
                MessageBox.Show("Se genero el siguiente error: " + Ex.Message, "Botón aceptar",
                                MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If

    End Sub

    Private Sub txtUsuario_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario.Enter
        txtUsuario.SelectAll()
    End Sub

    Private Sub txtClave_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.Enter
        txtClave.SelectAll()
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class
