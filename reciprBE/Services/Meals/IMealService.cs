using reciprBE.Models;
using ErrorOr;

namespace reciprBE.Services.Meals;

public interface IMealService {
    ErrorOr<Created> CreateMeal(Meal meal);

    ErrorOr<Meal> GetMeal(Guid id);

    ErrorOr<UpsertedMeal> UpsertMeal(Meal meal);

    ErrorOr<Deleted> DeleteMeal(Guid id);
}