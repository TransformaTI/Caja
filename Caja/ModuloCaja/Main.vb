Imports Microsoft.VisualBasic
Imports System.Data.SqlClient

Public Module Main

    Public oSeguridad As SigaMetClasses.cSeguridad

    Public GLOBAL_NombreAplicacion As String = "Caja " & Application.ProductVersion

    Public GLOBAL_IDEmpleado As Integer
    Public GLOBAL_Password As String
    Public GLOBAL_Servidor As String
    Public GLOBAL_Database As String
    Public GLOBAL_EmpleadoNombre As String
    Public GLOBAL_UsuarioNombre As String
    Public GLOBAL_CelulaUsuario As Short
    Public GLOBAL_CelulaDescripcion As String
    Public GLOBAL_IDUsuario As String
    Public GLOBAL_UsuarioNT As String
    Public GLOBAL_SeguridadNT As Boolean
    Public GLOBAL_CajaUsuario As Byte

    Public GLOBAL_TiempoEspera As Integer

    Public GLOBAL_RutaReportes As String
    Public GLOBAL_ReportesAppPath As Boolean
    Public GLOBAL_DiasAjuste As Byte
    Public GLOBAL_ClaveNotaIngreso As Byte
    Public GLOBAL_ReglaHoraLiquidacion As Boolean
    Public GLOBAL_MaxHoraLiquidacion As Date
    Public GLOBAL_VersionAutorizada As String
    Public GLOBAL_MensajeVersion As String

    'ID Usuario administrador
    Public GLOBAL_SysAdmin As String

    Public GLOBAL_Promocion As Boolean

    'Saldos a favor
    Public GLOBAL_SaldoAFavor As Boolean

    'Modificación de movimientos
    Public GLOBAL_TipoMovAutoModif As String

    'Multiempresa portátil
    Public GLOBAL_CorporativoUsuario As Short
    Public GLOBAL_SucursalUsuario As Short

    'Valor parametrizado del vale promocional
    Public GLOBAL_ValorValePromocional As Decimal

    'Nombre de la empresa en la que está corriendo la aplicación
    Public GLOBAL_NombreEmpresa As String

    'Habilita la seguridad de reportes
    Public GLOBAL_SeguridadReportes As Boolean

	Public GLOBAL_URLGATEWAY As String
	Public GLOBAL_CadenaConexion As String

	Public GLOBAL_Modulo As Byte = 3


#Region "Sigamet corporativo"
    'Parámetros para sigamet portátil
    Public GLOBAL_SigametPortatil As Boolean
    Public GLOBAL_FactorDensidad As Decimal
    Public GLOBAL_IVA As Integer
