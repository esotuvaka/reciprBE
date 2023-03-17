using reciprBE.Models; 

namespace reciprBE.Services.Meals;

public class MealService : IMealService {
    private static readonly Dictionary<Guid, Meal> _meals = new();
    public void CreateMeal(Meal meal) {
        _meals.Add(meal.Id, meal);
    }

    public void DeleteMeal(Guid id)
    {
        _meals.Remove(id);
    }

    public Meal GetMeal(Guid id) { 
        return _meals[id];
    }

    public void UpsertMeal(Meal meal)
    {
        _meals[meal.Id] = meal;
    }
}