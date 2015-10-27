Public Class AlumnoMPP

    Private vDatos As DAL.Datos

    Sub New()
        Me.vDatos = New DAL.Datos
    End Sub

    Public Function Crear(ByVal a As EE.Alumno) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Nombre", a.Nombre)
        parametros.Add("@Apellido", a.Apellido)
        parametros.Add("@FechaNac", a.FechaNac)
        parametros.Add("@Numero", a.Telefono.Numero)
        parametros.Add("@Zona", a.Telefono.Zona)
        parametros.Add("@Detalle", a.Telefono.Detalle)
        parametros.Add("@Facultad_Id", a.Facultad.Id)

        Return vDatos.Escribir("s_AltaAlumno", parametros)
    End Function

    Public Function Editar(ByVal a As EE.Alumno) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", a.Id)
        parametros.Add("@Nombre", a.Nombre)
        parametros.Add("@Apellido", a.Apellido)
        parametros.Add("@FechaNac", a.FechaNac)
        parametros.Add("@Numero", a.Telefono.Numero)
        parametros.Add("@Zona", a.Telefono.Zona)
        parametros.Add("@Detalle", a.Telefono.Detalle)
        parametros.Add("@Facultad_Id", a.Facultad.Id)

        Return vDatos.Escribir("s_EditarAlumno", parametros)
    End Function

    Public Function Eliminar(ByVal id As Integer) As Boolean
        Dim parametros As New Hashtable

        parametros.Add("@Id", id)

        Return vDatos.Escribir("s_EliminarAlumno", parametros)
    End Function

    Public Function Listar() As List(Of EE.Alumno)
        Dim ds As New DataSet
        Dim lista As New List(Of EE.Alumno)
        ds = vDatos.Leer("s_ListarAlumno", Nothing)

        If ds.Tables(0).Rows.Count > 0 Then
            For Each Item As DataRow In ds.Tables(0).Rows
                Dim a As EE.Alumno = New EE.Alumno
                a.Id = Item("Id")
                a.Nombre = Item("Nombre")
                a.Apellido = Item("Apellido")
                a.FechaNac = Item("FechaNac")
                a.Telefono.Numero = Item("Numero")
                a.Telefono.Zona = Item("Zona")
                a.Telefono.Detalle = Item("Detalle")
                a.Facultad.Nombre = Item("FacNombre")
                lista.Add(a)
            Next
        End If

        Return lista
    End Function

    Public Function ConsultaPorId(ByVal id As Integer) As EE.Alumno
        Dim parametros As New Hashtable
        Dim ds As New DataSet

        parametros.Add("@Id", id)
        ds = vDatos.Leer("s_ConsultarPorIdAlumno", parametros)

        If ds.Tables(0).Rows.Count > 0 Then
            Dim row As DataRow = ds.Tables(0).Rows(0)
            Dim a As New EE.Alumno
            a.Id = row.Item("Id")
            a.Nombre = row.Item("Nombre")
            a.Apellido = row.Item("Apellido")
            a.FechaNac = row.Item("FechaNac")
            a.Telefono.Numero = row.Item("Numero")
            a.Telefono.Zona = row.Item("Zona")
            a.Telefono.Detalle = row.Item("Detalle")
            a.Facultad.Id = row.Item("FacId")
            a.Facultad.Nombre = row.Item("FacNombre")

            Return a
        Else
            Return Nothing
        End If
    End Function

End Class
