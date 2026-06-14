import express from "express";

import authentication from "./authentication";
import save from "./save";

const router = express.Router();

export default (): express.Router => {
  authentication(router);
  save(router);

  return router;
};
