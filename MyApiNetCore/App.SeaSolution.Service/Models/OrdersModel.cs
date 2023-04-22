namespace App.SeaSolution.Service.Models
{
    public class OrdersModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
    }

    public class OrderDetailModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public int Quantity { get; set; }
        public string CustomersName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }

}
