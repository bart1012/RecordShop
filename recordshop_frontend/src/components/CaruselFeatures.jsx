import React from "react";
import Card from "./AlbumCard";
import { useEffect } from "react";
import { useLocation } from "react-router";
import Carousel from 'react-multi-carousel';
import 'react-multi-carousel/lib/styles.css';

const CaruselFeatures = () => {



      const featuredImgUrls = [
        "/images/featuredBannerImages/HomePageBanner11.webp",
        "/images/featuredBannerImages/HomePageBanner2.webp",
        "/images/featuredBannerImages/HomePageBanner3.webp"
    ];

    return (
        <>
         <section className="mt-10 rounded-xl flex flex-col font-semibold text-xl items-center md:h-[25rem] max-h-[35rem] bg-black mb-5 mx-20">
          
            <div id="default-carousel" class="relative w-full h-full" data-carousel="slide">
                <div class="relative h-full overflow-hidden">
                    <div class="hidden duration-700 rounded-xl ease-in-out" data-carousel-item>
                        <div class="flex flex-row rounded-xl absolute block w-full -translate-x-1/2 -translate-y-1/2 top-1/2 left-1/2 w-full h-full bg-[#ff4e4e]" >
                            <div className="w-1/2 flex py-[5rem] px-[7rem] flex flex-col">
                                <span className=" text-[5rem] text-white">Spring Sale</span>
                                <span className=" text-[1.5rem] text-white">Up to 50% of selected vinyls!</span>
                                <span className=" text-[1.5rem] text-[#ff4e4e] bg-white border rounded-full border-white p-1 w-fit px-3 mt-5">SHOP NOW</span>
                            </div>
                            <div className="w-1/2 flex py-[5rem]  flex flex-row ">
                                <img src="./images/featuredBannerImages/vinyl1.jpg"></img>
                                <img src="./images/featuredBannerImages/vinyl2.jpg"></img>             
                            </div>
                        </div>
                    </div>/
                    <div class="hidden duration-700 rounded-xl ease-in-out" data-carousel-item>/
                        <div class="flex flex-row rounded-xl absolute block w-full -translate-x-1/2 -translate-y-1/2 top-1/2 left-1/2 bg-[#d3d3d3] w-full h-full" >
                            <div className="w-2/3 flex py-[5rem] px-[7rem] flex flex-col">
                                <span className=" text-[5rem] ">Rushmere Out Now!</span>
                                <span className=" text-[1.5rem] ">Get the new album by the legendary band Mumford & Sons.</span>
                                <span className=" text-[1.5rem]  bg-white border rounded-full border-white p-1 w-fit px-3 mt-5">SHOP NOW</span>
                            </div>
                            <div className="w-1/3 flex py-[5rem]  flex flex-row ">
                                <img src="./images/featuredBannerImages/vinyl4.png"></img>
             
                            </div>
                        </div>                    
                        </div>
                    <div class="hidden duration-700 rounded-xl ease-in-out" data-carousel-item>/
                        <div class="flex flex-row rounded-xl absolute block w-full -translate-x-1/2 -translate-y-1/2 top-1/2 left-1/2 w-full h-full" >
                           <div className="w-[50%] flex py-[5rem] px-[7rem] flex flex-col">
                                <span className=" text-[2.5rem] text-white">All your favorite music in one place!</span>
                                <span className=" text-[1.5rem] text-white">Explore our range of new and vintage vinyls today!</span>
                                <span className=" text-[1.5rem] bg-white border rounded-full border-white p-1 w-fit px-3 mt-5">SHOP NOW</span>
                            </div>
                            <div className="w-[50%] flex mx-5 my-5 flex flex-row justify-center">
                                <img className="rounded-xl" width={550} src="./images/featuredBannerImages/vinylsbg.jpg"></img>
                            </div>
                        </div>                    
                        </div>
                </div>
                <div class="absolute z-30 flex -translate-x-1/2 bottom-5 left-1/2 space-x-3 rtl:space-x-reverse">
                    <button type="button" class="w-3 h-3 rounded-full" aria-current="true" aria-label="Slide 1" data-carousel-slide-to="0"></button>
                    <button type="button" class="w-3 h-3 rounded-full" aria-current="false" aria-label="Slide 2" data-carousel-slide-to="1"></button>
                    <button type="button" class="w-3 h-3 rounded-full" aria-current="false" aria-label="Slide 3" data-carousel-slide-to="2"></button>
                </div>
                <button type="button" class="absolute top-0 start-0 z-30 flex items-center justify-center h-full px-4 cursor-pointer group focus:outline-none" data-carousel-prev>
                    <span class="inline-flex items-center justify-center w-10 h-10 rounded-full bg-white/30 dark:bg-gray-800/30 group-hover:bg-white/50 dark:group-hover:bg-gray-800/60 group-focus:ring-4 group-focus:ring-white dark:group-focus:ring-gray-800/70 group-focus:outline-none">
                        <svg class="w-4 h-4 text-white dark:text-gray-800 rtl:rotate-180" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 6 10">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M5 1 1 5l4 4"/>
                        </svg>
                        <span class="sr-only">Previous</span>
                    </span>
                </button>
                <button type="button" class="absolute top-0 end-0 z-30 flex items-center justify-center h-full px-4 cursor-pointer group focus:outline-none" data-carousel-next>
                    <span class="inline-flex items-center justify-center w-10 h-10 rounded-full bg-white/30 dark:bg-gray-800/30 group-hover:bg-white/50 dark:group-hover:bg-gray-800/60 group-focus:ring-4 group-focus:ring-white dark:group-focus:ring-gray-800/70 group-focus:outline-none">
                        <svg class="w-4 h-4 text-white dark:text-gray-800 rtl:rotate-180" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 6 10">
                            <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="m1 9 4-4-4-4"/>
                        </svg>
                        <span class="sr-only">Next</span>
                    </span>
                </button>
            </div>
 
         </section>
        </>
    )
}

export default CaruselFeatures      