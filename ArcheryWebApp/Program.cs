using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using ArcheryWebApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArcheryContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("ArcheryDb"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("ArcheryDb"))
    )
);

var app = builder.Build();

// Middleware pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Scores}/{action=Index}/{id?}"
);

app.Run();