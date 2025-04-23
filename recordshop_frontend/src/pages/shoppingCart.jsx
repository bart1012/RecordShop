import ProductSummary from "../components/ProductSummary.jsx"
import { UseShoppingCart } from "../context/ShoppingCartContext.jsx"
import { Link } from "react-router";

const ShoppingCart = () => {

    const {cart} = UseShoppingCart();

    return <>
        <div className="mb-4 col-start-4 col-span-4">
                <h1 className="text-2xl font-semibold w-full text-center mb-2">Cart</h1>
                <div className="flex flex-row justify-center">
                    <span className="itemCount">{cart.length} Items |</span>
                    <span className="totalPrice ml-2">£0.00</span>
                </div>
        </div>

        <div className="grid p-6 grid-cols-12 ">

            <div className="flex flex-col col-start-4 col-span-3">
                {cart.map((item) => <ProductSummary album={item}></ProductSummary>)}
            </div>

            <div className="flex flex-col col-start-7 col-span-3 pl-5">
                <div className="flex flex-col">
                <p>Summary: </p>
                <br></br>
                <p>Total: £12.00</p>
                <Link to="checkout/tunnel">
                <button className="bg-blue-400 text-white">Checkout</button>
                </Link>
                </div>
            </div>
        </div>
    </>
}

export default ShoppingCart