using GerenteDeSenhas.Data;
using GerenteDeSenhas.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<UserDbContext>(opts =>
    opts.UseMySql(
        builder.Configuration.GetConnectionString("UserDbConnection"),
        new MySqlServerVersion(new Version(8, 0))));

builder.Services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(
    opt => opt.SignIn.RequireConfirmedEmail = true
    )
    .AddEntityFrameworkStores<UserDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<CadastroService, CadastroService>();
builder.Services.AddScoped<LoginService, LoginService>();
builder.Services.AddScoped<LogoutService, LogoutService>();
builder.Services.AddScoped<TokenService, TokenService>();
builder.Services.AddScoped<EmailService, EmailService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddUserSecrets<Program>();

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
