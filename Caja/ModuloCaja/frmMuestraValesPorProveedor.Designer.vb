<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMuestraValesPorProveedor
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
		Me.grdVales = New System.Windows.Forms.DataGrid()
		CType(Me.grdVales, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'grdVales
		'
		Me.grdVales.BackgroundColor = System.Drawing.Color.Gainsboro
		Me.grdVales.CaptionBackColor = System.Drawing.Color.DarkSeaGreen
		Me.grdVales.CaptionText = "Vales en este movimiento"
		Me.grdVales.DataMember = ""
		Me.grdVales.Dock = System.Windows.Forms.DockStyle.Fill
		Me.grdVales.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.grdVales.HeaderForeColor = System.Drawing.SystemColors.ControlText
		Me.grdVales.Location = New System.Drawing.Point(0, 0)
		Me.grdVales.Name = "grdVales"
		Me.grdVales.ReadOnly = True
		Me.grdVales.Size = New System.Drawing.Size(350, 261)
		Me.grdVales.TabIndex = 1
		'
		'frmMuestraValesPorProveedor
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(350, 261)
		Me.Controls.Add(Me.grdVales)
		Me.Name = "frmMuestraValesPorProveedor"
		Me.Text = "Cobro con vales"
		CType(Me.grdVales, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)

	End Sub

	Friend WithEvents grdVales As DataGrid
End Class
