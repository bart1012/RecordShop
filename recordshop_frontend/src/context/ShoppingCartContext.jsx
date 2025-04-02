import { useContext, createContext, useState, memo, useMemo, useEffect } from "react";


const ShoppingCartContext = createContext();

export function UseShoppingCart() {
    return useContext(ShoppingCartContext);
}

export function ShoppingCartProvider({ children }) {

    const [cart, setCart] = useState(() => {
        const savedCart = sessionStorage.getItem("cart");
        return savedCart ? JSON.parse(savedCart) : [];
    });

    useEffect(() => {
        sessionStorage.setItem("cart", JSON.stringify(cart));
    }, [cart]);

    const CartItemQuantity = cart.length;

    function IncreaseCartQuantity(album) {
        
        setCart((prevCart ) => [...prevCart , album] );   
    }

    function DecreaseCartQuantity() {
        setCart(prevCart  => (prevCart  > 0 ? prevCart  - 1 : 0)); 
    }

 
    return (
        <ShoppingCartContext.Provider 
        value={{ cart, CartItemQuantity, IncreaseCartQuantity, DecreaseCartQuantity }}
        >
            {children}
        </ShoppingCartContext.Provider>
    );
}

// export const ShoppingCartProvider = memo(({ children }) => {
//     const [cart, setCart] = useState([]);

//     // Memoize the context value
//     const contextValue = useMemo(() => ({
//         cart,
//         CartItemQuantity: cart.length,
//         IncreaseCartQuantity: (album) => setCart((prev) => [...prev, album]),
//         DecreaseCartQuantity: () => setCart((prev) => prev.slice(0, -1)),
//     }), [cart]);

//     return (
//         <ShoppingCartContext.Provider value={contextValue}>
//             {children}
//         </ShoppingCartContext.Provider>
//     );
// });



