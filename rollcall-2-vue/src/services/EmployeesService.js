import axios from "axios"
import baseUrl from "./BaseUrl"
const url = baseUrl.urlApiRollCall + "employees"  

export default{
    async getEmployeesAsync(pagerIn){
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
    },

    async addEmployeeAsync(employee){
        //var response

        await axios.post(url,{
            "person": {
                "name": employee.person.name,
                "lastName": employee.person.lastName,
                "birthday": employee.person.birthday,
                "genere": employee.person.genere
            },
            "number": "",
            "notes": employee.notes
        })

        //console.log(response)
    },

    async getEmployeeByIdAsync(id){
        var response
        var employee

        response  = await axios({
            url: url + '/' + id,
            method: 'GET'           
        })
        switch(response.status){
            case 200:
                employee = response.data
            break;
        }

        return employee
    },

    async deleteEmployeeAsync(id){
        await axios({
            url: url + '/' + id,
            method: 'DELETE'           
        })
    },

    async updateEmployeeAsync(employee){
        await axios.put(
            url + '/' + employee.id,
            {
                "person": {
                    "name": employee.person.name,
                    "lastName": employee.person.lastName,
                    "birthday": employee.person.birthday,
                    "genere": employee.person.genere
                },
                "number": "",
                "notes": employee.notes,
                "personId": employee.personId
            }
        )
    }
}