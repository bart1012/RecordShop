const ProductSummary = ({album}) => {
    return <>
        <div className="bg-red-400">
            <div>
                <h2>{album?.name}</h2>
            </div>
            <div>
                <button>Delete</button>
                <button>Save for later</button>
            </div>
        </div>
    </>
}

export default ProductSummary