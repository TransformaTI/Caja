

Public Class frmMovimientos
    Inherits SigaMetClasses.ConsultaMovimientos

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New(3, Main.GLOBAL_IDUsuario, Main.GLOBAL_IDEmpleado)

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
        components = New System.ComponentModel.Container()
    End Sub

#End Region

    Private Sub frmConsultaMovimientos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CargaDatos()
    End Sub

    Public Overrides Sub Imprimir(ByVal Caja As Byte, ByVal FOperacion As Date, ByVal Folio As Integer, ByVal Consecutivo As Integer)
        Cursor = Cursors.WaitCursor
        Dim frmConRep As New frmConsultaReporte(frmConsultaReporte.enumTipoReporte.RepMovimientoCajaDetalle, 0, Now, FOperacion, Caja, Folio, Consecutivo)
        frmConRep.ShowDialog()
        Cursor = Cursors.Default
    End Sub

    Public Overrides Sub Capturar()
        Cursor = Cursors.WaitCursor
        Dim frmCaptura As New frmCapCobranza(frmCapCobranza.enumTipoCaptura.NotaIngreso)
        frmCaptura.ShowDialog()
        Cursor = Cursors.Default
    End Sub

End Class
