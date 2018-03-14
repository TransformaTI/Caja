using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Filiales
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.DataGrid dataGrid2;
		private System.Windows.Forms.Button btnBuscarCliente;
		private System.Windows.Forms.Button btnInactivarCliente;
		private System.Windows.Forms.Button btnBuscarLocal;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.dataGrid2 = new System.Windows.Forms.DataGrid();
			this.btnBuscarCliente = new System.Windows.Forms.Button();
			this.btnInactivarCliente = new System.Windows.Forms.Button();
			this.btnBuscarLocal = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).BeginInit();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(168, 4);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(620, 148);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "groupBox1";
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(168, 160);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(620, 408);
			this.dataGrid1.TabIndex = 1;
			// 
			// dataGrid2
			// 
			this.dataGrid2.DataMember = "";
			this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid2.Location = new System.Drawing.Point(4, 44);
			this.dataGrid2.Name = "dataGrid2";
			this.dataGrid2.Size = new System.Drawing.Size(160, 524);
			this.dataGrid2.TabIndex = 2;
			// 
			// btnBuscarCliente
			// 
			this.btnBuscarCliente.Location = new System.Drawing.Point(4, 12);
			this.btnBuscarCliente.Name = "btnBuscarCliente";
			this.btnBuscarCliente.Size = new System.Drawing.Size(32, 23);
			this.btnBuscarCliente.TabIndex = 0;
			this.btnBuscarCliente.Text = "button1";
			// 
			// btnInactivarCliente
			// 
			this.btnInactivarCliente.Location = new System.Drawing.Point(36, 12);
			this.btnInactivarCliente.Name = "btnInactivarCliente";
			this.btnInactivarCliente.Size = new System.Drawing.Size(32, 23);
			this.btnInactivarCliente.TabIndex = 3;
			this.btnInactivarCliente.Text = "button2";
			// 
			// btnBuscarLocal
			// 
			this.btnBuscarLocal.Location = new System.Drawing.Point(132, 12);
			this.btnBuscarLocal.Name = "btnBuscarLocal";
			this.btnBuscarLocal.Size = new System.Drawing.Size(32, 23);
			this.btnBuscarLocal.TabIndex = 0;
			this.btnBuscarLocal.Text = "button3";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 573);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnInactivarCliente,
																		  this.dataGrid2,
																		  this.dataGrid1,
																		  this.groupBox1,
																		  this.btnBuscarCliente,
																		  this.btnBuscarLocal});
			this.Name = "Form1";
			this.Text = "Form1";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid2)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
	}
}
