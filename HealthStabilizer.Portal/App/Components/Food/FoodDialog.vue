<template>
  <div>
    <v-dialog v-model="dialog" persistent width="900">
      <v-card>
        <food-data-table :focusOnDate="focusOnDate" @close="dialog=false;$emit('close')"></food-data-table>
        <v-divider></v-divider>
        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="error" text @click="close">Close</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
import FoodDataTable from "./FoodDataTable.vue";
import Scanner from "../Scanner/Scanner.vue";
export default {
  props: {
    focusOnDate: Date
  },
  components: {
    FoodDataTable: FoodDataTable,
    Scanner: Scanner
  },
  data() {
    return {
      dialog: true
    };
  },
  methods: {
    close() {
      this.$emit("close");
      this.dialog = false;
    }
  }
};
</script>

<style lang="scss" scoped>
</style>