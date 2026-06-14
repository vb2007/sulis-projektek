import { createI18n } from "vue-i18n";
import en from "./en";
import hu from "./hu";

export const i18n = createI18n({
  legacy: false,
  locale: "en",
  fallbackLocale: "en",
  messages: { en, hu }
});
