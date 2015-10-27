Public Class AlumnoBLL

    Private vMapper As MPP.AlumnoMPP

    Sub New()
        vMapper = New MPP.AlumnoMPP
    End Sub

    Public Function Crear(ByVal a As EE.Alumno) As Boolean
        Return Me.vMapper.Crear(a)
    End Function

    Public Function Editar(ByVal a As EE.Alumno) As Boolean
        Return Me.vMapper.Editar(a)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Return Me.vMapper.Eliminar(id)
    End Function

    Public Function Listar() As List(Of EE.Alumno)
        Return Me.vMapper.Listar()
    End Function

    Public Function ConsultaPorId(ByVal id As Integer) As EE.Alumno
        Return vMapper.ConsultaPorId(id)
    End Function

End Class
