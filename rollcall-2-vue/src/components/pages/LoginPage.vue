<template>
    <div class="row justify-content-center">
        <div class="col-lg-8">
            <div class="card shadow-lg border-0 rounded-lg mt-5">
                <div class="card-header">
                    <h3 class="text-center font-weight-light my-4">Inicio de sesión</h3>
                </div>
                <div class="card-body">
                    <form>
                        <div class="form-floating mb-3">
                            <input class="form-control" id="inputEmail" type="email" placeholder="name@example.com" v-model="email" />
                            <label for="inputEmail">Correo</label>
                        </div>
                        <div class="form-floating mb-3">
                            <input class="form-control" id="inputPassword" type="password" placeholder="Password" v-model="password"/>
                            <label for="inputPassword">Contraseña</label>
                        </div>
                        <div class="d-flex align-items-center justify-content-between mt-4 mb-0">
                            <a class="small" href="password.html">¿Olvido su contraseña?</a>
                            <button class="btn btn-primary" @click="logIn" type="button">Iniciar sesión</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
import { useLoginStore } from '@/stores/LoginStore'
import router from '@/router'
import loginService from '@/services/LoginService'
import { ref } from 'vue';

var email = ref('')
var password = ref('')

const logIn = async () => {
    var response = await loginService.loginAsync(email.value, password.value)
    if(response.status == 200){
        useLoginStore().isLogin = true
        useLoginStore().fullName = response.data.fullName
        useLoginStore().roles = response.data.roles
        //console.log("LoginPage, está logeado? " + useLoginStore().isLogin)
        //console.log(router)
        router.push({ name: 'holaMundo' })
        //route.push({name: 'listUsers'})
    }else{
        alert("Credenciales erroneas")
    }
}

// onMounted(() => {
//     console.log("LoginPage->onMounted, está logeado? " + useLoginStore.isLogin)
// })
</script>