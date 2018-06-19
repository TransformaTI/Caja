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
            Dim PRUEBA As SigaMetClasses.CobroDetalladoDatos = _UltimoCobro

            Dim row As DataRow
            For Each row In _TablaRemisiones.Rows
                Cancelar.Add(CType(row("Saldo"), String))
            Next
            lbl_Total.Text = "$" + CType(_Total, String)
            lbl_saldo.Text = "$" + CType(_Total, String)
            ' Create new DataColumn, set DataType, ColumnName 
            ' and add to DataTable.    
            Dim keys(2) As DataColumn
            column = New DataColumn
            column.DataType = System.Type.GetType("System.String")
            column.ColumnName = "Serie"
            table.Columns.Add(column)
            keys(0) = column

            ' Create second column.
            column = New DataColumn
            column.DataType = Type.GetType("System.String")
            column.ColumnName = "Remisión"
            table.Columns.Add(column)
            keys(1) = column

            column = New DataColumn
            column.DataType = Type.GetType("System.String")
            column.ColumnName = "Importe abonado"
            table.Columns.Add(column)

            table.PrimaryKey = keys

            Dim keysRemiesiones(2) As DataColumn
            'Dim columnRemisiones As DataColumn
            'columnRemisiones = New DataColumn
            'columnRemisiones.DataType = System.Type.GetType("System.String")
            'columnRemisiones.ColumnName = "Serie"



            keysRemiesiones(0) = _TablaRemisiones.Columns(0)

            'columnRemisiones = New DataColumn
            'columnRemisiones.DataType = Type.GetType("System.String")
            'columnRemisiones.ColumnName = "Remisión"

            keysRemiesiones(1) = _TablaRemisiones.Columns(1)

            _TablaRemisiones.PrimaryKey = keysRemiesiones
            grdRemision.DataSource = Nothing
            grdRemision.DataSource = _TablaRemisiones
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
                    If grdRemision.VisibleRowCount > 0 Then
                        ' Create new DataRow objects and add to DataTable.    
                        row = table.NewRow
                        row("Serie") = grdRemision.Item(i, 0)
                        row("Remisión") = grdRemision.Item(i, 1)
                        row("Importe abonado") = grdRemision.Item(i, 7)
                        table.Rows.Add(row)
                        ' Set to DataGrid.DataSource property to the table.
                        grdAbonos.DataSource = table

                        i = grdRemision.CurrentRowIndex
                        ' lbl_saldo.Text = CType(_Total - CType(Val(grdRemision.Item(i, 7)), Decimal), String)
                        '  lbl_Total.Text = "$" + CType(Val(grdRemision.Item(i, 6)), String)
                        lbl_importeDocumento.Text = "$" + CType(Val(grdRemision.Item(i, 6)), String)
                        lblSaloMovimiento.Text = "$" + CType(Val(grdRemision.Item(i, 7)), String)
                        If _Total >= CDec(grdRemision.Item(i, 7)) Then
                            lblImporteAbobo.Text = "$" + CType((grdRemision.Item(i, 7)), String)
                        ElseIf _Total < CDec(grdRemision.Item(i, 7)) Then
                            lblImporteAbobo.Text = "$" + CType(CDec(grdRemision.Item(i, 7)) - _Total, String)
                        End If
                        _FilaSaldo = i
                        AceptarAbono = True
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

    Private Sub Btn_Borrar_Click(sender As Object, e As EventArgs) Handles Btn_Borrar.Click
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
        _Saldo = _Total
    End Sub

    Private Sub grdRemision_MouseClick(sender As Object, e As MouseEventArgs) Handles grdRemision.MouseClick

    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        If (Cancelar IsNot Nothing) Then
            Dim Contar As Integer = 0
            For Each item As String In Cancelar
                _TablaRemisiones.Rows(Contar)("Saldo") = item
                Contar = Contar + 1
            Next
        End If

        lbl_saldo.Text = "$" + CType(_Total, String)
        grdRemision.DataSource = _TablaRemisiones
        _Saldo = _Total
    End Sub

    Private Sub btn_aceptarAbonos_Click(sender As Object, e As EventArgs) Handles btn_aceptarAbonos.Click
        Dim fila As DataRow
        fila = _TablaRemisiones.Rows(_FilaSaldo)
        If _Saldo > 0 Then
            If AceptarAbono = True Then

                _Saldo = _Saldo - CDec(grdRemision.Item(i, 7))
                If _Saldo < 0 Then
                    fila("Saldo") = _Saldo * -1
                Else
                    fila("Saldo") = 0
                    grdRemision.DataSource = _TablaRemisiones
                End If
                If _Saldo < 0 Then
                    lblImporteAbobo.Text = CType(_Saldo * -1, String)
                    lbl_saldo.Text = "0"
                Else
                    lblImporteAbobo.Text = Valorcero()
                    lbl_saldo.Text = _Saldo.ToString
                End If
                lbl_importeDocumento.Text = Valorcero()
                lblSaloMovimiento.Text = Valorcero()

            End If
            AceptarAbono = False
        Else
            MessageBox.Show("Saldo insuficiente, No se puede hacer otro abono ")
            If MessageBox.Show("¿Desea salir?", "",
         MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
         = DialogResult.Yes Then
                Close()
            End If
        End If
    End Sub
    Function Valorcero() As String
        Valorcero = " $000.00"
    End Function
    Private Sub grdRemision_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdRemision.CurrentCellChanged
        i = grdRemision.CurrentRowIndex
    End Sub


    Private Sub frmRemisiones_FormClosed(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If _Saldo > 0 Then
            MessageBox.Show("No puede salir hasta tener saldo en 0 saldo: $" + _Saldo.ToString)
            e.Cancel = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim findTheseVals(1) As Object
        ' Set the values of the keys to find.
        findTheseVals(0) = grdRemision.Item(FilaAbono, 0)
        findTheseVals(1) = grdRemision.Item(FilaAbono, 1)
        Dim foundRow As DataRow = _TablaRemisiones.Rows.Find(findTheseVals)
        Dim MontoRemision As Decimal
        Dim MontoDevuelto As Decimal
        Dim MontoTotal As Decimal

        ' Display column 1 of the found row.
        If Not (foundRow Is Nothing) Then
            MontoRemision = Convert.ToDecimal(foundRow(7))
            MontoDevuelto = Convert.ToDecimal(grdAbonos.Item(FilaAbono, 2))
            MontoTotal = MontoRemision + MontoDevuelto
            foundRow(7) = MontoTotal
            table.Rows(FilaAbono).Delete()


            'grdRemision.Item(0, 7) = grdAbonos.Item(FilaAbono, 2)
            'MessageBox.Show(foundRow(0).ToString() + "    " + foundRow(7).ToString())
            'table.Rows(FilaAbono).Delete()

        End If
        'MessageBox.Show(CType(grdAbonos.Item(FilaAbono, 0), String))
        'MessageBox.Show(CType(grdAbonos.Item(FilaAbono, 1), String))






    End Sub

    Private Sub grdAbonos_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdAbonos.CurrentCellChanged
        FilaAbono = grdAbonos.CurrentRowIndex


    End Sub
End Class