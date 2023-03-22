namespace reciprBE.Models;
using reciprBE.ServiceErrors;
using reciprBE.Contracts.Meal;
using ErrorOr;

public class Macro {

}

public class Meal { 
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
  
    public Guid Id { get; private set; }
    public DateTime LastModifiedDateTime { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string Duration { get; private set; }
    public List<string> Tags { get; private set; }
    public List<string> Ingredients { get; private set; }
    public List<string> Seasoning { get; private set; }

    // EntityFramework will use Reflection to populate the Meal object
    private Meal() {}

    // Private Constructor
    // To create a Meal, you MUST use the static "Create" method
    //  which uses the Factory pattern.
    private Meal(
        Guid id, 
        DateTime lastModifiedDateTime, 
        string name,  
        string description,
        string duration, 
        List<string> tags, 
        List<string> ingredients, 
        List<string> seasoning) 
    {
         
        Id = id;
        LastModifiedDateTime = lastModifiedDateTime;
        Name = name; 
        Description = description;
        Duration = duration;
        Tags = tags;
        Ingredients = ingredients;
        Seasoning = seasoning;
    }

    public static ErrorOr<Meal> Create(
        string name, 
        string description,
        string duration,
        List<string> tags,
        List<string> ingredients,
        List<string> seasoning,
        Guid? id = null
    ) {
        // Enforce invariants or whatever Business rules are required
        List<Error> errors = new();
        if (name.Length is < MinNameLength or > MaxNameLength) {
            errors.Add(Errors.Meal.InvalidName);
        }

        if (errors.Count > 0) {
            return errors;
        }

        return new Meal (
            id ?? Guid.NewGuid(), 
            DateTime.UtcNow,
            name, 
            description,
            duration,
            tags,
            ingredients,
            seasoning  
        ); 
    }
    
    // 2 static factory methods. One for upserting (via an ID), other for creating
    public static ErrorOr<Meal> From(CreateMealRequest request) {
        return Create(
            request.Name, 
            request.Description,
            request.Duration,
            request.Tags,
            request.Ingredients,
            request.Seasoning
        );
    }

    public static ErrorOr<Meal> From(Guid id, UpsertMealRequest request) {
        return Create(
            request.Name, 
            request.Description,
            request.Duration,
            request.Tags,
            request.Ingredients,
            request.Seasoning,
            id
        );
    }
}