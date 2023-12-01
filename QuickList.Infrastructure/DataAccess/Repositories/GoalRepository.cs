using QuickList.Domain.GoalAggregate;

namespace QuickList.Infrastructure.DataAccess.Repositories;

public class GoalRepository : IGoalRepository
{
    private readonly QuickListContext _context;

    public GoalRepository(QuickListContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Goal goal)
    {
        await _context.AddAsync(goal);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Goal goal)
    {
        _context.Update(goal);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Goal goal)
    {
        _context.Remove(goal);
        await _context.SaveChangesAsync();
    }
}