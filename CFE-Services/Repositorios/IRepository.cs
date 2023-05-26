using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Repositorios
{
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Crea un nuevo dato de la entidad
        /// </summary>
        /// <param name="entity">datos de la entidad</param>
        /// <returns></returns>
        Task Add(TEntity entity);
        /// <summary>
        /// obtine una lista de las entidad
        /// </summary>
        /// <returns>una lista de entidades</returns>
        Task<List<TEntity>> AllGet();
        /// <summary>
        /// Obtine una entidad por su id
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns>una entidad</returns>
        Task<TEntity?> GetId(Guid id);
        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="id">id de la entidad</param>
        /// <returns></returns>
        Task Delete(Guid id);
        /// <summary>
        /// actuliza los todos de la entidad
        /// </summary>
        /// <param name="entity">datos de la entidad</param>
        /// <returns></returns>
        Task Update(TEntity entity);
        /// <summary>
        /// Busca una lista dependiendo de la exprecion que se pase
        /// </summary>
        /// <param name="expresion">Esprecion de bsuqueda</param>
        /// <returns></returns>
        Task<List<TEntity>> SearchWhere(Expression<Func<TEntity, bool>> expresion);
        /// <summary>
        /// Busca una entidad dependiendo de la exprecion que se pase
        /// </summary>
        /// <param name="expresion">Esprecion de bsuqueda</param>
        /// <returns></returns>
        Task<TEntity> SearchFirst(Expression<Func<TEntity, bool>> expresion);
    }
}
