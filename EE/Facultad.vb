Imports System.ComponentModel.DataAnnotations
Public Class Facultad

    Sub New()

    End Sub

    Private vId As Integer
    <Required(ErrorMessage:="Campo requerido")>
    Public Property Id() As Integer
        Get
            Return vId
        End Get
        Set(ByVal value As Integer)
            vId = value
        End Set
    End Property

    Private vNombre As String
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

End Class
