using Microsoft.AspNetCore.Mvc;
using SimpleApp.Shared.Messaging;

namespace SimpleApp.Api.Features.Users.Update;

internal sealed class UpdateUserCommand : ICommand<UpdateUserResponse>
{
    [FromRoute(Name = "userId")]
    public required Guid UserId { get; init; }
    
    [FromBody]
    public required UpdateUserRequest Request { get; init; }
}

internal sealed class UpdateUserRequest
{
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public string? Phone { get; init; }
    public required bool IsActive { get; init; }
}