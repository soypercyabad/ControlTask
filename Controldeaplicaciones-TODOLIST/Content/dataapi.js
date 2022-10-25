//$(document).ready(function () {
//    llenarcard();
//})

//function llenarcard() {
//    $.ajax({
//        type: "POST",
//        url: "API/Listtask",
//        dataType: "json",
//        success: function (data) {
//            var datos = JSON.parse(data);
//            $.each(datos, function (key, valor) {
//                var contenido =
//                    "<div class=\"col-md-4\">" +
//                    "<div class=\"card active p-3 mb-2\">" +
//                    "<div class=\"d-flex justify-content-between\">" +
//                    "<div class=\"d-flex flex-row align-items-center\">" +
//                    "<div class=\"icon\"> <i class=\"fa-solid fa-calendar-xmark\"></i> </div>" +
//                    "<div class=\"ms-2 c-details\">" +
//                    "<h6 class=\"mb-0\"></h6>" + data.Nombre + "<span>" + data.Nota + "</span>" +
//                    "</div>" +
//                    "</div>" +
//                    "<div class=\"badge-alta\"> <span>Alta</span> </div>" +
//                    "</div>" +
//                    "<div class=\"mt-5\">" +
//                    "<h4 class=\"heading\"></h4>" +
//                    "<div class=\"mt-3\"> <span class=\"text1\">Finalizado el <span class=\"text2\">23-10-2022 21:04:00</span></span> </div>" +
//                    "<div class=\"mt-5\">" +
//                    "<div class=\"action\">" +
//                    "<div> <i class=\"fa-solid fa-trash delete \"></i> &nbsp; <i class=\"fa-solid fa-arrows-rotate update\"></i> </div>" +
//                    "</div>" +
//                    "</div>" +
//                    "</div>" +
//                    "</div>";
//                $("#cardbody").append(contenido);
//            });

//        },
//        error: function (error) {
//            Swal.fire({
//                icon: 'error',
//                title: 'Oops!',
//                text: 'Se producido un error de tipo: ' + error,
//            })
//        }
//    })
//}


listado();

//Metodo para Cargar la lista al ejecutar el documento
function listado() {
    $.get("API/Listtask", function (data) {
        CrearListado(data);
    });
}

//Metodo para Listar Datos
function CrearListado(data) {
    var datos = JSON.parse(data);
    for (var i = 0; i < datos.length; i++) {
        var contenido = "";
        contenido += "<div class=\"col-md-4\">";
        if (datos[i].Estado == 1) {
            contenido += "<div class=\"card desactive p-3 mb-2\">";
        } else {
            contenido += "<div class=\"card active p-3 mb-2\">";
        } 
        contenido += "<div class=\"d-flex justify-content-between\">";
        contenido += "<div class=\"d-flex flex-row align-items-center\">";
        if (datos[i].Estado == 1) {
            contenido += "<div class=\"icon\"> <i class=\"fa-solid fa-calendar-check\"></i> </div>";
        } else {
            contenido += "<div class=\"icon\"> <i class=\"fa-solid fa-calendar-xmark\"></i> </div>";
        }
        contenido += "<div class=\"ms-2 c-details\">";
        contenido += "<h6 class=\"mb-0\"></h6>" + datos[i].Nombre + "</br> <span>" + moment(datos[i].Fechacre).format('DD-MM-YYYY HH:mm:ss') + "</span>";
        contenido += "</div>";
        contenido += "</div>";
        if (datos[i].Prioridad == "Alta") {
            contenido += "<div class=\"badge-alta\"> <span>" + datos[i].Prioridad + "</span> </div>";
        } else if (datos[i].Prioridad == "Media") {
            contenido += "<div class=\"badge-media\"> <span>" + datos[i].Prioridad + "</span> </div>";
        } else if (datos[i].Prioridad == "Baja") {
            contenido += "<div class=\"badge-baja\"> <span>" + datos[i].Prioridad + "</span> </div>";
        } 
        
        contenido += "</div>";
        contenido += "<div class=\"mt-5\">";
        contenido += "<h4 class=\"heading\">" + datos[i].Nota + "</h4>";
        if (datos[i].Fechacre > datos[i].Fechater) {
            contenido += "<div class=\"mt-3\"> <span class=\"text1\"> ╠ Tarea Pendiente ╣ <span class=\"text2\"> </span></span> </div>";
        } else {
            contenido += "<div class=\"mt-3\"> <span class=\"text1\">Finalizado el <span class=\"text2\">" + moment(datos[i].Fechater).format('DD-MM-YYYY HH:mm:ss') + "</span></span> </div>";

        }
        contenido += "<div class=\"mt-5\">";
        contenido += "<div class=\"action\">";
        contenido += "<div> <i class=\"fa-solid fa-trash delete \"></i> &nbsp; <i class=\"fa-solid fa-arrows-rotate update\"></i> </div>";
        contenido += "</div>";
        contenido += "</div>";
        contenido += "</div>";
        contenido += "<div>";
        $("#cardbody").append(contenido);
    }

}