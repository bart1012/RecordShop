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
import Checkout from './pages/checkout.jsx';
import { AuthProvider } from './context/AuthContext.jsx';
import Login from './pages/login.jsx';
import Lookup from './pages/lookup.jsx';
import "./css/customStyles.css";
import OrderConfirmation from './pages/orderConfirmation.jsx';

createRoot(document.getElementById('root')).render(
  <AuthProvider>
    <ShoppingCartProvider>
      <BrowserRouter>
        <Routes>

          <Route path="/signup" element={<Registration></Registration>}></Route>
          <Route path="/login" element={<Login></Login>}></Route> 
          <Route path="/lookup" element={<Lookup></Lookup>}></Route> 

          <Route path='/' element={<Layout></Layout>}>
            <Route index element={<Home></Home>}></Route> 
            <Route path="albums/:id" element={<Product></Product>}></Route>
            <Route path="account" element={<Account></Account>}></Route>        
            <Route path="cart" element={<ShoppingCart></ShoppingCart>}></Route>
            <Route path="search" element={<SearchResults></SearchResults>}></Route> 
            <Route path="new" element={<NewReleases></NewReleases>}></Route> 
            <Route path="checkout" element={<Checkout></Checkout>}></Route> 
            <Route path="order-confirmation" element={<OrderConfirmation></OrderConfirmation>}></Route> 
          </Route>

        </Routes>
      </BrowserRouter>
    </ShoppingCartProvider>
  </AuthProvider>
)
