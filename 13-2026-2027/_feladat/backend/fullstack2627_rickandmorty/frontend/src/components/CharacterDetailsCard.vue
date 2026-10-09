<script setup>
const { character } = defineProps({
    character: {
        type: Object,
        required: true
    }
});
</script>

<template>
    <div class="border rounded p-2 m-2 flex flex-col items-center gap-2">
        <img class="w-full rounded" :src="character.image" :alt="character.name">
        <h2 class="font-bold">{{ character.name }}</h2>
        <ul class="w-full">
            <li>Státusz: {{ character.status }}</li>
            <li>Faj: {{ character.species }}</li>
            <li>Nem: {{ character.gender }}</li>
            <li>Származás: {{ character.origin?.name }}</li>
            <li>Tartózkodási hely: {{ character.location?.name }}</li>
        </ul>
    </div>
</template>

<style lang="css" scoped>
</style>
