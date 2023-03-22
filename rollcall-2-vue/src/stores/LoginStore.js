import { defineStore } from "pinia"

export const useLoginStore = defineStore ('loginStore', {
    state:() =>({
        isLogin: false,
        userName: '',
        fullName: '',
        roles: ''
    }),
    getters:{},
    actions:{
        logIn(userName, roles){
            this.isLogin = true
            this.userName = userName
            this.roles = roles
        },
        logOut(){
            this.isLogin = false
        }
    }
})