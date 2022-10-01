namespace Notifications.MediatR.Models
{
    public class Result
    {
        private Result(bool succeeded, object? data, IEnumerable<string>? errors = null)
        {
            Succeeded = succeeded;
            Data = data;
            Errors = errors;
        }

        public bool Succeeded { get; }
        public object? Data { get; }
        public IEnumerable<string>? Errors { get; }

        public static Result Success()
            => new(true, default);

        public static Result Success(object data)
            => new(true, data);

        public static Result Failure(IEnumerable<string> errors)
            => new(false, default, errors);

        public static Result Failure(string error)
            => new(false, default, new string[] { error });

        public static Result Failure(IReadOnlyCollection<Notification> notifications)
            => new(false, default, notifications.Select(x => x.Message));
    }

    public class Result<T>
    {
        private Result(bool succeeded, T? data, IEnumerable<string>? errors = null)
        {
            Succeeded = succeeded;
            Data = data;
            Errors = errors;
        }

        public bool Succeeded { get; }
        public T? Data { get; }
        public IEnumerable<string>? Errors { get; }

        public static Result<T> Success()
            => new(true, default);

        public static Result<T> Success(T data)
            => new(true, data);

        public static Result<T> Failure(string error)
            => new(false, default, new string[] { error });

        public static Result<T> Failure(IEnumerable<string> errors)
            => new(false, default, errors);

        public static Result<T> Failure(IReadOnlyCollection<Notification> notifications)
            => new(false, default, notifications.Select(x => x.Message));
    }
}