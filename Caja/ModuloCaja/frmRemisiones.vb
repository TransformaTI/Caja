﻿Public Class frmRemisiones
    Private i As Integer
    Private _Total As Decimal
    Private _Saldo As Decimal
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
            Dim DetalleGrid As DataTable
            Dim cargarRemisiones As New SigaMetClasses.LiquidacionPortatil
            'DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(_Folio, _NDocumento)
            DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(119151, 90632)
            grdRemision.DataSource = DetalleGrid

            lbl_Total.Text = "$" + CType(_Total, String)
            lbl_saldo.Text = "$" + CType(_Total, String)

        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error al cargar los datos")
        End Try

    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
        If _Saldo > 0 Then

            Try
                If grdRemision.VisibleRowCount > 0 Then
                    Dim table As New DataTable

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
                    row("Importe abonado") = grdRemision.Item(i, 5)
                    table.Rows.Add(row)
                    ' Set to DataGrid.DataSource property to the table.
                    grdAbonos.DataSource = table

                    i = grdRemision.CurrentRowIndex
                    ' lbl_saldo.Text = CType(_Total - CType(Val(grdRemision.Item(i, 7)), Decimal), String)
                    '  lbl_Total.Text = "$" + CType(Val(grdRemision.Item(i, 6)), String)
                    lbl_importeDocumento.Text = "$" + CType(Val(grdRemision.Item(i, 6)), String)
                    lblSaloMovimiento.Text = "$" + CType(Val(grdRemision.Item(i, 7)), String)
                    If _Total > CDec(grdRemision.Item(i, 7)) Then
                        lblImporteAbobo.Text = "$" + CType((grdRemision.Item(i, 7)), String)
                    ElseIf _Total < CDec(grdRemision.Item(i, 7)) Then
                        lblImporteAbobo.Text = "$" + CType(CDec(grdRemision.Item(i, 7)) - _Total, String)
                    End If


                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
        Else
            MessageBox.Show("saldo insuficiente")
        End If
    End Sub

    Private Sub Btn_Borrar_Click(sender As Object, e As EventArgs) Handles Btn_Borrar.Click


        Dim table As New DataTable
        grdAbonos.DataSource = table
    End Sub

    Private Sub grdRemision_MouseClick(sender As Object, e As MouseEventArgs) Handles grdRemision.MouseClick
        i = grdRemision.CurrentRowIndex
        'lbl_saldo.Text = "$" + CType(Val(grdRemision.Item(i, 7)), String)
        'lbl_Total.Text = "$" + CType(Val(grdRemision.Item(i, 6)), String)
    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Close()

    End Sub

    Private Sub btn_aceptarAbonos_Click(sender As Object, e As EventArgs) Handles btn_aceptarAbonos.Click
        If _Saldo > 0 Then


            _Saldo = _Saldo - CDec(grdRemision.Item(i, 7))


            If _Saldo < 0 Then
                lblImporteAbobo.Text = CType(_Saldo * -1, String)
                lbl_saldo.Text = "0"
            Else
                lblImporteAbobo.Text = Valorcero()
                lbl_saldo.Text = _Saldo.ToString
            End If
            lbl_importeDocumento.Text = Valorcero()
            lblSaloMovimiento.Text = Valorcero()
        Else
            MessageBox.Show("Saldo insuficiente, No se puede hacer otro abono ")
        End If


    End Sub
    Function Valorcero() As String
        Valorcero = " $000.00"
    End Function
End Class