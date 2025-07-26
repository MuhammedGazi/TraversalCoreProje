using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;
using OfficeOpenXml;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Serilog yap�land�rmas�
Log.Logger = new LoggerConfiguration()
     .MinimumLevel.Information()
    .WriteTo.File(
        path: "Logs/logs.txt",               // Log dosyas�n�n yolu
        rollingInterval: RollingInterval.Day, // Her g�n yeni bir log dosyas� olu�tur
        outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level:u3}] {Message:lj}{NewLine}{Exception}"
    )
    .CreateLogger();

// Serilog'u default logging provider olarak ekle
builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddControllersWithViews(config =>
{
    var policy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddDbContext<Context>();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<Context>();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;              // Rakam zorunlu de�il
    options.Password.RequireLowercase = false;          // K���k harf zorunlu de�il
    options.Password.RequireUppercase = false;          // B�y�k harf zorunlu de�il (buray� false yapt�k)
    options.Password.RequireNonAlphanumeric = false;    // �zel karakter zorunlu de�il
    options.Password.RequiredLength = 1;                // Minimum uzunluk
});

builder.Services.ContainerDependencies();
builder.Services.AddLogging(x =>
{
    x.ClearProviders();
    x.SetMinimumLevel(LogLevel.Debug);
    x.AddDebug();
});

//builder.Services.AddAutoMapper(typeof(Startup));  eski y�ntemi bu alta yenisi
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddTransient<IValidator<AnnouncementAddDTO>, AnnouncementValidator>();  extensiona g�t�rd�m a�a��da ca��rd�m
builder.Services.CustomValidator();

builder.Services.AddControllersWithViews();

//builder.Services.AddMvc(config =>
//{
//    var policy = new AuthorizationPolicyBuilder()
//    .RequireAuthenticatedUser()
//    .Build();
//    config.Filters.Add(new AuthorizeFilter(policy));
//});
//builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error404","?code={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    //pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
