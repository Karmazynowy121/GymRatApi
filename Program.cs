using GymRatApi.Entieties;
using GymRatApi.Services;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, builder.Configuration.GetConnectionString("DatabaseName")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddNewtonsoftJson(options => {
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GymDbContext>(o =>
{
    o.UseSqlite($"Data Source={Path.Combine(AppDomain.CurrentDomain.BaseDirectory,builder.Configuration.GetConnectionString("DatabaseName"))}");
});


builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IExerciseServices,ExerciseServices>();
builder.Services.AddScoped<IVideoServices,VideoServices>();
builder.Services.AddScoped<IBodyPartService, BodyPartService>();
builder.Services.AddScoped<ISportServices, SportServices>();
builder.Services.AddScoped<ITrainingPartServices, TrainingPartService>();
builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingScheuldeService, TrainingScheuldeService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI(ui => {
        ui.DefaultModelRendering(Swashbuckle.AspNetCore.SwaggerUI.ModelRendering.Model);
        ui.DefaultModelExpandDepth(1);
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
