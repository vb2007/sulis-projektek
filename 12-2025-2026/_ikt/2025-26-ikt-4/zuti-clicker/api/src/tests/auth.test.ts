import { describe, it, beforeAll, expect } from "@jest/globals";
import request from "supertest";
import { TestData } from "../constants/test-data.js";
import { Responses } from "../constants/responses.js";

const api = request(TestData.BASE_URL);

async function loginAndGetCookie(email: string, password: string): Promise<string> {
  const res = await api.post("/auth/login").send({ email, password });
  const rawHeader = (res.headers["set-cookie"] as string[])[0];
  return rawHeader.split(";")[0]; // strip attributes, keep name=value
}

describe("POST /auth/register", () => {
  const user = TestData.generateUser();

  it("registers a new user and returns 201 with a userId", async () => {
    const res = await api.post("/auth/register").send(user);
    expect(res.status).toBe(201);
    expect(res.body.message).toBe(Responses.AUTH.REGISTER_SUCCESS.body.message);
    expect(typeof res.body.userId).toBe("number");
  });

  it("returns 400 when required fields are missing", async () => {
    const res = await api.post("/auth/register").send({ username: "onlythis" });
    expect(res.status).toBe(400);
    expect(res.body.error).toBe(Responses.AUTH.MISSING_REGISTER_FIELDS.body.error);
  });

  it("returns 409 when the email is already taken", async () => {
    const res = await api
      .post("/auth/register")
      .send({ ...user, username: "definitely_unique_xyz" });
    expect(res.status).toBe(409);
    expect(res.body.error).toBe(Responses.AUTH.EMAIL_EXISTS.body.error);
  });

  it("returns 409 when the username is already taken", async () => {
    const other = TestData.generateUser();
    const res = await api.post("/auth/register").send({ ...other, username: user.username });
    expect(res.status).toBe(409);
    expect(res.body.error).toBe(Responses.AUTH.USERNAME_EXISTS.body.error);
  });
});

describe("POST /auth/login", () => {
  const user = TestData.generateUser();

  beforeAll(async () => {
    await api.post("/auth/register").send(user);
  });

  it("logs in successfully and sets the AUTH_TOKEN cookie", async () => {
    const res = await api.post("/auth/login").send({ email: user.email, password: user.password });
    expect(res.status).toBe(200);
    expect(res.body.message).toBe(Responses.AUTH.LOGIN_SUCCESS.body.message);
    expect(res.headers["set-cookie"]).toBeDefined();
  });

  it("returns 400 when required fields are missing", async () => {
    const res = await api.post("/auth/login").send({ email: user.email });
    expect(res.status).toBe(400);
    expect(res.body.error).toBe(Responses.AUTH.MISSING_LOGIN_FIELDS.body.error);
  });

  it("returns 401 for a wrong password", async () => {
    const res = await api
      .post("/auth/login")
      .send({ email: user.email, password: "wrong_password" });
    expect(res.status).toBe(401);
    expect(res.body.error).toBe(Responses.AUTH.INVALID_CREDENTIALS.body.error);
  });

  it("returns 401 for an email that is not registered", async () => {
    const res = await api
      .post("/auth/login")
      .send({ email: "nobody_xyz@example.com", password: "pass" });
    expect(res.status).toBe(401);
    expect(res.body.error).toBe(Responses.AUTH.INVALID_CREDENTIALS.body.error);
  });
});

describe("GET /auth/me", () => {
  const user = TestData.generateUser();
  let cookie: string;

  beforeAll(async () => {
    await api.post("/auth/register").send(user);
    cookie = await loginAndGetCookie(user.email, user.password);
  });

  it("returns the current user when authenticated", async () => {
    const res = await api.get("/auth/me").set("Cookie", cookie);
    expect(res.status).toBe(200);
    expect(res.body.user.username).toBe(user.username);
    expect(res.body.user.email).toBe(user.email);
    expect(typeof res.body.user.id).toBe("number");
  });

  it("returns 401 without a session cookie", async () => {
    const res = await api.get("/auth/me");
    expect(res.status).toBe(401);
    expect(res.body.error).toBe(Responses.AUTH.UNAUTHORIZED.body.error);
  });
});

describe("POST /auth/logout", () => {
  const user = TestData.generateUser();
  let cookie: string;

  beforeAll(async () => {
    await api.post("/auth/register").send(user);
    cookie = await loginAndGetCookie(user.email, user.password);
  });

  it("returns 401 without a session cookie", async () => {
    const res = await api.post("/auth/logout");
    expect(res.status).toBe(401);
  });

  it("logs out successfully and returns 200", async () => {
    const res = await api.post("/auth/logout").set("Cookie", cookie);
    expect(res.status).toBe(200);
    expect(res.body.message).toBeDefined();
  });

  it("invalidates the session — GET /auth/me returns 401 with the old cookie", async () => {
    const res = await api.get("/auth/me").set("Cookie", cookie);
    expect(res.status).toBe(401);
  });
});
