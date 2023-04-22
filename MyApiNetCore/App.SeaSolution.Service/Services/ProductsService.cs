
using App.SeaSolution.Data.Data;

namespace App.SeaSolution.Service.Services
{
    public interface IProductsService
    {

    }
    public class ProductsService : IProductsService
    {
        private readonly SeaSolutionContext _context;

        public ProductsService(SeaSolutionContext context)
        {
            _context = context;
        }
    }
}
