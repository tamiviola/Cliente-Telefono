@ModelType EE.Alumno

@Code
    ViewData("Title") = "Create"
End Code

<h2>Create</h2>

@Using Html.BeginForm()
    @Html.AntiForgeryToken()
    @Html.ValidationSummary(True)

    @<fieldset>
        <legend>Alumno</legend>
       @Html.HiddenFor(Function(model) model.Id)
        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Nombre)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Nombre)
            @Html.ValidationMessageFor(Function(model) model.Nombre)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.Apellido)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.Apellido)
            @Html.ValidationMessageFor(Function(model) model.Apellido)
        </div>

        <div class="editor-label">
            @Html.LabelFor(Function(model) model.FechaNac)
        </div>
        <div class="editor-field">
            @Html.EditorFor(Function(model) model.FechaNac)
            @Html.ValidationMessageFor(Function(model) model.FechaNac)
        </div>
        
         <div class="editor-label">
             @Html.LabelFor(Function(model) model.Telefono.Numero)
         </div>
         <div class="editor-field">
             @Html.EditorFor(Function(model) model.Telefono.Numero)
             @Html.ValidationMessageFor(Function(model) model.Telefono.Numero)
         </div>

         <div class="editor-label">
             @Html.LabelFor(Function(model) model.Telefono.Zona)
         </div>
         <div class="editor-field">
             @Html.EditorFor(Function(model) model.Telefono.Zona)
             @Html.ValidationMessageFor(Function(model) model.Telefono.Zona)
         </div>
    
         <div class="editor-field">
             @Html.LabelFor(Function(model) model.Telefono.Detalle)
             @Html.DropDownListFor(Function(model) model.Telefono.Detalle, New List(Of SelectListItem)() From { _
                                New SelectListItem() With {.Text = "Hogar", .Value = "Hogar"},
                                New SelectListItem() With {.Text = "Personal", .Value = "Personal"},
                                New SelectListItem() With {.Text = "Laboral", .Value = "Laboral"}
                            }, "")
             @Html.ValidationMessageFor(Function(model) model.Telefono.Detalle)
         </div>

         <div class="editor-label">
             <label>Facultad</label>
             @Html.DropDownListFor(Function(model) model.Facultad.Id, New SelectList(ViewBag.Facultades, "Id", "Nombre"), "")
             @Html.ValidationMessageFor(Function(model) model.Facultad.Id)
         </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
End Using

<div>
    @Html.ActionLink("Back to List", "Index")
</div>
