using reciprBE.Models;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
namespace reciprBE.Services.Meals;

public interface IMealService {
    // Create
    ErrorOr<Created> CreateMeal(Meal meal);

    // Read
    ErrorOr<Meal> GetMeal(Guid id);

    // Update
    ErrorOr<UpsertedMeal> UpsertMeal(Meal meal);

    // Delete
    ErrorOr<Deleted> DeleteMeal(Guid id);


    // Specialized App endpoints
    ErrorOr<JsonResult> GetRandomMeals(int count);
}