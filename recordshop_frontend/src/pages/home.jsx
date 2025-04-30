import React, { useEffect, useState } from "react";
import Card from "../components/AlbumCard";
import TodaysPicksCarusel from "../components/caruselFeatures";
import MobileSectionBody from "../components/mobileSectionBody";
import {FetchAllAlbums, FetchMostRecent} from "../scripts/apiService";

const Home = () => {
    const [albums, setAlbums] = useState([]); 
    const [newReleases, setNewReleases] = useState(null); 
    const featuredImgUrls = [
        "images/featuredBannerImages/HomePageBanner11.webp",
        "images/featuredBannerImages/HomePageBanner2.webp",
        "images/featuredBannerImages/HomePageBanner3.webp"
    ];

    async function fetchAllAlbums() {    
            const response = await FetchAllAlbums();
            setAlbums(response);
    }

    async function fetchNewReleases() {
            const response = await FetchMostRecent();
            setNewReleases(response);
    }

    useEffect(() => {
        fetchAllAlbums(); fetchNewReleases();
    }, []);


    return (
        <div className="h-auto w-auto flex flex-col gap-6">
   
            <TodaysPicksCarusel imgURLs={featuredImgUrls} />
            <MobileSectionBody title={"Popular"} albums={albums}/>
            <MobileSectionBody title={"New Releases"} albums={newReleases} link={"/new"}/>
            <MobileSectionBody title={"Best Sellers"} albums={albums}/>
            <MobileSectionBody title={"Featured Artists"}/>
        </div>
    );
};

export default Home;
