using App.SeaSolution.Data.Data;
using App.SeaSolution.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace App.SeaSolution.Service.Services
{
    public interface IOrdersService
    {
        Task<ApiResponse<OrderDetailModel>> OrdersDetail(int id);
        Task<ApiResponse<List<OrdersModel>>> OrdersByCustomer(int customerId);
    }
    public class OrdersService : IOrdersService
    {
        private readonly SeaSolutionContext _context;

        public OrdersService(SeaSolutionContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<OrderDetailModel>> OrdersDetail(int id)
        {
            try
            {
                var order = _context.Orders.FirstOrDefault(c => c.Id == id);
                if (order == null)
                {
                    return new ApiResponse<OrderDetailModel>()
                    {
                        Code = Code.NotFound.ToString(),
                        Message = "Đơn hàng không tồn tại!"
                    };
                }
                order.Products = _context.Products.FirstOrDefault(c => c.Id == order.ProductId);
                order.Customers = _context.Cutomers.FirstOrDefault(c => c.Id == order.CustomerId);
                return new ApiResponse<OrderDetailModel>()
                {
                    Code = Code.Success.ToString(),
                    Data = new OrderDetailModel()
                    {
                        Id = order.Id,
                        Address = order.Address,
                        CustomersName = order.Customers.Name,
                        Description = order.Products.Description,
                        Email = order.Customers.Email,
                        Phone = order.Customers.Phone,
                        Price = order.Products.Price,
                        ProductName = order.Products.Name,
                        Quantity = order.Quantity
                    }
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<OrderDetailModel>()
                {
                    Code = Code.Error.ToString(),
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<List<OrdersModel>>> OrdersByCustomer(int customerId)
        {
            try
            {
                var order = _context.Orders.Where(c => c.CustomerId == customerId).Select(c => new OrdersModel()
                {
                    CustomerId = c.CustomerId,
                    Address = c.Address,
                    ProductId = c.ProductId,
                    Id = c.Id
                }).ToList();
                if (order.Count == 0)
                {
                    return new ApiResponse<List<OrdersModel>>()
                    {
                        Code = Code.NotFound.ToString(),
                        Message = "Không có thông đơn hàng nào!"
                    };
                }
                return new ApiResponse<List<OrdersModel>>()
                {
                    Code = Code.Success.ToString(),
                    Data = order
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<OrdersModel>>()
                {
                    Code = Code.Error.ToString(),
                    Message = ex.Message
                };
            }
        }
    }
}
