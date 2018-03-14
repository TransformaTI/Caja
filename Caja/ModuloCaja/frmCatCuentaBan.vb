

Public Class frmCatCuentaBan
    Inherits CatalogoBase.frmCatalogo

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'grdDatos
        '
        Me.grdDatos.AccessibleName = "DataGrid"
        Me.grdDatos.AccessibleRole = System.Windows.Forms.AccessibleRole.Table
        Me.grdDatos.Visible = True
        '
        'tabDatos
        '
        Me.tabDatos.ItemSize = New System.Drawing.Size(48, 18)
        Me.tabDatos.Visible = True
        '
        'tbrBarra
        '
        Me.tbrBarra.ButtonSize = New System.Drawing.Size(54, 36)
        Me.tbrBarra.Visible = True
        '
        'frmCatCuentaBan
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(568, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabDatos, Me.grdDatos, Me.tbrBarra})
        Me.Name = "frmCatCuentaBan"
        Me.Text = "Catálogo de cuentas bancarias"
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class
