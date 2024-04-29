using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Program {

        static void Main(string[] args) {
            List<Producto> productos = new List<Producto>(12);

            int opcion = 0;
            do {
                Console.WriteLine("--- MÁQUINA DE VENDING ---");
                Console.WriteLine("1. Comprar Productos");
                Console.WriteLine("2. Mostrar detalles del producto");
                Console.WriteLine("3. Carga individual de producto");
                Console.WriteLine("4.Carga Completa de los productos");
                Console.WriteLine("5.Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion) {
                    case 1:
                        RealizarCompra();
                        break;
                    case 2:
                        productos.MostrarDetalles();
                        break;
                    case 3:
                        Admin admin = new Admin(productos);
                        admin.CargaIndividual();
                        break;
                    case 4:
                        Admin admin2 = new Admin(productos);
                        admin2.CargaCompleta();
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;

                }
            } while (opcion != 5);
        }

        static void RealizarCompra() {
            List<Producto> listaDeLaCompra = new List<Producto>();

            bool continuidadCompra = false;
            do {
                Console.WriteLine("Compra de Producto:");
                foreach (Producto p in productos) {
                    Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} - Precio: {producto.PrecioUnitario} - Unidades disponibles: {producto.Unidades}");
                }
                Console.WriteLine("Ingrese el ID del producto que desea comprar: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad que desea comprar: ");
                int unidades = int.Parse(Console.ReadLine());
                Producto productoElegido = new Producto(id, unidades);
                listaDeLaCompra.Add(productoElegido);
                Console.WriteLine("Producto Añadido a la Cesta");


                Console.WriteLine("Quiere Añadir mas productos a la cesta? (true/false)");

            } while (continuidadCompra == true);


            int opcionPago = 0;
            do {
                Console.WriteLine("Seleccione el método de pago: ");
                Console.WriteLine("1. Pago en efectivo");
                Console.WriteLine("2. Pago con tarjeta");
                opcionPago = int.Parse(Console.ReadLine());

                switch (opcionPago) {
                    case 1:
                        Pago pagoEf = new Pago(listaDeLaCompra);
                        pagoEf.PagoEfectivo();
                        break;
                    case 2:
                        Pago pagoTar = new Pago(listaDeLaCompra);
                        pagoTar.PagoTarjeta();
                        break;
                }
            } while (opcionPago != 2);

        }

        static Producto BuscarProducto() {
            Console.Write("Id del producto: ");
            string idBuscar = Console.ReadLine();

            Producto ProductoBuscar = null;
            foreach (Producto p in productos) {
                if (p.Id == idBuscar) {
                    ProductoBuscar = p;
                }
            }

            if (ProductoBuscar != null) {

                Console.WriteLine(ProductoBuscar);
            }
            else {
                Console.WriteLine(".");
            }
            return ProductoBuscar;
        }


        public void SolicitarDetallesDeProducto() {
            bool continuidadsolicitud = false;
            do {
                foreach (var producto in productos) {
                    Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} ");
                }

                Producto productoSolicitado = BuscarProducto();

                if (productoSolicitado != null) {
                    Console.WriteLine(productoSolicitado.MostrarDetalles);
                }
                else {
                    Console.WriteLine("Producto no encontrado");

                }
                Console.WriteLine("Quiere ver detalles de otro productos. True/False");
                continuidadsolicitud = bool.Parse(Console.ReadLine());
            }while (continuidadsolicitud == true);
        }

    }
}
