<script setup>
import BaseLayout from '@layouts/BaseLayout.vue'; 
import UserSparkIcon from '@components/UserSparkIcon.vue';
import { ref, computed } from 'vue';

const character = ref({});

const loading = ref(true);

const isMainCharacter = computed(() => false);
</script>

<template>
    <BaseLayout>
        <div v-if="!loading" class="grid gap-4 md:grid-cols-[auto_1fr]">
            <img :src="character.image" :alt="character.name" class="w-full md:w-auto md:max-w-100">
            <div class="flex flex-col justify-center mt-4 md:mt-0">
                <h1 class="text-4xl font-bold font-poppins flex flex-wrap gap-1">{{ character.name }}<UserSparkIcon v-if="isMainCharacter" /></h1>
                <p class="font-poppins font-medium text-lg mb-2">{{ character.occupation }}<span class="font-sans font-normal">, {{ character.organization.name }} ({{ character.organization.area }})</span></p>
                <p>{{ character.description }}</p>
            </div>
        </div>
        <div v-else class="grid gap-4 md:grid-cols-[auto_1fr]">
            <div class="w-100 aspect-square max-w-100 md:w-100 bg-gray-600/80 animate-pulse"></div>
            <div class="flex flex-col justify-center mt-4 md:mt-0">
                <div class="animate-pulse bg-gray-600/80 h-8 rounded-full w-5/12 mb-2"></div>
                <div class="animate-pulse bg-gray-600/80 h-6 rounded-full w-8/12 mb-4"></div>
                <div class="animate-pulse bg-gray-600/80 h-4 rounded-full mb-1"></div>
                <div class="animate-pulse bg-gray-600/80 h-4 rounded-full mb-1"></div>
                <div class="animate-pulse bg-gray-600/80 h-4 rounded-full mb-1"></div>
                <div class="animate-pulse bg-gray-600/80 h-4 rounded-full w-11/12"></div>
            </div>
        </div>
    </BaseLayout>
</template>

<route lang="yaml">
name: characters.show
meta:
    title: Karakter
</route>