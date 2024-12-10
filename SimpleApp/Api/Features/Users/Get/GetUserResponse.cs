namespace SimpleApp.Api.Features.Users.Get;

internal sealed class GetUserResponse
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public required bool IsActive { get; set; }
}