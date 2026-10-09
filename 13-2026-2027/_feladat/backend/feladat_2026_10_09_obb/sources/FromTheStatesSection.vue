<script setup>
import { ref, computed } from 'vue';
import Card from '@components/Card.vue';
import Stepper from '@components/Stepper.vue';

const { items } = defineProps({
    items: {
        type: Array,
        required: true,
    }
})

const step = ref(0);
const hasTransition = ref(true);

const translate = computed(() => `calc(${step.value} * (-15.625rem - 2rem))`);
const transition = computed(() => hasTransition.value ? 'transition-all transition-300' : '');

const handlePrevious = () => {
    if (step.value <= 0) {
        step.value = 9;
        hasTransition.value = false;
        setTimeout(() => {
            hasTransition.value = true;
            step.value--;
        }, 30);
    } else {
        step.value--;
    }
} 

const handleNext = () => {
    if (step.value >= 9) {
        step.value = 0;
        hasTransition.value = false;
        setTimeout(() => {
            hasTransition.value = true;
            step.value++;
        }, 30);
    } else {
        step.value++;
    }
} 
</script>

<template>
<div class="flex flex-col items-center bg-[url('/images/states-bg.webp')] bg-cover bg-center text-white p-12 overflow-hidden relative @container">
    <h2 class="text-shadow-gray-800/50 text-shadow-md text-3xl text-center">Aus den Bundesländern</h2>
    <p class="text-shadow-gray-800/50 text-shadow-md text-xl mb-5 text-center">Regionale Angebote und Informationen</p>
    <Stepper @previous="handlePrevious" @next="handleNext">
            <div class="grow flex overflow-hidden max-w-[calc(3*15.625rem+2*2rem)] self-start @min-[calc(3*15.625rem+2*2rem)]:self-center">
                <div :class="['flex gap-8 text-black', transition]" :style="{ transform: `translate(${translate})`}">
                    <Card v-for="item in items" :key="item.id" :image="item.image_url" class="w-62.5">
                        <p class="text-sm">{{ item.title }}</p>
                    </Card>
                    <Card v-for="item in items.slice(0, 3)" :key="item.id" :image="item.image_url" class="w-62.5">
                        <p class="text-sm">{{ item.title }}</p>
                    </Card>
                </div>
            </div>
    </Stepper>
</div>
</template>