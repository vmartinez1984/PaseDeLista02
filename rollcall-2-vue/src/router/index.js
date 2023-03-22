import { createRouter, createWebHistory } from 'vue-router'
import ListaDePersonas from  '@/components/personas/ListaDePersonas.vue'
import FormularioDePersona from '@/components/personas/FormularioDePersona.vue'
import HelloWorld from '@/components/HelloWorld'
import ListUsers from '@/components/users/ListUsers'
import FormUser from '@/components/users/FormUser'
import ListEmployees from '@/components/employees/ListEmployees'
import FormEmployee from '@/components/employees/FormEmployee'
import LoginPage from '@/components/pages/LoginPage'
import { useLoginStore } from '@/stores/LoginStore'

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
        component: ListEmployees,
        meta: { requiresAuth: true}
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
        component: FormEmployee,
    },
    {
        path: '/login',
        name: 'login',
        component: LoginPage
    }
]

const router = createRouter({
    history: createWebHistory(process.env.BASE_URL),
    routes
})
router.beforeEach((to, from, next)=>{
    //console.log(to.meta.requiresAuth)
    //console.log(to)
    //console.log(from)    

    if(to.matched.some(route => route.meta.requiresAuth)){
        var isLogin
    //     var rol
        //console.log("login: ", useLoginStore().isLogin)
        isLogin =  useLoginStore().isLogin
    //    rol = useLoginStore().roles
    //     console.log('userRol ' + rol)
    //     console.log("Esta logueado: " + isLogin)
    //     console.log(to.meta.role.includes(rol))
        
    //     console.log(to.meta.role)
        if(isLogin == true){
    //     //Se verifica si tiene acceso deacuerdo al rol
    //     if(to.meta.role.includes(rol)){
    //         console.log("Permitido")
            next()
        }else{
            console.log("Acceso no permitido")
    //         next('/AccesoNoPermitido')
    //     }
    //     }else{
           next('/login')
        }   
    }else{
       next()
    }
})

export default router