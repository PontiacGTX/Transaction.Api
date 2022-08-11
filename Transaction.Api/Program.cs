using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Transactions.Data;
using Transactions.Data.Entities;
using Transactions.Repository;
using Transactions.Repository.Repositorios;
using Transactions.Services.Services;
using Transactions.Tests.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped< ClienteRepositorio>();
builder.Services.AddScoped< CuentaRepositorio>();
builder.Services.AddScoped< CuentasClientesRepository>();
builder.Services.AddScoped< MovimientosRepositorio>();
builder.Services.AddScoped< PersonaRepositorio>();
builder.Services.AddScoped<TipoDeCuentasRepositorio>();
builder.Services.AddScoped<TipoMovimientosRepositorio>();
builder.Services.AddScoped<GeneroRepositorio>();
builder.Services.AddScoped<PropiedadCuentaRepositorio>();
builder.Services.AddScoped<RepositoriosUnit>();

builder.Services.AddScoped<ClienteServicio>();
builder.Services.AddScoped<CuentaServicio>();
builder.Services.AddScoped<CuentaClienteServicio>();
builder.Services.AddScoped<MovimientosServicio>();
builder.Services.AddScoped<GeneroServicio>();
builder.Services.AddScoped<TipoDeCuentaServicio>();
builder.Services.AddScoped<TipoMovimientosServicio>();
builder.Services.AddScoped<PropiedadCuentaServicio>();
builder.Services.AddScoped<ReportesServicio>();

builder.Services.AddScoped<HttpClient>();


builder.Services.AddSingleton<AppSettingsAccess>(x=>new AppSettingsAccess(Directory.GetCurrentDirectory()));
builder.Services.AddScoped<ClienteServices>();

builder.Services.AddControllers()
    .AddNewtonsoftJson(x=>x.SerializerSettings.ReferenceLoopHandling= Newtonsoft.Json.ReferenceLoopHandling.Ignore);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string sqlConnection = builder.Configuration.GetConnectionString("ConexionDB");
builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(sqlConnection));
builder.Services
    .AddIdentity<Cliente, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.User.RequireUniqueEmail = false;
    })
    .AddSignInManager()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<Cliente>>(TokenOptions.DefaultPhoneProvider);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
using var serviceScope = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
using var appDbCtx =serviceScope.ServiceProvider.GetService<AppDbContext>();

appDbCtx.Database.EnsureCreated();
//appDbCtx.Database.Migrate();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
