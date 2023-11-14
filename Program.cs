using Allup_Template.DataAccessLayer;
using Allup_Template.Interfaces;
using Allup_Template.Services;
using Microsoft.EntityFrameworkCore;
using System;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("default"));
});
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ILayoutService, LayoutService>();
var app = builder.Build();
app.UseStaticFiles();
app.MapControllerRoute(
    name:"default", 
    pattern:"{controller=Home}/{action=Index}/{id?}");
app.Run();


