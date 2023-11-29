namespace QuickList.Domain.GoalAggregate;

public interface IGoalRepository
{
    Task CreateAsync(Goal goal);
    Task UpdateAsync(Goal goal);
    Task DeleteAsync(Goal goal);
}