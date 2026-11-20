import { ref } from 'vue'

const errorMessage = ref('')
let timeoutId = null

export function useErrorToast() {
    const clearError = () => {
        errorMessage.value = ''
        clearTimeout(timeoutId)
    }

    const showError = (message, duration = 4000) => {
        errorMessage.value = message
        clearTimeout(timeoutId)

        if (duration > 0) {
            timeoutId = setTimeout(clearError, duration)
        }
    }

    return {
        errorMessage,
        showError,
        clearError,
    }
}