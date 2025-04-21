import React from "react";
import Card from "./AlbumCard";

const TodaysPicksCarusel = ({imgURL}) => {
    return (
        <>
         <section className="w-full flex flex-col font-semibold text-xl items-center md:h-[35rem] h-[25rem] max-h-[35rem] bg-black">
            <div className="w-full h-full bg-white">
                <ul className="h-full">
                    <li className="h-full"><img width={1024} className="object-cover w-full h-full"src={imgURL}></img></li>
                </ul>
            </div>  
         </section>
        </>
    )
}

export default TodaysPicksCarusel      