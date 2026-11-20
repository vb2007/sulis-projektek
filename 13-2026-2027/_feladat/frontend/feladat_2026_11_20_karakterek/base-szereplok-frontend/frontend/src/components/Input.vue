<script setup>
const { label, name, type, placeholder, required, disabled, min, max, minlength, maxlength } = defineProps({
    label: {
        type: String,
        required: false,
    },
    name: {
        type: String,
        required: true,
    },
    type: {
        type: String,
        required: false,
        default: 'text',
    },
    placeholder: {
        type: String,
        required: false,
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
    min: {
        type: Number,
        required: false,
    },
    max: {
        type: Number,
        required: false,
    },
    minlength: {
        type: Number,
        required: false,
    },
    maxlength: {
        type: Number,
        required: false,
    },
});
const model = defineModel();
</script>

<template>
    <div class="flex flex-col gap-2">
        <label v-if="label" :for="name">{{ label }}</label>
        <input :type :name :id="name" :required :disabled :min :max :minlength :maxlength :placeholder v-model="model" class="bg-background px-1.5 py-1 rounded outline focus:outline-white">
    </div>
</template>