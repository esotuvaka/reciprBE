namespace reciprBE.Contracts.Meal;

public record UpsertMealRequest(
    Guid id,
    string Name,
    string Description,
    string Duration,
    List<string> Tags,
    List<string> Ingredients,
    List<string> Seasoning
);