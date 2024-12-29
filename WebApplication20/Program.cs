using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using WebApplication20.Data;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DocumentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DocumentContext") ?? throw new InvalidOperationException("Connection string 'DocumentContext' not found.")));
builder.Services.AddDbContext<FeedBackContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("FeedBackContext") ?? throw new InvalidOperationException("Connection string 'FeedBackContext' not found.")));
builder.Services.AddDbContext<ConditionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ConditionContext") ?? throw new InvalidOperationException("Connection string 'ConditionContext' not found.")));
builder.Services.AddDbContext<PaymentContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("PaymentContext") ?? throw new InvalidOperationException("Connection string 'PaymentContext' not found.")));

// Add DbContext for RoomConditionContext
builder.Services.AddDbContext<RoomConditionContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RoomConditionContext") ?? throw new InvalidOperationException("Connection string 'RoomConditionContext' not found.")));

// Add DbContext for BookingContext
builder.Services.AddDbContext<BookingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookingContext") ?? throw new InvalidOperationException("Connection string 'BookingContext' not found.")));

// Add ApplicationDbContext for Identity
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Identity services
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Add controllers and views
builder.Services.AddControllersWithViews();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
