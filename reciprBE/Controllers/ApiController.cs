using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ErrorOr;

namespace reciprBE.Controllers;

[ApiController]
[Route("[controller]")] // Since all requests start with Meals route, can abstract the route out
public class ApiController : ControllerBase {
    protected IActionResult Problem(List<Error> errors) {
        // If all errors are validation errors, return a problem that will
        //  explain in detail how to fix those errors.
        if (errors.All(e => e.Type == ErrorType.Validation)) {
            var modelStateDictionary = new ModelStateDictionary();

            foreach (var error in errors) {
                modelStateDictionary.AddModelError(error.Code, error.Description);
            }

            return ValidationProblem(modelStateDictionary);
        }

        if (errors.Any(e => e.Type == ErrorType.Unexpected)) {
            return Problem();
        }

        var firstError = errors[0];

        var statusCode = firstError.Type switch {
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError
        };

        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}