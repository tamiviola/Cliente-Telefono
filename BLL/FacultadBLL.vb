Public Class FacultadBLL

    Private vMapper As MPP.FacultadMPP

    Sub New()
        Me.vMapper = New MPP.FacultadMPP
    End Sub

    Public Function Crear(ByVal f As EE.Facultad) As Boolean
        Return Me.vMapper.Crear(f)
    End Function

    Public Function Editar(ByVal f As EE.Facultad) As Boolean
        Return Me.vMapper.Editar(f)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of EE.Facultad)
        Return Me.vMapper.Listar()
    End Function

End Class
