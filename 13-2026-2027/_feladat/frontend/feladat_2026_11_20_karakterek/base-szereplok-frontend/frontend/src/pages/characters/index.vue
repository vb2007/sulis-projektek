<script setup>
import BaseLayout from '@layouts/BaseLayout.vue';
import CharacterCard from '@components/CharacterCard.vue';
import CharacterCardSkeleton from '@components/CharacterCardSkeleton.vue';
import { ref } from 'vue';

const characters = ref([]);

const loading = ref(true);
</script>

<template>
    <BaseLayout>
        <h1 class="text-4xl font-bold font-poppins mb-4">Karakterek</h1>
        <div class="grid sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4">
            <CharacterCard v-if="!loading" v-for="character in characters" :key="character.id" :character />
            <CharacterCardSkeleton v-else v-for="i in 8" :key="i" />
        </div>
    </BaseLayout>
</template>

<route lang="yaml">
name: characters.index
meta:
    title: Karakterek
</route>