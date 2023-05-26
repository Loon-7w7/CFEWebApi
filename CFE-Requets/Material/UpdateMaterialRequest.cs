using CFE_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Material
{
    /// <summary>
    /// Peticion para actualizar materiales
    /// </summary>
    public class UpdateMaterialRequest
    {
        /// <summary>
        /// Folio del material
        /// </summary>
        public long Folio { get; set; }
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
        /// <summary>
        /// Identidicador de la entidad
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Fecha de creacion de la entidad
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// Fecha de modificacion de la entidad
        /// </summary>
        public DateTime UpdateDate { get; set; }
    }
}
