using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ControlDeValesPromocionales
{
	/// <summary>
	/// Summary description for UserControl1.
	/// </summary>
	public class ValePromocional : System.Windows.Forms.UserControl
	{
		private System.Windows.Forms.Label lblPromocion;
		internal System.Windows.Forms.TextBox txtCantidad;
		private System.Windows.Forms.Label lblDenominacion;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public event EventHandler CantidadChanged;
		public event EventHandler Subir;
		public event EventHandler Bajar;

		ControlDeValesPromocionales.TipoOperacion _tipoOperacion;

		protected virtual void OnCantidadChanged(EventArgs e)
		{
			if (CantidadChanged != null)
			{
				CantidadChanged(this, e);
			}
		}

		protected virtual void OnSubir(EventArgs e)
		{
			if (Subir != null)
			{
				Subir(this, e);
			}
		}

		protected virtual void OnBajar(EventArgs e)
		{
			if (Bajar != null)
			{
				Bajar(this, e);
			}
		}

		public ControlDeValesPromocionales.TipoOperacion TipoOperacion
		{
			get
			{
				return _tipoOperacion;
			}
			set
			{
				_tipoOperacion = value;
			}
		}

		public ValePromocional()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			this.TipoOperacion = ControlDeValesPromocionales.TipoOperacion.Captura;

			txtCantidad.TextChanged += new EventHandler(txtCantidadChanged);
			txtCantidad.KeyDown += new KeyEventHandler(txtCantidad_KeyDown);
		}

		public void txtCantidad_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Down :
				case Keys.Right :
				case Keys.Enter :
				case Keys.Tab :
					OnBajar(e);
					break;
				case Keys.Up :
				case Keys.Left :
					OnSubir(e);
					break;
			}
		}

		public void txtCantidadChanged(object sender, EventArgs e)
		{
			OnCantidadChanged(e);
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

		short _denominacion;
		decimal _valorDenominacion;
		int _cantidadVales = 0;
		decimal _importeVales;

		DataRow _dataRow;

		public short Denominacion
		{
			get
			{
				return _denominacion;
			}
			set
			{
				_denominacion = value;
			}
		}

		public int CantidadVales
		{
			get
			{
				_cantidadVales = 0;
				try
				{
					if (txtCantidad.Text.Trim().Length > 0)
					{
						_cantidadVales = Convert.ToInt32(txtCantidad.Text);
					}
				}
				catch (InvalidCastException ex)
				{
					string _message = ex.Message;
				}
				return _cantidadVales;
			}
			set
			{
				_cantidadVales = value;
				txtCantidad.Text = _cantidadVales.ToString();
			}
		}

		public decimal ImporteVales
		{
			get
			{
				_importeVales = _cantidadVales * _valorDenominacion;
				return _importeVales;
			}
			set
			{
				_importeVales = value;
			}
		}

		public decimal ValorDenominacion
		{
			set
			{
				_valorDenominacion = value;
				lblDenominacion.Text = _valorDenominacion.ToString("C");
			}
			get
			{
				return _valorDenominacion;
			}
		}

		public string Promocion
		{
			set
			{
				lblPromocion.Text = value;
			}
		}


		public DataRow DRPromocion
		{
			set
			{
				_dataRow = value;
				DataBind();
			}
			get
			{
				return _dataRow;
			}
		}

		public void DataBind()
		{
			if (_dataRow != null)
			{
				this.Promocion = Convert.ToString(_dataRow["Descripcion"]);
				this.ValorDenominacion = Convert.ToDecimal(_dataRow["ValorDenominacion"]);

				if (this.TipoOperacion == ControlDeValesPromocionales.TipoOperacion.Consulta)
				{
					this.CantidadVales = Convert.ToInt32(_dataRow["Cantidad"]);
					this.ImporteVales = Convert.ToDecimal(_dataRow["Importe"]);
				}
			}
		}

		public void UpdateData()
		{
			if (_dataRow != null)
			{
				_dataRow.BeginEdit();
				_dataRow["Cantidad"] = this.CantidadVales;
				_dataRow["Importe"] = this.ImporteVales;
				_dataRow.EndEdit();
			}
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.lblPromocion = new System.Windows.Forms.Label();
			this.lblDenominacion = new System.Windows.Forms.Label();
			this.txtCantidad = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblPromocion
			// 
			this.lblPromocion.Location = new System.Drawing.Point(0, 4);
			this.lblPromocion.Name = "lblPromocion";
			this.lblPromocion.Size = new System.Drawing.Size(132, 16);
			this.lblPromocion.TabIndex = 0;
			this.lblPromocion.Text = "Promocion";
			// 
			// lblDenominacion
			// 
			this.lblDenominacion.Location = new System.Drawing.Point(136, 4);
			this.lblDenominacion.Name = "lblDenominacion";
			this.lblDenominacion.Size = new System.Drawing.Size(60, 16);
			this.lblDenominacion.TabIndex = 1;
			this.lblDenominacion.Text = "$ 50.00";
			this.lblDenominacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtCantidad
			// 
			this.txtCantidad.Location = new System.Drawing.Point(208, 2);
			this.txtCantidad.Name = "txtCantidad";
			this.txtCantidad.Size = new System.Drawing.Size(56, 20);
			this.txtCantidad.TabIndex = 52;
			this.txtCantidad.Text = "";
			this.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ValePromocional
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtCantidad,
																		  this.lblDenominacion,
																		  this.lblPromocion});
			this.Name = "ValePromocional";
			this.Size = new System.Drawing.Size(268, 23);
			this.ResumeLayout(false);

		}
		#endregion
	}
}
