<script setup>
const { character } = defineProps({
    character: {
        type: Object,
        required: true
    }
});
</script>

<template>
    <RouterLink :to="{name: 'characters.show', params: {id: character.id}}" class="bg-secondary group hover:bg-primary hover:text-primary-foreground transition-all">
        <div class="aspect-square overflow-hidden">
            <img :src="character.image" :alt="character.name" class="w-full h-full object-cover group-hover:scale-110 transition-all">
        </div>
        <h2 class="text-lg font-medium font-poppins px-3 py-2">{{ character.name }}</h2>
    </RouterLink>
</template>