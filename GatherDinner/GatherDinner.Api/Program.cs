using GatherDinner.Api.Errors;
using GatherDinner.Api.Filters;
using GatherDinner.Application;
using GatherDinner.Contracts.Authentication;
using GatherDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);


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
