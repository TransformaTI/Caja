Imports System.Data.SqlClient

Public Class Autorizar
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private rdrSelect As SqlDataReader

    Private intTipoFicha, intTipoAplicacionIngreso, intConsecutivoTipoAplicacion As Integer
    Private dcmMonto As Decimal
    Private strAccion As String
    Private datFOperacion As Date
    Private intCaja As Integer
    Private intConsecutivo As Integer

#Region " Windows Form Designer generated code "

    Public Sub New(ByVal Caja As Integer, ByVal Consecutivo As Integer, ByVal TipoFicha As Integer, ByVal TipoAplicacionIngreso As Integer, ByVal ConsecutivoTipoAplicacion As Integer, ByVal Monto As Decimal, ByVal Accion As String, ByVal FOperacion As Date)
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.intTipoFicha = TipoFicha
        Me.intTipoAplicacionIngreso = TipoAplicacionIngreso
        Me.intConsecutivoTipoAplicacion = ConsecutivoTipoAplicacion
        Me.dcmMonto = Monto
        Me.strAccion = Accion
        Me.datFOperacion = FOperacion
        Me.intCaja = Caja
        Me.intConsecutivo = Consecutivo
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents txtClave As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtObservaciones As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Autorizar))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtClave = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(58, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Usuario:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(69, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(35, 14)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Clave:"
        '
        'txtUsuario
        '
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(104, 16)
        Me.txtUsuario.MaxLength = 15
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(176, 23)
        Me.txtUsuario.TabIndex = 0
        Me.txtUsuario.Text = "ULESRO"
        '
        'txtClave
        '
        Me.txtClave.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtClave.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClave.Location = New System.Drawing.Point(104, 48)
        Me.txtClave.MaxLength = 15
        Me.txtClave.Name = "txtClave"
        Me.txtClave.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.txtClave.Size = New System.Drawing.Size(176, 23)
        Me.txtClave.TabIndex = 1
        Me.txtClave.Text = ""
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Bitmap)
        Me.PictureBox1.Location = New System.Drawing.Point(8, 16)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(40, 32)
        Me.PictureBox1.TabIndex = 6
        Me.PictureBox1.TabStop = False
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(296, 48)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.TabIndex = 8
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(296, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.TabIndex = 7
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 14)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Observaciones:"
        '
        'txtObservaciones
        '
        Me.txtObservaciones.Location = New System.Drawing.Point(104, 80)
        Me.txtObservaciones.Multiline = True
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(176, 64)
        Me.txtObservaciones.TabIndex = 10
        Me.txtObservaciones.Text = ""
        '
        'Autorizar
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(386, 160)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtObservaciones, Me.Label3, Me.btnCancelar, Me.btnAceptar, Me.PictureBox1, Me.txtClave, Me.txtUsuario, Me.Label2, Me.Label1})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Autorizar"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acceso para autorizar gasto"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub txtUsuario_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtUsuario.Enter
        txtUsuario.SelectAll()
        If strAccion = "AUTORIZAR" Then
            Me.Text = "Acceso para autorizar gasto"
        ElseIf strAccion = "RECHAZAR" Then
            Me.Text = "Acceso para rechazar gasto"
        ElseIf strAccion = "CANCELAR" Then
            Me.Text = "Acceso para cancelar gasto"
        End If
    End Sub

    Private Sub txtClave_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClave.Enter
        txtClave.SelectAll()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Dim strUsuario As String
        Dim strClave As String

        strUsuario = ""
        strClave = ""

        cmdCommand.CommandType = CommandType.Text
        cmdCommand.CommandText = "Select Valor From Parametro Where Modulo=3 and Parametro='AutorizaMontoMaximo'"
        cmdCommand.Parameters.Clear()

        rdrSelect = cmdCommand.ExecuteReader
        If rdrSelect.Read() Then
            strUsuario = rdrSelect("Valor").ToString()
        End If
        rdrSelect.Close()

        cmdCommand.CommandType = CommandType.Text
        cmdCommand.CommandText = "Select Clave From Usuario Where Usuario ='" & strUsuario & "'"
        cmdCommand.Parameters.Clear()

        rdrSelect = cmdCommand.ExecuteReader
        If rdrSelect.Read() Then
            strClave = rdrSelect("Clave").ToString()
        End If
        rdrSelect.Close()

        If txtUsuario.Text = strUsuario And txtClave.Text = Trim(strClave) Then
            'If strAccion = "AUTORIZAR" Then
            Try
                With cmdCommand
                    .Parameters.Clear()
                    .CommandType = CommandType.StoredProcedure
                    .CommandText = "spSSStatusCorteCajaAplicacion"
                    .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                    .Parameters.Add("@Caja", SqlDbType.Int).Value = Me.intCaja
                    .Parameters.Add("@FOperacion", SqlDbType.Char).Value = datFOperacion
                    .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = intConsecutivo
                    .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = intTipoFicha
                    .Parameters.Add("@TipoAplicacionIngreso", SqlDbType.Int).Value = intTipoAplicacionIngreso
                    .Parameters.Add("@ConsecutivoTipoAplicacion", SqlDbType.Int).Value = intConsecutivoTipoAplicacion
                    .Parameters.Add("@Monto", SqlDbType.Money).Value = dcmMonto
                    If strAccion = "AUTORIZAR" Then
                        .Parameters.Add("@Accion", SqlDbType.Int).Value = 0  'Autoriza el gasto que sobrepasa el monto máximo
                    ElseIf strAccion = "RECHAZAR" Then
                        .Parameters.Add("@Accion", SqlDbType.Int).Value = 1  'Rechaza el gasto que sobrepasa el monto máximo
                    ElseIf strAccion = "CANCELAR" Then
                        .Parameters.Add("@Accion", SqlDbType.Int).Value = 2 'Cancela el gasto que sobrepasa el monto máximo
                    End If
                    .Parameters.Add("@Observaciones", SqlDbType.Char).Value = txtObservaciones.Text
                    .ExecuteNonQuery()
                End With
            Catch er As Exception
                MsgBox(er.Message)
            End Try
            If strAccion = "CANCELAR" Then
                Try
                    With cmdCommand
                        .Parameters.Clear()
                        .CommandType = CommandType.StoredProcedure
                        .CommandText = "spSSEliminaCorteCajaAplicacion"
                        .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                        .Parameters.Add("@Caja", SqlDbType.Int).Value = Me.intCaja
                        .Parameters.Add("@FOperacion", SqlDbType.Char).Value = datFOperacion
                        .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
                        .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = intTipoFicha
                        .Parameters.Add("@TipoAplicacionIngreso", SqlDbType.Int).Value = intTipoAplicacionIngreso
                        .Parameters.Add("@ConsecutivoTipoAplicacion", SqlDbType.Int).Value = intConsecutivoTipoAplicacion
                        .Parameters.Add("@Monto", SqlDbType.Money).Value = dcmMonto
                        .Parameters.Add("@Cancelar", SqlDbType.Bit).Value = True
                        .ExecuteNonQuery()
                    End With
                Catch er As Exception
                    MsgBox(er.Message)
                End Try
            End If
        Else
            MessageBox.Show("Usuario o contraseña incorrectos, verifique.", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Me.Close()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

End Class
