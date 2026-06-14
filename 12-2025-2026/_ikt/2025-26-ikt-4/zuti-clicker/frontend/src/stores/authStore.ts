import { defineStore } from "pinia";
import { ref, computed } from "vue";
import { api } from "@/lib/api";
import type { AuthUser } from "@/types";

export const useAuthStore = defineStore("auth", () => {
  const user = ref<AuthUser | null>(null);
  const isLoggedIn = computed(() => user.value !== null);
  const isChecked = ref(false);

  async function checkSession(): Promise<void> {
    try {
      const data = await api.auth.me();
      user.value = data.user;
    } catch {
      user.value = null;
    } finally {
      isChecked.value = true;
    }
  }

  async function login(email: string, password: string): Promise<void> {
    await api.auth.login(email, password);
    const data = await api.auth.me();
    user.value = data.user;
    isChecked.value = true;
  }

  async function register(
    username: string,
    email: string,
    password: string
  ): Promise<void> {
    await api.auth.register(username, email, password);
    await login(email, password);
  }

  async function logout(): Promise<void> {
    try {
      await api.auth.logout();
    } catch {
      // clear local state regardless
    } finally {
      user.value = null;
    }
  }

  return { user, isLoggedIn, isChecked, checkSession, login, register, logout };
});
