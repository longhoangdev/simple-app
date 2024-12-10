using Microsoft.AspNetCore.Mvc;
using SimpleApp.Shared.Messaging;

namespace SimpleApp.Api.Features.Users.Delete;

internal sealed class DeleteUserCommand : ICommand<DeleteUserResponse>
{
    [FromRoute(Name = "userId")]
    public required Guid UserId { get; init; }
}