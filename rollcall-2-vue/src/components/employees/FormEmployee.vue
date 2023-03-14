<template>

    <h1 class="mt-4" :class="claseDelTitulo">{{titulo}}</h1>
 
    <form @submit.prevent="saveEmployee">
        <div class="card">
            
            <div class="card-body">
                <input type="hidden" v-model="employee.id"/>
                <input type="hidden" v-model="employee.person.id"/>
                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="name" class="form-label">Nombre</label>
                            <input type="text" class="form-control" :class="{'is-invalid': errors.name.hasError}" id="name" placeholder="Nombre" v-model="employee.person.name" :disabled="disabled" @keyup="cleanError">                    
                            <div class="invalid-feedback">
                                {{errors.name.errorDescription}}
                            </div>
                        </div>
                    </div>

                    <div class="col-6">
                        <div class="mb-3">
                            <label class="form-label">Apellidos</label>
                            <input type="text" class="form-control" placeholder="Apellidos" v-model="employee.person.lastName" :disabled="disabled" :class="{'is-invalid': errors.lastName.hasError}" @keyup="errors.lastName.hasError=false">
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
                            <input type="date" class="form-control" v-model="employee.person.birthday" :disabled="disabled" :class="{'is-invalid': errors.birthday.hasError}" @keyup="errors.birthday.hasError=false">
                            <div class="invalid-feedback">
                                {{errors.birthday.errorDescription}}
                            </div>
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="mb-3">
                            <label class="form-label">Genero</label>
                            <select class="form-select" v-model="employee.person.genere" :disabled="disabled" :class="{'is-invalid': errors.genere.hasError}" @keyup="errors.genere.hasError=false">
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
                
                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="name" class="form-label">Notas</label>
                            <textarea class="form-control" v-model="employee.notes" :disabled="disabled" maxlength="1000">
                            </textarea>                    
                            <div class="invalid-feedback">
                                {{errors.name.errorDescription}}
                            </div>
                        </div>
                    </div>

                    <div class="col-6">
                        <!-- <div class="mb-3">
                            <label class="form-label">Apellidos</label>
                            <input type="text" class="form-control" placeholder="Apellidos" v-model="employee.person.lastName" :disabled="disabled" :class="{'is-invalid': errors.lastName.hasError}" @keyup="errors.lastName.hasError=false">
                            <div class="invalid-feedback">
                                {{errors.lastName.errorDescription}}
                            </div>
                        </div> -->
                    </div>
                </div>
            </div>

            <div class="card-footer">
                <div class="text-end">
                    <template v-if="isDelete">
                        <button class="btn btn-danger" type="button" :disabled="isDeleting" @click="deleteEmployeeAsync_click">
                            <span v-if="isDeleting">
                                Un momento
                                <div class="spinner-border spinner-border-sm text-white" role="status">                        
                                </div>
                            </span>
                            <span v-else>
                                Borrar
                            </span>
                        </button>
                        <router-link to="/employees" class="btn btn-secondary mx-1" :class="{'disabledlink': isDeleting}">Cancelar</router-link>
                    </template>
                    <template v-else>
                        <button class="btn" :class="claseDelBoton" type="submit" :disabled="disabled">
                            <span v-if="disabled">
                                Un momento
                                <div class="spinner-border spinner-border-sm text-white" role="status">                        
                                </div>
                            </span>
                            <span v-else>
                                Guardar
                            </span>
                        </button>
                        <router-link to="/employees" class="btn btn-secondary mx-1" :class="{'disabledlink': disabled}">Cancelar</router-link>
                    </template>
                </div>
            </div>
        </div>
    </form>

</template>

