<script setup>
const { label, name, required, disabled } = defineProps({
    label: {
        type: String,
        required: false,
    },
    name: {
        type: String,
        required: true,
    },
    required: {
        type: Boolean,
        required: false,
        default: false,
    },
    disabled: {
        type: Boolean,
        required: false,
        default: false,
    },
    empty: {
        type: Boolean,
        required: false,
        default: true,
    },
    items: {
        type: Array,
        required: true,
    },
});
const model = defineModel();
</script>

<template>
    <div class="flex flex-col gap-2">
        <label v-if="label" :for="name">{{ label }}</label>
        <select :required :disabled :name :id="name" v-model="model" class="bg-background px-1.5 py-1.5 rounded resize-none outline focus:outline-white">
            <option value="" selected>Válassz...</option>
            <option v-for="item in items" :value="item.value">{{ item.label }}</option>
        </select>
    </div>
</template>