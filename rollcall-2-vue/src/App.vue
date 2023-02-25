<template>
  <nav-bar/>
  <div id="layoutSidenav">
    <side-nav/>        
    <div id="layoutSidenav_content">
      <main>        
        <div class="container-fluid px-4">
          <!-- <h1 class="mt-4">Dashboard</h1>
          <ol class="breadcrumb mb-4">
              <li class="breadcrumb-item active">Dashboard</li>
          </ol> -->

          <!-- <img alt="Vue logo" src="./assets/logo.png">
          <HelloWorld msg="Welcome to Your Vue.js App"/>               -->
          <router-view/>
        </div>
      </main>
      <footer-bar/>
    </div>
  </div>
</template>

<script>
//import HelloWorld from './components/HelloWorld.vue'
import NavBar from '@/components/templates/NavBar.vue'
import SideNav from '@/components/templates/SideNav.vue'
import FooterBar from '@/components/templates/FooterBar.vue'

export default {
  name: 'App',
  components: {
   // HelloWorld,
    NavBar,
    SideNav,
    FooterBar
  }
}
</script>