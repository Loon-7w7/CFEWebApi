using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Material
{
    /// <summary>
    /// Peticion para buscar por by
    /// </summary>
    public class GetMaterialByIDRequest
    {
        /// <summary>
        /// Identificaor del maerial
        /// </summary>
        public Guid Id { get; set; }
    }
}
