using CarRentalSystem.Business.Mappings;
using CarRentalSystem.Business.Profiles;
using CarRentalSystem.Business.Services.Abstract;
using CarRentalSystem.Business.Services.Concrete;
using CarRentalSystem.DataAccess.Concrete;
using CarRentalSystem.DataAccess.Contexts;
using CarRentalSystem.DataAccess.Interfaces;
using CarRentalSystem.Entity.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CarRentalDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ICarRepository,CarRepository>();
builder.Services.AddScoped<ICompanyRepository,CompanyRepository>();
builder.Services.AddScoped<IRentalRepository,RentalRepository>();
builder.Services.AddScoped<ICarImageRepository,CarImageRepository>();
builder.Services.AddScoped<ICommentRepository,CommentRepository>();





builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(CarProfile).Assembly);
builder.Services.AddAutoMapper(typeof(RentalProfile).Assembly);
builder.Services.AddAutoMapper(typeof(PaymentProfile).Assembly);
builder.Services.AddAutoMapper(typeof(CarImageProfile).Assembly);


builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<IEmailService, EmailService>();


builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Auth/Login";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.ExpireTimeSpan = TimeSpan.FromDays(7);
        options.SlidingExpiration = true;
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Strict;

    });
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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
