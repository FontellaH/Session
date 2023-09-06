var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();  // They fit nicely right after AddControllerWithViews()  AddHttpContextAccessor gives our views direct access to session Add these two lines before calling the builder.Build() method
builder.Services.AddSession();  

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();  // add this line before calling the app.MapControllerRoute() method   // It fits nicely with other Use statements like app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
