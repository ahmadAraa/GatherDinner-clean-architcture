using GatherDinner.Contracts.Authentication;
using GatherDinner.Application;
using GatherDinner.Infrastructure;
using Scalar.AspNetCore;
using GatherDinner.Api.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using GatherDinner.Api.Errors;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddOpenApi();
// builder.Services.AddControllers(options =>
// {
//     options.Filters.Add<ErrorHandlingFilterAttribute>();
// });
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddSingleton<ProblemDetailsFactory,GatherDinnerProblemDetailsFactory>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}
app.UseExceptionHandler("/error");


app.UseHttpsRedirection();
app.MapControllers();

app.Run();
