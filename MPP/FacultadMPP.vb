Public Class FacultadMPP

    Private vDatos As DAL.Datos

    Sub New()
        Me.vDatos = New DAL.Datos
    End Sub

    Public Function Crear(ByVal f As EE.Facultad) As Boolean

    End Function

    Public Function Editar(ByVal f As EE.Facultad) As Boolean

    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean

    End Function

    Public Function Listar() As List(Of EE.Facultad)
        Dim ds As New DataSet
        Dim lista As New List(Of EE.Facultad)
        ds = vDatos.Leer("s_ListarFacultad", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each item As DataRow In ds.Tables(0).Rows
                Dim f As EE.Facultad = New EE.Facultad
                f.Id = item("Id")
                f.Nombre = item("Nombre")
                lista.Add(f)
            Next
        End If

        Return lista
    End Function

End Class
