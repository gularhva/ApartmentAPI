namespace Lesson27Task
{
    public class ResponseModel<T>
    {
        public bool Success { get; set; }
        public T Data { get; set; }
        public string ErrorMessage { get; set; }
        public ResponseModel()
        {
            Success = true;
        }
    }
}
