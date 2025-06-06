import { useContext, createContext, useState, useEffect } from "react";
import  { checkUserAuthStatus, loginUser, logoutUser, registerUser } from "../scripts/authService";


const AuthContext = createContext();

export function useAuthentication() {
    return useContext(AuthContext);
}

export function AuthProvider({ children }) {

    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(()=> {
        async function checkForExistingCookie() {
            const authResult = await hasAuthCookie();
            console.log(`Auth result: ${authResult}`);
            setIsAuthenticated(authResult);
        }
        checkForExistingCookie();
    }, []);

    const hasAuthCookie = async () => {
        var authenticationResult = await checkUserAuthStatus();
        return authenticationResult.status === 200 ? true : false;
    }

    const handleLogin = async (email, password) => {

        var loginResponse = await loginUser(email, password);

        if(loginResponse.statusCode === 200){
            setIsAuthenticated(true);
        }
        
        return loginResponse;
    }

    const handleLogout = async () => {

        const logoutResponse = await logoutUser();

        if(logoutResponse.statusCode === 200){
            console.log(`logging out`);
            setIsAuthenticated(false);
        }
        
    }
    const handleRegistration = async (registrationDTO) => {

        var apiResponse = await registerUser(registrationDTO);

        if(apiResponse.success &&
            apiResponse.statusCode === 200){

                const loginResult = await handleLogin(registrationDTO.email, registrationDTO.password);

                return {
                    isRegistered: true,
                    isLoggedin: loginResult.success && loginResult.statusCode === 200
                };

        }
        
        if(!apiResponse.success &&
            apiResponse.statusCode === 400){
                return {
                    isRegistered: false,
                    isLoggedin: false,
                    message: "Validation error during registration."
                };
        }

    }



 
    return (
        <AuthContext.Provider 
        value={{ isAuthenticated,  handleLogin, handleRegistration, handleLogout}}>
            {children}
        </AuthContext.Provider>
    );
}



