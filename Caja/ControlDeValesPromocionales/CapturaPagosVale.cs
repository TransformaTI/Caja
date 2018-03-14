using System;
using System.Data;
using System.Collections;

using System.Data.SqlClient;

namespace ControlDeValesPromocionales
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	/// 
	public enum TipoOperacion
	{
		Captura = 1,
		Consulta = 2
	}

	public class CapturaPagosVale
	{
		DataTable dtCatalogoVales;
		SGDAC.DAC _data;

		public DataTable CatalogoVales
		{
			get
			{
				return dtCatalogoVales;
			}
		}

		public CapturaPagosVale()
		{
			buildDataTable();

			_data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
			ConsultaPromocionVigente();

			Inicializacion();
		}

		public CapturaPagosVale(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio)
		{
			buildDataTable();

			_data = new SGDAC.DAC(SigaMetClasses.DataLayer.Conexion);
			CargaValeCapturado(Caja, FOperacion, Consecutivo, Folio);
		}

		public void ConsultaPromocionVigente()
		{
			try
			{
				_data.LoadData(dtCatalogoVales, "spCAJConsultaValesPromocionActivos", CommandType.StoredProcedure, null, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void CargaValeCapturado(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio)
		{
			SqlParameter[] param = new SqlParameter[4];
			param[0] = new SqlParameter("@Caja", SqlDbType.TinyInt);
			param[0].Value = Caja;
			param[1] = new SqlParameter("@FOperacion", SqlDbType.DateTime);
			param[1].Value = FOperacion;
			param[2] = new SqlParameter("@Consecutivo", SqlDbType.TinyInt);
			param[2].Value = Consecutivo;
			param[3] = new SqlParameter("@Folio", SqlDbType.Int);
			param[3].Value = Folio;

			try
			{
				_data.LoadData(dtCatalogoVales, "spCAConsultaPromocionesPorLiquidacion", CommandType.StoredProcedure, param, true);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public void Inicializacion()
		{
			foreach (DataRow dr in dtCatalogoVales.Rows)
			{
				dr.BeginEdit();
				dr["Cantidad"] = 0;
				dr["Importe"] = 0;
				dr.EndEdit();
			}
		}

		public void AltaConsultaDenominacion(byte Denominacion, string Descripcion, decimal ValorDenominacion, byte TipoCobro, int Cantidad, 
			decimal Total)
		{
			if (dtCatalogoVales == null)
			{
				buildDataTable();
			}

			DataRow drValePromocion = dtCatalogoVales.Rows.Find(Denominacion);

			if (drValePromocion == null)
			{
				drValePromocion = dtCatalogoVales.NewRow();
				
				drValePromocion.BeginEdit();		
				drValePromocion["Denominacion"] = Denominacion;
				drValePromocion.EndEdit();

				dtCatalogoVales.Rows.Add(drValePromocion);
			}

			drValePromocion.BeginEdit();

			drValePromocion["Descripcion"] = Descripcion;
			drValePromocion["ValorDenominacion"] = ValorDenominacion;
			drValePromocion["TipoCobro"] = TipoCobro;
			drValePromocion["Cantidad"] = Cantidad;
			drValePromocion["Importe"] = Total;

			drValePromocion.EndEdit();
		}

		private void buildDataTable()
		{
			dtCatalogoVales = new DataTable();

			dtCatalogoVales.Columns.Add("ValePromocion", System.Type.GetType("System.Int32"));
			dtCatalogoVales.Columns.Add("Denominacion", System.Type.GetType("System.Byte"));
			dtCatalogoVales.Columns.Add("Descripcion", System.Type.GetType("System.String"));
			dtCatalogoVales.Columns.Add("ValorDenominacion", System.Type.GetType("System.Decimal"));
			dtCatalogoVales.Columns.Add("TipoCobro", System.Type.GetType("System.Byte"));
			dtCatalogoVales.Columns.Add("Cantidad", System.Type.GetType("System.Int32"));
			dtCatalogoVales.Columns.Add("Importe", System.Type.GetType("System.Decimal"));

			//Llave primaria de la tabla
			dtCatalogoVales.PrimaryKey = new DataColumn[] { dtCatalogoVales.Columns["Denominacion"] };
		}
	}
}
