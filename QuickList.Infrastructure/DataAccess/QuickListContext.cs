using Microsoft.EntityFrameworkCore;
using QuickList.Domain.GoalAggregate;

namespace QuickList.Infrastructure.DataAccess;

public class QuickListContext : DbContext
{
    public DbSet<Goal> Goals { get; set; }
    
    public QuickListContext(DbContextOptions<QuickListContext> options) : base(options) { }
}