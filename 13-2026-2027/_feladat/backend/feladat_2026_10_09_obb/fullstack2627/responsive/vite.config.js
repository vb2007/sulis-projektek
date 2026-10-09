import { defineConfig } from 'vite'
import { fileURLToPath } from 'node:url'
import tailwindcss from '@tailwindcss/vite'


// https://vitejs.dev/config/
export default defineConfig({
  plugins: [
    tailwindcss(),
  ],
  server:{
    host: true,
    port: 5173,
    strictPort: true,
    allowedHosts: ["vm1.test", "vm2.test", "vm3.test", "vm4.test", "vm5.test", "vm6.test", "responsive.vm1.test", "responsive.vm2.test", "responsive.vm3.test", "responsive.vm4.test", "responsive.vm5.test", "responsive.vm6.test"]
  },
  resolve: {
    alias: {
      '@': fileURLToPath(new URL('./src', import.meta.url)),
      '@assets': fileURLToPath(new URL('./src/assets', import.meta.url)),
    }
  }
})
