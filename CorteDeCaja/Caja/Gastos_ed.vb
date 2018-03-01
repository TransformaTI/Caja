Imports System.Data
Imports System.Data.SqlClient

Public Class Gastos_ed
    Inherits System.Windows.Forms.Form
    Private cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Private dtSelect As New DataTable()
    Private daSelect As New SqlDataAdapter()
    Private rdrSelect As SqlDataReader
    Private VGD_MontoTopedeGastos As Decimal
    Private VGN_TipoFicha As Integer
    Private Monto As Decimal
    Private MontoDescuento As Decimal
    Private dcmMontoMaximo As Decimal
    Private Alta As Boolean
    Private MontoSaldos As Decimal
    Private MontoCheques As Decimal
    Private MontoChequesVencidosAnteriores As Decimal
    Private intCaja As Integer
    Private intTipoAplicacionIngreso As Integer
    Private blnAutorizar As Boolean = False

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call
        Me.intCaja = dmModulo.VGN_Caja


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
    Friend WithEvents lblTipoAplicacion As System.Windows.Forms.Label
    Friend WithEvents cmbTipoAplicacion As System.Windows.Forms.ComboBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblMontoMaximo As System.Windows.Forms.Label
    Friend WithEvents lblAutorizar As System.Windows.Forms.Label
    Friend WithEvents lblGastoMaximo As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonto As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Gastos_ed))
        Me.lblTipoAplicacion = New System.Windows.Forms.Label()
        Me.cmbTipoAplicacion = New System.Windows.Forms.ComboBox()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePicker2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.lblMontoMaximo = New System.Windows.Forms.Label()
        Me.lblAutorizar = New System.Windows.Forms.Label()
        Me.lblGastoMaximo = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblTipoAplicacion
        '
        Me.lblTipoAplicacion.AutoSize = True
        Me.lblTipoAplicacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipoAplicacion.Location = New System.Drawing.Point(34, 40)
        Me.lblTipoAplicacion.Name = "lblTipoAplicacion"
        Me.lblTipoAplicacion.Size = New System.Drawing.Size(93, 15)
        Me.lblTipoAplicacion.TabIndex = 0
        Me.lblTipoAplicacion.Text = "Tipo aplicación :"
        Me.lblTipoAplicacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbTipoAplicacion
        '
        Me.cmbTipoAplicacion.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoAplicacion.Location = New System.Drawing.Point(136, 36)
        Me.cmbTipoAplicacion.Name = "cmbTipoAplicacion"
        Me.cmbTipoAplicacion.Size = New System.Drawing.Size(289, 22)
        Me.cmbTipoAplicacion.TabIndex = 1
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = CType(resources.GetObject("btnAceptar.Image"), System.Drawing.Bitmap)
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(464, 16)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(104, 32)
        Me.btnAceptar.TabIndex = 9
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Bitmap)
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(464, 56)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(104, 32)
        Me.btnCancelar.TabIndex = 10
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker1.Location = New System.Drawing.Point(136, 104)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(142, 22)
        Me.DateTimePicker1.TabIndex = 11
        Me.DateTimePicker1.Value = New Date(2004, 12, 13, 0, 0, 0, 0)
        '
        'DateTimePicker2
        '
        Me.DateTimePicker2.Format = System.Windows.Forms.DateTimePickerFormat.Short
        Me.DateTimePicker2.Location = New System.Drawing.Point(136, 136)
        Me.DateTimePicker2.Name = "DateTimePicker2"
        Me.DateTimePicker2.Size = New System.Drawing.Size(142, 22)
        Me.DateTimePicker2.TabIndex = 12
        Me.DateTimePicker2.Value = New Date(2004, 12, 13, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(99, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(28, 15)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "De :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(112, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(15, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "a "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Blue
        Me.Label3.Location = New System.Drawing.Point(80, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Monto :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtMonto
        '
        Me.txtMonto.Font = New System.Drawing.Font("Tahoma", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonto.Location = New System.Drawing.Point(136, 67)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(138, 24)
        Me.txtMonto.TabIndex = 16
        Me.txtMonto.Text = "$0.00"
        '
        'lblMontoMaximo
        '
        Me.lblMontoMaximo.AutoSize = True
        Me.lblMontoMaximo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoMaximo.ForeColor = System.Drawing.Color.Maroon
        Me.lblMontoMaximo.Location = New System.Drawing.Point(10, 11)
        Me.lblMontoMaximo.Name = "lblMontoMaximo"
        Me.lblMontoMaximo.Size = New System.Drawing.Size(151, 15)
        Me.lblMontoMaximo.TabIndex = 17
        Me.lblMontoMaximo.Text = "Monto máximo a gastar"
        '
        'lblAutorizar
        '
        Me.lblAutorizar.AutoSize = True
        Me.lblAutorizar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblAutorizar.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutorizar.ForeColor = System.Drawing.Color.Maroon
        Me.lblAutorizar.Location = New System.Drawing.Point(10, 199)
        Me.lblAutorizar.Name = "lblAutorizar"
        Me.lblAutorizar.Size = New System.Drawing.Size(158, 17)
        Me.lblAutorizar.TabIndex = 18
        Me.lblAutorizar.Text = "GASTO POR AUTORIZAR"
        '
        'lblGastoMaximo
        '
        Me.lblGastoMaximo.AutoSize = True
        Me.lblGastoMaximo.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGastoMaximo.ForeColor = System.Drawing.Color.Black
        Me.lblGastoMaximo.Location = New System.Drawing.Point(497, 195)
        Me.lblGastoMaximo.Name = "lblGastoMaximo"
        Me.lblGastoMaximo.Size = New System.Drawing.Size(62, 15)
        Me.lblGastoMaximo.TabIndex = 19
        Me.lblGastoMaximo.Text = "     Monto"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(401, 195)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Monto Máximo:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Gastos_ed
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.CancelButton = Me.btnCancelar
        Me.ClientSize = New System.Drawing.Size(592, 222)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label4, Me.lblGastoMaximo, Me.lblAutorizar, Me.lblMontoMaximo, Me.txtMonto, Me.Label3, Me.Label2, Me.Label1, Me.DateTimePicker2, Me.DateTimePicker1, Me.btnAceptar, Me.btnCancelar, Me.cmbTipoAplicacion, Me.lblTipoAplicacion})
        Me.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.Name = "Gastos_ed"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Captura de gastos"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub Entrar(ByVal TipoFicha As Integer, ByVal Monto As Decimal, ByVal Alta As Boolean, Optional ByVal TipoAplicacionIngreso As Integer = 0)
        VGN_TipoFicha = TipoFicha
        Me.intTipoAplicacionIngreso = TipoAplicacionIngreso

        DateTimePicker1.Text = dmModulo.VGS_FOperacion
        DateTimePicker2.Text = dmModulo.VGS_FOperacion

        VGD_MontoTopedeGastos = Monto

        MontoMaximo()
        lblMontoMaximo.Text = "Monto máximo a gastar  " + VGD_MontoTopedeGastos.ToString("C")
        Me.Alta = Alta
        txtMonto.Text = VGD_MontoTopedeGastos.ToString("C")

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spTipoAplicacionIngreso"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@TipoAplicacionIngreso", SqlDbType.Int).Value = TipoAplicacionIngreso
            cmdCommand.Parameters.Add("@Caja", SqlDbType.TinyInt).Value = intCaja
            cmdCommand.ExecuteNonQuery()
            daSelect.SelectCommand = cmdCommand
            daSelect.Fill(dtSelect)

            cmbTipoAplicacion.DataSource = dtSelect
            cmbTipoAplicacion.ValueMember = "TipoAplicacionIngreso"
            cmbTipoAplicacion.DisplayMember = "Descripcion"        

            'If Not (Alta) And TipoAplicacionIngreso <> 0 Then

            '    cmdCommand.CommandType = CommandType.Text
            '    cmdCommand.CommandText = "Select Total from CorteCajaAplicacion Where Caja = @Caja and FOperacion = @FOperacion and TipoAplicacionIngreso = @TipoAplicacionIngreso "
            '    cmdCommand.Parameters.Clear()
            '    cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = me.intCaja
            '    cmdCommand.Parameters.Add("@Foperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
            '    cmdCommand.Parameters.Add("@TipoAplicacionIngreso", SqlDbType.Int).Value = TipoAplicacionIngreso
            '    rdrSelect = cmdCommand.ExecuteReader
            '    rdrSelect.Read()

            '    txtMonto.Text = CType(rdrSelect("Total"), Decimal).ToString("C")
            '    cmbTipoAplicacion.SelectedValue = TipoAplicacionIngreso
            '    rdrSelect.Close()

            'End If
        Catch e As Exception
            MsgBox(e.Message)
        End Try

        If Not (Descuentos()) And (Alta) And MontoDescuento > 0 Then
            If MessageBox.Show("¿Desea dar de alta en automatico descuentos por pronto pago por " + MontoDescuento.ToString("C") + "?", "Gastos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                AplicacionesAltaModifica(28, MontoDescuento, "AUTORIZADO")
                Me.Close()
            End If
        ElseIf Not (SaldosAFavorAplicados()) And (Alta) And MontoSaldos > 0 Then
            If MessageBox.Show("¿Desea dar de alta en automatico SALDO A FAVOR APLICADO por " + MontoSaldos.ToString("C") + "?", "Gastos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                AplicacionesAltaModifica(52, MontoSaldos, "AUTORIZADO")
                Me.Close()
            End If
        ElseIf Not (ChequesPosfechados()) And (Alta) And MontoCheques > 0 Then
            If MessageBox.Show("Tiene un saldo de cheques posfechados por  " + MontoCheques.ToString("C") + ", automáticamente se dará de alta.", "Gastos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
                AplicacionesAltaModifica(54, MontoCheques, "AUTORIZADO")
                Me.Close()
            End If
            'ElseIf Not (ChequesPosfechadosVencidosAnteriores()) And (Alta) And MontoChequesVencidosAnteriores > 0 Then
            '    If MessageBox.Show("Tiene un saldo de cheques posfechados por  " + MontoCheques.ToString("C") + ", automáticamente se dará de alta.", "Gastos", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            '        'AplicacionesAltaModifica(55, MontoCheques, "AUTORIZADO")
            '        Me.Close()
            '    End If
        Else
            If VGD_MontoTopedeGastos = 0 Then
                MessageBox.Show("El monto es CERO, NO SE PUEDE REALIZAR LA OPERACIÓN.", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Me.ShowDialog()
            End If
        End If


    End Sub
    

    Private Sub VerificarMontoAutorizado()
        MontoMaximo()

        If CType(txtMonto.Text.Trim, Double) > dcmMontoMaximo Then
            lblGastoMaximo.Text = Format(dcmMontoMaximo, "c")
            Me.Width = 600
            Me.Height = 248
        ElseIf CType(txtMonto.Text.Trim, Decimal) < dcmMontoMaximo Then
            Me.Width = 600
            Me.Height = 192
        End If
    End Sub


    Private Function Descuentos() As Boolean
        Dim ExisteDescuento As Boolean

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSExisteDescuentosenCaja"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Char).Value = dmModulo.VGN_Consecutivo
            If dmModulo.VGN_TipoCorte = 2 Then
                cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = dmModulo.VGN_TipoCorte
            End If
            rdrSelect = cmdCommand.ExecuteReader
            rdrSelect.Read()

            ExisteDescuento = CType(rdrSelect("ExisteDescuento"), Boolean)
            MontoDescuento = CType(rdrSelect("MontoDescuento"), Decimal)
            rdrSelect.Close()
            Return ExisteDescuento

        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Function

    Private Function SaldosAFavorAplicados() As Boolean
        Dim Existe As Boolean

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSExisteSaldos"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Char).Value = dmModulo.VGN_Consecutivo
            If dmModulo.VGN_TipoCorte = 2 Then
                cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = dmModulo.VGN_TipoCorte
            End If
            rdrSelect = cmdCommand.ExecuteReader
            rdrSelect.Read()

            Existe = CType(rdrSelect("Existe"), Boolean)
            MontoSaldos = CType(rdrSelect("Monto"), Decimal)
            rdrSelect.Close()
            Return Existe

        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Function

    Private Function ChequesPosfechadosVencidosAnteriores() As Boolean
        Dim Existe As Boolean

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSExisteSaldosChequesPosfechadosVencidosAnteriores"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Char).Value = dmModulo.VGN_Consecutivo
            If dmModulo.VGN_TipoCorte = 2 Then
                cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = dmModulo.VGN_TipoCorte
            End If
            rdrSelect = cmdCommand.ExecuteReader
            rdrSelect.Read()

            Existe = CType(rdrSelect("Existe"), Boolean)
            MontoCheques = CType(rdrSelect("Monto"), Decimal)
            rdrSelect.Close()
            Return Existe

        Catch e As Exception
            MsgBox(e.Message)
        End Try
    End Function

    Private Function ChequesPosfechados() As Boolean
        Dim Existe As Boolean

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSExisteSaldosChequesPosfechados"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            cmdCommand.Parameters.Add("@FOperacion", SqlDbType.Char).Value = CType(dmModulo.VGS_FOperacion, String)
            cmdCommand.Parameters.Add("@Consecutivo", SqlDbType.Char).Value = dmModulo.VGN_Consecutivo
            If dmModulo.VGN_TipoCorte = 2 Then
                cmdCommand.Parameters.Add("@TipoCorte", SqlDbType.Int).Value = dmModulo.VGN_TipoCorte
            End If
            rdrSelect = cmdCommand.ExecuteReader
            rdrSelect.Read()

            Existe = CType(rdrSelect("Existe"), Boolean)
            MontoCheques = CType(rdrSelect("Monto"), Decimal)
            rdrSelect.Close()
            Return Existe

        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Function

    Private Sub txtMonto_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonto.Leave
        Monto = CType(txtMonto.Text.Trim, Decimal)
        txtMonto.Text = Monto.ToString("C")
        VerificarMontoAutorizado()
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click
        If (CType(txtMonto.Text, Decimal) <= VGD_MontoTopedeGastos) Or Not (Alta) Then
            If CType(txtMonto.Text.Trim, Decimal) < dcmMontoMaximo Or blnAutorizar = True Then
                AplicacionesAltaModifica(CType(cmbTipoAplicacion.SelectedValue, Integer), CType(txtMonto.Text, Decimal), "AUTORIZADO")
            ElseIf CType(txtMonto.Text.Trim, Decimal) > dcmMontoMaximo Then
                AplicacionesAltaModifica(CType(cmbTipoAplicacion.SelectedValue, Integer), CType(txtMonto.Text, Decimal), "PENDIENTE")
                MessageBox.Show("Gasto por autorizar, verifique.", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
            Me.Close()
        Else
            MessageBox.Show("El monto del gasto es mayor al efectivo pendiente, verifique.", "Gastos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    'Verifica cual es el monto máximo para realizar un gasto
    Private Sub MontoMaximo()
        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSSCorteCajaGastoMaximo"
        cmdCommand.Parameters.Clear()

        rdrSelect = cmdCommand.ExecuteReader
        If rdrSelect.Read() Then
            dcmMontoMaximo = CType(rdrSelect("Valor"), Decimal)
        End If
        rdrSelect.Close()
        lblGastoMaximo.Text = dcmMontoMaximo.ToString("c")
    End Sub

    Private Sub AplicacionesAltaModifica(ByVal TipoAplicacion As Integer, ByVal Monto As Decimal, ByVal Status As String)
        ''Dim Consecutivo As Int16

        With cmdCommand
            .Parameters.Clear()
            .CommandType = CommandType.StoredProcedure
            .CommandText = "spSSCorteCajaAltaModificaGastos"
            .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
            .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
            .Parameters.Add("@FOperacion", SqlDbType.Char).Value = dmModulo.VGS_FOperacion
            .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = dmModulo.VGN_Consecutivo
            .Parameters.Add("@TipoAplicacionIngreso", SqlDbType.Int).Value = TipoAplicacion
            .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = VGN_TipoFicha
            .Parameters.Add("@Total", SqlDbType.Money).Value = Monto
            .Parameters.Add("@Status", SqlDbType.Char).Value = Status
            Try
                .ExecuteNonQuery()
            Catch eg As Exception
                MsgBox(eg.Message)
            End Try
        End With
    End Sub

    Private Sub cmbTipoAplicacion_SelectionChangeCommitted(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoAplicacion.SelectionChangeCommitted
        Dim TipoAplicacion As Integer
        Dim daSelect As New SqlDataAdapter()
        Dim dtTipoAplicacion As New DataTable()
        ''Dim rdrSelect As SqlDataReader
        Dim rowTipoAplicacion As DataRow

        cmdCommand.CommandType = CommandType.StoredProcedure
        cmdCommand.CommandText = "spSelectTipoAplicacionIngreso"
        cmdCommand.Parameters.Clear()
        cmdCommand.Parameters.Add("@TipoAplicacionIngreso", SqlDbType.Int).Value = intTipoAplicacionIngreso
        cmdCommand.ExecuteNonQuery()
        daSelect.SelectCommand = cmdCommand
        daSelect.Fill(dtTipoAplicacion)

        'Se verifica que Tipos de Aplicación Ingresos se pueden dar de alta sin necesidad de autorizar
        'cuando su monto excede el monto permitido
        For Each rowTipoAplicacion In dtTipoAplicacion.Rows
            TipoAplicacion = CType(rowTipoAplicacion.Item("TipoAplicacionIngreso"), Integer)
            If cmbTipoAplicacion.SelectedValue <> TipoAplicacion Then
                VerificarMontoAutorizado()
            Else
                Me.Width = 600
                Me.Height = 192
                blnAutorizar = True
                Exit For
            End If
        Next
    End Sub

End Class
