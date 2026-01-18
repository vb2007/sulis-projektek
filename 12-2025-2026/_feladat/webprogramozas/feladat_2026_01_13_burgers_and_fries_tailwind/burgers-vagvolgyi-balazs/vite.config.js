import { defineConfig } from "vite";
import { fileURLToPath } from "node:url";
import tailwindcss from "@tailwindcss/vite";

export default defineConfig({
    root: "./src",
    plugins: [tailwindcss()],
    server: {
        host: true,
        port: 8080,
        open: "./index.html",
    },
    resolve: {
        alias: {
            "@": fileURLToPath(new URL("./src", import.meta.url)),
            "@assets": fileURLToPath(new URL("./src/assets", import.meta.url)),
        },
    },
    build: {
        outDir: "../dist",
        rollupOptions: {
            input: "./index.html",
        },
    },
});
