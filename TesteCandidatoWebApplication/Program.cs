using Microsoft.EntityFrameworkCore;
using TesteCandidatoWebApplication.Data;
using TesteCandidatoWebApplication.Repositories.CEPRepository;
using TesteCandidatoWebApplication.Services.CEPService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddScoped<ICEPService, CEPService>();
builder.Services.AddScoped<ICEPRepository, CEPRepository>();

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
    pattern: "{controller=CEP}/{action=Index}/{id?}");

app.Run();