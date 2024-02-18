namespace Common.BaseDTO
{
    public class ResultViewModel
    {
        public class ResultDataModel
        {
            public bool IsSuccess { get; set; }
            public List<string> Message { get; set; } =new List<string>();
        }

        public class ResultDataModel<T>
        {
            public bool IsSuccess { get; set; }
            public string Message { get; set; } = string.Empty;
            public required T Data { get; set; }
        }
    }
}
