<script setup>
const { label, name, placeholder, required, disabled, minlength, maxlength } = defineProps({
    label: {
        type: String,
        required: false,
    },
    name: {
        type: String,
        required: true,
    },
    rows: {
        type: Number,
        required: false,
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
        <textarea :rows :required :name :id="name" :disabled :minlength :maxlength :placeholder v-model="model" class="bg-background px-1 py-0.75 rounded resize-none outline focus:outline-white">
            <slot />
        </textarea>
    </div>
</template>