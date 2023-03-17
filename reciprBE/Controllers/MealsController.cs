using Microsoft.AspNetCore.Mvc;
using reciprBE.Contracts.Meal;
using reciprBE.Models;
using reciprBE.Services.Meals;

namespace reciPR.Controllers;

[ApiController]
[Route("[controller]")] // Since all requests start with Meals route, can abstract the route out
public class MealsController : ControllerBase {

    // Dependency injection
    private readonly IMealService _mealService;

    public MealsController(IMealService mealService) {
        _mealService = mealService;
    }

    [HttpPost]
    public IActionResult CreateMeal(CreateMealRequest request){
        var meal = new Meal(
            Guid.NewGuid(),
            DateTime.UtcNow,
            request.Name,
            request.Macros,
            request.Duration,
            request.Tags,
            request.Ingredients,
            request.Seasoning
        );

        // TODO: Save meal to database
        _mealService.CreateMeal(meal);

        var response = new MealResponse(
            meal.Id,
            meal.LastModifiedDateTime,
            meal.Name,
            meal.Macros,
            meal.Duration,
            meal.Tags,
            meal.Ingredients,
            meal.Seasoning
        );

        return CreatedAtAction(actionName: nameof(GetMeal), routeValues: new { id = meal.Id }, value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMeal(Guid id){
        Meal meal = _mealService.GetMeal(id);

        var response = new MealResponse(
            meal.Id,
            meal.LastModifiedDateTime,
            meal.Name,
            meal.Macros,
            meal.Duration,
            meal.Tags,
            meal.Ingredients,
            meal.Seasoning
        );

        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertMeal(Guid id, UpsertMealRequest request){
        var meal = new Meal(
            id,
            DateTime.UtcNow,
            request.Name,
            request.Macros,
            request.Duration,
            request.Tags,
            request.Ingredients,
            request.Seasoning
        );

        _mealService.UpsertMeal(meal);

        // TODO: return 201 if a new meal is created
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMeal(Guid id) {
        _mealService.DeleteMeal(id);
        return NoContent();
    }
}