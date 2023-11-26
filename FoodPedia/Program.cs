using FoodPedia.Services;
using FoodPedia.Services.Breakfasts;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.

    builder.Services.AddControllers();

    // Register BreakfastService service implementation from IBreakfastService interface
    // AddScoped used for indicates that every request using this service (while in the same scope HTTP),
    // dependency injection container will return the same instance
    builder.Services.AddScoped<IBreakfastService, BreakfastService>();
    
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    // builder.Services.AddEndpointsApiExplorer();
    // builder.Services.AddSwaggerGen();
}


var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    // if (app.Environment.IsDevelopment())
    // {
    //     app.UseSwagger();
    //     app.UseSwaggerUI();
    // }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}

