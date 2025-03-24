import axios from 'axios';

const API_BASE_URL = 'https://localhost:7195'

const apiService = axios.create({
    baseURL: API_BASE_URL,
});

const fetchAllAlbums = async () => {
    try {
        const httpResponse = await apiService.get(API_BASE_URL + "/Albums");
        return httpResponse.data;
    } catch (error) {
        throw error;
    }
}

export { fetchAllAlbums }