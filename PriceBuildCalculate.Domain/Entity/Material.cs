using PriceBuildCalculate.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PriceBuildCalculate.Domain.Entity
{
    public class Material
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public double UnitOfMeasure { get; set; }

        public string Description { get; set; }

        public TypeMaterial TypeMaterial { get; set; }
    }
}
