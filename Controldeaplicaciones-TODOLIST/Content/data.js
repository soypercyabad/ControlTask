listado();

//Metodo para Cargar la lista al ejecutar el documento
function listado() {
    $.get("Home/Listtask", function (data) {
        CrearListado(data);
    });
}

//Metodo para Resetear Tabla
function Destroy() {
    $("#tableTask").dataTable().fnDestroy();
}

//Metodo para Listar Datos
function CrearListado(data) {
    var contenido = "";
    for (var i = 0; i < data.length; i++) {
        contenido += "<tr>";
        contenido += "<th id=\"tbid\" scope=\"row\">" + data[i].Id + "</th>";
        contenido += "<td id=\"tbname\">";
        contenido += "<span>" + data[i].Nombre + "</span>";
        contenido += "</td>";
        contenido += "<td id=\"tbnote\">";
        contenido += "<span>" + data[i].Nota + "</span>";
        contenido += "</td>";
        contenido += "<td id=\"tbdatec\">";
        contenido += "<span>" + moment(data[i].Fechacre).format('DD-MM-YYYY HH:mm:ss') + "</span>";
        contenido += "</td>";
        contenido += "<td id=\"tbstatus\">";
        if (data[i].Estado == 1) {
            contenido += "<span class=\"badge rounded-pill bg-success\"> Completado </span>";
        } else {
            contenido += "<span class=\"badge rounded-pill bg-danger\"> Pendiente </span>";
        }
        contenido += "</td>";
        contenido += "<td id=\"tbdatef\">";
        if (data[i].Fechacre > data[i].Fechater) {
            contenido += "<span>  </span>";
        } else {
            contenido += "<span>" + moment(data[i].Fechater).format('DD-MM-YYYY HH:mm:ss') + "</span>";
        }
        contenido += "</td>";
        contenido += "<td id=\"tbprioridad\">";
        if (data[i].Prioridad == "Alta") {
            contenido += "<span class=\"badge rounded-pill bg-danger text-danger bg-opacity-25\">" + data[i].Prioridad + "</span>";
        } else if (data[i].Prioridad == "Media") {
            contenido += "<span class=\"badge rounded-pill bg-secondary text-secondary bg-opacity-25\">" + data[i].Prioridad + "</span>";
        } else if (data[i].Prioridad == "Baja") {
            contenido += "<span class=\"badge rounded-pill bg-primary text-primary bg-opacity-25\">" + data[i].Prioridad + "</span";
        }
        contenido += "</td>";
        contenido += "<td>";
        if (data[i].Estado == 1) {
            contenido += "<input class=\"form-check-input\" type=\"checkbox\" id=\"changestatus\" checked disabled>";
        } else {
            contenido += "<input class=\"form-check-input\" type=\"checkbox\" id=\"changestatus\" onclick=\"CambiarEstado(" + data[i].Id + ")\">";
        }
        contenido += "</td>";
        contenido += "<td>";
        if (data[i].Estado == 1) {
            contenido += "<i class=\"fa-solid fa-arrows-rotate edit\" style=\"color:green\"></i>";
        } else {
            contenido += "<i class=\"fa-solid fa-arrows-rotate edit\" style=\"color:green\" data-bs-toggle=\"modal\" data-bs-target=\"#updatetask\" onclick=\"ObtenerData(" + data[i].Id + ")\"></i>";
        }
        contenido += "</td>";
        contenido += "<td>";
        contenido += "<i class=\"fa-solid fa-trash\" style=\"color:red\" onclick=\"EliminarTask(" + data[i].Id + ")\"></i>";
        contenido += "</td>";
        contenido += "</tr>";
    }
    
    document.getElementById("bodyTabla").innerHTML = contenido;
    $("#tableTask").dataTable({
        ordering: false,
        searching: false,
        language: {
            "lengthMenu": "Mostrar _MENU_ registros",
            "zeroRecords": "No se encontraron resultados",
            "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
            "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
            "infoFiltered": "(filtrado de un total de _MAX_ registros)",
            "sSearch": "Buscar:",
            "oPaginate": {
                "sFirst": "Primero",
                "sLast": "Último",
                "sNext": "Siguiente",
                "sPrevious": "Anterior"
            },
            "sProcessing": "Procesando...",
        }
    });
}

//Metodo para Filtrar por Prioridad
function BusquedaFilter() {
    var filtro = document.getElementById("cmbprioridad").value;
    if (filtro == "Todos") {

        Destroy();
        $.get("Home/Listtask", function (data) {
            CrearListado(data);
        });
    } else {

        Destroy();
        $.get("Home/ListPrioridad/?filtro=" + filtro, function (data) {
            CrearListado(data);
        });
    }
}

//Metodo para 0btener Datos
function ObtenerData(id) {
    $.get("Home/GetDatos/?id=" + id, function (data) {
        document.getElementById("idupdate").value = data[0].Id;
        document.getElementById("nameupdate").value = data[0].Nombre;
        document.getElementById("noteupdate").value = data[0].Nota;
        document.getElementById("priorityupdate").value = data[0].Prioridad;
    });
}

