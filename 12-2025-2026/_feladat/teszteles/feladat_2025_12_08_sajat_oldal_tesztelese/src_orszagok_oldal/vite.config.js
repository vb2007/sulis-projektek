import { defineConfig } from "vite";

export default defineConfig({
   root: "./",
   server: {
      port: 3000,
      open: "index.html",
      host: true,
   },
   build: {
      outDir: "../dist",
      rollupOptions: {
         input: "./index.html",
      },
   },
});
