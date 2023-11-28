using Microsoft.EntityFrameworkCore;

namespace QuickList.Infrastructure.DataAccess;

public class QuickListContext : DbContext
{
    public QuickListContext(DbContextOptions<QuickListContext> options) : base(options) { }
}