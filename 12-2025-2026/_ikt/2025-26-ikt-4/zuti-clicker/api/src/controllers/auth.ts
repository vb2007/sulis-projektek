import express from "express";
import { random, authentication } from "../helpers/index";
import {
  getUserByEmail,
  getUserByUsername,
  createUser,
  updateSessionToken
} from "../database/models/user";
import { Responses } from "../constants/responses";

/**
 * @openapi
 * /auth/me:
 *   get:
 *     tags: [Auth]
 *     summary: Get the currently authenticated user
 *     security:
 *       - cookieAuth: []
 *     responses:
 *       '200':
 *         description: Authenticated user info
 *         content:
 *           application/json:
 *             schema:
 *               type: object
 *               properties:
 *                 user:
 *                   type: object
 *                   properties:
 *                     id: { type: integer, example: 1 }
 *                     username: { type: string, example: johndoe }
 *                     email: { type: string, example: john@example.com }
 *       '401':
 *         $ref: '#/components/responses/Unauthorized'
 */
export const me = async (req: express.Request, res: express.Response) => {
  const identity = req.identity!;
  res.status(200).json({
    user: { id: identity.id, username: identity.username, email: identity.email }
  });
};

/**
 * @openapi
 * /auth/logout:
 *   post:
 *     tags: [Auth]
 *     summary: Log out the current user (clears the session cookie)
 *     security:
 *       - cookieAuth: []
 *     responses:
 *       '200':
 *         description: Logged out successfully
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/MessageResponse'
 *       '401':
 *         $ref: '#/components/responses/Unauthorized'
 */
export const logout = async (req: express.Request, res: express.Response) => {
  try {
    await updateSessionToken(req.identity!.id, "");
    res.clearCookie("AUTH_TOKEN", {
      httpOnly: true,
      secure: process.env.NODE_ENV === "production",
      sameSite: "strict"
    });
    res.status(200).json({ message: "Logged out successfully." });
  } catch (error) {
    console.error("Logout error:", error);
    const r = Responses.AUTH.INTERNAL_ERROR;
    res.status(r.status).json(r.body);
  }
};

/**
 * @openapi
 * /auth/register:
 *   post:
 *     tags:
 *       - Auth
 *     summary: Register a new user
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/RegisterRequest'
 *     responses:
 *       '201':
 *         description: User registered successfully
 *         content:
 *           application/json:
 *             schema:
 *               allOf:
 *                 - $ref: '#/components/schemas/MessageResponse'
 *                 - type: object
 *                   properties:
 *                     userId:
 *                       type: integer
 *                       example: 1
 *       '400':
 *         description: Missing required fields
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/ErrorResponse'
 *             example:
 *               error: username, email, and password are required
 *       '409':
 *         description: Email or username already in use
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/ErrorResponse'
 *             example:
 *               error: A user with that email already exists
 *       '500':
 *         description: Internal server error
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/ErrorResponse'
 */
export const register = async (req: express.Request, res: express.Response) => {
  try {
    const { username, email, password } = req.body as {
      username?: string;
      email?: string;
      password?: string;
    };

    if (!username || !email || !password) {
      const r = Responses.AUTH.MISSING_REGISTER_FIELDS;
      res.status(r.status).json(r.body);
      return;
    }

    const [existingEmail, existingUsername] = await Promise.all([
      getUserByEmail(email),
      getUserByUsername(username)
    ]);

    if (existingEmail) {
      const r = Responses.AUTH.EMAIL_EXISTS;
      res.status(r.status).json(r.body);
      return;
    }

    if (existingUsername) {
      const r = Responses.AUTH.USERNAME_EXISTS;
      res.status(r.status).json(r.body);
      return;
    }

    const salt = random();
    const hashedPassword = authentication(salt, password);

    const user = await createUser({ username, email, password: hashedPassword, salt });

    const r = Responses.AUTH.REGISTER_SUCCESS;
    res.status(r.status).json({ ...r.body, userId: user.id });
  } catch (error) {
    console.error("Register error:", error);
    const r = Responses.AUTH.INTERNAL_ERROR;
    res.status(r.status).json(r.body);
  }
};

/**
 * @openapi
 * /auth/login:
 *   post:
 *     tags:
 *       - Auth
 *     summary: Log in with email and password
 *     requestBody:
 *       required: true
 *       content:
 *         application/json:
 *           schema:
 *             $ref: '#/components/schemas/LoginRequest'
 *     responses:
 *       '200':
 *         description: Login successful. Sets the AUTH_TOKEN cookie.
 *         headers:
 *           Set-Cookie:
 *             schema:
 *               type: string
 *               example: AUTH_TOKEN=abc123; HttpOnly; SameSite=Strict; Max-Age=604800
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/MessageResponse'
 *             example:
 *               message: Login successful
 *       '400':
 *         description: Missing required fields
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/ErrorResponse'
 *             example:
 *               error: email and password are required
 *       '401':
 *         description: Invalid credentials
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/ErrorResponse'
 *             example:
 *               error: Invalid credentials
 *       '500':
 *         description: Internal server error
 *         content:
 *           application/json:
 *             schema:
 *               $ref: '#/components/schemas/ErrorResponse'
 */
export const login = async (req: express.Request, res: express.Response) => {
  try {
    const { email, password } = req.body as { email?: string; password?: string };

    if (!email || !password) {
      const r = Responses.AUTH.MISSING_LOGIN_FIELDS;
      res.status(r.status).json(r.body);
      return;
    }

    const user = await getUserByEmail(email);

    if (!user || !user.authentication) {
      const r = Responses.AUTH.INVALID_CREDENTIALS;
      res.status(r.status).json(r.body);
      return;
    }

    const expectedHash = authentication(user.authentication.salt, password);
    if (user.authentication.password !== expectedHash) {
      const r = Responses.AUTH.INVALID_CREDENTIALS;
      res.status(r.status).json(r.body);
      return;
    }

    const sessionSalt = random();
    const sessionToken = authentication(sessionSalt, user.id.toString());

    await updateSessionToken(user.id, sessionToken);

    res.cookie("AUTH_TOKEN", sessionToken, {
      httpOnly: true,
      secure: process.env.NODE_ENV === "production",
      sameSite: "strict",
      maxAge: 1000 * 60 * 60 * 24 * 7 // 7 days
    });

    const r = Responses.AUTH.LOGIN_SUCCESS;
    res.status(r.status).json(r.body);
  } catch (error) {
    console.error("Login error:", error);
    const r = Responses.AUTH.INTERNAL_ERROR;
    res.status(r.status).json(r.body);
  }
};
