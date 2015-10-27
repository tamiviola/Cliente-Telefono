Imports System.ComponentModel.DataAnnotations
Public Class Alumno

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

    Private vNombre As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Nombre")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Nombre() As String
        Get
            Return vNombre
        End Get
        Set(ByVal value As String)
            vNombre = value
        End Set
    End Property

    Private vApellido As String
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Apellido")>
    <StringLength(50, ErrorMessage:="Se ha superado la longitud permitida de 50 caracteres.")>
    Public Property Apellido() As String
        Get
            Return vApellido
        End Get
        Set(ByVal value As String)
            vApellido = value
        End Set
    End Property

    Private vFechaNac As Date
    <Required(ErrorMessage:="Campo requerido"), Display(Name:="Fecha"), DisplayFormat(DataFormatString:="{0:dd/MM/yyyy}")>
    Public Property FechaNac() As Date
        Get
            Return vFechaNac
        End Get
        Set(ByVal value As Date)
            vFechaNac = value
        End Set
    End Property

    Private vTelefono As New Telefono
    Public Property Telefono() As Telefono
        Get
            Return vTelefono
        End Get
        Set(ByVal value As Telefono)
            vTelefono = value
        End Set
    End Property

    Private vFacultad As New Facultad
    Public Property Facultad() As Facultad
        Get
            Return vFacultad
        End Get
        Set(ByVal value As Facultad)
            vFacultad = value
        End Set
    End Property

End Class
