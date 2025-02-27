using System.Net;

namespace MiniERP.Infra
{
    public struct CommandResponseBase<TResponse>
    {
        public bool Success { get; set; }
        public TResponse? Data { get; set; }
        public List<string> Messages { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        private CommandResponseBase(bool success, List<string> messages, TResponse? data, HttpStatusCode statusCode)
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

        public static CommandResponseBase<T> Create<T>(T data, bool success, List<string> messages, HttpStatusCode statusCode) => new(success, messages, data, statusCode);
        public static CommandResponseBase<T> Error<T>(string erro, HttpStatusCode statusCode) => new(erro, statusCode);
    }
}
