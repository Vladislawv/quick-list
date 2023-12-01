using Microsoft.AspNetCore.Mvc;
using QuickList.Domain.GoalAggregate;
using QuickList.MVC.DataMapers;
using QuickList.MVC.Requests;

namespace QuickList.MVC.Controllers;

public class GoalController : Controller
{
    private readonly IGoalService _goalService;

    public GoalController(IGoalService goalService)
    {
        _goalService = goalService;
    }

    /// <summary>
    /// Get all goals.
    /// </summary>
    /// <returns>Returns Partial View with all goals</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var goals = await _goalService.GetAllAsync();
        return PartialView(goals.ToResponse());
    }

    /// <summary>
    /// Get goal by Id.
    /// </summary>
    /// <param name="id">Goal Id</param>
    /// <returns>Returns PartialView with goal</returns>
    [HttpGet]
    public async Task<IActionResult> GetById(Guid id)
    {
        var goal = await _goalService.GetByIdAsync(id);
        return PartialView(goal.ToResponse());
    }

    /// <summary>
    /// Create a Goal.
    /// </summary>
    /// <param name="request">Input request with required title and description fields</param>
    /// <returns>Returns PartialView with goal</returns>
    [HttpPost]
    public async Task<IActionResult> Create(GoalRequest request)
    {
        var goal = await _goalService.CreateAsync(request.ToDomain());
        return PartialView("GetById",goal.ToResponse());
    }

    /// <summary>
    /// Update goal by Id.
    /// </summary>
    /// <param name="id">Goal Id</param>
    /// <param name="request">Input request with required title and description fields</param>
    /// <returns>Returns PartialView with goal</returns>
    [HttpPut]
    public async Task<IActionResult> UpdateById(Guid id, GoalRequest request)
    {
        var goal = await _goalService.UpdateByIdAsync(id, request.ToDomain());
        return PartialView("GetById", goal.ToResponse());
    }

    /// <summary>
    /// Delete goal by Id.
    /// </summary>
    /// <param name="id">Goal Id</param>
    /// <returns>Result operation status code</returns>
    [HttpDelete]
    public async Task<IActionResult> DeleteById(Guid id)
    {
        await _goalService.DeleteByIdAsync(id);
        return Ok();
    }

    /// <summary>
    /// Set property IsDone to the goal by Id.
    /// </summary>
    /// <param name="id">Goal Id</param>
    /// <param name="isDone">IsDone</param>
    /// <returns>Result operation status code</returns>
    [HttpPost]
    public async Task<IActionResult> SetIsDoneById(Guid id, bool isDone)
    {
        await _goalService.SetIsDoneByIdAsync(id, isDone);
        return Ok();
    }
}