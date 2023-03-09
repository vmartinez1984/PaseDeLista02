import axios from "axios"
import baseUrl from "./BaseUrl"
const url = baseUrl.urlApiRollCall + "employees"  

export default{
    async getEmployees(pagerIn){
        var pager
        var response

        response  = await axios({
            url: url,
            method: 'GET',
            params: pagerIn
        })
        switch(response.status){
            case 200:
                pager = response.data
            break;
        }
        return pager
    }
}