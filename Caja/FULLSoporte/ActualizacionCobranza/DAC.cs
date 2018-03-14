using System;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace ActualizacionCobranza
{
	/// <summary>
	/// Summary description for DAC.
	/// </summary>
	public class DAC
	{

		#region Private members
		private SqlConnection _connection;
		
		private DataTable dtListaMovimientosOrigen;
		private DataTable dtListaMovimientos;
		private DataTable dtListaDocumentos;
		private DataTable dtListaMovimientosOK;
		private DataTable dtListaMovimientosErroneos;
		private DataTable dtListaDocumentosErroneos;
		
		private SGDAC.DAC _dataQry;

		private string _usuario;

		private DataSet dsMovimientos;
		#endregion

		#region Public properties
		public DAC(string Usuario, SqlConnection Connection)
		{
			_usuario = Usuario;
			buildDbSchema();
			_connection = Connection;
			_dataQry = new SGDAC.DAC(_connection);
		}

		public DataSet Movimimientos
		{
			get
			{
				return dsMovimientos;
			}
		}
		#endregion

		#region MemoryDB
		private void buildDbSchema()
		{
			dsMovimientos = new DataSet();
			dtListaMovimientosOrigen = new DataTable("MovimientosOrigen");
			dtListaMovimientosOrigen.Columns.Add("Clave");
			dtListaMovimientos = new DataTable("Movimientos");
			dtListaDocumentos = new DataTable("ListaDocumentos");
			dsMovimientos.Tables.Add(dtListaMovimientosOrigen);
			dsMovimientos.Tables.Add(dtListaMovimientos);
			dsMovimientos.Tables.Add(dtListaDocumentos);
		}

		private void buildDbSchema2()
		{
			if (dtListaMovimientosErroneos == null)
			{
				dtListaMovimientosErroneos = dtListaMovimientos.Clone();
				dtListaMovimientosErroneos.TableName = "MovimientosErroneos";
				dsMovimientos.Tables.Add(dtListaMovimientosErroneos);
			}
			if (dtListaDocumentosErroneos == null)
			{
				dtListaDocumentosErroneos = dtListaDocumentos.Clone();
				dtListaDocumentosErroneos.TableName = "ListaDocumentosErroneos";
				dsMovimientos.Tables.Add(dtListaDocumentosErroneos);
			}
			if (dtListaMovimientosOK == null)
			{
				dtListaMovimientosOK = dtListaMovimientos.Clone();
				dtListaMovimientosOK.TableName = "MovimientosOK";
				dsMovimientos.Tables.Add(dtListaMovimientosOK);
			}
		}

		private void pkDefinition(DataTable dt, string KeyColumnName)
		{
			if (dt.PrimaryKey.GetLength(0) == 0)
			{
				DataColumn[] pk = new DataColumn[1];
				DataColumn dc = dt.Columns[KeyColumnName];
				pk[0] = dc;
				dt.PrimaryKey = pk;
			}
		}

		public void ResetData()
		{
			dtListaMovimientosOrigen.Rows.Clear();
			dtListaMovimientos.Rows.Clear();
			dtListaDocumentos.Rows.Clear();
		}
		#endregion

		#region FileAcces

		public void LeerClaves(string FileName)
		{
			try 
			{
				dtListaMovimientosOrigen.Clear();
				using (StreamReader sr = new StreamReader(FileName)) 
				{
					string line;
					while ((line = sr.ReadLine()) != null) 
					{
						AgregarMovimientoOrigen(line);
					}
				}
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		#endregion

		#region DBAccess

		public void ConsultarMovimientos()
		{
			try
			{
				dtListaMovimientos.Clear();
				dtListaDocumentos.Clear();
				foreach (DataRow dr in dtListaMovimientosOrigen.Rows)
				{
					SqlParameter[] param = new SqlParameter[1];
					param[0] = new SqlParameter("@Clave", SqlDbType.VarChar);
					param[0].Value = dr["Clave"];	
					_dataQry.LoadData(dtListaMovimientos,
						"spCyCCFMConsultaMovimientos",
						CommandType.StoredProcedure,
						param,
						false);
					pkDefinition(dtListaMovimientos, "Clave");
				}
				foreach (DataRow dr in dtListaMovimientos.Rows)
				{
					SqlParameter[] param2 = new SqlParameter[1];
					param2[0] = new SqlParameter("@Clave", SqlDbType.VarChar);
					param2[0].Value = dr["Clave"];	
					_dataQry.LoadData(dtListaDocumentos,
						"spCyCCFMConsultaDocumentos",
						CommandType.StoredProcedure,
						param2,
						false);
				}
				buildDbSchema2();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		#endregion

		#region DataProcessing

		public bool ProcesarFMovimiento(DateTime FMovimiento)
		{
			bool procesado = false;
			try
			{
				_dataQry.OpenConnection();
				_dataQry.BeginTransaction();
				foreach (DataRow dr in dtListaMovimientosOK.Rows)
				{
					procesarMovimiento(Convert.ToString(dr["Clave"]), FMovimiento, _usuario,
						"Cambio de FMovimiento", Convert.ToDateTime(dr["FMovimiento"]), _dataQry.Transaction);
				}
				_dataQry.Transaction.Commit();
				procesado = true;
			}
			catch (SqlException ex)
			{
				_dataQry.Transaction.Rollback();
				throw ex;
			}
			catch (Exception ex)
			{
				_dataQry.Transaction.Rollback();
				throw ex;
			}
			finally
			{
				_dataQry.CloseConnection();
			}
			return procesado;
		}

		private void procesarMovimiento(string Clave, DateTime FMovimiento,
			string Usuario, string Observaciones, DateTime FMovimientoAnterior,
			SqlTransaction Transaction)
		{
			SqlCommand cmd = new SqlCommand();
			cmd.CommandText = "spCyCCambioFMovimiento";
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Parameters.Add("@Clave", SqlDbType.VarChar).Value = Clave;
			cmd.Parameters.Add("@FMovimiento", SqlDbType.DateTime).Value = FMovimiento.Date;
			cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = Usuario;
			cmd.Parameters.Add("@Observaciones", SqlDbType.VarChar).Value = Observaciones;
			cmd.Parameters.Add("@FMovimientoAnterior", SqlDbType.DateTime).Value = FMovimientoAnterior;
			cmd.CommandTimeout = 100;
			cmd.Transaction = Transaction;
			try
			{
				cmd.Connection = _connection;	
				cmd.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				throw ex;
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				cmd.Dispose();
			}
		}

		#endregion

		#region MemoryDataAccess

		public void DocumentosErroneos(DateTime FMovimiento)
		{
			dtListaDocumentosErroneos.Clear();
			dtListaMovimientosErroneos.Clear();
			dtListaMovimientosOK.Clear();
			foreach (DataRow drM in dtListaMovimientos.Rows)
			{
				dtListaDocumentos.DefaultView.RowFilter = "Clave = '" + drM["Clave"] + "'";
				dtListaDocumentos.DefaultView.Sort = "Clave";
                foreach (DataRowView dr in dtListaDocumentos.DefaultView.FindRows(drM["Clave"]))
				{
					DateTime FCargo = Convert.ToDateTime(dr["FCargo"]);
					if ((FCargo.Month != FMovimiento.Month) &&
						FCargo > FMovimiento)
					{
						copyRow(dr, dtListaDocumentosErroneos, false);
						copyRow(drM, dtListaMovimientosErroneos, false);
					}
				}
				
				if (dtListaMovimientosErroneos.Rows.Find(drM["Clave"]) == null)
				{
					copyRow(drM, dtListaMovimientosOK, false);
				}

			}
		}

		public void AgregarMovimientoOrigen(string Clave)
		{
			DataRow dr = dtListaMovimientosOrigen.NewRow();
			dr["Clave"] = Clave.Trim();
			dtListaMovimientosOrigen.Rows.Add(dr);
		}

		private void copyRow(DataRow SourceRow, DataTable DestinationTable, bool ThrowException)
		{
			try
			{
				DataRow newRow = DestinationTable.NewRow();
				foreach (DataColumn dc in DestinationTable.Columns)
				{
					newRow[dc.ColumnName] = SourceRow[dc.ColumnName];
				}
				DestinationTable.Rows.Add(newRow);
			}
			catch (System.Data.ConstraintException ex)
			{
				if (ThrowException)
					throw ex;
				else
					ex = null;
			}
		}

		private void copyRow(DataRowView SourceRow, DataTable DestinationTable, bool ThrowException)
		{
			try
			{
				DataRow newRow = DestinationTable.NewRow();
				foreach (DataColumn dc in DestinationTable.Columns)
				{
					newRow[dc.ColumnName] = SourceRow[dc.ColumnName];
				}
				DestinationTable.Rows.Add(newRow);
			}
			catch (System.Data.ConstraintException ex)
			{
				if (ThrowException)
					throw ex;
				else
					ex = null;
			}
		}

		public DataTable DocumentosErroneos(string Clave)
		{
			DataTable retDt = dtListaDocumentos.Clone();
			dtListaDocumentosErroneos.DefaultView.RowFilter = "Clave = '" + Clave + "'";
			dtListaDocumentosErroneos.DefaultView.Sort = "Clave";
			foreach (DataRowView dr in dtListaDocumentos.DefaultView.FindRows(Clave))
			{
				copyRow(dr, retDt, false);
			}
			return retDt;
		}

		#endregion

	}

#region waste
	//string listaClaves = string.Empty;
	//listaClaves += dr["Clave"].ToString() + ", ";
	//if (listaClaves.Length > 0)
	//{
	//listaClaves = listaClaves.Substring(0, listaClaves.Length - 1);
	//}
	#endregion
}
