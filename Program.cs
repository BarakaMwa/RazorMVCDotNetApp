using RazorMVCDotNetApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RazorMVCDotNetApp.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("RazorMVCDotNetAppContextConnection");builder.Services.AddDbContext<RazorMVCDotNetAppContext>(options =>
    options.UseMySQL(connectionString));
builder.Services.AddDefaultIdentity<RazorMVCDotNetAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<RazorMVCDotNetAppContext>();
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

//Add DbContext for Injection
builder.Services.AddDbContext<DbConnection>();

//Add Daos for Injection
/*builder.Services.AddScoped<IEmployeeDao,EmployeeDao>();
builder.Services.AddScoped<IDepartmentDao,DepartmentDao>();*/

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
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
