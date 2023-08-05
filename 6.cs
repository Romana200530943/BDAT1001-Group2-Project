using Microsoft.AspNetCore.Identity;

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
