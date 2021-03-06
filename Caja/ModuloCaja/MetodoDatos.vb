﻿Imports System.Collections.Generic
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
End Class
