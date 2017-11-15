function EditCustomer(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/CFD_Expanded/Editing",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined))
                {
                    document.getElementById("CUSTNAME_M").value = data.CUSTNAME;
                    document.getElementById("CORP_CD_M").value = data.CORP_CD;
                    document.getElementById("CNTC_NO_M").value = data.CNTC_NO;
                    document.getElementById("ADDRESS1_M").value = data.ADDRESS1;
                    document.getElementById("ADDRESS2_M").value = data.ADDRESS2;
                    document.getElementById("ADDRESS3_M").value = data.ADDRESS3;
                    document.getElementById("CITY_M").value = data.CITY;
                    document.getElementById("STATE_M").value = data.STATE;
                    document.getElementById("ZIP_M").value = data.ZIP;
                    document.getElementById("RFC_M").value = data.RFC;
                    document.getElementById("PAYMENT_METHOD_TYPE_M").value = data.PAYMENT_METHOD_TYPE;
                    $("#modclientes").modal();
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

function DeleteCustomer(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/CFD_Expanded/Deleting",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined)) {
                    debugger;
                    console.log(data);
                    document.getElementById("CUSTNAME_D").value = data.CUSTNAME;
                    document.getElementById("CORP_CD_D").value = data.CORP_CD;
                    document.getElementById("CNTC_NO_D").value = data.CNTC_NO;
                    document.getElementById("ADDRESS1_D").value = data.ADDRESS1;
                    document.getElementById("ADDRESS2_D").value = data.ADDRESS2;
                    document.getElementById("ADDRESS3_D").value = data.ADDRESS3;
                    document.getElementById("CITY_D").value = data.CITY;
                    document.getElementById("STATE_D").value = data.STATE;
                    document.getElementById("ZIP_D").value = data.ZIP;
                    document.getElementById("RFC_D").value = data.RFC;
                    document.getElementById("PAYMENT_METHOD_TYPE_D").value = data.PAYMENT_METHOD_TYPE;
                    $("#deleteCust").modal();
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