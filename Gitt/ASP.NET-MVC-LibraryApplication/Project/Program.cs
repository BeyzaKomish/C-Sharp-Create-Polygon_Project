using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Project.Data;
using Project.Data.SeedData;
using Project.Models;

var builder = WebApplication.CreateBuilder(args);

var connectString = builder.Configuration.GetConnectionString("DefaultConnection");


// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<LibraryDbContext>(

      options => options.UseSqlite(connectString)

    );

builder.Services.AddIdentity<User, IdentityRole>(
    options =>
    {
        options.Password.RequiredUniqueChars = 0;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequiredLength = 8;
        options.Password.RequireNonAlphanumeric = false;    
    })
    .AddEntityFrameworkStores<LibraryDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    
    var serviceProvider = scope.ServiceProvider;
    var dbContext = serviceProvider.GetRequiredService<LibraryDbContext>(); 
    await dbContext.Database.MigrateAsync();    


    var roleManager = serviceProvider.GetRequiredService <RoleManager<IdentityRole>> ();
    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
    await UserSeedData.Initialize(serviceProvider, userManager ,roleManager);
}

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
