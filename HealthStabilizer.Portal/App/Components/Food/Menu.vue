<template>
  <div>
    <v-card>
      <v-tabs
        v-model="tab"
        background-color="yellow darken-1"
        color="purple darken-3"
        centered
        light
        icons-and-text
      >
        <v-tabs-slider></v-tabs-slider>

        <v-tab href="#tab-1">
          Database
          <v-icon>find_in_page</v-icon>
        </v-tab>

        <v-tab href="#tab-2">
          My food
          <v-icon>fastfood</v-icon>
        </v-tab>
      </v-tabs>

      <v-tabs-items v-model="tab">
        <v-tab-item v-for="i in 2" :key="i" :value="'tab-' + i">
          <v-card flat>
            <v-card-text>{{ text }}</v-card-text>
          </v-card>
        </v-tab-item>
      </v-tabs-items>
    </v-card>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
</style>