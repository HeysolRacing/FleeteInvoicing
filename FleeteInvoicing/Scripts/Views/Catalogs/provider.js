//Edit provider
function Edit(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/cat_Gestores/GetProvider",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined)) {
                    document.getElementById("ClaveGestor").value = data.ges_Clave_Gestor;
                    document.getElementById("NombreGestor").value = data.ges_Nombre_Gestor;
                    document.getElementById("TipoGestor").value = data.ges_Tipo_Gestor;
                    document.getElementById("EstatusGestor").value = data.ges_Estatus_Gestor;
                    $("#modProvider").modal();
                } else {
                    ErrorMessages("No existe el proveedor");
                }
            }, error: function (xhr) {
                ErrorMessages('Error en la comunicación del servidor: ' + xhr.status);
                console.log('Error en la comunicación del servidor: ' + xhr.status);
            }
        });
    } else {
        MessageWarning('Ingrese mas Tarde o comuniquese con el encargado del sistema ');
    }
}
///#View Model Provider

function IsAlphanumeric() {
    if ((event.charCode === 32)) {
        return true;
    }
    if (
            (event.charCode < 97 || event.charCode > 122) &&
            (event.charCode < 65 || event.charCode > 90) &&
            event.charCode !== 241 &&
            event.charCode !== 209 &&
            (event.charCode < 48 || event.charCode > 57)
        ) {
        return false;
    }
    return true;
}
$(function () {
    $('#grdProvider').DataTable();
});