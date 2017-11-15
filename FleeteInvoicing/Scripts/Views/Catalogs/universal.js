function EditUniversal(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/UniversalCollection/Editing",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined)) {
                    document.getElementById("Fleet_M").value = (data.uc_fleet == undefined) ? "" : data.uc_fleet;
                    document.getElementById("Account_M").value = (data.uc_account == undefined) ? "" : data.uc_account;
                    document.getElementById("Clabe_M").value = (data.uc_clabe == undefined) ? "" : data.uc_clabe;
                    document.getElementById("Aba_M").value = (data.uc_aba == undefined) ? "" : data.uc_aba;
                    document.getElementById("Swift_M").value = (data.uc_swift == undefined) ? "" : data.uc_swift;
                    document.getElementById("Currency_M").value = (data.uc_currency == undefined) ? "" : data.uc_currency;
                    $("#editUniversal").modal();
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

function DeleteUniversal(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/UniversalCollection/Deleting",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined)) {
                    document.getElementById("Fleet_D").value = (data.uc_fleet == undefined) ? "" : data.uc_fleet;
                    document.getElementById("Account_D").value = (data.uc_account== undefined) ? "" : data.uc_account;
                    document.getElementById("Clabe_D").value = (data.uc_clabe== undefined) ? "" : data.uc_clabe;
                    document.getElementById("Aba_D").value = (data.uc_aba== undefined) ? "" : data.uc_aba;
                    document.getElementById("Swift_D").value = (data.uc_swift== undefined) ? "" : data.uc_swift;
                    document.getElementById("Currency_D").value = (data.uc_currency== undefined) ? "" : data.uc_currency;
                    $("#deleteUniversal").modal();
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
