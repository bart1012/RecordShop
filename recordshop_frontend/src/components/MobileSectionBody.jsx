import React from "react";
import Card from "./AlbumCard";
import "../css/customStyles.css";
import { Link } from "react-router";

const MobileSectionBody = ({title, albums, link}) => {

    return (
    <section className="h-full w-auto flex flex-col max-w-screen overflow-hidden md:mx-20">

        <div className="flex flex-wrap justify-between px-4">
            <h2 className="text-xl font-semibold mb-3">{title}</h2>
            <Link to={link}><p className="text-gray-400 mt-1">View all</p></Link>
        </div>

        <div className="h-full w-auto">
            <ul className="scrollList scrollListElement flex flex-row gap-4 overflow-x-auto px-4 pb-4 md:min-h-[25rem]">
            {
                !albums
                ? [...Array(6).keys()].map(key => (
                    <li key={key} className="h-auto">  
                        <Card  />
                        
                    </li>       
                    ))
                : albums.map(album => (
                    <li key={album.name} className="flex-shrink-0 h-[17rem] w-[17rem] bg-red-400">  
                        <Card  album={album} />
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