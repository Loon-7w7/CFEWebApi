using CFE_DataBase;
using CFE_Services.General;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        // Conexion a la base de datos
        builder.Services.AddDbContext<CFEDataBaseContext>
            (
                opntion => opntion.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DefaultConnection")),
                mysqlOptions => { mysqlOptions.CommandTimeout(60); }) 
            );
        // inyeccion de servicios
        foreach( var service in RegisteredServices.Services()) 
        {
            builder.Services.AddScoped(service.Irepositorio, service.repositorio);
        }
        var app = builder.Build();


        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        //Migraciones
        using (var Scope = app.Services.CreateScope())
        {
            var application = Scope.ServiceProvider.GetRequiredService<CFEDataBaseContext>();
            application.Database.Migrate();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}