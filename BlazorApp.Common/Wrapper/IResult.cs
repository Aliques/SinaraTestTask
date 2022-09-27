namespace UserManagement.Common.Wrapper
{
    public interface IResult
    {
        List<string> Messages { get; set; }

        bool Succeeded { get; set; }

        string StringMessages { get; }

        object SucceededInfo { get; set; }

        void ThrowIfFail();
    }

    public interface IResult<out T> : IResult
    {
        T Data { get; }
    }
}
