const ProductSummary = ({album}) => {
    return <>

        <div className="bg-white border-t border-b pt-4 pb-4">
            <div className="flex flex-row ">
                <figure className="pr-6">
                    <img src={album?.imgURL} width={120}></img>
                </figure>
                <div className="flex flex-col pb-4">
                                <h3 className="font-semibold text-xl">{album?.name}</h3>
                                <h4 className="text-gray-500 mb-5">{album?.artists[0]}</h4>
                                
                                <strong>£12.99</strong>
                                <span>Quantity: 1</span>
                </div>
            
            </div>
            <div className="gap-4 flex flex-row"> 
                <button className="underline">Delete</button>
                <button className="underline">Save for later</button>
            </div>
         
        </div>
     
    </>
}

export default ProductSummary