<script setup>
    import router from '@/router';
    import employeesService from '@/services/EmployeesService';
    import { onMounted, ref } from 'vue'    
    import { useRoute } from 'vue-router'    

    //variables    
    var titulo = ref('Agregar empleado')  
    var claseDelTitulo = ref('text-primary')
    var claseDelBoton = ref('')
    var employee = ref({
        person: {
            id: 0,
            name: '',
            lastName: '',
            birthday: '',
            genere: ''        
        },
        id: 0,        
    })
    var disabled = ref(false) 
    var isDelete = ref(false)
    var isDeleting = ref(false)
    var errors = ref({
        hasError: false,
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
    var route = useRoute()   

    const saveEmployee = async () => {
        console.log(employee.value)
        if(validateForm()){
            console('Hay error', errors.value)
        }else{
            console.log("Formulario validado")
            if(employee.value.id == 0){
                addEmployeeAsync()
            }else{
                updateEmployeeAsync()
            }
        }
    }    

    const validateForm = () =>{
         errors.value.hasError = false
        if(employee.value.person.name.toString().length == 0){
            errors.value.hasError = true
            errors.value.name.hasError = true
            errors.value.name.errorDescription = 'El nombre no puede ir vacio'            
        }
        if(employee.value.person.lastName.toString().length == 0){
            errors.value.hasError = true
            errors.value.lastName.hasError = true
            errors.value.lastName.errorDescription = 'El apellido no puede ir vacio'
        }
        if(employee.value.person.birthday.toString().length == 0){
            errors.value.hasError = true
            errors.value.birthday.hasError = true
            errors.value.birthday.errorDescription = 'Seleccione una fecha de nacimiento'
        }
        if(employee.value.person.genere.toString().length == 0){
            errors.value.hasError = true
            errors.value.genere.hasError = true
            errors.value.genere.errorDescription = 'Seleccione un genero'
        }        
        
        //return errors.value.hasError
        return false
    }

    const addEmployeeAsync = async ()=>{
        try{
            disabled.value = true
            await employeesService.addEmployeeAsync(employee.value)
            router.push({name: 'listEmployees'})
        }catch(error){
            console.log(error)
            if(error.status == 400){
                setErrors(error.errors)
            }
        }
        disabled.value = false  
    }

    const updateEmployeeAsync= async ()=>{
        try{
            disabled.value = true
            await employeesService.updateEmployeeAsync(employee.value);           
            router.push({name: 'listEmployees'})
        }catch(error){
            //console.log(error)
            if(error.status == 400){
                setErrors(error.errors)
            }
        }
        disabled.value = false  
    }
    
    const setErrors = (listErrors)=>{
        //console.log(listErrors)
        for(var errorServer in listErrors){
            //console.log(error, errors.value[error])
            for (var error in errors.value){
                //console.log(error)
                //console.log(errorServer, listErrors[errorServer])
                if(error.toString() == errorServer.toLowerCase()){
                    //error.value.hasError = true
                    errors.value[error].hasError = true
                    errors.value[error].errorDescription = listErrors[errorServer][0]
                    //console.log(error, errors.value[error])
                }
            }
        }
    }
    
    const initForm = async ()=>{
        // console.log(route.path)  
        // console.log(route.name)  
        // console.log(route.params)  
        // console.log(route.query)  
        // console.log(route.hash)  
        // console.log(route.fullPath)  
        // console.log(route.matched)  
        // console.log(route.meta)  
        // console.log(route.redirectedFrom)  
        switch(route.name){
            case "createEmployee":
                claseDelBoton.value = 'btn-primary text-white'
                break
                case "editEmployee":
                    titulo.value = 'Editar empleado'
                claseDelTitulo.value = 'text-warning'
                claseDelBoton.value = 'btn-warning text-white'
                disabled.value = true
                employee.value = await employeesService.getEmployeeByIdAsync(route.params.id)
                disabled.value = false
                //console.log(employee.value)
                employee.value.person.birthday = employee.value.person.birthday.substring(0,10)            
                break
                case 'deleteEmployee':
                    disabled.value = true
                    isDelete.value = true
                    titulo.value = '¿Desea borrar?'
                    claseDelTitulo.value = 'text-danger'
                    isDeleting.value = true
                    employee.value = await employeesService.getEmployeeByIdAsync(route.params.id)
                    console.log(employee.value)
                    employee.value.person.birthday = employee.value.person.birthday.substring(0,10)
                    isDeleting.value = false
                    break
                }      
    }
            
    const deleteEmployeeAsync_click = async()=>{
        try{
            isDeleting.value = true
            await employeesService.deleteEmployeeAsync(employee.value.id)            
            router.push({name: 'listEmployees'})
        }catch(error){
            if(error.response.status == 500){
                alert("Ocurrio un error en el servidor")
            }
        }
        isDeleting.value = false
    }

    onMounted(()=>{
        initForm()
    })
</script>

<style>
.disabledlink{
    pointer-events: none;
}
</style>