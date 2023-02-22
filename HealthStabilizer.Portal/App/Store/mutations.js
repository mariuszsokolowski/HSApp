const mutations = {
  setAuthToken(state, value) {
    localStorage.setItem("authToken", value);
    state.authToken = value;
  },
  removeAuthToken(state) {
    localStorage.removeItem("authToken");
    state.authToken = "";
  },
  setFood(state, value) {
    state.food = value;
  },
  setUserGoals(state, value) {
    state.userGoals = value;
  },
  setUserSeciurity(state, value) {
    state.userSeciurity = value;
  },
  setUserProfile(state, value) {
    state.userProfile = value;
  },
  setDiary(state, value) {
    state.diary = value;
  },
  setDiarySum(state, value) {
    state.diarySum = value;
  }
};
export default mutations;
