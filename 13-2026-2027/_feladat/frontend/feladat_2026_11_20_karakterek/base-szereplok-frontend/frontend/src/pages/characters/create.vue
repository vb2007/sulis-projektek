<script setup>
import BaseLayout from '@layouts/BaseLayout.vue';
import { useErrorToast } from '@/composables/useErrorToast';
import { useRouter } from 'vue-router';
import { api } from '@utils/http.mjs';

const router = useRouter();
const errorToast = useErrorToast();

async function createCharacter(data) {
    try {
        await api.post('/characters', data);
        return true;
    } catch {
        return false;
    }
}

async function handleSubmit(data) {
    const success = await createCharacter(data);

    if (success) {
        router.push({ name: 'characters.index' });
    } else {
        errorToast.showError('Nem sikerült létrehozni a karaktert!');
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