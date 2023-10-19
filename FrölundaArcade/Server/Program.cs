using FrölundaArcade.Server.Data;
using FrölundaArcade.Server.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
await builder.Services.AddDbAsync(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddAuth();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IGamesReadService, GamesReadService>();
builder.Services.AddScoped<IReviewsWriteService, ReviewsWriteService>();
builder.Services.AddScoped<ICartWriteService, CartWriteService>();
builder.Services.AddScoped<ICartReadService, CartReadService>();
builder.Services.AddScoped<ICategoriesReadService, CategoriesReadService>();
builder.Services.AddScoped<IGamesWriteService, GamesWriteService>();
builder.Services.AddScoped<IUsersReadService, UsersReadService>();
builder.Services.AddScoped<IUsersWriteService, UsersWriteService>();
builder.Services.AddScoped<IOrdersWriteService, OrdersWriteService>();
builder.Services.AddScoped<IOrdersReadService, OrdersReadService>();

var app = builder.Build();

using var scope = app.Services.CreateScope();
var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
await SeedData.SeedDatabase(db, userManager, roleManager);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
