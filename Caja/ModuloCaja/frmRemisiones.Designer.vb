<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRemisiones
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btn_Aceptar = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lbl_Total = New System.Windows.Forms.Label()
        Me.lbl_saldo = New System.Windows.Forms.Label()
        Me.lbl_importeDocumento = New System.Windows.Forms.Label()
        Me.lblSaloMovimiento = New System.Windows.Forms.Label()
        Me.lblImporteAbobo = New System.Windows.Forms.Label()
        Me.btn_aceptarAbonos = New System.Windows.Forms.Button()
        Me.btn_cancelar = New System.Windows.Forms.Button()
        Me.grdRemisiones = New System.Windows.Forms.DataGrid()
        Me.grdAbonos = New System.Windows.Forms.DataGrid()
        CType(Me.grdRemisiones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdAbonos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_Aceptar
        '
        Me.btn_Aceptar.Location = New System.Drawing.Point(48, 185)
        Me.btn_Aceptar.Name = "btn_Aceptar"
        Me.btn_Aceptar.Size = New System.Drawing.Size(75, 23)
        Me.btn_Aceptar.TabIndex = 1
        Me.btn_Aceptar.Text = "Aceptar"
        Me.btn_Aceptar.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 230)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Captura de abono a pedido"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 257)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Total:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 280)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Saldo:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(118, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Importe del documento:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 337)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Saldo en movimiento:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Importe para el abono:"
        '
        'lbl_Total
        '
        Me.lbl_Total.AutoSize = True
        Me.lbl_Total.Location = New System.Drawing.Point(147, 257)
        Me.lbl_Total.Name = "lbl_Total"
        Me.lbl_Total.Size = New System.Drawing.Size(46, 13)
        Me.lbl_Total.TabIndex = 8
        Me.lbl_Total.Text = "$000.00"
        '
        'lbl_saldo
        '
        Me.lbl_saldo.AutoSize = True
        Me.lbl_saldo.Location = New System.Drawing.Point(147, 280)
        Me.lbl_saldo.Name = "lbl_saldo"
        Me.lbl_saldo.Size = New System.Drawing.Size(46, 13)
        Me.lbl_saldo.TabIndex = 9
        Me.lbl_saldo.Text = "$000.00"
        '
        'lbl_importeDocumento
        '
        Me.lbl_importeDocumento.AutoSize = True
        Me.lbl_importeDocumento.Location = New System.Drawing.Point(147, 310)
        Me.lbl_importeDocumento.Name = "lbl_importeDocumento"
        Me.lbl_importeDocumento.Size = New System.Drawing.Size(46, 13)
        Me.lbl_importeDocumento.TabIndex = 10
        Me.lbl_importeDocumento.Text = "$000.00"
        '
        'lblSaloMovimiento
        '
        Me.lblSaloMovimiento.AutoSize = True
        Me.lblSaloMovimiento.Location = New System.Drawing.Point(147, 337)
        Me.lblSaloMovimiento.Name = "lblSaloMovimiento"
        Me.lblSaloMovimiento.Size = New System.Drawing.Size(46, 13)
        Me.lblSaloMovimiento.TabIndex = 11
        Me.lblSaloMovimiento.Text = "$000.00"
        '
        'lblImporteAbobo
        '
        Me.lblImporteAbobo.AutoSize = True
        Me.lblImporteAbobo.Location = New System.Drawing.Point(147, 368)
        Me.lblImporteAbobo.Name = "lblImporteAbobo"
        Me.lblImporteAbobo.Size = New System.Drawing.Size(46, 13)
        Me.lblImporteAbobo.TabIndex = 12
        Me.lblImporteAbobo.Text = "$000.00"
        '
        'btn_aceptarAbonos
        '
        Me.btn_aceptarAbonos.Location = New System.Drawing.Point(295, 387)
        Me.btn_aceptarAbonos.Name = "btn_aceptarAbonos"
        Me.btn_aceptarAbonos.Size = New System.Drawing.Size(112, 23)
        Me.btn_aceptarAbonos.TabIndex = 13
        Me.btn_aceptarAbonos.Text = "Aceptar abonos"
        Me.btn_aceptarAbonos.UseVisualStyleBackColor = True
        '
        'btn_cancelar
        '
        Me.btn_cancelar.Location = New System.Drawing.Point(441, 387)
        Me.btn_cancelar.Name = "btn_cancelar"
        Me.btn_cancelar.Size = New System.Drawing.Size(112, 23)
        Me.btn_cancelar.TabIndex = 14
        Me.btn_cancelar.Text = "Cancelar"
        Me.btn_cancelar.UseVisualStyleBackColor = True
        '
        'grdRemisiones
        '
        Me.grdRemisiones.AccessibleName = ""
        Me.grdRemisiones.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdRemisiones.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdRemisiones.CaptionBackColor = System.Drawing.SystemColors.ScrollBar
        Me.grdRemisiones.CaptionText = "Remisiones"
        Me.grdRemisiones.DataMember = ""
        Me.grdRemisiones.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRemisiones.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdRemisiones.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdRemisiones.Location = New System.Drawing.Point(36, 12)
        Me.grdRemisiones.Name = "grdRemisiones"
        Me.grdRemisiones.ReadOnly = True
        Me.grdRemisiones.Size = New System.Drawing.Size(809, 149)
        Me.grdRemisiones.TabIndex = 43
        '
        'grdAbonos
        '
        Me.grdAbonos.AccessibleName = ""
        Me.grdAbonos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdAbonos.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.grdAbonos.CaptionBackColor = System.Drawing.SystemColors.ScrollBar
        Me.grdAbonos.CaptionText = "Abonos"
        Me.grdAbonos.DataMember = ""
        Me.grdAbonos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAbonos.HeaderFont = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grdAbonos.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.grdAbonos.Location = New System.Drawing.Point(441, 230)
        Me.grdAbonos.Name = "grdAbonos"
        Me.grdAbonos.ReadOnly = True
        Me.grdAbonos.Size = New System.Drawing.Size(196, 62)
        Me.grdAbonos.TabIndex = 44
        '
        'frmRemisiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(857, 441)
        Me.Controls.Add(Me.grdAbonos)
        Me.Controls.Add(Me.grdRemisiones)
        Me.Controls.Add(Me.btn_cancelar)
        Me.Controls.Add(Me.btn_aceptarAbonos)
        Me.Controls.Add(Me.lblImporteAbobo)
        Me.Controls.Add(Me.lblSaloMovimiento)
        Me.Controls.Add(Me.lbl_importeDocumento)
        Me.Controls.Add(Me.lbl_saldo)
        Me.Controls.Add(Me.lbl_Total)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_Aceptar)
        Me.Name = "frmRemisiones"
        Me.Text = "Remisiones"
        CType(Me.grdRemisiones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdAbonos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_Aceptar As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lbl_Total As Label
    Friend WithEvents lbl_saldo As Label
    Friend WithEvents lbl_importeDocumento As Label
    Friend WithEvents lblSaloMovimiento As Label
    Friend WithEvents lblImporteAbobo As Label
    Friend WithEvents btn_aceptarAbonos As Button
    Friend WithEvents btn_cancelar As Button
    Friend WithEvents grdRemisiones As DataGrid
    Friend WithEvents grdAbonos As DataGrid
End Class
