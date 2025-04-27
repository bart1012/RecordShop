import axios from "axios";


const BASE_URL = 'https://localhost:7195/';

const FetchAllAlbums = async () => {
    const URL = BASE_URL + 'Albums';
    try{

        const response = await axios.get(URL);
        return response.data;

    }catch(error){
        console.error("Error fetching albums:", error);
        return [];  
    }
    
}

const FetchAlbumByID = async (id) => {
    const URL = BASE_URL + `Albums/` + id;
    console.log(URL);
    try{
        const response = await axios.get(URL);
        return response.data;
    }catch(error){
        console.error(`Error fetching album with id: ${id}`, error);
        return [];  
    }
}

const FetchMostRecent = async () => {
    const URL = BASE_URL + 'Albums/New'
    try{
        const response = await axios.get(URL);
        return response.data;
    }catch(error){
        console.error("Error fetching new releases:", error);
        return [];  
    }
}

const FetchAlbumsByQuery = async (q) => {
    const URL = BASE_URL + 'Albums/search?q=' + q; 
    try{
        const response = await axios.get(URL);
        return response.data;
    }catch(error){
        console.error("Error fetching albums matching this query: ", error);
        return [];  
    }
}
export  {FetchAllAlbums, FetchAlbumByID, FetchMostRecent, FetchAlbumsByQuery};