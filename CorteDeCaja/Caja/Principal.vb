Public Class Principal
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
    Friend WithEvents mmPrincipal As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents staPrincipal As System.Windows.Forms.StatusBar
    Friend WithEvents stapUsuario As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stapNombre As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stapCelula As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stapFecha As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stapServidor As System.Windows.Forms.StatusBarPanel
    Friend WithEvents stapDB As System.Windows.Forms.StatusBarPanel
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCorteCaja As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents mnuCorteCajaP As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Principal))
        Me.mmPrincipal = New System.Windows.Forms.MainMenu()
        Me.MenuItem2 = New System.Windows.Forms.MenuItem()
        Me.MenuItem15 = New System.Windows.Forms.MenuItem()
        Me.MenuItem20 = New System.Windows.Forms.MenuItem()
        Me.mnuCorteCaja = New System.Windows.Forms.MenuItem()
        Me.mnuCorteCajaP = New System.Windows.Forms.MenuItem()
        Me.MenuItem17 = New System.Windows.Forms.MenuItem()
        Me.MenuItem14 = New System.Windows.Forms.MenuItem()
        Me.MenuItem11 = New System.Windows.Forms.MenuItem()
        Me.MenuItem19 = New System.Windows.Forms.MenuItem()
        Me.MenuItem1 = New System.Windows.Forms.MenuItem()
        Me.MenuItem12 = New System.Windows.Forms.MenuItem()
        Me.MenuItem3 = New System.Windows.Forms.MenuItem()
        Me.MenuItem13 = New System.Windows.Forms.MenuItem()
        Me.MenuItem16 = New System.Windows.Forms.MenuItem()
        Me.MenuItem18 = New System.Windows.Forms.MenuItem()
        Me.MenuItem21 = New System.Windows.Forms.MenuItem()
        Me.MenuItem4 = New System.Windows.Forms.MenuItem()
        Me.MenuItem6 = New System.Windows.Forms.MenuItem()
        Me.MenuItem7 = New System.Windows.Forms.MenuItem()
        Me.MenuItem8 = New System.Windows.Forms.MenuItem()
        Me.MenuItem9 = New System.Windows.Forms.MenuItem()
        Me.MenuItem5 = New System.Windows.Forms.MenuItem()
        Me.MenuItem10 = New System.Windows.Forms.MenuItem()
        Me.staPrincipal = New System.Windows.Forms.StatusBar()
        Me.stapUsuario = New System.Windows.Forms.StatusBarPanel()
        Me.stapNombre = New System.Windows.Forms.StatusBarPanel()
        Me.stapCelula = New System.Windows.Forms.StatusBarPanel()
        Me.stapFecha = New System.Windows.Forms.StatusBarPanel()
        Me.stapServidor = New System.Windows.Forms.StatusBarPanel()
        Me.stapDB = New System.Windows.Forms.StatusBarPanel()
        CType(Me.stapUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stapNombre, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stapCelula, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stapFecha, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stapServidor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.stapDB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'mmPrincipal
        '
        Me.mmPrincipal.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem1, Me.MenuItem3, Me.MenuItem4, Me.MenuItem5})
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem15, Me.MenuItem20, Me.mnuCorteCaja, Me.mnuCorteCajaP, Me.MenuItem17, Me.MenuItem14, Me.MenuItem11, Me.MenuItem19})
        Me.MenuItem2.Text = "&Archivo"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 0
        Me.MenuItem15.Text = "Relacion Cheques"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 1
        Me.MenuItem20.Text = "-"
        '
        'mnuCorteCaja
        '
        Me.mnuCorteCaja.Index = 2
        Me.mnuCorteCaja.Text = "Corte de Caja"
        '
        'mnuCorteCajaP
        '
        Me.mnuCorteCajaP.Index = 3
        Me.mnuCorteCajaP.Text = "Corte de Caja (Prestamos)"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 4
        Me.MenuItem17.Text = "-"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 5
        Me.MenuItem14.Text = "&Comprobante Servicio"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 6
        Me.MenuItem11.Text = "-"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 7
        Me.MenuItem19.Text = "Salir"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem12})
        Me.MenuItem1.Text = "Cata&logos"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 0
        Me.MenuItem12.Text = "&Tipo Ficha"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem13, Me.MenuItem16, Me.MenuItem18, Me.MenuItem21})
        Me.MenuItem3.MergeOrder = 12
        Me.MenuItem3.Text = "&Reportes"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 0
        Me.MenuItem13.Text = "Desgloce de fichas de deposito"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 1
        Me.MenuItem16.Text = "Cheques posfechados"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 2
        Me.MenuItem18.Text = "Cheques posfechados vencidos"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 3
        Me.MenuItem21.Text = "Relación de cheques para depósito en banco"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.MdiList = True
        Me.MenuItem4.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6, Me.MenuItem7, Me.MenuItem8, Me.MenuItem9})
        Me.MenuItem4.MergeOrder = 13
        Me.MenuItem4.Text = "&Ventana"
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "&Cascada"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.Text = "&Mosaico horizontal"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 2
        Me.MenuItem8.Text = "&Mosaico vertical"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = 3
        Me.MenuItem9.Text = "&Organizar"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 4
        Me.MenuItem5.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem10})
        Me.MenuItem5.MergeOrder = 14
        Me.MenuItem5.Text = "&?"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 0
        Me.MenuItem10.Text = "&Acerca de ..."
        '
        'staPrincipal
        '
        Me.staPrincipal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.staPrincipal.Location = New System.Drawing.Point(0, 691)
        Me.staPrincipal.Name = "staPrincipal"
        Me.staPrincipal.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.stapUsuario, Me.stapNombre, Me.stapCelula, Me.stapFecha, Me.stapServidor, Me.stapDB})
        Me.staPrincipal.ShowPanels = True
        Me.staPrincipal.Size = New System.Drawing.Size(1019, 34)
        Me.staPrincipal.TabIndex = 3
        '
        'stapUsuario
        '
        Me.stapUsuario.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.stapUsuario.Icon = CType(resources.GetObject("stapUsuario.Icon"), System.Drawing.Icon)
        Me.stapUsuario.Text = "MHUERTA"
        Me.stapUsuario.ToolTipText = "Usuario del sistema."
        Me.stapUsuario.Width = 102
        '
        'stapNombre
        '
        Me.stapNombre.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stapNombre.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.stapNombre.Text = "Miguel Angel Huerta Velazquez"
        Me.stapNombre.ToolTipText = "Nombre del usuario del sistema."
        Me.stapNombre.Width = 321
        '
        'stapCelula
        '
        Me.stapCelula.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stapCelula.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.stapCelula.Text = "Gerencia general"
        Me.stapCelula.ToolTipText = "Celula a la que corresponde el usuario del sistema."
        Me.stapCelula.Width = 321
        '
        'stapFecha
        '
        Me.stapFecha.Alignment = System.Windows.Forms.HorizontalAlignment.Center
        Me.stapFecha.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.stapFecha.Text = "19/08/2003"
        Me.stapFecha.Width = 72
        '
        'stapServidor
        '
        Me.stapServidor.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.stapServidor.Icon = CType(resources.GetObject("stapServidor.Icon"), System.Drawing.Icon)
        Me.stapServidor.Text = "Dell2600"
        Me.stapServidor.ToolTipText = "Nombre del servidor de base de datos"
        Me.stapServidor.Width = 95
        '
        'stapDB
        '
        Me.stapDB.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Contents
        Me.stapDB.Icon = CType(resources.GetObject("stapDB.Icon"), System.Drawing.Icon)
        Me.stapDB.Text = "Sigamet"
        Me.stapDB.ToolTipText = "Nombre de la Base de datos"
        Me.stapDB.Width = 92
        '
        'Principal
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(1019, 725)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.staPrincipal})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Menu = Me.mmPrincipal
        Me.Name = "Principal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Caja"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.stapUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stapNombre, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stapCelula, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stapFecha, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stapServidor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.stapDB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Principal_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        staPrincipal.Panels(1).Text = dmModulo._Nombre
        staPrincipal.Panels(0).Text = dmModulo._Usuario
        staPrincipal.Panels(2).Text = dmModulo._DesCentroCosto
        staPrincipal.Panels(3).Text = CType(Date.Today, String)
        staPrincipal.Panels(4).Text = dmModulo._Servidor
        staPrincipal.Panels(5).Text = dmModulo._DB
    End Sub
    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Dim frmAbout As New About
        frmAbout.ShowDialog(Me)
        frmAbout.Dispose()
    End Sub
    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub
    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub
    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub
    Private Sub MenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem9.Click
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub
    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        Dim frmRelacionCheques As New RelacionCheques
        MenuItem15.Enabled = False
        frmRelacionCheques.Entrar()
        frmRelacionCheques.Dispose()
        MenuItem15.Enabled = True
    End Sub
    Private Sub MenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Ficha As New MovimientosCajaDesglozados
        Ficha.MdiParent = Me
        Ficha.Show()
    End Sub
    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        Dim TipoFicha As New CatalogoTipoFicha
        TipoFicha.MdiParent = Me
        TipoFicha.Show()
    End Sub
    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCorteCaja.Click
        Dim frmCorteCaja As New CorteCaja
        'frmCorteCaja.MdiParent = Me
        mnuCorteCaja.Enabled = False
        frmCorteCaja.Entrar()
        frmCorteCaja.Dispose()
        mnuCorteCaja.Enabled = True
    End Sub
    Private Sub MenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Click
        Close()
        dmModulo.SqlConnection.Close()
    End Sub
