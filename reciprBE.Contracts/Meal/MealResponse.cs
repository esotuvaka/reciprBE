namespace reciprBE.Contracts.Meal;

public record MealResponse(
    Guid id,
    DateTime LastModifiedDateTime,
    string Name, 
    string Description, 
    List<Dictionary<string,int>> Macros,
    int Duration,
    List<string> Tags,
    List<string> Ingredients,
    List<string> Seasoning
);