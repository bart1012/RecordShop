import axios from "axios";


const BASE_URL = 'https://localhost:7195/';

const FetchAllGenres = async () => {
    const URL = BASE_URL + 'Genres';
    try{
        var response = await axios.get(URL);
        return response.data;
    }catch(error){
        console.error("Error fetch genre data: ", error);
        return [];
    }
}

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
        return response.status === 204 ? null : response.data;
    }catch(error){
        console.error("Error fetching albums matching this query: ", error);
        return [];  
    }
}

const EmailIsTaken = async (email) => { 
    const URL = BASE_URL + 'Users/Email-Exists?email=' + email; 
    try{
        const response = await axios.get(URL);
        return {
            status: "success",
            data: response.data
        }
    }catch(error){
        console.error("Error checking email against existing data ", error);
        return {
            status: "error",
            message: "Something went wrong. Please try again."
        }
    }
}

const RegisterNewUser = async (uEmail, uPassword) => { 
    const URL = BASE_URL + 'register';
    try{
        const response = await axios.post(URL, {
            "email": uEmail,
            "password": uPassword
          });

          if (response.status === 200) {
            return { success: true };
          } else {
            return { success: false, error: response.data };
          }   

        }catch(error){
        console.error("Error sending user data to the API", error);
        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
}
export  {RegisterNewUser, EmailIsTaken, FetchAllAlbums, FetchAlbumByID, FetchMostRecent, FetchAlbumsByQuery, FetchAllGenres};