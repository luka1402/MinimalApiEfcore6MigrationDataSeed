using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuizAppApi;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 builder.Services.AddDbContext<QuizContext>(options =>
     options.UseSqlServer(builder.Configuration.GetConnectionString("QuizDb")));

var app = builder.Build();


 using var scope = app.Services.CreateScope();
 using var context = scope.ServiceProvider.GetRequiredService<QuizContext>();
 context.Database.Migrate();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/questions", async (QuizContext context) =>
{
    var questions = await context.Quizs.ToListAsync();
    // Handle the questions as needed
    return questions;
});


app.Run();

