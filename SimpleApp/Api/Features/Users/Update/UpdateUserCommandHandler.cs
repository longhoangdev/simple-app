using FluentResults;
using Microsoft.EntityFrameworkCore;
using SimpleApp.Persistence.Contexts;
using SimpleApp.Shared.Messaging;

namespace SimpleApp.Api.Features.Users.Update;

internal sealed class UpdateUserCommandHandler(DataContext context) : ICommandHandler<UpdateUserCommand, UpdateUserResponse>
{
    public async Task<Result<UpdateUserResponse>> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
    {
        var user = await context.Users.FirstAsync(x => x.Id == command.UserId, cancellationToken);
        
        if (!user.Email.Equals(command.Request.Email, StringComparison.OrdinalIgnoreCase))
        {
            var userExisted =
                await context.Users.AnyAsync(u => u.Email.Equals(command.Request.Email, StringComparison.OrdinalIgnoreCase), cancellationToken);
            if (userExisted)
                return Result.Fail("User with this email already exists");
        }
        
        user.Update(command.Request.FirstName, command.Request.LastName, command.Request.Email, command.Request.Phone, command.Request.IsActive);
        context.Users.Update(user);
        
        await context.SaveChangesAsync(cancellationToken);
        
        return Result.Ok(new UpdateUserResponse
        {
            UserId = command.UserId
        });
    }
}