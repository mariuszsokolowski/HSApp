<template>
  <div>
    <v-hover v-slot:default="{ hover }">
      <v-card :loading="loading" class="mx-auto my-12" max-width="300" :elevation="hover ? 12 : 5">
        <div class="d-flex justify-center">
          <div style="width:85%; height:20vh" class="yellow darken-1 d-flex justify-center">
            <v-card-title class="mainTitle">Register</v-card-title>
          </div>
        </div>
        <v-card-text></v-card-text>

        <v-divider class="mx-4"></v-divider>
        <v-form ref="form" v-model="valid">
          <v-card-text>
            <v-col cols="12">
              <v-text-field
                label="Login"
                v-model="registerDTO.Login"
                prepend-icon="face"
                color="orange"
                :rules="loginRules"
                required
              ></v-text-field>
            </v-col>

            <v-col cols="12">
              <v-text-field
                label="Email"
                v-model="registerDTO.Email"
                prepend-icon="mail"
                color="orange"
                :rules="emailRules"
                required
              ></v-text-field>
            </v-col>

            <v-col cols="12">
              <v-text-field
                v-model="registerDTO.Password"
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
              <v-text-field
                v-model="registerDTO.ConfirmPassword"
                :append-icon="showConfirmPassword ? 'visibility' : 'visibility_off'"
                :type="showConfirmPassword ? 'text' : 'password'"
                name="input-10-1"
                label="Confirm password"
                prepend-icon="lock"
                color="orange"
                hint="At least 8 characters"
                counter
                :rules="confirmPasswordRules"
                @click:append="showConfirmPassword = !showConfirmPassword"
                required
              ></v-text-field>
            </v-col>
          </v-card-text>
        </v-form>

        <v-card-actions>
          <div class="flex-grow-1"></div>

          <v-btn color="green accent-4" text @click="register">Continue</v-btn>
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
      valid: true,
      showPassword: false,
      showConfirmPassword: false,
      registerDTO: {
        Login: "",
        Email: "",
        Password: "",
        ConfirmPassword: ""
      },

      emailRules: [
        value => !!value || "Required.",
        v => /.+@.+\..+/.test(v) || "E-mail must be valid"
      ],
      loginRules: [
        value => !!value || "Required.",
        v => v.length >= 4 || "Min 4 characters."
      ],
      passwordRules: [
        value => !!value || "Required.",
        v => v.length >= 8 || "Min 8 characters.",
        v => /.*[A-Z]/.test(v) || "One or more upper later requred."
      ],
      confirmPasswordRules: [
        value => !!value || "Required.",
        v => v.length >= 8 || "Min 8 characters.",
        () =>
          this.registerDTO.Password === this.registerDTO.ConfirmPassword ||
          "Password must be the same.",
        v => /.*[A-Z]/.test(v) || "One or more upper later requred."
      ]
    };
  },
  methods: {
    register() {
      if (!this.$refs.form.validate()) return;
      this.axios
        .post(API.Account + "Register", this.registerDTO)
        .then(response => {})
        .catch(function(error) {
          console.error(error);
        });
    }
  }
};
</script>

<style lang="scss" scoped>
.mainTitle {
  color: white;
  text-shadow: -0.5px 0 white, 0 0.5px white, 0.5px 0 white, 0 -0.5px white;
}
</style>