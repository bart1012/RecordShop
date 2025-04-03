import Card from "../components/AlbumCard"
import { UseShoppingCart } from "../context/ShoppingCartContext"
import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import {FetchAlbumByID} from "../scripts/apiService"
import Button from "../components/Button";



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
            <div className="flex flex-col p-4">
                <h2 className="font-bold text-xl">{data?.name}</h2>
                {data?.artists.map((artist) => <span>{artist}</span>)}
                <p>{data?.releaseDate}</p>
                <div className="flex flex-col gap-2 items-center max-w-screen">
                    <Button text="Add To Wishlist"></Button>
                    <Button text="Add To Cart" onClickFunction={() => IncreaseCartQuantity(data)}></Button>
                </div>
                <div>
                    <ul>
                        {data?.songs.map((song) => <li key={song.name} className="border-b-1">{song.name}</li>)}
                    </ul>
                </div>
            </div>
         </>
   
    )
}

export default Product