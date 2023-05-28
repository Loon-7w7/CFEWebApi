using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Material
{
    /// <summary>
    /// PEticion para crear multiples materiales
    /// </summary>
    public class CreateMultiMaterialrequest
    {
        /// <summary>
        /// Lista de materiales a crear
        /// </summary>
        public List<CreateMaterialRequest> Materials { get; set; }
    }
}
