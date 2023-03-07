<template>

    <h1 class="mt-4" :class="claseDelTitulo">{{titulo}}</h1>
 
    <form @submit.prevent="savePersonAsync">
        <div class="card">
            
            <div class="card-body">
                    <input type="hidden" v-model="person.id"/>
                    <input type="hidden" v-model="person.addressId"/>
                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <label for="name" class="form-label">Nombre</label>
                                <input type="text" class="form-control" :class="{'is-invalid': errors.name.hasError}" id="name" placeholder="Nombre" v-model="person.name" :disabled="disabled" @keyup="cleanError">                    
                                <div class="invalid-feedback">
                                    {{errors.name.errorDescription}}
                                </div>
                            </div>
                        </div>

                        <!-- <div class="col-md-6">
                            <label for="validationServer03" class="form-label">City</label>
                            <input type="text" class="form-control is-invalid" id="validationServer03" aria-describedby="validationServer03Feedback" >
                            <div id="validationServer03Feedback" class="invalid-feedback">
                                Please provide a valid city.
                            </div>
                        </div> -->

                        <!-- <div class="col-md-4">
                            <label for="validationServer01" class="form-label">First name</label>
                            <input type="text" class="form-control is-valid" id="validationServer01" value="Mark" required>
                            <div class="valid-feedback">
                            Looks good!
                            </div>
                        </div> -->
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Apellidos</label>
                                <input type="text" class="form-control" placeholder="Apellidos" v-model="person.lastName" :disabled="disabled" :class="{'is-invalid': errors.lastName.hasError}" @keyup="errors.lastName.hasError=false">
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
                                <input type="date" class="form-control" v-model="person.birthday" :disabled="disabled" :class="{'is-invalid': errors.birthday.hasError}" @keyup="errors.birthday.hasError=false">
                                <div class="invalid-feedback">
                                    {{errors.birthday.errorDescription}}
                                </div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Genero</label>
                                <select class="form-select" v-model="person.genere" :disabled="disabled" :class="{'is-invalid': errors.genere.hasError}" @keyup="errors.genere.hasError=false">
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
                                <label class="form-label">Calle y número</label>
                                <input type="text" class="form-control" placeholder="Calle y número"  v-model="person.streetAndNumber" :disabled="disabled" :class="{'is-invalid': errors.streetAndNumber.hasError}" @keyup="errors.lastName.hasError=false">
                                <div class="invalid-feedback">
                                    {{errors.streetAndNumber.errorDescription}}
                                </div>  
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="mb-3">
                                <label for="lastName" class="form-label">Código postal</label>
                                <input type="text" class="form-control" placeholder="Código postal" maxlength="5" @keyup="buscarCodigoPostal_keyup" v-model="person.zipCode" :disabled="disabled" :class="{'is-invalid': errors.zipCode.hasError}">
                                <div class="invalid-feedback">
                                    {{errors.zipCode.errorDescription}}
                                </div>  
                            </div>
                        </div>
                    </div>          

                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Colonia</label>
                                <select class="form-select" v-model="person.settlement" :disabled="disabled" :class="{'is-invalid': errors.settlement.hasError}">
                                    <template v-if="codigosPostales.length == 1">
                                        <option :value="codigosPostales[0].settlement">{{codigosPostales[0].settlement}}</option>    
                                    </template>
                                    <template v-else>
                                        <option value="">Seleccione</option>
                                        <option :value="codigoPostal.settlement" v-for="codigoPostal in codigosPostales" :key="codigoPostal.id">{{codigoPostal.settlement}}</option>                               
                                    </template>
                                </select> 
                                <div class="invalid-feedback">Seleccione la Colonia</div>  
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="mb-3">                           
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6">
                            <div class="mb-3">
                                <label class="form-label">Alcaldia</label>
                                <input type="text" class="form-control" placeholder="Alcaldia" disabled v-model="person.town" :class="{'is-invalid': errors.town.hasError}">
                                <div class="invalid-feedback">{{errors.town.errorDescription}}</div>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="mb-3">
                                <label for="lastName" class="form-label">Estado</label>
                                <input type="text" class="form-control" placeholder="Estado" disabled v-model="person.state"  :class="{'is-invalid': errors.state.hasError}">
                                <div class="invalid-feedback">{{errors.state.errorDescription}}</div>
                            </div>
                        </div>
                    </div> 
            </div>
            <div class="card-footer">
                <div class="text-end">
                    <template v-if="isDelete">
                        <button class="btn btn-danger" type="button" :disabled="isDeleting" @click="borrarPersona()">
                            <span v-if="isDeleting">
                                Un momento
                                <div class="spinner-border spinner-border-sm text-white" role="status">                        
                                </div>
                            </span>
                            <span v-else>
                                Borrar
                            </span>
                        </button>
                        <router-link to="/personas" class="btn btn-secondary mx-1" :class="{'disabledlink': isDeleting}">Cancelar</router-link>
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
                        <router-link to="/personas" class="btn btn-secondary mx-1" :class="{'disabledlink': disabled}">Cancelar</router-link>
                    </template>
                </div>
            </div>
        </div>
    </form>

</template>

