import React from "react";
import { UseShoppingCart } from "../context/ShoppingCartContext";
import { Link } from "react-router";


const Header = () => {

    const {CartItemQuantity} = UseShoppingCart();

    return (
        <>        
            <nav class="bg-white border-gray-200 dark:bg-gray-900">
            <div class="max-w-screen-xl flex flex-wrap items-center justify-between mx-auto p-4">              
          
                <Link to="/cart" class="flex items-center space-x-3 rtl:space-x-reverse text-white font-bold">
                <svg className="pr-1" xmlns="http://www.w3.org/2000/svg" width={25} shape-rendering="geometricPrecision" text-rendering="geometricPrecision" image-rendering="optimizeQuality" fill-rule="evenodd" clip-rule="evenodd" viewBox="0 0 512 448.47"><path fill="#fff" fill-rule="nonzero" d="M16.37 33.11C7.33 33.11 0 25.78 0 16.75 0 7.71 7.33.38 16.37.38c18.05 0 46.68-1.81 64.84 2.51 24.1 5.76 39.36 21.75 45.89 45.77 1.37 5.87 2.79 11.74 4.23 17.61h364.3c9.04 0 16.37 7.33 16.37 16.37 0 1.77-.28 3.47-.8 5.06l-42.35 171.36c-1.83 7.45-8.51 12.44-15.86 12.43l-266.92.04c6.02 21.72 11.52 33.49 19.58 38.91 4.96 3.33 11.92 5.05 21.44 5.85 17.38 1.47 42.66.42 60.74.42h160.62c9.04 0 16.37 7.33 16.37 16.37 0 9.04-7.33 16.37-16.37 16.37H289.54c-21.3 0-49.26 1.21-69.61-1.14-12.95-1.49-23.31-4.62-32.44-10.76-17.35-11.65-26.5-31.46-35.7-67.91L95.52 57.23c-3.27-12.03-9.31-19.34-21.34-22.45-14.34-3.69-43.81-1.67-57.81-1.67zm383.71 335.34c22.1 0 40.01 17.91 40.01 40.01 0 22.1-17.91 40.01-40.01 40.01-22.09 0-40.01-17.91-40.01-40.01 0-22.1 17.92-40.01 40.01-40.01zm-175.41 0c22.1 0 40.01 17.91 40.01 40.01 0 22.1-17.91 40.01-40.01 40.01-22.1 0-40.01-17.91-40.01-40.01 0-22.1 17.91-40.01 40.01-40.01zM324.85 99.01v59.49h135.21l14.71-59.49H324.85zm0 92.22v47.56h115.37l11.75-47.56H324.85zm-32.74 47.56v-47.56H165.12c4.36 15.86 8.63 31.71 12.68 47.56h114.31zm0-80.29V99.01H139.73c5.26 19.82 10.78 39.65 16.31 59.49h136.07z"/></svg>
                {CartItemQuantity}
                {/* <svg width="30" height="30" xmlns="http://www.w3.org/2000/svg">
                    <circle cx="15" cy="15" r="15" stroke="green" stroke-width="1" fill="yellow" />
                    <text x="37.5" y="30" font-size="5" text-anchor="middle" fill="black">{CartItemQuantity}</text>
                </svg>    */}
                </Link>

                <Link to="/" class="flex items-center space-x-3 rtl:space-x-reverse">
                    <span class="self-center text-2xl font-semibold whitespace-nowrap dark:text-white text-center w-full text-center">MusicApp</span>
                </Link>

                <button data-collapse-toggle="navbar-default" type="button" class="inline-flex items-center p-2 w-10 h-10 justify-center text-sm text-gray-500 rounded-lg md:hidden hover:bg-gray-100 focus:outline-none focus:ring-2 focus:ring-gray-200 dark:text-gray-400 dark:hover:bg-gray-700 dark:focus:ring-gray-600" aria-controls="navbar-default" aria-expanded="false">
                    <span class="sr-only">Open main menu</span>
                    <svg class="w-5 h-5" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 17 14">
                        <path stroke="currentColor" stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M1 1h15M1 7h15M1 13h15"/>
                    </svg>
                </button>
                <div class="hidden w-full md:block md:w-auto" id="navbar-default">
                <ul class="font-medium flex flex-col p-4 md:p-0 mt-4 border border-gray-100 rounded-lg bg-gray-50 md:flex-row md:space-x-8 rtl:space-x-reverse md:mt-0 md:border-0 md:bg-white dark:bg-gray-800 md:dark:bg-gray-900 dark:border-gray-700">
                    <li>
                    <a href="#" class="block py-2 px-3 text-white bg-blue-700 rounded-sm md:bg-transparent md:text-blue-700 md:p-0 dark:text-white md:dark:text-blue-500" aria-current="page">Home</a>
                    </li>
                    <li>
                    <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">About</a>
                    </li>
                    <li>
                    <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Services</a>
                    </li>
                    <li>
                    <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Pricing</a>
                    </li>
                    <li>
                    <a href="#" class="block py-2 px-3 text-gray-900 rounded-sm hover:bg-gray-100 md:hover:bg-transparent md:border-0 md:hover:text-blue-700 md:p-0 dark:text-white md:dark:hover:text-blue-500 dark:hover:bg-gray-700 dark:hover:text-white md:dark:hover:bg-transparent">Contact</a>
                    </li>
                </ul>
                </div>
            </div>
            </nav>
        </>
    )
}

export default Header;