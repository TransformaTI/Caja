using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ActualizacionCobranza
{
	/// <summary>
	/// Summary description for ActualizacionCobranza.
	/// </summary>
	public class ActualizacionCobranza : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components;

		private DAC _data;
		private System.Windows.Forms.DateTimePicker dtpNuevaFMovimiento;
		private CustGrd.vwGrd grdMovimientosOk;
		private CustGrd.vwGrd grdMovimientosErroneos;
		private CustGrd.vwGrd grdDetalleMovimientosErroneos;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label lblDetalleMovimientos;
		private System.Windows.Forms.Label lblMovimientosErroneos;
		private System.Windows.Forms.Label lblMovimientosOK;
		private CustGrd.vwGrd grdListaOrigen;
		private System.Windows.Forms.ToolBarButton btnTBAProcesar;
		private System.Windows.Forms.ToolBarButton btnTB;
		private System.Windows.Forms.ToolBarButton btnCargar;
		private System.Windows.Forms.ToolBarButton btnVerificar;
		private System.Windows.Forms.ToolBarButton btnProcesar;
		private System.Windows.Forms.ToolBarButton btnCancelar;
		private System.Windows.Forms.ToolBarButton btnSalir;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar tbFMov;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.StatusBarPanel statusBarPanel1;
		private System.Windows.Forms.LinkLabel lnkExportar;
		private System.Windows.Forms.TextBox txtNvoMovimiento;
		private System.Windows.Forms.Button btnAgregarMovimiento;
		private System.Windows.Forms.ContextMenu mnuListaMovimientos;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Data.SqlClient.SqlConnection _connection;

		public ActualizacionCobranza(string Usuario, System.Data.SqlClient.SqlConnection Connection)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			_connection = Connection;
			_data = new DAC(Usuario, _connection);
			
			
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(ActualizacionCobranza));
			this.grdMovimientosErroneos = new CustGrd.vwGrd();
			this.grdDetalleMovimientosErroneos = new CustGrd.vwGrd();
			this.dtpNuevaFMovimiento = new System.Windows.Forms.DateTimePicker();
			this.grdMovimientosOk = new CustGrd.vwGrd();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
			this.lblDetalleMovimientos = new System.Windows.Forms.Label();
			this.lblMovimientosErroneos = new System.Windows.Forms.Label();
			this.lblMovimientosOK = new System.Windows.Forms.Label();
			this.grdListaOrigen = new CustGrd.vwGrd();
			this.tbFMov = new System.Windows.Forms.ToolBar();
			this.btnCargar = new System.Windows.Forms.ToolBarButton();
			this.btnVerificar = new System.Windows.Forms.ToolBarButton();
			this.btnProcesar = new System.Windows.Forms.ToolBarButton();
			this.btnCancelar = new System.Windows.Forms.ToolBarButton();
			this.btnSalir = new System.Windows.Forms.ToolBarButton();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.btnTBAProcesar = new System.Windows.Forms.ToolBarButton();
			this.btnTB = new System.Windows.Forms.ToolBarButton();
			this.label1 = new System.Windows.Forms.Label();
			this.lnkExportar = new System.Windows.Forms.LinkLabel();
			this.txtNvoMovimiento = new System.Windows.Forms.TextBox();
			this.btnAgregarMovimiento = new System.Windows.Forms.Button();
			this.mnuListaMovimientos = new System.Windows.Forms.ContextMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
			this.SuspendLayout();
			// 
			// grdMovimientosErroneos
			// 
			this.grdMovimientosErroneos.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdMovimientosErroneos.ColumnMargin = 20;
			this.grdMovimientosErroneos.FullRowSelect = true;
			this.grdMovimientosErroneos.Location = new System.Drawing.Point(135, 284);
			this.grdMovimientosErroneos.Name = "grdMovimientosErroneos";
			this.grdMovimientosErroneos.Size = new System.Drawing.Size(788, 192);
			this.grdMovimientosErroneos.TabIndex = 2;
			this.grdMovimientosErroneos.View = System.Windows.Forms.View.Details;
			this.grdMovimientosErroneos.ListViewContentChanged += new CustGrd._listViewContentChanged(this.grdMovimientosErroneos_ListViewContentChanged);
			this.grdMovimientosErroneos.SelectedIndexChanged += new System.EventHandler(this.grdMovimientosErroneos_SelectedIndexChanged);
			// 
			// grdDetalleMovimientosErroneos
			// 
			this.grdDetalleMovimientosErroneos.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdDetalleMovimientosErroneos.ColumnMargin = 20;
			this.grdDetalleMovimientosErroneos.FullRowSelect = true;
			this.grdDetalleMovimientosErroneos.Location = new System.Drawing.Point(135, 504);
			this.grdDetalleMovimientosErroneos.Name = "grdDetalleMovimientosErroneos";
			this.grdDetalleMovimientosErroneos.Size = new System.Drawing.Size(788, 172);
			this.grdDetalleMovimientosErroneos.TabIndex = 4;
			this.grdDetalleMovimientosErroneos.View = System.Windows.Forms.View.Details;
			// 
			// dtpNuevaFMovimiento
			// 
			this.dtpNuevaFMovimiento.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.dtpNuevaFMovimiento.Location = new System.Drawing.Point(723, 9);
			this.dtpNuevaFMovimiento.Name = "dtpNuevaFMovimiento";
			this.dtpNuevaFMovimiento.TabIndex = 6;
			// 
			// grdMovimientosOk
			// 
			this.grdMovimientosOk.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.grdMovimientosOk.ColumnMargin = 20;
			this.grdMovimientosOk.FullRowSelect = true;
			this.grdMovimientosOk.Location = new System.Drawing.Point(135, 64);
			this.grdMovimientosOk.Name = "grdMovimientosOk";
			this.grdMovimientosOk.Size = new System.Drawing.Size(788, 192);
			this.grdMovimientosOk.TabIndex = 7;
			this.grdMovimientosOk.View = System.Windows.Forms.View.Details;
			this.grdMovimientosOk.ListViewContentChanged += new CustGrd._listViewContentChanged(this.grdMovimientosOk_ListViewContentChanged);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 679);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						  this.statusBarPanel1});
			this.statusBar1.Size = new System.Drawing.Size(924, 22);
			this.statusBar1.TabIndex = 8;
			// 
			// lblDetalleMovimientos
			// 
			this.lblDetalleMovimientos.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblDetalleMovimientos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblDetalleMovimientos.Location = new System.Drawing.Point(135, 480);
			this.lblDetalleMovimientos.Name = "lblDetalleMovimientos";
			this.lblDetalleMovimientos.Size = new System.Drawing.Size(788, 23);
			this.lblDetalleMovimientos.TabIndex = 9;
			this.lblDetalleMovimientos.Tag = "Detalle de movimientos erróneos";
			this.lblDetalleMovimientos.Text = "Detalle de movimientos erróneos";
			this.lblDetalleMovimientos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMovimientosErroneos
			// 
			this.lblMovimientosErroneos.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblMovimientosErroneos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblMovimientosErroneos.Location = new System.Drawing.Point(135, 260);
			this.lblMovimientosErroneos.Name = "lblMovimientosErroneos";
			this.lblMovimientosErroneos.Size = new System.Drawing.Size(788, 23);
			this.lblMovimientosErroneos.TabIndex = 10;
			this.lblMovimientosErroneos.Tag = "Movimientos erróneos";
			this.lblMovimientosErroneos.Text = "Movimientos erróneos";
			this.lblMovimientosErroneos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// lblMovimientosOK
			// 
			this.lblMovimientosOK.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.lblMovimientosOK.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lblMovimientosOK.Location = new System.Drawing.Point(135, 40);
			this.lblMovimientosOK.Name = "lblMovimientosOK";
			this.lblMovimientosOK.Size = new System.Drawing.Size(788, 23);
			this.lblMovimientosOK.TabIndex = 11;
			this.lblMovimientosOK.Tag = "Movimientos correctos";
			this.lblMovimientosOK.Text = "Movimientos correctos";
			this.lblMovimientosOK.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// grdListaOrigen
			// 
			this.grdListaOrigen.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left);
			this.grdListaOrigen.ColumnMargin = 1;
			this.grdListaOrigen.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.grdListaOrigen.Location = new System.Drawing.Point(1, 64);
			this.grdListaOrigen.Name = "grdListaOrigen";
			this.grdListaOrigen.Size = new System.Drawing.Size(133, 612);
			this.grdListaOrigen.TabIndex = 12;
			this.grdListaOrigen.View = System.Windows.Forms.View.Details;
			// 
			// tbFMov
			// 
			this.tbFMov.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.tbFMov.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																					  this.btnCargar,
																					  this.btnVerificar,
																					  this.btnProcesar,
																					  this.btnCancelar,
																					  this.btnSalir});
			this.tbFMov.DropDownArrows = true;
			this.tbFMov.ImageList = this.imageList1;
			this.tbFMov.Name = "tbFMov";
			this.tbFMov.ShowToolTips = true;
			this.tbFMov.Size = new System.Drawing.Size(924, 39);
			this.tbFMov.TabIndex = 13;
			this.tbFMov.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.tbFMov_ButtonClick);
			// 
			// btnCargar
			// 
			this.btnCargar.ImageIndex = 0;
			this.btnCargar.Tag = "Cargar";
			this.btnCargar.Text = "&Cargar";
			this.btnCargar.ToolTipText = "Cargar movimientos";
			// 
			// btnVerificar
			// 
			this.btnVerificar.ImageIndex = 1;
			this.btnVerificar.Tag = "Verificar";
			this.btnVerificar.Text = "&Verificar";
			this.btnVerificar.ToolTipText = "Verificar movimientos";
			// 
			// btnProcesar
			// 
			this.btnProcesar.ImageIndex = 2;
			this.btnProcesar.Tag = "Procesar";
			this.btnProcesar.Text = "&Procesar";
			this.btnProcesar.ToolTipText = "Procesar cambio de fecha";
			// 
			// btnCancelar
			// 
			this.btnCancelar.ImageIndex = 3;
			this.btnCancelar.Tag = "Cancelar";
			this.btnCancelar.Text = "&Cancelar";
			this.btnCancelar.ToolTipText = "Cancelar";
			// 
			// btnSalir
			// 
			this.btnSalir.ImageIndex = 4;
			this.btnSalir.Tag = "Salir";
			this.btnSalir.Text = "&Salir";
			this.btnSalir.ToolTipText = "Salir";
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// label1
			// 
			this.label1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.Location = new System.Drawing.Point(628, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 14);
			this.label1.TabIndex = 14;
			this.label1.Text = "F. Movimiento:";
			// 
			// lnkExportar
			// 
			this.lnkExportar.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
			this.lnkExportar.AutoSize = true;
			this.lnkExportar.Location = new System.Drawing.Point(836, 484);
			this.lnkExportar.Name = "lnkExportar";
			this.lnkExportar.Size = new System.Drawing.Size(83, 14);
			this.lnkExportar.TabIndex = 15;
			this.lnkExportar.TabStop = true;
			this.lnkExportar.Text = "Exportar detalle";
			this.lnkExportar.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkExportar_LinkClicked);
			// 
			// txtNvoMovimiento
			// 
			this.txtNvoMovimiento.Location = new System.Drawing.Point(1, 40);
			this.txtNvoMovimiento.Multiline = true;
			this.txtNvoMovimiento.Name = "txtNvoMovimiento";
			this.txtNvoMovimiento.Size = new System.Drawing.Size(113, 23);
			this.txtNvoMovimiento.TabIndex = 16;
			this.txtNvoMovimiento.Text = "";
			// 
			// btnAgregarMovimiento
			// 
			this.btnAgregarMovimiento.Location = new System.Drawing.Point(115, 42);
			this.btnAgregarMovimiento.Name = "btnAgregarMovimiento";
			this.btnAgregarMovimiento.Size = new System.Drawing.Size(18, 19);
			this.btnAgregarMovimiento.TabIndex = 17;
			this.btnAgregarMovimiento.Text = "+";
			this.btnAgregarMovimiento.Click += new System.EventHandler(this.btnAgregarMovimiento_Click);
			// 
			// mnuListaMovimientos
			// 
			this.mnuListaMovimientos.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																								this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Eliminar";
			// 
			// ActualizacionCobranza
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
			this.ClientSize = new System.Drawing.Size(924, 701);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnAgregarMovimiento,
																		  this.txtNvoMovimiento,
																		  this.lnkExportar,
																		  this.label1,
																		  this.grdListaOrigen,
																		  this.grdMovimientosOk,
																		  this.grdDetalleMovimientosErroneos,
																		  this.grdMovimientosErroneos,
																		  this.lblMovimientosOK,
																		  this.lblMovimientosErroneos,
																		  this.lblDetalleMovimientos,
																		  this.statusBar1,
																		  this.dtpNuevaFMovimiento,
																		  this.tbFMov});
			this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "ActualizacionCobranza";
			this.Text = "Cambio F. Movimiento";
			this.Load += new System.EventHandler(this.ActualizacionCobranza_Load);
			((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void loadFromFile()
		{
			OpenFileDialog dlgAbrir = new OpenFileDialog();
			dlgAbrir.Multiselect = false;
			dlgAbrir.DefaultExt = "txt";
			dlgAbrir.Filter = "Archivos de texto (*.txt)|*.txt";
			if (dlgAbrir.ShowDialog() == DialogResult.OK)
			{
				_data.LeerClaves(dlgAbrir.FileName);
				grdListaOrigen.DataSource = _data.Movimimientos.Tables["MovimientosOrigen"];
				if (grdListaOrigen.Columns.Count == 0)
					grdListaOrigen.AutoColumnHeader();
				grdListaOrigen.DataAdd();
				gridEnsureVisible(grdListaOrigen);
			}
		}

		private void checkContents()
		{
			try
			{
				_data.ConsultarMovimientos();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			
			_data.DocumentosErroneos(dtpNuevaFMovimiento.Value);

			grdMovimientosOk.DataSource = _data.Movimimientos.Tables["MovimientosOK"];
			grdMovimientosOk.AutoColumnHeader();
			grdMovimientosOk.DataAdd();
			gridEnsureVisible(grdMovimientosOk);

			
			grdDetalleMovimientosErroneos.DataSource = _data.Movimimientos.Tables["ListaDocumentosErroneos"];
			grdDetalleMovimientosErroneos.AutoColumnHeader();
			grdDetalleMovimientosErroneos.DataAdd();
			gridEnsureVisible(grdDetalleMovimientosErroneos);

			grdMovimientosErroneos.DataSource = _data.Movimimientos.Tables["MovimientosErroneos"];
			grdMovimientosErroneos.AutoColumnHeader();
			grdMovimientosErroneos.DataAdd();
			gridEnsureVisible(grdMovimientosErroneos);
		}

		private void grdMovimientosOk_ListViewContentChanged(object sender, System.EventArgs e)
		{
			lblMovimientosOK.Text = lblMovimientosOK.Tag.ToString();
            lblMovimientosOK.Text = lblMovimientosOK.Tag.ToString() + " (" +
				_data.Movimimientos.Tables["MovimientosOK"].Rows.Count + " Movimientos / Total $ " +
				_data.Movimimientos.Tables["MovimientosOK"].Compute("SUM(Total)", "") +")";
		}

		private void gridSummary(CustGrd.vwGrd Grid, Label GrdLabel, double Count)
		{
			GrdLabel.Tag = GrdLabel.Tag + " " + Grid.Items.Count.ToString() + " registros";
		}

		private void gridEnsureVisible(CustGrd.vwGrd Grid)
		{
			if (Grid.Items.Count > 0)
				Grid.EnsureVisible(0);
		}

		private void grdMovimientosErroneos_ListViewContentChanged(object sender, System.EventArgs e)
		{
			lblMovimientosErroneos.Text = lblDetalleMovimientos.Tag.ToString();
			lblMovimientosErroneos.Text = lblMovimientosErroneos.Tag.ToString() + " (" +
				_data.Movimimientos.Tables["MovimientosErroneos"].Rows.Count + " Movimientos / Total $ " +
				_data.Movimimientos.Tables["MovimientosErroneos"].Compute("SUM(Total)", "") +")";
		}

		private void procesarFMovimiento()
		{
			if ((_data.Movimimientos.Tables["MovimientosErroneos"].Rows.Count > 0) &&
				(MessageBox.Show("Hay registros que no podrán ser procesados por incongruencia" + (char)13 +
					"entre FCargo y FMovimiento, ¿Desea continuar?", this.Text, MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning) == DialogResult.No))
				{
					return;
				}
			if (MessageBox.Show("Se cambiará la FMovimiento de " + _data.Movimimientos.Tables["MovimientosOK"].Rows.Count.ToString() +
					" movimientos" + (char)13 + " ¿Desea continuar?", this.Text, MessageBoxButtons.YesNo,
					MessageBoxIcon.Warning) == DialogResult.No)
				{
					return;
				}
			try
			{
				this.Cursor = Cursors.WaitCursor;
				if (_data.ProcesarFMovimiento(dtpNuevaFMovimiento.Value))
				{
					MessageBox.Show("Movimientos actualizados correctamente", this.Text, MessageBoxButtons.OK,
						MessageBoxIcon.Information);
				}
			}
			catch (Exception ex)
			{
				this.Cursor = Cursors.Default;
				MessageBox.Show("Ha ocurrido el siguiente error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
			finally
			{
				this.Cursor = Cursors.Default;
			}
		}

		private void tbFMov_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (e.Button.Tag.ToString())
			{
				case "Cargar":
					loadFromFile();
					break;
				case "Verificar":
					checkContents();
					break;
				case "Procesar":
					procesarFMovimiento();
					break;
				case "Cancelar":
					cancelar();
					break;
				case "Salir":
					exitForm();
					break;
			}
		}

		private void cancelar()
		{
			if (MessageBox.Show("¿Desea cancelar la modificación" + (char)13 + "de las cobranzas cargadas?",
				this.Text,  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				_data.ResetData();
				grdListaOrigen.Items.Clear();
				grdMovimientosOk.Items.Clear();
				grdMovimientosErroneos.Items.Clear();
				grdDetalleMovimientosErroneos.Items.Clear();
			}
		}

		private void exitForm()
		{
			if (MessageBox.Show("¿Desea cerrar la pantalla de cambio" + (char)13 +
					"de movimientos de cobranza?", this.Text,  MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				this.Close();
				this.Dispose();
			}
		}

		private void ActualizacionCobranza_Load(object sender, System.EventArgs e)
		{
			
		}

		private void grdMovimientosErroneos_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lnkExportar_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			SaveFileDialog dlgGuardar = new SaveFileDialog();

			dlgGuardar.DefaultExt = "csv";
			dlgGuardar.Filter = "Archivos CSV (*.csv)|*.csv";
			dlgGuardar.OverwritePrompt = true;

			try
			{
				if (dlgGuardar.ShowDialog() == DialogResult.OK)
				{
					Exporting.TXTExporting ex = new Exporting.TXTExporting();
					ex.Export(_data.Movimimientos.Tables["ListaDocumentosErroneos"], dlgGuardar.FileName, true);
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido el siguiente error:" + (char)13 + ex.Message, this.Text, MessageBoxButtons.OK,
					MessageBoxIcon.Error);
			}
		}

		private void btnAgregarMovimiento_Click(object sender, System.EventArgs e)
		{
			_data.AgregarMovimientoOrigen(txtNvoMovimiento.Text.Trim());
			grdListaOrigen.Items.Clear();
			grdListaOrigen.DataSource = _data.Movimimientos.Tables["MovimientosOrigen"];
			if (grdListaOrigen.Columns.Count == 0)
				grdListaOrigen.AutoColumnHeader();
			grdListaOrigen.DataAdd();
			gridEnsureVisible(grdListaOrigen);
		}
	}
}
