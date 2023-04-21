using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using JM_Ejercicio_2_Tablas.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<JM_Ejercicio_2_TablasContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("JM_Ejercicio_2_TablasContext") ?? throw new InvalidOperationException("Connection string 'JM_Ejercicio_2_TablasContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
