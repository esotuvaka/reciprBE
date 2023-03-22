using reciprBE.Services.Meals;
using reciprBE.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ReciprDbContext>(options => // Need to change the connection string inside appsettings.json to actually target a db
    options.UseSqlServer(builder.Configuration.GetConnectionString("recipr.db.connect")));

builder.Services.AddCors();

var app = builder.Build();

app.UseCors(builder => {
    builder.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});
 
app.UseExceptionHandler("/error");
app.UseHttpsRedirection(); 
app.MapControllers();
app.Run();


