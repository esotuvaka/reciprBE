using Microsoft.AspNetCore.Mvc;
using reciprBE.Contracts.Meal;
using reciprBE.Models;
using reciprBE.Services.Meals;
using ErrorOr;
using reciprBE.ServiceErrors;
using reciprBE.Controllers;

namespace reciPR.Controllers;

[ApiController]
[Route("[controller]")] // Since all requests start with Meals route, can abstract the route out
public class MealsController : ApiController {

    // Dependency injection
    private readonly IMealService _mealService;

    public MealsController(IMealService mealService) {
        _mealService = mealService;
    }

    [HttpPost]
    public IActionResult CreateMeal(CreateMealRequest request){
        ErrorOr<Meal> requestToMealResult = Meal.From(request);

        if (requestToMealResult.IsError) {
            return Problem(requestToMealResult.Errors);
        }

        var meal = requestToMealResult.Value;

        // TODO: Save meal to database
        ErrorOr<Created> createMealResult = _mealService.CreateMeal(meal);

        return createMealResult.Match(
            created => CreatedAtGetMeal(meal),
            errors => Problem(errors)
        );
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetMeal(Guid id){
        ErrorOr<Meal> getMealResult = _mealService.GetMeal(id);

        return getMealResult.Match(
            meal => Ok(MapMealResponse(meal)),
            errors => Problem(errors)
        );
    }  

    [HttpPut("{id:guid}")]
    public IActionResult UpsertMeal(Guid id, UpsertMealRequest request){

        // Controller determines if it received errors or a Meal
        //  then returns whatever it received.
        ErrorOr<Meal> requestToMealResult = Meal.From(id, request);

        if (requestToMealResult.IsError) {
            return Problem(requestToMealResult.Errors);
        }

        var meal = requestToMealResult.Value;

        ErrorOr<UpsertedMeal> upsertedMealResult = _mealService.UpsertMeal(meal);
 
        return upsertedMealResult.Match(
            upserted => upserted.isNewlyCreated ? CreatedAtGetMeal(meal) : NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteMeal(Guid id) {
        ErrorOr<Deleted> deletedMealResult = _mealService.DeleteMeal(id);

        return deletedMealResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );        
    }

    private static MealResponse MapMealResponse(Meal meal) {
        return new MealResponse (
            meal.Id,
            meal.LastModifiedDateTime,
            meal.Name,
            meal.Macros,
            meal.Duration,
            meal.Tags,
            meal.Ingredients,
            meal.Seasoning
        );
    }

    private CreatedAtActionResult CreatedAtGetMeal(Meal meal) {
        return CreatedAtAction(
            actionName: nameof(GetMeal), 
            routeValues: new { id = meal.Id }, 
            value: MapMealResponse(meal)
        );
    }
}