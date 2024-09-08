using IdentityServer;
using IdentityServer.DataAccess;
using IdentityServer.Models;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//--------------DAtabaseSetting-------------------------.
builder.Services.AddDbContext<UserDbContex>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("conn")));
///*----------------------------------------------------------------------

builder.Services.AddControllersWithViews();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddAuthentication();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews();

//----------IdentityServerSetting-----------------------------
builder.Services.AddIdentityServer()
    .AddDeveloperSigningCredential()
    .AddInMemoryApiScopes(config.ApiScope)
    .AddInMemoryApiResources(config.ApiResource)
    .AddInMemoryIdentityResources(config.IdentityResources)
    .AddInMemoryClients(config.Client);
//. AddResourceOwnerValidator<ResourceOwnerPasswordValidator>(); 
///*----------------------------------------------------------



builder.Services.AddControllers(opt =>
{
    // [Authorize(LocalApi.PolicyName)] Tüm controllerlar için otomatik Authorize yapar.

    opt.Filters.Add(new AuthorizeFilter());

});
//--------IdentityUser Setting--------------------------------------
builder.Services.AddIdentity<UsersConfrim, IdentityRole<Guid>>(
    options =>
    {
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 1;
        options.User.RequireUniqueEmail = true;
    }

    ).AddEntityFrameworkStores<UserDbContex>();//.AddDefaultTokenProviders(); ;

///*------------------------------------------------------------------

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseIdentityServer();
app.UseAuthentication();

app.MapControllers();

app.Run();
