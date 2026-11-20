<script setup>
import { ref, computed, onMounted } from 'vue';
import Input from '@components/Input.vue';
import TextArea from '@components/TextArea.vue';
import Select from '@components/Select.vue';
import Button from '@components/Button.vue';

const organizations = ref([]);

const images = ref([]);

const types = ref([{value: 'mellékszereplő', label: 'Mellékszereplő'}, {value: 'főszereplő', label: 'Főszereplő'}]);

const organizationsMapped = computed(() => organizations.value.map(x => ({value: x.id, label: `${x.name} (${x.area})`})));

const imagesMapped = computed(() => images.value.map(x => ({value: x, label: x})));
</script>

<template>
    <form class="grid md:grid-cols-6 gap-4 px-6 pt-6 pb-8 rounded bg-gray-900">
        <Input label="Név" type="text" name="name" required :maxlength="50" class="md:col-span-3" />
        <Select label="Szervezet" name="organization" :items="organizationsMapped" required class="md:col-span-3" />
        <TextArea label="Leírás" name="description" required :maxlength="60000" :rows="4" class="col-span-full" />
        <Select label="Típus" name="type" :items="types" required class="md:col-span-2" />
        <Input label="Foglalkozása" type="text" name="occupation" required :maxlength="20" class="md:col-span-2" />
        <Select label="Kép" name="image" :items="imagesMapped" required class="md:col-span-2" />
        <Button type="submit" class="col-span-full justify-self-end">Létrehozás</Button>
    </form>
</template>