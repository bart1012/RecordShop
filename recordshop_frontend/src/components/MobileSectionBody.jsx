import React from "react";
import Card from "./AlbumCard";

const MobileSectionBody = ({title, style, albums}) => {
    return (
    <section className="h-full w-auto flex flex-col max-w-screen overflow-hidden md:mx-20">

        <div className="flex flex-wrap justify-between px-4">
            <h2 className="text-xl font-semibold mb-3">{title}</h2>
            <p className="text-gray-400 mt-1">View all</p>
        </div>

        <div className="h-full">
            <ul className="flex flex-row gap-4 overflow-y-auto px-4 pb-4 min-h-[100px] h-full">
            {
                !albums
                ? [...Array(6).keys()].map(key => (
                    <li key={key} className="h-auto">  
                        <Card style={style} />
                        
                    </li>       
                    ))
                : albums.map(album => (
                    <li key={album.name} className="h-auto">  
                        <Card style={style} album={album} />
                    </li>
                    ))
            }   
            </ul>
          

            {/* change this to an unordered list, fetch api data and map each item into a card  */}
        </div>

    </section>
    )
}

export default MobileSectionBody;