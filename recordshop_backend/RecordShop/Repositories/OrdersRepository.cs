using Microsoft.EntityFrameworkCore;
using RecordShop.Backend.DbContexts;
using RecordShop.Backend.DTOs;
using RecordShop.Backend.Models;
using RecordShop.Backend.Utils;

namespace RecordShop.Backend.Repositories
{
    public interface IOrdersRepository
    {
        public Task<List<Order>> RetrieveAllOrdersAsync();
        public Task<Order?> FindOrderByIDAsync(int id);
        public Task<Order> UpdateOrderDetailsAsync(int id, CreateOrderDTO orderDTO);
        public Task<OperationStatus> IsOrderDeletedAsync(int id);
        public Task<Order> AddOrderAsync(CreateOrderDTO order);
    }
    public class OrdersRepository(OrdersDbContext db) : IOrdersRepository
    {

        private readonly OrdersDbContext _db = db;

        public async Task<Order> AddOrderAsync(CreateOrderDTO order)
        {
            await using var transaction = await _db.Database.BeginTransactionAsync();

            try
            {
                var orderRecord = new Order()
                {
                    UserID = order.UserID,
                    TotalPence = order.TotalPence,
                    Status = OrderStatus.Purchased,
                    CreatedAt = DateTime.Now,
                };
                await _db.Orders.AddAsync(orderRecord);
                await _db.SaveChangesAsync();


                await _db.OrderDetails.AddAsync(new OrderDetails()
                {
                    OrderID = orderRecord.ID,
                    FirstName = order.CustomerOrderInfo.CustomerFirstName,
                    LastName = order.CustomerOrderInfo.CustomerLastName,
                    PhoneNumber = order.CustomerOrderInfo.CustomerPhoneNumber,
                    Email = order.CustomerOrderInfo.CustomerEmail,
                    AddressLine = order.DeliveryAddress.AddressLine,
                    Postcode = order.DeliveryAddress.Postcode,
                    Town = order.DeliveryAddress.Town,
                    Country = order.DeliveryAddress.Country
                });


                foreach (var item in order.OrderItems)
                {
                    await _db.OrderItems.AddAsync(new OrderItem()
                    {
                        OrderID = orderRecord.ID,
                        AlbumID = item.AlbumID,
                        Quantity = item.Quantity,
                        PricePence = item.TotalPriceInPence,
                        AlbumArtist = item.AlbumArtist,
                        AlbumName = item.AlbumName
                    });
                }

                await _db.SaveChangesAsync();
                await transaction.CommitAsync();
                return orderRecord;
            }
            catch (Exception e)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<Order?> FindOrderByIDAsync(int id)
        {
            var targetOrder = await _db.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.OrderItems)
                .SingleOrDefaultAsync(o => o.ID == id);
            return targetOrder;
        }

        public async Task<OperationStatus> IsOrderDeletedAsync(int id)
        {

            var targetOrder = await _db.Orders.SingleOrDefaultAsync(a => a.ID == id);
            if (targetOrder is null)
            {
                return new OperationStatus() { Status = OperationResult.Failure };

            }
            else
            {
                _db.Orders.Remove(targetOrder);
                _db.OrderDetails.RemoveRange(_db.OrderDetails.Where(o => o.OrderID == targetOrder.ID));
                _db.OrderItems.RemoveRange(_db.OrderItems.Where(o => o.OrderID == targetOrder.ID));
                await _db.SaveChangesAsync();
                return new OperationStatus() { Status = OperationResult.Success };
            }

        }

        public async Task<List<Order>> RetrieveAllOrdersAsync()
        {
            var orders = await _db.Orders
                .Include(o => o.OrderDetails)
                .Include(o => o.OrderItems)
                .ToListAsync();
            return orders;
        }

        public Task<Order> UpdateOrderDetailsAsync(int id, CreateOrderDTO orderDTO)
        {
            // var targetOrder = await _db.Orders.SingleOrDefaultAsync(a => a.ID == id);
            //if (targetOrder is null)
            //{
            //    return new OperationStatus() { Status = OperationResult.Failure };

            //}
            //else
            //{
            //    _db.Orders.Remove(targetOrder);
            //    _db.OrderDetails.RemoveRange(_db.OrderDetails.Where(o => o.OrderID == targetOrder.ID));
            //    _db.OrderItems.RemoveRange(_db.OrderItems.Where(o => o.OrderID == targetOrder.ID));
            //    await _db.SaveChangesAsync();
            //    return new OperationStatus() { Status = OperationResult.Success };
            //}
            throw new NotImplementedException();
        }
    }
}
