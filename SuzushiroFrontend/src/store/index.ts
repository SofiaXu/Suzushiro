import UserInfo from '@/models/UserInfo';
import Vue from "vue";
import Vuex from "vuex"

Vue.use(Vuex);

interface RootState {
    userInfo: UserInfo;
}

export default new Vuex.Store<RootState>({
    state: {
        userInfo: new UserInfo()
    },
    mutations: {
        setUserInfo(state, userInfo: UserInfo) {
            state.userInfo = userInfo;
            if (localStorage.getItem("Suzushiro.UserInfo") == null) {
                localStorage.removeItem("Suzushiro.UserInfo");
            }
            localStorage.setItem("Suzushiro.UserInfo", JSON.stringify(state.userInfo));
        },
        removeUserInfo(state) {
            state.userInfo = new UserInfo();
            if (localStorage.getItem("Suzushiro.UserInfo")) {
                localStorage.removeItem("Suzushiro.UserInfo");
            }
        }
    }
});