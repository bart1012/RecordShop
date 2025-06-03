import { useContext, createContext, useState, useEffect } from "react";
import  { getIsUserAuthenticated,postUserLogin } from "../scripts/authService";


const AuthContext = createContext();

export function useAuthentication() {
    return useContext(AuthContext);
}

export function AuthProvider({ children }) {

    const [isAuthenticated, setIsAuthenticated] = useState(false);

    useEffect(()=> {
        async function checkForExistingCookie() {
            const authResult = await hasAuthCookie();
            setIsAuthenticated(authResult);
        }
        checkForExistingCookie();
    }, []);

        const hasAuthCookie = async () => {
        var authenticationResult = await getIsUserAuthenticated();
        return authenticationResult.status == 200 ? true : false;
    }

    const userLogin = async (email, password) => {
        var loginResponse = await postUserLogin(email, password);

        if(loginResponse.status == 200){
            setIsAuthenticated(true);
        }
        
        return loginResponse;
    }



 
    return (
        <AuthContext.Provider 
        value={{ isAuthenticated,  userLogin}}>
            {children}
        </AuthContext.Provider>
    );
}



