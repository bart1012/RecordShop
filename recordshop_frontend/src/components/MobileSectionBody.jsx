import React from "react";
import Card from "./AlbumCard";
import "../css/customStyles.css";
import { Link } from "react-router";

const MobileSectionBody = ({title, albums, link}) => {

    return (
    <section className="h-full w-auto flex flex-col max-w-screen overflow-hidden md:mx-20 mb-5">

        <div className="flex flex-wrap justify-between px-4">
            <h2 className="text-xl font-semibold mb-3">{title}</h2>
            <Link to={link}><p className="text-gray-400 mt-1">View all</p></Link>
        </div>

        <div className="h-full w-auto">
            <ul className={ (albums ? "md:min-h-[25rem] " : "md:min-h-[18rem] ") + "scrollList scrollListElement flex flex-row gap-4 overflow-x-auto px-4 pb-4"}>
            {
                !albums
                ? [...Array(6).keys()].map(key => (
                    <li key={key} className="flex-shrink-0 h-[10rem] w-[17rem]">  
                        <Card  />
                        
                    </li>       
                    ))
                : albums.map(album => (
                    <li key={album.name} className="flex-shrink-0 h-[17rem] w-[17rem]">  
                        <Card  album={album} />
                    </li>
                    ))
            }   
            </ul>
          

        </div>

    </section>
    )
}

export default MobileSectionBody;