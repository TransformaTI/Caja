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

                tipoConcepto.TipoConceptoPro = Convert.ToInt32(reader(0).ToString())
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
            cmd.CommandText = "spConsultaTipoConcepto"
            cmd.Connection = GLOBAL_Connection
            Dim reader As SqlDataReader
            reader = cmd.ExecuteReader()
            While (reader.Read)
                'Dim celula As New Celula(Convert.ToInt32(reader(0).ToString()), reader(1).ToString())


                TipoConcepto.TipoConceptoPro = Convert.ToInt32(reader(0).ToString())
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
End Class
