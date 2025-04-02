import React from "react";
import { Link } from "react-router";

const Card = ({album, style = "regular"}) => {
    return <>
    <Link to="/products" >
        <article className="w-full h-auto">
            <div className={style == "rounded" ? "rounded-full bg-red-400 w-full h-[7rem] overflow-hidden" : "rounded-lg bg-red-400 w-full h-full overflow-hidden" }> 
                <img src="https://i.scdn.co/image/ab67616d0000b27328933b808bfb4cbbd0385400" alt={album?.Name + " album cover" || "Album Cover"}></img>
            </div>
        </article>
    </Link>
    </>
}

export default Card