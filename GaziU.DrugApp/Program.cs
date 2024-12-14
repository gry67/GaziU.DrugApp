
using GaziU.DrugApp.BL.Abstract;
using GaziU.DrugApp.BL.Concrete;
using GaziU.DrugApp.DAL;
using GaziU.DrugApp.DAL.Models;
using GaziU.DrugApp.DAL.Repositories.Abstract;
using GaziU.DrugApp.DAL.Repositories.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace GaziU.DrugApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<AppDbContext>();

            builder.Services.AddScoped(typeof(DAL.Repositories.Abstract.IGenericManager<>), typeof(GenericRepository<>));;
            builder.Services.AddScoped(typeof(BL.Abstract.IGenericManager<>), typeof(GenericManager<>));
            builder.Services.AddScoped<IDrugRepository, DrugRepository>();
            builder.Services.AddScoped<IDrugManager, DrugManager>();
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });

            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var Issuer = jwtSettings["Issuer"];
            var Audience = jwtSettings["Audience"];
            var SecretKey = jwtSettings["SecretKey"];

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = Issuer,
                    ValidAudience = Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SecretKey))
                };

                options.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = opt =>
                    {
                        Console.WriteLine($"Authentication Failed. Error Text: {opt.Exception.Message}");
                        return Task.CompletedTask;
                    },

                    OnMessageReceived = opt =>
                    {
                        Console.WriteLine($"Token received: {opt.Request.Headers}");
                        return Task.CompletedTask;
                    }
                };
            });


            builder.Services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: 'Bearer {token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                           Reference = new OpenApiReference
                           {
                           Type = ReferenceType.SecurityScheme,
                           Id = "Bearer"
                           }
                    },
                        Array.Empty<string>()
                    }
                    
                });
            });



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();    
            app.UseAuthorization();
            app.UseCors("AllowAllOrigins"); 

            app.MapControllers();

            app.Run();
        }
    }
}
