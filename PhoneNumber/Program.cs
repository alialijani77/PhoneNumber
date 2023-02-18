using Microsoft.EntityFrameworkCore;
using PhoneNumber.DataLayer.Context;
using PhoneNumber.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
#region DbContext
builder.Services.AddDbContext<PhoneNumberDbContext>(options => options.
UseSqlServer(builder.Configuration.GetConnectionString("PhoneNumberDbContext")));
#endregion

#region RegisterDependencies
DependencyContainer.RegisterDependencies(builder.Services);
#endregion


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
