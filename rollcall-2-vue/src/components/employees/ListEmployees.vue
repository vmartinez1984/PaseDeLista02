<template>
    <h1 class="mt-4 text-primary">Lista de empleados</h1>

    <div class="card">
        <div class="card-header">
            <router-link to="/personas/agregar" class="btn btn-secondary">Agregar empleado</router-link>
            <form>
                <label>Buscar</label>
                <input class="form-control" type="text" />
                <button class="btn btn-primary">
                    Buscar
                </button>
            </form>
        </div>
        <div class="card-body">
            <template v-if="isLoading">
                <div class="d-flex justify-content-center">
                    <div class="spinner-border text-primary" role="status">
                        <span class="visually-hidden">Loading...</span>
                    </div>
                </div>
            </template>
            <template v-else>
                <table class="table table-hover">
                <thead>
                <tr>
                    <th>Nombre</th>
                    <th>Apellidos</th>
                    <th>Fecha de nacimiento</th>
                    <!-- <th>Registro</th> -->
                    <th></th>
                </tr>
                </thead>
                <tbody>
                     <tr v-for="employee in pager.list" :key="employee.id">
                        <td>{{ employee.person.name }}</td>
                        <td>{{ employee.person.lastName }}</td>
                        <td>{{ employee.person.birthday.substring(0,10) }}</td>
                        <!-- <td>{{ person.dateRegistration.substring(0,10) }}</td> -->
                        <td>                                               
                            <!-- <router-link class="btn btn-danger text-white mx-2" :to="{name:'deleteEmployee', params:{'id': employee.id}}">
                                Borrar
                            </router-link>                        
                            <router-link class="btn btn-warning text-white mx-2" :to="{name:'editEmployee', params:{'id': employee.id}}">
                                Editar
                            </router-link> -->
                        </td>
                    </tr>
                </tbody>
                </table>
            </template>
        </div>
        <div class="card-footer">
            <div v-if="isLoading">
                <span class="text-info">Cargando...</span>
            </div>
            <div v-else>
                <div class="row">
                    <div class="col">
                        Total de registros: {{pager.totalRecords}}                        
                    </div>
                    <div class="col">                        
                        Total de registros filtrados: {{pager.totalRecordsFiltered}}
                    </div>
                    <div class="col">
                        Página {{pager.pageCurrent}} de {{pager.countPage}}
                    </div>                    
                </div>
                <div class="text-center">
                    <div class="btn-group" role="group" aria-label="Basic example">                
                        <button type="button" class="btn btn-outline-primary" @click="cargarLista(pager.pageCurrent-1)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-left" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z"/>
                            </svg>
                        </button>
                        <template v-for="pagina in pager.countPage" :key="pagina">
                            <template v-if="pagina == pager.pageCurrent">
                                <button type="button" class="btn btn-primary" @click="cargarLista(pagina)" disabled>{{pagina}}</button>                
                            </template>
                            <template v-else>
                                <button type="button" class="btn btn-primary" @click="cargarLista(pagina)">{{pagina}}</button>
                            </template>
                        </template>
                        <button type="button" class="btn btn-outline-primary" @click="cargarLista(pager.pageCurrent + 1)">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-right" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M1 8a.5.5 0 0 1 .5-.5h11.793l-3.147-3.146a.5.5 0 0 1 .708-.708l4 4a.5.5 0 0 1 0 .708l-4 4a.5.5 0 0 1-.708-.708L13.293 8.5H1.5A.5.5 0 0 1 1 8z"/>
                            </svg>
                        </button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script setup>
    import { ref, onMounted } from "vue"    
    import employeesService from "@/services/EmployeesService";

    var pager = ref({})
    var list = ref({})
    var isLoading = ref(true)

    const getEmployees = async (pagerIn) =>{    
        var data

        isLoading.value = true
        data = await employeesService.getEmployees(pagerIn)
        list.value = data.list
        pager.value = data
        isLoading.value = false        
    }

    const cargarLista = async (paginaActual) =>{        
        //console.log(paginaActual)
        if(paginaActual == 0){
            paginaActual = pager.value.countPage
        }
        if(paginaActual == (pager.value.countPage + 1)){
            paginaActual = 1
        }            
        pager.value.pageCurrent = paginaActual
        await getEmployees(pager.value)            
    }

    onMounted(()=>{
        var pager

        pager ={
            pageCurrent: 1,
            recordsPerPage: 10            
        }
        getEmployees(pager)
    })
</script>