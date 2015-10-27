@ModelType EE.Alumno

@Code
    ViewData("Title") = "Details"
End Code

<h2>Details</h2>

<fieldset>
    <legend>Alumno</legend>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Nombre)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Nombre)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.Apellido)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.Apellido)
    </div>

    <div class="display-label">
        @Html.DisplayNameFor(Function(model) model.FechaNac)
    </div>
    <div class="display-field">
        @Html.DisplayFor(Function(model) model.FechaNac)
    </div>
</fieldset>
<p>

    @Html.ActionLink("Edit", "Edit", New With {.id = Model.Id}) |
    @Html.ActionLink("Delete", "Delete", New With {.id = Model.Id})
    
    @Html.ActionLink("Back to List", "Index")
</p>
