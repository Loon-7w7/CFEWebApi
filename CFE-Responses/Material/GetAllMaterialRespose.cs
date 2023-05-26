using CFE_Domain.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Responses.Materials
{
    /// <summary>
    /// Respuesta de una lista de materiales
    /// </summary>
    public class GetAllMaterialRespose
    {
        /// <summary>
        /// Lista de materiales
        /// </summary>
        public List<Material> materials  { get; set; }
    }
}
