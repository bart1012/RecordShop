import { UseShoppingCart } from "../context/ShoppingCartContext";
import { createOrder } from "../scripts/orderService";

const CheckoutForm = () => {

    const {cart, CalculateTotalPrice} = UseShoppingCart();

     const extractFormData = (e) => {
        e.preventDefault();
        const formData = new FormData(e.target);
        const orderDetails = Object.fromEntries(formData.entries());
        return orderDetails;
    }

    const convertToOrderDTO = (formData) => {
        return {
            "totalPence": CalculateTotalPrice(),
            "deliveryAddress": {
                "addressLine": formData.addressLine,
                "postcode": formData.postcode,
                "town": formData.town,
                "country": formData.country
            },
            "customerOrderInfo": {
                "customerFirstName": formData.customerFirstName,
                "customerLastName": formData.customerLastName,
                "customerPhoneNumber": formData.customerPhoneNumber,
                "customerEmail": formData.customerEmail
            },
            "orderItems": cart.map((item) => ({
                "albumID": item.id,
                "albumName": item.name,
                "albumArtist": item.artists[0],
                "quantity": item.quantity,
                "totalPriceInPence": item.pricePence * item.quantity
            }))
        };
    }

    const handleFormSubmission = async (e) => {
        const formData = extractFormData(e);
        const orderDTO = convertToOrderDTO(formData);
        const apiResponse = await createOrder(orderDTO);
        if(apiResponse.success){
            alert("success");
        }else{
            alert("failure");
        }
    }

     return (<div class="mt-6 sm:mt-8 lg:flex lg:items-start lg:gap-12">
                    <form onSubmit={handleFormSubmission} class="w-full rounded-lg border border-gray-200 bg-white p-4 shadow-sm  sm:p-6 lg:max-w-xl lg:p-8">
                    <div class="mb-6 grid grid-cols-12 gap-4">
                        
                        {/* Customer details */}
                        <div className="col-span-12 ">
                        <input name="customerEmail" type="text" id="full_name" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="Email*" required />
                        </div>

                        <div class="col-span-6">
                        <input name="customerFirstName" type="text" id="first_name" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="First Name*" required />
                        </div>

                         <div class="col-span-6">
                        <input name="customerLastName" type="text" id="last_name" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="Last Name*" required />
                        </div>

                        <div className="col-span-12 ">
                        <input name="customerPhoneNumber" type="tel" id="mobile_num" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="Phone Number
                        *" required />
                        </div>
                        {/* Shipping details */}
                        <div className="col-span-12 ">
                        <input name="addressLine" type="text" id="address" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="Address Line 1*" required />
                        </div>

                        <div className="col-span-4 ">
                        <input name="town" type="text" id="town" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="Town*" required />
                        </div>

                        <div className="col-span-4 ">
                        <input name="postcode" type="text" id="postcode" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="Postcode*" required />
                        </div>

                          <div className="col-span-4 ">
                        <input name="country" type="text" id="country" class="block w-full rounded-lg border border-gray-300 p-2.5 text-sm text-gray-900 focus:border-primary-500 focus:ring-primary-500 " placeholder="Country*" required />
                        </div>
                     
                    </div>
                    <button className="btn" type="submit">Place Order</button>
                    </form>

                    <div class="mt-6 grow sm:mt-8 lg:mt-0">
                    <div class="space-y-4 rounded-lg border border-gray-100 p-6 ">
                        <div class="space-y-2">
                        <dl class="flex items-center justify-between gap-4">
                            <dt class="text-base font-normal ">Price</dt>
                            <dd class="text-base font-medium ">$6,592.00</dd>
                        </dl>

                  

                        <dl class="flex items-center justify-between gap-4">
                            <dt class="text-base font-normal ">Delivery</dt>
                            <dd class="text-base font-medium ">$799</dd>
                        </dl>
                        </div>

                        <dl class="flex items-center justify-between gap-4 border-t border-gray-200 pt-2 ">
                        <dt class="text-base font-bold ">Total</dt>
                        <dd class="text-base font-bold ">$7,191.00</dd>
                        </dl>
                    </div>

                    <div class="mt-6 flex items-center justify-center gap-8">
                        <img class="h-8 w-auto dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/paypal.svg" alt="" />
                        <img class="hidden h-8 w-auto dark:flex" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/paypal-dark.svg" alt="" />
                        <img class="h-8 w-auto dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/visa.svg" alt="" />
                        <img class="hidden h-8 w-auto dark:flex" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/visa-dark.svg" alt="" />
                        <img class="h-8 w-auto dark:hidden" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/mastercard.svg" alt="" />
                        <img class="hidden h-8 w-auto dark:flex" src="https://flowbite.s3.amazonaws.com/blocks/e-commerce/brand-logos/mastercard-dark.svg" alt="" />
                    </div>
                    </div>
                </div>)
}

export default CheckoutForm;