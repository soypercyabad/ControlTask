
//Llenar las tablas al cargar el documento
$(document).ready(function () {
    llenaTablas();
});

//Funcion de LLenar tablas
function llenaTablas() {
    $.ajax({
        type: "POST",
        url: "Home/Llenartabla",
        dataType: "json",
        success: function (data) {
            $("#bodyTabla").html("");
            $.each(data, function (key, valor) {
                //condicion ? ValorSI : ValorNO
                let statusTxt = valor.Estado ? "Completo" : "Pendiente"; //Valida si el estado es True o False - Para cambiar Visualmente la info en la tabla
                let statusHex = valor.Estado ? "success" : "danger"; //Valida si el estado es True o False - Para cambiar Visualmente el bg de la info en la tabla
                let Statuscheck = valor.Estado ? "checked" : ""; //Valida si el estado es true o false - Para Mostrar el estado del checkbox
                let Statusvicheck = valor.Estado ? "disabled" : ""; //Valida si el estado es true o false - Para Mostrar la visibilidad del checkbox
                let Datefinish = valor.Estado ? moment(valor.Fechater).format('DD-MM-YYYY  HH:mm:ss') : " "; //Valida si el estado es true o false - Para Mostrar la visibilidad del checkbox

                var codigoHtml =
                    "<tr>" +
                    "<th scope=\"row\">" + valor.Id + "</th>" +
                    "<td>" + valor.Nombre + "</td>" +
                    "<td>" + moment(valor.Fechare).format('DD-MM-YYYY  HH:mm:ss') + "</td> " +
                    "<td>" +
                    "    <span class=\"badge rounded-pill bg-" + statusHex + "\">" + statusTxt + "</span>" +
                    "</td>" +
                    "<td>" + Datefinish + "</td>" +
                    "<td>" +
                    "    <input class=\"form-check-input\" type=\"checkbox\" id=\"checkboxNoLabel\" onclick=\"cambiostatus(" + valor.Id + ")\"" + Statuscheck + " " + Statusvicheck + ">" +
                    "</td>" +
                    "<td>" +
                    "    <i class=\"fa-solid fa-arrows-rotate\" valu=" + valor.Id + " style=\"color:green\" data-bs-toggle=\"modal\" data-bs-target=\"#updatetask\" onclick=\"llenarmoadalupdate(" + valor.Id + ","+ valor.Nombre + "," + valor.Fechacre + ")\"></i>" +
                    "</td>" +
                    "<td>" +
                    "    <i class=\"fa-solid fa-trash\" style=\"color:red\" onclick=\"Eliminar(" + valor.Id + ")\"></i>" +
                    "</td>" +
                    "</tr>";
                $("#bodyTabla").append(codigoHtml);
            });
        },
        error: function (error) {
            Swal.fire({
                icon: 'error',
                title: 'Oops!',
                text: 'Se producido un error de tipo: ' + error,
            })
        }
    });
}


//Funcion de Agregar
function Agregartask() {

    let nameadd = $("#nameadd").val();
    let timeadd = moment().format('DD-MM-YYYY HH:mm:ss');

    let objtask = { Nombre: nameadd, FechaCre: timeadd };

    $.ajax({
        type: "POST",
        url: "Home/Agregar",
        dataType: "json",
        data: objtask,
        success: function (data) {
            llenaTablas()
            Swal.fire({
                icon: 'success',
                title: 'Felicidades!',
                text: 'Has creado una nueva tarea!',
            })
            $('#nameadd').val('');
            $('#relojadd').val('');

        },
        error: function () {
            Swal.fire(
                'Oopss!',
                '¡No se pudo crear tu tarea!',
                'error'
            )
        }
    });
}

//Funcion para cambiar estados
function cambiostatus(id) {
    var miCheckbox = document.getElementById('checkboxNoLabel');
    if (miCheckbox.click) {

        let objtask = 1;

        $.ajax({
            type: "POST",
            url: "Home/Status",
            dataType: "json",
            data: objtask,
            success: function (data) {

                Swal.fire(
                    '¡Felicidades!',
                    '¡Has dado por finalizado la tarea',
                    'info'
                )

                //Refrescar la pagina
                $("#exampleFormControlInput1").val(data.Nombre);
                llenaTablas()
            },
            error: function () {
                Swal.fire(
                    'Oopss!',
                    '¡No se pudo finalizar tu tarea!',
                    'error'
                )
            }
        });
    }


}

function llenarmoadalupdate(id, nombre, fecha) {
    $("#idupdate").val(id);
    $("#nameupdate").val(nombre);
    ("#timeupdate").val(fecha);
}

//Funcion de actualizar
function ActualizarTarea(id) {

    let idupdt = $("#idupdate").val();
    let nameupdt = $("#nameupdate").val();
    let timeupdt = $("#timeupdate").val();

    let objtask = { Id : idupdt, Nombre: nameupdt, Fechacre: timeupdt };

    $.ajax({
        type: "POST",
        url: "Home/Actualizar",
        dataType: "json",
        data: objtask,
        success: function (data) {


            Swal.fire(
                '¡Actualizado!',
                '¡Tu tarea ha sido actualizada!',
                'success'
            )

            //Refrescar la pagina
            $("#nameupdate").val(data.Nombre);
            $("#timeupdate").val(data.FechaCre);
            llenaTablas()
        },
        error: function () {
            Swal.fire(
                'Oopss!',
                '¡No se pudo actualizar tu tarea!',
                'error'
            )
        }
    });
}

//Funcion de eliminar
function Eliminar() {

    swal.fire({
        title: '¿Estas Seguro?',
        text: "¡No podra revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: '¡No, Cancelar!',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '¡Si, Eliminalo!'
    }).then((result) => {
        if (result.isConfirmed) {
            //Refrescar la pagina
            llenaTablas()
            let objtask = 1;//{ Id: id }
            $.ajax({
                type: "POST",
                url: "Home/Eliminar",
                dataType: "json",
                data: objtask,
                success: function () {
                    Swal.fire(
                        '¡Eliminado!',
                        '¡Tu tarea ha sido eliminada!',
                        'success'
                    )
                },
                error: function () {
                    Swal.fire(
                        'Oopss!',
                        '¡No se pudo eliminar tu tarea!',
                        'error'
                    )
                }
            });
        }
    })
}




