<script setup>
import BaseLayout from '@layouts/BaseLayout.vue';
import { useErrorToast } from '@/composables/useErrorToast';
import { api } from '@utils/http.mjs';

const errorToast = useErrorToast();

async function createCharacter(data) {
    try {
        await api.post('/characters', data);
        return true;
    } catch {
        return false;
    }
}
</script>

<template>
    <BaseLayout>
        <h1 class="text-4xl font-bold font-poppins mb-4">Új karakter létrehozása</h1>
    </BaseLayout>
</template>

<route lang="yaml">
name: characters.create
meta:
    title: Új karakter
</route>