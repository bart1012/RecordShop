import { useState } from "react";
import Button from "../components/Button";
import { useNavigate } from "react-router";
import { isEmailTaken } from "../scripts/authService";
import EmailAvailabilityChecker from "../components/emailAvailabilityCheck";
import LoginWindow from "../components/LogInWindow";
import RegistrationWindow from "../components/RegistrationWindow";
import { useSearchParams } from "react-router";

const Registration = () => {

    const navigate = useNavigate();
    let [searchParams, setSearchParams] = useSearchParams();

    return <main className="w-screen h-screen flex flex-col"> 

        <header className="h-auto px-[3rem] py-[1rem]">
            <button className="text-[3rem] text-gray cursor-pointer" onClick={()=>navigate(-1)}>🡐</button>
        </header>

        <RegistrationWindow userEmail={decodeURIComponent(searchParams.get('email'))}>
            
        </RegistrationWindow>
    </main>
}

export default Registration;