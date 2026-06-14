<script setup lang="ts">
import { computed } from "vue";
import { useI18n } from "vue-i18n";
import { useAuthStore } from "@/stores/authStore";
import { useUiStore } from "@/stores/uiStore";

const { t } = useI18n();
const auth = useAuthStore();
const ui = useUiStore();

const visible = computed(
  () => auth.isChecked && !auth.isLoggedIn && !ui.guestWarningDismissed
);

function openAuth() {
  ui.guestWarningDismissed = true;
  ui.authModalOpen = true;
}

function dismiss() {
  ui.guestWarningDismissed = true;
}
</script>

<template>
  <Teleport to="body">
    <div v-if="visible" class="modal-backdrop">
      <div class="modal" role="alertdialog" aria-modal="true">
        <div class="modal-icon">💾</div>
        <h2 class="modal-title">{{ t("guest.warningTitle") }}</h2>
        <p class="modal-body">{{ t("guest.warningBody") }}</p>
        <div class="modal-actions">
          <button class="btn-primary" @click="openAuth">{{ t("guest.loginBtn") }}</button>
          <button class="btn-ghost" @click="dismiss">{{ t("guest.continueBtn") }}</button>
        </div>
      </div>
    </div>
  </Teleport>
</template>

<style scoped>
.modal-backdrop {
  position: fixed;
  inset: 0;
  background: rgba(0, 0, 0, 0.55);
  display: flex;
  align-items: center;
  justify-content: center;
  z-index: 900;
  animation: fadeIn 220ms ease;
}

.modal {
  background: var(--bg-surface);
  border: 1px solid var(--border);
  border-radius: var(--radius-md);
  padding: 36px 32px 28px;
  width: 100%;
  max-width: 400px;
  text-align: center;
  animation: fadeScaleIn 240ms ease;
  box-shadow: 0 20px 60px rgba(0, 0, 0, 0.4);
}

.modal-icon { font-size: 40px; margin-bottom: 14px; line-height: 1; }

.modal-title {
  font-size: 17px;
  font-weight: 800;
  color: var(--text-primary);
  margin-bottom: 10px;
}

.modal-body {
  font-size: 13px;
  color: var(--text-secondary);
  line-height: 1.6;
  margin-bottom: 24px;
}

.modal-actions { display: flex; flex-direction: column; gap: 8px; }

.btn-primary {
  padding: 10px 16px;
  background: var(--btn-buy-bg);
  color: var(--btn-buy-text);
  border-radius: var(--radius-sm);
  font-size: 14px;
  font-weight: 700;
  transition: background var(--transition-fast);
}
.btn-primary:hover { background: var(--accent-dim); }

.btn-ghost {
  padding: 8px 16px;
  background: transparent;
  color: var(--text-muted);
  font-size: 12px;
  border-radius: var(--radius-sm);
  transition: color var(--transition-fast);
}
.btn-ghost:hover { color: var(--text-secondary); }
</style>
