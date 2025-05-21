import Card from "../components/AlbumCard"
import { UseShoppingCart } from "../context/ShoppingCartContext"
import React, { useEffect, useState } from "react";
import { useParams } from "react-router";
import {FetchAlbumByID} from "../scripts/apiService"
import Button from "../components/Button";
import SongTab from "../components/SongTab";
import {CartModal} from "../components/CartModal";



const Product = () => {

    const [data, setData] = useState(null);
    const [modalIsActive, setModalState] = useState(false);
    const { IncreaseCartQuantity } = UseShoppingCart();
    const { id } = useParams();
    
    async function FetchData(id){
        const albumData = await FetchAlbumByID(id);
        setData(albumData);
    }

    useEffect(() => {FetchData(id);}, []);


    return(
     
        <main className="grid grid-cols-12 mt-15">


                <CartModal  album={data} isActive={modalIsActive} toggleFunction={() => setModalState(state => !state)}></CartModal>
                
                <div className="overflow-hidden col-start-4 col-span-3">
                    
                    <img src={data?.imgURL} alt={data?.name + "album cover"} width={900} className="object-cover"></img>

                </div>

                <div className="col-start-7 col-span-3 flex flex-col pl-6"> 
 
                        <h1 className="font-semibold text-[3rem]">{data?.name}</h1>
                        {data?.artists.map((artist) => <h2 key={artist} className="font-bold text-gray-500 row-start-2">{artist}</h2>)}
                        <span className="row-span-2 text-lg font-semibold text-center flex items-center mr-4 mt-1">£{data?.pricePence / 100}</span>
                        <p className="mt-4 mb-4">Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. </p>
                        <div className="flex flex-col gap-2 items-center max-w-screen mt-8 ">
                            <Button text="Add To Wishlist"></Button>
                            <Button text="Add To Cart" onClickFunction={() => {IncreaseCartQuantity(data); setModalState(state => !state);}}></Button>
                        </div>
                </div>

                <div className="flex flex-col my-15 gap-6 col-start-4 col-span-6">

                    <div className="pb-6">
                        <h2 className="text-2xl pb-4 w-full  pt-3">Songs</h2>
                        <ul>
                            {data?.songs.map((song, i) => <li key={song.name}><SongTab song={song} index={i+1}></SongTab></li>)}
                        </ul>
                    </div>

                </div>
          
         </main>
   
    )
}

export default Product