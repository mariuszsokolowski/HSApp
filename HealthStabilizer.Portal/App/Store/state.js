const state = {
  authToken: localStorage.getItem("authToken") || "",
  food: [""],
  userGoals: [""],
  userSeciurity: [""],
  userProfile: [""],
  diary: [""],
  diarySum: [""]
};

export default state;
