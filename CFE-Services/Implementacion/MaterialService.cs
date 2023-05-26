using CFE_Domain.Material;
using CFE_Services.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Implementacion
{
    /// <summary>
    /// Servio de materiales
    /// </summary>
    public class MaterialService : IMaterialRepository
    {
        /// <summary>
        /// Repositorio de materiales
        /// </summary>
        private readonly IRepository<Material> _materialRepository;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="materialRepository"></param>
        public MaterialService(IRepository<Material> materialRepository)
        {
            _materialRepository = materialRepository;
        }
        /// <summary>
        /// Crea un material
        /// </summary>
        /// <param name="material">Datos del material</param>
        /// <returns></returns>
        public Task Add(Material material)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Elimina un material
        /// </summary>
        /// <param name="id">id del material</param>
        /// <returns></returns>
        public Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// obtiene una lista de materiales
        /// </summary>
        /// <returns></returns>
        public Task<List<Material>> GetAll()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Busxas por id del material
        /// </summary>
        /// <param name="id">id del material</param>
        /// <returns></returns>
        public Task<Material> GetById(Guid id)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Actuliza el material
        /// </summary>
        /// <param name="material">Material Actualizado</param>
        /// <returns></returns>
        public Task Update(Material material)
        {
            throw new NotImplementedException();
        }
    }
}
