import { useState, useEffect } from "react";
import Button from "./Button";
import { EmailIsTaken } from "../scripts/apiService";
const EmailAvailabilityChecker = ({redirectFunction, setUserEmailFunction}) => {

    const[emailCheckerStatus, setEmailCheckerStatus] = useState(null);
    const checkIfEmailExists = async (email) => {
        var apiResponse = await EmailIsTaken(email);
        setEmailCheckerStatus(apiResponse);
    }

    useEffect(() => {
        if(emailCheckerStatus !== null){
            if (
                emailCheckerStatus.status === "success" &&
                emailCheckerStatus.data.availability === "taken"
            ) {
                redirectFunction("login");
                setUserEmailFunction(emailCheckerStatus.data.email);
            }else if (
                emailCheckerStatus.status === "success" &&
                emailCheckerStatus.data.availability === "available"
            ){
                redirectFunction("signup");
                setUserEmailFunction(emailCheckerStatus.data.email);
            }
        }
    }, [emailCheckerStatus]);

    return      <section className="w-1/4 h-auto flex m-auto items-center align-center">
                <div className="w-full h-full mt-[13rem]">
                    <h1 className="text-3xl  font-semibold mb-5">Enter your email</h1>
                    <div className="flex flex-row mb-2 text-md text-gray-600">
                        <span className="mr-5">Location: United Kingdom</span>
                        <span className="underline">Change</span>
                    </div>
                    <input type="email" id="emailInput" name="email" placeholder="Email" className="h-[3.5rem] rounded-md w-full" autoComplete="off" onKeyDown={(e)=>{
                        if(e.key === "Enter"){
                            checkIfEmailExists(document.getElementById("emailInput").value);
                        }
                    }}/>
                    <div className="mt-2 mb-5 flex flex-col">
                        {(emailCheckerStatus !== null && emailCheckerStatus.status === "error") && 
                        <p className="text-red-400 mb-3">An error has occured. Please try again.</p>}
                        {(emailCheckerStatus !== null && emailCheckerStatus.status === "success" && emailCheckerStatus.data.availability === "taken") 
                        && <p className="text-red-400 mb-3">This email is already in use. Please try <span className="underline">logging in</span> or use a different email address.</p>}
                        <p className="text-sm text-gray-600">
                            By continuing, you agree to nothing at all. We promise we won't send you spam.
                        </p>
                    </div>
                    <Button text={"Continue"} onClickFunction={()=> checkIfEmailExists(document.getElementById("emailInput").value)}></Button>
                </div>
            </section>   
}

export default EmailAvailabilityChecker