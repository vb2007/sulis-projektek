import express from "express";

import { register, login, me, logout } from "../controllers/auth";
import { isAuthenticated } from "../middlewares/index";

export default (router: express.Router) => {
  router.post("/auth/register", register);
  router.post("/auth/login", login);
  router.get("/auth/me", isAuthenticated, me);
  router.post("/auth/logout", isAuthenticated, logout);
};
