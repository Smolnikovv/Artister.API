using Artister.API.Configs;
using Artister.API.Services;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DatabaseContext>
    (options => options.UseSqlServer(builder.Configuration.GetConnectionString("DatabaseConnection")));
builder.Services.AddScoped<DatabaseSeeder>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IArtistService, ArtistService>();
builder.Services.AddScoped<ISubgenreService, SubgenreService>();
builder.Services.AddScoped<INotificationService, NotificationService>();
var policyName = "Allow all";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName, policy =>
    {
        policy.AllowAnyOrigin().AllowAnyHeader();
    });
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetService<DatabaseSeeder>();
seeder.Seed();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
