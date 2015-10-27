Public Class TelefonoMPP

    Private vDatos As DAL.Datos

    Sub New()
        Me.vDatos = New DAL.Datos
    End Sub

    Public Function Crear(ByVal t As EE.Telefono) As Boolean

    End Function

    Public Function Editar(ByVal t As EE.Telefono) As Boolean

    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean

    End Function

    Public Function Listar() As List(Of EE.Telefono)

    End Function

End Class
