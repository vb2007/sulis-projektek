export function setTitle(to, from) {
  document.title = `${to.meta.title} | ${import.meta.env.VITE_APP_NAME}`
  return true
}
