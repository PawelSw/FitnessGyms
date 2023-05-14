using FitnessGyms.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using FitnessGyms.Infrastructure.Extensions;
using FitnessGyms.Application.Extensions;
using FitnessGyms.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true);
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();


//builder.Services.AddDbContext<FitnessGymDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("FitnessGymsDatabaseConnection")));


var app = builder.Build();

var scope = app.Services.CreateScope();

var seeder = scope.ServiceProvider.GetRequiredService<FitnessGymSeeder>();

await seeder.Seed();

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
