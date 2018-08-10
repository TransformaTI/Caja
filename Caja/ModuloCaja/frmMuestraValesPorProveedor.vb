Imports System.Data.SqlClient

Public Class frmMuestraValesPorProveedor
	Private dsPreLiq As DataSet
	Private _año As Integer
	Private _folio As Integer

	Public Property Año As Integer
		Get
			Return _año
		End Get
		Set(value As Integer)
			_año = value
		End Set
	End Property

	Public Property Folio As Integer
		Get
			Return _folio
		End Get
		Set(value As Integer)
			_folio = value
		End Set
	End Property

	Private Sub CargaGrid()
		Dim cmd As New SqlClient.SqlCommand("spCCConsultaValesporProveedor", GLOBAL_Connection)
		cmd.CommandType = CommandType.StoredProcedure
		cmd.Parameters.Add("@AñoAtt", SqlDbType.SmallInt).Value = _año
		cmd.Parameters.Add("@Folio", SqlDbType.Int).Value = _folio


		Dim datCmd As New SqlClient.SqlDataAdapter(cmd)
		Dim dtTabla As New DataTable
		grdVales.DataSource = Nothing
		Try
			Cursor = Cursors.WaitCursor
			datCmd.Fill(dtTabla)
			dtTabla.Columns("Saldo").ColumnMapping = MappingType.Hidden

			grdVales.PreferredColumnWidth = 150
			If dtTabla.Rows.Count > 0 Then
				grdVales.DataSource = dtTabla
			End If
		Catch ex As Exception
			MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Me.Close()
		Finally
			If GLOBAL_Connection.State = ConnectionState.Open Then
				GLOBAL_Connection.Close()
			End If
			Cursor = Cursors.Default
		End Try
	End Sub

	Private Sub frmMuestraValesPorProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		CargaGrid()

	End Sub

	Private Sub grdVales_CellContentClick(sender As Object, e As DataGridViewCellEventArgs)

	End Sub
End Class