import { defineStore } from "pinia";
import { ref, watch } from "vue";
import { api, ApiError } from "@/lib/api";
import { useAuthStore } from "./authStore";
import { useGameStore } from "./gameStore";

export const useSaveStore = defineStore("save", () => {
  const auth = useAuthStore();
  const game = useGameStore();

  const autosaveEnabled = ref(true);
  const autosaveIntervalSecs = ref(30);
  const lastSyncedAt = ref<Date | null>(null);
  const isSyncing = ref(false);
  const syncError = ref<string | null>(null);

  let _timer: ReturnType<typeof setInterval> | null = null;

  function _clearTimer(): void {
    if (_timer !== null) {
      clearInterval(_timer);
      _timer = null;
    }
  }

  function _startTimer(): void {
    _clearTimer();
    if (autosaveEnabled.value && auth.isLoggedIn) {
      _timer = setInterval(() => {
        void sync();
      }, autosaveIntervalSecs.value * 1000);
    }
  }

  watch(
    [autosaveEnabled, autosaveIntervalSecs, () => auth.isLoggedIn],
    _startTimer,
    { immediate: true }
  );

  async function load(): Promise<void> {
    if (!auth.isLoggedIn) return;
    try {
      const data = await api.save.load();
      if (data.save) {
        game.loadFromSave(data.save);
        lastSyncedAt.value = new Date(data.save.savedAt);
      }
    } catch {
      // No save yet — start fresh
    }
  }

  async function sync(): Promise<void> {
    if (!auth.isLoggedIn || isSyncing.value) return;
    isSyncing.value = true;
    syncError.value = null;
    try {
      const result = await api.save.store(game.toSavePayload());
      lastSyncedAt.value = new Date(result.savedAt);
    } catch (e) {
      syncError.value = (e as ApiError).message;
    } finally {
      isSyncing.value = false;
    }
  }

  async function resetSave(): Promise<void> {
    if (!auth.isLoggedIn) return;
    await api.save.reset();
    lastSyncedAt.value = null;
  }

  return {
    autosaveEnabled,
    autosaveIntervalSecs,
    lastSyncedAt,
    isSyncing,
    syncError,
    load,
    sync,
    resetSave
  };
});
