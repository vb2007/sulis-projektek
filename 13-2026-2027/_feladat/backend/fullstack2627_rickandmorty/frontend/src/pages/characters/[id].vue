<script setup>
import CharacterDetailsCard from '@components/CharacterDetailsCard.vue';
import BaseLayout from '@layouts/BaseLayout.vue';
import { api } from '@utils/http.mjs';
import { onMounted, ref } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute();
const character = ref(null);
onMounted(async () => {
    const result = await api.get(`character/${route.params.id}`);
    character.value = result.data;
});

</script>

<template>
    <BaseLayout>
        <h1 class="text-center text-red-500 font-bold">{{ route.params.id }}. Karakter</h1>
        <div class="container px-2 md:w-1/3">
            <CharacterDetailsCard v-if="character" :character></CharacterDetailsCard>
        </div>
    </BaseLayout>
</template>

<style lang="css" scoped>
</style>

<route lang="yaml">
name: characters.show
meta:
  title: Karakterek
</route>
