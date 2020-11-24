import Vue from 'vue';
import App from './App.vue';
import router from "@/router/index.ts"
import store from './store';
import UserInfo from './models/UserInfo';

Vue.config.productionTip = true;

if (localStorage.getItem("Suzushiro.UserInfo")) {
    store.state.userInfo = JSON.parse(localStorage.getItem("Suzushiro.UserInfo") || JSON.stringify(new UserInfo()));
}

router.beforeEach((to, from, next) => {
    if (to.meta.title) {
        document.title = to.meta.title;
    }
    if (to.matched.some(r => r.meta.requireAuth)) {
        if (store.state.userInfo.isLogIn) {
            next();
        } else {
            next({
                path: "/login",
                query: { redirect: to.fullPath }
            });
        }
    } else {
        next();
    }
});

new Vue({
    router,
    store,
    render: h => h(App)
}).$mount('#app');
