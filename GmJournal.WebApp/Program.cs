using GmJournal.Data.Configuration;
using GmJournal.Logic.Services.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add GmJournalDbContext to the services and configure it.
builder.Services.AddDbContext<GmJournalDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add UserAccessService
builder.Services.AddSingleton<IUserAccessService, UserAccessService>();

// Building app
var app = builder.Build();

// Get the IServiceScopeFactory from the app service.
var scopeFactory = app.Services.GetService<IServiceScopeFactory>();

// Create a scope using the scopeFactory.
if (scopeFactory != null)
    using (var scope = scopeFactory.CreateScope())
    {
        // Get the GmJournalDbContext from the scope.
        var _GmJournalDbContext = scope.ServiceProvider.GetService<GmJournalDbContext>();
        
        if (_GmJournalDbContext != null)
            // Ensure the database is created.
            _GmJournalDbContext.Database.EnsureCreated();
    }

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
