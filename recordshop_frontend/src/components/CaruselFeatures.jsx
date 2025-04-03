import React from "react";
import Card from "./AlbumCard";

const TodaysPicksCarusel = ({album}) => {
    return (
        <>
         <section className=" w-full flex flex-col font-semibold text-xl items-center">
            <ul>
                <li><img src={album?.imgURL}></img></li>
            </ul>
         </section>
        </>
    )
}

export default TodaysPicksCarusel      