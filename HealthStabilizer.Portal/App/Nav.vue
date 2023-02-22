<template>
  <div>
    <v-app-bar color="orange" dark>
      <div>
        <p text-center @click="$router.push('/')">
          <v-icon>home</v-icon>Health Stabilizer
        </p>
      </div>
      <div class="flex-grow-1"></div>
      <v-toolbar-items>
        <router-link to="/Account" v-if="isLoggedIn">
          <v-btn text>
            Me
            <v-icon>person</v-icon>
          </v-btn>
        </router-link>

        <router-link :to="isLoggedIn ? '/Logout' : '/Login'">
          <v-btn text>
            <span>{{isLoggedIn ? 'Logout' : 'Login'}}</span>
          </v-btn>
        </router-link>
      </v-toolbar-items>

      <template v-slot:extension>
        <v-tabs align-with-title background-color="transparent">
          <router-link
            v-for="route in routes"
            :key="route.path"
            tag="v-tab"
            :to="route.path"
          >{{route.title}}</router-link>
        </v-tabs>
      </template>
    </v-app-bar>
  </div>
</template>

<script>
export default {
  data() {
    return {
      routes: [
        // dynamic segments start with a colon
        { path: "/", title: "Home" },
        { path: "/Diary", title: "Diary" },
        { path: "/Food", title: "Food" }
      ]
    };
  },
  created() {},
  computed: {
    isLoggedIn() {
      return this.$store.getters.isLoggedIn;
    }
  }
};
</script>

<style scoped>
</style>