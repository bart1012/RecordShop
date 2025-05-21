import React from "react";
import { Link } from "react-router";

const Card = ({album}) => {
    const cardURL = `http://localhost:5173/albums/${album?.id}`
    return <>
    <Link to={cardURL} >
    <article className="w-auto md:w-full ">
            <div className={"mb-2 overflow-hidden w-full h-full rounded-xl bg-white" }> 
                <img className="object-cover h-full w-full"  src={album?.imgURL || "./images/no-image.svg"} alt={album?.Name + " album cover" || "Album Cover"}></img>
            </div>
            {album && <div>
                <h4 className="font-semibold">{album?.name}</h4>
                <h5 className="text-gray-800 mb-1">{album?.artists[0]}</h5>
                <h3 className="font-semibold">£{(album?.pricePence / 100).toLocaleString("en", { minimumFractionDigits: 2 })}</h3>
            </div>}
      

    </article>
    </Link>
    </>
}

export default Card