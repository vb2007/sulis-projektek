<script setup lang="ts">
import { ref } from "vue";
import { useI18n } from "vue-i18n";
import { UNIT_DEFINITIONS } from "@/utils/gameConstants";
import MultiplierSelector from "./MultiplierSelector.vue";
import UnitCard from "./UnitCard.vue";
import type { Multiplier } from "@/types";

const { t } = useI18n();
const multiplier = ref<Multiplier>(1);
</script>

<template>
  <aside class="units-panel">
    <div class="panel-header">
      <span class="panel-title">{{ t("units.title") }}</span>
    </div>

    <MultiplierSelector v-model="multiplier" />

    <div class="units-list">
      <UnitCard
        v-for="unit in UNIT_DEFINITIONS"
        :key="unit.id"
        :unit-id="unit.id"
        :multiplier="multiplier"
      />
    </div>
  </aside>
</template>

<style scoped>
.units-panel {
  display: flex;
  flex-direction: column;
  background: var(--bg-surface);
  border-left: 1px solid var(--border);
  overflow: hidden;
  transition:
    background var(--transition-slow),
    border-color var(--transition-slow);
  animation: slideInRight 0.3s ease both;
}

.panel-header {
  padding: 16px 14px 10px;
  border-bottom: 1px solid var(--border-subtle);
  flex-shrink: 0;
}

.panel-title {
  font-size: 11px;
  font-weight: 600;
  text-transform: uppercase;
  letter-spacing: 1px;
  color: var(--text-muted);
}

.units-list {
  flex: 1;
  overflow-y: auto;
}
</style>
