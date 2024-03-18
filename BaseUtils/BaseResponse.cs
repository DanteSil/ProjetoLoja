namespace ProjetoLoja.BaseUtils
{
    public class BaseResponse
    {
        public BaseResponse(bool success, object data)
        {
            IsSuccess = success;
            Data = data;
            Errors = new List<string>();

            if (!success && data is Exception exception)
                Data = BaseRersponseException(exception);
        }

        private object BaseRersponseException(Exception e)
        {
            return new { e.Message };
        }

        public bool IsSuccess { get; set; } 
        public object Data { get; set; }
        public List<string> Errors { get; set; }
    }
}
