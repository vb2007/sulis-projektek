<script setup lang="ts">
import { ref } from "vue";
import { useI18n } from "vue-i18n";
import { useGameStore } from "@/stores/gameStore";
import { formatRate } from "@/utils/formatters";
import ClickerCircle from "./ClickerCircle.vue";
import FloatingNumber from "./FloatingNumber.vue";

const { t } = useI18n();
const game = useGameStore();

interface FloatEntry {
  id: number;
  x: number;
  y: number;
  amount: number;
}

const floats = ref<FloatEntry[]>([]);
let uid = 0;

function onCircleClick(e: MouseEvent) {
  const earned = game.clickToken();
  const id = uid++;
  floats.value.push({
    id,
    x: e.clientX + (Math.random() * 36 - 18),
    y: e.clientY - 16,
    amount: earned
  });
  setTimeout(() => {
    const i = floats.value.findIndex((f) => f.id === id);
    if (i !== -1) floats.value.splice(i, 1);
  }, 780);
}
</script>

<template>
  <main class="clicker-area">
    <div class="glow-bg" aria-hidden="true"></div>

    <div class="clicker-content">
      <ClickerCircle @click="onCircleClick" />

      <p class="hint">{{ t("clicker.hint") }}</p>

      <Transition name="tps-fade">
        <div v-if="game.tokensPerSecond > 0" class="tps-pill">
          <span class="tps-val">{{ formatRate(game.tokensPerSecond) }}</span>
          <span class="tps-unit">/s</span>
        </div>
      </Transition>
    </div>

    <Teleport to="body">
      <FloatingNumber v-for="f in floats" :key="f.id" :x="f.x" :y="f.y" :amount="f.amount" />
    </Teleport>
  </main>
</template>

<style scoped>
.clicker-area {
  position: relative;
  display: flex;
  align-items: center;
  justify-content: center;
  background: var(--bg-base);
  overflow: hidden;
  transition: background var(--transition-slow);
}

.glow-bg {
  position: absolute;
  inset: 0;
  background: radial-gradient(ellipse 55% 45% at 50% 50%, var(--accent-glow), transparent 70%);
  pointer-events: none;
  opacity: 0.35;
}

.clicker-content {
  display: flex;
  flex-direction: column;
  align-items: center;
  gap: 22px;
  position: relative;
  z-index: 1;
}

.hint {
  font-size: 13px;
  color: var(--text-muted);
  font-weight: 500;
  letter-spacing: 0.2px;
  user-select: none;
}

.tps-pill {
  display: flex;
  align-items: baseline;
  gap: 3px;
  background: var(--bg-surface);
  border: 1px solid var(--border);
  border-radius: var(--radius-full);
  padding: 5px 16px;
}

.tps-val {
  font-size: 15px;
  font-weight: 800;
  color: var(--accent);
  font-variant-numeric: tabular-nums;
}

.tps-unit {
  font-size: 11px;
  color: var(--text-secondary);
  font-weight: 500;
}

.tps-fade-enter-active,
.tps-fade-leave-active {
  transition:
    opacity 0.3s ease,
    transform 0.3s ease;
}
.tps-fade-enter-from,
.tps-fade-leave-to {
  opacity: 0;
  transform: translateY(6px);
}
</style>
