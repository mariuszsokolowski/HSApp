<template>
  <div>
    <v-row justify="center">
      <v-dialog v-model="dialog" persistent max-width="600px">
        <template v-slot:activator="{ on }">
          <v-btn color="orange" v-on="on">
            <v-icon>insert_emoticon</v-icon>Vitamins
          </v-btn>
        </template>
        <v-card>
          <v-card-title class="yellow darken-1">
            <span class="headline">Vitamins for Apple</span>
          </v-card-title>

          <v-card-text>
            <v-form ref="form" v-model="valid">
              <v-container>
                <v-row>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Vitamin A"
                      v-model.number="vitaminDTO.VitaminA"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Vitamin D"
                      v-model.number="vitaminDTO.VitaminD"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Vitamin E"
                      v-model.number="vitaminDTO.VitaminE"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>

                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Vitamin K"
                      v-model.number="vitaminDTO.VitaminK"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Vitamin C"
                      v-model.number="vitaminDTO.VitaminC"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Thiamine"
                      v-model.number="vitaminDTO.Thiamine"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Riboflavin"
                      v-model.number="vitaminDTO.Riboflavin"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Niacin"
                      v-model.number="vitaminDTO.Niacin"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Vitamin B6"
                      v-model.number="vitaminDTO.VitaminB6"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      label="Vitamin B12"
                      v-model.number="vitaminDTO.VitaminB12"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      label="Folic Acid"
                      v-model.number="vitaminDTO.FolicAcid"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      label="Biotin"
                      v-model.number="vitaminDTO.Biotin"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      label="Panotehnic Acid"
                      v-model.number="vitaminDTO.PanotehnicAcid"
                      :rules="rules.mineralAndVitaminRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      label="Choline"
                      v-model.number="vitaminDTO.Choline"
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
      valid: true,
      dialog: false,
      rules: "",
      vitaminDTO: {
        VitaminA: 0,
        VitaminD: 0,
        VitaminE: 0,
        VitaminK: 0,
        VitaminC: 0,
        Thiamine: 0,
        Riboflavin: 0,
        Niacin: 0,
        VitaminB6: 0,
        VitaminB12: 0,
        FolicAcid: 0,
        Biotin: 0,
        PanotehnicAcid: 0,
        Choline: 0
      }
    };
  },
  methods: {
    save() {
      if (!this.$refs.form.validate()) return;
    },
    close() {
      if (confirm("All vitamins will be set to 0. Reset setting?")) {
        for (var property in this.vitaminDTO) {
          this.vitaminDTO[property] = 0;
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