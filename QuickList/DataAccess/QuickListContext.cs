using Microsoft.EntityFrameworkCore;

namespace QuickList.DataAccess;

public class QuickListContext : DbContext
{
    public QuickListContext(DbContextOptions<QuickListContext> options) : base(options) { }
}