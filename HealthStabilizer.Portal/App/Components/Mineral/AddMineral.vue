<template>
  <div>
    <v-row justify="center">
      <v-dialog v-model="dialog" persistent max-width="600px">
        <template v-slot:activator="{ on }">
          <v-btn color="grey darken-1" dark v-on="on">
            <v-icon>sentiment_satisfied_alt</v-icon>Minerals
          </v-btn>
        </template>
        <v-card>
          <v-card-title class="yellow darken-1">
            <span class="headline">Mineral</span>
          </v-card-title>

          <v-card-text>
            <v-form ref="form" v-model="valid">
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Potassium"
                      v-model.number="mineralDTO.Potassium"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Chloride"
                      v-model.number="mineralDTO.Chloride"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Calcium"
                      v-model.number="mineralDTO.Calcium"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>

                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Phosphorus"
                      v-model.number="mineralDTO.Phosphorus"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Magnesium"
                      v-model.number="mineralDTO.Magnesium"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Iron"
                      v-model.number="mineralDTO.Iron"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Zinc"
                      v-model.number="mineralDTO.Zinc"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Copper"
                      v-model.number="mineralDTO.Copper"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Manganese"
                      v-model.number="mineralDTO.Manganese"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Fluoride"
                      v-model.number="mineralDTO.Fluoride"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Selenium"
                      v-model.number="mineralDTO.Selenium"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Chromium"
                      v-model.number="mineralDTO.Chromium"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field
                      label="Molybdenum"
                      v-model.number="mineralDTO.Molybdenum"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field
                      label="Iodine"
                      v-model.number="mineralDTO.Iodine"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="6">
                    <v-text-field
                      label="Sodium"
                      v-model.number="mineralDTO.Sodium"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-form>
          </v-card-text>
          <v-card-actions>
            <v-btn color="error" text @click="close()">Close</v-btn>
            <div class="flex-grow-1"></div>
            <v-btn color="success" text @click="save()">Save</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-row>
  </div>
</template>

<script>
import Rules from "../../Config/rules";

export default {
  data() {
    return {
      dialog: false,
      valid: true,
      rules: "",
      mineralDTO: {
        Potassium: 0,
        Chloride: 0,
        Calcium: 0,
        Phosphorus: 0,
        Magnesium: 0,
        Iron: 0,
        Zinc: 0,
        Copper: 0,
        Manganese: 0,
        Fluoride: 0,
        Selenium: 0,
        Chromium: 0,
        Molybdenum: 0,
        Iodine: 0,
        Sodium: 0
      }
    };
  },
  methods: {
    save() {
      if (!this.$refs.form.validate()) return;
    },
    close() {
      if (confirm("All mineral will be set to 0. Reset setting?")) {
        for (var property in this.mineralDTO) {
          this.mineralDTO[property] = 0;
        }
        this.dialog = false;
      }
    }
  },
  created() {
    this.rules = Rules;
  }
};
</script>

<style lang="scss" scoped>
</style>