using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.SeaSolution.Service.Models;
using App.SeaSolution.Service.Services;

namespace MyApiNetCore.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrdersController : Controller
    {
        private readonly IOrdersService _service;

        public OrdersController(IOrdersService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("Id/{id}")]
        public async Task<ApiResponse<OrderDetailModel>> OrdersDetail([FromRoute]int id)
        {
            return await _service.OrdersDetail(id);
        }
        
        [HttpGet]
        [Route("IdCustomer/{id}")]
        public async Task<ApiResponse<List<OrdersModel>>> OrdersByCustomer([FromRoute]int id)
        {
            return await _service.OrdersByCustomer(id);
        }
    }
}
