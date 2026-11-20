<script setup>
import { ref, computed, onMounted } from 'vue';
import Input from '@components/Input.vue';
import TextArea from '@components/TextArea.vue';
import Select from '@components/Select.vue';
import Button from '@components/Button.vue';
import { api } from '@utils/http.mjs';

const emit = defineEmits(['submit']);

const data = ref({
    name: '',
    type: null,
    occupation: '',
    description: '',
    image: null,
    organization_id: null,
});

const organizations = ref([]);

const images = ref([]);

const types = ref([{value: 'mellékszereplő', label: 'Mellékszereplő'}, {value: 'főszereplő', label: 'Főszereplő'}]);

const organizationsMapped = computed(() => organizations.value.map(x => ({value: x.id, label: `${x.name} (${x.area})`})));

const imagesMapped = computed(() => images.value.map(x => ({value: x, label: x})));

async function getOrganizations() {
    const response = await api.get('/organizations');
    organizations.value = response.data.data;
}

async function getImages() {
    const response = await api.get('/images');
    images.value = response.data.data;
}

function handleSubmit() {
    emit('submit', data.value);
}

onMounted(() => {
    getOrganizations();
    getImages();
});
</script>

<template>
    <form @submit.prevent="handleSubmit"
        class="grid md:grid-cols-6 gap-4 px-6 pt-6 pb-8 rounded bg-gray-900"
        >
        <Input v-model="data.name"
            label="Név" type="text" name="name" required
            :maxlength="50" class="md:col-span-3" />

        <Select v-model="data.organization_id"
            label="Szervezet" name="organization"
            :items="organizationsMapped" required class="md:col-span-3" />

        <TextArea v-model="data.description"
            label="Leírás" name="description" required
            :maxlength="60000" :rows="4" class="col-span-full" />

        <Select v-model="data.type"
            label="Típus" name="type"
            :items="types" required class="md:col-span-2" />

        <Input v-model="data.occupation"
            label="Foglalkozása" type="text" name="occupation" required
            :maxlength="20" class="md:col-span-2" />

        <Select v-model="data.image"
            label="Kép" name="image"
            :items="imagesMapped" required class="md:col-span-2" />

        <Button type="submit" class="col-span-full justify-self-end">Létrehozás</Button>
    </form>
</template>