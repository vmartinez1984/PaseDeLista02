import baseUrl from '@/services/BaseUrl'
const url = baseUrl.urlApiRollCall + "Persons"

export default{    
    async obtenerPersonasAsync(pager){
        var persons
        var urlSearchParams

        urlSearchParams = new URLSearchParams({
            //search : pager.search,
            pageCurrent : pager.pageCurrent,
            RecordsPerPage: pager.recordsPerPage
        })
        await  fetch(url + '?' +urlSearchParams)        
        .then(response => {
            if (response.ok) {
              return response.json();
            } else {
              throw new Error('Error en la solicitud.');
              //console.log(response.text())
              //throw response.text()
            }
        })
        .then(data => {
            //console.log(data)
            persons = data
        })
        .catch(error =>{ throw error})

        return persons
    },
    async setPersonAsync(person){
        //console.log(person)
        var myHeaders = new Headers();
        myHeaders.append("accept", "*/*");
        myHeaders.append("Content-Type", "application/json");
        var raw = JSON.stringify({            
            "name": person.name,
            "lastName": person.lastName,
            "genere": person.genere,
            "birthday": person.birthday,
            "streetAndNumber": person.streetAndNumber,
            "settlement": person.settlement,
            "town": person.town,
            "state": person.state,
            "zipCode": person.zipCode          
        });

        const response = await fetch(url, {
            method: 'POST',
            headers:  myHeaders,
            body: raw
        })

        if(response.ok){
            const data = await response.json();
            //console.log("Data", data)
            return data
        }else if(response.status == 400){            
            const data = await response.json();
            //console.log("Error 400", data)

            throw data
        }else{
            response.json().then((errorJson) => {
                console.log(errorJson.errors); // should return the error json                
                //throw new Error(`HTTP error! status: ${response.status}`);
            }); 
        }

    }
}