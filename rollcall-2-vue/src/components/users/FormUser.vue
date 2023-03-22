<template>

    <h1 class="mt-4" :class="claseDelTitulo">{{titulo}}</h1>
 
    <form @submit.prevent="savePersonAsync">
        <div class="card">
            
            <div class="card-body">
                    <input type="hidden" v-model="user.id"/>
                    
                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Correo</label>
                                <input type="text" class="form-control" :class="{'is-invalid': errors.email.hasError}" placeholder="Correo" v-model="user.email" :disabled="disabled" @keyup="errors.email.hasError = false">
                                <div class="invalid-feedback">
                                    {{errors.email.errorDescription}}
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Contraseña</label>
                                <input type="password" class="form-control" placeholder="Contraseña" v-model="user.password" :disabled="disabled" :class="{'is-invalid': errors.lastName.hasError}" @keyup="errors.lastName.hasError=false">
                                <div class="invalid-feedback">
                                    {{errors.password.errorDescription}}
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Rol</label>
                                <select class="form-select" :class="{'is-invalid': errors.roleId.hasError}" v-model="user.roleId" :disabled="disabled" @keyup="errors.roleId.hasError = false">
                                    <option value="0">Seleccione</option>
                                    <option v-for="role in roles" :key="role.id" :value="role.id">{{ role.name }}</option>
                                </select>
                                <div class="invalid-feedback">
                                    {{errors.roleId.errorDescription}}
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="mb-3"></div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <label for="name" class="form-label">Nombre</label>
                                <input type="text" class="form-control" :class="{'is-invalid': errors.name.hasError}" id="name" placeholder="Nombre" v-model="user.name" :disabled="disabled" @keyup="errors.lastName.hasError=false">                    
                                <div class="invalid-feedback">
                                    {{errors.name.errorDescription}}
                                </div>
                            </div>
                        </div>

                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Apellidos</label>
                                <input type="text" class="form-control" placeholder="Apellidos" v-model="user.lastName" :disabled="disabled" :class="{'is-invalid': errors.lastName.hasError}" @keyup="errors.lastName.hasError=false">
                                <div class="invalid-feedback">
                                    {{errors.lastName.errorDescription}}
                                </div>
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Fecha de nacimiento</label>
                                <input type="date" class="form-control" v-model="user.birthday" :disabled="disabled" :class="{'is-invalid': errors.birthday.hasError}" @keyup="errors.birthday.hasError=false">
                                <div class="invalid-feedback">
                                    {{errors.birthday.errorDescription}}
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Genero</label>
                                <select class="form-select" v-model="user.genere" :disabled="disabled" :class="{'is-invalid': errors.genere.hasError}" @keyup="errors.genere.hasError=false">
                                    <option value="">Seleccione</option>
                                    <option value="Femenino">Femenino</option>
                                    <option value="Masculino">Masculino</option>
                                </select>  
                                <div class="invalid-feedback">
                                    {{errors.genere.errorDescription}}
                                </div>                              
                            </div>
                        </div>
                    </div>
            </div>
            <div class="card-footer">
                <div class="text-end">
                    <template v-if="isDelete">
                        <button class="btn btn-danger" type="button" :disabled="isDeleting" @click="deleteUserAsync()">
                            <span v-if="isDeleting">
                                Un momento
                                <div class="spinner-border spinner-border-sm text-white" role="status">                        
                                </div>
                            </span>
                            <span v-else>
                                Borrar
                            </span>
                        </button>
                        <router-link to="/users" class="btn btn-secondary mx-1" :class="{'disabledlink': isDeleting}">Cancelar</router-link>
                    </template>
                    <template v-else>
                        <button class="btn" :class="claseDelBoton" type="submit" :disabled="disabled">
                            <span v-if="disabled">
                                Un momento
                                <div class="spinner-border spinner-border-sm text-white" role="status"></div>
                            </span>
                            <span v-else>
                                Guardar
                            </span>
                        </button>
                        <router-link to="/users" class="btn btn-secondary mx-1" :class="{'disabledlink': disabled}">Cancelar</router-link>
                    </template>
                </div>
            </div>
        </div>
    </form>

</template>

