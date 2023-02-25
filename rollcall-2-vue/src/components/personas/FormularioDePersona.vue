<template>
    <h1 class="mt-4">Agregar persona</h1>
    <form @submit.prevent="savePersonAsync">
    <div class="card">
        <div class="card-body">
                <input type="hidden" v-model="person.id"/>
                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="name" class="form-label">Nombre</label>
                            <input type="text" class="form-control" id="name" placeholder="Nombre" v-model="person.name" :disabled="disabled">                    
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="lastName" class="form-label">Apellidos</label>
                            <input type="text" class="form-control" id="lastName" placeholder="Apellidos" v-model="person.lastName" :disabled="disabled">
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="birthday" class="form-label">Fecha de nacimiento</label>
                            <input type="date" class="form-control" id="birthday" v-model="person.birthday" :disabled="disabled">                    
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="mb-3">
                            <label class="form-label">Genero</label>
                            <select class="form-select" v-model="person.genere" :disabled="disabled">
                                <option value="">Seleccione</option>
                                <option value="Femenino">Femenino</option>
                                <option value="Masculino">Masculino</option>
                            </select>                                 
                        </div>
                    </div>
                </div>

                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <label class="form-label">Calle y número</label>
                            <input type="text" class="form-control" placeholder="Calle y número"  v-model="person.streetAndNumber" :disabled="disabled">
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="lastName" class="form-label">Código postal</label>
                            <input type="text" class="form-control" placeholder="Código postal" maxlength="5" @keyup="buscarCodigoPostal" v-model="person.zipCode" :disabled="disabled">
                        </div>
                    </div>
                </div>          

                <div class="row">
                    <div class="col-6">
                        <div class="mb-3">
                            <label class="form-label">Colonia</label>
                             <select class="form-select" v-model="person.settlement" :disabled="disabled">
                                <template v-if="codigosPostales.length == 1">
                                    <option :value="codigosPostales[0].settlement">{{codigosPostales[0].settlement}}</option>    
                                </template>
                                <template v-else>
                                    <option value="">Seleccione</option>
                                    <option :value="codigoPostal.settlement" v-for="codigoPostal in codigosPostales" :key="codigoPostal.id">{{codigoPostal.settlement}}</option>                               
                                </template>
                            </select> 
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
                            <input type="text" class="form-control" placeholder="Alcaldia" disabled v-model="person.town">
                        </div>
                    </div>
                    <div class="col-6">
                        <div class="mb-3">
                            <label for="lastName" class="form-label">Estado</label>
                            <input type="text" class="form-control" placeholder="Estado" disabled v-model="person.state">
                        </div>
                    </div>
                </div> 
        </div>
        <div class="card-footer">
            <div class="text-end">
            <button class="btn btn-primary" type="submit" :disabled="disabled">
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
            </div>
        </div>
    </div>
    </form>

</template>

<script setup>
    import { ref } from 'vue'
    import codigoPostalService from '@/services/CodigoPostalSevice'    
    import personService from '@/services/PersonasService'

    //variables
    var codigosPostales = ref([])
    //var codigoPostal = ref('')
    var person = ref({
        zipCode:'',
        genere: '',
        settlement: '',
        id: 0
    })
    var disabled = ref(false)   

    const buscarCodigoPostal = async () => {        
        if(person.value.zipCode.length == 5){
            var lista
            lista = await codigoPostalService.obtenerCodigosPostalesAsyn(person.value.zipCode)
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
    }    

    const savePersonAsync = async () => {
        console.log(person.value)
        if(person.value.id == 0){
            disabled.value = true
            personService.setPersonAsync(person.value);
            disabled.value = false            
        }
    }    
</script>

<style>
.disabledlink{
    pointer-events: none;
}
</style>