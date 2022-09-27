using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Common.Wrapper
{
    public class Result : IResult
    {
        public Result()
        {
        }

        public List<string> Messages { get; set; } = new List<string>();

        public bool Succeeded { get; set; }

        public object SucceededInfo { get; set; }

        public string StringMessages { get => string.Join(": ", Messages); }

        public static IResult Fail()
        {
            return new Result { Succeeded = false };
        }

        public static IResult Fail(string message)
        {
            return new Result { Succeeded = false, Messages = new List<string> { message } };
        }

        public static IResult Fail(List<string> messages)
        {
            return new Result { Succeeded = false, Messages = messages };
        }

        public static Task<IResult> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public static Task<IResult> FailAsync(string message)
        {
            return Task.FromResult(Fail(message));
        }

        public static Task<IResult> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        public static IResult Success()
        {
            return new Result { Succeeded = true };
        }

        public static IResult Success(string message)
        {
            return new Result { Succeeded = true, Messages = new List<string> { message } };
        }

        public static Task<IResult> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public static Task<IResult> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static async Task<IResult> ExecuteAsync(Func<Task<IResult>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                // TODO: логирование
                return Result.Fail(e.Message);
            }
        }

        public static async Task<IResult> ExecuteAsync(Func<Task> func)
        {
            try
            {
                await func();
                return Result.Success();
            }
            catch (Exception e)
            {
                // TODO: логирование
                return Result.Fail(e.Message);
            }
        }

        public static async Task<IResult> ExecuteAsync(Func<Task> func, Action<string> logFunc)
        {
            try
            {
                await func();
                return Result.Success();
            }
            catch (Exception e)
            {
                if (logFunc != null)
                    logFunc.Invoke($"{e}");
                return Result.Fail(e.Message);
            }
        }

        public static async Task<IResult> ExecuteAsync(Func<Task<IResult>> func, Action<string> logFunc)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                if (logFunc != null)
                    logFunc.Invoke($"{e}");
                return Result.Fail(e.Message);
            }
        }

        public void ThrowIfFail()
        {
            if (!Succeeded)
                throw new Exception(String.Join("\n", Messages));
        }
    }

    public class Result<T> : Result, IResult<T>
    {
        public Result()
        {
        }

        public T Data { get; set; }

        public new static Result<T> Fail()
        {
            return new Result<T> { Succeeded = false };
        }

        public new static Result<T> Fail(string message, object info = null)
        {
            return new Result<T> { Succeeded = false, Messages = new List<string> { message }, SucceededInfo = info };
        }

        public new static Result<T> Fail(List<string> messages)
        {
            return new Result<T> { Succeeded = false, Messages = messages };
        }

        public new static Task<Result<T>> FailAsync()
        {
            return Task.FromResult(Fail());
        }

        public new static Task<Result<T>> FailAsync(string message, object info = null)
        {
            return Task.FromResult(Fail(message, info));
        }

        public new static Task<Result<T>> FailAsync(List<string> messages)
        {
            return Task.FromResult(Fail(messages));
        }

        public new static Result<T> Success()
        {
            return new Result<T> { Succeeded = true };
        }

        public new static Result<T> Success(string message)
        {
            return new Result<T> { Succeeded = true, Messages = new List<string> { message } };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T> { Succeeded = true, Data = data };
        }

        public static Result<T> Success(T data, string message)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = new List<string> { message } };
        }

        public static Result<T> Success(T data, List<string> messages)
        {
            return new Result<T> { Succeeded = true, Data = data, Messages = messages };
        }

        public new static Task<Result<T>> SuccessAsync()
        {
            return Task.FromResult(Success());
        }

        public new static Task<Result<T>> SuccessAsync(string message)
        {
            return Task.FromResult(Success(message));
        }

        public static Task<Result<T>> SuccessAsync(T data)
        {
            return Task.FromResult(Success(data));
        }

        public static Task<Result<T>> SuccessAsync(T data, string message)
        {
            return Task.FromResult(Success(data, message));
        }

        public static async Task<IResult<T>> ExecuteAsync(Func<Task<IResult<T>>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                // TODO: логирование
                return Result<T>.Fail(e.Message);
            }
        }

        public static async Task<IResult<T>> ExecuteAsync(Func<Task<IResult<T>>> func, Action<string> logFunc)
        {
            try
            {
                return await func();
            }
            catch (Exception e)
            {
                if (logFunc != null)
                    logFunc($"{e}");
                return Result<T>.Fail(e.Message);
            }
        }

        public static async Task<IResult<T>> ExecuteAsync(Func<Task<T>> func, Action<string> logFunc,
                string errorMsg = null)
        {
            try
            {
                return Result<T>.Success(await func());
            }
            catch (Exception e)
            {
                if (logFunc != null)
                    logFunc($"{e}");
                return Result<T>.Fail(errorMsg ?? e.Message);
            }
        }

        public static async Task<IResult<T>> ExecuteAsync(Func<Task<T>> func)
        {
            try
            {
                return Result<T>.Success(await func());
            }
            catch (Exception e)
            {
                // TODO: логирование
                return Result<T>.Fail(e.Message);
            }
        }
    }
}
