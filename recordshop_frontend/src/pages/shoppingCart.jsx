import ProductSummary from "../components/ProductSummary.jsx"
import { UseShoppingCart } from "../context/ShoppingCartContext.jsx"
import { Link, useNavigate } from "react-router";
import Button from "../components/Button.jsx";
import { useState } from "react";
import { CheckoutMethodsModal } from "../components/checkoutMethodModal.jsx";
import { useAuthentication } from "../context/AuthContext.jsx";

const ShoppingCart = () => {

    const {isAuthenticated} = useAuthentication();
    const navigate = useNavigate();
    const {cart, CartItemQuantity} = UseShoppingCart();
    const totalPrice = cart.reduce((sum, album) => sum + (album.pricePence * album.quantity), 0) / 100;
    const [checkoutOptionsAreVisible, setCheckoutOptionsVisibility] = useState(false);
    const handleCheckoutClick = () => {
        if(isAuthenticated){
            navigate('/checkout');
        }else{
            setCheckoutOptionsVisibility(true);
        }
    }

 
    return <>
        <CheckoutMethodsModal isActive={checkoutOptionsAreVisible} toggleFunction={()=>setCheckoutOptionsVisibility(false)}></CheckoutMethodsModal>
        <div className="mb-4 col-start-4 col-span-4 mt-15">
                <h1 className="text-2xl font-semibold w-full text-center mb-2">Cart</h1>
                <div className="flex flex-row justify-center">
                    <span className="itemCount">{CartItemQuantity} Items |</span>
                    <span className="totalPrice ml-2">£{totalPrice}</span>
                </div>
        </div>

        <div className="grid p-6 grid-cols-12 ">

            <div className="flex flex-col col-start-4 col-span-4">
                {cart.map((item) => <ProductSummary album={item}></ProductSummary>)}
            </div>

            <div className="flex flex-col col-start-8 col-span-2 pl-5">
                <div className="flex flex-col">
                    <h2 className="text-2xl font-semibold">Order summary: </h2>
                    <br></br>

                    <p className="text-gray-600 font-semibold border-b-1 py-1 ">Subtotal: <span className="float-right">£{totalPrice}</span></p>

                    <p className="text-gray-600 font-semibold border-b-1 py-1 ">Delivery: <span className="float-right">£4.99</span></p>
          
                    <p className="text-black font-semibold pt-1 text-xl text-black">Total: <span className="float-right text-xl text-black">£{totalPrice}</span></p>
                    <p className="mb-15 text-xs text-gray-600">VAT Inclusive</p>

                    <button className="btn" onClick={handleCheckoutClick}>Checkout</button>            
                </div>
            </div>
        </div>
    </>
}

export default ShoppingCart