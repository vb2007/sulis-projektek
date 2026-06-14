import express from "express";
import { loadSave, storeSave, resetSave } from "../controllers/save";
import { isAuthenticated } from "../middlewares/index";

export default (router: express.Router) => {
  router.get("/save", isAuthenticated, loadSave);
  router.put("/save", isAuthenticated, storeSave);
  router.delete("/save", isAuthenticated, resetSave);
};
