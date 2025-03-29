import React from "react";
import Card from "../components/AlbumCard";
import TodaysPicksCarusel from "../components/caruselFeatures";
import MobileSectionBody from "../components/mobileSectionBody";

const Home = () => {
    return(

     <div className="h-full grid gap-6">
                <TodaysPicksCarusel></TodaysPicksCarusel>
                <MobileSectionBody title={"Popular"}></MobileSectionBody>
                <MobileSectionBody title={"New Releases"}></MobileSectionBody>
     </div>

    )
}

export default Home;