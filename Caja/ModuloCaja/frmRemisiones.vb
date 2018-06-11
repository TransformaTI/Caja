Public Class frmRemisiones
    Private _Total As Decimal

    Public Sub New(Total As Decimal)

        ' This call is required by the designer.
        InitializeComponent()
        _Total = Total
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private i As Integer

    Private Sub frmRemisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'grdRemision.AutoGenerateColumns = False
        Try
            Dim DetalleGrid As DataTable
            Dim cargarRemisiones As New SigaMetClasses.LiquidacionPortatil
            'DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(_Folio, _NDocumento)
            DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(119151, 90632)
            'grdRemision.DataSource = DetalleGrid
            'grdRemision.Columns(0).Width = 70
            'grdRemision.Columns(1).DataPropertyName = "Serie"
            'grdRemision.Columns(1).Width = 80
            'grdRemision.Columns(2).DataPropertyName = "Remision"
            'grdRemision.Columns(2).Width = 80
            'grdRemision.Columns(3).DataPropertyName = "Cliente"
            'grdRemision.Columns(3).Width = 80
            'grdRemision.Columns(4).DataPropertyName = "Nombre"
            'grdRemision.Columns(4).Width = 150
            'grdRemision.Columns(5).DataPropertyName = "Kilos"
            'grdRemision.Columns(5).Width = 80
            'grdRemision.Columns(6).DataPropertyName = "Descuento"
            'grdRemision.Columns(6).Width = 80
            'grdRemision.Columns(7).DataPropertyName = "Importe"
            'grdRemision.Columns(7).Width = 80
            'grdRemision.Columns(8).DataPropertyName = "Saldo"
            'grdRemision.Columns(8).Width = 80
            'grdRemision.Columns(9).DataPropertyName = "FormaPago"
            'grdRemision.Columns(9).HeaderText = "Forma Pago"
            'grdRemision.Columns(9).Width = 150
            grdRemision.DataSource = DetalleGrid
            lbl_Total.Text = "$" + _Total.ToString
            lbl_saldo.Text = "$" + _Total.ToString
        Catch ex As Exception
            MessageBox.Show(ex.Message + "Error al cargar los datos")
        End Try

    End Sub

    Private Sub btn_Aceptar_Click(sender As Object, e As EventArgs) Handles btn_Aceptar.Click
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
                lbl_saldo.Text = CType(_Total - CType(Val(grdRemision.Item(i, 7)), Decimal), String)
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
    End Sub

    Private Sub Btn_Borrar_Click(sender As Object, e As EventArgs) Handles Btn_Borrar.Click


        Dim table As New DataTable
        grdAbonos.DataSource = table
    End Sub

    Private Sub grdRemision_MouseClick(sender As Object, e As MouseEventArgs) Handles grdRemision.MouseClick


    End Sub

    Private Sub btn_cancelar_Click(sender As Object, e As EventArgs) Handles btn_cancelar.Click
        Close()

    End Sub
End Class