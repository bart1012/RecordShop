import Card from "../components/AlbumCard";
import {  useSearchParams } from "react-router";
import { useState, useEffect } from "react";
import { FetchAlbumsByQuery, FetchAllAlbums, FetchMostRecent } from "../scripts/albumApiService";

const NewReleases = () => {

    const [data, setData] = useState(null);

    async function FetchAlbumData(){
            const response =  await FetchMostRecent();
            setData(response);    
    }

    useEffect(()=>{
        FetchAlbumData();
    }, []);

    return<main className="mx-auto lg:mt-[2rem] w-[60%]">
        <h1 className="text-2xl font-semibold mb-10">New Releases</h1>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4 justify-center mb-15">
            {data?.map((searchResults) => <Card album={searchResults}></Card>)}
        </div>     
    </main>
}

export default NewReleases;