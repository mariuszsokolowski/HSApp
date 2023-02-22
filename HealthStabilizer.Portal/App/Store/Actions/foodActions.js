import API from "../../Config/API";
import axios from "axios";

export default {
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
  }
};
