var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// Register the Swagger services
builder.Services.AddSwaggerDocument();

var app = builder.Build();

// Register the Swagger generator and the Swagger UI middlewares
app.UseOpenApi();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerUi3();
}

app.UseCors(options => options.AllowAnyOrigin().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();