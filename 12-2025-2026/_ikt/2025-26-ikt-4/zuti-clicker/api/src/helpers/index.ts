import crypto from "crypto";
import dotenv from "dotenv";

dotenv.config();

const SECRET: crypto.BinaryLike = process.env.CRYPTO_SECRET_KEY!;

export const random = (): string => crypto.randomBytes(128).toString("base64");
export const authentication = (salt: string, password: string): string => {
  return crypto.createHmac("sha256", [salt, password].join("/")).update(SECRET).digest("hex");
};
