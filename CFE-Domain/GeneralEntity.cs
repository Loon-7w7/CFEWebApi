using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Domain
{
    public class GeneralEntity
    {
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
