using CFE_Domain.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Repositorios
{
    /// <summary>
    /// Repository de la cantidad de los materiales
    /// </summary>
    public interface IAmoutMatrialRepository
    {
        /// <summary>
        /// Optiene una lista de cantidad de materiales dependiendo del dispositivo
        /// </summary>
        /// <param name="deviceId">id del dispositivo</param>
        /// <returns></returns>
        Task<List<AmountMaterial>> getall(Guid deviceId);
    }
}
