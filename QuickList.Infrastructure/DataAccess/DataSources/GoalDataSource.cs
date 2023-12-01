using Microsoft.EntityFrameworkCore;
using QuickList.Domain.GoalAggregate;

namespace QuickList.Infrastructure.DataAccess.DataSources;

public class GoalDataSource : IGoalDataSource
{
    private readonly QuickListContext _context;

    public GoalDataSource(QuickListContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Goal>> GetAllAsync()
    {
        return await _context.Goals.ToListAsync();
    }

    public async Task<Goal?> GetByIdAsync(Guid id)
    {
        return await _context.Goals.FirstOrDefaultAsync(x => x.Id == id);
    }
}