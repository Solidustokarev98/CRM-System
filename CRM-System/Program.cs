using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CRM_System.Db;
using CRM_System.Models;
using CRM_System.Repository;
using CRM_System.Repository.Implementations;
using CRM_System.Repository.Interfaces;
using CRM_System.Services.Implementations;
using CRM_System.Services.Interfaces;
using System;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetSection("Data:EventManagementDB:ConnectionString").Value;

var connectionStringIdentity = builder.Configuration.GetSection("Data:CRMIdentity:ConnectionString").Value;

builder.Services.AddDbContext<AppIdentityContext>(options => options.UseSqlServer(connectionStringIdentity));

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityContext>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));


builder.Services.AddTransient<IManagerRepository, FakeManagerRepository>();

builder.Services.AddTransient<IManagerService, ManagerService>();

builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<IAdminService, AdminService>();

builder.Services.AddScoped(SessionCart.GetCart);
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

SeedData.EnsurePopulated(app);
await IdentitySeedData.EnsurePopulatedAsync(app);

app.UseDeveloperExceptionPage();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "null",
    pattern: "{category}/Page{page:int}",
    defaults: new { controller = "Product", action = "Index" }
);

app.MapControllerRoute(
    name: "null",
    pattern: "Page{page:int}",
    defaults: new { controller = "Manager", action = "Index", page = 1 }
);

app.MapControllerRoute(
    name: "null",
    pattern: "{category}",
    defaults: new { controller = "Manager", action = "Index", page = 1 }
);

app.MapControllerRoute(
    name: "pagination",
    pattern: "Manager/Page{page}",
    defaults: new { controller = "Manager", action = "Index" }
);

app.MapControllerRoute(
    name: "null",
    pattern: "",
    defaults: new { controller = "Manager", action = "Index", page = 1 }
);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Manager}/{action=Index}"
);

app.Run();