using EY.BankApp.Web.Data.Context;
using EY.BankApp.Web.Data.Interfaces;
using EY.BankApp.Web.Data.Repositories;
using EY.BankApp.Web.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BankContext>(opt =>
{
    opt.UseSqlServer("server=localhost\\SQLEXPRESS;database=BankDb;integrated security=true;trusted_connection=true");
});
builder.Services.AddScoped<IApplicationUserRepository,ApplicationUserRepository>();
builder.Services.AddScoped<IApplicatonUserMapper,ApplicationUserMapper>();
builder.Services.AddScoped<IAccountMapper,AccountMapper>();
builder.Services.AddScoped<IAccountRepository,AccountRepository>();
builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}


app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "node_modules")),
    RequestPath = new PathString("/node_modules")
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
