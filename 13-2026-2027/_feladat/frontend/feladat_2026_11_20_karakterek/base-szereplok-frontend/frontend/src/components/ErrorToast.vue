<script setup>
import { useErrorToast } from '@/composables/useErrorToast'

const { errorMessage, clearError } = useErrorToast()
</script>

<template>
  <Transition name="fade">
    <div v-if="errorMessage" class="fixed top-6 right-6 z-50 flex items-center gap-4 py-3 px-6 text-lg text-secondary-foreground bg-secondary border border-primary rounded-md shadow" role="alert">
      <span class="font-medium" style="text-box-trim: trim-both;">{{ errorMessage }}</span>
      <button class="bg-none border-none text-inherit leading-none cursor-pointer p-0" @click="clearError" aria-label="Close">&times;</button>
    </div>
  </Transition>
</template>

<style scoped>
.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.25s, transform 0.25s;
}

.fade-enter-from {
    opacity: 0;
    transform: translateY(-10px);
}
.fade-leave-to {
  opacity: 0;
  transform: translateY(10px);
}
</style>Ū