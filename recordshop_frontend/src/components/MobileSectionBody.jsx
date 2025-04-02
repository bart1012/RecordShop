import React from "react";
import Card from "./AlbumCard";

const MobileSectionBody = ({title, style}) => {
    return (
    <section className="h-40 w-full flex flex-col">
        <div className="flex flex-wrap justify-between">
            <h2 className="text-xl   font-semibold mb-5">{title}</h2>
            <p className="text-gray-400 mt-1">View all</p>
        </div>
        <div className="grid gap-4 grid-cols-3 grid-rows-1 h-full">
            <Card style={style}></Card>
            <Card style={style}></Card>
            <Card style={style}></Card>
        </div>
    </section>
    )
}

export default MobileSectionBody;