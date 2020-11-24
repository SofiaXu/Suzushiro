<template>
    <div>
        <header class="navbar navbar-dark sticky-top bg-dark flex-md-nowrap p-0 shadow">
            <a class="navbar-brand col-md-3 col-lg-2 mr-0 px-3" href="#">Suzushiro</a>
            <ul class="navbar-nav px-3">
                <li class="nav-item text-nowrap">
                    <router-link class="nav-link" to="/user">{{ username }}</router-link>
                </li>
            </ul>
        </header>
        <div class="container-fluid">
            <div class="row">
                <router-view class="col-md-9 ml-sm-auto col-lg-10 px-md-4"></router-view>
            </div>
        </div>
    </div>
</template>

<script lang="ts">
    import { Component, Vue } from "vue-property-decorator";
    @Component
    export default class Home extends Vue {

        get username(): string {
            return this.$store.state.userInfo.username;
        }
    }
</script>

<style scoped>
</style>