Imports System.Collections.Generic

Public Class frmRemisiones
    Private i As Integer
    Private FilaAbono As Integer
    Private _Total As Decimal
    Private _Saldo As Decimal
    Private _TablaRemisiones As DataTable
    Private _FilaSaldo As Integer
    Public AceptarAbono As Boolean
    Dim Cancelar As New List(Of String)
    Dim table As New DataTable
    Dim fila As DataRow
    Dim column As DataColumn
    Dim row As DataRow
    Private _UltimoCobro As SigaMetClasses.CobroDetalladoDatos
    Private _TablaRemisionesInicial As DataTable
    Private _SumImportesSaldo As Decimal
    Private _AceptaSaldo As Boolean
    Private _CancelPago As Boolean
    Dim oCobroRemision As SigaMetClasses.CobroRemisiones
    Private _ListaCobroRemisiones As New List(Of SigaMetClasses.CobroRemisiones)
    Private _Tipocobro As Integer

    Private _Pago As Integer
    Public Property Pago() As Integer
        Get
            Return _Pago
        End Get
        Set(ByVal value As Integer)
            _Pago = value
        End Set
    End Property


    Public Property CobroRemisiones() As List(Of SigaMetClasses.CobroRemisiones)
        Get
            Return _ListaCobroRemisiones
        End Get
        Set(ByVal value As List(Of SigaMetClasses.CobroRemisiones))
            _ListaCobroRemisiones = value
        End Set
    End Property



    Public Property UltimoCobro() As SigaMetClasses.CobroDetalladoDatos
        Get
            Return _UltimoCobro
        End Get
        Set(value As SigaMetClasses.CobroDetalladoDatos)
            _UltimoCobro = value
        End Set
    End Property

    Public Property ObtenerRemisiones() As DataTable
        Get
            Return _TablaRemisiones
        End Get
        Set(value As DataTable)
            _TablaRemisiones = value
        End Set
    End Property

    Public Property TipoCobro() As Integer
        Get
            Return _Tipocobro
        End Get
        Set(value As Integer)
            _Tipocobro = value
        End Set
    End Property

    Public Property AceptaSaldo() As Boolean
        Get
            Return _AceptaSaldo
        End Get
        Set(ByVal value As Boolean)
            _AceptaSaldo = value
        End Set
    End Property

    Public Property CancelarFormaPago() As Boolean
        Get
            Return _CancelPago
        End Get
        Set(value As Boolean)
            _CancelPago = value
        End Set
    End Property


    Public Sub New(Total As Decimal)
        ' This call is required by the designer.
        InitializeComponent()
        _Total = Total
        _Saldo = _Total
        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New()
    End Sub

    Private Sub frmRemisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'grdRemision.AutoGenerateColumns = False
        Try
            Dim row As DataRow
            If Not _TablaRemisiones Is Nothing Then
                For Each row In _TablaRemisiones.Rows
                    Cancelar.Add(CType(row("Saldo"), String))
                Next
                _TablaRemisionesInicial = _TablaRemisiones
                lbl_Total.Text = "$" + CType(_Total, String)
                lbl_saldo.Text = "$" + CType(_Total, String)
                ' Create new DataColumn, set DataType, ColumnName 
                ' and add to DataTable.    
                'Dim keys(2) As DataColumn
                Dim keys(3) As DataColumn
                column = New DataColumn
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Serie"
                table.Columns.Add(column)
                keys(0) = column
                column = New DataColumn
                column.DataType = Type.GetType("System.String")
                column.ColumnName = "Remisión"
                table.Columns.Add(column)
                keys(1) = column

                ' Se agrega la columna y llame producto RM_30_07_2018
                column = New DataColumn
                column.DataType = System.Type.GetType("System.String")
                column.ColumnName = "Producto"
                table.Columns.Add(column)
                keys(2) = column

                column = New DataColumn
                column.DataType = Type.GetType("System.String")
                column.ColumnName = "Importe abonado"
                table.Columns.Add(column)
                table.PrimaryKey = keys
                Dim keysRemiesiones(3) As DataColumn
                keysRemiesiones(0) = _TablaRemisiones.Columns(0)
                keysRemiesiones(1) = _TablaRemisiones.Columns(1)
                keysRemiesiones(2) = _TablaRemisiones.Columns("Producto")
                _TablaRemisiones.PrimaryKey = keysRemiesiones
                grdRemision.DataSource = Nothing
                grdRemision.DataSource = _TablaRemisiones
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error al cargar los datos")
        End Try

    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        Dim SaldoAbonado As Decimal
        SaldoAbonado = CDec(grdRemision.Item(i, 7))
        If SaldoAbonado > 0 Then
            If _Saldo > 0 Then
                Try
                    row = table.NewRow
                    row("Serie") = grdRemision.Item(i, 0)
                    row("Remisión") = grdRemision.Item(i, 1)
                    row("Producto") = grdRemision.Item(i, 11)

                    If _Saldo >= CDec(grdRemision.Item(i, 7)) Then
                        row("Importe abonado") = grdRemision.Item(i, 7)
                    Else
                        row("Importe abonado") = _Saldo.ToString
                    End If

                    table.Rows.Add(row)
                    grdAbonos.DataSource = table
                    Dim fila As DataRow
                    fila = _TablaRemisiones.Rows(_FilaSaldo)

                    If _Saldo > 0 Then
                        If _Saldo >= CDec(grdRemision.Item(i, 7)) Then
                            _SumImportesSaldo += CDec(grdRemision.Item(i, 7))
                            _Saldo = _Total - _SumImportesSaldo
                            fila("Saldo") = 0
                        Else
                            fila("Saldo") = CDec(grdRemision.Item(i, 7)) - _Saldo
                            _Saldo = 0
                        End If
                        fila("Tipocobro") = _Tipocobro
                        grdRemision.DataSource = _TablaRemisiones
                        If _Saldo <= 0 Then
                            lbl_saldo.Text = Valorcero()
                        Else
                            lbl_saldo.Text = "$" + _Saldo.ToString
                        End If
                        lbl_importeDocumento.Text = Valorcero()
                        lblSaloMovimiento.Text = Valorcero()
						lblImporteAbobo.Text = Valorcero()
						UltimoCobro.Remision = CInt(grdRemision.Item(i, 1))
						UltimoCobro.Serie = CType(grdRemision.Item(i, 0), String)
					End If
                Catch ex As Exception
                    MessageBox.Show(ex.Message)
                End Try
            Else
                MessageBox.Show("saldo insuficiente")
            End If
        Else
            MessageBox.Show("Ya no se permite hacer un abono, el saldo ya es de cero")
        End If
    End Sub

    Private Sub Btn_Borrar_Click(sender As Object, e As EventArgs) Handles Btn_BorrarTodo.Click
        If table.Rows.Count > 0 Then
            For i = 0 To table.Rows.Count - 1
                table.Rows(0).Delete()
            Next
        End If
        grdAbonos.DataSource = table
        If (Cancelar IsNot Nothing) Then
            Dim Contar As Integer = 0
            For Each item As String In Cancelar
                _TablaRemisiones.Rows(Contar)("Saldo") = item
                Contar = Contar + 1
            Next
        End If

        lbl_saldo.Text = "$" + CType(_Total, String)
        grdRemision.DataSource = _TablaRemisiones
        _SumImportesSaldo = 0
        _Saldo = _Total
    End Sub

    Private Sub grdRemision_MouseClick(sender As Object, e As MouseEventArgs) Handles grdRemision.MouseClick
        Try
            ActualizarEtiquetas()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End Try
    End Sub

    Private Sub ActualizarEtiquetas()
        If Not grdRemision.DataSource Is Nothing Then
            lbl_importeDocumento.Text = "$" + CType(Val(grdRemision.Item(i, 6)), String)
            lblSaloMovimiento.Text = "$" + CType(Val(grdRemision.Item(i, 7)), String)
            If _Saldo >= CDec(grdRemision.Item(i, 7)) Then
                lblImporteAbobo.Text = "$" + CType((grdRemision.Item(i, 7)), String)
            Else
                lblImporteAbobo.Text = "$" + _Saldo.ToString
            End If
            _FilaSaldo = i
        End If
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        If table.Rows.Count > 0 Then
            For i = 0 To table.Rows.Count - 1
                table.Rows(0).Delete()
            Next
        End If
        grdAbonos.DataSource = table
        If (Cancelar IsNot Nothing) Then
            Dim Contar As Integer = 0
            For Each item As String In Cancelar
                _TablaRemisiones.Rows(Contar)("Saldo") = item
                Contar = Contar + 1
            Next
        End If

        lbl_saldo.Text = "$" + CType(_Total, String)
        grdRemision.DataSource = _TablaRemisiones
        _SumImportesSaldo = 0
        _Saldo = 0
        _CancelPago = True
        Close()

    End Sub

    Private Sub btn_aceptarAbonos_Click(sender As Object, e As EventArgs) Handles btn_aceptarAbonos.Click
        If _AceptaSaldo = False Then
            If _Saldo > 0 Then
                MessageBox.Show("No se puede aceptar abonos el saldo debe de ser de $0.00 pesos, El saldo actual es de  " + _Saldo.ToString)
            ElseIf _Saldo = 0 Then
                MessageBox.Show("¡Captura de remisiones concluida!")
                Close()
            End If
        Else
            If _Saldo > 0 Then
                If MessageBox.Show("¿Desea generar saldo a favor?", "",
          MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
          = DialogResult.Yes Then
                    Dim InsertCobro As SigaMetClasses.CobroDetalladoDatos = _UltimoCobro
                    InsertCobro.SaldoAFavor = True
                    InsertCobro.Saldo = _Saldo
                    InsertCobro.StatusSaldoAFavor = "ACTIVO"
                    _UltimoCobro = InsertCobro
                    MessageBox.Show("¡Captura de remisiones concluida!")
                    Close()
                End If
            Else
                MessageBox.Show("¡Captura de remisiones concluida!")
                Close()
            End If




            End If


            For Each row As DataRow In table.Rows
            oCobroRemision = New SigaMetClasses.CobroRemisiones
            oCobroRemision.Pago = Pago
            oCobroRemision.Remision = row("Remisión").ToString()
            oCobroRemision.Serie = row("Serie").ToString()
            oCobroRemision.MontoAbonado = Convert.ToDecimal(row("importe abonado").ToString())
            CobroRemisiones.Add(oCobroRemision)
        Next
    End Sub
    Function Valorcero() As String
        Valorcero = " $000.00"
    End Function

    Private Sub grdRemision_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdRemision.CurrentCellChanged
        i = grdRemision.CurrentRowIndex
        ActualizarEtiquetas()
    End Sub


    Private Sub frmRemisiones_FormClosed(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If _AceptaSaldo = False Then
            If _Saldo > 0 Then
                MessageBox.Show("No puede salir hasta tener saldo en 0 saldo: $" + _Saldo.ToString)
                e.Cancel = True
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BtnBorrarUnAbono.Click
        For Each abono As DataRow In table.Rows
            If (table.Rows.IndexOf(abono) = grdAbonos.CurrentRowIndex) Then

                For Each Remision As DataRow In _TablaRemisionesInicial.Rows
                    If (Remision("Serie").ToString() = abono("Serie").ToString() And
                        Remision("Remision").ToString() = abono("Remisión").ToString() And
                        Remision("Producto").ToString() = abono("Producto").ToString()) Then

                        _Saldo = Convert.ToDecimal(lbl_saldo.Text.Replace("$", "")) + Convert.ToDecimal(abono("importe abonado").ToString().Replace("$", ""))
                        lbl_saldo.Text = "$" + _Saldo.ToString()
                        abono.Delete()
                        _TablaRemisiones.Rows(_TablaRemisionesInicial.Rows.IndexOf(Remision))("Saldo") = Cancelar(_TablaRemisionesInicial.Rows.IndexOf(Remision))

                        GoTo Finalize
                    End If
                Next
            End If
        Next
Finalize:
        grdRemision.DataSource = _TablaRemisiones
        grdAbonos.DataSource = table
        _SumImportesSaldo = 0
    End Sub

    Private Sub grdAbonos_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdAbonos.CurrentCellChanged
        FilaAbono = grdAbonos.CurrentRowIndex
    End Sub
End Class