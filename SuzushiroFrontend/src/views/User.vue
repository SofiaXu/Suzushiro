<template>
  <div>
    <img v-bind:src="userAvatar" alt="UserAvatar" />
  </div>
</template>

<script lang="ts">
import { Component, Vue } from "vue-property-decorator";
@Component
export default class User extends Vue {
  private userAvatar = "http://localhost:8080/";
  mounted() {
    fetch("https://localhost:44300/api/Identity/GetUserInformation", {
      method: "GET",
      headers: {
        Authorization: "Bearer " + this.$store.state.userInfo.accessToken,
      },
      mode: "cors",
    })
      .then((response) => {
        if (response.ok) {
          return response.json();
        } else {
          if (response.status == 400) {
            alert("登录失败！请检查用户名或密码");
          } else {
            alert("登录失败！请检查用户名或密码");
          }
        }
      })
      .then((responseJson) => {
        this.userAvatar = responseJson.userAvatar;
      })
      .catch((error) => console.error(error));
  }
}
</script>
