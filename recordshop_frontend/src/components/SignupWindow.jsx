import React from "react";
import Button from "./Button";

const SignupWindow = ({userEmail}) => {
    return (<section className="w-1/4 h-auto flex m-auto items-center align-center">
        <div className="w-full h-full mt-[13rem]">
            <h2 className="text-3xl  font-semibold mb-2">Create an account</h2>
            <div>

                <form  action="#" method="POST">

                    <div className="flex flex-row mb-2 text-md text-gray-600 mb-7">
                            <span className="mr-5">{userEmail}</span>
                            <span className="underline">Change</span>
                    </div>

                    <div className="mb-8">

                        <div className="flex flex-row justify-between gap-3">
                            <input type="text" name="firstName" id="firstName" placeholder="First Name" autocomplete="off" required 
                            className="rounded-md w-full mb-3 h-[3.5rem]"/>
                            <input type="text" name="lastName" id="lastName" placeholder="Last Name" autocomplete="off" required 
                            className="rounded-md w-full mb-3 h-[3.5rem]"/>
                        </div>

                        <input type="password" name="password" id="password" placeholder="Password" autocomplete="current-password" required 
                        className="rounded-md w-full mb-3 h-[3.5rem]"/>
                        <div className="flex flex-row items-center gap-4">
                            <input type="checkbox" id="conditionsCheckbox" name="conditionsCheckbox" value="Agree"></input>
                            <label for="conditionsCheckbox">I agree to Terms of Use and I confirm I have read the Privacy Policy.</label>
                        </div>
                
                    </div>

                    <div>
                        <Button text={"Create Account"}></Button>
                    </div>

                </form>

        

            </div>
            </div>

    </section>);
};

export default SignupWindow;