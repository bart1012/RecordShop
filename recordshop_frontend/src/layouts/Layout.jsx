import React from 'react';
import { Outlet } from 'react-router';
import Header from '../components/Header';
import Footer from '../components/Footer';
import { ShoppingCartProvider } from '../context/ShoppingCartContext';

const Layout = () => {
    return (
            <div className="min-h-screen flex flex-col">
                <Header />
                <main className="flex-grow  p-6">
                    <Outlet /> 
                </main>
                <Footer />
            </div>
    );
}

export default Layout;
