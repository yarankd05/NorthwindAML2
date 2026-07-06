using Microsoft.EntityFrameworkCore;
using NorthwindAML.Application.Services;
using NorthwindAML.Domain.Interfaces;
using NorthwindAML.Infrastructure.Data;
using NorthwindAML.Infrastructure.Repositories;
using NorthwindAML.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindConnection")));

// repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IWatchlistRepository, WatchlistRepository>();
builder.Services.AddScoped<ITransactionFlagRepository, TransactionFlagRepository>();
builder.Services.AddScoped<ICustomerRiskScoreRepository, CustomerRiskScoreRepository>();
builder.Services.AddScoped<ISARRepository, SARRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// services
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAuthService, NorthwindAML.Infrastructure.Services.AuthService>();
builder.Services.AddScoped<ISARService, SARService>();
builder.Services.AddScoped<IRiskScoreService, RiskScoreService>();

// authentication
builder.Services.AddAuthentication("Cookies")
    .AddCookie("Cookies", options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
    });

builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();