<script setup lang="ts">
import { useI18n } from "vue-i18n";
import { storeToRefs } from "pinia";
import { useSettingsStore } from "@/stores/settingsStore";
import SaveBar from "@/components/layout/SaveBar.vue";
import type { Language } from "@/types";

const { t, locale } = useI18n();
const settings = useSettingsStore();
const { theme, language } = storeToRefs(settings);

function toggleLanguage() {
  const next: Language = language.value === "en" ? "hu" : "en";
  settings.setLanguage(next);
  locale.value = next;
}
</script>

<template>
  <header class="app-header">
    <div class="brand">
      <span class="brand-name">{{ t("app.title") }}</span>
    </div>

    <SaveBar />

    <div class="controls">
      <button class="ctrl-btn" @click="toggleLanguage" :title="t('settings.language')">
        <span class="flag">{{ language === "en" ? "🇬🇧" : "🇭🇺" }}</span>
        <span class="lang-code">{{ language.toUpperCase() }}</span>
      </button>

      <button
        class="ctrl-btn icon-btn"
        @click="settings.toggleTheme"
        :title="t('settings.toggleTheme')"
      >
        <span>{{ theme === "dark" ? "☀️" : "🌙" }}</span>
      </button>
    </div>
  </header>
</template>

<style scoped>
.app-header {
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 20px;
  height: 52px;
  background: var(--bg-surface);
  border-bottom: 1px solid var(--border);
  flex-shrink: 0;
  z-index: 20;
  transition:
    background var(--transition-slow),
    border-color var(--transition-slow);
}

.brand {
  display: flex;
  align-items: center;
  gap: 8px;
}

.brand-name {
  font-size: 17px;
  font-weight: 800;
  color: var(--accent);
  letter-spacing: -0.4px;
}

.controls {
  display: flex;
  gap: 6px;
}

.ctrl-btn {
  display: flex;
  align-items: center;
  gap: 5px;
  padding: 5px 10px;
  border-radius: var(--radius-sm);
  border: 1px solid var(--border);
  background: var(--bg-elevated);
  color: var(--text-secondary);
  font-size: 12px;
  font-weight: 600;
  transition: all var(--transition-fast);
}

.ctrl-btn:hover {
  border-color: var(--accent);
  color: var(--accent-text);
  background: var(--bg-hover);
}

.icon-btn {
  padding: 5px 10px;
}

.flag {
  font-size: 14px;
  line-height: 1;
}
.lang-code {
  letter-spacing: 0.5px;
}
</style>
