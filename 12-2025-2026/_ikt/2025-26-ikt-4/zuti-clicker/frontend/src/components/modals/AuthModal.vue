<script setup lang="ts">
import { ref } from "vue";
import { useI18n } from "vue-i18n";
import { useAuthStore } from "@/stores/authStore";
import { useUiStore } from "@/stores/uiStore";
import { ApiError } from "@/lib/api";

const { t } = useI18n();
const auth = useAuthStore();
const ui = useUiStore();

const tab = ref<"login" | "register">("login");
const email = ref("");
const username = ref("");
const password = ref("");
const isLoading = ref(false);
const error = ref<string | null>(null);

function close() {
  ui.authModalOpen = false;
  error.value = null;
}

function switchTab(newTab: "login" | "register") {
  tab.value = newTab;
  error.value = null;
}

async function submit() {
  error.value = null;
  isLoading.value = true;
  try {
    if (tab.value === "login") {
      await auth.login(email.value, password.value);
    } else {
      await auth.register(username.value, email.value, password.value);
    }
    close();
  } catch (e) {
    error.value = e instanceof ApiError ? e.message : "An unexpected error occurred.";
  } finally {
    isLoading.value = false;
  }
}
</script>

<template>
  <Teleport to="body">
    <div v-if="ui.authModalOpen" class="modal-backdrop" @click.self="close">
      <div class="modal" role="dialog" aria-modal="true">
        <button class="modal-close" @click="close" aria-label="Close">✕</button>

        <div class="modal-tabs">
          <button
            :class="['tab-btn', { active: tab === 'login' }]"
            @click="switchTab('login')"
          >{{ t("auth.loginTab") }}</button>
          <button
            :class="['tab-btn', { active: tab === 'register' }]"
            @click="switchTab('register')"
          >{{ t("auth.registerTab") }}</button>
        </div>

        <form class="modal-form" @submit.prevent="submit">
          <div v-if="tab === 'register'" class="form-group">
            <label>{{ t("auth.usernameLabel") }}</label>
            <input
              v-model="username"
              type="text"
              autocomplete="username"
              required
              :placeholder="t('auth.usernameLabel')"
            />
          </div>
          <div class="form-group">
            <label>{{ t("auth.emailLabel") }}</label>
            <input
              v-model="email"
              type="email"
              autocomplete="email"
              required
              :placeholder="t('auth.emailLabel')"
            />
          </div>
          <div class="form-group">
            <label>{{ t("auth.passwordLabel") }}</label>
            <input
              v-model="password"
              type="password"
              :autocomplete="tab === 'login' ? 'current-password' : 'new-password'"
              required
              :placeholder="t('auth.passwordLabel')"
            />
          </div>

          <p v-if="error" class="error-msg">{{ error }}</p>

          <button type="submit" class="submit-btn" :disabled="isLoading">
            {{ isLoading ? "…" : tab === "login" ? t("auth.loginBtn") : t("auth.registerBtn") }}
          </button>
        </form>

        <button class="switch-btn" @click="switchTab(tab === 'login' ? 'register' : 'login')">
          {{ tab === "login" ? t("auth.switchToRegister") : t("auth.switchToLogin") }}
        </button>
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
  z-index: 1000;
  animation: fadeIn 180ms ease;
}

.modal {
  position: relative;
  background: var(--bg-surface);
  border: 1px solid var(--border);
  border-radius: var(--radius-md);
  padding: 28px 32px 24px;
  width: 100%;
  max-width: 400px;
  animation: fadeScaleIn 200ms ease;
  box-shadow: 0 20px 60px rgba(0, 0, 0, 0.4);
}

.modal-close {
  position: absolute;
  top: 12px;
  right: 14px;
  background: transparent;
  color: var(--text-muted);
  font-size: 14px;
  padding: 4px 6px;
  border-radius: var(--radius-xs);
  transition: color var(--transition-fast);
}
.modal-close:hover { color: var(--text-primary); }

.modal-tabs {
  display: flex;
  gap: 4px;
  margin-bottom: 24px;
  background: var(--bg-elevated);
  padding: 4px;
  border-radius: var(--radius-sm);
}

.tab-btn {
  flex: 1;
  padding: 7px 12px;
  border-radius: calc(var(--radius-sm) - 2px);
  font-size: 13px;
  font-weight: 600;
  background: transparent;
  color: var(--text-secondary);
  transition: all var(--transition-fast);
}
.tab-btn.active { background: var(--accent); color: #fff; }
.tab-btn:not(.active):hover { color: var(--text-primary); }

.modal-form { display: flex; flex-direction: column; gap: 14px; }

.form-group { display: flex; flex-direction: column; gap: 5px; }

.form-group label {
  font-size: 12px;
  font-weight: 600;
  color: var(--text-secondary);
  text-transform: uppercase;
  letter-spacing: 0.4px;
}

.form-group input {
  padding: 9px 12px;
  background: var(--bg-elevated);
  border: 1px solid var(--border);
  border-radius: var(--radius-sm);
  color: var(--text-primary);
  font-size: 14px;
  font-family: inherit;
  transition: border-color var(--transition-fast);
  outline: none;
}
.form-group input:focus { border-color: var(--accent); }

.error-msg {
  font-size: 12px;
  color: #f87171;
  background: rgba(248, 113, 113, 0.1);
  border: 1px solid rgba(248, 113, 113, 0.25);
  border-radius: var(--radius-xs);
  padding: 6px 10px;
  margin: 0;
}

.submit-btn {
  padding: 10px;
  background: var(--btn-buy-bg);
  color: var(--btn-buy-text);
  border-radius: var(--radius-sm);
  font-size: 14px;
  font-weight: 700;
  transition: background var(--transition-fast);
  margin-top: 4px;
}
.submit-btn:hover:not(:disabled) { background: var(--accent-dim); }
.submit-btn:disabled { opacity: 0.6; cursor: not-allowed; }

.switch-btn {
  display: block;
  margin: 16px auto 0;
  background: transparent;
  color: var(--text-muted);
  font-size: 12px;
  text-decoration: underline;
  text-underline-offset: 2px;
  transition: color var(--transition-fast);
}
.switch-btn:hover { color: var(--accent-text); }
</style>
