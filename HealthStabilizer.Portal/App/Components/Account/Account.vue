<template>
  <div>
    <v-card>
      <v-toolbar flat color="yellow darken-1" light>
        <v-toolbar-title>
          <v-icon>person</v-icon>Account
        </v-toolbar-title>
      </v-toolbar>

      <v-tabs vertical color="deep-purple darken-1" background-color="grey lighten-1">
        <v-tab>
          <v-icon left>speed</v-icon>Goals
        </v-tab>
        <v-tab>
          <v-icon left>mdi-lock</v-icon>Security
        </v-tab>
        <v-tab>
          <v-icon left>person</v-icon>Profile
        </v-tab>

        <v-tab-item>
          <goals></goals>
        </v-tab-item>

        <v-tab-item>
          <security></security>
        </v-tab-item>

        <v-tab-item>
          <profile></profile>
        </v-tab-item>
      </v-tabs>
    </v-card>
  </div>
</template>

<script>
import Goals from "./Goals.vue";
import Security from "./Security.vue";
import Profile from "./Profile.vue";
export default {
  components: {
    Goals: Goals,
    Security: Security,
    Profile: Profile
  }
};
</script>

<style lang="scss" scoped>
</style>