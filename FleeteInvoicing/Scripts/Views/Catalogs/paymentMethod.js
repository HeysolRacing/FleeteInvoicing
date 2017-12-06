function EditPayment(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/PaymentMethod/Editing",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined)) {
                    document.getElementById("PMCODE_M").value = data.paymentMethodTypeCode;
                    document.getElementById("PMDESC_M").value = data.paymentMethodDesc;
                    $("#editPayment").modal();
                } else {
                    ErrorMessages("No existe el cliente");
                }
            }, error: function (xhr) {
                ErrorMessages('Error en la comunicación del servidor: ' + xhr.status);
                console.log('Error en la comunicación del servidor: ' + xhr.status);
            }
        });
    } else {
        MessageWarning('Ingrese mas tarde o comuniquese con el encargado del sistema ');
    }
}

function DeletePayment(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/PaymentMethod/Deleting",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined)) {
                    document.getElementById("PMCODE_D").value = data.paymentMethodTypeCode;
                    document.getElementById("PMDESC_D").value = data.paymentMethodDesc;
                    $("#deletePayment").modal();
                } else {
                    ErrorMessages("No existe el cliente");
                }
            }, error: function (xhr) {
                ErrorMessages('Error en la comunicación del servidor: ' + xhr.status);
                console.log('Error en la comunicación del servidor: ' + xhr.status);
            }
        });
    } else {
        MessageWarning('Ingrese mas tarde o comuniquese con el encargado del sistema ');
    }
}

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