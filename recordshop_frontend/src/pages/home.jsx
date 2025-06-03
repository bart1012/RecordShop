import React, { useEffect, useState } from "react";
import Card from "../components/AlbumCard";
import TodaysPicksCarusel from "../components/CaruselFeatures";
import MobileSectionBody from "../components/mobileSectionBody";
import {FetchAllAlbums, FetchMostRecent} from "../scripts/albumApiService";

const Home = () => {

    const [albums, setAlbums] = useState(null); 
    const [newReleases, setNewReleases] = useState(null); 
  

    async function fetchAllAlbums() {    
            const response = await FetchAllAlbums();
            setAlbums(response);
    }

    async function fetchNewReleases() {
            const response = await FetchMostRecent();
            setNewReleases(response);
    }

    useEffect(()=>{
        fetchAllAlbums();
        fetchNewReleases();
    }, []);

    return (
        <div className="h-auto w-auto flex flex-col gap-6">
            <TodaysPicksCarusel />
            <MobileSectionBody title={"Popular"} albums={albums}/>
            <MobileSectionBody title={"New Releases"} albums={newReleases} link={"/new"}/>
            <MobileSectionBody title={"Best Sellers"} albums={albums}/>
        </div>
    );
};

export default Home;
