using Microsoft.EntityFrameworkCore;
using UExample.Core;
using UExample.DataLayer;

var builder = WebApplication.CreateBuilder(args);

//Add services to the container.
builder.Services.AddControllersWithViews();

//****Add repositories here.
builder.Services.AddTransient<IUser, UserServices>();

//Add DbContext ctor.
#region DBContext

builder.Services.AddDbContext<UExampleContext>(p =>
{
    p.UseSqlServer(builder.Configuration.GetConnectionString("UExampleString"));
});

#endregion


//App development.
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    //This HSTS value is 30 days.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );
    

app.Run();