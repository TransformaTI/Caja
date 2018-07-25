Imports RTGMGateway
Public Class TransformadorCRM
    Public Function ConsultaChequesCRM(lDataTable As DataTable) As DataTable
        Dim lParametro As New SigaMetClasses.cConfig(16, GLOBAL_CorporativoUsuario, GLOBAL_SucursalUsuario)
        Dim lURLGateway As String
        Try
            lURLGateway = CType(lParametro.Parametros.Item("URLGateway"), String)
        Catch SAEX As System.ArgumentException
            lURLGateway = ""
        Catch ex As Exception
            Throw ex
        End Try

        lParametro.Dispose()
        If Not String.IsNullOrEmpty(lURLGateway) Then
            Dim lSolicitud As RTGMGateway.SolicitudGateway = New SolicitudGateway()
            Dim lRemoteGateway As RTGMGateway.RTGMGateway = New RTGMGateway.RTGMGateway()
            lRemoteGateway.URLServicio = lURLGateway
            For Each row As DataRow In lDataTable.Rows
                Dim lCliente As Integer
                lCliente = Convert.ToInt32(row("Cliente"))
                lSolicitud.Fuente = RTGMCore.Fuente.CRM
                lSolicitud.Sucursal = GLOBAL_SucursalUsuario
                lSolicitud.IDCliente = lCliente
                Dim lDireccionEntrega As RTGMCore.DireccionEntrega = lRemoteGateway.buscarDireccionEntrega(lSolicitud)
                row("ClienteNombre") = lDireccionEntrega.Nombre
            Next row
        End If
        Return lDataTable
    End Function
End Class