//Metodo para Limpiar Inputs
function LimpiarInput() {
    var controles = document.getElementsByClassName("clear");
    var ncontroles = controles.length;
    for (var i = 0; i < ncontroles; i++) {
        controles[i].value = "";
    }

    var $miSelect = $('#priorityadd');
    $miSelect.val($miSelect.children('option:first').val());

}

//Metodo para Cerrar Modal
function CierraPopup() {
    $('#cerraradd').click(); //Esto simula un click sobre el botón close de la modal, por lo que no se debe preocupar por qué clases agregar o qué clases sacar.
    $('#cerrarupdate').click(); //Esto simula un click sobre el botón close de la modal, por lo que no se debe preocupar por qué clases agregar o qué clases sacar.
    $('.modal-backdrop').remove();//eliminamos el backdrop del modal
}

//Metodo para Agregar Task
function Agregartask() {

    var form = new FormData();

    var nombre = document.getElementById("nameadd").value;
    var nota = document.getElementById("noteadd").value;
    var fechaini = document.getElementById("relojadd").textContent;
    var estado = document.getElementById("statusadd").value;
    var fechafin = document.getElementById("relojaddfin").value;
    var prioridad = document.getElementById("priorityadd").value;

    if (nombre == "" || nota == "" || prioridad == "-- Seleccione una Opción--") {
        Swal.fire(
            'Oopss!',
            '¡Faltan ingresar datos al formulario!',
            'error'
        )
    } else {
        form.append("Nombre", nombre);
        form.append("Nota", nota);
        form.append("Fechacre", fechaini);
        form.append("Estado", estado);
        form.append("Fechater", fechafin);
        form.append("Prioridad", prioridad);

        $.ajax({
            type: "POST",
            url: "Home/InsertTask",
            data: form,
            contentType: false,
            processData: false,
            success: function (data) {
                LimpiarInput();
                Destroy();
                listado();
                CierraPopup();
                Swal.fire({
                    icon: 'success',
                    title: 'Felicidades!',
                    text: 'Has creado una nueva tarea!',
                })
            },
            error: function () {
                Swal.fire(
                    'Oopss!',
                    '¡No se pudo crear tu tarea!',
                    'error'
                )
            }
        })
    }
}

//Metodo para Editar Task
function EditarTask() {
    var form = new FormData();

    var id = document.getElementById("idupdate").value;
    var nombre = document.getElementById("nameupdate").value;
    var nota = document.getElementById("noteupdate").value;

    if (nombre == "" || nota == "") {
        Swal.fire(
            'Oopss!',
            '¡Faltan ingresar datos al formulario!',
            'error'
        )
    } else {
        form.append("Id", id);
        form.append("Nombre", nombre);
        form.append("Nota", nota);

        $.ajax({
            type: "POST",
            url: "Home/EditTask",
            data: form,
            contentType: false,
            processData: false,
            success: function (data) {
                LimpiarInput();
                Destroy();
                listado();
                CierraPopup();
                Swal.fire({
                    icon: 'success',
                    title: 'Felicidades!',
                    text: 'Tu tarea fue actualizada!',
                })
            },
            error: function () {
                Swal.fire(
                    'Oopss!',
                    '¡No se pudo actualizar tu tarea!',
                    'error'
                )
            }
        })
    }
}

//Metodo para Cambiar el Estado
function CambiarEstado(id) {

    var form = new FormData();
    form.append("Id", id);

    swal.fire({
        title: '¿Desea Finalizar la Tarea?',
        text: "¡No podra revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: '¡No, Cancelar!',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '¡Si, Finalizar!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "Home/ChangeStatusTask",
                data: form,
                contentType: false,
                processData: false,
                success: function (data) {
                    Destroy();
                    listado();
                    Swal.fire(
                        '¡Felicidades!',
                        '¡Has dado por finalizado la tarea',
                        'success'
                    )
                },
                error: function () {
                    Swal.fire(
                        'Oopss!',
                        '¡No se pudo finalizar tu tarea!',
                        'error'
                    )
                }
            })
        }
    })
}

//Metodo para Eliminar Task
function EliminarTask(id) {

    var form = new FormData();
    form.append("Id", id);

    swal.fire({
        title: '¿Desea Eliminar la Tarea?',
        text: "¡No podra revertir esto!",
        icon: 'warning',
        showCancelButton: true,
        cancelButtonText: '¡No, Cancelar!',
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: '¡Si, Eliminar!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "Home/DeleteTask",
                data: form,
                contentType: false,
                processData: false,
                success: function (data) {
                    Destroy();
                    listado();
                    Swal.fire(
                        '¡Felicidades!',
                        '¡Has eliminado la tarea',
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
            })
        }
    })
}