<script setup>
    import { onMounted, ref } from 'vue'     
    import { useRoute } from 'vue-router'
    import usersService from '@/services/UsersService'
    import rolesService from '@/services/RolesService';

    //variables    
    var titulo = ref('Agregar usuario')  
    var claseDelTitulo = ref('text-primary')
    var claseDelBoton = ref('')
    var user = ref({
        email: '',
        password: '',
        roleId: 0,
        name: '',
        lastName: '',
        birthday: '',
        genere: '',        
        id: 0        
    })
    var disabled = ref(false) 
    var isDelete = ref(false)
    var isDeleting = ref(false)
    var errors = ref({
        hasError: false,
        email: {
            hasError : false,
            errorDescription:''
        },
        password: {
            hasError : false,
            errorDescription:''
        },
        roleId: {
            hasError : false,
            errorDescription:''
        },
        name: {
            hasError : false,
            errorDescription:''
        },
        lastName: {
            hasError : false,
            errorDescription:''
        },
        birthday: {
            hasError : false,
            errorDescription:''
        },
        genere: {
            hasError : false,
            errorDescription:''
        }
    })
    var roles = ref([]);
    var route = useRoute()

    const savePersonAsync = async () => {
        route.push({name: 'listUsers'})
        console.log(user.value)
        if(validateForm()){
            //alert('Hay error')
        }else{
            console.log("Formulario validado")
            if(user.value.id == 0){
                addUserAsync()
            }else{
               console.log("Actualizar")
            }
        }
    }        

    const addUserAsync = async () => {
        try{
            disabled.value = true            
            await usersService.addUserAsync(user.value)

            route.push({name: 'listUsers'})
        }catch(error){
            console.log(error)
        }
        disabled = false
    } 
   
    const getUserId = async ()=>{
        console.log(route.name)  
        if(route.params.id == undefined){
            //console.log("Agregar")
        }else{
            //console.log("editar")
            user.value = await usersService.getUserByIdAsync(route.params.id)     
            user.value.birthday = user.value.birthday.substring(0,10)            
        }

        //Pintar el boton de borrar
        if(route.name == "deleteUser"){
            disabled.value = true
            isDelete.value = true
            titulo.value = '¿Desea borrar?'
            claseDelTitulo.value = 'text-danger'
        }

        //Coloca los letreros y clases css
        if(route.name == "editUser"){            
            titulo.value = 'Editar usuario'
            claseDelTitulo.value = 'text-warning'
            claseDelBoton.value = 'btn-warning text-white'
        }

        if(route.name == "createUser"){
            claseDelBoton.value = 'btn-primary text-white'
        }
    }

    const getAllRolesAsync = async () => {
        var data

        data = await rolesService.getAllRolesAsync()

        roles.value = data
        //console.log(roles.value)
    }

    onMounted(()=>{
       getUserId()
       getAllRolesAsync()
    })

    const validateForm = () =>{
        errors.value.hasError = false
        if(user.value.email.toString().length == 0){
            errors.value.hasError = true
            errors.value.email.hasError = true
            errors.value.email.errorDescription = 'El correo no puede ir vacio'            
        }
        if(user.value.password.toString().length == 0){
            errors.value.hasError = true
            errors.value.password.hasError = true
            errors.value.password.errorDescription = 'La contraseña no puede ir vacio'            
        }
        if(user.value.roleId == 0){
            errors.value.hasError = true
            errors.value.roleId.hasError = true
            errors.value.roleId.errorDescription = 'Elija un rol'
        }
        if(user.value.name.toString().length == 0){
            errors.value.hasError = true
            errors.value.name.hasError = true
            errors.value.name.errorDescription = 'El nombre no puede ir vacio'            
        }
        if(user.value.lastName.toString().length == 0){
            errors.value.hasError = true
            errors.value.lastName.hasError = true
            errors.value.lastName.errorDescription = 'El apellido no puede ir vacio'
        }
        if(user.value.birthday.toString().length == 0){
            errors.value.hasError = true
            errors.value.birthday.hasError = true
            errors.value.birthday.errorDescription = 'Seleccione una fecha de nacimiento'
        }
        if(user.value.genere.toString().length == 0){
            errors.value.hasError = true
            errors.value.genere.hasError = true
            errors.value.genere.errorDescription = 'Seleccione un genero'
        }       
        
        return errors.value.hasError
    }  

    const deleteUserAsync = async () =>{        
        try{
            isDeleting.value = true

            await usersService.deleteUserAsync(user.value.id)

            route.push({name: 'listUsers'})
        }catch(error){
            console.log(error)
        }
        isDeleting.value = false
    }
</script>

<style>
.disabledlink{
    pointer-events: none;
}
</style>