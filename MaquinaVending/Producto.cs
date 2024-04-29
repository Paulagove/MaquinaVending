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
        public double PrecioUnitario { get; set; }
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
            return $"Nombre: {Nombre} - Unidades: {Unidades} - Precio por Unidad: {PrecioUnitario} - Descripción: {Descripcion}";
        }
        public virtual void SolicitarDetalles() {
            Console.Write("Nombre: ");
            Nombre = Console.ReadLine();
            Console.Write("Unidades: ");
            Unidades = int.Parse(Console.ReadLine());
            Console.Write("Precio por unidad: ");
            PrecioUnitario = int.Parse(Console.ReadLine());
            Console.Write("Descripción: ");
            Descripcion = Console.ReadLine();
        }
    }
}
