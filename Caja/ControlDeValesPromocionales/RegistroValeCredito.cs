using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace ControlDeValesPromocionales
{
	/// <summary>
	/// Summary description for RegistroValeCredito.
	/// </summary>
	public class RegistroValeCredito : System.Windows.Forms.UserControl
	{
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label29;
		internal System.Windows.Forms.Label txtTotalVales;
		private System.Windows.Forms.Button btnValePromocion;
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

//		public event EventHandler Click;
//
//		public void OnClick(EventArgs e)
//		{
//			if (Click != null)
//			{
//				Click(this, e);
//			}
//		}

		public decimal Total
		{
			set
			{
				txtTotalVales.Text = value.ToString("C");
			}
		}

		public RegistroValeCredito()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitForm call
			
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Label1 = new System.Windows.Forms.Label();
			this.Label29 = new System.Windows.Forms.Label();
			this.txtTotalVales = new System.Windows.Forms.Label();
			this.btnValePromocion = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Label1
			// 
			this.Label1.AutoSize = true;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Label1.Location = new System.Drawing.Point(4, 4);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(76, 13);
			this.Label1.TabIndex = 82;
			this.Label1.Text = "Promociones:";
			// 
			// Label29
			// 
			this.Label29.AutoSize = true;
			this.Label29.Location = new System.Drawing.Point(4, 50);
			this.Label29.Name = "Label29";
			this.Label29.Size = new System.Drawing.Size(33, 13);
			this.Label29.TabIndex = 81;
			this.Label29.Text = "Total:";
			// 
			// txtTotalVales
			// 
			this.txtTotalVales.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtTotalVales.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtTotalVales.Location = new System.Drawing.Point(44, 44);
			this.txtTotalVales.Name = "txtTotalVales";
			this.txtTotalVales.Size = new System.Drawing.Size(88, 24);
			this.txtTotalVales.TabIndex = 80;
			this.txtTotalVales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnValePromocion
			// 
			this.btnValePromocion.Location = new System.Drawing.Point(4, 20);
			this.btnValePromocion.Name = "btnValePromocion";
			this.btnValePromocion.Size = new System.Drawing.Size(128, 20);
			this.btnValePromocion.TabIndex = 83;
			this.btnValePromocion.Text = "Capturar vales";
			this.btnValePromocion.Click += new System.EventHandler(this.btnValePromocion_Click);
			// 
			// RegistroValeCredito
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnValePromocion,
																		  this.Label1,
																		  this.Label29,
																		  this.txtTotalVales});
			this.Name = "RegistroValeCredito";
			this.Size = new System.Drawing.Size(136, 68);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnValePromocion_Click(object sender, System.EventArgs e)
		{
			this.OnClick(e);
		}
	}
}
