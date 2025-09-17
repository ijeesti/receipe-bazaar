using Microsoft.OpenApi.Models;
using RecipeMaster.Api.Endpoints;
using RecipeMaster.Api.Extentions;
using RecipeMaster.Api.Middlewares;
using RecipeMaster.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

var service = builder.Services;
service.AddEndpointsApiExplorer();
service.AddControllers();
service.AddSwaggerGen(options =>
{
    // Basic API info
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Recipe Bazaar API",
        Version = "v1",
        Description = "A showcase API demonstrating using React"
    });

    // Include XML comments (for summaries and parameter descriptions)
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

    // Optional: group endpoints, add tags, etc.
});

service.AddCors();
service.AddDependencies();

var app = builder.Build();

app.UseCors(p =>
        p.WithOrigins("http://localhost:3005")
        .AllowAnyMethod()
        .AllowAnyHeader()
);

// Ensure SQLite database
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<RecipeDbContext>();
    db.Database.EnsureCreated(); // creates DB and tables
}

app.UseMiddleware<ExceptionMiddleware>();
app.MapCommentEndpoints();
app.MapRecipeEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
