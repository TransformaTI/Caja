Public Class About
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
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents lblCodebase As System.Windows.Forms.Label
    Friend WithEvents lblCopyright As System.Windows.Forms.Label
    Friend WithEvents lblDescription As System.Windows.Forms.Label
    Friend WithEvents lblVersion As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pbIcon As System.Windows.Forms.PictureBox
    Friend WithEvents lbCompany As System.Windows.Forms.Label
    Friend WithEvents lbProduct As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.lblCodebase = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pbIcon = New System.Windows.Forms.PictureBox()
        Me.lbCompany = New System.Windows.Forms.Label()
        Me.lbProduct = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnAceptar
        '
        Me.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnAceptar.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnAceptar.Location = New System.Drawing.Point(344, 214)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(80, 23)
        Me.btnAceptar.TabIndex = 5
        Me.btnAceptar.Text = "Cerrar"
        '
        'lblCodebase
        '
        Me.lblCodebase.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCodebase.Location = New System.Drawing.Point(64, 170)
        Me.lblCodebase.Name = "lblCodebase"
        Me.lblCodebase.Size = New System.Drawing.Size(360, 38)
        Me.lblCodebase.TabIndex = 12
        Me.lblCodebase.Text = "Application Codebase"
        '
        'lblCopyright
        '
        Me.lblCopyright.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblCopyright.Location = New System.Drawing.Point(64, 103)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(360, 25)
        Me.lblCopyright.TabIndex = 11
        Me.lblCopyright.Text = "Application Copyright"
        '
        'lblDescription
        '
        Me.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblDescription.Location = New System.Drawing.Point(64, 134)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(360, 34)
        Me.lblDescription.TabIndex = 10
        Me.lblDescription.Text = "Application Description"
        '
        'lblVersion
        '
        Me.lblVersion.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblVersion.Location = New System.Drawing.Point(64, 34)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(360, 14)
        Me.lblVersion.TabIndex = 9
        Me.lblVersion.Text = "Application Version"
        '
        'lblTitle
        '
        Me.lblTitle.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitle.Location = New System.Drawing.Point(66, 11)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(360, 23)
        Me.lblTitle.TabIndex = 8
        Me.lblTitle.Text = "Application Title"
        '
        'pbIcon
        '
        Me.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.pbIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.pbIcon.Location = New System.Drawing.Point(10, 11)
        Me.pbIcon.Name = "pbIcon"
        Me.pbIcon.Size = New System.Drawing.Size(46, 45)
        Me.pbIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbIcon.TabIndex = 7
        Me.pbIcon.TabStop = False
        '
        'lbCompany
        '
        Me.lbCompany.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbCompany.Location = New System.Drawing.Point(64, 78)
        Me.lbCompany.Name = "lbCompany"
        Me.lbCompany.Size = New System.Drawing.Size(360, 23)
        Me.lbCompany.TabIndex = 13
        Me.lbCompany.Text = "Application Company"
        '
        'lbProduct
        '
        Me.lbProduct.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lbProduct.Location = New System.Drawing.Point(64, 51)
        Me.lbProduct.Name = "lbProduct"
        Me.lbProduct.Size = New System.Drawing.Size(360, 23)
        Me.lbProduct.TabIndex = 14
        Me.lbProduct.Text = "Application Product"
        '
        'About
        '
        Me.AcceptButton = Me.btnAceptar
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.CancelButton = Me.btnAceptar
        Me.ClientSize = New System.Drawing.Size(434, 242)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.lbProduct, Me.lbCompany, Me.lblCodebase, Me.lblCopyright, Me.lblDescription, Me.lblVersion, Me.lblTitle, Me.pbIcon, Me.btnAceptar})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "About"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Acerca de ..."
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub About_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = "About " & Me.Owner.Text
        Me.Icon = Me.Owner.Icon
        Me.pbIcon.Image = Me.Owner.Icon.ToBitmap()
        ' Set the labels identitying the Title, Version, and Description by
        ' reading Assembly meta-data originally entered in the AssemblyInfo.vb file
        ' using the AssemblyInfo class defined in the same file
        Dim ainfo As New AssemblyInfo()
        Me.lblTitle.Text = ainfo.Title
        Me.lblVersion.Text = String.Format("Version {0}", ainfo.Version)
        Me.lblCopyright.Text = ainfo.Copyright
        Me.lblDescription.Text = ainfo.Description
        Me.lblCodebase.Text = ainfo.CodeBase
        Me.lbProduct.Text = ainfo.Product
        Me.lbCompany.Text = ainfo.Company
    End Sub
End Class
