import { defineStore } from "pinia";
import { ref, computed } from "vue";
import { UNIT_DEFINITIONS, BASE_TOKENS_PER_CLICK } from "@/utils/gameConstants";
import { getUnitCost, getBulkCost, getMaxBuyable } from "@/utils/costCalculator";
import type { UnitState, Multiplier } from "@/types";

export const useGameStore = defineStore("game", () => {
  const tokens = ref(0);
  const totalTokensEarned = ref(0);
  const totalClicks = ref(0);
  const elapsedSeconds = ref(0);

  const unitStates = ref<UnitState[]>(UNIT_DEFINITIONS.map((d) => ({ id: d.id, owned: 0 })));

  const tokensPerSecond = computed(() =>
    UNIT_DEFINITIONS.reduce((sum, def) => {
      const state = unitStates.value.find((u) => u.id === def.id);
      return sum + (state?.owned ?? 0) * def.baseProduction;
    }, 0)
  );

  const tokensPerClick = computed(() => BASE_TOKENS_PER_CLICK);

  function clickToken(): number {
    const earned = tokensPerClick.value;
    tokens.value += earned;
    totalTokensEarned.value += earned;
    totalClicks.value++;
    return earned;
  }

  function _resolveAmount(unitId: string, multiplier: Multiplier): number {
    const def = UNIT_DEFINITIONS.find((d) => d.id === unitId);
    if (!def) return 0;
    const owned = unitStates.value.find((u) => u.id === unitId)?.owned ?? 0;
    if (multiplier === "max") return getMaxBuyable(def, owned, tokens.value);
    return multiplier;
  }

  function getBuyCost(unitId: string, multiplier: Multiplier): number {
    const def = UNIT_DEFINITIONS.find((d) => d.id === unitId);
    if (!def) return 0;
    const owned = unitStates.value.find((u) => u.id === unitId)?.owned ?? 0;
    const amount = multiplier === "max" ? getMaxBuyable(def, owned, tokens.value) : multiplier;
    if (amount <= 0) return getUnitCost(def, owned);
    return getBulkCost(def, owned, amount);
  }

  function getProductionGain(unitId: string, multiplier: Multiplier): number {
    const def = UNIT_DEFINITIONS.find((d) => d.id === unitId);
    if (!def) return 0;
    const amount = _resolveAmount(unitId, multiplier);
    return amount * def.baseProduction;
  }

  function canAfford(unitId: string, multiplier: Multiplier): boolean {
    const def = UNIT_DEFINITIONS.find((d) => d.id === unitId);
    if (!def) return false;
    const owned = unitStates.value.find((u) => u.id === unitId)?.owned ?? 0;
    if (multiplier === "max") return getMaxBuyable(def, owned, tokens.value) > 0;
    return getBulkCost(def, owned, multiplier) <= tokens.value;
  }

  function buyUnit(unitId: string, multiplier: Multiplier): boolean {
    const def = UNIT_DEFINITIONS.find((d) => d.id === unitId);
    if (!def) return false;
    const state = unitStates.value.find((u) => u.id === unitId);
    if (!state) return false;
    const amount =
      multiplier === "max" ? getMaxBuyable(def, state.owned, tokens.value) : multiplier;
    if (amount <= 0) return false;
    const cost = getBulkCost(def, state.owned, amount);
    if (tokens.value < cost) return false;
    tokens.value -= cost;
    state.owned += amount;
    return true;
  }

  function tick(delta: number) {
    const earned = tokensPerSecond.value * delta;
    tokens.value += earned;
    totalTokensEarned.value += earned;
    elapsedSeconds.value += delta;
  }

  function loadFromSave(save: {
    tokens: number;
    totalTokensEarned: number;
    totalClicks: number;
    elapsedSeconds: number;
    units: { unitId: string; owned: number }[];
  }): void {
    tokens.value = save.tokens;
    totalTokensEarned.value = save.totalTokensEarned;
    totalClicks.value = save.totalClicks;
    elapsedSeconds.value = save.elapsedSeconds;
    unitStates.value.forEach((u) => { u.owned = 0; });
    for (const { unitId, owned } of save.units) {
      const state = unitStates.value.find((u) => u.id === unitId);
      if (state) state.owned = owned;
    }
  }

  function toSavePayload() {
    return {
      tokens: tokens.value,
      totalTokensEarned: totalTokensEarned.value,
      totalClicks: totalClicks.value,
      elapsedSeconds: elapsedSeconds.value,
      units: unitStates.value.map((u) => ({ unitId: u.id, owned: u.owned }))
    };
  }

  return {
    tokens,
    totalTokensEarned,
    totalClicks,
    elapsedSeconds,
    unitStates,
    tokensPerSecond,
    tokensPerClick,
    clickToken,
    getBuyCost,
    getProductionGain,
    canAfford,
    buyUnit,
    tick,
    loadFromSave,
    toSavePayload
  };
});
