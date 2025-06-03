import Card from "../components/AlbumCard";
import {  useSearchParams } from "react-router";
import { useState, useEffect } from "react";
import { FetchAlbumsByQuery, FetchAllAlbums } from "../scripts/albumApiService";

const SearchResults = () => {
    const [searchParams] = useSearchParams();
    const searchQuery = searchParams.get('q');
    const [data, setData] = useState(null);

    async function FetchAlbumData(){
            const response = searchQuery === "" ? await FetchAllAlbums() : await FetchAlbumsByQuery(searchQuery);
            setData(response);    
    }

    useEffect(()=>{
        FetchAlbumData();
    });

    return<main className="mx-auto lg:mt-[2rem] w-[60%]">
        <h1 className="text-2xl font-semibold mb-10">Results for: <span>{searchQuery}</span></h1>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4 justify-center mb-15">
            {data != null && data?.map((searchResults) => <Card album={searchResults}></Card>)}
        </div>     
    </main>
}

export default SearchResults;