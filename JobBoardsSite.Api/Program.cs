using JobBoardsSite.Api.Extensions;
using JobBoardsSite.Api.Middleware;
using JobBoardsSite.Shared.Models;
using Microsoft.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureAppServices(builder.Configuration);
builder.Services.ConfigureIdentityServices(builder.Configuration);
builder.Services.AddControllers();
builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("ApiSettings:JwtOptions"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowSpecificOrigin",
		builder => builder
			.WithOrigins("https://localhost:7115")
			.AllowAnyMethod()
			.AllowAnyHeader()
			.AllowCredentials());
});
var app = builder.Build();

//Add-Migration NewMigration2 -Context ApplicationDbContext
//Add-Migration NewMigration2 -Context AppIdentityDbContext

//Update-Database -Context ApplicationDbContext
//Update-Database -Context AppIdentityDbContext

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
/*
app.UseCors(policy =>
policy.WithOrigins("https://localhost:7115", "http://localhost:7115").AllowAnyMethod().WithHeaders(HeaderNames.ContentType));
*/
app.UseCors(u => u.AllowAnyHeader().AllowAnyMethod()
.AllowCredentials()
.WithOrigins("https://localhost:7115", "http://localhost:7115"));

app.UseMiddleware<ErrorMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
