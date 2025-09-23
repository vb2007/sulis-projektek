import { defineConfig } from "vite";

export default defineConfig({
  root: "./src",
  server: {
    port: 3000,
    open: "/metro2033.html",
    host: true,
  },
  build: {
    outDir: "../dist",
    rollupOptions: {
      input: "./metro2033.html",
    },
  },
});
