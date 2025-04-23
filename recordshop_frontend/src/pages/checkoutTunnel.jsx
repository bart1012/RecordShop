import Button from "../components/Button.jsx";
import LoginWindow from "../components/logInWindow.jsx";
import { Link } from "react-router";

const CheckoutTunnel = () => {
    return (<>
        <h1 className="text-center text-xl font-semibold md:my-25">Checkout</h1>

        <div className="w-screen">

            <div className="flex flex-row w-fit mx-auto">
                <div className="lg:h-[25rem] lg:w-[30rem] border-r-2 border-gray-400 flex flex-col gap-5">
                    <h2 className="text-lg font-semibold text-center">Checkout as a member</h2>
                    <Link to="/login">
                    <Button text={"Login or Sign Up"} className="mb"></Button>
                    </Link>
       
                </div>
                <div className="lg:h-[25rem] lg:w-[30rem]  flex flex-col gap-5">
                    <h2 className="text-lg font-semibold text-center">Checkout as a quest</h2>
                    <Button text={"Check out as guest"}></Button>
                </div>
            </div>

        </div>
    </>)
};

export default CheckoutTunnel