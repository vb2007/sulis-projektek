<script setup>
import BaseLayout from '@layouts/BaseLayout.vue'
import { useCounter } from '@stores/CounterStore.js'

const counter = useCounter()
</script>

<template>
  <BaseLayout>
    <h1 class="text-6xl my-10">Rick and Morty</h1>

    <RouterLink
      class="bg-blue-500 text-white rounded py-2 px-4 mx-2"
      :to="{ name: `characters.index`}">
      Karakterek
    </RouterLink>

    <RouterLink
      class="bg-blue-500 text-white rounded py-2 px-4 mx-2"
      :to="{ name: `characters.show`, params: {id: 1}}">
      Rick
    </RouterLink>
  </BaseLayout>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>
