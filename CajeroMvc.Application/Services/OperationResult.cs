namespace CajeroMvc.Application.Services
{
    public class OperationResult
    {
        public OperationResult()
        {
            Sucess = true;
        }
        public bool Sucess { get; set; }
        public string? Message { get; set; }
        public dynamic? Data { get; set; }
    }
}
