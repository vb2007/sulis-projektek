<script setup lang="ts">
defineProps<{ x: number; y: number; amount: number }>();
</script>

<template>
  <div class="float-num" :style="{ left: `${x}px`, top: `${y}px` }">+{{ amount }}</div>
</template>

<style scoped>
.float-num {
  position: fixed;
  pointer-events: none;
  z-index: 200;
  font-size: 22px;
  font-weight: 900;
  color: var(--accent-text);
  text-shadow: 0 0 12px var(--accent-glow);
  animation: floatUp 0.75s ease-out forwards;
  white-space: nowrap;
  user-select: none;
}
</style>
