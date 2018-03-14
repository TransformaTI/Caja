using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace ControlDeValesPromocionales
{
	/// <summary>
	/// Summary description for frmCapturaPagosConVale.
	/// </summary>
	public class frmCapturaPagosConVale : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.Label lblTotal;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Panel pnlTotal;

		//Carga de datos: Vales de promoción
		private CapturaPagosVale _datosVale;
		private System.Windows.Forms.Button btnAceptar;

		private ArrayList _listaVales;
//
//		private DataTable _dtListaVales;

		public DataTable ListaVales
		{
			get
			{
				return _datosVale.CatalogoVales;
			}
		}

		bool _enabled = true;

		public bool CaptureEnabled
		{
			get
			{
				return _enabled;
			}
		}

		private decimal _total = 0;

		public decimal Total
		{
			get
			{
				return _total;
			}
		}

		public frmCapturaPagosConVale()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_datosVale = new CapturaPagosVale();

			_listaVales = new ArrayList();

			CargaVales(TipoOperacion.Captura);

			_enabled = true;
		}

		public frmCapturaPagosConVale(byte Caja, DateTime FOperacion, byte Consecutivo, int Folio)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//

			_datosVale = new CapturaPagosVale(Caja, FOperacion, Consecutivo, Folio);

			_listaVales = new ArrayList();

			CargaVales(TipoOperacion.Consulta);
			SumarCantidad();

			_enabled = false;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		public void CargaVales(ControlDeValesPromocionales.TipoOperacion TipoOperacion)
		{
			int _top = 20;
			foreach (DataRow _dataRow in _datosVale.CatalogoVales.Rows)
			{
				ValePromocional valePromocion = new ValePromocional();
				valePromocion.Top = _top;
				valePromocion.Left = 4;

				valePromocion.TipoOperacion = TipoOperacion;

				if (TipoOperacion == ControlDeValesPromocionales.TipoOperacion.Consulta)
				{
					valePromocion.Enabled = false;
				}

				valePromocion.DRPromocion = _dataRow;
                
				valePromocion.CantidadChanged += new EventHandler(CantidadChanged);
				valePromocion.Subir += new EventHandler(valePromocion_SubirControl);
				valePromocion.Bajar += new EventHandler(valePromocion_BajarControl);

				_top += valePromocion.Height;
				this.Controls.Add(valePromocion);
				_listaVales.Add(valePromocion);
				pnlTotal.Top += valePromocion.Height;
				this.Height += valePromocion.Height;
			}

			if (_listaVales.Count > 0)
			{
				((ValePromocional)_listaVales[0]).Select();
			}
		}

		protected void CantidadChanged(object sender, EventArgs e)
		{
			((ValePromocional)sender).UpdateData();
			SumarCantidad();
		}

		protected void valePromocion_SubirControl(object sender, EventArgs e)
		{
			int index = _listaVales.IndexOf((ValePromocional)sender);

			if (index > 0)
			{
				((ValePromocional)_listaVales[index - 1]).Select();
			}
		}

		protected void valePromocion_BajarControl(object sender, EventArgs e)
		{
			int index = _listaVales.IndexOf((ValePromocional)sender);
			index += 1;
			if (index <= _listaVales.Count - 1)
			{
				((ValePromocional)_listaVales[index]).Select();
			}
			else
			{
				btnAceptar.Select();
			}
		}

		private void SumarCantidad()
		{
			if (_datosVale.CatalogoVales.Rows.Count > 0)
			{
				_total = Convert.ToDecimal(_datosVale.CatalogoVales.Compute("SUM(Importe)", ""));
				lblTotal.Text = _total.ToString("C");
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCapturaPagosConVale));
			this.lblTotal = new System.Windows.Forms.Label();
			this.pnlTotal = new System.Windows.Forms.Panel();
			this.btnAceptar = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.pnlTotal.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblTotal
			// 
			this.lblTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lblTotal.Location = new System.Drawing.Point(100, 3);
			this.lblTotal.Name = "lblTotal";
			this.lblTotal.TabIndex = 1;
			this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// pnlTotal
			// 
			this.pnlTotal.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.btnAceptar,
																				   this.label1,
																				   this.lblTotal});
			this.pnlTotal.Location = new System.Drawing.Point(68, 20);
			this.pnlTotal.Name = "pnlTotal";
			this.pnlTotal.Size = new System.Drawing.Size(200, 60);
			this.pnlTotal.TabIndex = 2;
			// 
			// btnAceptar
			// 
			this.btnAceptar.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnAceptar.BackColor = System.Drawing.Color.Silver;
			this.btnAceptar.Image = ((System.Drawing.Bitmap)(resources.GetObject("btnAceptar.Image")));
			this.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAceptar.Location = new System.Drawing.Point(100, 32);
			this.btnAceptar.Name = "btnAceptar";
			this.btnAceptar.Size = new System.Drawing.Size(100, 23);
			this.btnAceptar.TabIndex = 4;
			this.btnAceptar.Text = "Aceptar";
			this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(8, 7);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Total:";
			// 
			// frmCapturaPagosConVale
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(276, 89);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.pnlTotal});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmCapturaPagosConVale";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Promociones";
			this.pnlTotal.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnAceptar_Click(object sender, System.EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		public void AltaConsultaDenominacion(byte Denominacion, string Descripcion, decimal ValorDenominacion, byte TipoCobro, int Cantidad, 
			decimal Total)
		{
			_datosVale.AltaConsultaDenominacion(Denominacion, Descripcion, ValorDenominacion, TipoCobro, Cantidad,
				Total);
		}
	}
}
