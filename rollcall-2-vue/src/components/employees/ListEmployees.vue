<template>
    <h1 class="mt-4 text-primary">Lista de empleados</h1>

    <div class="card">
        <div class="card-header">
            <router-link to="/employees/create" class="btn btn-secondary">Agregar empleado</router-link>
            <form class="mt-3">                                                
                <div class="input-group">
                    <input class="form-control" type="text" placeholder="Buscar" maxlength="15" v-model="pager.search">
                    <button class="btn btn-primary" id="btnNavbarSearch" type="button" @click="search_click">
                        <svg class="svg-inline--fa fa-magnifying-glass" aria-hidden="true" focusable="false" data-prefix="fas" data-icon="magnifying-glass" role="img" xmlns="http://www.w3.org/2000/svg" viewBox="0 0 512 512" data-fa-i2svg=""><path fill="currentColor" d="M500.3 443.7l-119.7-119.7c27.22-40.41 40.65-90.9 33.46-144.7C401.8 87.79 326.8 13.32 235.2 1.723C99.01-15.51-15.51 99.01 1.724 235.2c11.6 91.64 86.08 166.7 177.6 178.9c53.8 7.189 104.3-6.236 144.7-33.46l119.7 119.7c15.62 15.62 40.95 15.62 56.57 0C515.9 484.7 515.9 459.3 500.3 443.7zM79.1 208c0-70.58 57.42-128 128-128s128 57.42 128 128c0 70.58-57.42 128-128 128S79.1 278.6 79.1 208z"></path></svg><!-- <i class="fas fa-search"></i> Font Awesome fontawesome.com -->
                    </button>
                    </div>
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
                    <th>Registro</th>
                    <th></th>
                </tr>
                </thead>
                <tbody>
                     <tr v-for="employee in pager.list" :key="employee.id">
                        <td>{{ employee.person.name }}</td>
                        <td>{{ employee.person.lastName }}</td>
                        <td>{{ employee.person.birthday.substring(0,10) }}</td>                        
                        <td>                                               
                            
                            <router-link class="btn btn-warning text-white mx-2" :to="{name:'editEmployee', params:{'id': employee.id}}">
                                Editar
                            </router-link>

                            <router-link class="btn btn-danger text-white mx-2" :to="{name:'deleteEmployee', params:{'id': employee.id, 'employee': employee}}">
                                Borrar
                            </router-link>
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
                <div class="row text-info">
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
                <div class="text-center mt-1">
                    <div class="btn-group" role="group" aria-label="Basic example">                
                        <button type="button" class="btn btn-outline-primary" @click="cargarLista(pager.pageCurrent-1)" :disabled="pager.countPage == 1">
                            <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-left" viewBox="0 0 16 16">
                                <path fill-rule="evenodd" d="M15 8a.5.5 0 0 0-.5-.5H2.707l3.147-3.146a.5.5 0 1 0-.708-.708l-4 4a.5.5 0 0 0 0 .708l4 4a.5.5 0 0 0 .708-.708L2.707 8.5H14.5A.5.5 0 0 0 15 8z"/>
                            </svg>
                        </button>
                        <template v-for="pagina in pager.countPage" :key="pagina">
                            <template v-if="pagina == pager.pageCurrent">
                                <button type="button" class="btn btn-primary" @click="getEmployeesAsync_click(pagina)" disabled>{{pagina}}</button>                
                            </template>
                            <template v-else>
                                <button type="button" class="btn btn-primary" @click="getEmployeesAsync_click(pagina)">{{pagina}}</button>
                            </template>
                        </template>
                        <button type="button" class="btn btn-outline-primary" @click="getEmployeesAsync_click(pager.pageCurrent + 1)" :disabled="pager.countPage == 1">
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

    const getEmployeesAsync = async (pagerIn) =>{    
        var data

        isLoading.value = true
        data = await employeesService.getEmployeesAsync(pagerIn)
        list.value = data.list
        pager.value = data
        isLoading.value = false        
    }

    const getEmployeesAsync_click = async (paginaActual) =>{        
        //console.log(paginaActual)
        if(paginaActual == 0){
            paginaActual = pager.value.countPage
        }
        if(paginaActual == (pager.value.countPage + 1)){
            paginaActual = 1
        }            
        pager.value.pageCurrent = paginaActual
        await getEmployeesAsync(pager.value)            
    }

    const search_click = async () =>{
        console.log(pager.value)
        await getEmployeesAsync(pager.value)
    }

    onMounted(()=>{
        pager.value = {
            pageCurrent: 1,
            recordsPerPage: 10            
        }
        getEmployeesAsync(pager)
    })
</script>