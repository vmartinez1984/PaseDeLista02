function buscarCodigoPostal() {
    var codigoPostal
    const url = "http://127.0.0.1:8080/codigosPostales/api/v2/index.php/CodigosPostales/"

    codigoPostal = document.getElementById('ZipCode').value
    console.log(codigoPostal)
    if (codigoPostal.length == 5) {
        fetch(url + codigoPostal)
            .then(response => response.json())
            .then(data => {
                console.log(data)
                codigoPostal = data[0]
                document.getElementById('Town').value = codigoPostal.alcaldia
                document.getElementById('TownAux').value = codigoPostal.alcaldia
                document.getElementById('State').value = codigoPostal.estado
                document.getElementById('StateAux').value = codigoPostal.estado
                llenarSelectDeColonia(data)
            })
    }
}

function llenarSelectDeColonia(codigosPostales) {
    //limpiamos la opciones del select
    document.getElementById('Settlement').innerHTML = ''

    if (codigosPostales.length == 1) {
        //si solo tiene una opción la damos por seleccionada
        var option

        option = document.createElement('option')
        option.value = codigosPostales[0].tipoDeAsentamiento + ' ' + codigosPostales[0].asentamiento
        option.text = codigosPostales[0].tipoDeAsentamiento + ' ' + codigosPostales[0].asentamiento
        document.getElementById('Settlement').appendChild(option)
    } else {
        // colocamos las opciones
        var select
        var option

        option = document.createElement('option')
        option.value = ''
        option.text = 'Seleccione la colonia'
        select = document.getElementById('Settlement').appendChild(option)
        codigosPostales.forEach(item => {
            var option

            option = document.createElement('option')
            option.value = item.tipoDeAsentamiento + ' ' + item.asentamiento
            option.text = item.tipoDeAsentamiento + ' ' + item.asentamiento

            select = document.getElementById('Settlement').appendChild(option)
        })
    }
}