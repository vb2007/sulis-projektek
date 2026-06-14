export class ApiError extends Error {
  constructor(
    public readonly status: number,
    message: string
  ) {
    super(message);
    this.name = "ApiError";
  }
}

// Dev: Vite proxy rewrites /api → http://localhost:2710 (vite.config.ts).
// Production: VITE_API_BASE_URL is baked in at build time by the Dockerfile.
const BASE = (import.meta.env.VITE_API_BASE_URL as string | undefined) ?? "/api";

async function request<T>(method: string, path: string, body?: unknown): Promise<T> {
  const headers: Record<string, string> = {};
  if (body !== undefined) headers["Content-Type"] = "application/json";

  const res = await fetch(BASE + path, {
    method,
    credentials: "include",
    headers,
    body: body !== undefined ? JSON.stringify(body) : undefined
  });

  const data = (await res.json()) as { error?: string } & T;
  if (!res.ok) {
    throw new ApiError(res.status, data.error ?? `HTTP ${res.status}`);
  }
  return data;
}

export interface RegisterResponse {
  message: string;
  userId: number;
}
export interface LoginResponse {
  message: string;
}
export interface LogoutResponse {
  message: string;
}
export interface MeResponse {
  user: { id: number; username: string; email: string };
}

export interface UnitEntry {
  unitId: string;
  owned: number;
}

export interface SavePayload {
  tokens: number;
  totalTokensEarned: number;
  totalClicks: number;
  elapsedSeconds: number;
  units: UnitEntry[];
}

export interface SaveData extends SavePayload {
  savedAt: string;
}
export interface LoadSaveResponse {
  save: SaveData | null;
}
export interface StoreSaveResponse {
  message: string;
  savedAt: string;
}
export interface ResetSaveResponse {
  message: string;
}

export const api = {
  auth: {
    register: (username: string, email: string, password: string) =>
      request<RegisterResponse>("POST", "/auth/register", { username, email, password }),
    login: (email: string, password: string) =>
      request<LoginResponse>("POST", "/auth/login", { email, password }),
    logout: () => request<LogoutResponse>("POST", "/auth/logout"),
    me: () => request<MeResponse>("GET", "/auth/me")
  },
  save: {
    load: () => request<LoadSaveResponse>("GET", "/save"),
    store: (payload: SavePayload) => request<StoreSaveResponse>("PUT", "/save", payload),
    reset: () => request<ResetSaveResponse>("DELETE", "/save")
  }
};
