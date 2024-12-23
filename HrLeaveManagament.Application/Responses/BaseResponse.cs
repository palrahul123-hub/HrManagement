namespace HrLeaveManagament.Application.Responses
{
    public class BaseResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; }

        public BaseResponse()
        {
            Message = string.Empty;
            Errors = new List<string>();
            Success = false;
        }
    }
}
