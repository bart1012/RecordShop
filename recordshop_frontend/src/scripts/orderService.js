import axios from "axios";

const BASE_URL = 'https://localhost:7195/Orders';

const createOrder = async (orderDTO) => {
    try{
        const response = await axios.post(BASE_URL, orderDTO, { withCredentials: true });
        if (response.status === 200 || response.status === 201) {
            console.log(response);
            return {
                success: true,
                statusCode: response.status,
                message: "Order created successfully",
                data: response.data
            };
        } else {
            return {
                success: false,
                statusCode: response.status,
                message: "Unexpected response from server",
                data: response.data
            };
        }

    }catch (error) {

        const status = error.response?.status || 500;
        const errorData = error.response?.data || {};

        return {
            success: false,
            statusCode: status,
            message: status >= 400 && status < 500
                ? "Bad request"
                : "Server error",
            error: error.message,
            data: errorData
        };
    }
}

const fetchOrderById = async (orderID) => {

    try{
        const response = await axios.get(BASE_URL + `/${orderID}`);
        if (response.status === 200 || response.status === 201) {
            console.log(response);
            return {
                success: true,
                statusCode: response.status,
                message: "Order retrieved successfully",
                data: response.data
            };
        } else {
            return {
                success: false,
                statusCode: response.status,
                message: "Unexpected response from server",
                data: response.data
            };
        }

    }catch (error) {

        const status = error.response?.status || 500;
        const errorData = error.response?.data || {};

        return {
            success: false,
            statusCode: status,
            message: status >= 400 && status < 500
                ? "Bad request"
                : "Server error",
            error: error.message,
            data: errorData
        };
    }
}

export {createOrder, fetchOrderById};