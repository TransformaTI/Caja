Public Class frmPreLiquidacionConsulta
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents btnCerrar As ControlesBase.BotonBase
    Friend WithEvents lblCelula As ControlesBase.LabelBase
    Friend WithEvents InfoPreliq As SigaMetClasses.InfoPreliq
    Friend WithEvents grpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents LabelBase5 As ControlesBase.LabelBase
    Friend WithEvents LabelBase4 As ControlesBase.LabelBase
    Friend WithEvents LabelBase3 As ControlesBase.LabelBase
    Friend WithEvents LabelBase2 As ControlesBase.LabelBase
    Friend WithEvents LabelBase1 As ControlesBase.LabelBase
    Friend WithEvents lblImporteCredito As System.Windows.Forms.Label
    Friend WithEvents lblImporteContado As System.Windows.Forms.Label
    Friend WithEvents lblLitrosVendidos As System.Windows.Forms.Label
    Friend WithEvents lblFTermino As System.Windows.Forms.Label
    Friend WithEvents lblAutotanque As System.Windows.Forms.Label
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblFAsignacion As ControlesBase.LabelBase
    Friend WithEvents lblNota As System.Windows.Forms.Label
    Friend WithEvents ComboCelula As SigaMetClasses.Combos.ComboCelula
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPreLiquidacionConsulta))
        Me.btnCerrar = New ControlesBase.BotonBase()
        Me.lblCelula = New ControlesBase.LabelBase()
        Me.grpDatos = New System.Windows.Forms.GroupBox()
        Me.LabelBase5 = New ControlesBase.LabelBase()
        Me.LabelBase4 = New ControlesBase.LabelBase()
        Me.LabelBase3 = New ControlesBase.LabelBase()
        Me.LabelBase2 = New ControlesBase.LabelBase()
        Me.LabelBase1 = New ControlesBase.LabelBase()
        Me.lblImporteCredito = New System.Windows.Forms.Label()
        Me.lblImporteContado = New System.Windows.Forms.Label()
        Me.lblLitrosVendidos = New System.Windows.Forms.Label()
        Me.lblFTermino = New System.Windows.Forms.Label()
        Me.lblAutotanque = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.lblFAsignacion = New ControlesBase.LabelBase()
        Me.lblNota = New System.Windows.Forms.Label()
        Me.ComboCelula = New SigaMetClasses.Combos.ComboCelula()
        Me.InfoPreliq = New SigaMetClasses.InfoPreliq()
        Me.grpDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCerrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCerrar.Image = CType(resources.GetObject("btnCerrar.Image"), System.Drawing.Image)
        Me.btnCerrar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCerrar.Location = New System.Drawing.Point(466, 24)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(80, 24)
        Me.btnCerrar.TabIndex = 4
        Me.btnCerrar.Text = "&Cerrar"
        Me.btnCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'lblCelula
        '
        Me.lblCelula.AutoSize = True
        Me.lblCelula.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCelula.Location = New System.Drawing.Point(16, 8)
        Me.lblCelula.Name = "lblCelula"
        Me.lblCelula.Size = New System.Drawing.Size(41, 13)
        Me.lblCelula.TabIndex = 7
        Me.lblCelula.Text = "Célula"
        '
        'grpDatos
        '
        Me.grpDatos.Controls.Add(Me.LabelBase5)
        Me.grpDatos.Controls.Add(Me.LabelBase4)
        Me.grpDatos.Controls.Add(Me.LabelBase3)
        Me.grpDatos.Controls.Add(Me.LabelBase2)
        Me.grpDatos.Controls.Add(Me.LabelBase1)
        Me.grpDatos.Controls.Add(Me.lblImporteCredito)
        Me.grpDatos.Controls.Add(Me.lblImporteContado)
        Me.grpDatos.Controls.Add(Me.lblLitrosVendidos)
        Me.grpDatos.Controls.Add(Me.lblFTermino)
        Me.grpDatos.Controls.Add(Me.lblAutotanque)
        Me.grpDatos.Location = New System.Drawing.Point(184, 64)
        Me.grpDatos.Name = "grpDatos"
        Me.grpDatos.Size = New System.Drawing.Size(360, 296)
        Me.grpDatos.TabIndex = 10
        Me.grpDatos.TabStop = False
        Me.grpDatos.Text = "Datos de la pre-liquidación"
        '
        'LabelBase5
        '
        Me.LabelBase5.AutoSize = True
        Me.LabelBase5.Location = New System.Drawing.Point(16, 172)
        Me.LabelBase5.Name = "LabelBase5"
        Me.LabelBase5.Size = New System.Drawing.Size(85, 13)
        Me.LabelBase5.TabIndex = 29
        Me.LabelBase5.Text = "Importe crédito:"
        '
        'LabelBase4
        '
        Me.LabelBase4.AutoSize = True
        Me.LabelBase4.Location = New System.Drawing.Point(16, 140)
        Me.LabelBase4.Name = "LabelBase4"
        Me.LabelBase4.Size = New System.Drawing.Size(91, 13)
        Me.LabelBase4.TabIndex = 28
        Me.LabelBase4.Text = "Importe contado:"
        '
        'LabelBase3
        '
        Me.LabelBase3.AutoSize = True
        Me.LabelBase3.Location = New System.Drawing.Point(16, 108)
        Me.LabelBase3.Name = "LabelBase3"
        Me.LabelBase3.Size = New System.Drawing.Size(83, 13)
        Me.LabelBase3.TabIndex = 27
        Me.LabelBase3.Text = "Litros vendidos:"
        '
        'LabelBase2
        '
        Me.LabelBase2.AutoSize = True
        Me.LabelBase2.Location = New System.Drawing.Point(16, 76)
        Me.LabelBase2.Name = "LabelBase2"
        Me.LabelBase2.Size = New System.Drawing.Size(79, 13)
        Me.LabelBase2.TabIndex = 26
        Me.LabelBase2.Text = "Fecha termino:"
        '
        'LabelBase1
        '
        Me.LabelBase1.AutoSize = True
        Me.LabelBase1.Location = New System.Drawing.Point(16, 44)
        Me.LabelBase1.Name = "LabelBase1"
        Me.LabelBase1.Size = New System.Drawing.Size(68, 13)
        Me.LabelBase1.TabIndex = 25
        Me.LabelBase1.Text = "Autotanque:"
        '
        'lblImporteCredito
        '
        Me.lblImporteCredito.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteCredito.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteCredito.ForeColor = System.Drawing.Color.Blue
        Me.lblImporteCredito.Location = New System.Drawing.Point(120, 168)
        Me.lblImporteCredito.Name = "lblImporteCredito"
        Me.lblImporteCredito.Size = New System.Drawing.Size(224, 23)
        Me.lblImporteCredito.TabIndex = 24
        Me.lblImporteCredito.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblImporteContado
        '
        Me.lblImporteContado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblImporteContado.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblImporteContado.ForeColor = System.Drawing.Color.Blue
        Me.lblImporteContado.Location = New System.Drawing.Point(120, 136)
        Me.lblImporteContado.Name = "lblImporteContado"
        Me.lblImporteContado.Size = New System.Drawing.Size(224, 23)
        Me.lblImporteContado.TabIndex = 23
        Me.lblImporteContado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLitrosVendidos
        '
        Me.lblLitrosVendidos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblLitrosVendidos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLitrosVendidos.ForeColor = System.Drawing.Color.Blue
        Me.lblLitrosVendidos.Location = New System.Drawing.Point(120, 104)
        Me.lblLitrosVendidos.Name = "lblLitrosVendidos"
        Me.lblLitrosVendidos.Size = New System.Drawing.Size(224, 23)
        Me.lblLitrosVendidos.TabIndex = 22
        Me.lblLitrosVendidos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblFTermino
        '
        Me.lblFTermino.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblFTermino.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFTermino.ForeColor = System.Drawing.Color.Blue
        Me.lblFTermino.Location = New System.Drawing.Point(120, 72)
        Me.lblFTermino.Name = "lblFTermino"
        Me.lblFTermino.Size = New System.Drawing.Size(224, 23)
        Me.lblFTermino.TabIndex = 21
        Me.lblFTermino.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAutotanque
        '
        Me.lblAutotanque.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAutotanque.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAutotanque.ForeColor = System.Drawing.Color.Blue
        Me.lblAutotanque.Location = New System.Drawing.Point(120, 40)
        Me.lblAutotanque.Name = "lblAutotanque"
        Me.lblAutotanque.Size = New System.Drawing.Size(224, 23)
        Me.lblAutotanque.TabIndex = 20
        Me.lblAutotanque.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(16, 72)
        Me.dtpFecha.MaxDate = New Date(2500, 12, 31, 0, 0, 0, 0)
        Me.dtpFecha.MinDate = New Date(1999, 1, 1, 0, 0, 0, 0)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(152, 21)
        Me.dtpFecha.TabIndex = 11
        Me.dtpFecha.Value = New Date(2010, 12, 31, 0, 0, 0, 0)
        '
        'lblFAsignacion
        '
        Me.lblFAsignacion.AutoSize = True
        Me.lblFAsignacion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFAsignacion.Location = New System.Drawing.Point(16, 56)
        Me.lblFAsignacion.Name = "lblFAsignacion"
        Me.lblFAsignacion.Size = New System.Drawing.Size(116, 13)
        Me.lblFAsignacion.TabIndex = 12
        Me.lblFAsignacion.Text = "Fecha de operación"
        '
        'lblNota
        '
        Me.lblNota.Location = New System.Drawing.Point(16, 368)
        Me.lblNota.Name = "lblNota"
        Me.lblNota.Size = New System.Drawing.Size(152, 32)
        Me.lblNota.TabIndex = 13
        Me.lblNota.Text = "(* = Indica una ruta que no ha sido pre-liquidada)"
        '
        'ComboCelula
        '
        Me.ComboCelula.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboCelula.ForeColor = System.Drawing.Color.MediumBlue
        Me.ComboCelula.Location = New System.Drawing.Point(19, 24)
        Me.ComboCelula.Name = "ComboCelula"
        Me.ComboCelula.Size = New System.Drawing.Size(152, 21)
        Me.ComboCelula.TabIndex = 14
        '
        'InfoPreliq
        '
        Me.InfoPreliq.Location = New System.Drawing.Point(16, 104)
        Me.InfoPreliq.Name = "InfoPreliq"
        Me.InfoPreliq.Size = New System.Drawing.Size(152, 256)
        Me.InfoPreliq.TabIndex = 9
        '
        'frmPreLiquidacionConsulta
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.BackColor = System.Drawing.Color.Gainsboro
        Me.CancelButton = Me.btnCerrar
        Me.ClientSize = New System.Drawing.Size(554, 415)
        Me.Controls.Add(Me.ComboCelula)
        Me.Controls.Add(Me.lblNota)
        Me.Controls.Add(Me.lblFAsignacion)
        Me.Controls.Add(Me.dtpFecha)
        Me.Controls.Add(Me.grpDatos)
        Me.Controls.Add(Me.InfoPreliq)
        Me.Controls.Add(Me.lblCelula)
        Me.Controls.Add(Me.btnCerrar)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPreLiquidacionConsulta"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Consulta de pre-liquidaciones efectuadas en la célula"
        Me.grpDatos.ResumeLayout(False)
        Me.grpDatos.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub frmPreLiquidacionConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Cursor = Cursors.WaitCursor
        Try
            ComboCelula.CargaDatos()
        Catch ex As Exception
            MessageBox.Show(ex.ToString)
        Finally
            Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub InfoPreliq_RutaSeleccionada() Handles InfoPreliq.RutaSeleccionada
        Cursor = Cursors.WaitCursor
        lblAutotanque.Text = InfoPreliq.Autotanque.ToString
        lblFTermino.Text = CType(InfoPreliq.FTerminoRuta, String)
        lblLitrosVendidos.Text = InfoPreliq.LitrosVendidos.ToString
        lblImporteContado.Text = InfoPreliq.ImporteContado.ToString("C")
        lblImporteCredito.Text = InfoPreliq.ImporteCredito.ToString("C")
        Cursor = Cursors.Default
    End Sub

    Private Sub dtpFecha_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtpFecha.ValueChanged
        If ComboCelula.Items.Count > 0 Then
            InfoPreliq.ConsultaPreLiq(ComboCelula.Celula, CType(dtpFecha.Value.ToShortDateString, Date), CType(dtpFecha.Value.ToShortDateString & " 23:59:59", Date))
        End If
    End Sub

    Private Sub ComboCelula_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboCelula.SelectedIndexChanged
        If ComboCelula.Items.Count > 0 Then
            InfoPreliq.ConsultaPreLiq(ComboCelula.Celula, CType(dtpFecha.Value.ToShortDateString, Date), CType(dtpFecha.Value.ToShortDateString & " 23:59:59", Date))
        End If
    End Sub
End Class