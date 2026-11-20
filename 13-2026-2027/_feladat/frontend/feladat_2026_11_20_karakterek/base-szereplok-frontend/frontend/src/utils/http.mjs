import axios from 'axios';

/**
* @type {import('axios').AxiosInstance}
*/
export const api = axios.create({
    baseURL: import.meta.env.VITE_BACKEND_URL + '/api',
    header: {
        "Accept": "application/json",
        "Content-Type": "application/json"
    }
});