using SimpleApp.Domain.Interfaces;

namespace SimpleApp.Domain.Entities.Users;

public class User : ISoftDeletable
{
    public required Guid Id { get; init; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public required bool IsActive { get; set; }
    public bool IsDeleted { get; set; }
    
    public static User Create(string firstName, string lastName, string email, string? phone, bool isActive)
        => new()
        {
            Id = Guid.NewGuid(),
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Phone = phone,
            IsActive = isActive
        };

    public void Update(string firstName, string lastName, string email, string? phone, bool isActive)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Phone = phone;
        IsActive = isActive;
    }
}