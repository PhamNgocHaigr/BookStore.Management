using BookStore.Management.DataAccess;
using BookStore.Management.DataAccess.Data;
using BookStore.Management.Infrastructure.Configuration;
using BookStore.Management.UI.Ultility;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var builderRazor = builder.Services.AddRazorPages();

// Add services to the container.
// xsmtpsib-1b2f1a661e9531a9f69e7ad40ff98e76ec08de8c6658fde0c66fc3358ba1510c-GV58S4QE29sTr3AP
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.ConfigureIdentity(builder.Configuration);
builder.Services.AddDependencyInjection();
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new CommonDataActionFiler());
});
builder.Services.AddAutoMapper();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(1);
});

var app = builder.Build();
app.AutoMigration().GetAwaiter().GetResult();
app.SeedData(builder.Configuration).GetAwaiter().GetResult();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    builderRazor.AddRazorRuntimeCompilation();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
var timeOutCacheStaticFiles = 60 * 60;
app.UseStaticFiles(new StaticFileOptions
{
    OnPrepareResponse = cg =>
    {
        cg.Context.Response.Headers.Append("Cache-Control", $"public, max-age={timeOutCacheStaticFiles}");
    },
    //RequestPath = "/StaticFile-User"
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapAreaControllerRoute(
    name: "AdminRouting",
    areaName: "Admin",
    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
