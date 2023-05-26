using CFE_Domain.Material;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Database
{
    /// <summary>
    /// Clase de conexion a la base de datos
    /// </summary>
    public class CFEDataBaseContext : DbContext
    {
        /// <summary>
        /// Datos de los Materiales
        /// </summary>
        public DbSet<Material> Materials { get; set; }
        /// <summary>
        /// Contructor que resive la configuracion
        /// </summary>
        /// <param name="options">opcines de conexcion</param>
        public CFEDataBaseContext(DbContextOptions<CFEDataBaseContext> options): base(options) 
        {
        }
        /// <summary>
        /// contructor para llamar
        /// </summary>
        public CFEDataBaseContext() 
        {
        }
        /// <summary>
        /// Inicializador de las configuraciones y el controlador de errores
        /// </summary>
        /// <param name="optionsBuilder">Confiraciones de la conexcion</param>
        /// <exception cref="Exception">menciona la configuracion erronea de la base de datos</exception>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                throw new Exception("No se configuro la conexcion a la base de datos");
            }
        }
        /// <summary>
        /// creador de las tablas de la base de datos
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Material>();
        }
    }
}
