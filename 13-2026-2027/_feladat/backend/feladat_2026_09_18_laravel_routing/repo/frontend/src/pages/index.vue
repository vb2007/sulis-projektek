<script setup>
import BaseLayout from '@layouts/BaseLayout.vue'
import { useCounter } from '@stores/CounterStore.js'

const counter = useCounter()
</script>

<template>
  <BaseLayout>
    <h1 class="text-6xl my-10">Hello!</h1>
    <button class="bg-blue-500 text-white rounded py-2 px-4" @click="counter.increment()">
      Számláló: {{ counter.counter }}
    </button>
  </BaseLayout>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>
