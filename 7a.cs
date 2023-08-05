using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ContactManager.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;

var webAppBuilder = WebApplication.CreateBuilder(args);

var connString = webAppBuilder.Configuration.GetConnectionString("DefaultConnection");
webAppBuilder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connString));
webAppBuilder.Services.AddDatabaseDeveloperPageExceptionFilter();

webAppBuilder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationDbContext>();

webAppBuilder.Services.AddRazorPages();

webAppBuilder.Services.AddControllers(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                     .RequireAuthenticatedUser()
                     .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

var app = webAppBuilder.Build();
