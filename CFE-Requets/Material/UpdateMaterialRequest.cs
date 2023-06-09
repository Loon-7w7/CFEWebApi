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
        /// Codigo del material
        /// </summary>
        public long Code { get; set; }
        /// <summary>
        /// Nombre del material
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Unidad de medida del material
        /// </summary>
        public UnitEmun Unit { get; set; }
        /// <summary>
        /// Precio por unidad del material
        /// </summary>
        public double unirPrice { get; set; }
        public Guid Id { get; set; }
        /// <summary>
        /// Fecha de creacion de la entidad
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
