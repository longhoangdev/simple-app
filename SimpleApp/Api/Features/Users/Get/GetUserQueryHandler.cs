using FluentResults;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.Entities.Users;
using SimpleApp.Persistence.Contexts;
using SimpleApp.Shared.Messaging;

namespace SimpleApp.Api.Features.Users.Get;

internal sealed class GetUserQueryHandler(DataContext dataContext) : IQueryHandler<GetUserQuery, GetUserResponse>
{
    public async Task<Result<GetUserResponse>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await dataContext.Users.FirstAsync(u => u.Id == request.UserId, cancellationToken);
        return Result.Ok(new GetUserResponse
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            IsActive = user.IsActive
        });
    }
}