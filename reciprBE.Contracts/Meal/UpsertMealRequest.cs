namespace reciprBE.Contracts.Meal;

public record UpsertMealRequest(
    Guid id,
    string Name,
    List<Dictionary<string, int>> Macros,
    string Duration,
    List<string> Tags,
    List<string> Ingredients,
    List<string> Seasoning
);