using MediatR;
using SimpleApp.Api.Base.Extensions;
using SimpleApp.Api.Base.Middlewares;
using SimpleApp.Api.Features.Users.Create;
using SimpleApp.Api.Features.Users.Delete;
using SimpleApp.Api.Features.Users.Get;
using SimpleApp.Api.Features.Users.GetList;
using SimpleApp.Api.Features.Users.Update;

namespace SimpleApp.Api.Features.Users;

public class EndpointBuilder :IEndpointBuilder
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder)
    {
        routeBuilder.MapGet("users", async (
            IMediator mediator,
            [AsParameters] GetUserListQuery query,
            CancellationToken cancellationToken
        ) =>
        {
            var result = await mediator.Send(query, cancellationToken);
            return result.ToHttpResult();
        });
        
        routeBuilder.MapGet("users/{userId}", async (
            IMediator mediator,
            [AsParameters] GetUserQuery query,
            CancellationToken cancellationToken
        ) =>
        {
            var result = await mediator.Send(query, cancellationToken);
            return result.ToHttpResult();
        });
        
        routeBuilder.MapPut("users/{userId}", async (
            IMediator mediator,
            [AsParameters] UpdateUserCommand command,
            CancellationToken cancellationToken
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.ToHttpResult();
        });
        
        routeBuilder.MapPost("users", async (
            IMediator mediator,
            [AsParameters] CreateUserCommand command,
            CancellationToken cancellationToken
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.ToHttpResult();
        });
        
        routeBuilder.MapDelete("users/{userId}", async (
            IMediator mediator,
            [AsParameters] DeleteUserCommand command,
            CancellationToken cancellationToken
        ) =>
        {
            var result = await mediator.Send(command, cancellationToken);
            return result.ToHttpResult();
        });
    }
}