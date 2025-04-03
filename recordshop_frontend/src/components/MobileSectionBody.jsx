import React from "react";
import Card from "./AlbumCard";

const MobileSectionBody = ({title, style, albums}) => {
    return (
    <section className="h-auto w-full flex flex-col max-w-screen">

        <div className="flex flex-wrap justify-between px-4">
            <h2 className="text-xl   font-semibold mb-3">{title}</h2>
            <p className="text-gray-400 mt-1">View all</p>
        </div>

        <div>
            <ul className="flex flex-row gap-4 overflow-y-auto px-4 pb-4">
            {
                !albums
                ? [...Array(6).keys()].map(key => (
                    <li key={key}>  
                        <Card style={style} />
                    </li>   
                    ))
                : albums.map(album => (
                    <li key={album.name}>  
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