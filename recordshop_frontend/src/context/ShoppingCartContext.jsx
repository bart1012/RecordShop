import { useContext, createContext, useState, useMemo } from "react";

const ShoppingCartContext = createContext();

export function UseShoppingCart() {
    return useContext(ShoppingCartContext);
}

export function ShoppingCartProvider({ children }) {
    const [value, setValue] = useState([]);

    const CartItemQuantity = value.length;

    function IncreaseCartQuantity(album) {
        
        setValue((cartData) => [...cartData, album]); 
    }

    function DecreaseCartQuantity() {
        setValue(prev => (prev > 0 ? prev - 1 : 0)); 
    }

 
    return (
        <ShoppingCartContext.Provider 
        value={{ value, CartItemQuantity, IncreaseCartQuantity, DecreaseCartQuantity }}
        >
            {children}
        </ShoppingCartContext.Provider>
    );
}


