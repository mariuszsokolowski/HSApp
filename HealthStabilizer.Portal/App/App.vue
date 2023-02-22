<template>
  <v-app>
    <Nav></Nav>
    <div class="container">
      <router-view></router-view>
    </div>
  </v-app>
</template>
<script>
import Nav from "./Nav.vue";
import axios from "axios";
export default {
  components: {
    Nav: Nav
  },
  created() {
    if (this.$store.getters.isLoggedIn)
      axios.defaults.headers.common["Authorization"] =
        "bearer " + this.$store.getters.getAuthToken;
  }
};
</script>

<style lang="scss">
</style>