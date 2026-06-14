<script setup lang="ts">
import { useI18n } from "vue-i18n";
import type { Multiplier } from "@/types";

const { t } = useI18n();

defineProps<{ modelValue: Multiplier }>();
const emit = defineEmits<{ "update:modelValue": [v: Multiplier] }>();

const OPTIONS: Multiplier[] = [1, 5, 10, 50, "max"];

function label(m: Multiplier): string {
  return m === "max" ? t("units.multipliers.max") : `${m}×`;
}
</script>

<template>
  <div class="mult-sel" role="group">
    <button
      v-for="opt in OPTIONS"
      :key="opt"
      class="mult-btn"
      :class="{ active: modelValue === opt }"
      @click="emit('update:modelValue', opt)"
    >
      {{ label(opt) }}
    </button>
  </div>
</template>

<style scoped>
.mult-sel {
  display: flex;
  gap: 4px;
  padding: 10px 12px;
}

.mult-btn {
  flex: 1;
  padding: 5px 2px;
  border-radius: var(--radius-xs);
  border: 1px solid var(--border);
  background: var(--bg-elevated);
  color: var(--text-secondary);
  font-size: 11px;
  font-weight: 700;
  letter-spacing: 0.2px;
  transition: all var(--transition-fast);
}

.mult-btn:hover {
  border-color: var(--accent);
  color: var(--accent-text);
  background: var(--bg-hover);
}

.mult-btn.active {
  background: var(--accent);
  border-color: var(--accent);
  color: #fff;
}
</style>
