import ProductSummary from "../components/ProductSummary.jsx"
import { UseShoppingCart } from "../context/ShoppingCartContext.jsx"
import { Link } from "react-router";
import Button from "../components/Button.jsx";

const ShoppingCart = () => {

    const {cart} = UseShoppingCart();
    const totalPrice = cart.reduce((sum, album) => sum + (album.pricePence), 0) / 100;

    return <>
        <div className="mb-4 col-start-4 col-span-4">
                <h1 className="text-2xl font-semibold w-full text-center mb-2">Cart</h1>
                <div className="flex flex-row justify-center">
                    <span className="itemCount">{cart.length} Items |</span>
                    <span className="totalPrice ml-2">£{totalPrice}</span>
                </div>
        </div>

        <div className="grid p-6 grid-cols-12 ">

            <div className="flex flex-col col-start-4 col-span-3">
                {cart.map((item) => <ProductSummary album={item}></ProductSummary>)}
            </div>

            <div className="flex flex-col col-start-7 col-span-3 pl-5">
                <div className="flex flex-col">
                    <h2 className="text-xl font-semibold">Summary: </h2>
                    <br></br>
                    <p className="font-semibold border-t-1 border-b-1 py-1 mb-5">Total: <span className="float-right">£{totalPrice}</span></p>
                    <Link to="checkout/tunnel">
                    <Button text={"Checkout"} className="bg-blue-400 text-white">Checkout</Button>
                    </Link>
                </div>
            </div>
        </div>
    </>
}

export default ShoppingCart