<template>
    <h1 class="mt-4 text-primary">Lista de usuarios</h1>

    <div class="card">
        <div class="card-header">
            <router-link to="/users/create" class="btn btn-secondary">Agregar usuario</router-link>            
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
                <!-- <tr>
                    <th>Nombre</th>
                    <th>Apellidos</th>
                    <th>Fecha de nacimiento</th>
                    <th>Registro</th>
                    <th></th>
                </tr> -->
                </thead>
                <tbody>
                     <tr v-for="user in list" :key="user.id">
                        <td>{{ user.roleName }}</td>
                        <td>{{ user.email }}</td>
                        <td>{{ user.name }}</td>
                        <td>{{ user.lastName }}</td>
                        <td>{{ user.birthday.substring(0,10) }}</td>                        
                        <td>                                               
                            <router-link class="btn btn-danger text-white mx-2" :to="{name:'deleteUser', params:{'id': user.id}}">
                                Borrar
                            </router-link>                        
                            <router-link class="btn btn-warning text-white mx-2" :to="{name:'editUser', params:{'id': user.id}}">
                                Editar
                            </router-link>
                        </td>
                    </tr>
                </tbody>
                </table>
            </template>
        </div>
        <div class="card-footer">           
        </div>
    </div>
</template>

<script setup>
    import { ref, onMounted } from "vue"    
    import usersService from "@/services/UsersService";
    
    var list = ref({})
    var isLoading = ref(true)

    const getAllUsersAsync = async () =>{    
        var data

        isLoading.value = true
        data = await usersService.getAllUsersAsync()
        list.value = data        
        isLoading.value = false        
    }

    onMounted(()=>{        
        getAllUsersAsync()
    })
</script>