using QuickList.Domain.GoalAggregate;
using QuickList.MVC.Requests;
using QuickList.MVC.Responses;

namespace QuickList.MVC.DataMapers;

public static class GoalDataMapper
{
    public static IReadOnlyList<GoalResponse> ToResponse(this IReadOnlyList<Goal> goals)
    {
        return goals.Select(ToResponse).ToList();
    }
    
    public static GoalResponse ToResponse(this Goal goal)
    {
        return new GoalResponse
        {
            Id = goal.Id,
            Title = goal.Title,
            Description = goal.Description,
            IsDone = goal.IsDone,
            CreatedDate = goal.CreatedDate,
            LastUpdatedDate = goal.LastUpdatedDate
        };
    }

    public static Goal ToDomain(this GoalRequest request)
    {
        return new Goal
        {
            Title = request.Title,
            Description = request.Description
        };
    }
}