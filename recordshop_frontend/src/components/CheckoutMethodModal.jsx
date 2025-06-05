import { Link, useNavigate } from "react-router"
import { useState } from "react";
import Button from "./Button";




export function CheckoutMethodsModal ({isActive, toggleFunction}) {
    const location = useNavigate();
    return(
        <div className={"lightbox absolute inset-0 min-h-full w-screen bg-white/50 z-550 " + (isActive ? 'show' : 'hidden')}>

            <div className="modalContent m-5 bg-white relative top-1/4 flex flex-col border border-gray-400 md:w-[25rem] m-auto">

                <div className="modalHeader w-full flex flex-row">
                    <button className="float-right px-5 pt-5 pb-3 cursor-pointer" onClick={toggleFunction}>✕</button>
                </div>

                <div className="modalBody flex flex-col justify-center px-5 mb-8">

                        <h1 className="text-2xl font-semibold mb-2">Checkout as a member</h1>
                        <ul className="mb-5 list-disc ml-5">
                            <li className="text-sm text-gray-800">Earn points and use them for discounts</li>
                            <li className="text-sm text-gray-800">Get exclusive offers and deals</li>
                            <li className="text-sm text-gray-800">Free delivery on orders over £15.00</li>
                        </ul>
                        <Link to="/lookup" state={{from: location.pathname}}><Button text={"Continue"}></Button></Link>
                        <div className="flex flex-row my-5 items-center text-gray-600">
                            <hr className="flex-auto"></hr>
                            <span className="px-2">Or</span>
                            <hr className="flex-auto"></hr>
                        </div>
                        <Link to="/checkout"><Button text={"Checkout as guest"} colour="white"></Button></Link>
                </div>

            </div>
        </div>
    )
}