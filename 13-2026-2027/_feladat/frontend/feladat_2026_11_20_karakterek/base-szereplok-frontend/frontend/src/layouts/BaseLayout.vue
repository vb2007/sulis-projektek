<script setup>
import BaseHeader from '@components/layout/BaseHeader.vue'
import ErrorToast from '@components/ErrorToast.vue';
</script>

<template>
  <BaseHeader />
  <main class="container mx-auto max-w-280 grow flex flex-col p-4">
    <slot />
  </main>
  <ErrorToast />
</template>
