Public Class TipoConcepto
    Dim _tipoConcepto As Integer
    Dim _descripcion As String
    Dim _tipomovimientocaja As Integer
    Dim _cuentacontable As String
    Dim _status As String
    Dim _usuarioalta As String
    Dim _falta As String

    Public Property TipoConcepto As Integer
        Get
            Return _tipoConcepto
        End Get
        Set(value As Integer)
            _tipoConcepto = value
        End Set
    End Property

    Public Property Descripcion As String
        Get
            Return _descripcion
        End Get
        Set(value As String)
            _descripcion = value
        End Set
    End Property

    Public Property Tipomovimientocaja As Integer
        Get
            Return _tipomovimientocaja
        End Get
        Set(value As Integer)
            _tipomovimientocaja = value
        End Set
    End Property

    Public Property Cuentacontable As String
        Get
            Return _cuentacontable
        End Get
        Set(value As String)
            _cuentacontable = value
        End Set
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(value As String)
            _status = value
        End Set
    End Property

    Public Property Usuarioalta As String
        Get
            Return _usuarioalta
        End Get
        Set(value As String)
            _usuarioalta = value
        End Set
    End Property

    Public Property Falta As String
        Get
            Return _falta
        End Get
        Set(value As String)
            _falta = value
        End Set
    End Property

    Public Sub Alta()
        Dim metodoDatos As MetodoDatos = New MetodoDatos()
        metodoDatos.GuardaTipoConcepto(Me.Descripcion, Me.Tipomovimientocaja, Me.Cuentacontable, Me.Status, Me.Usuarioalta, DateTime.Parse(Me.Falta))
    End Sub

    Public Sub Modifica()
        Dim metodoDatos As MetodoDatos = New MetodoDatos()
        metodoDatos.ModificaTipoConcepto(Me.TipoConcepto, Me.Descripcion, Me.Tipomovimientocaja, Me.Cuentacontable, Me.Status)
    End Sub


End Class
