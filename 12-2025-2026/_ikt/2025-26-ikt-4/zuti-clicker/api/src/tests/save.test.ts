import { describe, it, beforeAll, expect } from "@jest/globals";
import request from "supertest";
import { TestData } from "../constants/test-data.js";
import { Responses } from "../constants/responses.js";

const api = request(TestData.BASE_URL);

describe("Save endpoints - unauthenticated", () => {
  it("GET /save returns 401", async () => {
    const res = await api.get("/save");
    expect(res.status).toBe(401);
    expect(res.body.error).toBe(Responses.AUTH.UNAUTHORIZED.body.error);
  });

  it("PUT /save returns 401", async () => {
    const res = await api.put("/save").send(TestData.VALID_SAVE);
    expect(res.status).toBe(401);
    expect(res.body.error).toBe(Responses.AUTH.UNAUTHORIZED.body.error);
  });

  it("DELETE /save returns 401", async () => {
    const res = await api.delete("/save");
    expect(res.status).toBe(401);
    expect(res.body.error).toBe(Responses.AUTH.UNAUTHORIZED.body.error);
  });
});

describe("Save endpoints - authenticated", () => {
  let cookie: string;

  beforeAll(async () => {
    const user = TestData.generateUser();
    await api.post("/auth/register").send(user);
    const loginRes = await api
      .post("/auth/login")
      .send({ email: user.email, password: user.password });
    const rawHeader = (loginRes.headers["set-cookie"] as string[])[0];
    cookie = rawHeader.split(";")[0];
  });

  it("GET /save returns null when no save exists yet", async () => {
    const res = await api.get("/save").set("Cookie", cookie);
    expect(res.status).toBe(200);
    expect(res.body.save).toBeNull();
  });

  it("PUT /save returns 400 when required fields are missing", async () => {
    const res = await api.put("/save").set("Cookie", cookie).send(TestData.SAVE_MISSING_FIELDS);
    expect(res.status).toBe(400);
    expect(res.body.error).toBe(Responses.SAVE.MISSING_FIELDS.body.error);
  });

  it("PUT /save returns 400 when units have an invalid shape", async () => {
    const res = await api.put("/save").set("Cookie", cookie).send(TestData.SAVE_INVALID_UNITS);
    expect(res.status).toBe(400);
    expect(res.body.error).toBe(Responses.SAVE.INVALID_UNITS.body.error);
  });

  it("PUT /save creates a save and returns 200 with savedAt", async () => {
    const res = await api.put("/save").set("Cookie", cookie).send(TestData.VALID_SAVE);
    expect(res.status).toBe(200);
    expect(res.body.message).toBe(Responses.SAVE.SAVE_SUCCESS.body.message);
    expect(typeof res.body.savedAt).toBe("string");
  });

  it("GET /save returns the newly created save data", async () => {
    const res = await api.get("/save").set("Cookie", cookie);
    expect(res.status).toBe(200);
    expect(res.body.save).not.toBeNull();
    expect(res.body.save.tokens).toBe(TestData.VALID_SAVE.tokens);
    expect(res.body.save.totalTokensEarned).toBe(TestData.VALID_SAVE.totalTokensEarned);
    expect(res.body.save.totalClicks).toBe(TestData.VALID_SAVE.totalClicks);
    expect(res.body.save.elapsedSeconds).toBe(TestData.VALID_SAVE.elapsedSeconds);
    expect(res.body.save.units).toHaveLength(TestData.VALID_SAVE.units.length);
  });

  it("PUT /save overwrites the save with new data", async () => {
    const res = await api.put("/save").set("Cookie", cookie).send(TestData.UPDATED_SAVE);
    expect(res.status).toBe(200);
    expect(res.body.message).toBe(Responses.SAVE.SAVE_SUCCESS.body.message);
  });

  it("GET /save returns the updated values after overwrite", async () => {
    const res = await api.get("/save").set("Cookie", cookie);
    expect(res.status).toBe(200);
    expect(res.body.save.tokens).toBe(TestData.UPDATED_SAVE.tokens);
    expect(res.body.save.units).toHaveLength(TestData.UPDATED_SAVE.units.length);
    const alphaUnit = res.body.save.units.find((u: { unitId: string }) => u.unitId === "alpha");
    expect(alphaUnit?.owned).toBe(TestData.UPDATED_SAVE.units[0].owned);
  });

  it("DELETE /save resets the save and returns 200", async () => {
    const res = await api.delete("/save").set("Cookie", cookie);
    expect(res.status).toBe(200);
    expect(res.body.message).toBe(Responses.SAVE.RESET_SUCCESS.body.message);
  });

  it("DELETE /save is idempotent — returns 200 even when no save exists", async () => {
    const res = await api.delete("/save").set("Cookie", cookie);
    expect(res.status).toBe(200);
  });

  it("GET /save returns null after the save was deleted", async () => {
    const res = await api.get("/save").set("Cookie", cookie);
    expect(res.status).toBe(200);
    expect(res.body.save).toBeNull();
  });
});
