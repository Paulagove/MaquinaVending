using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace MaquinaVending {
    internal class Program {
        static List<Producto> productos = new List<Producto>(12);

        static void Main(string[] args) {

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
                        //primero se muestran todos y luego se especifican
                        p.MostrarDetalles(productos);
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
            Producto productoElegido = null;
            bool continuidadCompra = false;
            do {
                Console.WriteLine("Compra de Producto:");
                foreach (Producto p in productos) {
                    Console.WriteLine($"ID: {p.Id} - {p.Nombre} - Precio: {p.PrecioUnitario} - Unidades disponibles: {p.Unidades}");
                }
                Console.WriteLine("Ingrese el ID del producto que desea comprar: ");
                int id = int.Parse(Console.ReadLine());
                Console.WriteLine("Ingrese la cantidad que desea comprar: ");
                int unidades = int.Parse(Console.ReadLine());

                //hacer foreach comparando
                foreach(Producto p in productos) {
                    if(p.Id == id && p.Unidades >= unidades) {
                        productoElegido = p;
                    }
                }
                listaDeLaCompra.Add(productoElegido);
                Console.WriteLine("Producto Añadido a la Cesta");

                Console.Write("Quiere Añadir mas productos a la cesta? (1.Sí/2.No): ");
                continuidadCompra = bool.Parse(Console.ReadLine());

            } while (continuidadCompra == true);


            int opcionPago = 0;
            do {
                Console.WriteLine("Seleccione el método de pago: ");
                Console.WriteLine("1. Pago en efectivo");
                Console.WriteLine("2. Pago con tarjeta");
                opcionPago = int.Parse(Console.ReadLine());

                switch (opcionPago) {
                    case 1:
                        //intentar reducir
                        Pago pagoEf = new Pago(listaDeLaCompra);
                        pagoEf.PagoEfectivo(listaDeLaCompra);
                        break;
                    case 2:
                        Pago pagoTar = new Pago(listaDeLaCompra);
                        pagoTar.PagoTarjeta(listaDeLaCompra);
                        break;
                }
            } while (opcionPago != 2);

        }

        static Producto BuscarProducto() {
            Console.Write("Id del producto: ");
            int idBuscar = int.Parse(Console.ReadLine());

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
                    Console.WriteLine(productoSolicitado.MostrarDetalles());
                }
                else {
                    Console.WriteLine("Producto no encontrado");

                }
                Console.Write("Quiere ver detalles de otro productos (1.Sí/2.No): ");
                continuidadsolicitud = bool.Parse(Console.ReadLine());
            }while (continuidadsolicitud == true);
        }

    }
}
