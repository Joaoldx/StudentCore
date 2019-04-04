<template>
    <div>
        <b-container>
            <b-nav justified tabs>
                <b-nav-item active>Home</b-nav-item>
                <b-nav-item>Alunos</b-nav-item>
                <b-nav-item>Professores</b-nav-item>
                <b-nav-item >Grupos</b-nav-item>
                <b-nav-item-dropdown
                        id="my-nav-dropdown"
                        text="Login"
                        extra-toggle-classes="nav-link-custom"
                        right        >
                    <b-dropdown-item>Opções</b-dropdown-item>
                    <b-dropdown-divider></b-dropdown-divider>
                    <b-dropdown-item>Sair</b-dropdown-item>
                </b-nav-item-dropdown>
            </b-nav>
        </b-container>
    </div>
</template>

<script>
    export default {
        name: "Nav"
    }
</script>

<style scoped>

</style>
