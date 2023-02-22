<template>
  <div>
    <v-text-field color="success" loading disabled v-if="isLoading"></v-text-field>
    <v-card color="yellow darken-1" :loading="loading">
      <v-row justify="center" style="margin:20px">
        <template id="date">
          <v-btn @click="setDate(-1)" text>
            <v-icon>keyboard_arrow_left</v-icon>
          </v-btn>
          <v-menu
            v-model="focusOnDateMenu"
            :close-on-content-click="false"
            :nudge-right="40"
            transition="scale-transition"
            offset-y
            min-width="290px"
          >
            <template v-slot:activator="{ on }">
              <v-text-field
                v-model="focusOnDate"
                label="Check your goal"
                prepend-icon="event"
                readonly
                v-on="on"
              ></v-text-field>
            </template>

            <v-date-picker
              first-day-of-week="1"
              color="yellow darken-2"
              v-model="focusOnDate"
              @input="changeDate()"
            ></v-date-picker>
          </v-menu>
          <v-btn @click="setDate(1)" text>
            <v-icon>keyboard_arrow_right</v-icon>
          </v-btn>
        </template>
      </v-row>
      <v-container>
        <v-card-title>Total.</v-card-title>
        <v-row>
          <template id="Macro">
            <v-col cols="3">
              <span>Calories</span>
              <v-progress-circular
                :rotate="360"
                :size="70"
                :width="10"
                :value="(diarySum.sumCalories/diarySum.goalCalories)*100"
                :color="getColor((diarySum.sumCalories/diarySum.goalCalories)*100)"
              >{{Math.round((diarySum.sumCalories/diarySum.goalCalories)*100)}}%</v-progress-circular>
              <span>{{diarySum.sumCalories}} of {{diarySum.goalCalories}}</span>
            </v-col>
            <v-col cols="3">
              <span>Fat</span>
              <v-progress-circular
                :rotate="360"
                :size="70"
                :width="10"
                :value="(diarySum.sumFat/diarySum.goalFat)*100"
                :color="getColor((diarySum.sumFat/diarySum.goalFat)*100)"
              >{{Math.round((diarySum.sumFat/diarySum.goalFat)*100)}}%</v-progress-circular>
              <span>{{diarySum.sumFat}} of {{diarySum.goalFat}}g</span>
            </v-col>

            <v-col cols="3">
              <span>Protein</span>
              <v-progress-circular
                :rotate="360"
                :size="70"
                :width="10"
                :value="(diarySum.sumProtein/diarySum.goalProtein)*100"
                :color="getColor((diarySum.sumProtein/diarySum.goalProtein)*100)"
              >{{Math.round((diarySum.sumProtein/diarySum.goalProtein)*100)}}%</v-progress-circular>
              <span>{{diarySum.sumProtein}} of {{diarySum.goalProtein}}g</span>
            </v-col>
            <v-col cols="3">
              <span>Carbs</span>
              <v-progress-circular
                :rotate="360"
                :size="70"
                :width="10"
                :value="(diarySum.sumCarbs/diarySum.goalCarbs)*100"
                :color="getColor((diarySum.sumCarbs/diarySum.goalCarbs)*100)"
              >{{Math.round((diarySum.sumCarbs/diarySum.goalCarbs)*100)}}%</v-progress-circular>
              <span>{{diarySum.sumCarbs}} of {{diarySum.goalCarbs}}g</span>
            </v-col>
          </template>
        </v-row>

        <template id="VitaminsAndMinerals" v-if="showDetails">
          <v-divider></v-divider>
          <h2>Vitamin:</h2>
          <v-row>
            <v-col
              cols="3"
              v-for="(item, index) in diarySum.sumVitamin"
              :key="index"
              v-if="index!='vitaminId'"
            >
              <h3>{{index[0].toUpperCase()+index.slice(1)}}</h3>
              <v-progress-circular
                :rotate="360"
                :size="70"
                :width="10"
                :value="Math.round((item/diarySum.goalVitamin[index])*100)"
                :color="getColor(Math.round((item/diarySum.goalVitamin[index])*100))"
              >{{Math.round((item/diarySum.goalVitamin[index])*100)}}%</v-progress-circular>
              <span>{{item}} of {{diarySum.goalVitamin[index]}}</span>
            </v-col>
          </v-row>
          <v-divider></v-divider>
          <h2>Mineral:</h2>
          <v-row>
            <v-col
              cols="3"
              v-for="(item, index) in diarySum.sumMineral"
              :key="index"
              v-if="index!='mineralId'"
            >
              <h3>{{index[0].toUpperCase()+index.slice(1)}}</h3>
              <v-progress-circular
                :rotate="360"
                :size="70"
                :width="10"
                :value="Math.round((item/diarySum.goalMineral[index])*100)"
                :color="getColor(Math.round((item/diarySum.goalMineral[index])*100))"
              >{{Math.round((item/diarySum.goalMineral[index])*100)}}%</v-progress-circular>
              <span>{{item}} of {{diarySum.goalMineral[index]}}</span>
            </v-col>
          </v-row>
        </template>

        <v-btn @click="showDetails=!showDetails">
          {{showDetails ? 'Hide more' : 'Show more'}}
          <v-icon>remove_red_eye</v-icon>
        </v-btn>
      </v-container>

      <diary-data-iterator
        @fetchData="fetchData"
        :focusOnDate="focusOnDate"
        ref="diaryDataIterator"
      ></diary-data-iterator>
    </v-card>
  </div>
</template>

<script>
import DiaryDataIterator from "./DiaryDataIterator.vue";
export default {
  components: {
    DiaryDataIterator
  },
  data() {
    return {
      showDetails: false,
      focusOnDate: new Date().toISOString().substr(0, 10),
      focusOnDateMenu: false,
      isLoading: true,
      diary: []
    };
  },
  methods: {
    fetchData() {
      this.fetchUserGoals();
      this.fetchDiaryIntake();
    },
    fetchUserGoals() {
      this.$store
        .dispatch("getUserGoals", this.focusOnDate)
        .then(response => {})
        .catch(err => {
          console.log(err);
          alert("No data");
        });
    },
    fetchDiaryIntake() {
      this.$store
        .dispatch("getDiarySum", this.focusOnDate)
        .then(response => {
          this.isLoading = false;
        })
        .catch(err => {
          console.log(err);
            alert("No data");
        });
    },
    setDate(days) {
      let newDate = new Date(this.focusOnDate);
      newDate.setDate(newDate.getDate() + days);
      this.focusOnDate = newDate.toISOString().substr(0, 10);
      this.changeDate();
    },
    getColor(item) {
      if (item < 40) return "red";
      else if (item > 40 && item < 80) return "orange";
      else return "success";
    },
    changeDate() {
      this.focusOnDateMenu = false;
      this.fetchData();
      this.$refs.diaryDataIterator.focusOnDate = this.focusOnDate;
      this.$refs.diaryDataIterator.fetchData();
    }
  },
  mounted() {
    this.fetchData();
  },
  computed: {
    diaryIntake() {
      return this.$store.getters.getUserGoals;
    },
    diarySum() {
      return this.$store.getters.getDiarySum;
    }
  }
};
</script>

<style lang="scss" scoped>
</style>