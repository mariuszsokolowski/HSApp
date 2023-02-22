import API from "../../Config/API";
import axios from "axios";

export default {
  getDiary(context) {
    return new Promise((resolve, reject) => {
      axios
        .get(API.Diary)
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
