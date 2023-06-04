namespace Organization.Queries.OwnCompanyGet;

internal sealed class GetOwnCompanyQueryInvalidException : Exception
{
    public GetOwnCompanyQueryInvalidException(string message) : base(message)
    {
    }
}