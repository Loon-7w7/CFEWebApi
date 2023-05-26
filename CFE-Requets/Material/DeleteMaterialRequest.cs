using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Material
{
    /// <summary>
    /// peticion para eliminar un material
    /// </summary>
    public class DeleteMaterialRequest
    {
        /// <summary>
        /// Identificaor del maerial
        /// </summary>
        public Guid Id { get; set; }
    }
}
