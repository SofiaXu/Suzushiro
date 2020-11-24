<template>
	<div id="app">
		<router-view></router-view>
	</div>
</template>

<script lang="ts">
import { Component, Vue } from 'vue-property-decorator';
@Component
export default class App extends Vue {

}
</script>

<style>
@import url("../node_modules/bootstrap/dist/css/bootstrap.min.css");
</style>
