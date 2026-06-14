import { defineStore } from "pinia";
import { ref } from "vue";

export const useUiStore = defineStore("ui", () => {
  const authModalOpen = ref(false);
  const confirmDeleteOpen = ref(false);
  const guestWarningDismissed = ref(false);

  return { authModalOpen, confirmDeleteOpen, guestWarningDismissed };
});
