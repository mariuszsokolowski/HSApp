<template>
  <div>
    <DiaryIntake></DiaryIntake>
    <!-- <diary-data-table></diary-data-table> -->
  </div>
</template>

<script>
import DiaryIntake from "./DiaryIntake.vue";
import DiaryDataTable from "./DiaryDataTable.vue";

export default {
  components: {
    DiaryDataTable,
    DiaryIntake
  },
  data() {
    return {};
  }
};
</script>

<style lang="scss" scoped>
</style>