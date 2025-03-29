import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import { BrowserRouter, Route, Routes } from "react-router";
import Layout from './layouts/layout.jsx';
import Home from './pages/home.jsx';
import Browse from './pages/browse.jsx';
import Product from './pages/product.jsx';

createRoot(document.getElementById('root')).render(
  <BrowserRouter>
    <Routes>
      <Route path='/' element={<Layout></Layout>}>
        <Route index element={<Home></Home>}></Route> 
        <Route path="browse" element={<Browse></Browse>}></Route>
        <Route path="products" element={<Product></Product>}></Route>          
      </Route>
    </Routes>
  </BrowserRouter>
)