#Region "Menú Reportes"
    Private Sub MenuItem13_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem13.Click
        Dim frmParametrosDesgloceFichas As New ParametrosReportes
        frmParametrosDesgloceFichas.TipoReporte(1)
        frmParametrosDesgloceFichas.Dispose()
    End Sub

    Private Sub MenuItem16_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        Dim frmParametroChequesPosfechado As New ParametrosReportes
        frmParametroChequesPosfechado.TipoReporte(2)
        frmParametroChequesPosfechado.Dispose()
    End Sub

    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        Dim frmParametroChequesPosfechadosVencidos As New ParametrosReportes
        frmParametroChequesPosfechadosVencidos.TipoReporte(3)
        frmParametroChequesPosfechadosVencidos.Dispose()
    End Sub
    Private Sub MenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem21.Click
        Dim frmRelacionChequesDeposito As New ParametrosReportes
        frmRelacionChequesDeposito.TipoReporte(4)
        frmRelacionChequesDeposito.Dispose()
    End Sub
#End Region
    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        Dim Comprobante As New ComprobanteServicio
        Comprobante.MdiParent = Me
        Comprobante.Show()
    End Sub

    '2011-11-22	
    'Autor: Claudia García
    'Motivo: Se agrego un corte de caja para la cobranza de los comisionistas
    Private Sub mnuCorteCajaP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuCorteCajaP.Click
        Dim frmCorteCaja As New CorteCajaAbonoPres()
        'frmCorteCaja.MdiParent = Me
        mnuCorteCaja.Enabled = False
        frmCorteCaja.Entrar()
        frmCorteCaja.Dispose()
        mnuCorteCaja.Enabled = True
    End Sub
End Class
