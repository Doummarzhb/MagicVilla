//using Serilog;

//using MagicVilla_VillaAPI.Logging;

using MagicVilla_VillaAPI;
using MagicVilla_VillaAPI.Data;
using MagicVilla_VillaAPI.Repository;
using MagicVilla_VillaAPI.Repository.IRepository;
using MagicVilla_Web;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//Log.Logger = new LoggerConfiguration().MinimumLevel.Debug().WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger() ;


//builder.Host.UseSerilog();
builder.Services.AddDbContext<ApplicationDbContext>(option => { 
	option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQlConnection"));
});
builder.Services.AddScoped<IVillaRepository,VillaRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IHttpContextAccessor,HttpContextAccessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddAutoMapper(typeof(MagicVilla_VillaAPI.MappingConfig));
builder.Services.AddControllers(option => { 
//option.ReturnHttpNotAcceptable=true);
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
 // builder.Services.AddSingleton<ILogging , LoggingV2>();

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
