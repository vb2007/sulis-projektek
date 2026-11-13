import { fileURLToPath, URL } from 'node:url'
import { defineConfig, loadEnv } from 'vite';

import Vue from '@vitejs/plugin-vue'
import VueDevtools from 'vite-plugin-vue-devtools'
import VueRouter from 'vue-router/vite'
import TailwindCSS from '@tailwindcss/vite'

export default ({ mode }) => {
  process.env = { ...process.env, ...loadEnv(mode, process.cwd()) };

  return defineConfig({
    plugins: [
      VueRouter({
        importMode: 'async'
      }),
      Vue(),
      VueDevtools(),
      TailwindCSS()
    ],
    server: {
      host: true,
      allowedHosts: [process.env.VITE_FRONTEND_URL ?? 'localhost']
    },
    resolve: {
      alias: {
        '@': fileURLToPath(new URL('./src', import.meta.url)),
        '@assets': fileURLToPath(new URL('./src/assets', import.meta.url)),
        '@components': fileURLToPath(new URL('./src/components', import.meta.url)),
        '@layouts': fileURLToPath(new URL('./src/layouts', import.meta.url)),
        '@locales': fileURLToPath(new URL('./src/locales', import.meta.url)),
        '@pages': fileURLToPath(new URL('./src/pages', import.meta.url)),
        '@stores': fileURLToPath(new URL('./src/stores', import.meta.url)),
        '@utils': fileURLToPath(new URL('./src/utils', import.meta.url))
      }
    }
  })
}