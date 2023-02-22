import API from "../Config/API";
import axios from "axios";

const actions = {
  login(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .post(API.Account + "Login", payload)
        .then(response => {
          context.commit("setAuthToken", response.data);

          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject(error);
        });
    });
  },

  logout(context) {
    return new Promise((resolve, reject) => {
      axios
        .post(API.Account + "Logout")
        .then(response => {
          context.commit("removeAuthToken");
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },

  getFood(context) {
    return new Promise((resolve, reject) => {
      axios
        .get(API.Food)
        .then(response => {
          context.commit("setFood", response.data);
          resolve(response.data);
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },

  getUserGoals(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .get(API.Goals + "?date=" + payload)
        .then(response => {
          context.commit("setUserGoals", response.data);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  setUserGoals(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .put(API.Goals + payload.goalsId, payload)
        .then(response => {
          context.commit("setUserGoals", payload);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  getUserSeciurity(context) {
    return new Promise((resolve, reject) => {
      axios
        .get(API.User + "Seciurity/")
        .then(response => {
          context.commit("setUserSeciurity", response.data);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  setUserSeciurity(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .put(API.User + "Seciurity/" + payload.userId, payload)
        .then(response => {
          context.commit("setUserSeciurity", payload);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  getUserProfile(context) {
    return new Promise((resolve, reject) => {
      axios
        .get(API.User + "Profile/")
        .then(response => {
          context.commit("setUserProfile", response.data);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  setUserProfile(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .put(API.User + "Profile/" + payload.userId, payload)
        .then(response => {
          context.commit("setUserProfile", payload);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  getDiary(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .get(API.Diary + "?date=" + payload)
        .then(response => {
          context.commit("setDiary", response.data);
          resolve(response.data);
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  getDiarySum(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .get(API.Diary + "GetSum/?date=" + payload)
        .then(response => {
          context.commit("setDiarySum", response.data);
          resolve(response.data);
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  addFoodsToDiary(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .post(`${API.Diary}${payload.Date}`, payload.Foods)
        .then(response => {
          context.commit("setDiary", payload);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  removeFromDiary(context, payload) {
    return new Promise((resolve, reject) => {
      axios
        .delete(`${API.Diary}${payload}`)
        .then(response => {
          // context.commit("setDiary", payload);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  },
  updateQuantityInDiary(context, payload) {
    return new Promise((resolve, reject) => {
      console.log("payload");
      console.log(payload);
      axios
        .put(`${API.Diary}${payload.diaryId}`, payload)
        .then(response => {
          context.commit("setDiary", payload);
          resolve();
        })
        .catch(function(error) {
          console.error(error);
          reject();
        });
    });
  }
};
export default actions;
