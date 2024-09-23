using FreeDemoCatalog.Bussiness;
using FreeDemoCatalog.Bussiness.Services;
using FreeDemoCatalog.DataAccess.Repositories;
using FreeDemoCatalog.Entities.Entity;
using FreeDemoCatalog.Entities.Entity.Models;
using FreeDemoCategory.Core.Abstract;
using FreeDomeCatalog.Catalog.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CategoryDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn"),
        b => b.MigrationsAssembly("FreeDomeCatalog.Catalog")));

// Add services to the container.
//builder.Services.AddAutoMapper(typeof(mapperProfile).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var Configuration = builder.Configuration;

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(options =>
//    {
//        options.Authority = Configuration["IdentityServerUrl"];//appsettingten gelir.
//        options.Audience = "resource_catalog";//Identity Serverdan gelir
//        options.RequireHttpsMetadata = false; // Enforces HTTPS in production
//                                              //options.TokenValidationParameters = new TokenValidationParameters
//                                              //{
//                                              //    ValidateIssuer = true,
//                                              //    ValidateAudience = true,
//                                              //    ValidateLifetime = true,
//                                              //    ValidAudience = "your-api-audience",
//                                              //    ValidIssuer = Configuration["IdentityServerUrl"]
//                                              //};
//                                               options.SaveToken = true; // Optional: Saves the token
//    });

builder.Services.AddScoped(typeof(IServices<>), typeof(Manager<>));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//builder.Services.AddControllers(opt =>
//{
//    // [Authorize(LocalApi.PolicyName)] Tüm controllerlar için otomatik Authorize yapar.

//    opt.Filters.Add(new AuthorizeFilter());

//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
//app.UseAuthentication();//Sonradan eklendi tokenalmak için

app.MapControllers();

app.Run();
