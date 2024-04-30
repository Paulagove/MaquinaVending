using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal abstract class Producto {
        public int Id { get; protected set; }
        public string TipoProducto { get; set; }
        public string Nombre { get; set; }
        public int Unidades { get; set; }
        public float PrecioUnitario { get; set; }
        public string Descripcion { get; set; }


        public Producto() { }

        public Producto(int id) {
            Id = id;
        }
        public Producto(int id, string tipoProducto, string nombre, int unidades, float precioUnitario, string descripcion) {
            Id = id;
            TipoProducto = tipoProducto;
            Nombre = nombre;
            Unidades = unidades;
            PrecioUnitario = precioUnitario;
            Descripcion = descripcion;


        }

        public virtual string MostrarDetalles() {
            return $"({Id})| Nombre: {Nombre} | Unidades: {Unidades} | Precio/unidad: {PrecioUnitario} | Descripción: {Descripcion}";
        }
        public virtual void SolicitarDetalles() {
            try {
                Console.Write("Nombre: ");
                Nombre = Console.ReadLine();
                Console.Write("Unidades: ");
                Unidades = int.Parse(Console.ReadLine());
                Console.Write("Precio por unidad: ");
                PrecioUnitario = float.Parse(Console.ReadLine());
                Console.Write("Descripción: ");
                Descripcion = Console.ReadLine();
            }
            catch (FormatException) {
                Console.WriteLine("Error: Opción inválida. Por favor, ingrese un número válido");
            }
            catch (Exception ex) {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
