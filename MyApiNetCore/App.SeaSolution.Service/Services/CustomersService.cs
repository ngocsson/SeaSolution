using App.SeaSolution.Data.Data;
using App.SeaSolution.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace App.SeaSolution.Service.Services
{
    public interface ICustomersService
    {
        Task<ApiResponse<List<CustomersModel>>> GetCustomers();
        Task<ApiResponse<string>> InsertCustomers(CustomersModel body);
    }
    public class CustomersService : ICustomersService
    {
        private readonly SeaSolutionContext _context;

        public CustomersService(SeaSolutionContext context)
        {
            _context = context;
        }
        public async Task<ApiResponse<List<CustomersModel>>> GetCustomers()
        {
            try
            {
                var listCustomer = await _context.Cutomers.ToListAsync();
                return new ApiResponse<List<CustomersModel>>()
                {
                    Code = Code.Success.ToString(),
                    Data = listCustomer.Select(c => new CustomersModel()
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Email = c.Email,
                        Phone = c.Phone
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<CustomersModel>>()
                {
                    Code = Code.Error.ToString(),
                    Message = ex.Message
                };
            }
        }

        public async Task<ApiResponse<string>> InsertCustomers(CustomersModel body)
        {
            try
            {
                var customers = new Customers()
                {
                    Name = body.Name,
                    Email = body.Email,
                    Phone = body.Phone
                };
                _context.Cutomers.Add(customers);
                await _context.SaveChangesAsync(true);
                return new ApiResponse<string>()
                {
                    Code = Code.Success.ToString(),
                    Data = "Thành Công"
                };
            }
            catch (Exception ex)
            {

                return new ApiResponse<string>()
                {
                    Code = Code.Error.ToString(),
                    Message = ex.Message
                }; ;
            }
            

        }
    }
}
