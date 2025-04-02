import ProductSummary from "../components/ProductSummary.jsx"
import { UseShoppingCart } from "../context/ShoppingCartContext.jsx"


const ShoppingCart = () => {

    const {cart} = UseShoppingCart();

    return <>
        {cart.map((item) => <ProductSummary album={item}></ProductSummary>)}
        <br></br>
        <p>Total: </p>
        <button>Place order</button>
    </>
}

export default ShoppingCart