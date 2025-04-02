import Card from "../components/AlbumCard"
import { UseShoppingCart } from "../context/ShoppingCartContext"
import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import {FetchAlbumByID} from "../scripts/apiService"



const Product = () => {

    const [data, setData] = useState(null);
    const { IncreaseCartQuantity } = UseShoppingCart();
    const { id } = useParams();
    
    async function FetchData(id){
        const albumData = await FetchAlbumByID(id);
        setData(albumData);
    }

    useEffect(() => {FetchData(id);}, []);


    return(
     
        <>
            <div className="h-85 w-full overflow-hidden">
            <img src={data?.imgURL} alt={data?.name + "album cover"}></img>
            </div>
            <h2 className="font-bold text-xl">{data?.name}</h2>
            {data?.artists.map((artist) => <span>{artist}</span>)}
            <p>{data?.releaseDate}</p>
            <div className="flex justify-between">
                <button className="p2 bg-blue-400 text-white px-4">Add to wishlist</button>
                <button className="p2 bg-blue-400 text-white px-4" onClick={()=>{IncreaseCartQuantity(data)}}>Add To Cart</button>
            </div>
            <div>
                <ul>
                    {data?.songs.map((song) => <li className="border-b-1">{song.name}</li>)}
                </ul>
            </div>
         </>
   
    )
}

export default Product