import axios from "axios";

const BASE_URL = 'https://localhost:7195/';

const checkUserAuthStatus = async () => {

    const URL = BASE_URL + "check-auth";
    try{
        const response = await axios.get(URL,  { withCredentials: true });
        console.log(response);  
        return response;
    }catch(error){
         if(error.response && error.response.status === 401){
            console.error(error);
            return {
            success: false,
            statusCode: error.response.status,
            message: error.response,
            }
        }
        console.error("API error: ", error);
        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
};

const isEmailTaken = async (email) => { 
    const URL = BASE_URL + 'is-email-taken?email=' + email; 
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

const loginUser = async (email, password) => {

    const URL = BASE_URL + "login?useCookies=true";

    try{
        const response = await axios.post(URL, {
            "email": email, 
            "password": password
        }, {withCredentials: true});
        return  {
            success: true,
            statusCode: response.status,
            data: response.data,
        };

    }catch(error){

        if(error.response && error.response.status === 401){
            return {
            success: false,
            statusCode: error.response.status,
            message: "Invalid credentials. Please try again.",
            }
        }

        console.error("Error authenticating user", error);
        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
};

const logoutUser = async() => {

    const URL = BASE_URL + "logout";

    try{
        const response = await axios.post(URL, {
        }, {withCredentials: true});
        console.log(response);
        return  {
            success: true,
            statusCode: response.status,
            data: response.data,
        };

    }catch(error){

        console.error("Error logging out user", error);

        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
} 

const registerUser = async (registrationDTO) => {

    const URL = BASE_URL + "register";
    console.log("authService:")
    console.log(registrationDTO);

    try{
        const response = await axios.post(URL, registrationDTO);
        return  {
            success: true,
            statusCode: response.status,
            data: response.data,
        };
    }catch(error){
        if(error.response && error.response.status === 400){
            console.error(error);
            return {
            success: false,
            statusCode: error.response.status,
            message: error.response,
            }
        }
        console.error("Error authenticating user", error);
        return {
            success: false,
            message: "Something went wrong. Please try again.",
            apiError: error
        }
    }
};


export  {isEmailTaken, loginUser, registerUser, checkUserAuthStatus, logoutUser};