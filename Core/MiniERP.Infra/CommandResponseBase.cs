using System.Net;

namespace MiniERP.Infra
{
    public struct CommandResponseBase<TResponse>
    {
        public bool Success { get; set; }
        public TResponse? Data { get; set; }
        public List<string>? Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        private CommandResponseBase(TResponse? data, bool success = true, List<string>? messages = default, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            Success = success;
            Messages = messages;
            Data = data;
            StatusCode = statusCode;
        }

        private CommandResponseBase(string erro, HttpStatusCode statusCode)
        {
            Messages = [erro];
            StatusCode = statusCode;
        }

        public static CommandResponseBase<T> Create<T>(T data, bool success, List<string> messages, HttpStatusCode statusCode) => new(data, success, messages, statusCode);
        public static CommandResponseBase<T> Create<T>(T data, bool success, HttpStatusCode statusCode) => new(data, success, statusCode: statusCode);
        public static CommandResponseBase<T> Create<T>(T data, HttpStatusCode statusCode) => new(data, statusCode: statusCode);
        public static CommandResponseBase<T> Create<T>(T data) => new(data);
        public static CommandResponseBase<T> Error<T>(string erro, HttpStatusCode statusCode) => new(erro, statusCode);
    }
}
