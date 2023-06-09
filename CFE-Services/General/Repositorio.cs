﻿using CFE_DataBase;
using CFE_Services.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace CFE_Services.General
{
    /// <summary>
    /// Funciones generales de entity framework
    /// </summary>
    /// <typeparam name="TEntity">el tipo en entidad</typeparam>
    public class Repositorio<TEntity>: IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Tipo de la entidad
        /// </summary>
        Type entityType = typeof(TEntity);
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
        public async Task<bool> Add(TEntity entity) 
        {
            try 
            {
                _dbset.Add(entity);
                await _context.SaveChangesAsync();
                return true;
            } 
            catch (Exception ex) 
            {
                return false;
            }
            
        }
        /// <summary>
        /// obtine una lista de las entidad
        /// </summary>
        /// <returns>una lista de entidades</returns>
        public async Task<List<TEntity>> AllGet(params Expression<Func<TEntity, object>>[] includes) 
        {
            IQueryable<TEntity> entities = _dbset;
            if (includes != null) 
            {
                entities = includes.Aggregate(entities, (current, include) => current.Include(include));
            }
            List<TEntity> Response = await entities.ToListAsync();
            if(Response.Count == 0) 
            {
                return new List<TEntity>();
            }
            else 
            {
                return Response;
            }
            
        }
        /// <summary>
        /// Obtine una entidad por su id
        /// </summary>
        /// <param name="id">Identificador de la entidad</param>
        /// <returns>una entidad</returns>
        public async Task<TEntity?> GetId(Guid id) 
        {
            TEntity? entity = await _dbset.FindAsync(id);
                return entity; 
        }
        /// <summary>
        /// Elimina una entidad
        /// </summary>
        /// <param name="id">id de la entidad</param>
        /// <returns></returns>
        public async Task<bool> Delete(Guid id) 
        {
            try
            {
                TEntity? entidad = await _dbset.FindAsync(id);
                if (entidad != null)
                {
                    _dbset.Remove(entidad);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// actuliza los todos de la entidad
        /// </summary>
        /// <param name="entity">datos de la entidad</param>
        /// <returns></returns>
        public async Task<bool> Update(TEntity entity) 
        {
            try
            {
                _dbset.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// Busca dependiendo de la exprecion que se pase
        /// </summary>
        /// <param name="expresion">Esprecion de busqueda</param>
        /// <returns></returns>
        public async Task<List<TEntity>> SearchWhere(Expression<Func<TEntity, bool>> expresion, params Expression<Func<TEntity, object>>[] includes) 
        {
            IQueryable<TEntity> entities = _dbset;
            if (includes != null)
            {
                entities = includes.Aggregate(entities, (current, include) => current.Include(include));
            }
            List<TEntity> Response = await entities.Where(expresion).ToListAsync();
            if (Response.Count == 0)
            {
                return new List<TEntity>();
            }
            else
            {
                return Response;
            }
        }
        /// <summary>
        /// Busca una entidad dependiendo de la exprecion que se pase
        /// </summary>
        /// <param name="expresion">Esprecion de bsuqueda</param>
        /// <returns></returns>
        public async Task<TEntity?> SearchFirst(Expression<Func<TEntity, bool>> expresion, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> entities = _dbset;
            if (includes != null)
            {
                entities = includes.Aggregate(entities, (current, include) => current.Include(include));
            }
            TEntity? entity = await entities.FirstOrDefaultAsync(expresion);
                return entity;

        }
        /// <summary>
        /// crea multiples entidades
        /// </summary>
        /// <param name="entities">lista de entidades</param>
        /// <returns></returns>
        public async Task<bool> MultiAdd(List<TEntity> entities)
        {
            try 
            {
                await _dbset.AddRangeAsync(entities);
                await _context.SaveChangesAsync();
                return true;
            }catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
