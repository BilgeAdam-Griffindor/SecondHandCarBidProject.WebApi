using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SecondHandCarBidProject.Business.Extensions;
using SecondHandCarBidProject.Business.Middlewares;
using System.Text;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddServices(builder.Configuration);


string key = builder.Configuration.GetSection("JwtToken:SecurityKey").Value;
byte[] keyValue = Encoding.UTF8.GetBytes(key);
//jwt configurations
builder.Services.AddAuthentication(auth =>
{
    auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    jwt.RequireHttpsMetadata = true;
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        IssuerSigningKey = new SymmetricSecurityKey(keyValue),
        ValidateIssuer = false,
        ValidateAudience = false,
        LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseMiddleware<UserActionLogMiddleware>();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
