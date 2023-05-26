using CFE_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Domain.Material
{
    /// <summary>
    /// Entidad de materiales
    /// </summary>
    public class Material : GeneralEntity
    {
        /// <summary>
        /// Folio del material
        /// </summary>
        public long Folio {get; set; }
        /// <summary>
        /// Nombre del material
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Almacen del material
        /// </summary>
        public string store { get; set; }
        /// <summary>
        /// Lote del material
        /// </summary>
        public string Lot { get; set; }
        /// <summary>
        /// Unidad de medida del material
        /// </summary>
        public UnitEmun Unit { get; set; }
    }
}
