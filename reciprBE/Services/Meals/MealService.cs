using Microsoft.EntityFrameworkCore;
using reciprBE.Models; 
using reciprBE.ServiceErrors;
using reciprBE.Persistence;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace reciprBE.Services.Meals;

public class MealService : IMealService {
    private readonly ReciprDbContext _dbContext;

    public MealService(ReciprDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ErrorOr<Created> CreateMeal(Meal meal) {
        _dbContext.Add(meal);
        _dbContext.SaveChanges();

        return Result.Created;
    }

    public ErrorOr<Deleted> DeleteMeal(Guid id)
    {
        var meal = _dbContext.Meals.Find(id);

        if (meal is null) {
            return Errors.Meal.NotFound;
        }

        _dbContext.Remove(meal);
        _dbContext.SaveChanges();

        return Result.Deleted;
    }

    public ErrorOr<Meal> GetMeal(Guid id) { 
        if (_dbContext.Meals.Find(id) is Meal meal) {
            return meal;
        }

        return Errors.Meal.NotFound;
    }

    public ErrorOr<JsonResult> GetRandomMeals(int count) {
        var randomMeals = _dbContext.Meals.OrderBy(m => Guid.NewGuid()).Take(count).ToList();
        return new JsonResult(randomMeals);
    }

    public ErrorOr<JsonResult> GetMealsByTags(string tag) { 
       var taggedMeals = _dbContext.Meals
                            .FromSqlRaw($"SELECT * FROM Meals WHERE Tags LIKE '%' + @tag + '%'", new SqlParameter("@tag", tag))
                            .ToList();

        if (taggedMeals is List<Meal> meals) {
            return new JsonResult(meals);
        }

        return Errors.Meal.InvalidTags;
    }

    public ErrorOr<UpsertedMeal> UpsertMeal(Meal meal)
    {
        // HTTP protocol requires returning 201 if something is created
        //  204 if something is updated.

        // Check for an ID match of the Meal
        //  if no match then create the meal, otherwise update it
        var isNewlyCreated = !_dbContext.Meals.Any(b => b.Id == meal.Id);
        
        if (isNewlyCreated) {
            _dbContext.Meals.Add(meal);
        } 
        else {
            _dbContext.Meals.Update(meal);
        }

        _dbContext.SaveChanges();

        return new UpsertedMeal(isNewlyCreated);
    }
}