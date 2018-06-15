Imports System.Collections.Generic

Public Class frmRemisiones
    Private i As Integer
    Private _Total As Decimal
    Private _Saldo As Decimal
    Private _TablaRemisiones As DataTable
    Private _FilaSaldo As Integer
    Public AceptarAbono As Boolean
    Dim Cancelar As New List(Of String)


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

            grdRemision.DataSource = _TablaRemisiones
            Dim row As DataRow
            For Each row In _TablaRemisiones.Rows
                Cancelar.Add(CType(row("Saldo"), String))
            Next
            lbl_Total.Text = "$" + CType(_Total, String)
            lbl_saldo.Text = "$" + CType(_Total, String)
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
                        Dim table As New DataTable
                        Dim fila As DataRow
                        ' Declare DataColumn and DataRow variables.
                        Dim column As DataColumn
                        Dim row As DataRow

                        ' Create new DataColumn, set DataType, ColumnName 
                        ' and add to DataTable.    
                        column = New DataColumn
                        column.DataType = System.Type.GetType("System.String")
                        column.ColumnName = "Serie"
                        table.Columns.Add(column)

                        ' Create second column.
                        column = New DataColumn
                        column.DataType = Type.GetType("System.String")
                        column.ColumnName = "Remisión"
                        table.Columns.Add(column)

                        column = New DataColumn
                        column.DataType = Type.GetType("System.String")
                        column.ColumnName = "Importe abonado"
                        table.Columns.Add(column)
                        ' Create new DataRow objects and add to DataTable.    
                        row = table.NewRow
                        row("Serie") = grdRemision.Item(i, 0)
                        row("Remisión") = grdRemision.Item(i, 1)
                        If _Saldo > CDec(grdRemision.Item(i, 7)) Then
                            row("Importe abonado") = grdRemision.Item(i, 7)
                        Else
                            row("Importe abonado") = CDec(grdRemision.Item(i, 7)) - _Saldo
                        End If
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


        Dim table As New DataTable
        grdAbonos.DataSource = table
    End Sub

    Private Sub grdRemision_MouseClick(sender As Object, e As MouseEventArgs) Handles grdRemision.MouseClick

    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        If _Saldo <= 0 Then
            Close()

        End If
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
            Close()
        End If


    End Sub
    Function Valorcero() As String
        Valorcero = " $000.00"
    End Function
    Private Sub grdRemision_CurrentCellChanged(sender As Object, e As EventArgs) Handles grdRemision.CurrentCellChanged
        i = grdRemision.CurrentRowIndex
    End Sub

    Private Sub frmRemisiones_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed


    End Sub
    Private Sub frmRemisiones_FormClosed(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If _Saldo > 0 Then
            MessageBox.Show("No puede salir hasta tener saldo en 0 saldo: $" + _Saldo.ToString)
            e.Cancel = True
        End If
    End Sub
End Class