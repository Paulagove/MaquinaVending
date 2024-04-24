using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal abstract class Producto {
        protected int Id { get; set; }
        protected string Nombre { get; set; }
        protected int Unidades { get; set; }
        protected double PrecioUnitario { get; set; }
        protected string Descripcion { get; set; }


        public Producto(int id, string nombre, int unidades, double precioUnitario, string descripcion) {
            Id = id;
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
        }

        public virtual string MostrarDetalles()
        {
            return $"Nombre: {Nombre}, Unidades: {Unidades}, Precio por Unidad: {PrecioUnitario}";
        }

    }
}
