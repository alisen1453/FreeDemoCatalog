using FreeDemoCatalog.Bussiness;
using FreeDemoCatalog.Bussiness.Services;
using FreeDemoCatalog.DataAccess.Abstract;
using FreeDemoCatalog.DataAccess.Dal;
using FreeDomeCatalog.Catalog.DataAccess;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CategoryDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var Configuration = builder.Configuration;

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Authority = Configuration["IdentityServerUrl"];//appsettingten gelir.
        options.Audience = "resource_catalog";//Identity Serverdan gelir
        options.RequireHttpsMetadata = false; // Enforces HTTPS in production
        //options.TokenValidationParameters = new TokenValidationParameters
        //{
        //    ValidateIssuer = true,
        //    ValidateAudience = true,
        //    ValidateLifetime = true,
        //    ValidAudience = "your-api-audience",
        //    ValidIssuer = Configuration["IdentityServerUrl"]
        //};
       // options.SaveToken = true; // Optional: Saves the token
    });


builder.Services.AddTransient<INoteServices,NoteManager>();
builder.Services.AddTransient<ICategoryServices,CategoryManager>();

builder.Services.AddTransient<ICategoryRepository, CategoryDal>();
builder.Services.AddTransient<INoteRepository,NoteDal>();



builder.Services.AddControllers(opt =>
{
    // [Authorize(LocalApi.PolicyName)] Tüm controllerlar için otomatik Authorize yapar.

    opt.Filters.Add(new AuthorizeFilter());

});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.UseAuthentication();//Sonradan eklendi tokenalmak için

app.MapControllers();

app.Run();
