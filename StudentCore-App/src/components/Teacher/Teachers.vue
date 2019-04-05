<template>
    <div>
        <b-container>
            <b-card-group deck>
                <b-card no-body v-for="teacher in teachers">
                    <b-card-body>
                        <b-img fluid src="https://cdn3.vectorstock.com/i/1000x1000/92/77/faceless-businessman-avatar-man-in-suit-with-blue-vector-13569277.jpg"></b-img>
                        <b-link to="/">
                            <h4>{{ teacher.name }}</h4>
                        </b-link>
                        <p class="card-text">
                            <h3>{{ teacher.email }}</h3>
                            <h3>{{ teacher.telephone }}</h3>
                            <h3>{{ teacher.birthday }}</h3>
                        </p>
                    </b-card-body>
                </b-card>
            </b-card-group>
        </b-container>
    </div>
</template>

<script>
    export default {
        name: "Teacher",
        data() {
            return {
                teachers: []
            }
        },
        created() {
            this.$http
                .get('http://localhost:5000/api/teacher')
                .then(res => res.json())
                .then(teachers =>
                    (this.teachers = teachers));
        },
    }
</script>

<style scoped>

</style>
