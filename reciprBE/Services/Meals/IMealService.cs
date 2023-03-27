using reciprBE.Models;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
namespace reciprBE.Services.Meals;

public interface IMealService {
    ErrorOr<Created> CreateMeal(Meal meal);

    ErrorOr<Meal> GetMeal(Guid id);

    ErrorOr<JsonResult> GetRandomMeals(int count);

    ErrorOr<UpsertedMeal> UpsertMeal(Meal meal);

    ErrorOr<Deleted> DeleteMeal(Guid id);
}