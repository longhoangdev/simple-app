namespace SimpleApp.Api.Features.Users.GetList;

internal sealed class GetUserListResponse
{
    public required int Total { get; init; }
    public required List<GetUserListResponseItem> Items { get; init; }
}

internal sealed class GetUserListResponseItem
{
    public required Guid Id { get; init; }
    public required string FirstName { get; init; }
    public required string LastName { get; init; }
    public required string Email { get; init; }
    public string? Phone { get; init; }
    public required bool IsActive { get; init; }
}