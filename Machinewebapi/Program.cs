

using AutoMapper;
using Machinewebapi;
using Machinewebapi.DAOImp;
using Machinewebapi.EfCore;
using Machinewebapi.Hubs;
using Machinewebapi.IDAO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<LaverieAppDbContext>(x => { x.UseSqlServer(connectionString); });
builder.Services.AddSignalR();

builder.Services.AddScoped<IDAOLaverie, DAOImpLaverie>();
builder.Services.AddScoped<IDAOMachine, DAOImpMachine>();
/*builder.Services.AddAutoMapper(typeof(Startup));*/

var mapperconfig = new MapperConfiguration(cfg =>
  {
      cfg.AddProfile(new AutoMapperProfile());
  }
);
var mapper = mapperconfig.CreateMapper();
builder.Services.AddSingleton(mapper);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var key = "kygmtest12345678";

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});
builder.Services.AddSingleton<JwtAuthenticationManager>(new JwtAuthenticationManager(key));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<DataHub>("datahub");
});
/*app.MapHub<DataHub>("datahub");*/

app.Run();
