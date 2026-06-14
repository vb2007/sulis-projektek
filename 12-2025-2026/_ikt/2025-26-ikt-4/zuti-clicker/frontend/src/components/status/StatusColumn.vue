<script setup lang="ts">
import { computed } from "vue";
import { useI18n } from "vue-i18n";
import { useGameStore } from "@/stores/gameStore";
import { formatNumber, formatRate, formatTime } from "@/utils/formatters";
import StatItem from "./StatItem.vue";

const { t } = useI18n();
const game = useGameStore();

const stats = computed(() => [
  {
    label: t("status.perSecond"),
    value: `${formatRate(game.tokensPerSecond)}/s`,
    primary: false
  },
  { label: t("status.perClick"), value: `+${formatNumber(game.tokensPerClick)}`, primary: false },
  { label: t("status.totalEarned"), value: formatNumber(game.totalTokensEarned), primary: false },
  { label: t("status.totalClicks"), value: formatNumber(game.totalClicks), primary: false },
  { label: t("status.timePlayed"), value: formatTime(game.elapsedSeconds), primary: false }
]);
</script>

<template>
  <aside class="status-col">
    <div class="col-header">
      <span class="col-title">{{ t("status.title") }}</span>
    </div>

    <div class="token-hero">
      <div class="token-amount">{{ formatNumber(game.tokens) }}</div>
      <div class="token-label">{{ t("status.tokens") }}</div>
    </div>

    <div class="stats-list">
      <StatItem
        v-for="s in stats"
        :key="s.label"
        :label="s.label"
        :value="s.value"
        :primary="s.primary"
      />
    </div>
  </aside>
</template>

<style scoped>
.status-col {
  display: flex;
  flex-direction: column;
  background: var(--bg-surface);
  border-right: 1px solid var(--border);
  overflow-y: auto;
  transition:
    background var(--transition-slow),
    border-color var(--transition-slow);
  animation: slideInLeft 0.3s ease both;
}

.col-header {
  padding: 16px 14px 10px;
  border-bottom: 1px solid var(--border-subtle);
  flex-shrink: 0;
}

.col-title {
  font-size: 11px;
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 1px;
  color: var(--text-muted);
}

.token-hero {
  padding: 20px 14px 16px;
  border-bottom: 1px solid var(--border-subtle);
  flex-shrink: 0;
}

.token-amount {
  font-size: 32px;
  font-weight: 900;
  color: var(--accent);
  font-variant-numeric: tabular-nums;
  letter-spacing: -1px;
  line-height: 1.1;
  animation: countUp 0.15s ease;
}

.token-label {
  font-size: 11px;
  font-weight: 500;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.8px;
  margin-top: 4px;
}

.stats-list {
  padding: 8px;
  flex: 1;
  display: flex;
  flex-direction: column;
  gap: 1px;
}
</style>
