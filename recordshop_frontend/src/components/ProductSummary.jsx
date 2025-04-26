import { UseShoppingCart } from "../context/ShoppingCartContext";

const ProductSummary = ({album}) => {

    const { DecreaseCartQuantity } = UseShoppingCart();
    
    return <>

        <div className="bg-white  border-b pb-4 mb-5 mr-10">
            <div className="flex flex-row ">
                <figure className="pr-6">
                    <img src={album?.imgURL} width={120}></img>
                </figure>
                <div className="flex flex-col pb-4">
                                <h3 className="font-semibold text-xl">{album?.name}</h3>
                                <h4 className="text-gray-500 mb-5">{album?.artists[0]}</h4>
                                
                                <strong>£{album?.pricePence / 100}</strong>
                                <span>Quantity: 1</span>
                </div>
            
            </div>
            <div className="gap-4 flex flex-row"> 
                <button onClick={() => DecreaseCartQuantity(album)} className="underline cursor-pointer	">Delete</button>
                <button className="underline cursor-pointer	">Save for later</button>
            </div>
         
        </div>
     
    </>
}

export default ProductSummary