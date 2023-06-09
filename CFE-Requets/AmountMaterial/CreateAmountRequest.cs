using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.AmountMaterial
{
    /// <summary>
    /// Peticion para crear materiales con contador
    /// </summary>
    public class CreateAmountRequest
    {
        /// <summary>
        /// Identificador del material
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// cantidad del material
        /// </summary>
        public int Amount { get; set; } 
    }
}
