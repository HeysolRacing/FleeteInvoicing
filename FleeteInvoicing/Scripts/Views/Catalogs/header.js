function EditHeader(id) {
    if (id !== 0) {
        var jsonMapping = JSON.stringify({ id: id });
        $.ajax({
            type: "POST",
            url: "/CFD_Header/Editing",
            data: jsonMapping,
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                if ((data !== null) && (data !== undefined)) {
                    debugger;
                    console.log(data);
                    document.getElementById("headerFleet_M").value = (data.headerFleet == undefined) ? "" : data.headerFleet;
                    document.getElementById("headerSeries_M").value = data.headerSeries + "-" + data.headerFolio;
                    document.getElementById("headerUUID_M").value = (data.headerUUID == undefined) ? "" : data.headerUUID;
                    document.getElementById("headerObs3_M").value = (data.headerObs3 == undefined) ? "" : data.headerObs3;
                    document.getElementById("headerComments_M").value = (data.headerComments == undefined) ? "" : data.headerComments;
                    $("#editHeader").modal();

                } else {
                    ErrorMessages("No existe el cliente");
                }
            }, error: function (xhr) {
                ErrorMessages('Error en la comunicación del servidor: ' + xhr.status);
                console.log('Error en la comunicación del servidor: ' + xhr.status);
            }
        });
    } else {
        MessageWarning('Ingrese más tarde o comuniquese con el encargado del sistema ');
    }
}
