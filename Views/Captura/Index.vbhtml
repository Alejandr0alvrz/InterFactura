@Code
    ViewData("Title") = "Home Page"
End Code
<form id="main-register-form">
    <!--TITULAR-->
    <div class="form-group">
        <h1 class="active">CAPTURA DE INFORMACIÓN</h1>
    </div>
    <!--Datos Principales-->
    <div class="form-group">
        <div class="row">
            <div class="col-lg-4">
                <label for="txtNombre">Nombre</label>
                <input type="text" class="form-control" name="txtNombre" id="txtNombre" placeholder="Nombre" required>
            </div>
            <div class="col-lg-4">
                <label for="txtApPat">Apellido Paterno</label>
                <input type="text" class="form-control" name="txtApPat" id="txtApPat" placeholder="Apellido Paterno" required>
            </div>
            <div class="col-lg-4">
                <label for="txtApMat">Apellido Materno</label>
                <input type="text" class="form-control" name="txtApMat" id="txtApMat" placeholder="Apellido Materno" required>
            </div>
        </div>
    </div>
    <!--Datos Complementarios-->
    <div class="form-group">
        <div class="row">
            <div class="col-lg-4">
                <label for="dtpFechaNac">Fecha de nacimiento</label>
                <input placeholder="Indicar fecha" type="date" name="dtpFechaNac" id="dtpFechaNac" class="form-control datepicker" required>
            </div>
            <div class="col-lg-4">
                <label for="txtRFC">RFC</label>
                <input type="text" class="form-control" id="txtRFC" name="txtRFC" placeholder="RFC" maxlength="12" required>
            </div>
            <div class="col-lg-4">
                <label for="dtpFechaIng">Fecha de ingreso</label>
                <input placeholder="Indicar fecha" type="date" id="dtpFechaIng" name="dtpFechaIng" class="form-control datepicker" required>
            </div>
        </div>
    </div>
    <div class="form-group">
        <div class="row">
            <div class="col-lg-4">
                <label for="chkAct">Alumno Activo</label>
                <input type="checkbox" name="chkAct" id="chkAct" placeholder="Activo">
            </div>
            <div class="col-lg-4">
                <label for="slctGenero">Genero</label>
                <select name="genero">
                    <option value="1">Masculino</option>
                    <option value="2">Femenino</option>
                </select>
            </div>
        </div>
    </div>
    <!--GUARDADO-->
    <button type="submit" class="btn btn-primary">Guardar</button>
</form>
<h1 id="rspnse" class="active" style="display:none;"></h1>


<script type="text/javascript">
    $('#main-register-form').submit(function () {       
        $.ajax({
            type: 'POST',
            url: '/captura/save',
            data: $('#main-register-form').serialize(),
            success: function (data) {
                $('#rspnse').text(data)
                $('#rspnse').show();
            }
        });
        return false;
    });
</script>