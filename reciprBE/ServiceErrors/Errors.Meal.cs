using ErrorOr;

namespace reciprBE.ServiceErrors;

public static class Errors {
    public static class Meal {
         public static Error InvalidName => Error.Validation(
            code: "Meal.InvalidName",
            description: $"Meal name must be between {Models.Meal.MinNameLength} and {Models.Meal.MaxNameLength} characters long."
        );
        public static Error NotFound => Error.NotFound(
            code: "Meal.NotFound",
            description: "Meal was not found"
        );
    }
}