import React from "react";
import { UseShoppingCart } from "../context/ShoppingCartContext";
import { Link } from "react-router";


const Header = () => {

    const {CartItemQuantity} = UseShoppingCart();

    return (
        <>        
            <nav class="bg-white ">
                
                <div class="max-w-screen flex flex-wrap items-center justify-between mx-auto px-4 py-2 md:mx-20">              
            

                    <Link to="/" class="sm:order-1 flex items-center space-x-3 rtl:space-x-reverse" >
                        <img src="../public/Icons/logoBlack.webp" alt="BBRecords Logo" width={60}></img>
                    </Link>

                    <div className="sm:order-2 md:order-3 flex flex-row gap-4 items-center sm:float-right ml-auto lg:ml-0">

                        <div className="flex flex-row md:order-2 gap-4">
                            <svg xmlns="http://www.w3.org/2000/svg" x="0px" y="0px" width="25" height="25" viewBox="0 0 50 50">
                            <path fill="black" d="M 21 3 C 11.601563 3 4 10.601563 4 20 C 4 29.398438 11.601563 37 21 37 C 24.355469 37 27.460938 36.015625 30.09375 34.34375 L 42.375 46.625 L 46.625 42.375 L 34.5 30.28125 C 36.679688 27.421875 38 23.878906 38 20 C 38 10.601563 30.398438 3 21 3 Z M 21 7 C 28.199219 7 34 12.800781 34 20 C 34 27.199219 28.199219 33 21 33 C 13.800781 33 8 27.199219 8 20 C 8 12.800781 13.800781 7 21 7 Z"></path>
                            </svg>
                        
                            
                            <Link to="/cart" class="flex items-center space-x-3 rtl:space-x-reverse font-bold order-2">
                            <svg className="pr-1" xmlns="http://www.w3.org/2000/svg" 
                            width={25} shape-rendering="geometricPrecision" text-rendering="geometricPrecision" 
                            image-rendering="optimizeQuality" fill-rule="evenodd" clip-rule="evenodd" viewBox="0 0 512 448.47"><path fill="black" fill-rule="nonzero" d="M16.37 33.11C7.33 33.11 0 25.78 0 16.75 0 7.71 7.33.38 16.37.38c18.05 0 46.68-1.81 64.84 2.51 24.1 5.76 39.36 21.75 45.89 45.77 1.37 5.87 2.79 11.74 4.23 17.61h364.3c9.04 0 16.37 7.33 16.37 16.37 0 1.77-.28 3.47-.8 5.06l-42.35 171.36c-1.83 7.45-8.51 12.44-15.86 12.43l-266.92.04c6.02 21.72 11.52 33.49 19.58 38.91 4.96 3.33 11.92 5.05 21.44 5.85 17.38 1.47 42.66.42 60.74.42h160.62c9.04 0 16.37 7.33 16.37 16.37 0 9.04-7.33 16.37-16.37 16.37H289.54c-21.3 0-49.26 1.21-69.61-1.14-12.95-1.49-23.31-4.62-32.44-10.76-17.35-11.65-26.5-31.46-35.7-67.91L95.52 57.23c-3.27-12.03-9.31-19.34-21.34-22.45-14.34-3.69-43.81-1.67-57.81-1.67zm383.71 335.34c22.1 0 40.01 17.91 40.01 40.01 0 22.1-17.91 40.01-40.01 40.01-22.09 0-40.01-17.91-40.01-40.01 0-22.1 17.92-40.01 40.01-40.01zm-175.41 0c22.1 0 40.01 17.91 40.01 40.01 0 22.1-17.91 40.01-40.01 40.01-22.1 0-40.01-17.91-40.01-40.01 0-22.1 17.91-40.01 40.01-40.01zM324.85 99.01v59.49h135.21l14.71-59.49H324.85zm0 92.22v47.56h115.37l11.75-47.56H324.85zm-32.74 47.56v-47.56H165.12c4.36 15.86 8.63 31.71 12.68 47.56h114.31zm0-80.29V99.01H139.73c5.26 19.82 10.78 39.65 16.31 59.49h136.07z"/></svg>
                            {CartItemQuantity}
                            </Link>
                        </div>
                    </div>

                    <div className="sm:order-3 md:order-2 ml-4">
                    <button data-collapse-toggle="navbar-default" type="button" class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600" aria-controls="navbar-default" aria-expanded="false">
                            <span class="sr-only">Open main menu</span>
                            <svg class="w-5 h-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 17 14">
                                <path stroke="black" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M1 1h15M1 7h15M1 13h15"/>
                            </svg>
                        </button>

                            <div class="hidden w-full md:block md:w-auto md:order-1" id="navbar-default">
                            <ul class="font-medium flex flex-col p-4 md:p-0 mt-4 border border-gray-100 rounded-lg  md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0 md:bg-white">
                                <li>
                                <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent" aria-current="page">Best Sellers</a>
                                </li>
                                <li>
                                <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">New Releases</a>
                                </li>
                                <li>
                                <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Genres</a>
                                </li>
                                <li>
                                <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Artists</a>
                                </li>
                                <li>
                                <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Blog</a>
                                </li>
                            </ul>
                            </div>
                        </div>
                </div>
            </nav>
        </>
    )
}

export default Header;