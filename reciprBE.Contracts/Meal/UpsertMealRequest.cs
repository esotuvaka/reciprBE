namespace reciprBE.Contracts.Meal;

public record UpsertMealRequest(
    Guid id,
    string Name,
    string Description, 
    List<Dictionary<string, int>> Macros,
    int Duration,
    List<string> Tags,
    List<string> Ingredients,
    List<string> Seasoning,
    List<string> Instructions
);