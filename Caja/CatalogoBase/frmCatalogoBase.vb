Option Strict On
Option Explicit On 
Public Class frmCatalogo
    Inherits System.Windows.Forms.Form
    Public Enum enumTipoAccion
        Agregar = 1
        Eliminar = 2
        Modificar = 3
        Consultar = 4
        Buscar = 5
        Imprimir = 6
        Refrescar = 7
        Cerrar = 8
    End Enum
    Public grdTableStyle1 As New DataGridTableStyle()
    Private _ID As String
    Private _IndiceID As Integer
    Private _ConString As String = "Data Source=DESARROLLO;Initial Catalog=SIGAMET;User ID=sa;Password=development"
    Private _Query As String
    Private _ListaDatos As New ArrayList()
    Private _TipoAccion As enumTipoAccion
    Private _NombreTabla As String


#Region "Propiedades"
    Public ReadOnly Property ID() As String
        Get
            Return _ID
        End Get
    End Property
    Public Property ConString() As String
        Get
            Return _ConString
        End Get
        Set(ByVal Value As String)
            _ConString = Value
        End Set
    End Property
    Public Property Query() As String
        Get
            Return _Query
        End Get
        Set(ByVal Value As String)
            _Query = Value
        End Set
    End Property
    Public Property ListaDatos() As ArrayList
        Get
            Return _ListaDatos
        End Get
        Set(ByVal Value As ArrayList)
            _ListaDatos = Value
        End Set
    End Property
    Public Property IndiceID() As Integer
        Get
            Return _IndiceID
        End Get
        Set(ByVal Value As Integer)
            _IndiceID = Value
        End Set
    End Property
    Public Property TipoAccion() As enumTipoAccion
        Get
            Return _TipoAccion
        End Get
        Set(ByVal Value As enumTipoAccion)
            _TipoAccion = Value
        End Set
    End Property
    Public Property NombreTabla() As String
        Get
            Return _NombreTabla
        End Get
        Set(ByVal Value As String)
            _NombreTabla = Value
        End Set
    End Property
