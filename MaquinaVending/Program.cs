using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Program {
        static void Main(string[] args)
        {
            
       







        int opcion = 0;
            do
            {
                Console.WriteLine("--- MÁQUINA DE VENDING ---");
                Console.WriteLine("1. Comprar Productos");
                Console.WriteLine("2. Solictitar detalles del producto");
                Console.WriteLine("3. Carga individual de producto");
                Console.WriteLine("4.Carga Completa de los productos");
                Console.WriteLine("5.Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        RealizarCompra();
                       
                        break;
                    case 2:
                        SolicitarDetallesProducto();

                        break;
                    case 3:
                        Admin.CargaIndividual();
                        break;
                    case 4:
                        Admin.CargaCompleta();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo");
                        break;

              }
                Console.WriteLine("Presiona una tecla para continuar");
                Console.ReadKey();
            } while (opcion != 5);
        }

        static void RealizarCompra()
        {

            Console.WriteLine("Compra de Producto:");

            Console.WriteLine("Productos disponibles:");
            foreach (var producto in productos)
            {
            Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} - Precio: {producto.PrecioUnitario} - Unidades disponibles: {producto.Unidades}");
            }

            Console.Write("Ingrese el ID del producto que desea comprar: ");
            //
            Console.Write("Ingrese la cantidad que desea comprar: ");
            //
            Console.Write("Ingrese el dinero: ");
            //

            
        }


        static void SolicitarDetallesProducto()
        {
            Console.WriteLine("Detalles del Producto:");
            // mostrar lista de productos
            Console.Write("Ingrese el ID del producto del que desea ver detalles: ");
            //

            var producto = // metodo que sea buscar producto por id;
            if (producto != null)
            {
                Console.WriteLine();
                producto.MostrarDetalless();
            }
            else
            {
                Console.WriteLine("Producto no encontrado.");
            }
        }




    }
}
