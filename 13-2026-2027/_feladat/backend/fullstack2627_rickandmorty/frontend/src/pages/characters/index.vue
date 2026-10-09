<script setup>
import CharacterCard from '@components/CharacterCard.vue';
import BaseLayout from '@layouts/BaseLayout.vue';
import { api } from '@utils/http.mjs';
import { computed, onMounted, ref } from 'vue';

const characters = ref([]);
onMounted(async () => {
    const result = await api.get(`character`);
    console.log(result.data.results);
    characters.value = result.data.results;
});

const name = ref("");
const filtered = computed(() => {
    return characters.value.filter(c => c.name.toLowerCase().includes(name.value.toLowerCase()));
});

</script>

<template>
    <BaseLayout>
        <div class="container px-2">
            <h1 class="text-center font-bold">Karakterek</h1>
            <form class="flex my-4 gap-4" @submit.prevent>
                <label for="name">Név</label>
                <input v-model="name" type="text" id="name" placeholder="Név" class="border border-blue-800 px-4 py-2">
            </form>
            <div class="grid md:grid-cols-4 gaps-4">
                <CharacterCard v-for="character in filtered" :key="character.id" :character></CharacterCard>
            </div>
        </div>
    </BaseLayout>
</template>

<style lang="css" scoped>
</style>

<route lang="yaml">
name: characters.index
meta:
  title: Karakterek
</route>
