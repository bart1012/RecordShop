import { useState } from "react";
import Button from "../components/Button";
import { useNavigate, useSearchParams } from "react-router";
import { isEmailTaken } from "../scripts/authService";
import EmailAvailabilityChecker from "../components/emailAvailabilityCheck";
import LoginWindow from "../components/LogInWindow";
import RegistrationWindow from "../components/RegistrationWindow";

const Login = () => {
   
    const navigate = useNavigate();
    let [searchParams, setSearchParams] = useSearchParams();
    const changeUserEmail = (email) => {
        setUserEmail(email);
    }

    return <main className="w-screen h-screen"> 

        <header className="h-auto px-[3rem] py-[1rem]">
            <button className="text-[3rem] text-gray cursor-pointer" onClick={()=>navigate(-1)}>🡐</button>
        </header>
        <LoginWindow userEmail={decodeURIComponent(searchParams.get('email'))}></LoginWindow>
    </main>
}

export default Login;