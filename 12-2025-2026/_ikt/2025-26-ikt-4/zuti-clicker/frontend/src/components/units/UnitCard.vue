<script setup lang="ts">
import { computed, ref } from "vue";
import { useI18n } from "vue-i18n";
import { useGameStore } from "@/stores/gameStore";
import { UNIT_DEFINITIONS } from "@/utils/gameConstants";
import { getMaxBuyable } from "@/utils/costCalculator";
import { formatNumber, formatRate } from "@/utils/formatters";
import type { Multiplier } from "@/types";

const props = defineProps<{ unitId: string; multiplier: Multiplier }>();

const { t } = useI18n();
const game = useGameStore();

const def = computed(() => UNIT_DEFINITIONS.find((d) => d.id === props.unitId)!);
const state = computed(() => game.unitStates.find((u) => u.id === props.unitId)!);
const owned = computed(() => state.value?.owned ?? 0);

const effectiveAmount = computed(() => {
  if (!def.value) return 0;
  if (props.multiplier === "max") return getMaxBuyable(def.value, owned.value, game.tokens);
  return props.multiplier;
});

const cost = computed(() => game.getBuyCost(props.unitId, props.multiplier));
const affordable = computed(() => game.canAfford(props.unitId, props.multiplier));
const gainPerS = computed(() => game.getProductionGain(props.unitId, props.multiplier));

const unitIdx = computed(() => UNIT_DEFINITIONS.findIndex((d) => d.id === props.unitId));

const visible = computed(() => {
  if (unitIdx.value === 0) return true;
  return game.totalTokensEarned >= (def.value?.baseCost ?? Infinity) * 0.1;
});

const nameKey = computed(() => `units.names.${props.unitId}` as Parameters<typeof t>[0]);
const descKey = computed(() => `units.descriptions.${props.unitId}` as Parameters<typeof t>[0]);

function buy() {
  if (!affordable.value || effectiveAmount.value === 0) return;
  game.buyUnit(props.unitId, props.multiplier);
}

const hovered = ref(false);

const btnLabel = computed(() => {
  if (props.multiplier === "max") {
    return effectiveAmount.value > 0 ? `×${effectiveAmount.value}` : "—";
  }
  return `×${props.multiplier}`;
});
</script>

<template>
  <Transition name="unit-appear">
    <div
      v-if="visible"
      class="unit-card"
      :class="{ affordable }"
      @mouseenter="hovered = true"
      @mouseleave="hovered = false"
    >
      <!-- left: info -->
      <div class="unit-info">
        <div class="unit-name">{{ t(nameKey) }}</div>
        <div class="unit-sub">
          <span class="owned-count">{{ owned }}</span>
          <span class="owned-label"> {{ t("units.owned") }}</span>
          <span class="prod-badge">{{ formatRate(def?.baseProduction ?? 0) }}/s</span>
        </div>
      </div>

      <!-- right: buy button -->
      <button class="buy-btn" :disabled="!affordable || effectiveAmount === 0" @click.stop="buy">
        <span class="btn-mult">{{ btnLabel }}</span>
        <span class="btn-cost">{{ formatNumber(cost) }}</span>
      </button>

      <!-- tooltip -->
      <Transition name="tip">
        <div v-if="hovered" class="tooltip">
          <div class="tip-name">{{ t(nameKey) }}</div>
          <div class="tip-desc">{{ t(descKey) }}</div>
          <div class="tip-divider"></div>
          <div class="tip-row">
            <span>{{ t("units.tooltipCost") }}</span>
            <span class="tip-val">{{ formatNumber(cost) }}</span>
          </div>
          <div v-if="effectiveAmount > 0" class="tip-row">
            <span>{{ t("units.tooltipGain") }}</span>
            <span class="tip-val accent">+{{ formatRate(gainPerS) }}/s</span>
          </div>
          <div class="tip-row">
            <span>{{ t("units.tooltipEach") }}</span>
            <span class="tip-val">{{ formatRate(def?.baseProduction ?? 0) }}/s</span>
          </div>
        </div>
      </Transition>
    </div>
  </Transition>
</template>

