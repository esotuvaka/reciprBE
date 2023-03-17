namespace reciprBE.Models;

public class Meal {
    public Guid Id { get; }
    public DateTime LastModifiedDateTime {get;}
    public string Name {get;}
    public List<Dictionary<string, int>> Macros {get;}
    public string Duration {get;}
    public List<string> Tags {get;}
    public List<string> Ingredients {get;}
    public List<string> Seasoning {get;}

    // Constructor
    public Meal(
        Guid id, 
        DateTime lastModifiedDateTime, 
        string name, 
        List<Dictionary<string, int>> macros, 
        string duration, 
        List<string> tags, 
        List<string> ingredients, 
        List<string> seasoning) 
    {
        // enforce invariants
        Id = id;
        LastModifiedDateTime = lastModifiedDateTime;
        Name = name;
        Macros = macros;
        Duration = duration;
        Tags = tags;
        Ingredients = ingredients;
        Seasoning = seasoning;
    }
}