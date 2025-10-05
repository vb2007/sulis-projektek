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
    assetsDir: "assets",
    rollupOptions: {
      input: "./index.html",
    },
  },
  assetsInclude: ["**/*.woff", "**/*.woff2", "**/*.ttf", "**/*.otf"],
});
