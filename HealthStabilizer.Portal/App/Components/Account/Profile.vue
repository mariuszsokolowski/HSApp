<template>
  <div>
    <v-card flat :loading="userProfile.length<=0">
      <v-form ref="form">
        <v-card class="mx-auto" color="#F9F9F9" max-width="400">
          <v-list-item two-line>
            <v-list-item-content>
              <v-list-item-title class="headline">
                <v-icon>person</v-icon>Profile
              </v-list-item-title>
              <v-list-item-subtitle>change your profile settings</v-list-item-subtitle>
            </v-list-item-content>
          </v-list-item>

          <v-list-item>
            <div class="flex-grow-1"></div>
            <v-col cols="12">
              <v-btn text color="purple">Recalculate goals</v-btn>
            </v-col>
          </v-list-item>

          <v-list-item>
            <v-list-item-subtitle>
              <v-row>
                <v-col cols="12" sm="12" md="6">
                  <v-text-field
                    label="FirstName"
                    v-model="userProfile.firstName"
                    :rules="requiredRules"
                    color="purple"
                  ></v-text-field>
                </v-col>

                <v-col cols="12" sm="12" md="6">
                  <v-text-field
                    label="LastName"
                    v-model="userProfile.lastName"
                    :rules="requiredRules"
                    color="purple"
                  ></v-text-field>
                </v-col>
              </v-row>

              <v-col cols="12">
                <v-text-field
                  label="Age"
                  v-model="userProfile.age"
                  :rules="requiredNumberRules"
                  color="purple"
                ></v-text-field>
              </v-col>

              <v-col cols="12">
                <v-text-field
                  label="Height"
                  v-model="userProfile.height"
                  :rules="requiredNumberRules"
                  color="purple"
                ></v-text-field>
              </v-col>

              <v-col cols="12">
                <v-text-field
                  label="Weight"
                  v-model="userProfile.weight"
                  :rules="requiredNumberRules"
                  color="purple"
                  suffix="kg"
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
      ],
      requiredRules: [value => !!value || "Required."],
      requiredNumberRules: [
        value => !!value || "Required.",
        v => Number.isInteger(v) || "Value must be number."
      ]
    };
  },
  methods: {
    fetchData() {
      this.$store.dispatch("getUserProfile");
    },
    save() {
      if (!this.$refs.form.validate()) return;
      this.$store.dispatch("setUserProfile", this.userProfile).then(() => {
        alert("User profile is updated.");
      });
    }
  },
  computed: {
    userProfile() {
      return this.$store.getters.getUserProfile;
    }
  },
  mounted() {
    this.fetchData();
  }
};
</script>

<style lang="scss" scoped>
</style>