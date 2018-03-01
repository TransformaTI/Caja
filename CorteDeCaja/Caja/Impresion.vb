Imports System.Data
Imports System.Data.SqlClient
Public Class Impresion
    Inherits System.Windows.Forms.Form
    Dim Transaccion As SqlTransaction
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private daSelect As SqlDataAdapter
    Private dtUsiario As New DataTable()
    Private comprobante As Integer
    Public Imprime As Boolean
    Public cajera As String
#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents grpInfoCentro As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents cboUsuario As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Impresion))
        Me.grpInfoCentro = New System.Windows.Forms.GroupBox()
        Me.cboUsuario = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.grpInfoCentro.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpInfoCentro
        '
        Me.grpInfoCentro.Controls.AddRange(New System.Windows.Forms.Control() {Me.cboUsuario})
        Me.grpInfoCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpInfoCentro.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpInfoCentro.Location = New System.Drawing.Point(8, 32)
        Me.grpInfoCentro.Name = "grpInfoCentro"
        Me.grpInfoCentro.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grpInfoCentro.Size = New System.Drawing.Size(272, 48)
        Me.grpInfoCentro.TabIndex = 115
        Me.grpInfoCentro.TabStop = False
        Me.grpInfoCentro.Text = "Cajera"
        '
        'cboUsuario
        '
        Me.cboUsuario.BackColor = System.Drawing.Color.White
        Me.cboUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsuario.ItemHeight = 16
        Me.cboUsuario.Location = New System.Drawing.Point(8, 16)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(256, 24)
        Me.cboUsuario.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(312, 24)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 30)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Imprimir"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(312, 72)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 3
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Impresion
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(410, 112)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnAceptar, Me.btnCancelar, Me.grpInfoCentro})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Impresion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Comprobante Servcio"
        Me.TopMost = True
        Me.grpInfoCentro.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        cajera = cboUsuario.SelectedValue.ToString()
        Imprime = True
        Me.Close()
    End Sub
    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Imprime = False
        Me.Close()
    End Sub
    Public Sub Entrar(ByVal Comp As Integer)
        comprobante = Comp
        Me.ShowDialog()
    End Sub
    Private Sub Impresion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        daSelect = New SqlDataAdapter()
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spssUsuariosCaja"
        daSelect.SelectCommand = cmdCommand
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@Comprobante", SqlDbType.Int).Value = comprobante
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtUsiario)
        cboUsuario.DataSource = dtUsiario
        cboUsuario.ValueMember = "USUARIO"
        cboUsuario.DisplayMember = "NOMBRE"
        cmdCommand.ExecuteReader()
    End Sub
End Class
