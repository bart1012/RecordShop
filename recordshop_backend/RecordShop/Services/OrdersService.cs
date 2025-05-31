using Microsoft.AspNetCore.JsonPatch;
using RecordShop.Backend.DTOs;
using RecordShop.Backend.Repositories;
using RecordShop.Backend.Utils;


namespace RecordShop.Backend.Services
{
    public interface IOrdersService
    {
        Task<List<OrderDTO>?> RetrieveAllOrdersAsync();
        Task<OrderDTO> AddNewOrderAsync(OrderDTO order);
        Task<OperationStatus?> DeleteOrderByIDAsync(int id);
        Task<OrderDTO> UpdateOrderByIDAsync(int id, JsonPatchDocument jsonPatch);
        Task<OrderDTO?> RetrieveOrderByIDAsync(int id);
    }
    public class OrdersService(IOrdersRepository repository) : IOrdersService
    {
        private readonly IOrdersRepository _repository = repository;
        public async Task<OrderDTO> AddNewOrderAsync(OrderDTO order)
        {
            var orderEntity = await _repository.AddOrderAsync(order);
            return order;
        }

        public Task<OperationStatus> DeleteOrderByIDAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<OrderDTO>?> RetrieveAllOrdersAsync()
        {
            var orders = await _repository.RetrieveAllOrdersAsync();

            return orders is null ? null : orders.Select(o => new OrderDTO()
            {
                UserID = o.UserID,
                TotalPence = o.TotalPence,
                Status = OperationResult.Success,
                CustomerOrderInfo = new CustomerOrderInfoDTO()
                {
                    CustomerFirstName = o.OrderDetails.FirstName,
                    CustomerLastName = o.OrderDetails.LastName,
                    CustomerPhoneNumber = o.OrderDetails.PhoneNumber,
                    CustomerEmail = o.OrderDetails.Email,
                },
                DeliveryAddress = new DeliveryAddressDTO()
                {
                    AddressLine = o.OrderDetails.AddressLine,
                    Postcode = o.OrderDetails.Postcode,
                    Town = o.OrderDetails.Town,
                    Country = o.OrderDetails.Country
                },
                OrderItems = o.OrderItems.Select(item => new AlbumOrderDTO()
                {
                    AlbumID = item.AlbumID,
                    AlbumArtist = item.AlbumArtist,
                    AlbumName = item.AlbumTitle,
                    Quantity = item.Quantity,
                    TotalPriceInPence = item.PricePence
                }).ToList()

            }).ToList();
        }

        public async Task<OrderDTO?> RetrieveOrderByIDAsync(int id)
        {
            var targetOrder = await _repository.FindOrderByIDAsync(id);

            return targetOrder is null ? null : new OrderDTO()
            {
                UserID = targetOrder.UserID,
                TotalPence = targetOrder.TotalPence,
                Status = OperationResult.Success,
                CustomerOrderInfo = new CustomerOrderInfoDTO()
                {
                    CustomerFirstName = targetOrder.OrderDetails.FirstName,
                    CustomerLastName = targetOrder.OrderDetails.LastName,
                    CustomerPhoneNumber = targetOrder.OrderDetails.PhoneNumber,
                    CustomerEmail = targetOrder.OrderDetails.Email,
                },
                DeliveryAddress = new DeliveryAddressDTO()
                {
                    AddressLine = targetOrder.OrderDetails.AddressLine,
                    Postcode = targetOrder.OrderDetails.Postcode,
                    Town = targetOrder.OrderDetails.Town,
                    Country = targetOrder.OrderDetails.Country
                },
                OrderItems = targetOrder.OrderItems.Select(item => new AlbumOrderDTO()
                {
                    AlbumID = item.AlbumID,
                    AlbumArtist = item.AlbumArtist,
                    AlbumName = item.AlbumTitle,
                    Quantity = item.Quantity,
                    TotalPriceInPence = item.PricePence
                }).ToList()
            };
        }

        public Task<OrderDTO> UpdateOrderByIDAsync(int id, JsonPatchDocument jsonPatch)
        {
            throw new NotImplementedException();
        }
    }
}
