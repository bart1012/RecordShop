import { useEffect, useState } from "react";
import { useParams, useSearchParams } from "react-router";
import { fetchOrderById } from "../scripts/orderService";

const OrderConfirmation = () => {

    const [orderInfo, setOrderInfo] = useState(null);
    const [params, setParams] = useSearchParams();

    const getOrderSummary = async (orderID) => {
        const apiResponse = await fetchOrderById(orderID);
        setOrderInfo(apiResponse.data);
    }

    useEffect(()=>{
        const handleApiCall = async () => {
            const orderID = params.get('orderID');
            await getOrderSummary(orderID);
        }

        handleApiCall();
    }, []);

    return (
        <section className="w-1/4 flex-grow flex flex-col m-auto">
            <div className="w-full align-center relative top-[5rem]"> 
                <h2 className="font-semibold text-xl">Order Confirmation: </h2>
                {orderInfo && <>
                    <p>{orderInfo.userID}</p>
                </>}
            </div>
        </section>
    )
}

export default OrderConfirmation;