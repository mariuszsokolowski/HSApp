<template>
  <div>
    <v-dialog persistent hide-overlay v-model="dialog" width="500">
      <v-card>
        <v-card-title class="headline grey lighten-2" primary-title>Edity Quantity in {{Item.name}}</v-card-title>

        <v-card-text>
          <v-text-field label="Quantity [g]" v-model="Item.quantity"></v-text-field>
        </v-card-text>

        <v-divider></v-divider>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="primary" text @click="close">Save</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>
  </div>
</template>

<script>
export default {
  props: {
    Item: Array
  },
  data() {
    return {
      oldQuantity: 0,
      dialog: true
    };
  },
  methods: {
    close() {
      this.Item.oldQuantity = this.newQuantity;
      this.$emit("close", this.Item);
    }
  },
  created() {
    this.newQuantity = this.Item.quantity;
  }
};
</script>

<style lang="scss" scoped>
</style>