import Card from "../components/AlbumCard"
import { UseShoppingCart } from "../context/ShoppingCartContext"
import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import {FetchAlbumByID} from "../scripts/apiService"
import Button from "../components/Button";
import SongTab from "../components/SongTab";



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
            <div className="flex flex-col p-4 gap-6">

                <div className="grid grid-cols-2 grid-rows-2">
                    <h1 className="font-semibold text-2xl">{data?.name}</h1>
                    {data?.artists.map((artist) => <h2 className="text-lg text-gray-500 row-start-2">{artist}</h2>)}
                    <span className="row-span-2 text-lg font-semibold text-center flex items-center justify-end mr-4">£12.99</span>
                </div>

                <div className="flex flex-col gap-2 items-center max-w-screen">
                    <Button text="Add To Wishlist"></Button>
                    <Button text="Add To Cart" onClickFunction={() => IncreaseCartQuantity(data)}></Button>
                </div>

                <div>
                    <ul>
                        {data?.songs.map((song, i) => <li key={song.name}><SongTab song={song} index={i+1}></SongTab></li>)}
                    </ul>
                </div>

            </div>
         </>
   
    )
}

export default Product