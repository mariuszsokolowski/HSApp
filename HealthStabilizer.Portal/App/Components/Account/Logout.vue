<template>
  <div>Logout...</div>
</template>

<script>
export default {
  methods: {
    logout() {
      this.$store
        .dispatch("logout")
        .then(() => {
          this.$router.push({ path: "/Login" });
        })
        .catch(err => {
          console.log(err);
          alert(err);
        });
    }
  },
  created() {
    this.logout();
  }
};
</script>

<style lang="scss" scoped>
</style>