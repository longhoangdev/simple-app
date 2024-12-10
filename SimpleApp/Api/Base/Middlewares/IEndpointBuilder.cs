namespace SimpleApp.Api.Base.Middlewares;

internal interface IEndpointBuilder
{
    void MapEndpoints(IEndpointRouteBuilder endpoints);
}