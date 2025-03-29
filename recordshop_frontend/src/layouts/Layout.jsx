import React from 'react';
import { Outlet } from 'react-router';
import Header from '../components/header';
import Footer from '../components/footer';

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
