using CFE_DataBase;
using CFE_Services.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using APiCFE.Middleware;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(c =>
        {
            // Configuraciones de Swagger

            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Authorization header using the Bearer scheme",
                Type = SecuritySchemeType.Http,
                Scheme = "bearer"
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
            new string[] {}
        }
    });
        });
        // Conexion a la base de datos
        builder.Services.AddDbContext<CFEDataBaseContext>
            (
                opntion => opntion.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")),
                mysqlOptions => { mysqlOptions.CommandTimeout(100); }) 
            );
        // inyeccion de servicios
        foreach( var service in RegisteredServices.Services()) 
        {
            builder.Services.AddScoped(service.Irepositorio, service.repositorio);
        }
        //Token
        IConfigurationSection jwtSettings = builder.Configuration.GetSection("Jwt");
        string secretKey = jwtSettings.GetValue<string>("SecretKey");
        builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer
            (
                options => options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters() 
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetValue<string>("Issuer"),
                    ValidAudience = jwtSettings.GetValue<string>("Audience"),
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey))
                }
            );
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }
        //middlewares
        app.UseMiddleware<ErrorHandlingMiddleware>();
        //Migraciones
        using (var Scope = app.Services.CreateScope())
        {
            var application = Scope.ServiceProvider.GetRequiredService<CFEDataBaseContext>();
            application.Database.Migrate();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}