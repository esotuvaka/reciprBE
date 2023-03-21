using reciprBE.Services.Meals;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddScoped<IMealService, MealService>();
builder.Services.AddEndpointsApiExplorer();

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


