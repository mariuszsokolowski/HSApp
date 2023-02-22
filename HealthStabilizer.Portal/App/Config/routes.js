import Home from "../Components/Home/Home.vue";
import Diary from "../Components/Diary/Diary.vue";
import FoodDialog from "../Components/Food/FoodDialog.vue";
import Login from "../Components/Account/Login.vue";
import Logout from "../Components/Account/Logout.vue";
import Register from "../Components/Account/Register.vue";
import Account from "../Components/Account/Account.vue";

const routes = [
  { path: "/", component: Home, meta: { requiresAuth: true } },
  { path: "/Diary", component: Diary, meta: { requiresAuth: true } },
  { path: "/Login", component: Login },
  { path: "/Logout", component: Logout },
  { path: "/Register", component: Register },
  { path: "/Account", component: Account }
];
export default routes;
