using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vilas.Utils.Text
{
    public class Result<T> where T : class
    {
        public Result() { }

        public int StatusCode { get; set; } = 200;
        public bool IsSuccess { get; set; }
        public T Data { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public string ErrorMessageString
        {
            get
            {
                if (Errors == null || !Errors.Any())
                    return string.Empty;

                return string.Join(";", Errors);
            }
        }

        public void AddError(string error) =>
            Errors.Add(error);

        public Result<T> Ok(T data)
        {
            Data = data;
            StatusCode = 200;

            return this;
        }

        public Result<T> Created(T data)
        {
            Data = data;
            StatusCode = 201;

            return this;
        }

        public Result<T> Conflict(string error)
        {
            Errors.Add(error);
            StatusCode = 409;

            return this;
        }

        public Result<T> NotFound(string error)
        {
            Errors.Add(error);
            StatusCode = 404;
            return this;
        }

        public Result<T> BadRequest(string error)
        {
            Errors.Add(error);
            StatusCode = 400;
            return this;
        }

        public Result<T> InternalServerError(string error)
        {
            Errors.Add(error);
            StatusCode = 500;
            return this;
        }

        public Result<T> FromStatusCode(int statusCode, List<string> error)
        {
            StatusCode = statusCode;
            Errors.AddRange(error);
            return this;
        }
    }
}
