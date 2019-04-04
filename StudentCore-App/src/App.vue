<template>
  <div id="app">
    <Nav />
    <Student />
  </div>
</template>

<script>
import Student from './components/Student/Student.vue';
import Nav from './components/_nav/Nav.vue';

export default {
  components: {
    Student,
    Nav
  }
}
</script>

<style>
/*#app {*/
/*  font-family: 'Avenir', Helvetica, Arial, sans-serif;*/
/*  -webkit-font-smoothing: antialiased;*/
/*  -moz-osx-font-smoothing: grayscale;*/
/*  text-align: center;*/
/*  color: #2c3e50;*/
/*  margin-top: 60px;*/
/*}*/
</style>
