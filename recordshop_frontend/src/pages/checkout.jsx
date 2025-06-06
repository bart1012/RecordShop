import React from "react";
import Button from "../components/Button";
import CheckoutForm from "../components/CheckoutForm";


const Checkout = () => {
    return (<>
        <section class="bg-white py-8 antialiased md:py-16 flex flex-col">
        
            <div class="mx-auto max-w-screen-xl px-4 2xl:px-0">

                <div class="mx-auto max-w-5xl">

                <div className="title-container mx-auto max-w-screen-xl px-4 2xl:px-0 w-full">
                    <h2 className="text-[1.5rem] font-semibold">Delivery</h2>
                </div>

                <CheckoutForm></CheckoutForm>
              
                </div>
                
            </div>
        </section>

        <script src="https://cdnjs.cloudflare.com/ajax/libs/flowbite/2.3.0/datepicker.min.js"></script>
    </>)
};

export default Checkout