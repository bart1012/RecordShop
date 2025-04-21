import React from 'react';
import { Outlet } from 'react-router';
import Header from '../components/header';
import Footer from '../components/Footer';
import { ShoppingCartProvider } from '../context/ShoppingCartContext';

const Layout = () => {
    return (
            <div className="min-h-screen flex flex-col">
                <Header />
                <main className="flex-grow">
                    <Outlet /> 
                </main>
                <Footer />
            </div>
    );
}

export default Layout;
