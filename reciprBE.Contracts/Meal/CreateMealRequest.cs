namespace reciprBE.Contracts.Meal;

public record CreateMealRequest(
    string Name,
    List<Dictionary<string, int>> Macros,
    string Duration,
    List<string> Tags,
    List<string> Ingredients,
    List<string> Seasoning
);