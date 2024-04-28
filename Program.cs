using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using rep.App_Data;

var builder = WebApplication.CreateBuilder();
builder.Services.AddMvc();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Authentication/Login";
        options.LogoutPath = "/Aunthetication/Login";
        options.AccessDeniedPath = "/Aunthetication/AunthError";
    });



builder.Services.AddAuthorization();

string? connection = builder.Configuration.GetConnectionString("MyConnectionString");
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));

builder.Services.AddControllersWithViews();


var app = builder.Build();

app.MapControllerRoute(
    name: "default",
    pattern: "{Controller=Home}/{Action=Index}");

app.UseAuthentication();
app.UseAuthorization();



app.UseStaticFiles();

app.Run();