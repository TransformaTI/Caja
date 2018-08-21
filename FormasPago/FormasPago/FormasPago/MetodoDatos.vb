Imports System.Collections.Generic
Imports System.Data.SqlClient

Public Class MetodoDatos
    Public Function ConsultaCelulasPorUsusario() As List(Of Celula)
        Dim listaCelulas As New List(Of Celula)
        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If

            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spConsultaCelulasPorUsuario"
            cmd.Connection = GLOBAL_Connection
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar).Value = GLOBAL_IDUsuario
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While (reader.Read)
                Dim celula As New Celula(Convert.ToInt32(reader(0).ToString()), reader(1).ToString())
                listaCelulas.Add(celula)
            End While


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

        Return listaCelulas
    End Function

    Public Function ConsultaTodasLasCelulas() As List(Of Celula)
        Dim listaCelulas As New List(Of Celula)
        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spConsultaTodasLasCelulas"
            cmd.Connection = GLOBAL_Connection
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While (reader.Read)
                Dim celula As New Celula(Convert.ToInt32(reader(0).ToString()), reader(1).ToString())
                listaCelulas.Add(celula)
            End While


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

        Return listaCelulas
    End Function

    Public Function ValidarParametroCelulasUsuario() As Boolean
        Dim res As Boolean = True
        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spConsultaParametroCelulasUsuario"
            cmd.Connection = GLOBAL_Connection
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While (reader.Read)
                res = CBool(IIf(reader(0).ToString() = "1", True, False))
            End While

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

        Return res
    End Function


    Public Function CargaTipoConcepto() As List(Of TipoConcepto)

        Dim listaTipoConcepto As New List(Of TipoConcepto)
        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spConsultaTipoConcepto"
            cmd.Connection = GLOBAL_Connection
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While (reader.Read)
                'Dim celula As New Celula(Convert.ToInt32(reader(0).ToString()), reader(1).ToString())
                Dim tipoConcepto As New TipoConcepto()

                tipoConcepto.TipoConcepto = Convert.ToInt32(reader(0).ToString())
                tipoConcepto.Descripcion = reader(1).ToString()
                tipoConcepto.Tipomovimientocaja = Convert.ToInt32(reader(2).ToString())
                tipoConcepto.Cuentacontable = reader(3).ToString()
                tipoConcepto.Status = reader(4).ToString()
                tipoConcepto.Usuarioalta = reader(5).ToString()
                tipoConcepto.Falta = reader(6).ToString()

                listaTipoConcepto.Add(tipoConcepto)
            End While


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

        Return listaTipoConcepto
    End Function


    Public Overloads Function ConsultaTipoConcepto() As DataTable
        Dim cmd As New SqlCommand()
        Dim ds As New DataSet()

        Try

            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spConsultaTipoConcepto"
            cmd.Connection = GLOBAL_Connection
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(ds, "TipoConcepto")
        Catch ex As Exception
            Throw ex
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

        If ds.Tables("TipoConcepto").Rows.Count > 0 Then
            Return ds.Tables("TipoConcepto")
        Else
            Return Nothing
        End If

    End Function

    Public Function CargaTipoConcepto(ByVal IdTipoConcepto As Integer) As TipoConcepto

        Dim tipoConcepto As New TipoConcepto()
        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spConsultaTipoConceptoPorId"
            cmd.Connection = GLOBAL_Connection
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@TipoConcepto", SqlDbType.Int)).Value = IdTipoConcepto
            End With
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While (reader.Read)

                tipoConcepto.TipoConcepto = Convert.ToInt32(reader(0).ToString())
                tipoConcepto.Descripcion = reader(1).ToString()
                tipoConcepto.Tipomovimientocaja = Convert.ToInt32(reader(2).ToString())
                tipoConcepto.Cuentacontable = reader(3).ToString()
                tipoConcepto.Status = reader(4).ToString()
                tipoConcepto.Usuarioalta = reader(5).ToString()
                tipoConcepto.Falta = reader(6).ToString()


            End While


        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

        Return tipoConcepto
    End Function

    Public Function GuardaTipoConcepto(
                                       ByVal Descripcion As String,
                                       ByVal TipoMovimientoCaja As Integer,
                                       ByVal CuentaContable As String,
                                       ByVal Estatus As String,
                                       ByVal UsuarioAlta As String,
                                       ByVal Falta As DateTime) As Boolean
        Dim result As Boolean = False
        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spAltaTipoConcepto"
            cmd.Connection = GLOBAL_Connection
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar, 100)).Value = Descripcion
                .Parameters.Add(New SqlParameter("@TipoMovimientoCaja", SqlDbType.TinyInt)).Value = TipoMovimientoCaja
                .Parameters.Add(New SqlParameter("@CuentaContable", SqlDbType.VarChar, 30)).Value = CuentaContable
                .Parameters.Add(New SqlParameter("@Estatus", SqlDbType.VarChar, 30)).Value = Estatus
                .Parameters.Add(New SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 10)).Value = UsuarioAlta
                .Parameters.Add(New SqlParameter("@Falta", SqlDbType.DateTime)).Value = Falta

            End With
            cmd.ExecuteNonQuery()
            result = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try
        Return result
    End Function

    Public Function ModificaTipoConcepto(ByVal IdTipoConcepto As Integer,
                                       ByVal Descripcion As String,
                                       ByVal TipoMovimientoCaja As Integer,
                                       ByVal CuentaContable As String,
                                         ByVal Estatus As String) As Boolean


        Dim result As Boolean = False
        Dim cmd As New SqlCommand()
        Try
            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spModificaTipoConcepto"
            cmd.Connection = GLOBAL_Connection
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@IdTipoConcepto", SqlDbType.Int)).Value = IdTipoConcepto
                .Parameters.Add(New SqlParameter("@Descripcion", SqlDbType.VarChar, 100)).Value = Descripcion
                .Parameters.Add(New SqlParameter("@TipoMovimientoCaja", SqlDbType.TinyInt)).Value = TipoMovimientoCaja
                .Parameters.Add(New SqlParameter("@CuentaContable", SqlDbType.VarChar, 30)).Value = CuentaContable
                .Parameters.Add(New SqlParameter("@Estatus", SqlDbType.VarChar, 30)).Value = Estatus

            End With
            cmd.ExecuteNonQuery()
            result = True
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try
        Return result


    End Function

    Public Function ConsultaTipoMovCaja() As DataTable
        Dim cmd As New SqlCommand()
        Dim ds As New DataSet()

        Try

            If GLOBAL_Connection.State = ConnectionState.Closed Then
                GLOBAL_Connection.Open()
            End If
            cmd.CommandTimeout = GLOBAL_TiempoEspera
            cmd.CommandType = CommandType.StoredProcedure
            cmd.CommandText = "spConsultaCatalogoTipoMovimientoCaja"
            cmd.Connection = GLOBAL_Connection
            With cmd
                .CommandType = CommandType.StoredProcedure
                .Parameters.Add(New SqlParameter("@NotaIngreso", SqlDbType.Bit)).Value = 1
            End With
            Dim da As New SqlDataAdapter(cmd)

            da.Fill(ds, "TipoMovimientoCaja")
        Catch ex As Exception
            Throw ex
        Finally
            If GLOBAL_Connection.State = ConnectionState.Open Then
                GLOBAL_Connection.Close()
            End If
        End Try

        If ds.Tables("TipoMovimientoCaja").Rows.Count > 0 Then
            Return ds.Tables("TipoMovimientoCaja")
        Else
            Return Nothing
        End If

    End Function

End Class
