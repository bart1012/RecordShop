import React from "react";
import Button from "./Button";
import { useState, useEffect } from "react";
import { useAuthentication } from "../context/AuthContext";
import { useNavigate } from "react-router";
import { fetchCookieValue } from "../scripts/cookieService";

const RegistrationWindow = ({userEmail}) => {

    const [passwordValidationResult, setPasswordValidationResult] = useState(null);
    const {handleRegistration} = useAuthentication();
    const navigate = useNavigate();

    const extractFormData = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        const registrationDTO = Object.fromEntries(formData.entries());
        registrationDTO.email = userEmail;
        return registrationDTO;
    }

    const validatePassword = (password) => {
        return {
            isCorrectLength: password.length > 5,
            hasDigit: /\d/.test(password),
            hasSpecialCharacter: /[^a-zA-Z0-9]/.test(password),
            hasUpperCase: /[A-Z]/.test(password)
        };
    }
    

    const handleFormSubmission = async (e) => {

        const formData = extractFormData(e);
        const isInputPasswordValid = validatePassword(formData.password);

        if(!Object.values(isInputPasswordValid).every(Boolean)){
            setPasswordValidationResult(isInputPasswordValid);
            return;
        }
            
        const registrationAndLoginResult = await handleRegistration(formData);       

        if(registrationAndLoginResult.isRegistered && registrationAndLoginResult.isLoggedin){
            navigate(fetchCookieValue('lastVisited'));
        }
    }

    return (<section className="w-1/4 h-auto flex m-auto grow items-center">
        
        <div className="w-full">
            <h2 className="text-3xl  font-semibold mb-2">Create an account</h2>
            <div>
                    <div className="flex flex-row mb-2 text-md text-gray-600 mb-7">
                            {userEmail != undefined &&
                                <>
                                <span className="mr-5">{userEmail}</span> 
                                <span className="underline">Change</span>
                                </>
                            }
                    </div>

                    <form onSubmit={handleFormSubmission} method="POST">
                        <div className="mb-8 grid grid-cols-12 gap-4">

                            <input type="text" name="firstName" id="firstName" placeholder="First Name" autocomplete="off" required 
                            className="col-span-6 rounded-md w-full h-[3.5rem]"/>
                            <input type="text" name="lastName" id="lastName" placeholder="Last Name" autocomplete="off" required 
                            className="col-start-7 col-span-6 rounded-md w-full h-[3.5rem]"/>
                            <input type="password" name="password" id="password" placeholder="Password" autocomplete="current-password" required 
                            className="col-span-12 rounded-md w-full h-[3.5rem]"/>
                            <input type="tel" name="mobileNumber" id="mobileNumber" placeholder="Phone Number" autocomplete="tel" required 
                            className="col-span-12 rounded-md w-full h-[3.5rem]"/>       
                            <input type="text" name="addressLine" id="addressLine" placeholder="Address Line" autocomplete="address-line1" required 
                            className="col-span-12 rounded-md w-full h-[3.5rem]"/>  
                            <input type="text" name="town" id="town" placeholder="City" autocomplete="address-level2" required 
                            className="col-span-4 rounded-md w-full h-[3.5rem]"/>  
                            <input type="text" name="postcode" id="postcode" placeholder="Postcode" autocomplete="postal-code" required 
                            className="col-start-5 col-span-4 rounded-md w-full h-[3.5rem]"/>  
                            <input type="text" name="country" id="country" placeholder="Country" autocomplete="country-name" required 
                            className="col-start-9 col-span-4 rounded-md w-full h-[3.5rem]"/>  

                            {(passwordValidationResult !== null) &&    
                            <>
                                <div className="col-span-12 py-4 border border-red-600 p-4 bg-red-50" role="alert">
                                    <h3 className="text-lg font-bold mb-2">Your password needs to:</h3>
                                    <ul className="list-disc list-inside pl-2">
                                        <li className={passwordValidationResult.hasDigit ? "text-green-600" : "text-red-600"}>have at least one digit</li>
                                        <li className={passwordValidationResult.hasSpecialCharacter ? "text-green-600" : "text-red-600"}>have at least one non alphanumeric character</li>
                                        <li className={passwordValidationResult.hasUpperCase ? "text-green-600" : "text-red-600"}>have at least one uppercase character</li>
                                        <li className={passwordValidationResult.isCorrectLength ? "text-green-600" : "text-red-600"}>be at least 6 characters long</li>
                                    </ul>
                                </div>
                            </>}

                            <div className="flex flex-row items-center gap-4 col-span-12 rounded-md w-full h-[3.5rem]">
                                <input type="checkbox" id="conditionsCheckbox" name="conditionsCheckbox" value="Agree"></input>
                                <label for="conditionsCheckbox">I agree to Terms of Use and I confirm I have read the Privacy Policy.</label>
                            </div>
                        </div>
                        <div>
                        <button type="submit" className="btn">Create Account</button>
                        </div>
                    </form>
               

               

        

            </div>
            </div>

    </section>);
};

export default RegistrationWindow;