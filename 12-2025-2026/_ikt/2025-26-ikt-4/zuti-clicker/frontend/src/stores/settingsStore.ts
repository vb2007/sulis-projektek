import { defineStore } from "pinia";
import { ref, watch } from "vue";
import type { Theme, Language } from "@/types";

export const useSettingsStore = defineStore("settings", () => {
  const theme = ref<Theme>("dark");
  const language = ref<Language>("en");

  function toggleTheme() {
    theme.value = theme.value === "dark" ? "light" : "dark";
  }

  function setLanguage(lang: Language) {
    language.value = lang;
  }

  watch(theme, (t) => document.documentElement.setAttribute("data-theme", t), { immediate: true });

  return { theme, language, toggleTheme, setLanguage };
});
