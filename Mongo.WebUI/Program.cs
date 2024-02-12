using Microsoft.EntityFrameworkCore;
using Mongo.WebUI.Context;
using Mongo.WebUI.DAL.Services;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped(typeof(IRepository<>),typeof(GenericRepository<>));
var mongoDatabase = new MongoClient("mongodb://localhost:27017").GetDatabase("MongoEFCore");


builder.Services.AddDbContext<MongoContext>(opt =>
{
    opt.UseMongoDB(mongoDatabase.Client, mongoDatabase.DatabaseNamespace.DatabaseName);
});
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
