import { defineConfig } from "vite";

export default defineConfig({
   root: "./",
   server: {
      port: 3000,
      open: "orszagok.html",
      host: true,
   },
   build: {
      outDir: "../dist",
      rollupOptions: {
         input: "./orszagok.html",
      },
   },
});
