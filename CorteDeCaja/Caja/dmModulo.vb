Imports System.IO
Imports System.Data.SqlClient
Imports System.Data.OleDb

Module dmModulo
    Public strConnection As String 'Cadena para la conexion del componente.
    Public _Celula As Integer
    Public _Usuario As String
    Public _blnAdministrador As Boolean
    Public _Nombre As String
    Public _DesCentroCosto As String
    Public _Servidor As String
    Public _TipoUsuario As String
    Public _DB As String
    Public _PassWord As String
    Public VGN_Caja As Integer
    Public _DesCaja As String
    Public Conexion As Boolean
    Public _Version As String
    Public SqlConnection As New SqlConnection()
    Public cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand
    Public drLeer As SqlDataReader
    Public VGN_EmpresaContable As Integer
    Public VGS_FOperacion As String
    Public VGN_Consecutivo As Integer
    Public VGN_TipoCorte As Integer = 0
    Private ainfo As New AssemblyInfo()
    Public _NombreEmpresaContable As String
    Public _EmpresaContable As Integer
    Public _Sucursal As Integer
    Public _Corporativo As Integer
    Public _ChequePorFicha As Boolean
    Public _LiquidacionPorFicha As Boolean

    Dim myReader As System.Configuration.AppSettingsReader

    Sub Main()
        Conexion = False

        Dim frmLogin As Login = New Login()
        'Dim _Sucursal As Integer

        frmLogin.ShowDialog()

        If Conexion = True Then
            Try
                SqlConnection.Close()
                SqlConnection.ConnectionString = strConnection
                SqlConnection.Open()
                Conexion = True
            Catch dataException As Exception
                MsgBox("No se ha podido conectar a la base de datos. Verifique con el administrador del sistema." + Chr(13) + _
                            "Detalles : " + Chr(13) + dataException.Message, MsgBoxStyle.Information, "Mensaje de sistema (Main)")
            End Try

            Try
                'Obtenemos las propiedades de la aplicacion
                myReader = New System.Configuration.AppSettingsReader()
                _EmpresaContable = CType(myReader.GetValue("EmpresaContableSigamet", GetType(Integer)), Integer)

                _Sucursal = CType(myReader.GetValue("SucursalVentas", GetType(Integer)), Integer)
                _Corporativo = CType(myReader.GetValue("EmpresaCorporativo", GetType(Integer)), Integer)

                _ChequePorFicha = False
                _LiquidacionPorFicha = False
                If ObtenParametroSistema(3, _Sucursal, _Corporativo, "FichaPorCheque") = "1" Then
                    _ChequePorFicha = True
                End If
                If ObtenParametroSistema(3, _Sucursal, _Corporativo, "FichaPorLiquidacion") = "1" Then
                    _LiquidacionPorFicha = True
                End If

                _NombreEmpresaContable = ObtenParametroSistema(3, _Sucursal, CType(myReader.GetValue("EmpresaCorporativo", GetType(Integer)), Integer), "Empresa")
            Catch ex As Exception
                MsgBox("Verifique que los parametro esten configurados. Corporativo: " + CType(_Corporativo, String) + ", sucursal: " + CType(_Sucursal, String) + Chr(13) + _
                           "Detalles : " + Chr(13) + ex.Message, MsgBoxStyle.Information, "Mensaje de sistema (Main)")
            End Try

            Dim frmPrincipal As Principal = New Principal()
            frmPrincipal.ShowDialog()
        End If

    End Sub

    ' Esta función devuelve la cadena de conexión para la base de datos...
    Public Function CadenaConexion(ByVal UserId As String, ByVal Password As String) As String
        Dim sr As StreamReader = File.OpenText(Application.StartupPath + "\LogIn.ini")
        Dim Line As String = sr.ReadLine
        Dim i As Integer
        i = 0
        While Not (Line Is Nothing)
            strConnection = strConnection + " " + Line
            Line = sr.ReadLine
            i = i + 1
        End While
        sr.Close()
        strConnection = strConnection + "Application Name = Caja 1.2.0.0; User ID = " + UserId + "; Password = " + Password
        _PassWord = Password
        Return (strConnection)
    End Function

    Public Function MontoPendienteTipoFicha(ByVal TipoFicha As Integer, ByVal Consulta As Boolean, ByVal Monto As Decimal, ByVal MontoPendiente As Decimal) As Decimal
        Dim VLM_MontoPendiente As Decimal = -1
        Try
            With cmdCommand
                .CommandType = CommandType.StoredProcedure
                .CommandText = "spSSMontoPendienteTipoFicha"
                .Parameters.Clear()
                .Parameters.Add("@EmpresaContable", SqlDbType.Int).Value = dmModulo._EmpresaContable
                .Parameters.Add("@Caja", SqlDbType.Int).Value = dmModulo.VGN_Caja
                .Parameters.Add("@FOperacion", SqlDbType.Char).Value = VGS_FOperacion
                .Parameters.Add("@Consecutivo", SqlDbType.Int).Value = VGN_Consecutivo
                .Parameters.Add("@TipoFicha", SqlDbType.Int).Value = TipoFicha

                If (Consulta) Then
                    'Obtiene el monto pendiente si es que lo hay de este tipo de ficha
                    .Parameters.Add("@Consulta", SqlDbType.Bit).Value = 1
                    drLeer = .ExecuteReader
                    If drLeer.Read Then
                        VLM_MontoPendiente = CType(drLeer("MontoPendiente"), Decimal)
                    End If
                    drLeer.Close()
                Else
                    'Se registra o actualiza el monto pendiente de este tipo de ficha
                    .Parameters.Add("@MontoAplicar", SqlDbType.Money).Value = Monto
                    .Parameters.Add("@MontoTotal", SqlDbType.Money).Value = MontoPendiente
                    .ExecuteNonQuery()
                End If
            End With

            Return VLM_MontoPendiente
        Catch err As Exception
            MsgBox(err.Message)
        End Try
    End Function

