using GymRatApi.Entieties;
using GymRatApi.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, builder.Configuration.GetConnectionString("DatabaseName")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GymDbContext>(o =>
{
    o.UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory,builder.Configuration.GetConnectionString("DatabaseName"))}");
});


builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IExerciseServices,ExerciseServices>();



var app = builder.Build();

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
