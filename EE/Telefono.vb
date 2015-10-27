Imports System.ComponentModel.DataAnnotations
Public Class Telefono

    Sub New()

    End Sub

    Private vId As Integer
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vNumero As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Teléfono")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Numero() As String
        Get
            Return vNumero
        End Get
        Set(ByVal value As String)
            vNumero = value
        End Set
    End Property

    Private vZona As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Zona")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Zona() As String
        Get
            Return vZona
        End Get
        Set(ByVal value As String)
            vZona = value
        End Set
    End Property

    Private vDetalle As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Detalle")>
    Public Property Detalle() As String
        Get
            Return vDetalle
        End Get
        Set(ByVal value As String)
            vDetalle = value
        End Set
    End Property

End Class
