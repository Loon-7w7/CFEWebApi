using CFE_Domain.Material;
using CFE_Requets.Material;
using CFE_Responses.Materials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Repositorios
{
    /// <summary>
    /// Repositorio de materiales
    /// </summary>
    public interface IMaterialRepository
    {
        /// <summary>
        /// Busxas por id del material
        /// </summary>
        /// <param name="id">id del material</param>
        /// <returns></returns>
        Task<GetMaterialByIDResponse> GetById(GetMaterialByIDRequest request);
        /// <summary>
        /// obtiene una lista de materiales
        /// </summary>
        /// <returns></returns>
        Task<GetAllMaterialRespose> GetAll();
        /// <summary>
        /// Crea un material
        /// </summary>
        /// <param name="material">Datos del material</param>
        /// <returns></returns>
        Task Add(CreateMaterialRequest request);
        /// <summary>
        /// Actuliza el material
        /// </summary>
        /// <param name="material">Material Actualizado</param>
        /// <returns></returns>
        Task Update(UpdateMaterialRequest request);
        /// <summary>
        /// Elimina un material
        /// </summary>
        /// <param name="id">id del material</param>
        /// <returns></returns>
        Task Delete(DeleteMaterialRequest request);
    }
}
