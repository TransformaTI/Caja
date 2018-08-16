Public Class DebitoAnticipo
    Public _anio As String
    Public _folio As String
    Public _montodebitado As Decimal

    Property anio() As String
        Get
            Return _anio
        End Get
        Set(ByVal Value As String)
            _anio = Value
        End Set
    End Property

    Property folio() As String
        Get
            Return _folio
        End Get
        Set(ByVal Value As String)
            _folio = Value
        End Set
    End Property

    Property montodebitado() As Decimal
        Get
            Return _montodebitado
        End Get
        Set(ByVal Value As Decimal)
            _montodebitado = Value
        End Set
    End Property


End Class