import React from "react";
import Button from "./Button";
import { useState, useEffect } from "react";
import { useAuthentication } from "../context/AuthContext";

const RegistrationWindow = ({userEmail}) => {

    const [isPasswordValid, setIsPasswordValid] = useState(null);
    const {handleRegistration} = useAuthentication();

    const extractFormData = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        const registrationDTO = Object.fromEntries(formData.entries());
        registrationDTO.email = userEmail;
        return registrationDTO;
    }

    const validatePassword = (password) => {

        console.log(password);
        const isCorrectLength = password.length > 5;
        return /^(?=.*\d)(?=.*[A-Z])(?=.*[^a-zA-Z0-9])/.test(password) && isCorrectLength;
    }
    

    const handleFormSubmission = async (e) => {

        const formData = extractFormData(e);
        const isInputPasswordValid = validatePassword(formData.password);

        if(!isInputPasswordValid){
            setIsPasswordValid(false);
            return;
        }
            
        await handleRegistration(formData);
        
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

                            <div className="flex flex-row items-center gap-4 col-span-12 rounded-md w-full h-[3.5rem]">
                                <input type="checkbox" id="conditionsCheckbox" name="conditionsCheckbox" value="Agree"></input>
                                <label for="conditionsCheckbox">I agree to Terms of Use and I confirm I have read the Privacy Policy.</label>
                            </div>
                        </div>
                        <div>
                        <button type="submit" className="btn">Create Account</button>
                        {(isPasswordValid != null && isPasswordValid == false) && <p>Invalid password!</p>}
                        </div>
                    </form>
               

               

        

            </div>
            </div>

    </section>);
};

export default RegistrationWindow;