#End Region

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()
        InitializeComponent()
        _ID = ""
        _IndiceID = -1
        _TipoAccion = 0
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
    Protected WithEvents tbrBarra As ControlesBase.ToolBarBase
    Friend WithEvents Splitter As System.Windows.Forms.Splitter
    Protected WithEvents tabDatos As System.Windows.Forms.TabControl
    Public WithEvents tbDatos As System.Windows.Forms.TabPage
    Protected WithEvents grdDatos As System.Windows.Forms.DataGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.tbrBarra = New ControlesBase.ToolBarBase()
        Me.grdDatos = New System.Windows.Forms.DataGrid()
        Me.Splitter = New System.Windows.Forms.Splitter()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.tbDatos = New System.Windows.Forms.TabPage()
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbrBarra
        '
        Me.tbrBarra.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
        Me.tbrBarra.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.tbrBarra.DropDownArrows = True
        Me.tbrBarra.Name = "tbrBarra"
        Me.tbrBarra.ShowToolTips = True
        Me.tbrBarra.Size = New System.Drawing.Size(568, 40)
        Me.tbrBarra.TabIndex = 0
        Me.tbrBarra.Wrappable = False
        '
        'grdDatos
        '
        Me.grdDatos.AlternatingBackColor = System.Drawing.Color.GhostWhite
        Me.grdDatos.BackColor = System.Drawing.Color.GhostWhite
        Me.grdDatos.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.grdDatos.CaptionBackColor = System.Drawing.Color.RoyalBlue
        Me.grdDatos.CaptionForeColor = System.Drawing.Color.White
        Me.grdDatos.DataMember = ""
        Me.grdDatos.Dock = System.Windows.Forms.DockStyle.Top
        Me.grdDatos.FlatMode = True
        Me.grdDatos.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.grdDatos.ForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDatos.HeaderBackColor = System.Drawing.Color.MidnightBlue
        Me.grdDatos.HeaderFont = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.grdDatos.HeaderForeColor = System.Drawing.SystemColors.AppWorkspace
        Me.grdDatos.LinkColor = System.Drawing.Color.Teal
        Me.grdDatos.Location = New System.Drawing.Point(0, 40)
        Me.grdDatos.Name = "grdDatos"
        Me.grdDatos.ParentRowsBackColor = System.Drawing.SystemColors.AppWorkspace
        Me.grdDatos.ParentRowsForeColor = System.Drawing.Color.MidnightBlue
        Me.grdDatos.ReadOnly = True
        Me.grdDatos.SelectionBackColor = System.Drawing.Color.Teal
        Me.grdDatos.SelectionForeColor = System.Drawing.Color.PaleGreen
        Me.grdDatos.Size = New System.Drawing.Size(568, 168)
        Me.grdDatos.TabIndex = 1
        '
        'Splitter
        '
        Me.Splitter.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter.Location = New System.Drawing.Point(0, 208)
        Me.Splitter.Name = "Splitter"
        Me.Splitter.Size = New System.Drawing.Size(568, 2)
        Me.Splitter.TabIndex = 4
        Me.Splitter.TabStop = False
        '
        'tabDatos
        '
        Me.tabDatos.Controls.AddRange(New System.Windows.Forms.Control() {Me.tbDatos})
        Me.tabDatos.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tabDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.Location = New System.Drawing.Point(0, 210)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(568, 187)
        Me.tabDatos.TabIndex = 5
        '
        'tbDatos
        '
        Me.tbDatos.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbDatos.Location = New System.Drawing.Point(4, 22)
        Me.tbDatos.Name = "tbDatos"
        Me.tbDatos.Size = New System.Drawing.Size(560, 161)
        Me.tbDatos.TabIndex = 0
        Me.tbDatos.Text = "Datos"
        '
        'frmCatalogo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 14)
        Me.ClientSize = New System.Drawing.Size(568, 397)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.tabDatos, Me.Splitter, Me.grdDatos, Me.tbrBarra})
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "frmCatalogo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Catálogo base"
        CType(Me.grdDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Overridable Sub tbrBarra_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles tbrBarra.ButtonClick
        Select Case e.Button.Tag.ToString()
            Case Is = "Agregar"
                _TipoAccion = enumTipoAccion.Agregar
            Case Is = "Eliminar"
                _TipoAccion = enumTipoAccion.Eliminar
            Case Is = "Modificar"
                _TipoAccion = enumTipoAccion.Modificar
            Case Is = "Consultar"
                _TipoAccion = enumTipoAccion.Consultar
            Case Is = "Buscar"
                _TipoAccion = enumTipoAccion.Buscar
            Case Is = "Imprimir"
                _TipoAccion = enumTipoAccion.Imprimir
            Case Is = "Refrescar"
                _TipoAccion = enumTipoAccion.Refrescar
            Case Is = "Cerrar"
                _TipoAccion = enumTipoAccion.Cerrar
                Me.Close()
        End Select
    End Sub

    Public Overridable Sub grdDatos_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDatos.CurrentCellChanged
        _ID = CType(grdDatos.Item(grdDatos.CurrentRowIndex, 0), String)
    End Sub

    Protected Sub AplicaFormato(ByVal Titulo As String)
        With grdDatos
            .BackgroundColor = SystemColors.AppWorkspace
            .CaptionText = ""
            .CaptionBackColor = SystemColors.ActiveCaption
            .TableStyles.Clear()
            .ResetAlternatingBackColor()
            .ResetBackColor()
            .ResetForeColor()
            .ResetGridLineColor()
            .ResetHeaderBackColor()
            .ResetHeaderFont()
            .ResetHeaderForeColor()
            .ResetSelectionBackColor()
            .ResetSelectionForeColor()
            .ResetText()
            .BorderStyle = BorderStyle.Fixed3D
        End With
        With grdDatos
            .BackColor = Color.GhostWhite
            .BackgroundColor = SystemColors.AppWorkspace
            .BorderStyle = BorderStyle.None
            .CaptionBackColor = Color.RoyalBlue
            .CaptionFont = New Font("Tahoma", 10.0!, FontStyle.Bold)
            .CaptionForeColor = Color.Bisque
            .CaptionText = Titulo
            .Font = New Font("Tahoma", 8.0!)
            .ParentRowsBackColor = Color.Lavender
            .ParentRowsForeColor = Color.MidnightBlue
        End With

        With grdTableStyle1
            .GridColumnStyles.Clear()
            .AlternatingBackColor = Color.GhostWhite
            .BackColor = Color.GhostWhite
            .ForeColor = Color.MidnightBlue
            .GridLineColor = SystemColors.Control
            .HeaderBackColor = Color.MidnightBlue
            .HeaderFont = New Font("Tahoma", 8.0!, FontStyle.Bold)
            .HeaderForeColor = SystemColors.AppWorkspace
            .SelectionBackColor = Color.Teal
            .SelectionForeColor = Color.PaleGreen
            .MappingName = _NombreTabla
            .PreferredColumnWidth = 125
            .PreferredRowHeight = 15
        End With
    End Sub
End Class