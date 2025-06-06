using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RecordShop.Backend.DTOs;
using RecordShop.Backend.Services;
using RecordShop.Backend.Utils;
using System.Security.Claims;

namespace RecordShop.Backend.Controllers
{
    [ApiController]
    //[Authorize(Roles = "Admin")]
    [Route("/[controller]")]
    public class OrdersController(IOrdersService service) : ControllerBase
    {

        private readonly IOrdersService _service = service;

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {

            var orders = await _service.RetrieveAllOrdersAsync();
            return orders.IsNullOrEmpty() ? NoContent() : Ok(orders);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByID(int id)
        {
            var order = await _service.RetrieveOrderByIDAsync(id);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderByID(int id)
        {
            OperationStatus deleteResult = await _service.DeleteOrderByIDAsync(id);
            return deleteResult.Status == OperationResult.Success ? NoContent() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderById(int id, CreateOrderDTO orderReplacement)
        {
            OrderSummaryDTO patchResult = await _service.UpdateOrderByIDAsync(id, orderReplacement);
            return patchResult is null ? NotFound() : Ok(patchResult);
        }

        //[AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> PostOrder(CreateOrderDTO order)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            order.UserID = userId;

            try
            {
                var orderData = await _service.AddNewOrderAsync(order);
                string uri = $"https://localhost:7195/Orders/{orderData.ID}";
                return Created(uri, order);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
