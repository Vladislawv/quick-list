namespace QuickList.Domain.GoalAggregate;

public interface IGoalDataSource
{
    Task<IReadOnlyList<Goal>> GetAllAsync();
    Task<Goal?> GetByIdAsync(Guid id);
}