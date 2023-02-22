<template>
  <div>
    <v-row justify="center">
      <scanner
        v-if="searchScanner"
        v-on:close="searchScanner=false"
        v-on:successScan="foodDTO.QRCode=$event; searchScanner=false"
      ></scanner>

      <v-dialog v-model="dialog" persistent max-width="600px">
        <template v-slot:activator="{ on }">
          <v-btn v-on="on" color="yellow darken-3">Add</v-btn>
        </template>
        <v-card>
          <v-form ref="form" v-model="valid">
            <v-card-title class="yellow darken-1">
              <span class="headline">Adding your food</span>
              <div class="flex-grow-1"></div>

              <v-col cols="12" sm="12" md="12">
                <v-text-field
                  label="QRCode | Barcode"
                  required
                  prepend-icon="camera"
                  v-model="foodDTO.QRCode"
                  @click:prepend="searchScanner=true"
                ></v-text-field>
              </v-col>
              <v-row>
                <v-col cols="6" sm="6" md="6" class="d-flex align-start">
                  <add-vitamin-dialog></add-vitamin-dialog>
                </v-col>
                <v-col cols="6" sm="6" md="6" class="d-flex justify-end">
                  <add-mineral-dialog></add-mineral-dialog>
                </v-col>
              </v-row>
            </v-card-title>

            <v-card-text>
              <v-container>
                <v-row>
                  <v-col cols="12" sm="12" md="7">
                    <v-text-field
                      label="*Name"
                      required
                      v-model="foodDTO.Name"
                      :rules="[rules.basicRules.required]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="5">
                    <v-text-field label="Brand" v-model="foodDTO.Brand"></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="12" md="12">
                    <v-text-field
                      label="*Descritpion"
                      required
                      v-model="foodDTO.Description"
                      :rules="[rules.basicRules.required]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="*Calories"
                      v-model.number="foodDTO.Calories"
                      :rules="rules.numberRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="*Carbs"
                      required
                      v-model.number="foodDTO.Carbs"
                      :rules="rules.macroRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="*Protein"
                      required
                      v-model="foodDTO.Protein"
                      :rules="rules.macroRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="*Fat"
                      required
                      v-model.number="foodDTO.Fat"
                      :rules="rules.macroRule"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Piece in package"
                      required
                      v-model.Number="foodDTO.PieceInPackage"
                      :rules="[rules.basicRules.numberType]"
                    ></v-text-field>
                  </v-col>
                  <v-col cols="12" sm="6" md="4">
                    <v-text-field
                      label="Weight in package"
                      required
                      v-model.number="foodDTO.WeightInPackage"
                      :rules="[rules.basicRules.numberType]"
                    ></v-text-field>
                  </v-col>
                </v-row>
              </v-container>
            </v-card-text>
            <v-card-actions>
              <v-btn color="error" text @click="dialog = false">Close</v-btn>
              <div class="flex-grow-1"></div>
              <v-btn color="success" text @click="save()">Add</v-btn>
            </v-card-actions>
          </v-form>
        </v-card>
      </v-dialog>
    </v-row>
  </div>
</template>

<script>
import AddVitaminDialog from "../Vitamin/AddVitamin.vue";
import AddMineralDialog from "../Mineral/AddMineral.vue";
import Scanner from "../Scanner/Scanner.vue";
import Rules from "../../Config/rules";

export default {
  components: {
    AddVitaminDialog: AddVitaminDialog,
    AddMineralDialog: AddMineralDialog,
    Scanner: Scanner
  },
  data() {
    return {
      valid: true,
      dialog: false,
      editedItem: [],
      searchScanner: false,
      foodDTO: {
        QRCode: "",
        Name: "",
        Brand: "",
        Descritpion: "",
        Calories: 0,
        Carbs: 0,
        Protein: 0,
        Fat: 0,
        PieceInPackage: 0,
        WeightInPackage: 0
      },
      rules: ""
    };
  },
  methods: {
    save() {
          if (!this.$refs.form.validate()) return;

      this.$store
        .dispatch("addFood", this.foodDTO)
        .then(() => {
          this.$router.push({ path: "/" });
        })
        .catch(err => {
          alert("You entered an invalid login or password. Please try again.");
        });
    }
  },
  created() {
    this.rules = Rules;
  }
};
</script>

<style lang="scss" scoped>
</style>