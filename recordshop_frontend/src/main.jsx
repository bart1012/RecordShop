import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { BrowserRouter, Route, Routes } from "react-router";
import Layout from './layouts/layout.jsx';
import Home from './pages/home.jsx';
import Product from './pages/product.jsx';
import Account from './pages/account.jsx';
import ShoppingCart from './pages/shoppingCart.jsx';
import { ShoppingCartProvider } from './context/ShoppingCartContext.jsx';
import SearchResults from './pages/searchResult.jsx';
import NewReleases from './pages/newReleases.jsx';
import Registration from './pages/registration.jsx';

createRoot(document.getElementById('root')).render(
  <ShoppingCartProvider>
    <BrowserRouter>
      <Routes>
        <Route path="/signup" element={<Registration></Registration>}></Route> 
        <Route path='/' element={<Layout></Layout>}>
          <Route index element={<Home></Home>}></Route> 
          <Route path="albums/:id" element={<Product></Product>}></Route>
          <Route path="your-account" element={<Account></Account>}></Route>        
          <Route path="cart" element={<ShoppingCart></ShoppingCart>}></Route>
          <Route path="search" element={<SearchResults></SearchResults>}></Route> 
          <Route path="new" element={<NewReleases></NewReleases>}></Route> 
        </Route>

      </Routes>
    </BrowserRouter>
  </ShoppingCartProvider>
)
