
function muestraReloj() {
    var fechaHora = new Date();
    var horas = fechaHora.getHours();
    var minutos = fechaHora.getMinutes();
    var segundos = fechaHora.getSeconds();
    var dias = fechaHora.getDate();
    var meses = (fechaHora.getMonth()) + 1;
    var anos = fechaHora.getFullYear();

    if (horas < 10) { horas = '0' + horas; }
    if (minutos < 10) { minutos = '0' + minutos; }
    if (segundos < 10) { segundos = '0' + segundos; }
    if (dias < 10) { dias = '0' + dias; }
    if (meses < 10) { meses = '0' + meses; }

    document.getElementById("relojadd").innerHTML = dias + '-' + meses + '-' + anos + ' ' + horas + ':' + minutos + ':' + segundos;
}

window.onload = function () {
    setInterval(muestraReloj, 1000);
}