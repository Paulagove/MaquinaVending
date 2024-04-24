using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class ProductosAlimenticios : Producto {

        public string InformacionNutricional { get; set; }

      

        public ProductosAlimenticios(int id, string nombre, int unidades, double precioUnitario, string descripcion, string informacionNutricional)
        : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            InformacionNutricional = informacionNutricional;
        }

        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"Informacion Nutricional: {InformacionNutricional}";
        }
    }
}
