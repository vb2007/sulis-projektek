<script setup>
import BaseLayout from '@layouts/BaseLayout.vue'
import Cover from '@assets/cover.webp'


</script>

<template>
  <BaseLayout>
    <h1 class="sr-only">GTA VI Karakterek</h1>
    <div class="grow flex flex-col justify-center">
      <img :src="Cover" alt="GTA VI" class="w-full">
      <div class="grid sm:grid-cols-2 gap-4 mt-4">
        <RouterLink :to="{name: 'characters.index'}" class="bg-primary text-primary-foreground font-bold text-3xl p-8 text-center">Karakterek</RouterLink>
        <RouterLink :to="{name: 'characters.create'}" class="bg-primary text-primary-foreground font-bold text-3xl p-8 text-center">Új karakter</RouterLink>
      </div>
    </div>
  </BaseLayout>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>
