const getters = {
  getAuthToken: state => state.authToken,
  getConfig: state => state.config,
  isLoggedIn: state => !!state.authToken,
  getFood: state => state.food,
  getUserGoals: state => state.userGoals,
  getUserSeciurity: state => state.userSeciurity,
  getUserProfile: state => state.userProfile,
  getDiary: state => state.diary,
  getDiarySum: state => state.diarySum
};
export default getters;
