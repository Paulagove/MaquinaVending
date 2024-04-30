using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class MaterialesPreciosos : Producto {

        public string TipoMaterial { get; set; }
        public double Peso { get; set; }

      public MaterialesPreciosos() { }


        public MaterialesPreciosos(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, double peso)
        : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            Peso = peso;
        }
        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"Tipo de material: {TipoMaterial}, Peso {Peso}";
        }

    }
}
