namespace Notifications.MediatR.Models
{
    public class Result
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="succeeded"></param>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        public Result(bool succeeded, object? data, IEnumerable<string>? errors = null)
        {
            Succeeded = succeeded;
            Data = data;
            Errors = errors;
        }

        public bool Succeeded { get; }
        public object? Data { get; }
        public IEnumerable<string>? Errors { get; }

        public static Result Success()
        {
            return new Result(true, default, Array.Empty<string>());
        }

        public static Result Success(object data)
        {
            return new Result(true, data, Array.Empty<string>());
        }

        public static Result Failure(IEnumerable<string> errors)
        {
            return new Result(false, default, errors);
        }
    }

    public class Result<T>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="succeeded"></param>
        /// <param name="data"></param>
        /// <param name="errors"></param>
        public Result(bool succeeded, T? data, IEnumerable<string>? errors = null)
        {
            Succeeded = succeeded;
            Data = data;
            Errors = errors;
        }

        public bool Succeeded { get; }
        public T? Data { get; }
        public IEnumerable<string>? Errors { get; }

        public static Result<T> Success()
        {
            return new Result<T>(true, default, Array.Empty<string>());
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, Array.Empty<string>());
        }

        public static Result<T> Failure(IEnumerable<string> errors)
        {
            return new Result<T>(false, default, errors);
        }

        public static Result<T> Failure(IReadOnlyCollection<Notification> notifications)
        {
            return new Result<T>(false, default, notifications.Select(x => x.Message));
        }
    }
}