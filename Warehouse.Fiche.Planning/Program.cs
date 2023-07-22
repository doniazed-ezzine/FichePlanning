
using Database;
using Infra;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;
using AutoMapper;
var builder = WebApplication.CreateBuilder(args);


#region services cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("Origin",
                          policy =>
                          {
                              policy.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader();
                          });
});
#endregion

//builder.Services.AddControllers();

builder.Services.AddControllers(
options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddMediatR(typeof(Program));
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

#region Dependency injection Configuration
DependencyContainer.RegisterServices(builder.Services);
#endregion

#region Context
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("FichePlanningDbConnection"));
});
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}
app.UseSwagger();
app.UseSwaggerUI();

var version = $"v{typeof(Program).Assembly.GetName().Version}";
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint($"{version}/swagger.json", typeof(Program).Assembly.CustomAttributes.First(x => x.AttributeType.Name == "AssemblyProductAttribute").ConstructorArguments[0].Value.ToString());
});

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();
app.UseAuthentication();
app.UseCors("Origin");

app.MapControllers();

app.Run();