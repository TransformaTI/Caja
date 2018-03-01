Imports System.Data
Imports System.Data.SqlClient

Public Class PosfecharCheques

    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private dtSelect As DataTable
    Private daSelect As New SqlDataAdapter()
    Private drLeer As SqlDataReader
    Private VGN_AñoCobro As Integer
    Private VGN_CobroCheque As Integer
    Private VGS_NumeroCheque As String


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
    Friend WithEvents imgMain As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents PersistentRepository1 As DevExpress.XtraEditors.Repository.PersistentRepository
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents txtFecha As System.Windows.Forms.TextBox
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    Friend WithEvents dtFechaCheque As DevExpress.XtraEditors.DateEdit
    Friend WithEvents txtNumeroCheque As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(PosfecharCheques))
        Me.imgMain = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtFechaCheque = New DevExpress.XtraEditors.DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtFecha = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtNumeroCheque = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.PersistentRepository1 = New DevExpress.XtraEditors.Repository.PersistentRepository()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dtFechaCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'imgMain
        '
        Me.imgMain.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.imgMain.ImageSize = New System.Drawing.Size(16, 16)
        Me.imgMain.TransparentColor = System.Drawing.Color.Transparent
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1})
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(278, 208)
        Me.Panel1.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.dtFechaCheque, Me.Label2})
        Me.GroupBox2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox2.Location = New System.Drawing.Point(8, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(256, 56)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Posfechar"
        '
        'dtFechaCheque
        '
        Me.dtFechaCheque.DateTime = New Date(2003, 12, 9, 0, 0, 0, 0)
        Me.dtFechaCheque.Location = New System.Drawing.Point(120, 18)
        Me.dtFechaCheque.Name = "dtFechaCheque"
        Me.dtFechaCheque.Properties.Buttons.Add(New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo))
        Me.dtFechaCheque.Size = New System.Drawing.Size(120, 21)
        Me.dtFechaCheque.TabIndex = 18
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(16, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 15)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Fecha Deposito :"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.txtFecha, Me.Label1, Me.txtMonto, Me.Label6, Me.txtNumeroCheque, Me.Label4})
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Location = New System.Drawing.Point(8, 16)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(256, 112)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Datos Cheque"
        '
        'txtFecha
        '
        Me.txtFecha.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFecha.ForeColor = System.Drawing.Color.Black
        Me.txtFecha.Location = New System.Drawing.Point(120, 80)
        Me.txtFecha.MaxLength = 10
        Me.txtFecha.Name = "txtFecha"
        Me.txtFecha.ReadOnly = True
        Me.txtFecha.Size = New System.Drawing.Size(120, 20)
        Me.txtFecha.TabIndex = 19
        Me.txtFecha.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(16, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(47, 15)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Monto :"
        '
        'txtMonto
        '
        Me.txtMonto.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtMonto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMonto.ForeColor = System.Drawing.Color.Black
        Me.txtMonto.Location = New System.Drawing.Point(120, 48)
        Me.txtMonto.MaxLength = 10
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.ReadOnly = True
        Me.txtMonto.Size = New System.Drawing.Size(120, 20)
        Me.txtMonto.TabIndex = 18
        Me.txtMonto.Text = ""
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label6.Location = New System.Drawing.Point(16, 24)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(76, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "No. Cheque :"
        '
        'txtNumeroCheque
        '
        Me.txtNumeroCheque.BackColor = System.Drawing.SystemColors.HighlightText
        Me.txtNumeroCheque.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumeroCheque.ForeColor = System.Drawing.Color.Black
        Me.txtNumeroCheque.Location = New System.Drawing.Point(120, 16)
        Me.txtNumeroCheque.MaxLength = 10
        Me.txtNumeroCheque.Name = "txtNumeroCheque"
        Me.txtNumeroCheque.ReadOnly = True
        Me.txtNumeroCheque.Size = New System.Drawing.Size(120, 20)
        Me.txtNumeroCheque.TabIndex = 12
        Me.txtNumeroCheque.Text = ""
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(16, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 15)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Fecha Original :"
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(144, 222)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(75, 26)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(48, 222)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 27)
        Me.btnAceptar.TabIndex = 4
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PosfecharCheques
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(278, 260)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnCancelar, Me.btnAceptar, Me.Panel1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PosfecharCheques"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cheques"
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dtFechaCheque, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Public Sub New(ByVal NumeroCheque As String, ByVal Monto As Decimal, ByVal fecha As String, ByVal Año As Integer, ByVal Cobro As Integer)
        MyBase.New()
        InitializeComponent()
        txtNumeroCheque.Text = CType(NumeroCheque, String)
        txtMonto.Text = Monto.ToString("c")
        txtFecha.Text = CType(fecha, String)
        NumeroCheque = NumeroCheque
        VGN_AñoCobro = Año
        VGS_NumeroCheque = NumeroCheque
        VGN_CobroCheque = Cobro
        dtFechaCheque.DateTime = Now

        Me.ShowDialog()
    End Sub


    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandTimeout = 0
            cmdCommand.CommandText = "spSSActualizaFechaCheques"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@AñoCobro", SqlDbType.Int).Value = VGN_AñoCobro
            cmdCommand.Parameters.Add("@Cobro", SqlDbType.Int).Value = VGN_CobroCheque
            cmdCommand.Parameters.Add("@FDeposito", SqlDbType.DateTime).Value = dtFechaCheque.DateTime.Date
            cmdCommand.Parameters.Add("@NumeroCheque", SqlDbType.Char).Value = VGS_NumeroCheque.Trim
            cmdCommand.ExecuteNonQuery()
        Catch a As Exception
            MessageBox.Show(a.Message)
        End Try
        Me.Close()

    End Sub


End Class
