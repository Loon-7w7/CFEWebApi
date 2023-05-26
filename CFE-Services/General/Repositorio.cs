using CFE_DataBase;
using CFE_Services.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.General
{
    /// <summary>
    /// Funciones generales de entity framework
    /// </summary>
    /// <typeparam name="TEntity">el tipo en entidad</typeparam>
    public class Repositorio<TEntity>: IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// contexto de la base de datos
        /// </summary>
        private readonly CFEDataBaseContext _context;
        /// <summary>
        /// tabla de la base de datos
        /// </summary>
        private readonly DbSet<TEntity> _dbset;
        /// <summary>
        /// constuctor con el contexto
        /// </summary>
        /// <param name="context">contexto de la base de datos</param>
        public Repositorio(CFEDataBaseContext context) 
        {
            _context = context;
            _dbset = context.Set<TEntity>();
        }
        /// <summary>
        /// Crea un nuevo dato de la entidad
        /// </summary>
        /// <param name="entity">datos de la entidad</param>
        /// <returns></returns>
        public async Task Add(TEntity entity) 
        {
            _dbset.Add(entity);
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// obtine una lista de las entidad
        /// </summary>
        /// <returns>una lista de entidades</returns>
        public async Task<List<TEntity>> AllGet() 
        {
            return await _dbset.ToListAsync();
        }
        /// <summary>
        /// Obtine una entidad por su id
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns>una entidad</returns>
        public async Task<TEntity?> GetId(Guid id) 
        {

            return await _dbset.FindAsync(id);
        }
        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="id">id de la entidad</param>
        /// <returns></returns>
        public async Task Delete(Guid id) 
        {
            TEntity? entidad = await _dbset.FindAsync(id);
            if (entidad != null)
            {
                _dbset.Remove(entidad);
                await _context.SaveChangesAsync();
            }
        }
        /// <summary>
        /// actuliza los todos de la entidad
        /// </summary>
        /// <param name="entity">datos de la entidad</param>
        /// <returns></returns>
        public async Task Update(TEntity entity) 
        {
            _dbset.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// Busca dependiendo de la exprecion que se pase
        /// </summary>
        /// <param name="expresion">Esprecion de bsuqueda</param>
        /// <returns></returns>
        public async Task<List<TEntity>> SearchWhere(Expression<Func<TEntity, bool>> expresion) 
        {
            return await _dbset.Where(expresion).ToListAsync();
        }
        /// <summary>
        /// Busca una entidad dependiendo de la exprecion que se pase
        /// </summary>
        /// <param name="expresion">Esprecion de bsuqueda</param>
        /// <returns></returns>
        public async Task<TEntity> SearchFirst(Expression<Func<TEntity, bool>> expresion)
        {
            
            return await _dbset.FirstAsync(expresion);
        }
    }
}
