import { useState } from "react";
import Button from "../components/Button";
import { useNavigate } from "react-router";
import { EmailIsTaken } from "../scripts/apiService";

const Registration = () => {

    const navigate = useNavigate();
    const[emailInputMessage, setEmailInputMessage] = useState(null);
    const checkIfEmailExists = async (email) => {

        var apiResponse = await EmailIsTaken(email);
        setEmailInputMessage(apiResponse);
    }

    return <main className="w-screen h-screen"> 

        <header className="h-auto px-[3rem] py-[1rem]">
            <button className="text-[3rem] text-gray cursor-pointer" onClick={()=>navigate(-1)}>🡐</button>
        </header>

        <section className="w-1/4 h-auto flex m-auto items-center align-center">
            <div className="w-full h-full mt-[13rem]">
                <h1 className="text-3xl  font-semibold mb-5">Create an account</h1>
                <div className="flex flex-row mb-2 text-md text-gray-600">
                    <span className="mr-5">Location: United Kingdom</span>
                    <span className="underline">Change</span>
                </div>
                <input type="text" id="emailInput" name="email" placeholder="Email" className="rounded-md w-full" autoComplete="off" onKeyDown={(e)=>{
                    if(e.key === "Enter"){
                        checkIfEmailExists(document.getElementById("emailInput").value);
                    }
                }}/>
                <div className="mt-2 mb-5 flex flex-col">
                    {(emailInputMessage !== null && emailInputMessage.status === "error") && <p className="text-red-400 mb-3">An error has occured. Please try again.</p>}
                    {(emailInputMessage !== null && emailInputMessage.status === "success" && emailInputMessage.data.availability === "taken") && <p className="text-red-400 mb-3">This email is already in use. Please try <span className="underline">logging in</span> or use a different email address.</p>}
                    <p className="text-sm text-gray-600">
                        By continuing, you agree to nothing at all. We promise we won't send you spam.
                    </p>
                </div>
                <Button text={"Continue"} onClickFunction={()=> checkIfEmailExists(document.getElementById("emailInput").value)}></Button>
            </div>
        </section>   

    </main>
}

export default Registration;