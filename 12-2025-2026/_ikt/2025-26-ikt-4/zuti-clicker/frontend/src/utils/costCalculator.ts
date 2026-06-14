import type { UnitDefinition } from "@/types";

export function getUnitCost(unit: UnitDefinition, owned: number): number {
  return unit.baseCost * Math.pow(unit.costGrowth, owned);
}

export function getBulkCost(unit: UnitDefinition, owned: number, amount: number): number {
  if (amount <= 0) return 0;
  const { baseCost, costGrowth } = unit;
  //geometric series: baseCost * growth^owned * (growth^amount - 1) / (growth - 1)
  return (
    (baseCost * Math.pow(costGrowth, owned) * (Math.pow(costGrowth, amount) - 1)) / (costGrowth - 1)
  );
}

export function getMaxBuyable(unit: UnitDefinition, owned: number, tokens: number): number {
  const firstCost = getUnitCost(unit, owned);
  if (tokens < firstCost) return 0;
  const { baseCost, costGrowth } = unit;
  const n = Math.floor(
    Math.log(1 + (tokens * (costGrowth - 1)) / (baseCost * Math.pow(costGrowth, owned))) /
      Math.log(costGrowth)
  );
  //float correction: makes sure total cost doesn't exceed tokens
  if (getBulkCost(unit, owned, n) > tokens) return n - 1;
  return n;
}
