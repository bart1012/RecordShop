import { useState } from "react";
import Button from "../components/Button";
import { useNavigate } from "react-router";
import { EmailIsTaken } from "../scripts/apiService";
import EmailAvailabilityChecker from "../components/emailAvailabilityCheck";
import LoginWindow from "../components/LogInWindow";
import SignupWindow from "../components/SignupWindow";

const Registration = () => {

    const navigate = useNavigate();
    const [pipelineStep, setPipelineStep] = useState("emailCheck");
    const [userEmail, setUserEmail] = useState(null);
    const changePipelineStep = (nextPipelineStep) => {
        setPipelineStep(nextPipelineStep);
    }
    const changeUserEmail = (email) => {
        setUserEmail(email);
    }

    return <main className="w-screen h-screen"> 

        <header className="h-auto px-[3rem] py-[1rem]">
            <button className="text-[3rem] text-gray cursor-pointer" onClick={()=>navigate(-1)}>🡐</button>
        </header>

    {pipelineStep === "emailCheck" &&
        <EmailAvailabilityChecker redirectFunction={changePipelineStep} setUserEmailFunction={changeUserEmail}></EmailAvailabilityChecker>}

    {pipelineStep === "login" &&
        <LoginWindow userEmail={userEmail}></LoginWindow>}

    {pipelineStep === "signup" &&
        <SignupWindow userEmail={userEmail}></SignupWindow>
    }
    </main>
}

export default Registration;