#End Region

    Public SesionIniciada As Boolean = False 'Indica si la sesion ya se inició
    Public PuedeIniciarSesion As Boolean = True 'Indica si el usuario puede iniciar sesión
    Public ConsecutivoInicioDeSesion As Byte 'Indica el número de consecutivo que el inicio de sesión tiene
    Public FechaInicioSesion As Date
    'Public FechaOperacion As Date = SigaMetClasses.FechaServidor.Date  'Indica la fecha de operación actual en formato (dd/MM/yyyy)
    Public FechaOperacion As Date 'Indica la fecha de operación actual en formato (dd/MM/yyyy)
    Public AmarraClienteCapturaCobranza As Boolean = True 'Indica si solo se pueden capturar documentos relacionados con el cliente especificado en frmCapturaCobranzaDoc
    Public ClienteCapturaCobranza As Integer = 0 'El cliente al que se le captura la cobranza por eficiencia negativa

    'Mensajes
    Public M_ESTAN_CORRECTOS As String = SigaMetClasses.M_ESTAN_CORRECTOS
    Public M_DATOS_OK As String = SigaMetClasses.M_DATOS_OK
    Public M_DESEA_CONTINUAR As String = SigaMetClasses.M_DESEA_CONTINUAR

	Public ConString As String



	Public GLOBAL_Connection As SqlConnection

    Public CapturaMixtaEfectivoVales As Boolean = False 'Indica si el cobro que se está capturando es mixto.
    '(Efectivo y vales en el mismo cobro).  Se usa en la captura de cobranza.
    Public CapturaEfectivoVales As Boolean = False 'Indica si ya se capturo un cobro con efectivo o con vales.
    'Se usa en la captura de cobranza.
    Public Event IniciandoSesion()

    Public Function SumaColumna(ByVal NombreTabla As DataTable, ByVal NombreColumna As String) As Decimal
        Dim _row As DataRow, decTotalSuma As Decimal = 0
        For Each _row In NombreTabla.Rows
            decTotalSuma += CType(_row(NombreColumna), Decimal)
        Next
        Return decTotalSuma
    End Function

    Public Function SumaColumna(ByVal FormaPago As Integer, ByVal NombreTabla As DataTable, ByVal NombreColumna As String) As Decimal
        Dim _row As DataRow, decTotalSuma As Decimal = 0
        For Each _row In NombreTabla.Rows
            'ITL DEFECTO 4AGOSTO
            If (CType(_row("TipoCobro"), Integer) = FormaPago) Then
                decTotalSuma += CType(_row(NombreColumna), Decimal)
            End If
        Next
        Return decTotalSuma
    End Function

    Public Sub Main()
        Dim frmAcceso As New SigametSeguridad.UI.Acceso(Application.StartupPath & "\Default.Seguridad y Administracion.exe.config", True, 3,
            New Bitmap(Application.StartupPath & "\ModuloCaja.ico"))

        If frmAcceso.ShowDialog = DialogResult.OK Then

            Dim oLogin As New SigaMetClasses.Seguridad(3, frmAcceso.CadenaConexion, frmAcceso.Usuario.IdUsuario,
                frmAcceso.Usuario.ClaveDesencriptada)

			'Liquidación portátil
			PortatilClasses.Globals.GetInstance.ConfiguraModulo(frmAcceso.Usuario.IdUsuario, frmAcceso.Usuario.ClaveDesencriptada,
			frmAcceso.CadenaConexion, frmAcceso.Usuario.Corporativo,
			frmAcceso.Usuario.Sucursal)

			LiquidacionPortatil.Globals.GetInstance.ConfiguraModulo(frmAcceso.Usuario.IdUsuario, frmAcceso.Usuario.ClaveDesencriptada,
			frmAcceso.CadenaConexion, frmAcceso.Usuario.Corporativo, frmAcceso.Usuario.Sucursal, 3)

			FormasPago.Globals.GetInstance.ConfiguraModulo(frmAcceso.Usuario.IdUsuario, frmAcceso.Usuario.ClaveDesencriptada,
			frmAcceso.CadenaConexion, frmAcceso.Usuario.Corporativo, frmAcceso.Usuario.Sucursal, 3)

			GLOBAL_Connection = SigaMetClasses.DataLayer.Conexion

            FechaOperacion = SigaMetClasses.FechaServidor.Date


            GLOBAL_Database = oLogin.BaseDatos
            GLOBAL_Servidor = oLogin.Servidor
            GLOBAL_IDUsuario = oLogin.UserID
            GLOBAL_Password = oLogin.Password


            GLOBAL_CorporativoUsuario = oLogin.Corporativo
            GLOBAL_SucursalUsuario = oLogin.Sucursal

            oSeguridad = New SigaMetClasses.cSeguridad(GLOBAL_IDUsuario, 3)

            If Not oSeguridad.TieneAcceso("ACCESO") Then
                MessageBox.Show("Usted no tiene acceso.", GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If



            'IMPLEMENTACIÓN DEL UpDATER (ACTUALIZACION AUTOMÁTICA) 14/09/2004
            'Dim tmpConn As New SqlConnection(oLogin.CadenaConexion)
            Dim updateSys As New SIGAMETSecurity.Updater(3, Application.ProductVersion, Application.StartupPath, frmAcceso.CadenaConexion)
            If updateSys.Desactualizado = True Then
                'Necesita actualizarse
                Application.Exit()
            End If
            'tmpConn.Dispose()

            'Variables globales del módulo

            GLOBAL_UsuarioNT = oLogin.UsuarioNT
            GLOBAL_IDEmpleado = oLogin.Empleado
            GLOBAL_EmpleadoNombre = oLogin.EmpleadoNombre
            GLOBAL_UsuarioNombre = oLogin.UsuarioNombre
            GLOBAL_CelulaUsuario = oLogin.Celula
            GLOBAL_CelulaDescripcion = oLogin.CelulaDescripcion
            GLOBAL_CajaUsuario = oLogin.Caja
            GLOBAL_SeguridadNT = oLogin.SeguridadNT
            ConString = oLogin.CadenaConexion

            'Parámetros del módulo
            GLOBAL_DiasAjuste = CType(oLogin.Parametros("DiasAjuste"), Byte)
            GLOBAL_ClaveNotaIngreso = CType(oLogin.Parametros("ClaveNotaIngreso"), Byte)
            GLOBAL_MaxHoraLiquidacion = CType(FechaOperacion.ToShortDateString & " " & CType(oLogin.Parametros("MaxHoraLiquidacion"), String), Date)
            GLOBAL_ReglaHoraLiquidacion = CType(oLogin.Parametros("ReglaHoraLiquidacion"), Boolean)

            'GLOBAL_RutaReportes = CType(oLogin.Parametros("RutaReportes"), String)
            GLOBAL_RutaReportes = CType(SigametSeguridad.Seguridad.Parametros(3,
                CType(GLOBAL_CorporativoUsuario, Byte), CType(GLOBAL_SucursalUsuario, Byte)).ValorParametro("RutaReportesW7"), String)

            GLOBAL_VersionAutorizada = CType(oLogin.Parametros("VersionAutorizada"), String)
            GLOBAL_MensajeVersion = CType(oLogin.Parametros("MensajeVersion"), String)

            'SE UTILIZA EL UPDATER PARA MANTENER ACTUALIZADAS LAS VERSIONES, YA NO SE NECESITA ESTO FAZ 13-11-2006 JAGD
            'If GLOBAL_VersionAutorizada <> Application.ProductVersion.ToString Then
            '    MessageBox.Show(GLOBAL_MensajeVersion, "Módulo de Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            GLOBAL_TiempoEspera = CType(oLogin.Parametros("TiempoEspera"), Integer)

            'Sigamet corporativo
            GLOBAL_SysAdmin = CType(oLogin.Parametros("SysAdmin"), String)
            GLOBAL_SigametPortatil = CType(oLogin.Parametros("AplicaSigametPortatil"), Boolean)

            If GLOBAL_SigametPortatil Then
                GLOBAL_FactorDensidad = CType(oLogin.Parametros("FactorDensidad"), Decimal)
                GLOBAL_IVA = CType(oLogin.Parametros("IVA"), Integer)
            End If

            'Promoción temporal
            GLOBAL_Promocion = CType(oLogin.Parametros("PromocionAvispa"), Boolean)

            'Saldos a favor
            GLOBAL_SaldoAFavor = CType(oLogin.Parametros("CAPTURASALDOAFAVOR"), Boolean)

            GLOBAL_TipoMovAutoModif = CType(oLogin.Parametros("MovAutoModificacion"), String)


            GLOBAL_ValorValePromocional = CType(oLogin.Parametros("ValorValePromocional"), Decimal)

            'Nombre de la empresa en la que está corriendo la aplicación
            Dim _datosEmpresa As New NombreEmpresa.DatosEmpresa()
            GLOBAL_NombreEmpresa = _datosEmpresa.NombreEmpresa

            'TODO: Valor de la seguridad de reportes
            GLOBAL_SeguridadReportes = CType(oLogin.Parametros("SeguridadReportes"), Boolean)
            GLOBAL_URLGATEWAY = CType(oLogin.Parametros("URLGateway"), String)

            'Aquí iría la seguridad de Manuel

            'Explicitly set apartment state to Single Thread Apartment (STA)
            'System.Threading.Thread.CurrentThread.ApartmentState = System.Threading.ApartmentState.STA
            Dim eh As New CustomExceptionHandler()
            AddHandler Application.ThreadException, AddressOf eh.OnThreadException
            Application.Run(New frmPrincipal())

        End If
    End Sub

    Friend Class CustomExceptionHandler
        ' The Error Handler class
        ' We need a class because event handling methods can't be static
        ' Handle the exception event
        Public Sub OnThreadException(ByVal Sender As Object, ByVal t As System.Threading.ThreadExceptionEventArgs)

            Dim result As DialogResult = DialogResult.Cancel
            Try
                result = Me.ShowThreadExceptionDialog(t.Exception)
            Catch
                Try
                    MessageBox.Show("Error Fatal", "Error Fatal", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop)
                Finally
                    Application.Exit()
                End Try
            End Try

            If (result = DialogResult.Abort) Then
                Application.Exit()
            End If
        End Sub


        ' The simple dialog that is displayed when this class catches and exception
        Private Function ShowThreadExceptionDialog(ByVal e As Exception) As DialogResult
            Dim errorMsg As String = "Ha ocurrido un error.  Por favor contacte al administrador del " &
                                     "sistema con la siguiente información:" & vbCrLf & vbCrLf
            errorMsg &= e.Message & vbCrLf & vbCrLf & "Stack Trace:" &
                        vbCrLf & e.StackTrace
            Return MessageBox.Show(errorMsg,
                                    "Error en la aplicación",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Stop)
        End Function
    End Class

    Public Sub IniciarSesion(ByRef InicioDeSesion As DateTime)
        If SesionIniciada Then
            MessageBox.Show("La sesión ya fue iniciada.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        If Not PuedeIniciarSesion Then
            MessageBox.Show("No puede iniciar sesión.", "Inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
            Exit Sub
        End If

        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            InicioDeSesion = Now
            ConsecutivoInicioDeSesion = CType(oCorte.Alta(GLOBAL_CajaUsuario, CType(Today.ToShortDateString, Date), GLOBAL_IDUsuario, InicioDeSesion), Byte)
            SesionIniciada = True
        Catch ex As Exception
            SesionIniciada = False
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub

    Public Function ExisteCorteCaja(ByVal Caja As Byte,
                                    ByVal FOperacion As Date) As Boolean
        Dim cmd As New SqlCommand("Select Count(*) From CorteCajaAplicacion WHERE Caja = " & Caja & " AND FOperacion = '" & FOperacion & "'")
        'Dim cn As New SqlConnection(ConString)
        Dim cn As SqlConnection = GLOBAL_Connection
        Dim intRegistros As Integer
        Try
            cmd.Connection = cn
            If cn.State = ConnectionState.Closed Then
                cn.Open()
            End If
            intRegistros = CType(cmd.ExecuteScalar, Integer)
        Catch ex As Exception
            MessageBox.Show(ex.Message, ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If cn.State = ConnectionState.Open Then
                cn.Close()
            End If
            'cn.Dispose()
            cmd.Dispose()
        End Try
        If intRegistros > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Sub TerminarSesion()
        If Not SesionIniciada Then
            MessageBox.Show("La sesión no ha sido iniciada.", "Termino de sesión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        Dim oCorte As New SigaMetClasses.CorteCaja()
        Try
            oCorte.TerminaSesion(GLOBAL_CajaUsuario, CType(Today.ToShortDateString, Date), ConsecutivoInicioDeSesion, Now, GLOBAL_IDUsuario)
            SesionIniciada = False
        Catch ex As Exception
            SesionIniciada = True
            MessageBox.Show(ex.Message)
        Finally
            oCorte = Nothing
        End Try
    End Sub

    Public Function FechaCrystal(ByVal Fecha As Date) As String
        Dim strFecha As String
        strFecha = "#" & Month(Fecha) & "/" & Day(Fecha) & "/" & Year(Fecha) & "#"
        Return strFecha
    End Function

End Module

Public Class MiDataTable
    Inherits DataTable

    Private _TotalMovimientoCaja As Decimal

    Public Property TotalMovimientoCaja() As Decimal
        Get
            Return _TotalMovimientoCaja
        End Get
        Set(ByVal Value As Decimal)
            _TotalMovimientoCaja = Value
        End Set
    End Property

    Public ReadOnly Property TotalRegistros() As Integer
        Get
            Return Me.Rows.Count
        End Get
    End Property

    Public ReadOnly Property ImporteTotalCobros() As Decimal
        Get
            Dim x As DataRow, decImporteTotalCobros As Decimal = 0
            For Each x In Me.Rows
                decImporteTotalCobros += CType(x("CobroPedidoTotal"), Decimal)
            Next
            Return decImporteTotalCobros
        End Get
    End Property

    Public ReadOnly Property ImporteTotalEfectivo() As Decimal
        Get
            Dim x As DataRow, decImporteTotalEfectivo As Decimal = 0
            For Each x In Me.Rows
                If CType(x("TipoCobro"), Byte) = 1 Then
                    decImporteTotalEfectivo += CType(x("CobroPedidoTotal"), Decimal)
                End If
            Next
            Return decImporteTotalEfectivo
        End Get
    End Property

    Public ReadOnly Property ImporteTotalVales() As Decimal
        Get
            Dim x As DataRow, decImporteTotalVales As Decimal = 0
            For Each x In Me.Rows
                If CType(x("TipoCobro"), Byte) = 2 Then
                    decImporteTotalVales += CType(x("CobroPedidoTotal"), Decimal)
                End If
            Next
            Return decImporteTotalVales
        End Get
    End Property

    Public ReadOnly Property ImporteTotalCheques() As Decimal
        Get
            Dim x As DataRow, decImporteTotalCheques As Decimal = 0
            For Each x In Me.Rows
                If CType(x("TipoCobro"), Byte) = 3 Then
                    decImporteTotalCheques += CType(x("CobroPedidoTotal"), Decimal)
                End If
            Next
            Return decImporteTotalCheques
        End Get
    End Property

    Public ReadOnly Property ImporteTotalEfectivoVales() As Decimal
        Get
            Dim x As DataRow, decImporteTotalEfectivoVales As Decimal = 0
            For Each x In Me.Rows
                If CType(x("TipoCobro"), Byte) = 5 Then
                    decImporteTotalEfectivoVales += CType(x("CobroPedidoTotal"), Decimal)
                End If
            Next
            Return decImporteTotalEfectivoVales
        End Get
    End Property

    Public ReadOnly Property ImporteTotalEfectivoValesNI() As Decimal
        Get
            Dim x As DataRow, decImporteTotalEfectivoValesNI As Decimal = 0
            For Each x In Me.Rows
                If CType(x("TipoCobro"), Byte) = 5 Then
                    decImporteTotalEfectivoValesNI += CType(x("CobroTotal"), Decimal)
                End If
            Next
            Return decImporteTotalEfectivoValesNI
        End Get
    End Property

End Class

Public Class MiDataTableCambio
    Inherits DataTable
    Private _ImporteTotalCambio As Decimal
    Public ReadOnly Property ImporteTotalCambio() As Decimal
        Get
            Dim dr As DataRow
            For Each dr In Me.Rows
                _ImporteTotalCambio += CType(dr("Total"), Decimal)
            Next
            Return _ImporteTotalCambio
        End Get
    End Property
End Class


Public Enum TipoOperacionMovimientoCaja
    Validacion = 1
    Consulta = 2
    Liquidacion = 3
End Enum

#Region "Waste"
'Public Sub Main()
'    Dim oLogin As New SigaMetClasses.Seguridad(3, Application.ProductVersion, "LavenderBlush")
'    If oLogin.ShowDialog = DialogResult.OK Then

'        GLOBAL_Database = oLogin.BaseDatos
'        GLOBAL_Servidor = oLogin.Servidor
'        GLOBAL_IDUsuario = oLogin.UserID
'        GLOBAL_Password = oLogin.Password

'        oSeguridad = New SigaMetClasses.cSeguridad(GLOBAL_IDUsuario, 3)

'        If Not oSeguridad.TieneAcceso("ACCESO") Then
'            MessageBox.Show("Usted no tiene acceso.", GLOBAL_NombreAplicacion, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
'            Exit Sub
'        End If

'        'IMPLEMENTACIÓN DEL UpDATER (ACTUALIZACION AUTOMÁTICA) 14/09/2004
'        Dim tmpConn As New SqlConnection(oLogin.CadenaConexion)
'        Dim updateSys As New SIGAMETSecurity.Updater(3, Application.ProductVersion, Application.StartupPath, tmpConn)
'        If updateSys.Desactualizado = True Then
'            'Necesita actualizarse
'            Application.Exit()
'            Exit Sub
'        End If
'        tmpConn.Dispose()

'        'Variables globales del módulo

'        GLOBAL_UsuarioNT = oLogin.UsuarioNT
'        GLOBAL_IDEmpleado = oLogin.Empleado
'        GLOBAL_EmpleadoNombre = oLogin.EmpleadoNombre
'        GLOBAL_UsuarioNombre = oLogin.UsuarioNombre
'        GLOBAL_CelulaUsuario = oLogin.Celula
'        GLOBAL_CelulaDescripcion = oLogin.CelulaDescripcion
'        GLOBAL_CajaUsuario = oLogin.Caja
'        GLOBAL_SeguridadNT = oLogin.SeguridadNT
'        ConString = oLogin.CadenaConexion

'        'Parámetros del módulo
'        GLOBAL_DiasAjuste = CType(oLogin.Parametros("DiasAjuste"), Byte)
'        GLOBAL_ClaveNotaIngreso = CType(oLogin.Parametros("ClaveNotaIngreso"), Byte)
'        GLOBAL_MaxHoraLiquidacion = CType(FechaOperacion.ToShortDateString & " " & CType(oLogin.Parametros("MaxHoraLiquidacion"), String), Date)
'        GLOBAL_ReglaHoraLiquidacion = CType(oLogin.Parametros("ReglaHoraLiquidacion"), Boolean)

'        GLOBAL_RutaReportes = CType(oLogin.Parametros("RutaReportes"), String)
'        GLOBAL_VersionAutorizada = CType(oLogin.Parametros("VersionAutorizada"), String)
'        GLOBAL_MensajeVersion = CType(oLogin.Parametros("MensajeVersion"), String)

'        If GLOBAL_VersionAutorizada <> Application.ProductVersion.ToString Then
'            MessageBox.Show(GLOBAL_MensajeVersion, "Módulo de Caja", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
'            Exit Sub
'        End If

'        GLOBAL_TiempoEspera = CType(oLogin.Parametros("TiempoEspera"), Integer)

'        'Sigamet corporativo
'        GLOBAL_SysAdmin = CType(oLogin.Parametros("SysAdmin"), String)
'        GLOBAL_SigametPortatil = CType(oLogin.Parametros("AplicaSigametPortatil"), Boolean)

'        If GLOBAL_SigametPortatil Then
'            GLOBAL_FactorDensidad = CType(oLogin.Parametros("FactorDensidad"), Decimal)
'            GLOBAL_IVA = CType(oLogin.Parametros("IVA"), Integer)
'        End If

'        'Promoción temporal
'        GLOBAL_Promocion = CType(oLogin.Parametros("PromocionAvispa"), Boolean)

'        'Saldos a favor
'        GLOBAL_SaldoAFavor = CType(oLogin.Parametros("CAPTURASALDOAFAVOR"), Boolean)

'        'Aquí iría la seguridad de Manuel

'        'Explicitly set apartment state to Single Thread Apartment (STA)
'        System.Threading.Thread.CurrentThread.ApartmentState = System.Threading.ApartmentState.STA
'        Dim eh As New CustomExceptionHandler()
'        AddHandler Application.ThreadException, AddressOf eh.OnThreadException
'        Application.Run(New frmPrincipal())

'    End If
'End Sub
#End Region