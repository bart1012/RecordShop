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
        console.error("Error fetching album:", error);
        return [];  
    }
}

export  {FetchAllAlbums, FetchAlbumByID};