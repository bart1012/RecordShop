import { useContext, createContext, useState, useEffect } from "react";


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

    const CartItemQuantity = () => {
        if(cart == null || cart.Lengh === 0){
            return 0;
        }else{
            return cart.reduce((accumulator, album) => {
                return accumulator + album.quantity;
            }, 0);
        }
    }

    function IncreaseCartQuantity(album) {
       
        setCart((prevCart ) => {

            if(prevCart.find(item => item.id === album.id) == null){
                return   [...prevCart , {...album, quantity: 1}];
            }else{
                return prevCart.map(item =>
                    item.id === album.id
                      ? { ...item, quantity: item.quantity + 1 }
                      : item
                  );
            }

        } );   
    }

    function DecreaseCartQuantity(album) {

        setCart((prevCart ) => {
            if(prevCart.find(item => item.id === album.id).quantity === 1){
                return   prevCart.filter(element => element.id !== album.id);
            }else{
                return prevCart.map(element => {
                    if(element.id === album.id){
                        return {...element, quantity: element.quantity - 1}
                    }else{
                        return element;
                    }
                })
           
            }

        } );  
    }

 
    return (
        <ShoppingCartContext.Provider 
        value={{ cart, CartItemQuantity, IncreaseCartQuantity, DecreaseCartQuantity }}
        >
            {children}
        </ShoppingCartContext.Provider>
    );
}



