Imports System.Text.RegularExpressions

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

Public Class Cuenta
	Public Function validarExpresionRegular(TipoCobro As Integer, CuentaOrigen As String) As Boolean
		Dim resultado As Boolean = True

		Dim cuenta As New SigaMetClasses.cCuenta()

		Try
			Dim patron As String
			patron = cuenta.ConsultarPatron(TipoCobro)

			Dim reg As New Regex(patron

			resultado = reg.IsMatch(CuentaOrigen)
		Catch ex As Exception
			If ex.Message = "vacio" Then
				Throw New Exception("Tipo de cobro no tiene patron")
			Else
				Throw New Exception(ex.Message)
			End If
		End Try

		Return resultado
	End Function


End Class