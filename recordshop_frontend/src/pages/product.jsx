import Card from "../components/AlbumCard"

const Product = () => {
    return(
        <>
         <div className="h-85 w-full">
          <Card></Card>
         </div>
         <h2>AlbumName</h2>
         <p>Artist Name</p>
         <div className="flex justify-between">
            <button>Add to wishlist</button>
            <button>Add to cart</button>
         </div>
        </>
    )
}

export default Product