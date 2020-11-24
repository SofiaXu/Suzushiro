<template>
  <main class="form-signin">
    <form v-on:submit.prevent="onFormSubmit">
      <h1 class="h3 mb-3 fw-normal">Suzushiro</h1>
      <h1 class="h3 mb-3 fw-normal">Please sign in</h1>
      <label for="inputEmail" class="visually-hidden">username</label>
      <input
        v-model="username"
        type="text"
        class="form-control"
        placeholder="Username"
        required
        autofocus
      />
      <label for="inputPassword" class="visually-hidden">Password</label>
      <input
        v-model="password"
        type="password"
        class="form-control"
        placeholder="Password"
        required
      />
      <button class="btn btn-lg btn-primary btn-block" type="submit">
        Sign in
      </button>
    </form>
  </main>
</template>

<script lang="ts">
import UserInfo from "@/models/UserInfo";
import { Component, Vue } from "vue-property-decorator";
import { Mutation } from "vuex-class";

@Component
export default class SignIn extends Vue {
  private username = "";
  private password = "";

  @Mutation("setUserInfo")
  private setUserInfo!: Function;

  private onFormSubmit() {
    const object = {
      username: this.username,
      password: this.password,
    };
    const json = JSON.stringify(object);
    fetch("https://localhost:44300/api/Identity/SignIn", {
      method: "POST",
      headers: {
        "Content-Type": "application/json",
        Accept: "application/json",
      },
      body: json,
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
        const userInfo: UserInfo = new UserInfo();
        userInfo.username = responseJson.username;
        userInfo.isLogIn = true;
        userInfo.accessToken = responseJson.token;
        this.setUserInfo(userInfo);
        this.$router.push({ path: "/" });
      })
      .catch((error) => console.error(error));
  }
}
</script>

<style scoped>
.form-signin {
  width: 100%;
  max-width: 330px;
  padding: 15px;
  margin: auto;
  height: 100%;
  display: flex;
  align-items: center;
  text-align: center;
}
.form-signin .checkbox {
  font-weight: 400;
}
.form-signin .form-control {
  position: relative;
  box-sizing: border-box;
  height: auto;
  padding: 10px;
  font-size: 16px;
}
.form-signin .form-control:focus {
  z-index: 2;
}
.form-signin input[type="text"] {
  margin-bottom: -1px;
  border-bottom-right-radius: 0;
  border-bottom-left-radius: 0;
}
.form-signin input[type="password"] {
  margin-bottom: 10px;
  border-top-left-radius: 0;
  border-top-right-radius: 0;
}
</style>