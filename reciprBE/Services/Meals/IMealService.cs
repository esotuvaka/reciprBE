using reciprBE.Models;

namespace reciprBE.Services.Meals;

public interface IMealService {
    void CreateMeal(Meal meal);

    Meal GetMeal(Guid id);

    void UpsertMeal(Meal meal);

    void DeleteMeal(Guid id);
}