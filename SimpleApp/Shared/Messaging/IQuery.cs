using FluentResults;
using MediatR;

namespace SimpleApp.Shared.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>;