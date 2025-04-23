import { Link } from "react-router"
import { useState } from "react";




export function CartModal ({album, isActive, toggleFunction}) {
    return(
        <div className={"lightbox absolute inset-0 min-h-full w-screen bg-white/50 z-550 " + (isActive ? 'show' : 'hidden')}>

            <div className="modalContent m-5 bg-white relative top-1/4 flex flex-col border border-gray-400 md:w-[35rem] m-auto">

                <div className="modalHeader w-full flex flex-row bg-green-300">
                    <button className="float-right p-4 cursor-pointer" onClick={toggleFunction}>✕</button>
                    <div className="confirmationMessage p-4 text-green-700">
                        <p>
                         {album?.name} has been added to your cart.
                        </p>
                    </div>
                </div>

                <div className="modalBody p-4">
                    <article className="flex flex-row justify-between">
                  

                        <div className="flex flex-col pb-4">
                            <h3 className="font-semibold text-xl">{album?.name}</h3>
                            <h4 className="text-gray-500 mb-5">{album?.artists[0]}</h4>
                            
                            <strong>£12.99</strong>
                            <strong>Quantity: 1</strong>
                        </div>

                        <figure>
                            <img src={album?.imgURL} width={120}></img>
                        </figure>

                    </article>
                    <hr className="pb-4"></hr>
                    <nav>
                        
                        <div className="flex flex-wrap justify-between">    

                            <button onClick={toggleFunction} className="cursor-pointer bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded">
                                Continue Shopping
                            </button>
                            <Link className="cursor-pointer bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded" to="/cart">
                                View Basket
                            </Link>
                        
                        </div>

                    </nav>
                </div>

            </div>
        </div>
    )
}