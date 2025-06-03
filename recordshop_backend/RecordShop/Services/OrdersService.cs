using RecordShop.Backend.DTOs;
using RecordShop.Backend.Repositories;
using RecordShop.Backend.Utils;


namespace RecordShop.Backend.Services
{
    public interface IOrdersService
    {
        Task<List<OrderSummaryDTO>?> RetrieveAllOrdersAsync();
        Task<OrderSummaryDTO?> AddNewOrderAsync(CreateOrderDTO order);
        Task<OperationStatus?> DeleteOrderByIDAsync(int id);
        Task<OrderSummaryDTO?> UpdateOrderByIDAsync(int id, CreateOrderDTO orderDTO);
        Task<OrderSummaryDTO?> RetrieveOrderByIDAsync(int id);
    }
    public class OrdersService(IOrdersRepository repository) : IOrdersService
    {
        private readonly IOrdersRepository _repository = repository;
        public async Task<OrderSummaryDTO?> AddNewOrderAsync(CreateOrderDTO order)
        {
            var targetOrder = await _repository.AddOrderAsync(order);
            return targetOrder is null ? null : new OrderSummaryDTO()
            {
                ID = targetOrder.ID,
                UserID = targetOrder.UserID,
                TotalPence = targetOrder.TotalPence,
                Status = targetOrder.Status,
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
                    AlbumName = item.AlbumName,
                    Quantity = item.Quantity,
                    TotalPriceInPence = item.PricePence
                }).ToList()
            };
        }

        public Task<OperationStatus> DeleteOrderByIDAsync(int id)
        {
            return _repository.IsOrderDeletedAsync(id);
        }

        public async Task<List<OrderSummaryDTO>?> RetrieveAllOrdersAsync()
        {
            var orders = await _repository.RetrieveAllOrdersAsync();

            return orders is null ? null : orders.Select(o => new OrderSummaryDTO()
            {
                ID = o.ID,
                UserID = o.UserID,
                TotalPence = o.TotalPence,
                Status = o.Status,
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
                    AlbumName = item.AlbumName,
                    Quantity = item.Quantity,
                    TotalPriceInPence = item.PricePence
                }).ToList()

            }).ToList();
        }

        public async Task<OrderSummaryDTO?> RetrieveOrderByIDAsync(int id)
        {
            var targetOrder = await _repository.FindOrderByIDAsync(id);

            return targetOrder is null ? null : new OrderSummaryDTO()
            {
                ID = targetOrder.ID,
                UserID = targetOrder.UserID,
                TotalPence = targetOrder.TotalPence,
                Status = targetOrder.Status,
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
                    AlbumName = item.AlbumName,
                    Quantity = item.Quantity,
                    TotalPriceInPence = item.PricePence
                }).ToList()
            };
        }

        public async Task<OrderSummaryDTO?> UpdateOrderByIDAsync(int id, CreateOrderDTO orderDTO)
        {
            var targetOrder = await _repository.UpdateOrderDetailsAsync(id, orderDTO);
            return targetOrder is null ? null : new OrderSummaryDTO()
            {
                ID = targetOrder.ID,
                UserID = targetOrder.UserID,
                TotalPence = targetOrder.TotalPence,
                Status = targetOrder.Status,
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
                    AlbumName = item.AlbumName,
                    Quantity = item.Quantity,
                    TotalPriceInPence = item.PricePence
                }).ToList()
            };
        }
    }
}
