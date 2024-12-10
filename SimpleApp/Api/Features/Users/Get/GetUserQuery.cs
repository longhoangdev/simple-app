using Microsoft.AspNetCore.Mvc;
using SimpleApp.Shared.Messaging;

namespace SimpleApp.Api.Features.Users.Get;

internal sealed class GetUserQuery : IQuery<GetUserResponse>
{
    [FromRoute(Name = "userId")]
    public required Guid UserId { get; init; }
}