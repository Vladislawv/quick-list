namespace QuickList.Domain.GoalAggregate;

public interface IGoalService
{
    Task<IReadOnlyList<Goal>> GetAllAsync();
    Task<Goal> GetByIdAsync(Guid id);
    Task<Goal> CreateAsync(Goal goal);
    Task<Goal> UpdateByIdAsync(Guid id, Goal goal);
    Task DeleteByIdAsync(Guid id);
    Task<Goal> SetIsDoneByIdAsync(Guid id, bool isDone);
}