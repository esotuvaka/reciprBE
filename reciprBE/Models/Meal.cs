namespace reciprBE.Models;
using reciprBE.ServiceErrors;
using reciprBE.Contracts.Meal;
using ErrorOr;

public class Meal { 
    public const int MinNameLength = 3;
    public const int MaxNameLength = 50;
   

    public Guid Id { get; }
    public DateTime LastModifiedDateTime {get;}
    public string Name {get;}
    public List<Dictionary<string, int>> Macros {get;}
    public string Duration {get;}
    public List<string> Tags {get;}
    public List<string> Ingredients {get;}
    public List<string> Seasoning {get;}

    // Private Constructor
    // To create a Meal, you MUST use the static "Create" method
    //  which uses the Factory pattern.
    private Meal(
        Guid id, 
        DateTime lastModifiedDateTime, 
        string name, 
        List<Dictionary<string, int>> macros, 
        string duration, 
        List<string> tags, 
        List<string> ingredients, 
        List<string> seasoning) 
    {
         
        Id = id;
        LastModifiedDateTime = lastModifiedDateTime;
        Name = name;
        Macros = macros;
        Duration = duration;
        Tags = tags;
        Ingredients = ingredients;
        Seasoning = seasoning;
    }

    public static ErrorOr<Meal> Create(
        string name,
        List<Dictionary<string, int>> macros,
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
            macros,
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
            request.Macros,
            request.Duration,
            request.Tags,
            request.Ingredients,
            request.Seasoning
        );
    }

    public static ErrorOr<Meal> From(Guid id, UpsertMealRequest request) {
        return Create(
            request.Name,
            request.Macros,
            request.Duration,
            request.Tags,
            request.Ingredients,
            request.Seasoning,
            id
        );
    }
}