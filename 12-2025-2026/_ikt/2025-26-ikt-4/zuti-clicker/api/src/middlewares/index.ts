import express from "express";
import { getUserBySessionToken } from "../database/models/user";
import { Responses } from "../constants/responses";

export const isAuthenticated = async (
  req: express.Request,
  res: express.Response,
  next: express.NextFunction
) => {
  try {
    const sessionToken: string | undefined = req.cookies["AUTH_TOKEN"];

    if (!sessionToken) {
      const r = Responses.AUTH.UNAUTHORIZED;
      res.status(r.status).json(r.body);
      return;
    }

    const authRecord = await getUserBySessionToken(sessionToken);

    if (!authRecord) {
      const r = Responses.AUTH.UNAUTHORIZED;
      res.status(r.status).json(r.body);
      return;
    }

    req.identity = authRecord.user;
    next();
  } catch (error) {
    console.error("Auth middleware error:", error);
    const r = Responses.AUTH.INTERNAL_ERROR;
    res.status(r.status).json(r.body);
  }
};
