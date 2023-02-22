<template>
  <div>
    <v-timeline>
      <v-timeline-item color="yellow darken-1" fill-dot icon="accessibility_new">
        <v-card>
          <v-system-bar color="orange darken-2">
            <v-icon size="23">accessibility_new</v-icon>
            <span class="title">Patronite</span>
          </v-system-bar>
          <v-toolbar flat>
            <v-toolbar-title>Be a patron!</v-toolbar-title>
            <div class="flex-grow-1"></div>
          </v-toolbar>
          <v-banner single-line :sticky="sticky">
            <pre>
        This app is free with no ads.
        Do u like this app?
        Be a patron and donate development and maintanece this app.
        </pre>

            <template v-slot:actions>
              <v-btn text color="deep-purple accent-4">Be a patron</v-btn>
            </template>
          </v-banner>
        </v-card>
      </v-timeline-item>

      <v-timeline-item color="yellow darken-1" fill-dot icon="update">
        <v-card>
          <v-system-bar dark color="orange darken-2">
            <v-icon size="23">update</v-icon>
            <span class="title">Last update</span>
          </v-system-bar>
          <v-toolbar flat>
            <v-col cols="12">
              <v-toolbar-title>What's new?</v-toolbar-title>
            </v-col>
            <div class="flex-grow-1"></div>
          </v-toolbar>
          <v-banner single-line :sticky="sticky">
            <pre>
           * New Design
           ...
        </pre>

            <template v-slot:actions>
              <v-btn text color="deep-purple accent-4">See deatils</v-btn>
            </template>
          </v-banner>
        </v-card>
      </v-timeline-item>

      <v-timeline-item color="yellow darken-1" fill-dot icon="person">
        <v-card>
          <v-system-bar dark color="orange darken-2">
            <v-icon size="23">person</v-icon>
            <span class="title">About</span>
          </v-system-bar>
          <v-toolbar flat>
            <v-col cols="12">
              <v-toolbar-title>About app</v-toolbar-title>
            </v-col>
            <div class="flex-grow-1"></div>
          </v-toolbar>
          <v-banner single-line :sticky="sticky">
            <pre>
          ....
          ....
          ....     
        </pre>

            <template v-slot:actions>
              <v-btn text color="deep-purple accent-4">Learn more</v-btn>
            </template>
          </v-banner>
        </v-card>
      </v-timeline-item>
    </v-timeline>
  </div>
</template>

<script>
export default {};
</script>

<style lang="scss" scoped>
</style>