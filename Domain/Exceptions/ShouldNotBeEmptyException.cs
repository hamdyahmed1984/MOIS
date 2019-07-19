namespace Domain.Exceptions
{
    public sealed class ShouldNotBeEmptyException : DomainException
    {
        internal ShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
