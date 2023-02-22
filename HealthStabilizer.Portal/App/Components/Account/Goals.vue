<template>
  <div>
    <v-card flat color="#E0E0E0" :loading="goals.length<=0">
      <v-card-text>
        <v-card class="mx-auto" color="#F9F9F9" max-width="400">
          <v-list-item two-line>
            <v-list-item-content>
              <v-list-item-title class="headline">
                <v-icon>speed</v-icon>calories & macro
              </v-list-item-title>
              <v-list-item-subtitle>change your goals</v-list-item-subtitle>
              <v-radio-group v-model="unitUsing" @change="recalculate()">
                <v-radio value="%">
                  <template v-slot:label>
                    <div>
                      Use
                      <strong class="success--text">procents</strong>
                    </div>
                  </template>
                </v-radio>
                <v-radio value="g">
                  <template v-slot:label>
                    <div>
                      Use
                      <strong class="primary--text">grams</strong>
                    </div>
                  </template>
                </v-radio>
              </v-radio-group>
            </v-list-item-content>
          </v-list-item>
          <v-form ref="form" v-model="valid">
            <v-list-item>
              <v-list-item-subtitle>
                <v-col cols="12">
                  <v-text-field
                    label="Calories"
                    v-model.number="goals.calories"
                    color="purple"
                    :rules="requiredRule"
                    suffix="kcal"
                  ></v-text-field>
                </v-col>
              </v-list-item-subtitle>
            </v-list-item>

            <v-list-item>
              <v-list-item-subtitle>
                <v-col cols="12">
                  <v-text-field
                    :label="unitUsing==='g' ?'Carbs ('+goals.carbs*4+' kcal)' : 'Carbs ('+Math.round((goals.calories*(goals.carbs/100))/4)+'g)'"
                    v-model.number="goals.carbs"
                    color="purple"
                    :rules="requiredRule"
                    :suffix="unitUsing"
                  ></v-text-field>
                </v-col>
              </v-list-item-subtitle>
            </v-list-item>

            <v-list-item>
              <v-list-item-subtitle>
                <v-col cols="12">
                  <v-text-field
                    :label="unitUsing==='g' ?'Protein ('+goals.protein*4+' kcal)' : 'Protein ('+Math.round((goals.calories*(goals.protein/100))/4)+'g)' "
                    v-model.number="goals.protein"
                    color="purple"
                    :rules="requiredRule"
                    :suffix="unitUsing"
                  ></v-text-field>
                </v-col>
              </v-list-item-subtitle>
            </v-list-item>

            <v-list-item>
              <v-list-item-subtitle>
                <v-col cols="12">
                  <v-text-field
                    :label="unitUsing==='g' ?'Fat ('+goals.fat*9+' kcal)' : 'Fat ('+Math.round((goals.calories*(goals.fat/100))/9)+'g)'"
                    v-model.number="goals.fat"
                    color="purple"
                    :rules="requiredRule"
                    :suffix="unitUsing"
                  ></v-text-field>
                </v-col>
              </v-list-item-subtitle>
            </v-list-item>
          </v-form>
          <ul style="color:red">
            <li v-for="(item,index) in errorMessage" :key="index">
              <span>
                <i>{{item}}</i>
              </span>
            </li>
          </ul>
          <v-divider></v-divider>

          <v-card-actions>
            <v-btn text color="error">Cancle</v-btn>
            <div class="flex-grow-1"></div>
            <v-btn text color="success" @click="save">Save changes</v-btn>
          </v-card-actions>
        </v-card>
      </v-card-text>
    </v-card>
  </div>
</template>

<script>
export default {
  data() {
    return {
      unitUsing: "%",

      errorMessage: [],
      requiredRule: [
        v => !!v || "Required.",
        v => Number.isInteger(v) || "Value must be number."
      ]
    };
  },
  methods: {
    fetchData() {
      this.$store.dispatch("getUserGoals");
    },

    save() {
      this.errorMessage = [];
      if (!this.$refs.form.validate()) return;

      if (this.unitUsing === "%" && !this.checkProcents()) {
        this.errorMessage.push("The sum of the percentages must be 100");
        return;
      } else if (this.unitUsing === "g" && !this.checkGrams()) {
        this.errorMessage.push(
          "The sum of macro kcal and global kcal must be the same"
        );
        return;
      }

      this.$store
        .dispatch("setUserGoals", this.recalculateToProcents())
        .then(() => {
          alert("Goals is updated.");
        });
    },
    checkProcents() {
      return this.goals.carbs + this.goals.protein + this.goals.fat === 100;
    },
    checkGrams() {
      return (
        (this.goals.carbs + this.goals.protein) * 4 + this.goals.fat * 9 ===
        this.goals.calories
      );
    },
    recalculate() {
      if (this.unitUsing === "%") {
        this.goals.carbs = ((this.goals.carbs * 4) / this.goals.calories) * 100;
        this.goals.protein =
          ((this.goals.protein * 4) / this.goals.calories) * 100;
        this.goals.fat = ((this.goals.fat * 9) / this.goals.calories) * 100;
      } else {
        this.goals.carbs = (this.goals.calories * (this.goals.carbs / 100)) / 4;

        this.goals.protein =
          (this.goals.calories * (this.goals.protein / 100)) / 4;
        this.goals.fat = (this.goals.calories * (this.goals.fat / 100)) / 9;
      }
    },
    recalculateToProcents() {
      if (this.unitUsing == "%") return this.goals;
      var tempGoals = JSON.parse(JSON.stringify(this.goals));
      tempGoals.carbs = ((this.goals.carbs * 4) / this.goals.calories) * 100;
      tempGoals.protein =
        ((this.goals.protein * 4) / this.goals.calories) * 100;
      tempGoals.fat = ((this.goals.fat * 9) / this.goals.calories) * 100;
      return tempGoals;
    }
  },
  computed: {
    goals() {
      return this.$store.getters.getUserGoals;
    }
  },
  mounted() {
    this.fetchData();
  }
};
</script>

<style lang="scss" scoped>
</style>