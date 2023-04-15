import { createApp } from 'vue'
import { createPinia } from 'pinia'
import App from './App.vue'
import router from '@/router'
import axios from 'axios'
import { useLoginStore } from './stores/LoginStore'

axios.interceptors.request.use(config =>{
    config.headers['Authorization'] = 'Bearer ' + useLoginStore().token

    return config
})

const pinia = createPinia()

createApp(App)
.use(pinia)
.use(router)
.mount('#app')
