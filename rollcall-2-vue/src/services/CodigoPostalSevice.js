import baseUrl from "./BaseUrl"
import axios from 'axios'

const url = baseUrl.urlCodigosPostales +'CodigosPostales/'

export default{
    async obtenerCodigosPostalesAsyn(codigoPostal){
        var codigosPostales
        var response

        response = await axios.get(url + codigoPostal)
        // console.log(response)
        // if(!response.ok){
        //     response.json().then((errorJson) => {
        //         console.log(errorJson.errors); // should return the error json
        //     }); 
        //     console.log(response.text())
        //     throw new Error(`HTTP error! status: ${response.status}`);
        // }
        codigosPostales = response.data

        return codigosPostales
    }
}