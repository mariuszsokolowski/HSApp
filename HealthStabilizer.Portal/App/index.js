import Vue from "vue";
import VueRouter from "vue-router";
import App from "./App.vue";
import Vuetify from "vuetify";
import "vuetify/dist/vuetify.min.css";
import axios from "axios";
import VueAxios from "vue-axios";
import routes from "./Config/routes";
import Vuex from "vuex";
import state from "./Store/state";
import getters from "./Store/getters";
import mutations from "./Store/mutations";
import actions from "./Store/actions";

Vue.use(require("vue-cookies"));
Vue.use(VueAxios, axios);
Vue.use(Vuex);

Vue.use(VueRouter);
Vue.use(Vuetify);

Vue.config.productionTip = false;
Vue.config.devtools = true;
console.log(actions);
const store = new Vuex.Store({
  state: state,
  getters: getters,
  mutations: mutations,
  actions: actions
});

const router = new VueRouter({
  routes,
  mode: "history"
});
router.beforeEach((to, from, next) => {
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (store.getters.isLoggedIn) {
      next();
      return;
    }
    next("/Login");
  } else {
    next();
  }
});

new Vue({
  vuetify: new Vuetify({
    icons: {
      iconfont: "md" // default - only for display purposes
    }
  }),
  el: "#app",
  render: h => h(App),
  store,
  router
});
