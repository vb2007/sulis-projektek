import express from "express";

//other endpoint categories

const router: express.Router = express.Router();

export default (): express.Router => {
  return router;
};
