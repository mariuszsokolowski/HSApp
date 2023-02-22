<template>
  <div>
    <v-container>
      <change-quantity-dialog
        v-if="changeQuantityDialog"
        :Item="changeQuantityItem"
        v-on:close="changeQuantity"
      ></change-quantity-dialog>
      <v-data-iterator
        :items="items"
        :items-per-page.sync="itemsPerPage"
        :page="page"
        :search="search"
        :sort-by="sortBy.toLowerCase()"
        :sort-desc="sortDesc"
        hide-default-footer
      >
        <template v-slot:header>
          <v-toolbar dark color="yellow darken-1" class="mb-1">
            <v-text-field
              v-model="search"
              clearable
              flat
              solo-inverted
              hide-details
              prepend-inner-icon="search"
              label="Search"
              light
            ></v-text-field>
            <template v-if="$vuetify.breakpoint.mdAndUp">
              <div class="flex-grow-1"></div>
              <v-select
                v-model="sortBy"
                flat
                solo-inverted
                hide-details
                :items="keys"
                prepend-inner-icon="search"
                label="Sort by"
                light
              ></v-select>
              <div class="flex-grow-1"></div>
              <v-btn-toggle v-model="sortDesc" mandatory light>
                <v-btn large color="yellow darken-2" :value="false">
                  <v-icon>arrow_upward</v-icon>
                </v-btn>
                <v-btn large color="yellow darken-2" :value="true">
                  <v-icon>arrow_downward</v-icon>
                </v-btn>
              </v-btn-toggle>
            </template>
          </v-toolbar>
          <v-btn color="yellow darken-3" @click="foodDialog=!foodDialog">Add new</v-btn>
          <FoodDialog
            v-if="foodDialog"
            @close="fetchData();foodDialog=false; "
            :focusOnDate="focusOnDate"
          ></FoodDialog>
        </template>

        <template v-slot:default="props">
          <v-row justify="end"></v-row>
          <v-row>
            <v-col v-for="item in props.items" :key="item.name" cols="12" sm="6" md="4" lg="3">
              <v-card color="yellow darken-3">
                <v-row>
                  <v-col cols="9">
                    <v-card-title
                      class="subheading font-weight-bold"
                      @click="openChangeQuantityDialog(item)"
                    >{{ item.food.name }} [{{item.quantity}}g]</v-card-title>
                  </v-col>
                  <v-col cols="3" class="d-flex justify-end">
                    <v-btn text>
                      <v-icon color="orange darken-4" @click="remove(item)">delete</v-icon>
                    </v-btn>
                  </v-col>
                </v-row>
                <v-divider></v-divider>

                <v-list dense>
                  <v-list-item
                    v-for="(key, index) in keys"
                    :key="index"
                    :color="sortBy === key ? `blue lighten-4` : `white`"
                  >
                    <template v-if="key!='Name'">
                      <v-list-item-content>{{ key }}:</v-list-item-content>
                      <v-list-item-content
                        class="align-end"
                      >{{ Math.round(item.food[key.toLowerCase()]*(item.quantity/100) *100)/100 }}</v-list-item-content>
                    </template>
                  </v-list-item>
                </v-list>
              </v-card>
            </v-col>
          </v-row>
        </template>

        <template v-slot:footer>
          <v-row class="mt-2" align="center" justify="center">
            <span class="grey--text">Items per page</span>
            <v-menu offset-y>
              <template v-slot:activator="{ on }">
                <v-btn dark text color="primary" class="ml-2" v-on="on">
                  {{ itemsPerPage }}
                  <v-icon>mdi-chevron-down</v-icon>
                </v-btn>
              </template>
              <v-list>
                <v-list-item
                  v-for="(number, index) in itemsPerPageArray"
                  :key="index"
                  @click="updateItemsPerPage(number)"
                >
                  <v-list-item-title>{{ number }}</v-list-item-title>
                </v-list-item>
              </v-list>
            </v-menu>

            <div class="flex-grow-1"></div>

            <span class="mr-4 grey--text">Page {{ page }} of {{ numberOfPages }}</span>
            <v-btn fab dark color="yellow darken-3" class="mr-1" @click="formerPage">
              <v-icon>arrow_back</v-icon>
            </v-btn>
            <v-btn fab dark color="yellow darken-3" class="ml-1" @click="nextPage">
              <v-icon>arrow_forward</v-icon>
            </v-btn>
          </v-row>
        </template>
      </v-data-iterator>
    </v-container>
  </div>
