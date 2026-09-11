<script setup>
import BaseHeader from '@components/layout/BaseHeader.vue'
</script>

<template>
  <BaseHeader />
  <main class="container mx-auto">
    <slot />
  </main>
</template>
