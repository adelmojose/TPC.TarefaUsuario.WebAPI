using Microsoft.EntityFrameworkCore;
using TPC.TarefaUsuario.API.Core.Data;
using TPC.TarefaUsuario.API.Core.Repositories;
using TPC.TarefaUsuario.API.Core.Repositories.Interface;
using TPC.TarefaUsuario.API.Core.Services;
using TPC.TarefaUsuario.API.Core.Services.Interface;
using TPC.TarefaUsuario.API.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers().AddJsonOptions(x =>
{
    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


#region registro das classes service / repository 

builder.Services.AddTransient<IUsuarioService, UsuarioService>();
builder.Services.AddTransient<ITarefaService, TarefaService>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();

#endregion

IConfiguration configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
var conexao = configuration.GetConnectionString("TarefaCadastro");
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(conexao));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.ConfigureExceptionHandler();

app.UseHttpsRedirection();




app.UseAuthorization();

app.MapControllers();

app.Run();
