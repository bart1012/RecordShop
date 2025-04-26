import Card from "../components/AlbumCard";
import { useParams } from "react-router";
import { useState, useEffect } from "react";
import { FetchAllAlbums } from "../scripts/apiService";

const SearchResults = () => {
    const searchQuery = useParams();
    const [data, setData] = useState(null);
    const searchResults = null;

    async function FetchAlbumData(){
        try{
            const response = await FetchAllAlbums();
            setData(response);
        }catch (error){
            console.error("Couldn't fetch album data: ", error);
        }
    }

    useEffect(()=>{
        FetchAlbumData();
    });

    searchResults = data.filter(album => 
        album.name.toLowerCase().Includes(searchQuery.toLowerCase()) ||
        album.artist[0].toLowerCase().Includes(searchQuery.toLowerCase())
    );

    return<main className="mx-auto lg:mt-[2rem] w-[60%]">
        <h1 className="text-2xl font-semibold mb-10">Results for: <span>Keyword</span></h1>
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-4 justify-center">
            {data?.map((searchResults) => <Card album={searchResults}></Card>)}
        </div>     
    </main>
}

export default SearchResults;