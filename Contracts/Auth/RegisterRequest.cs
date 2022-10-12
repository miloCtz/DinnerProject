namespace Contracts.Auth
{
    public record class RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
