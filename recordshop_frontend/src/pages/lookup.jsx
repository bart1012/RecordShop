import { useState } from "react";
import Button from "../components/Button";
import { useLocation, useNavigate } from "react-router";
import { isEmailTaken } from "../scripts/authService";
import EmailAvailabilityChecker from "../components/emailAvailabilityCheck";
import LoginWindow from "../components/LogInWindow";
import RegistrationWindow from "../components/RegistrationWindow";

const Lookup = () => {
    const location = useLocation();
    const navigatedFrom = location.state?.from;
    document.cookie = `lastVisited=${encodeURIComponent(navigatedFrom)}; path=/; max-age=300`;
    const navigate = useNavigate();
    const [userEmail, setUserEmail] = useState(null);
    const changeUserEmail = (email) => {
        setUserEmail(email);
    }

    return <main className="w-screen h-screen"> 

        <header className="h-auto px-[3rem] py-[1rem]">
            <button className="text-[3rem] text-gray cursor-pointer" onClick={()=>navigate(-1)}>🡐</button>
        </header>
        <EmailAvailabilityChecker></EmailAvailabilityChecker>
    </main>
}

export default Lookup;