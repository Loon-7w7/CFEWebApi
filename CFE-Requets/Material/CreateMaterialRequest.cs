﻿using CFE_Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFE_Requets.Material
{
    /// <summary>
    /// peticion para crear materiales
    /// </summary>
    public class CreateMaterialRequest
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
    }
}
