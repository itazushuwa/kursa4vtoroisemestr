var builder = WebApplication.CreateBuilder(args);
builder.Services.AddMvc();
var app = builder.Build();
app.UseStaticFiles();

app.MapControllerRoute(
    name: "default", pattern: "{Controller=Home}/{Action=Index}");

app.Run();
