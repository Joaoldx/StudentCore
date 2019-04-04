<template>
    <div>
        <b-container>
            <b-card-group deck>
                <b-card no-body v-for="student in students">
                    <b-card-body>
                        <b-img fluid src="https://cdn3.vectorstock.com/i/1000x1000/92/77/faceless-businessman-avatar-man-in-suit-with-blue-vector-13569277.jpg"></b-img>
                        <b-link to="/">
                            <h4>{{ student.name }}</h4>
                        </b-link>

                        <p class="card-text">
                            {{ student.email }}
                        <h4>{{ student.telephone }}</h4>
                        <h4>{{ student.birthday }}</h4>
                        </p>
                    </b-card-body>
                </b-card>
            </b-card-group>
        </b-container>
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
    .smallImg{
        width: 100px;
    }
</style>
