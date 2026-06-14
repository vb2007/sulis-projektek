<script setup lang="ts">
import { ref } from "vue";

const emit = defineEmits<{ click: [e: MouseEvent] }>();

const active = ref(false);

function handleClick(e: MouseEvent) {
  emit("click", e);
  if (active.value) return;
  active.value = true;
  setTimeout(() => (active.value = false), 220);
}
</script>

<template>
  <div class="circle-wrap" @click="handleClick">
    <!-- pulse rings -->
    <div class="ring ring-1" :class="{ pulse: active }"></div>
    <div class="ring ring-2" :class="{ pulse: active }"></div>

    <div class="circle" :class="{ active }">
      <div class="circle-inner">
        <img src="@/assets/images/zutiy.jpg" alt="Dr. Zuti Pál, Digitális kor győztese" />
      </div>
    </div>
  </div>
</template>

<style scoped>
.circle-wrap {
  position: relative;
  width: 220px;
  height: 220px;
  cursor: pointer;
  user-select: none;
  display: flex;
  align-items: center;
  justify-content: center;
}

.circle {
  width: 200px;
  height: 200px;
  border-radius: 50%;
  background: radial-gradient(circle at 38% 38%, var(--bg-elevated), var(--bg-card));
  border: 2px solid var(--accent);
  display: flex;
  align-items: center;
  justify-content: center;
  transition:
    box-shadow var(--transition-fast),
    border-color var(--transition-fast);
  animation: breathe 3.5s ease-in-out infinite;
  position: relative;
  z-index: 1;
}

.circle-wrap:hover .circle {
  border-color: var(--accent-text);
  box-shadow:
    0 0 48px var(--accent-glow),
    0 0 80px var(--accent-glow);
}

.circle.active {
  animation: clickPop 0.22s ease both;
  box-shadow: 0 0 64px var(--accent-glow);
}

.circle-inner {
  width: 100%;
  height: 100%;
  border-radius: 50%;
  overflow: hidden;
  display: flex;
  align-items: center;
  justify-content: center;
}

/* rings */
.ring {
  position: absolute;
  border-radius: 50%;
  border: 1px solid var(--accent);
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  pointer-events: none;
  opacity: 0;
  transition: opacity var(--transition-base);
}

.ring-1 {
  width: 224px;
  height: 224px;
}
.ring-2 {
  width: 250px;
  height: 250px;
}

.circle-wrap:hover .ring-1 {
  opacity: 0.25;
}
.circle-wrap:hover .ring-2 {
  opacity: 0.1;
}

.ring.pulse {
  animation: pulseRing 0.4s ease-out both;
}
</style>
