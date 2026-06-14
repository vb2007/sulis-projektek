<script setup lang="ts">
import { onMounted, onUnmounted, watch } from "vue";
import { useI18n } from "vue-i18n";
import { useAuthStore } from "@/stores/authStore";
import { useSaveStore } from "@/stores/saveStore";
import { useUiStore } from "@/stores/uiStore";
import { useGameStore } from "@/stores/gameStore";
import AppHeader from "@/components/layout/AppHeader.vue";
import StatusColumn from "@/components/status/StatusColumn.vue";
import ClickerArea from "@/components/clicker/ClickerArea.vue";
import UnitsPanel from "@/components/units/UnitsPanel.vue";
import AuthModal from "@/components/modals/AuthModal.vue";
import GuestWarningModal from "@/components/modals/GuestWarningModal.vue";
import ConfirmModal from "@/components/modals/ConfirmModal.vue";
import { useGameLoop } from "@/composables/useGameLoop";

const { t } = useI18n();
const auth = useAuthStore();
const save = useSaveStore();
const ui = useUiStore();
const game = useGameStore();

useGameLoop();

onMounted(async () => {
  await auth.checkSession();
});

watch(
  () => auth.isLoggedIn,
  async (loggedIn) => {
    if (loggedIn) await save.load();
  }
);

function handleBeforeUnload(e: BeforeUnloadEvent) {
  if (game.totalClicks > 0) {
    e.preventDefault();
    e.returnValue = "";
  }
}
onMounted(() => window.addEventListener("beforeunload", handleBeforeUnload));
onUnmounted(() => window.removeEventListener("beforeunload", handleBeforeUnload));

async function onConfirmDelete() {
  await save.resetSave();
  ui.confirmDeleteOpen = false;
}
</script>

<template>
  <div class="app">
    <AppHeader />
    <div class="game-layout">
      <StatusColumn />
      <ClickerArea />
      <UnitsPanel />
    </div>
  </div>

  <AuthModal />
  <GuestWarningModal />
  <ConfirmModal
    v-if="ui.confirmDeleteOpen"
    :title="t('confirm.deleteSaveTitle')"
    :body="t('confirm.deleteSaveBody')"
    :confirm-label="t('confirm.deleteBtn')"
    :cancel-label="t('confirm.cancelBtn')"
    @confirm="onConfirmDelete"
    @cancel="ui.confirmDeleteOpen = false"
  />
</template>

<style scoped>
.app {
  height: 100vh;
  display: flex;
  flex-direction: column;
  overflow: hidden;
}

.game-layout {
  display: grid;
  grid-template-columns: 252px 1fr 288px;
  flex: 1;
  overflow: hidden;
}
</style>
