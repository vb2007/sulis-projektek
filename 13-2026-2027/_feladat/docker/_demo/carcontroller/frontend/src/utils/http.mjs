import axios from 'axios'

/**
 * Configure the global Axios instance for backend API communication.
 * Always check the current environment for the correct Base URL.
 * 
 * @type {import('axios').AxiosInstance}
 */
export const api = axios.create({
    baseURL: import.meta.env.VITE_BACKEND_URL,
    headers:{
        "Accept": "application/json",
        "Content-Type": "application/json" 
    }
})
