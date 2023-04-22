using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.SeaSolution.Service.Models;
using App.SeaSolution.Service.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyApiNetCore.Controllers
{
    [ApiController]
    public class CutomersController : Controller
    {
        private readonly ICustomersService _service;

        public CutomersController(ICustomersService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("InsertCustomer")]
        public async Task<ApiResponse<string>> InsertCustomers(CustomersModel body)
        {
            return await _service.InsertCustomers(body);
        }

        [HttpGet]
        [Route("Cutomers")]
        public async Task<ApiResponse<List<CustomersModel>>> GetCustomers()
        {
            return await _service.GetCustomers();
        }
    }
}
