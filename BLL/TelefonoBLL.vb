Public Class TelefonoBLL

    Private vMapper As MPP.TelefonoMPP

    Sub New()
        Me.vMapper = New MPP.TelefonoMPP
    End Sub

    Public Function Crear(ByVal t As EE.Telefono) As Boolean
        Return Me.vMapper.Crear(t)
    End Function

    Public Function Editar(ByVal t As EE.Telefono) As Boolean
        Return Me.vMapper.Editar(t)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of EE.Telefono)
        Return Me.vMapper.Listar()
    End Function

End Class
