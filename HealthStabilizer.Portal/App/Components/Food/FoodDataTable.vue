<template>
  <div>
    <scanner
      v-if="searchScanner"
      v-on:close="searchScanner=false"
      v-on:successScan="search=$event; searchScanner=false"
    ></scanner>
    <MenuNav></MenuNav>
    <change-quantity-dialog
      v-if="changeQuantityDialog"
      :Item="changeQuantityItem"
      v-on:close="changeQuantity"
    ></change-quantity-dialog>
    <v-card color="yellow darken-1">
      <v-card-title>
        <v-container>
          <v-row justify="end">
            <v-col cols="auto">
              <v-btn
                color="yellow darken-3"
                :disabled="selectedFood.length<=0"
                @click="addFoodsToDiary"
              >Add checked</v-btn>
              <!-- <add-food></add-food> -->
            </v-col>
          </v-row>
          <v-row justify="end">
            <v-col cols="6">
              <div class="flex-grow-1"></div>
              <v-text-field
                v-model="search"
                append-icon="search"
                @click:prepend="searchScanner=true"
                label="Search"
                single-line
                hide-details
                prepend-icon="camera"
              ></v-text-field>
            </v-col>
          </v-row>
        </v-container>
      </v-card-title>
      <v-data-table
        v-model="selectedFood"
        :headers="headers"
        :items="items"
        loading="true"
        :search="search"
        item-key="foodId"
        multi-sort
        show-select
        class="elevation-1"
      >
        <template v-slot:item.quantity="{ item }">
          <div @click="openChangeQuantityDialog(item)">{{item.quantity}}g</div>
        </template>
      </v-data-table>
    </v-card>
  </div>
</template>

<script>
import API from "../../Config/API";
import AddFood from "./AddFood.vue";
import Scanner from "../Scanner/Scanner.vue";
import MenuNav from "./Menu.vue";
import ChangeQuantityDialog from "./ChangeQuantityDialog.vue";
export default {
  props: {
    focusOnDate: Date
  },
  components: {
    AddFood: AddFood,
    Scanner: Scanner,
    MenuNav: MenuNav,
    ChangeQuantityDialog: ChangeQuantityDialog
  },
  data() {
    return {
      changeQuantityDialog: false,
      changeQuantityItem: "",
      searchScanner: false,
      selectedFood: [],
      search: "",
      addFoodToDiaryDTO: {
        Date: "",
        Foods: []
      },
      headers: [
        {
          text: "Name",
          align: "left",
          value: "name"
        },
        { text: "Quantity [g]", value: "quantity" },
        { text: "Calories", value: "calories" },
        { text: "Fat (g)", value: "fat" },
        { text: "Carbs (g)", value: "carbs" },
        { text: "Protein (g)", value: "protein" },
        { text: "Iron (%)", value: "iron" }
      ],
      items: []
    };
  },
  methods: {
    fetchData() {
      this.$store
        .dispatch("getFood")
        .then(data => {
          for (var i = 0; i < data.length; i++) {
            data[i].quantity = 100;
          }
          this.items = data;
        })
        .catch(err => {
          console.log(err);
          alert(err);
        });
    },
    addFoodsToDiary() {
      this.addFoodToDiaryDTO.Foods = this.selectedFood;
      this.addFoodToDiaryDTO.Date = this.focusOnDate;
      if (this.addFoodToDiaryDTO.Foods.length <= 0) return;

      for (var i = 0; i < this.addFoodToDiaryDTO.Foods.length; i++) {
        if (this.addFoodToDiaryDTO.Foods[i].Quantity <= 0) return;
      }
      this.$store
        .dispatch(`addFoodsToDiary`, this.addFoodToDiaryDTO)
        .then(() => {
          alert("Added to diary.");
          this.close();
          // this.$router.push({ path: "/Diary" });
        })
        .catch(err => {
          console.log(err);
        });
    },
    openChangeQuantityDialog(item) {
      this.changeQuantityDialog = true;
      this.changeQuantityItem = item;
    },
    changeQuantity(payload) {
      this.changeQuantityDialog = false;
      this.items.find(x => x.FoodId == payload.item.FoodId).quantity =
        payload.Quantity;
    },
    close() {
      this.$emit("close");
    }
  },
  mounted() {
    this.fetchData();
  }
};
</script>

<style lang="scss" scoped>
</style>