import React from "react";
import Button from "./Button";

const LoginWindow = ({userEmail}) => {
    return (<section className="w-1/4 h-auto flex m-auto items-center align-center">
        <div className="w-full h-full mt-[13rem]">
            <h2 className="text-3xl  font-semibold mb-2">What's your password?</h2>
            <div>

                <form  action="#" method="POST">

                    <div className="flex flex-row mb-2 text-md text-gray-600 mb-7">
                            <span className="mr-5">{userEmail}</span>
                            <span className="underline">Change</span>
                    </div>

                    <div className="mb-8">

                        <input type="password" name="password" id="password" placeholder="Password" autocomplete="current-password" required 
                        className="rounded-md w-full mb-3 h-[3.5rem]"/>
                        <a href="#" className="text-sm underline font-semibold text-gray-600 hover:text-gray-500">Forgot password?</a>
                
                    </div>

                    <div>
                        <Button text={"Sign in"}></Button>
                    </div>

                </form>

        

            </div>
            </div>

    </section>);
};

export default LoginWindow;