</template>

<script>
import FoodDialog from "../Food/FoodDialog.vue";
import ChangeQuantityDialog from "../Food/ChangeQuantityDialog.vue";
export default {
  components: {
    ChangeQuantityDialog,
    FoodDialog
  },
  props: {
    focusOnDate: String
  },
  data() {
    return {
      foodDialog: false,
      changeQuantityDialog: false,
      changeQuantityItem: "",
      itemsPerPageArray: [4, 8, 12],
      search: "",
      filter: {},
      sortDesc: false,
      page: 1,
      itemsPerPage: 4,
      sortBy: "name",
      keys: ["Name", "Calories", "Fat", "Carbs", "Protein"],
      items: []
    };
  },
  computed: {
    numberOfPages() {
      return Math.ceil(this.items.length / this.itemsPerPage);
    },
    filteredKeys() {
      return this.keys.filter(key => key !== `Name`);
    },
    diarySum() {
      if (this.items.length > 0) {
        return {
          calories: this.items.reduce(function(a, b) {
            return a.food
              ? Math.round(a.food.calories * (a.quantity / 100) * 100) / 100 +
                  Math.round(b.food.calories * (b.quantity / 100) * 100) / 100
              : a +
                  Math.round(b.food.calories * (b.quantity / 100) * 100) / 100;
          }),
          protein: this.items.reduce(function(a, b) {
            return a.food
              ? Math.round((a.food.protein / (100 / a.quantity)) * 100) /
                  +Math.round((b.food.protein / (100 / b.quantity)) * 100) /
                  100
              : a +
                  Math.round((b.food.protein / (100 / b.quantity)) * 100) / 100;
          }),
          fat: this.items.reduce(function(a, b) {
            return a.food
              ? Math.round((a.food.fat / (100 / a.quantity)) * 100) /
                  +Math.round((b.food.fat / (100 / b.quantity)) * 100) /
                  100
              : a + Math.round((b.food.fat / (100 / b.quantity)) * 100) / 100;
          }),
          carbs: this.items.reduce(function(a, b) {
            return a.food
              ? Math.round((a.food.carbs / (100 / a.quantity)) * 100) /
                  +Math.round((b.food.carbs / (100 / b.quantity)) * 100) /
                  100
              : a + Math.round((b.food.carbs / (100 / b.quantity)) * 100) / 100;
          })
        };
      }
    }
  },
  methods: {
    fetchData() {
      this.$emit("fetchData");
      this.items = [];
      this.$store
        .dispatch("getDiary", this.focusOnDate)
        .then(data => {
          this.items = data;
        })
        .catch(err => {
          console.log(err);
          alert("No data");
        });
    },
    remove(item) {
      this.$store
        .dispatch("removeFromDiary", item.diaryId)
        .then(data => {
          alert("Removed from diary.");
          this.fetchData();
        })
        .catch(err => {
          console.log(err);
          alert(err);
        });
    },
    nextPage() {
      if (this.page + 1 <= this.numberOfPages) this.page += 1;
    },
    formerPage() {
      if (this.page - 1 >= 1) this.page -= 1;
    },
    updateItemsPerPage(number) {
      this.itemsPerPage = number;
    },
    openChangeQuantityDialog(item) {
      this.changeQuantityDialog = true;
      this.changeQuantityItem = item;
    },
    changeQuantity(payload) {
      if (payload.quantity !== payload.oldQuantity) {
        this.updateDiaryQuantity(payload);
      }
      this.changeQuantityDialog = false;
      this.items.find(x => x.diaryId == payload.diaryId).quantity =
        payload.quantity;
    },
    updateDiaryQuantity(payload) {
      this.$store
        .dispatch("updateQuantityInDiary", payload)
        .then(data => {
          alert("Zaktualizowano");
        })
        .catch(err => {
          console.log(err);
          alert(err);
        });
    }
  },
  computed: {},
  created() {
    this.fetchData();
  }
};
</script>

<style lang="scss" scoped>
</style>