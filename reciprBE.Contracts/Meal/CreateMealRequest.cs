namespace reciprBE.Contracts.Meal;

public record CreateMealRequest(
    string Name,
    string Description,
    string Duration,
    List<string> Tags,
    List<string> Ingredients,
    List<string> Seasoning
);