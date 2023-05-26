using CFE_Domain.Material;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Responses.Materials
{
    /// <summary>
    /// Respuesta de busqueda por id
    /// </summary>
    public class GetMaterialByIDResponse
    {
        /// <summary>
        /// Lista de materiales
        /// </summary>
        public  Material materials { get; set; }
    }
}
