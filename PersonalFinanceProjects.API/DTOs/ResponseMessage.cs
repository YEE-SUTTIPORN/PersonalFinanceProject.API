namespace PersonalFinanceProjects.API.DTOs
{
    public class ResponseMessage
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
    }

    public class ResponseMessage<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public T? Data { get; set; }
    }
}
