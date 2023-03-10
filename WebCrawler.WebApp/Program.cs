using Microsoft.EntityFrameworkCore;
using WebCrawlerDataBase;
using WebCrawlerLogic;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CrawlerContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("CrawlerDB"))
        );

builder.Services.AddScoped();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Crawler/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Crawler}/{action=Index}/{id?}");

app.Run();
