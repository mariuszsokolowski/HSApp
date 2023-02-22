<template>
  <div>
    <v-hover v-slot:default="{ hover }">
      <v-card :loading="loading" class="mx-auto my-12" max-width="300" :elevation="hover ? 12 : 5">
        <div class="d-flex justify-center">
          <div style="width:85%; height:20vh" class="yellow darken-1 d-flex justify-center">
            <v-card-title style="color:white;" class="mainTitle">Login</v-card-title>
          </div>
        </div>
        <v-card-text></v-card-text>

        <v-divider class="mx-4"></v-divider>
        <v-form ref="form" v-model="valid">
          <v-card-text>
            <v-col cols="12">
              <v-text-field
                label="Login"
                v-model="loginDTO.Login"
                prepend-icon="face"
                color="orange"
                :rules="loginRules"
                required
              ></v-text-field>
            </v-col>
            <v-col cols="12">
              <v-text-field
                v-model="loginDTO.Password"
                :append-icon="showPassword ? 'visibility' : 'visibility_off'"
                :type="showPassword ? 'text' : 'password'"
                name="input-10-1"
                label="Password"
                prepend-icon="lock"
                color="orange"
                hint="At least 8 characters"
                counter
                @click:append="showPassword = !showPassword"
                :rules="passwordRules"
                required
              ></v-text-field>
            </v-col>
          </v-card-text>
        </v-form>
        <v-card-actions>
          <router-link to="/Register">
            <v-btn color="deep-purple accent-4" text>Register</v-btn>
          </router-link>
          <div class="flex-grow-1"></div>
          <v-btn color="green accent-4" text @click="login">Login</v-btn>
        </v-card-actions>
      </v-card>
    </v-hover>
  </div>
</template>

<script>
import API from "../../Config/API";
export default {
  data() {
    return {
      showPassword: false,
      valid: true,
      API: "",
      loginDTO: {
        Login: "",
        Password: ""
      },
      rules: "",
      loginRules: [
        v => !!v || "Required.",
        v => v.length >= 4 || "Min 4 characters."
      ],
      passwordRules: [
        value => !!value || "Required.",
        v => v.length >= 8 || "Min 8 characters.",
        v => /.*[A-Z]/.test(v) || "One or more upper later requred."
      ]
    };
  },
  methods: {
    login() {
      if (!this.$refs.form.validate()) return;

      this.$store
        .dispatch("login", this.loginDTO)
        .then(() => {
          this.$router.push({ path: "/" });
        })
        .catch(err => {
          // console.log(err);
          alert("You entered an invalid login or password. Please try again.");
        });
    }
  },
  computed: {
    authToken() {
      return true;
    }
  },
  created() {
    this.rules = rules;
  }
};
</script>

<style lang="scss" scoped>
.mainTitle {
  color: white;
  text-shadow: -0.5px 0 white, 0 0.5px white, 0.5px 0 white, 0 -0.5px white;
}
</style>