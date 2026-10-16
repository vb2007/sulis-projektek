import { createApp } from 'vue'
import { createPinia } from 'pinia'
import { router } from '@/router/index.js'
import piniaPluginPersistedstate from 'pinia-plugin-persistedstate'

import App from '@/App.vue'

import '@assets/main.css'

createApp(App)
  .use(createPinia().use(piniaPluginPersistedstate))
  .use(router)
  .mount('#app')
