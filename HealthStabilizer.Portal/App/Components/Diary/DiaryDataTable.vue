<template>
  <div>
    <v-card color="yellow darken-1">
      <v-container>
        <v-row justify="center"></v-row>
        <v-row justify="end">
          <v-btn color="yellow darken-3" @click="foodDialog=!foodDialog">Add new</v-btn>
          <FoodDialog v-if="foodDialog" v-on:close="foodDialog=false"></FoodDialog>
        </v-row>
      </v-container>
      <v-card-title></v-card-title>
    </v-card>
  </div>
</template>

<script>
import API from "../../Config/API";
import FoodDialog from "../Food/FoodDialog.vue";

export default {
  props: {
    focusOnDate: Date
  },
  components: {
    FoodDialog
  },
  data() {
    return {
      search: "",
      foodDialog: false,

      headers: [
        {
          text: "Dessert (100g serving)",
          align: "left",
          sortable: false,
          value: "name"
        },
        { text: "Calories", value: "calories" },
        { text: "Fat (g)", value: "fat" },
        { text: "Carbs (g)", value: "carbs" },
        { text: "Protein (g)", value: "protein" },
        { text: "Iron (%)", value: "iron" }
      ],
      desserts: []
    };
  },
  methods: {
    fetchData() {
      this.axios
        .get(API.DiaryIntake, { date: this.focusOnDate })
        .then(response => {
          this.items = response.data;
        })
        .catch(function(error) {
          console.error(error);
        });
    }
  },
  mounted() {
    this.fetchData();
  }
};
</script>

<style lang="scss" scoped>
</style>