<script setup>
    import { onMounted, ref } from 'vue'
    import codigoPostalService from '@/services/CodigoPostalSevice'    
    import personService from '@/services/PersonasService'
    import { useRoute } from 'vue-router'

    //variables
    var codigosPostales = ref([])  
    var titulo = ref('Agregar persona')  
    var claseDelTitulo = ref('text-primary')
    var claseDelBoton = ref('')
    var person = ref({
        name: '',
        lastName: '',
        birthday: '',
        genere: '',
        streetAndNumber:'',
        zipCode:'',
        settlement: '',
        town: '',
        state: '',
        id: 0,
        addressId: 0
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
        },
        streetAndNumber: {
            hasError : false,
            errorDescription:''
        },
        zipCode: {
            hasError : false,
            errorDescription:''
        },
        settlement:{
            hasError: false
        },
        town:{
            hasError: false
        },
        state:{
            hasError: false
        }
    })
    var route = useRoute()

    const buscarCodigoPostal_keyup = async () => {        
        if(person.value.zipCode.length == 5){
           buscarCodigoPostal(person.value.zipCode)
        }
    }    

    const buscarCodigoPostal = async (codigoPostal) => {
         var lista
            lista = await codigoPostalService.obtenerCodigosPostalesAsyn(codigoPostal)
            codigosPostales.value = []
            lista.forEach(item =>{
                codigosPostales.value.push({
                    alcaldia : item.alcaldia,
                    estado : item.estado,
                    settlement: item.tipoDeAsentamiento + " " + item.asentamiento
                })
            })
            //console.log(codigosPostales.value)
            if(codigosPostales.value.length == 1){
                person.value.settlement = codigosPostales.value[0].settlement
            }
            if(codigosPostales.value.length > 0){
                person.value.town = codigosPostales.value[0].alcaldia
                person.value.state = codigosPostales.value[0].estado
            }
    }
    const savePersonAsync = async () => {
        //console.log(person.value)
        if(validateForm()){
            //alert('Hay error')
        }else{
            console.log("Formulario validado")
            if(person.value.id == 0){
                agregarPersonaAsync()
            }else{
                actualizarPersonaAsync()
            }
        }
    }    

    const agregarPersonaAsync = async ()=>{
        try{
            disabled.value = true
            await personService.setPersonAsync(person.value);
        }catch(error){
            //console.log(error)
            if(error.status == 400){
                setErrors(error.errors)
            }
        }
        disabled.value = false  
    }

    const actualizarPersonaAsync= async ()=>{
        try{
            disabled.value = true
            await personService.actualizarPersona(person.value);
        }catch(error){
            //console.log(error)
            if(error.status == 400){
                setErrors(error.errors)
            }
        }
        disabled.value = false  
    }

    const borrarPersona = async ()=>{
        try{
            isDeleting.value = true
            await personService.actualizarPersona(person.value);
            window.location.href = '/personas'
        }catch(error){
            //console.log(error)
            if(error.status == 400){
                setErrors(error.errors)
            }
        }
        //isDeleting.value = false  
    }

    const validateForm = () =>{
         errors.value.hasError = false
        if(person.value.name.toString().length == 0){
            errors.value.hasError = true
            errors.value.name.hasError = true
            errors.value.name.errorDescription = 'El nombre no puede ir vacio'            
        }
        if(person.value.lastName.toString().length == 0){
            errors.value.hasError = true
            errors.value.lastName.hasError = true
            errors.value.lastName.errorDescription = 'El apellido no puede ir vacio'
        }
        if(person.value.birthday.toString().length == 0){
            errors.value.hasError = true
            errors.value.birthday.hasError = true
            errors.value.birthday.errorDescription = 'Seleccione una fecha de nacimiento'
        }
        if(person.value.genere.toString().length == 0){
            errors.value.hasError = true
            errors.value.genere.hasError = true
            errors.value.genere.errorDescription = 'Seleccione un genero'
        }
        if(person.value.streetAndNumber.toString().length < 5){
            errors.value.hasError = true
            errors.value.streetAndNumber.hasError = true
            errors.value.streetAndNumber.errorDescription = 'Anote la calle y número'
        }
        if(person.value.zipCode.toString().length != 5){
            errors.value.hasError = true
            errors.value.zipCode.hasError = true
            errors.value.zipCode.errorDescription = 'Anote el código postal'
        }
        if(person.value.settlement.toString().length == 0){
            errors.value.hasError = true
            errors.value.settlement.hasError = true            
        }
        if(person.value.town.toString().length == 0){
            errors.value.hasError = true
            errors.value.town.hasError = true            
        }
        if(person.value.state.toString().length == 0){
            errors.value.hasError = true
            errors.value.state.hasError = true            
        }
        
        return errors.value.hasError
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

    const getPersonaId = async ()=>{
        console.log(route.name)  
        if(route.params.id == undefined){
            //console.log("Agregar")
        }else{
            //console.log("editar")
            person.value = await personService.obtenerPersonaAsync(route.params.id)     
            person.value.birthday = person.value.birthday.substring(0,10)
            buscarCodigoPostal(person.value.zipCode)
            //console.log(person.value)      
        }

        //Pintar el boton de borrar
        if(route.name == "borrarPersona"){
            disabled.value = true
            isDelete.value = true
            titulo.value = '¿Desea borrar?'
            claseDelTitulo.value = 'text-danger'
        }

        //Coloca los letreros y clases css
        if(route.name == "editarPersona"){            
            titulo.value = 'Editar persona'
            claseDelTitulo.value = 'text-warning'
            claseDelBoton.value = 'btn-warning text-white'
        }

        if(route.name == "agregarPersona"){
            claseDelBoton.value = 'btn-primary text-white'
        }
    }

    onMounted(()=>{
       getPersonaId()
    })
</script>

<style>
.disabledlink{
    pointer-events: none;
}
</style>