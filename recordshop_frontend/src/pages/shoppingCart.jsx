import ProductSummary from "../components/ProductSummary.jsx"
import { UseShoppingCart } from "../context/ShoppingCartContext.jsx"


const ShoppingCart = () => {

    const {cart} = UseShoppingCart();

    return <>
        <div className="p-6">
            <div className="mb-4">
                <h1 className="text-2xl font-semibold w-full text-center mb-2">Cart</h1>
                <div className="flex flex-row justify-center">
                    <span className="itemCount">{cart.length} Items |</span>
                    <span className="totalPrice ml-2">£0.00</span>
                </div>
            </div>
            {cart.map((item) => <ProductSummary album={item}></ProductSummary>)}
            <br></br>
            <p>Total: </p>
            <button>Place order</button>
        </div>
    </>
}

export default ShoppingCart