<style scoped>
.unit-card {
  position: relative;
  display: flex;
  align-items: center;
  gap: 10px;
  padding: 11px 14px;
  border-bottom: 1px solid var(--border-subtle);
  transition: background var(--transition-fast);
}

.unit-card:hover {
  background: var(--bg-elevated);
}

.unit-card.affordable {
  border-left: 2px solid var(--accent);
}

.unit-card.affordable:hover {
  background: var(--bg-hover);
}

/* info */
.unit-info {
  flex: 1;
  min-width: 0;
}

.unit-name {
  font-size: 13px;
  font-weight: 700;
  color: var(--text-primary);
  white-space: nowrap;
  overflow: hidden;
  text-overflow: ellipsis;
}

.unit-sub {
  display: flex;
  align-items: center;
  gap: 4px;
  margin-top: 2px;
}

.owned-count {
  font-size: 12px;
  font-weight: 800;
  color: var(--accent-text);
  font-variant-numeric: tabular-nums;
}

.owned-label {
  font-size: 11px;
  color: var(--text-muted);
}

.prod-badge {
  margin-left: 4px;
  font-size: 10px;
  font-weight: 600;
  color: var(--text-muted);
  background: var(--bg-elevated);
  border: 1px solid var(--border-subtle);
  border-radius: var(--radius-full);
  padding: 1px 6px;
}

/* buy button */
.buy-btn {
  display: flex;
  flex-direction: column;
  align-items: center;
  min-width: 68px;
  padding: 6px 10px;
  border-radius: var(--radius-sm);
  background: var(--btn-buy-bg);
  color: var(--btn-buy-text);
  transition: all var(--transition-fast);
  flex-shrink: 0;
}

.buy-btn:hover:not(:disabled) {
  filter: brightness(1.15);
  transform: translateY(-1px);
  box-shadow: 0 4px 14px var(--accent-glow);
}

.buy-btn:active:not(:disabled) {
  transform: translateY(0);
}

.buy-btn:disabled {
  background: var(--btn-dis-bg);
  cursor: not-allowed;
}

.btn-mult {
  font-size: 10px;
  font-weight: 700;
  opacity: 0.75;
  line-height: 1.2;
}

.buy-btn:disabled .btn-mult,
.buy-btn:disabled .btn-cost {
  color: var(--btn-dis-text);
}

.btn-cost {
  font-size: 13px;
  font-weight: 800;
  font-variant-numeric: tabular-nums;
  line-height: 1.3;
}

/* tooltip */
.tooltip {
  position: absolute;
  right: calc(100% + 10px);
  top: 50%;
  transform: translateY(-50%);
  width: 192px;
  background: var(--bg-card);
  border: 1px solid var(--border);
  border-radius: var(--radius-md);
  padding: 12px 14px;
  box-shadow: 0 8px 28px rgba(0, 0, 0, 0.35);
  z-index: 100;
  pointer-events: none;
}

.tip-name {
  font-size: 13px;
  font-weight: 700;
  color: var(--accent-text);
  margin-bottom: 4px;
}

.tip-desc {
  font-size: 11px;
  color: var(--text-secondary);
  line-height: 1.5;
  margin-bottom: 10px;
}

.tip-divider {
  height: 1px;
  background: var(--border-subtle);
  margin-bottom: 8px;
}

.tip-row {
  display: flex;
  justify-content: space-between;
  align-items: center;
  font-size: 11px;
  color: var(--text-secondary);
  margin-bottom: 5px;
}

.tip-val {
  font-weight: 700;
  color: var(--text-primary);
  font-variant-numeric: tabular-nums;
}

.tip-val.accent {
  color: var(--accent-text);
}

/* transitions */
.tip-enter-active,
.tip-leave-active {
  transition:
    opacity 0.12s ease,
    transform 0.12s ease;
}
.tip-enter-from,
.tip-leave-to {
  opacity: 0;
  transform: translateY(-50%) translateX(6px);
}

.unit-appear-enter-active {
  transition:
    opacity 0.3s ease,
    transform 0.3s ease;
}
.unit-appear-enter-from {
  opacity: 0;
  transform: translateX(12px);
}
</style>
