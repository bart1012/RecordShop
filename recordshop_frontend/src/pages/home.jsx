import React, { useEffect, useState } from "react";
import Card from "../components/AlbumCard";
import TodaysPicksCarusel from "../components/caruselFeatures";
import MobileSectionBody from "../components/mobileSectionBody";
import {FetchAllAlbums, FetchMostRecent} from "../scripts/apiService";

const Home = () => {
    const [albums, setAlbums] = useState([]); 
    const [newReleases, setNewReleases] = useState(null); 

    async function fetchAllAlbums() {
        try {
            const response = await FetchAllAlbums();
            setAlbums(response);
        } catch (error) {
            console.error("Error calling backend API: ", error);
        }
    }

    async function fetchNewReleases() {
        try {
            const response = await FetchMostRecent();
            setNewReleases(response);
        } catch (error) {
            console.error("Error calling backend API: ", error);
        }
    }

    useEffect(() => {
        fetchAllAlbums(); fetchNewReleases();
    }, []);


    return (
        <div className="h-auto w-auto flex flex-col gap-6">
   
            <TodaysPicksCarusel imgURL={"../public/images/HomePageBanner1.webp"} />
            <MobileSectionBody title={"Popular"} albums={albums}/>
            <MobileSectionBody title={"New Releases"} albums={newReleases}/>
            <MobileSectionBody title={"Best Sellers"} albums={albums}/>
            <MobileSectionBody title={"Featured Artists"} style={"rounded"}/>
        </div>
    );
};

export default Home;
