
using DomainLayer.Models;
using DomainLayer.Data;
using ServiceLayer.Service;

using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Repository;
using ServiceLayer.Dto;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DemoDbContext>(o=>o.UseSqlServer (builder.Configuration.GetConnectionString("DemoConnectionString"), b=>b.MigrationsAssembly("Day8")));

//Add service
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddScoped<ICustomService<StudentDto>, StudentService>();
builder.Services.AddAutoMapper(typeof(ServiceLayer.Profiles.AutoMapperProfile));



// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
