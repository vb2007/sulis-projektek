<script setup>
import BaseLayout from '@layouts/BaseLayout.vue'
import { api } from '@utils/http.mjs';
import { ref, onMounted } from 'vue'

const quotationEndpoints = {
  house: '/api/idezetek/house',
  family: '/api/idezetek/modern-family',
  csoki: '/api/idezetek/uvegtigris/csoki',
  lali: '/api/idezetek/uvegtigris/lali',
  fredgeorge: '/api/idezetek/harry-potter/fred-es-george',
  hermione: '/api/idezetek/harry-potter/hermione',
}

const quotations = ref([])

const calendarEndpoints = {
  yesterday: '/api/naptar/tegnap',
  today: '/api/naptar/ma',
  tomorrow: '/api/naptar/holnap',
}

const calendars = ref([])

const weekdayName = ref(null)
const weekdayNumber = ref(null)

const weekdays = [
  'hétfő',
  'kedd',
  'szerda',
  'csütörtök',
  'péntek',
  'szombat',
  'vasárnap',
]


const getWeekdayName = async (number) => {
  try {
    const response = await api.get(`/api/hetnapja/${number}`)
    weekdayName.value = response.data.data.result
  } catch (error) {
    console.error(error)
    weekdayName.value = null
  }
}

const getWeekdayNumber = async (name) => {
  try {
    const response = await api.get(`/api/hetnapja/${name}`)
    weekdayNumber.value = response.data.data.result
  } catch (error) {
    console.error(error)
    weekdayNumber.value = null
  }
}

const calculatorA = ref('')
const calculatorB = ref('')
const calculatorOperator = ref('+')
const calculatorResult = ref(null)
const calculatorError = ref(null)

const calculate = async () => {
  calculatorResult.value = null
  calculatorError.value = null

  try {
    const response = await api.get(
      `/api/szamologep/${calculatorA.value}${calculatorOperator.value}${calculatorB.value}`
    )

    calculatorResult.value = response.data.data
  } catch (error) {
    calculatorError.value =
      error.response?.data?.message ?? 'Hiba történt'
  }
}

onMounted(async () => {
  const entries = Object.entries(quotationEndpoints)

  const results = await Promise.allSettled(
    entries.map(([, url]) => api.get(url))
  )

  quotations.value = results.map((result, index) => {
    const [name, url] = entries[index]

    return {
      name,
      url,
      data: result.status === 'fulfilled'
        ? result.value.data.data
        : null,
    }
  })

  const calendarEntries = Object.entries(calendarEndpoints)

  const calendarResults = await Promise.allSettled(
    calendarEntries.map(([, url]) => api.get(url, {
      timeout: 3000,
    }))
  )

  calendars.value = calendarResults.map((result, index) => {
    const [name, url] = calendarEntries[index]

    return {
      name,
      url,
      data: result.status === 'fulfilled'
        ? result.value.data.data
        : null,
    }
  })
})


</script>

<template>
  <BaseLayout>

    <h1 class="text-3xl my-10">Laravel routing teszt</h1>
    <h2 class="text-xl">Idézetek</h2>


    <div v-for="item in quotations" :key="item.url"
      class="mb-6 rounded-xl border border-gray-200 bg-white p-6 shadow-sm">
      <template v-if="item.data">
        <h3 class="mb-3 text-xl font-semibold">
          {{ item.data.title }}
        </h3>

        <blockquote class="border-l-4 border-gray-300 pl-4 italic text-gray-700">
          {{ item.data.quote }}
        </blockquote>

        <p class="mt-4 text-right font-medium text-gray-600">
          — {{ item.data.name }}
        </p>
      </template>

      <div v-else class="rounded-lg bg-red-50 p-4 text-red-700">
        <p class="font-medium">
          Nincs adat erről a végpontról
        </p>

        <code class="mt-1 block text-sm">
    {{ item.url }}
  </code>
      </div>
    </div>



    <<section class="mb-10">
  <h2 class="mb-6 text-3xl font-semibold">
    Naptár
  </h2>

  <div class="grid gap-4 md:grid-cols-3">
    <div
      v-for="item in calendars"
      :key="item.url"
      class="rounded-xl border border-gray-200 bg-white p-6 shadow-sm"
    >
      <template v-if="item.data">
        <h3 class="text-xl font-semibold">
          {{ item.data.title }}
        </h3>

        <p class="mt-2 text-gray-600">
          {{ item.data.date }}
        </p>
      </template>

      <div
        v-else
        class="rounded-lg bg-red-50 p-4 text-red-700"
      >
        <p class="font-medium">
          Nincs adat
        </p>

        <code class="mt-1 block text-sm">
          {{ item.url }}
        </code>
      </div>
    </div>
  </div>
</section>


    <div class="grid gap-6 md:grid-cols-2">
      <div class="rounded-xl border border-gray-200 bg-white p-6 shadow-sm">
        <h3 class="mb-4 text-xl font-semibold">
          Nap sorszámból
        </h3>

        <div class="flex gap-2">
          <button v-for="number in 7" :key="number" class="rounded-lg border px-3 py-2" @click="getWeekdayName(number)">
            {{ number }}
          </button>
        </div>

        <p class="mt-4">
          Eredmény:
          <strong>{{ weekdayName ?? 'Nincs' }}</strong>
        </p>
      </div>

      <div class="rounded-xl border border-gray-200 bg-white p-6 shadow-sm">
        <h3 class="mb-4 text-xl font-semibold">
          Napnévből sorszám
        </h3>

        <div class="flex flex-wrap gap-2">
          <button v-for="day in weekdays" :key="day" class="rounded-lg border px-3 py-2" @click="getWeekdayNumber(day)">
            {{ day }}
          </button>
        </div>

        <p class="mt-4">
          Eredmény:
          <strong>{{ weekdayNumber ?? 'Nincs' }}</strong>
        </p>
      </div>
    </div>


    <div class="mb-6 rounded-xl border border-gray-200 bg-white p-6 shadow-sm">
      <h2 class="mb-4 text-2xl font-semibold">
        Számológép
      </h2>

      <div class="flex flex-wrap items-center gap-3">
        <input v-model="calculatorA" type="number" class="w-28 rounded-lg border px-3 py-2" placeholder="A">

        <select v-model="calculatorOperator" class="rounded-lg border px-3 py-2">
          <option value="+">+</option>
          <option value="-">-</option>
          <option value="*">*</option>
        </select>

        <input v-model="calculatorB" type="number" class="w-28 rounded-lg border px-3 py-2" placeholder="B">

        <button class="rounded-lg bg-gray-900 px-4 py-2 text-white" @click="calculate">
          Számol
        </button>
      </div>

      <div v-if="calculatorResult" class="mt-5 rounded-lg bg-gray-50 p-4">
        <p class="text-lg">
          {{ calculatorResult.a }}
          {{ calculatorResult.operator }}
          {{ calculatorResult.b }}
          =
          <strong>{{ calculatorResult.result }}</strong>
        </p>
      </div>

      <div v-if="calculatorError" class="mt-5 rounded-lg bg-red-50 p-4 text-red-700">
        {{ calculatorError }}
      </div>
    </div>

  </BaseLayout>
</template>

<route lang="yaml">
name: index
meta:
  title: Főoldal
</route>
