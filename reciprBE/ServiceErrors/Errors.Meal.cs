using ErrorOr;

namespace reciprBE.ServiceErrors;

public static class Errors {
    public static class Meal {
        public static Error NotFound => Error.NotFound(
            code: "Meal.NotFound",
            description: "Meal was not found"
        );
    }
}