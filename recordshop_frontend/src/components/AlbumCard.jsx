import React from "react";
import { Link } from "react-router";

const Card = ({album, style = "regular"}) => {
    const cardURL = `http://localhost:5173/albums/${album?.id}`
    return <>
    <Link to={cardURL} >
    <article className="w-[7rem]  md:w-full ">
            <div className={"mb-2 overflow-hidden " + (style === "rounded" ? "rounded-full sm:w-[7rem] sm:h-[7rem] md:h-[13rem] md:w-[13rem]" : "w-full h-full") }> 
                <img className="object-cover h-full w-full"  src={album?.imgURL || "https://i.scdn.co/image/ab6761610000e5eba00b11c129b27a88fc72f36b"} alt={album?.Name + " album cover" || "Album Cover"}></img>
            </div>
            
            {style === 'regular' &&
                <div>
                   <h4 className="font-semibold">{album?.name}</h4>
                   <h5 className="text-gray-800 mb-1">{album?.artists[0]}</h5>
                   <h3>£{album?.pricePence / 100}</h3>
               </div>
            }
         
    </article>
    </Link>
    </>
}

export default Card