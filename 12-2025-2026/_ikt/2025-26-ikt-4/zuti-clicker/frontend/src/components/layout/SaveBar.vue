<script setup lang="ts">
import { ref, watch, onMounted, onUnmounted } from "vue";
import { useI18n } from "vue-i18n";
import { useAuthStore } from "@/stores/authStore";
import { useSaveStore } from "@/stores/saveStore";
import { useUiStore } from "@/stores/uiStore";

const { t } = useI18n();
const auth = useAuthStore();
const save = useSaveStore();
const ui = useUiStore();

// --- Sync button feedback ---
const syncJustCompleted = ref(false);
let _fbTimer: ReturnType<typeof setTimeout> | null = null;

watch(
  () => save.isSyncing,
  (syncing, wasSyncing) => {
    if (wasSyncing && !syncing && !save.syncError) {
      syncJustCompleted.value = true;
      if (_fbTimer) clearTimeout(_fbTimer);
      _fbTimer = setTimeout(() => {
        syncJustCompleted.value = false;
      }, 3000);
    }
  }
);

onUnmounted(() => {
  if (_fbTimer) clearTimeout(_fbTimer);
});

// --- User dropdown ---
const userMenuRef = ref<HTMLElement | null>(null);
const userMenuOpen = ref(false);

function onDocClick(e: MouseEvent) {
  if (userMenuRef.value && !userMenuRef.value.contains(e.target as Node)) {
    userMenuOpen.value = false;
  }
}
onMounted(() => document.addEventListener("click", onDocClick));
onUnmounted(() => document.removeEventListener("click", onDocClick));

function openAuthModal() {
  ui.authModalOpen = true;
}

function openDeleteConfirm() {
  userMenuOpen.value = false;
  ui.confirmDeleteOpen = true;
}

async function logout() {
  userMenuOpen.value = false;
  await auth.logout();
}

const intervalOptions = [
  { value: 15, label: "15s" },
  { value: 30, label: "30s" },
  { value: 60, label: "1m" },
  { value: 300, label: "5m" }
];
</script>

<template>
  <!-- Guest state -->
  <div v-if="!auth.isLoggedIn" class="save-bar">
    <button class="ctrl-btn save-guest-btn" @click="openAuthModal">
      <span>💾</span>
      <span>{{ t("save.loginToSave") }}</span>
    </button>
  </div>

  <!-- Logged-in state -->
  <div v-else class="save-bar">
    <!-- Sync button -->
    <button
      class="ctrl-btn sync-btn"
      :class="{
        syncing: save.isSyncing,
        synced: syncJustCompleted,
        'sync-error': !!save.syncError
      }"
      :disabled="save.isSyncing"
      :title="save.syncError ?? (save.lastSyncedAt ? save.lastSyncedAt.toLocaleTimeString() : t('save.neverSynced'))"
      @click="save.sync()"
    >
      <span class="sync-icon" :class="{ spinning: save.isSyncing }">
        {{ save.isSyncing ? "⟳" : syncJustCompleted ? "✓" : "↑" }}
      </span>
      <span>{{ save.isSyncing ? t("save.syncing") : t("save.sync") }}</span>
    </button>

    <!-- Autosave toggle -->
    <button
      class="ctrl-btn autosave-btn"
      :class="{ active: save.autosaveEnabled }"
      @click="save.autosaveEnabled = !save.autosaveEnabled"
    >
      <span>{{ save.autosaveEnabled ? "✓" : "✗" }}</span>
      <span>{{ t("save.autosave") }}</span>
    </button>

    <!-- Interval select (only when autosave on) -->
    <select
      v-if="save.autosaveEnabled"
      v-model="save.autosaveIntervalSecs"
      class="interval-select"
    >
      <option
        v-for="opt in intervalOptions"
        :key="opt.value"
        :value="opt.value"
      >{{ opt.label }}</option>
    </select>

    <!-- User dropdown -->
    <div ref="userMenuRef" class="user-menu">
      <button class="ctrl-btn user-btn" @click.stop="userMenuOpen = !userMenuOpen">
        <span>👤</span>
        <span class="username">{{ auth.user?.username }}</span>
        <span class="chevron">{{ userMenuOpen ? "▴" : "▾" }}</span>
      </button>

      <div v-if="userMenuOpen" class="dropdown-menu">
        <button class="dropdown-item danger" @click="openDeleteConfirm">
          {{ t("save.deleteSave") }}
        </button>
        <button class="dropdown-item" @click="logout">
          {{ t("save.logout") }}
        </button>
      </div>
    </div>
  </div>
</template>

<style scoped>
.save-bar {
  display: flex;
  align-items: center;
  gap: 4px;
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
  white-space: nowrap;
}
.ctrl-btn:hover:not(:disabled) {
  border-color: var(--accent);
  color: var(--accent-text);
  background: var(--bg-hover);
}
.ctrl-btn:disabled { opacity: 0.6; cursor: not-allowed; }

.save-guest-btn { border-color: var(--accent); color: var(--accent-text); }
.save-guest-btn:hover { background: var(--accent); color: #fff; }

.sync-btn.synced { border-color: #22c55e; color: #22c55e; }
.sync-btn.sync-error { border-color: #f87171; color: #f87171; }

@keyframes spin { to { transform: rotate(360deg); } }
.sync-icon.spinning { display: inline-block; animation: spin 0.7s linear infinite; }

.autosave-btn.active { border-color: var(--accent); color: var(--accent-text); }

.interval-select {
  padding: 5px 8px;
  border-radius: var(--radius-sm);
  border: 1px solid var(--border);
  background: var(--bg-elevated);
  color: var(--text-secondary);
  font-size: 12px;
  font-family: inherit;
  font-weight: 600;
  cursor: pointer;
  outline: none;
  transition: border-color var(--transition-fast);
  height: 30px;
}
.interval-select:hover { border-color: var(--accent); }

.user-menu { position: relative; }

.username { max-width: 90px; overflow: hidden; text-overflow: ellipsis; }
.chevron { font-size: 10px; opacity: 0.6; margin-left: 2px; }

.dropdown-menu {
  position: absolute;
  top: calc(100% + 4px);
  right: 0;
  background: var(--bg-surface);
  border: 1px solid var(--border);
  border-radius: var(--radius-sm);
  min-width: 150px;
  z-index: 200;
  overflow: hidden;
  animation: fadeScaleIn 140ms ease;
  box-shadow: 0 8px 24px rgba(0, 0, 0, 0.3);
}

.dropdown-item {
  display: block;
  width: 100%;
  text-align: left;
  padding: 9px 14px;
  font-size: 13px;
  font-weight: 500;
  background: transparent;
  color: var(--text-secondary);
  transition: all var(--transition-fast);
}
.dropdown-item:hover { background: var(--bg-hover); color: var(--text-primary); }
.dropdown-item.danger { color: #f87171; }
.dropdown-item.danger:hover { background: rgba(248, 113, 113, 0.08); }
</style>
