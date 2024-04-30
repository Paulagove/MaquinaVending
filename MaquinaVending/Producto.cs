using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal abstract class Producto {
        public int Id { get; protected set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public double PrecioUnitario { get; set; }
        public string Descripcion { get; set; }

        public Producto() { }

        public Producto(int id) {
            Id = id;
        }
        public Producto(int id, string nombre, int unidades, double precioUnitario, string descripcion) {
            Id = id;
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;
        }

        public virtual string MostrarDetalles()
        {
            return $"({Id}) Nombre: {Nombre} - Unidades: {Unidades} - Precio por Unidad: {PrecioUnitario} - Descripción: {Descripcion}";
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
        public abstract void ToFile();
    }
}
