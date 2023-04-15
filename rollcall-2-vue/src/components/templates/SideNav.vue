<template>
    <div id="layoutSidenav_nav">
        <nav class="sb-sidenav accordion sb-sidenav-dark" id="sidenavAccordion">

            <menu-administrador v-if="useLoginStore().roles == 'Administrador'"/>

            <menu-operador v-if="useLoginStore().roles == 'Operador'"/>
            
            <div class="sb-sidenav-footer">
                <div class="small">Ha iniciado sesión como: {{ useLoginStore().fullName }}</div>
                {{ useLoginStore().roles }}
            </div>
        </nav>
    </div>
</template>

<script setup>
import { useLoginStore } from '@/stores/LoginStore'
import MenuAdministrador from './MenuAdministrador.vue';
import MenuOperador from '@/components/templates/MenuOperador.vue'
</script>