namespace App.SeaSolution.Service.Models
{
    public class ApiResponse<TData>
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public TData Data { get; set; }
    }

    public enum Code
    {
        Success, Error, NotFound
    }

}
