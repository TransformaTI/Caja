Public Class frmRemisiones
    Private Sub frmRemisiones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim DetalleGrid As DataTable
        Dim cargarRemisiones As New SigaMetClasses.LiquidacionPortatil
        'DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(_Folio, _NDocumento)
        DetalleGrid = cargarRemisiones.cargarRemisionesPortatilALiquidar(119151, 90632)
        grdRemisiones.DataSource = DetalleGrid
    End Sub

    Private Sub grdRemisiones_MouseClick(sender As Object, e As MouseEventArgs) Handles grdRemisiones.MouseClick
        Dim i As Integer
        i = grdRemisiones.CurrentRowIndex
        lbl_saldo.Text = "$" + CType(Val(grdRemisiones.Item(i, 7)), String)
        lbl_Total.Text = "$" + CType(grdRemisiones.Item(i, 6), String)
    End Sub
End Class