namespace reciprBE.Contracts.Meal;

public record MealResponse(
    Guid id,
    DateTime LastModifiedDateTime,
    string Name, 
    string Description,
    int Duration,
    List<string> Tags,
    List<string> Ingredients,
    List<string> Seasoning
);