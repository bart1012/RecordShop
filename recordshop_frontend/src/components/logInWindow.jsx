import React, { useState } from "react";
import Button from "./Button";
import { useNavigate } from "react-router";
import "../css/customStyles.css";
import { fetchCookieValue } from "../scripts/cookieService";
import { useAuthentication } from "../context/AuthContext";

const LoginWindow = ({userEmail}) => {

    const [isPasswordCorrect, setIsPasswordCorrect] = useState(null);
    const {handleLogin} = useAuthentication();
    const navigate = useNavigate();

    const loginUser = async (event) => {

        event.preventDefault();
        
        const userPassword = document.getElementById("passwordInput").value;


        var apiResponse = await handleLogin(userEmail, userPassword);

        if(apiResponse.success &&
            apiResponse.statusCode === 200){
                alert("user logged in");
                navigate(fetchCookieValue('lastVisited'));
               
        }else if(!apiResponse.success &&
            apiResponse.statusCode === 401){
                alert("wrong password");
                setIsPasswordCorrect(false);
        }else{
            alert("api failure");
        }

    }

    return (<section className="w-1/4 h-auto flex m-auto items-center align-center">
        <div className="w-full h-full mt-[13rem]">
            <h2 className="text-3xl  font-semibold mb-2">What's your password?</h2>
            <div>

                <form  onSubmit={loginUser} method="POST">

                    <div className="flex flex-row mb-2 text-md text-gray-600 mb-7">

                        {userEmail != undefined &&
                        <>
                            <span className="mr-5">{userEmail}</span> 
                            <span className="underline">Change</span>
                        </>
                        }
                            
                    </div>

                    <div className="mb-8">

                        <input type="password" name="password" id="passwordInput" placeholder="Password" autocomplete="current-password" required 
                        className="rounded-md w-full mb-3 h-[3.5rem]"/>
                        {isPasswordCorrect === false && 
                            <>
                                <div>
                                    <p className="error">Incorrect password. Please try again.</p>
                                </div>
                            </>
                        }
                        <a href="#" className="text-sm underline font-semibold text-gray-600 hover:text-gray-500">Forgot password?</a>
                
                    </div>

                    <div>
                        <button type="submit" className="btn" 
                        >Log in</button>
                    </div>

                </form>

        

            </div>
            </div>

    </section>);
};

export default LoginWindow;