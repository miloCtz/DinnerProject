namespace Contracts.Auth
{
    public record class AuthResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token)
    {
    }
}
