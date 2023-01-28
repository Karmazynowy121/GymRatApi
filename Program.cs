using FluentValidation;
using FluentValidation.AspNetCore;
using GymRatApi;
using GymRatApi.Commands.BodyPartCommands;
using GymRatApi.Commands.ExerciseCommands;
using GymRatApi.Commands.SportCommands;
using GymRatApi.Commands.TrainingCommands;
using GymRatApi.Commands.TrainingPartCommands;
using GymRatApi.Commands.TrainingScheuldeCommands;
using GymRatApi.Commands.UserCommands;
using GymRatApi.Commands.VideoCommands;
using GymRatApi.Dto;
using GymRatApi.Entieties;
using GymRatApi.ModuleData.Dto;
using GymRatApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using static System.Net.WebRequestMethods;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
Console.WriteLine(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, builder.Configuration.GetConnectionString("DatabaseName")));
builder.Services.AddAutoMapper(cfg =>
{
    cfg.CreateMap<BodyPart, BodyPartDto>();
    cfg.CreateMap<BodyPartUpdateCommand, BodyPart>();
    cfg.CreateMap<Exercise, ExerciseDto>();
    cfg.CreateMap<ExerciseUpdateCommand, Exercise>();
    cfg.CreateMap<Sport, SportDto>();
    cfg.CreateMap<SportUpdateCommand, SportDto>();
    cfg.CreateMap<Training, TrainingDto>();
    cfg.CreateMap<TrainingUpdateCommand, Training>();
    cfg.CreateMap<TrainingPart, TrainingPartDto>();
    cfg.CreateMap<TrainingPartUpdateCommand, TrainingPart>();
    cfg.CreateMap<TrainingScheulde, TrainingScheuldeDto>();
    cfg.CreateMap<TrainingScheuldeUpdateCommand, TrainingScheulde>();
    cfg.CreateMap<User, UserDto>();
    cfg.CreateMap<UserUpdateCommand, User>();
    cfg.CreateMap<Video, VideoDto>();
    cfg.CreateMap<VideoCreateCommand, Video>();
    cfg.CreateMap<UserTrainingScheulde, UserTrainingScheuldeDto>();
    cfg.CreateMap<User,LoggedUserDto>();
});
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

    var authenticationSettings = new AuthenticationSettings();
    
    builder.Configuration.GetSection("Authentication").Bind(authenticationSettings);
    builder.Services.AddSingleton(authenticationSettings);
    builder.Services.AddAuthentication(option =>
    {
        option.DefaultAuthenticateScheme = "Bearer";
        option.DefaultScheme = "Bearer";
        option.DefaultChallengeScheme = "Bearer";
    }).AddJwtBearer(cfg =>
    {
        cfg.RequireHttpsMetadata = false;
        cfg.SaveToken = true;
        cfg.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = authenticationSettings.JwtIssuer,
            ValidAudience = authenticationSettings.JwtIssuer,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(authenticationSettings.JwtKey)),
        };
    });



builder.Services.AddControllers().AddFluentValidation();
builder.Services.AddScoped<IUserServices,UserServices>();
builder.Services.AddScoped<IPasswordHasher<User>, PasswordHasher<User>>();
builder.Services.AddScoped<IValidator<UserCreateCommand>, UserCreateCommandValidator>(); 
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
app.UseAuthentication();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
