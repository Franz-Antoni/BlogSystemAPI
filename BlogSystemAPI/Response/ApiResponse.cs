namespace BlogSystem.Api.Response
{
    public class ApiResponse<T>
    {
        public ApiResponse(T data) 
        {
            Data = data;
        }

        public T Data { get; set; }
    }
}
