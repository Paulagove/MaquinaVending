using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class ProductosElectronicos : Producto {

        public string TipoMaterial { get; set; }
        public bool TieneBateria { get; set; }
        public bool Precargado { get; set; }

       
        public ProductoElectronico(int id, string nombre, int unidades, double precioUnitario, string descripcion, string tipoMaterial, bool tieneBateria, bool precargado)
        : base(id, nombre, unidades, precioUnitario, descripcion)
        {
            TipoMaterial = tipoMaterial;
            TieneBateria = tieneBateria;
            Precargado = precargado;
        }

        public override string MostrarDetalles()
        {
            return base.MostrarDetalles() + $"Tipo de Material: {TipoMaterial}, Tiene Bateria {TieneBateria}, Viene precargado {Precargado}";
        }


    }
}
