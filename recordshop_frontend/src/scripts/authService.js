import axios from "axios";

const BASE_URL = 'https://localhost:7195/';

const getIsUserAuthenticated = async () => {

    const URL = BASE_URL + "check-auth";
    try{
        const response = await axios.get(URL);
        return response;
    }catch(error){
        console.error("Error validating user.", error);
        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
};

const postUserLogin = async (email, password) => {

    const URL = BASE_URL + "login?useCookies=true";

    try{
        const response = await axios.post(URL, {
            "email": email, 
            "password": password
        }, {withCredentials: true});
        return response;
    }catch(error){
        console.error("Error authenticating user", error);
        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
};

const postUserRegistration = async (email, password, firstName, 
    lastName, mobileNumber, addressLine, town, postCode, country) => {

    const URL = BASE_URL + "login?useCookies=true";

    try{
        const response = await axios.post(URL, {
            
            "email": email,
            "password": password,
            "firstName": firstName,
            "lastName": lastName,
            "mobileNumber": mobileNumber,
            "addressLine": addressLine,
            "town": town,
            "postcode": postCode,
            "country": country

        });
        return response;
    }catch(error){
        console.error("Error authenticating user", error);
        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
};


export  {postUserLogin, postUserRegistration, getIsUserAuthenticated};