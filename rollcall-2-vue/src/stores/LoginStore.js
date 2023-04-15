import { defineStore } from "pinia"

export const useLoginStore = defineStore ('loginStore', {
    state:() =>({
        isLogin: false,
        userName: '',
        fullName: '',
        roles: '',
        token: ''
    }),
    getters:{},
    actions:{
        logIn(userName, roles, token){
            this.isLogin = true
            this.fullName = userName
            this.roles = roles
            this.token = token
        },
        logOut(){
            this.isLogin = false
        }
    }
})