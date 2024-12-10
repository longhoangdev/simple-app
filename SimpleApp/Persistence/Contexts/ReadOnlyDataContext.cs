using Microsoft.EntityFrameworkCore;
using SimpleApp.Domain.Entities.Users;

namespace SimpleApp.Persistence.Contexts;

public class ReadOnlyDataContext
{
    private readonly DataContext _context;
    
    public ReadOnlyDataContext(DataContext context)
    {
        _context = context;
        _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }
    
    public IQueryable<User> Users => _context.Users.IgnoreAutoIncludes();
}