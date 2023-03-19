namespace reciprBE.Models;
using ErrorOr;

public class Meal {
    // Timestamp 55:17, Industry level REST API 
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

    // Constructor
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
        List<string> seasoning
    ) {
        // enforce invariants
        if (name.Length is < MinNameLength or > MaxNameLength) {
            
        }
        return new Meal (
            Guid.NewGuid(), 
            DateTime.UtcNow,
            name,
            macros,
            duration,
            tags,
            ingredients,
            seasoning  
        ); 
    }
}