#Region "Funciones generales"

    'Funcion que permite obtener el valor de los parámetros de sistema
    '2007-016-EIM-01	
    'REQ 139
    'Autor: Fernando Correa
    'Se obtiene el Nombre de la empresa
    Public Function ObtenParametroSistema(ByVal Modulo As Integer, ByVal Sucursal As Integer, ByVal Corporativo As Integer, ByVal NombreParametro As String) As String
        Dim drLeer As SqlDataReader = Nothing
        Dim cmdCommand As SqlCommand = dmModulo.SqlConnection.CreateCommand()

        Dim Valorcito As String = String.Empty

        Try
            cmdCommand.CommandType = CommandType.StoredProcedure
            cmdCommand.CommandText = "spSSConsultaParametro"
            cmdCommand.Parameters.Clear()
            cmdCommand.Parameters.Add("@Modulo", SqlDbType.SmallInt).Value = Modulo
            cmdCommand.Parameters.Add("@Sucursal", SqlDbType.TinyInt).Value = Sucursal
            cmdCommand.Parameters.Add("@Corporativo", SqlDbType.TinyInt).Value = Corporativo
            cmdCommand.Parameters.Add("@Parametro", SqlDbType.VarChar).Value = NombreParametro
            drLeer = cmdCommand.ExecuteReader
            drLeer.Read()

            If drLeer.HasRows Then
                Valorcito = drLeer("Valor").ToString()
            End If

        Catch errorObtenParametroSistema As Exception
            MessageBox.Show("No se pudo obtener el parámetro de sistema [" + NombreParametro + "]" + vbCrLf _
                           + errorObtenParametroSistema.ToString(), "Obtencion de parámetros de sistema", MessageBoxButtons.OK, MessageBoxIcon.Stop)
        Finally
            drLeer.Close()
        End Try

        Return Valorcito

    End Function
#End Region
End Module
