import { createRouter, createWebHistory } from 'vue-router'
import ListaDePersonas from  '@/components/personas/ListaDePersonas.vue'
import FormularioDePersona from '@/components/personas/FormularioDePersona.vue'
import HelloWorld from '@/components/HelloWorld'
import ListUsers from '@/components/users/ListUsers'
import FormUser from '@/components/users/FormUser'
import ListEmployees from '@/components/employees/ListEmployees'
import FormEmployee from '@/components/employees/FormEmployee'

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
    {
        path: '/users',
        name: 'listUsers',
        component: ListUsers
    },
    {
        path: '/users/create',
        name: 'createUser',
        component: FormUser
    },
    {
        path: '/users/edit/:id',
        name: 'editUser',
        component: FormUser
    },
    {
        path: '/users/delete/:id',
        name: 'deleteUser',
        component: FormUser
    },
    {
        path: '/employees',
        name: 'listEmployees',
        component: ListEmployees
    },
    {
        path: '/employees/create',
        name: 'createEmployee',
        component: FormEmployee
    },
    {
        path: '/employees/edit/:id',
        name: 'editEmployee',
        component: FormEmployee
    },
    {
        path: '/employees/delete/:id',
        name: 'deleteEmployee',
        component: FormEmployee
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})

export default router