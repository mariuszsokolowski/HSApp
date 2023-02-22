<template>
  <div>
    <v-card flat :loading="userSecurity.length<=0">
      <v-form ref="form">
        <v-card class="mx-auto" color="#F9F9F9" max-width="400">
          <v-list-item two-line>
            <v-list-item-content>
              <v-list-item-title class="headline">
                <v-icon>mdi-lock</v-icon>Seciurty
              </v-list-item-title>
              <v-list-item-subtitle>change your profile seciurity</v-list-item-subtitle>
            </v-list-item-content>
          </v-list-item>

          <v-list-item>
            <div class="flex-grow-1"></div>
            <v-col cols="12">
              <v-btn text color="purple" disabled>Reset password</v-btn>
            </v-col>
          </v-list-item>

          <v-list-item>
            <v-list-item-subtitle>
              <v-col cols="12">
                <v-text-field
                  label=" "
                  v-model="userSecurity.mail"
                  :rules="emailRules"
                  color="purple"
                ></v-text-field>
              </v-col>
            </v-list-item-subtitle>
          </v-list-item>

          <v-divider></v-divider>

          <v-card-actions>
            <div class="flex-grow-1"></div>
            <v-btn text color="success" @click="save()">Save changes</v-btn>
          </v-card-actions>
        </v-card>
      </v-form>
    </v-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      emailRules: [
        value => !!value || "Required.",
        v => /.+@.+\..+/.test(v) || "E-mail must be valid"
      ]
    };
  },
  methods: {
    fetchData() {
      this.$store.dispatch("getUserSeciurity");
    },
    save() {
      if (!this.$refs.form.validate()) return;
      this.$store.dispatch("setUserSeciurity", this.userSecurity).then(() => {
        alert("User seciurity is updated.");
      });
    }
  },
  computed: {
    userSecurity() {
      return this.$store.getters.getUserSeciurity;
    }
  },
  mounted() {
    this.fetchData();
  }
};
</script>

<style lang="scss" scoped>
</style>