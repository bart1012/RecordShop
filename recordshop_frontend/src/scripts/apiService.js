import axios from "axios";


const BASE_URL = 'https://localhost:7195/';

const FetchAllAlbums = async () => {
    const URL = BASE_URL + 'Albums';
    try{
        const httpClient = await axios.get(URL);
        return httpClient.data;
    }catch(error){
        throw error;      
    }
    
}

export default FetchAllAlbums;