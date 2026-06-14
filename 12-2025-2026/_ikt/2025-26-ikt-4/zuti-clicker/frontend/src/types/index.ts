export interface UnitDefinition {
  id: string;
  baseCost: number;
  baseProduction: number;
  costGrowth: number;
}

export interface UnitState {
  id: string;
  owned: number;
}

export type Multiplier = 1 | 5 | 10 | 50 | "max";
export type Theme = "dark" | "light";
export type Language = "en" | "hu";

export interface AuthUser {
  id: number;
  username: string;
  email: string;
}
