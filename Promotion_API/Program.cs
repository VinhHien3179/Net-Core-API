using Promotion.Application.Interfaces;
using Promotion.Application.Services;
using Promotion_API;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.IO.Compression;
using System.Text;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using static Dapper.SqlMapper;
using Promotion.Model.Model;
using Promotion.Model.Model.Comon;
using Twilio.Jwt.AccessToken;
using Pos.Model.Model.Auth;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

ConfigurationManager configuration = builder.Configuration;
builder.Services.AddControllers().AddNewtonsoftJson(
                        opt =>
                        {
                            opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                        }
                    );

builder.Services.AddCors(policyBuilder =>
    policyBuilder.AddDefaultPolicy(policy =>
        policy.WithOrigins("*").AllowAnyHeader().AllowAnyHeader())
);

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1_06_10_2023"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


builder.Services.AddScoped<ILoginService, LoginService>();


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["Jwt:Issuer"],
            ValidAudience = configuration["Jwt:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
        };
    });
builder.Services.Configure<GzipCompressionProviderOptions>(options =>
{
    options.Level = CompressionLevel.Fastest;
});
builder.Services.AddResponseCompression(options =>
{
    options.Providers.Add<GzipCompressionProvider>();
    options.EnableForHttps = true;
    options.MimeTypes =
                ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "image/svg+xml" });
});


var app = builder.Build();
app.UseResponseCompression();
app.UseCors();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
//var dashboardOptions = new DashboardOptions { IgnoreAntiforgeryToken = true };

//dashboardOptions.Authorization = new[] { new DashboardNoAuthorizationFilter() };

//app.UseHangfireDashboard("/hangfire", dashboardOptions);

//app.UseAuthorization();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
//app.UseStaticFiles();
//app.UseC(Directory.GetCurrentDirectory());
AuthData.Configure(configuration.GetSection("Jwt"));
Const.POS_CONNECTION_STRING = configuration.GetConnectionString("POSContext");

app.Run();
