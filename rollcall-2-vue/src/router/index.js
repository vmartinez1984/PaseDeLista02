import { createRouter, createWebHistory } from 'vue-router'
import ListaDePersonas from  '@/components/personas/ListaDePersonas.vue'
import FormularioDePersona from '@/components/personas/FormularioDePersona.vue'
import HelloWorld from '@/components/HelloWorld'

const routes =[
    {
        path: '/',
        name: 'holaMundo',
        component: HelloWorld
    },
    {
        path: '/personas',
        name: 'listaDePersonas',
        component: ListaDePersonas
    },
    {
        path: '/personas/agregar',
        name: 'agregarPersona',
        component: FormularioDePersona
    },
    {
        path: '/personas/editar/:id',
        name: 'editarPersona',
        component: FormularioDePersona
    },
    {
        path: '/personas/borrar/:id',
        name: 'borrarPersona',
        component: FormularioDePersona
    },
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router