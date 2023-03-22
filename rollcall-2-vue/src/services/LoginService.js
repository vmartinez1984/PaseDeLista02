import axios from "axios"
import baseUrl from '@/services/BaseUrl'

const url = baseUrl.urlApiRollCall + "Login"

export default{
    async loginAsync(email, password){
        var response

        response  = await axios({
            url: url,
            method: 'POST',
            data: {
                "email": email,
                "password": password
            }
        })

        return response
    }
}