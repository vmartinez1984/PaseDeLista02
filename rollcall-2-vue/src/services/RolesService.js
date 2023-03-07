import baseUrl from '@/services/BaseUrl'
const url = baseUrl.urlApiRollCall + "Roles"

export default{    
  async getAllRolesAsync(){
      var list        
      await  fetch(url)        
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
          list = data
      })
      .catch(error =>{ throw error})

      return list
  } 
}