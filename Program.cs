using DSS_Assignment_Ebube.Repository;
using DSS_Assignment_Ebube.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ITeam, TeamRepository>();
builder.Services.AddTransient<IPlayer, PlayerRepository>();
builder.Services.AddTransient<IPlayer_League, Player_LeagueRepository>();
builder.Services.AddTransient<ILeague, LeagueRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
