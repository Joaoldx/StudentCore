<template>
  <div class="hello">
    <ul v-for="(student, index) in students" :key="index">
      <li>{{student.name}}</li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      students: []
    }
  },
  created() {
    this.$http
      .get('http://localhost:5000/api/student')
      .then(res => res.json())
      .then(students =>
        (this.students = students));
  },
  methods: {
    // getAllStudents: function () {
    //
    // }
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h3 {
  margin: 40px 0 0;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
</style>
