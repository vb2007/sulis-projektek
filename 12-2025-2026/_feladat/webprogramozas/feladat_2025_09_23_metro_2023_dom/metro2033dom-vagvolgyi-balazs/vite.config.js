import { defineConfig } from 'vite'

export default defineConfig({
  root: './',
  server: {
    port: 3000,
    open: true,
    host: true
  },
  build: {
    outDir: 'dist',
    rollupOptions: {
      input: {
        main: './metro2033.html'
      }
    }
  }
})
