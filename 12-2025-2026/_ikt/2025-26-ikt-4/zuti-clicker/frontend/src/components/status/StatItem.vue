<script setup lang="ts">
defineProps<{
  label: string;
  value: string;
  primary?: boolean;
}>();
</script>

<template>
  <div class="stat-item" :class="{ primary }">
    <span class="stat-label">{{ label }}</span>
    <span class="stat-value">{{ value }}</span>
  </div>
</template>

<style scoped>
.stat-item {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 9px 14px;
  border-radius: var(--radius-sm);
  transition: background var(--transition-fast);
}

.stat-item:hover {
  background: var(--bg-elevated);
}

.stat-label {
  font-size: 11px;
  font-weight: 500;
  color: var(--text-muted);
  text-transform: uppercase;
  letter-spacing: 0.6px;
}

.stat-value {
  font-size: 14px;
  font-weight: 700;
  color: var(--text-primary);
  font-variant-numeric: tabular-nums;
  letter-spacing: -0.3px;
}

.primary .stat-label {
  color: var(--text-secondary);
}
.primary .stat-value {
  color: var(--accent-text);
  font-size: 16px;
}
</style>
