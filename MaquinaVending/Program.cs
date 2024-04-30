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
            Admin admin = new Admin(productos);
            string password;
            int opcion = 0;
            do {
                Console.WriteLine("--- MÁQUINA DE VENDING ---");
                Console.WriteLine("1. Comprar Productos");
                Console.WriteLine("2. Mostrar detalles del producto");
                Console.WriteLine("3. Carga individual de producto");
                Console.WriteLine("4. Carga Completa de los productos");
                Console.WriteLine("5. Salir");
                Console.Write("Seleccione una opcion: ");
                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion) {
                    case 1:
                        RealizarCompra();
                        break;
                    case 2:
                        //primero se muestran todos y luego se especifican
                        MostrarDetallesDeProducto();
                        break;
                    case 3:
                        Console.Write("Introduzca la contraseña: ");
                        password = Console.ReadLine();
                        while (admin.LoginAdmin(password) == true) {
                            admin.CargaIndividual();
                            Console.Clear();
                            break;
                        }
                        Console.WriteLine("Contraseña incorrecta");

                        break;
                    case 4:
                        Console.Write("Introduzca la contraseña: ");
                        password = Console.ReadLine();
                        while (admin.LoginAdmin(password) == true) {
                            admin.CargaCompleta();
                            break;
                        }
                        Console.WriteLine("Contraseña incorrecta");
                        break;
                    case 5:
                        Console.WriteLine("Saliendo...");
                        break;

                }
            } while (opcion != 5);
        }

        static void RealizarCompra() {
            List<Producto> listaDeLaCompra = new List<Producto>();
            static List<Producto> productos = new List<Producto>(12);

            Producto productoElegido = null;
            bool continuidadCompra = false;
            do {
                Console.WriteLine("Compra de Producto:");
                foreach (Producto producto in productos) {
                    Console.WriteLine($"ID: {producto.Id} - {producto.Nombre} - Precio: {producto.PrecioUnitario} - Unidades disponibles: {producto.Unidades}");
                }
                Console.Write("Ingrese el ID del producto que desea comprar: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Ingrese la cantidad que desea comprar: ");
                int unidades = int.Parse(Console.ReadLine());

                //hacer foreach comparando
                foreach(Producto p in productos) {
                    if(p.Id == id && p.Unidades >= unidades) {
                        productoElegido = p;
                    }
                }
                listaDeLaCompra.Add(productoElegido);
                Console.WriteLine("Producto Añadido a la Cesta");
                productos.Remove(productoElegido);
                Console.Write("Quiere Añadir mas productos a la cesta? (1.Sí/2.No): ");
                continuidadCompra = bool.Parse(Console.ReadLine());

            } while (continuidadCompra == true);


            int opcionPago = 0;
            do {
                Console.WriteLine("1. Pago en efectivo");
                Console.WriteLine("2. Pago con tarjeta");
                Console.Write("Seleccione el método de pago: ");
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


        static void MostrarDetallesDeProducto() {
            bool continuidadsolicitud = false;
            do {
                foreach (var producto in productos) {
                    Console.WriteLine($"ID: {producto.Id} - Nombre:{producto.Nombre}, Descripcion {producto.Descripcion}, Cantidad {producto.Unidades} ");
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
