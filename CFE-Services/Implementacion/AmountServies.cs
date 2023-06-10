using CFE_Domain.Material;
using CFE_Services.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Services.Implementacion
{
    public class AmountServies : IAmoutMatrialRepository
    {
        /// <summary>
        /// Repositorio de las cantidadess
        /// </summary>
        private readonly IRepository<AmountMaterial> _AmountRepository;
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="DevicesRepository"></param>
        public AmountServies(IRepository<AmountMaterial> AmountRepository) 
        {
            _AmountRepository = AmountRepository;
        }
        /// <summary>
        /// Optiene una lista de cantidad de materiales dependiendo del dispositivo
        /// </summary>
        /// <param name="deviceId">id del dispositivo</param>
        /// <returns></returns>
        public async Task<List<AmountMaterial>> getall(Guid deviceId)
        {
            List<AmountMaterial> amounts = new List<AmountMaterial>();
            amounts = await _AmountRepository.SearchWhere(expresion:(p => p.DevicesId == deviceId),(x => x.material));
            return amounts;
            
        }
    }
}
