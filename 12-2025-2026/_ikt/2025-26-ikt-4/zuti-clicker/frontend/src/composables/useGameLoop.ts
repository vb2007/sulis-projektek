import { onMounted, onUnmounted } from "vue";
import { useGameStore } from "@/stores/gameStore";
import { TICK_RATE } from "@/utils/gameConstants";

export function useGameLoop() {
  const gameStore = useGameStore();
  let intervalId: ReturnType<typeof setInterval>;

  onMounted(() => {
    intervalId = setInterval(() => {
      gameStore.tick(1 / TICK_RATE);
    }, 1000 / TICK_RATE);
  });

  onUnmounted(() => clearInterval(intervalId));
}
