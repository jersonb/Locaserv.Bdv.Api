namespace Locaserv.Bdv.Api.ViewModels
{
    public class Response<TResult> where TResult : class
    {
        public int StatusCode { get; private init; }
        public bool IsSucess { get; private init; }
        public IEnumerable<string> Errors { get; private init; } = Enumerable.Empty<string>();
        public TResult? Result { get; private init; } = null;

        public static Response<TResult> Sucess(int statusCode, TResult result)
        {
            return new()
            {
                StatusCode = statusCode,
                IsSucess = true,
                Result = result
            };
        }

        public static Response<TResult> Error(int statusCode, params string[] erros)
        {
            return new()
            {
                StatusCode = statusCode,
                IsSucess = false,
                Errors = erros
            };
        }
    }
}