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
        <RouterLink
            class="bg-blue-500 text-white rounded py-2 px-4 w-full text-center"
            :to="{ name: `characters.show`, params: { id: character.id } }">
            {{ character.name }}
        </RouterLink>
    </div>
</template>

<style lang="css" scoped>
</style>
