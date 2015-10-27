Public Class AlumnoController
    Inherits System.Web.Mvc.Controller

    Private vBLL As BLL.AlumnoBLL
    Private vBLLFac As BLL.FacultadBLL

    Sub New()
        Me.vBLL = New BLL.AlumnoBLL
        Me.vBLLFac = New BLL.FacultadBLL
    End Sub
    '
    ' GET: /Alumno

    Function Index() As ActionResult
        Dim vLista As List(Of EE.Alumno) = Me.vBLL.Listar()
        Return View(vLista)
    End Function

    '
    ' GET: /Alumno/Details/5

    Function Details(ByVal id As Integer) As ActionResult
        Dim vAlumno As EE.Alumno = Me.vBLL.ConsultaPorId(id)
        Return View(vAlumno)
    End Function

    '
    ' GET: /Alumno/Create

    Function Create() As ActionResult
        ViewBag.Facultades = Me.vBLLFac.Listar()
        Return View()
    End Function

    '
    ' POST: /Alumno/Create

    <HttpPost()> _
    Function Create(ByVal a As EE.Alumno) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Crear(a)
            Return RedirectToAction("Index")
        End If

        ViewBag.Facultades = Me.vBLLFac.Listar()
        Return View(a)
    End Function

    '
    ' GET: /Alumno/Edit/5

    Function Edit(ByVal id As Integer) As ActionResult
        Dim vAlumno As EE.Alumno = Me.vBLL.ConsultaPorId(id)
        ViewBag.Facultades = Me.vBLLFac.Listar()
        Return View(vAlumno)
    End Function

    '
    ' POST: /Alumno/Edit/5

    <HttpPost()> _
    Function Edit(ByVal id As Integer, ByVal a As EE.Alumno) As ActionResult
        If ModelState.IsValid Then
            Me.vBLL.Editar(a)
            Return RedirectToAction("Index")
        End If

        ViewBag.Facultades = Me.vBLLFac.Listar()
        Return View(a)
    End Function

    '
    ' GET: /Alumno/Delete/5

    Function Delete(ByVal id As Integer) As ActionResult
        Me.vBLL.Eliminar(id)
        Return RedirectToAction("Index")
    End Function

End Class