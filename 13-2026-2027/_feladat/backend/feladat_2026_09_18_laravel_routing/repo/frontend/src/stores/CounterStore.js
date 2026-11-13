import { defineStore } from 'pinia'
import { ref, computed } from 'vue'

export const useCounter = defineStore('counter', () => {
  const counter = ref(0)

  function increment(step = 1) {
    counter.value += step
  }

  const counter10X = computed(() => counter.value * 10)

  return { counter, increment, counter10X }
})
