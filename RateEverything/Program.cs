using RateEverything.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using RateEverything.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var databaseConnection = builder.Configuration["Database:ConnectionString"];

// Add services to the container.
builder.Services.AddDbContext<RateEverythingContext>(options =>
    options.UseSqlServer(databaseConnection));

builder.Services.AddDefaultIdentity<RateEverythingUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<RateEverythingContext>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter(); 
// Add services to the container.
builder.Services.AddControllersWithViews();

//Allow session access in views
//builder.Services.AddSingleton<HttpContextAccessor, HttpContextAccessor>();
builder.Services.AddHttpContextAccessor();

//Add Session
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
