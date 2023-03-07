import baseUrl from '@/services/BaseUrl'
const url = baseUrl.urlApiRollCall + "Users"

export default{    
  async getAllUsersAsync(){
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
  },

  async getUserByIdAsync(userId){
      var user
      
      await  fetch(url + '/' + userId)
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
          user = data
      })
      .catch(error =>{ throw error})

      return user
  },  

  async addUserAsync(user){
    var myHeaders = new Headers();
    myHeaders.append("accept", "*/*");
    myHeaders.append("Content-Type", "application/json");
    var raw = JSON.stringify({            
      "email": user.email,
      "password": user.password,
      "roleId": user.roleId,              
      "name": user.name,
      "lastName": user.lastName,
      "genere": user.genere,
      "birthday": user.birthday
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
  },

  async deleteUserAsync(userId){
    const response = await fetch(url + "/" + userId, {
      method: 'DELETE'                 
    })

    if(response.ok){
      var data;
      
      data =  await response.json()

      console.log("Data", data)      
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