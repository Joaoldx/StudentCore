<template>
  <div id="app">
    <Student />
  </div>
</template>

<script>
import Student from './components/Student/Student.vue';

export default {
  components: {
    Student
  }
}
</script>

<style>
#app {
  font-family: 'Avenir', Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
