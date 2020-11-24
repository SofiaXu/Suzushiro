import Vue from "vue";
import VueRouter, { RouteConfig } from "vue-router";
import SignIn from "@/views/SignIn.vue";
import Home from "@/views/Home.vue"
import User from "@/views/User.vue"

Vue.use(VueRouter);

const routes: RouteConfig[] = [
    {
        path: "/",
        name: "Home",
        component: Home,
        meta: {
            requireAuth: true
        },
        children: [
            {
                path: "/User",
                name: "User",
                component: User,
                meta: {
                    requireAuth: true
                }
            }
        ]
    },
    {
        path: "/SignIn",
        name: "SignIn",
        component: SignIn
    },{path: '*',redirect: '/'}
];

export default new VueRouter({
    routes,
    mode: 'history',
    base: process.env.BASE_URL,
});