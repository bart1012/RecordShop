import { useContext, createContext, useState, useEffect } from "react";
import  { checkUserAuthStatus, loginUser, logoutUser } from "../scripts/authService";


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
            console.log(`setting isAuth to true`);
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
        var apiResponse = await postUserRegistration(registrationDTO);

        if(apiResponse.success &&
            apiResponse.statusCode === 200){
                alert("new account created");
        }else if(!apiResponse.success &&
            apiResponse.statusCode === 400){
                alert("error in registration");
        }else{
            alert("api failure");
        }
    }



 
    return (
        <AuthContext.Provider 
        value={{ isAuthenticated,  handleLogin, handleRegistration, handleLogout}}>
            {children}
        </AuthContext.Provider>
    );
}



