using Application.Interfaces.Contexts;
using Application.Interfaces.Personal;
using Application.Personal.FacadePattern;
using Mapster;
using MapsterMapper;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region connectionString
builder.Services.AddTransient<IDataBaseContext, DataBaseContext>();
string? connection = builder.Configuration["ConnectionString:SqlServer"];
builder.Services.AddDbContext<DataBaseContext>(option => option.UseSqlServer(connection));
#endregion

builder.Services.AddTransient<IPersonFacade, PersonFacade>();

var config = TypeAdapterConfig.GlobalSettings;
config.Scan(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton(config);
builder.Services.AddScoped<IMapper, ServiceMapper>();

builder.Services.AddRazorPages();
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
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
