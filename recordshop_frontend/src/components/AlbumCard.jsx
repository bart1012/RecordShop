import React from "react";
import { Link } from "react-router";

const Card = ({album, style = "regular"}) => {
    const cardURL = `http://localhost:5173/albums/${album?.id}`
    return <>
    <Link to={cardURL} >
        <article className="w-[7rem] h-[7rem]">
            <div className={style === "rounded" ? "rounded-full bg-red-400 w-[7rem] h-[7rem] overflow-hidden" : "rounded-lg bg-red-400 w-full h-full overflow-hidden" }> 
                <img className="object-cover h-full w-full"  src={album?.imgURL || "https://facesconsent.com/images/default-vendor-image.png"} alt={album?.Name + " album cover" || "Album Cover"}></img>
            </div>
        </article>
    </Link>
    </>
}

export default Card