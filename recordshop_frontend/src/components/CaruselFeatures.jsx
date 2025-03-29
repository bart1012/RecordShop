import React from "react";
import Card from "./AlbumCard";

const TodaysPicksCarusel = () => {
    return (
        <>
         <section className="h-100 w-full flex flex-col font-semibold text-xl justify-center items-center">
            <h2 className="w-full mb-5 ">Today's Picks</h2>
            <Card></Card>
         </section>
        </>
    )
}

export default TodaysPicksCarusel      