import React, { useEffect, useState } from "react";
import Card from "../components/AlbumCard";
import TodaysPicksCarusel from "../components/caruselFeatures";
import MobileSectionBody from "../components/mobileSectionBody";
import {FetchAllAlbums} from "../scripts/apiService";

const Home = () => {
    const [data, setData] = useState([]); 
    const [loading, setLoading] = useState(true);

    async function fetchData() {
        try {
            const albumData = await FetchAllAlbums();
            setData(albumData);
        } catch (error) {
            console.error("Error calling backend API: ", error);
        } finally {
            setLoading(false);
        }
    }

    useEffect(() => {
        fetchData();
    }, []);

    useEffect(() => {
        console.log("API Response Data:", data[0]);
    }, [data]); 

    return (
        <div className="h-full grid gap-6">
   
            <TodaysPicksCarusel album={data[0]} />
            <MobileSectionBody title={"Popular"} />
            <MobileSectionBody title={"New Releases"} />
            <MobileSectionBody title={"Best Sellers"} />
            <MobileSectionBody title={"Featured Artists"} style={"rounded"}/>
        </div>
    );
};

export default Home;
