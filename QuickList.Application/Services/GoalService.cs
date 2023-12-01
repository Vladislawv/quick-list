using QuickList.Domain.Exceptions;
using QuickList.Domain.GoalAggregate;

namespace QuickList.Application.Services;

public class GoalService : IGoalService
{
    private readonly IGoalDataSource _goalDataSource;
    private readonly IGoalRepository _goalRepository;

    public GoalService(IGoalDataSource goalDataSource, IGoalRepository goalRepository)
    {
        _goalDataSource = goalDataSource;
        _goalRepository = goalRepository;
    }

    public async Task<IReadOnlyList<Goal>> GetAllAsync()
    {
        return await _goalDataSource.GetAllAsync();
    }

    public async Task<Goal> GetByIdAsync(Guid id)
    {
        return await GetByIdThrowIfNullAsync(id);
    }

    public async Task<Goal> CreateAsync(Goal goal)
    {
        goal.CreatedDate = DateTime.UtcNow;
        goal.LastUpdatedDate = DateTime.UtcNow;
        await _goalRepository.CreateAsync(goal);
        
        return goal;
    }

    public async Task<Goal> UpdateByIdAsync(Guid id, Goal goal)
    {
        var existingGoal = await GetByIdThrowIfNullAsync(id);

        existingGoal.Title = goal.Title;
        existingGoal.Description = goal.Description;
        existingGoal.LastUpdatedDate = DateTime.UtcNow;
        
        await _goalRepository.UpdateAsync(existingGoal);
        return existingGoal;
    }

    public async Task DeleteByIdAsync(Guid id)
    {
        var goal = await GetByIdThrowIfNullAsync(id);
        await _goalRepository.DeleteAsync(goal);
    }

    public async Task<Goal> SetIsDoneByIdAsync(Guid id, bool isDone)
    {
        var goal = await GetByIdThrowIfNullAsync(id);
        goal.IsDone = isDone;
        await _goalRepository.UpdateAsync(goal);
        
        return goal;
    }

    private async Task<Goal> GetByIdThrowIfNullAsync(Guid id)
    {
        return await _goalDataSource.GetByIdAsync(id)
            ?? throw new NotFoundException($"Goal is not exist with Id: {id}.");
    }
}